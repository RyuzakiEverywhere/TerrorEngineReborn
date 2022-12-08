using System;
using System.Collections.Generic;
using SimpleAI.Navigation;

namespace SimpleAI.Planning
{
	// Token: 0x0200018F RID: 399
	public class AStarPlanner : Planner
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x000535DB File Offset: 0x000519DB
		public LinkedList<Node> Solution
		{
			get
			{
				return this.m_solution;
			}
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x000535E4 File Offset: 0x000519E4
		public override void Awake(int maxNumberOfNodes)
		{
			base.Awake(maxNumberOfNodes);
			this.m_openNodes = new BinaryHeap<Node>();
			this.m_openNodes.Capacity = maxNumberOfNodes;
			this.m_nodePool = new Pool<Node>(maxNumberOfNodes);
			this.m_expandedNodes = new Dictionary<int, Pool<Node>.Node>(maxNumberOfNodes);
			this.m_solution = new LinkedList<Node>();
			this.m_reachedGoalNodeSuccessCondition = new ReachedGoalNode_SuccessCondition();
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0005363D File Offset: 0x00051A3D
		public override void Start(IPlanningWorld world)
		{
			base.Start(world);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00053648 File Offset: 0x00051A48
		public override int Update(int numCyclesToConsume)
		{
			if (this.m_planStatus != Planner.ePlanStatus.kPlanning)
			{
				return 0;
			}
			int i = 0;
			while (i < numCyclesToConsume)
			{
				this.m_planStatus = this.RunSingleAStarCycle();
				i++;
				if (this.m_planStatus == Planner.ePlanStatus.kPlanFailed)
				{
					break;
				}
				if (this.m_planStatus == Planner.ePlanStatus.kPlanSucceeded)
				{
					break;
				}
			}
			return i;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x000536A4 File Offset: 0x00051AA4
		public void StartANewPlan(int startNodeIndex, int goalNodeIndex)
		{
			if (startNodeIndex == -1 || goalNodeIndex == -1)
			{
				this.m_planStatus = Planner.ePlanStatus.kPlanFailed;
				return;
			}
			this.m_nodePool.Clear();
			this.m_openNodes.Clear();
			this.m_solution.Clear();
			this.m_expandedNodes.Clear();
			this.m_startNode = this.GetNode(startNodeIndex).Item;
			this.m_goalNode = this.GetNode(goalNodeIndex).Item;
			this.m_reachedGoalNodeSuccessCondition.Awake(this.m_goalNode);
			this.m_successCondition = this.m_reachedGoalNodeSuccessCondition;
			this.m_startNode.G = 0f;
			this.m_startNode.H = base.World.GetHCost(this.m_startNode.Index, this.m_goalNode.Index);
			this.m_startNode.F = this.m_startNode.G + this.m_startNode.H;
			this.m_startNode.Parent = null;
			this.OpenNode(this.m_startNode);
			this.m_planStatus = Planner.ePlanStatus.kPlanning;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x000537B8 File Offset: 0x00051BB8
		protected Planner.ePlanStatus RunSingleAStarCycle()
		{
			if (this.m_openNodes.Count == 0)
			{
				return Planner.ePlanStatus.kPlanFailed;
			}
			Node node = this.m_openNodes.Remove();
			this.CloseNode(node);
			if (this.PlanSucceeded(node))
			{
				this.ConstructSolution();
				return Planner.ePlanStatus.kPlanSucceeded;
			}
			if (this.PlanFailed(node))
			{
				return Planner.ePlanStatus.kPlanFailed;
			}
			int[] array = null;
			int neighbors = base.World.GetNeighbors(node.Index, ref array);
			for (int i = 0; i < neighbors; i++)
			{
				int num = array[i];
				if (num != -1)
				{
					Pool<Node>.Node node2 = this.GetNode(num);
					if (this.m_expandedNodes.Count == this.m_maxNumberOfNodes)
					{
						return Planner.ePlanStatus.kPlanFailed;
					}
					switch (node2.Item.State)
					{
					case Node.eState.kUnvisited:
						this.RecordParentNodeAndPathCosts(node2.Item, node);
						this.OpenNode(node2.Item);
						break;
					case Node.eState.kOpen:
					{
						float gcost = base.World.GetGCost(node.Index, node2.Item.Index);
						float num2 = node.G + gcost;
						if (num2 < node2.Item.G)
						{
							this.RecordParentNodeAndPathCosts(node2.Item, node);
							this.m_openNodes.Remove(node2.Item);
							this.m_openNodes.Add(node2.Item);
						}
						break;
					}
					}
				}
			}
			return Planner.ePlanStatus.kPlanning;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00053934 File Offset: 0x00051D34
		protected void RecordParentNodeAndPathCosts(Node node, Node parentNode)
		{
			node.G = parentNode.G + base.World.GetGCost(parentNode.Index, node.Index);
			node.H = base.World.GetHCost(node.Index, this.m_goalNode.Index);
			node.F = node.G + node.H;
			node.Parent = parentNode;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x000539A4 File Offset: 0x00051DA4
		protected Pool<Node>.Node GetNode(int nodeIndex)
		{
			Pool<Node>.Node result;
			if (!this.m_expandedNodes.TryGetValue(nodeIndex, out result))
			{
				result = this.CreateNode(nodeIndex);
			}
			return result;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x000539CD File Offset: 0x00051DCD
		protected bool PlanFailed(Node currentNode)
		{
			return currentNode != this.m_startNode && this.m_openNodes.Count == this.m_maxNumberOfNodes;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x000539F8 File Offset: 0x00051DF8
		protected void ConstructSolution()
		{
			for (Node node = this.m_goalNode; node != this.m_startNode; node = node.Parent)
			{
				this.m_solution.AddFirst(node);
			}
			this.m_solution.AddFirst(this.m_startNode);
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00053A43 File Offset: 0x00051E43
		protected bool PlanSucceeded(Node currentNode)
		{
			return this.m_successCondition.Evaluate(currentNode);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00053A54 File Offset: 0x00051E54
		protected Pool<Node>.Node CreateNode(int nodeIndex)
		{
			Pool<Node>.Node node = this.m_nodePool.Get();
			this.m_expandedNodes[nodeIndex] = node;
			Node.eState state = Node.eState.kUnvisited;
			if (base.World.IsNodeBlocked(nodeIndex))
			{
				state = Node.eState.kBlocked;
			}
			node.Item.Awake(nodeIndex, state);
			return node;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00053A9E File Offset: 0x00051E9E
		protected void OpenNode(Node node)
		{
			node.State = Node.eState.kOpen;
			this.m_openNodes.Add(node);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00053AB3 File Offset: 0x00051EB3
		protected void CloseNode(Node node)
		{
			node.State = Node.eState.kClosed;
		}

		// Token: 0x04000B36 RID: 2870
		protected BinaryHeap<Node> m_openNodes;

		// Token: 0x04000B37 RID: 2871
		protected Pool<Node> m_nodePool;

		// Token: 0x04000B38 RID: 2872
		protected Dictionary<int, Pool<Node>.Node> m_expandedNodes;

		// Token: 0x04000B39 RID: 2873
		protected Node m_startNode;

		// Token: 0x04000B3A RID: 2874
		protected Node m_goalNode;

		// Token: 0x04000B3B RID: 2875
		protected LinkedList<Node> m_solution;

		// Token: 0x04000B3C RID: 2876
		protected SuccessCondition m_successCondition;

		// Token: 0x04000B3D RID: 2877
		private ReachedGoalNode_SuccessCondition m_reachedGoalNodeSuccessCondition;
	}
}
