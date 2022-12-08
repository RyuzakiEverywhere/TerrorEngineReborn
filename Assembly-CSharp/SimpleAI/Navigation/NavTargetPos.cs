using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x0200017F RID: 383
	public class NavTargetPos : INavTarget
	{
		// Token: 0x06000927 RID: 2343 RVA: 0x00052A84 File Offset: 0x00050E84
		public NavTargetPos(Vector3 targetPos, IPathTerrain pathTerrain)
		{
			this.m_targetPos = targetPos;
			this.m_pathTerrain = pathTerrain;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00052A9A File Offset: 0x00050E9A
		public Vector3 GetNavTargetPosition()
		{
			return this.m_pathTerrain.GetValidPathFloorPos(this.m_targetPos);
		}

		// Token: 0x04000B16 RID: 2838
		private Vector3 m_targetPos;

		// Token: 0x04000B17 RID: 2839
		private IPathTerrain m_pathTerrain;
	}
}
