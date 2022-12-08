using System;
using SimpleAI.Navigation;

namespace SimpleAI.Planning
{
	// Token: 0x02000194 RID: 404
	public abstract class Planner
	{
		// Token: 0x060009A6 RID: 2470 RVA: 0x0005356E File Offset: 0x0005196E
		public Planner()
		{
			this.m_planStatus = Planner.ePlanStatus.kInvalid;
			this.m_maxNumberOfNodes = 0;
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x00053584 File Offset: 0x00051984
		protected IPlanningWorld World
		{
			get
			{
				return this.m_world;
			}
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0005358C File Offset: 0x0005198C
		public virtual void Awake(int maxNumberOfNodes)
		{
			this.m_maxNumberOfNodes = maxNumberOfNodes;
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x00053595 File Offset: 0x00051995
		public virtual void Start(IPlanningWorld world)
		{
			this.m_world = world;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0005359E File Offset: 0x0005199E
		public virtual int Update(int numCyclesToConsume)
		{
			return 0;
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x000535A1 File Offset: 0x000519A1
		public virtual void OnDrawGizmos()
		{
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000535A3 File Offset: 0x000519A3
		public bool HasPlanSucceeded()
		{
			return this.m_planStatus == Planner.ePlanStatus.kPlanSucceeded;
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x000535AE File Offset: 0x000519AE
		public bool HasPlanFailed()
		{
			return this.m_planStatus == Planner.ePlanStatus.kPlanFailed;
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x000535B9 File Offset: 0x000519B9
		public bool HasPlanCompleted()
		{
			return this.m_planStatus == Planner.ePlanStatus.kPlanFailed || this.m_planStatus == Planner.ePlanStatus.kPlanSucceeded;
		}

		// Token: 0x04000B4B RID: 2891
		protected Planner.ePlanStatus m_planStatus;

		// Token: 0x04000B4C RID: 2892
		protected int m_maxNumberOfNodes;

		// Token: 0x04000B4D RID: 2893
		private IPlanningWorld m_world;

		// Token: 0x02000195 RID: 405
		public enum ePlanStatus
		{
			// Token: 0x04000B4F RID: 2895
			kInvalid = -1,
			// Token: 0x04000B50 RID: 2896
			kPlanning,
			// Token: 0x04000B51 RID: 2897
			kPlanSucceeded,
			// Token: 0x04000B52 RID: 2898
			kPlanFailed
		}
	}
}
