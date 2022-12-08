using System;

namespace SimpleAI.Planning
{
	// Token: 0x02000193 RID: 403
	public class ReachedGoalNode_SuccessCondition : SuccessCondition
	{
		// Token: 0x060009A4 RID: 2468 RVA: 0x00054566 File Offset: 0x00052966
		public void Awake(Node goalNode)
		{
			this.m_goalNode = goalNode;
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0005456F File Offset: 0x0005296F
		public override bool Evaluate(Node currentNode)
		{
			return this.m_goalNode == currentNode;
		}

		// Token: 0x04000B4A RID: 2890
		private Node m_goalNode;
	}
}
