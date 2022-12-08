using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x02000188 RID: 392
	public class PathPlanParams
	{
		// Token: 0x0600094B RID: 2379 RVA: 0x00053513 File Offset: 0x00051913
		public PathPlanParams(Vector3 startPos, INavTarget target, float replanInterval)
		{
			this.m_startPos = startPos;
			this.m_target = target;
			this.m_goalPos = target.GetNavTargetPosition();
			this.m_replanInterval = replanInterval;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0005353C File Offset: 0x0005193C
		public Vector3 StartPos
		{
			get
			{
				return this.m_startPos;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x00053544 File Offset: 0x00051944
		public Vector3 GoalPos
		{
			get
			{
				return this.m_goalPos;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x0005354C File Offset: 0x0005194C
		public float ReplanInterval
		{
			get
			{
				return this.m_replanInterval;
			}
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00053554 File Offset: 0x00051954
		public void UpdateStartAndGoalPos(Vector3 newStartPos)
		{
			this.m_startPos = newStartPos;
			this.m_goalPos = this.m_target.GetNavTargetPosition();
		}

		// Token: 0x04000B22 RID: 2850
		private Vector3 m_startPos;

		// Token: 0x04000B23 RID: 2851
		private Vector3 m_goalPos;

		// Token: 0x04000B24 RID: 2852
		private INavTarget m_target;

		// Token: 0x04000B25 RID: 2853
		private float m_replanInterval;
	}
}
