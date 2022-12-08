using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x02000180 RID: 384
	public class NavTargetGameObject : INavTarget
	{
		// Token: 0x06000929 RID: 2345 RVA: 0x00052AAD File Offset: 0x00050EAD
		public NavTargetGameObject(GameObject targetGameObject, IPathTerrain pathTerrain)
		{
			this.m_targetGameObject = targetGameObject;
			this.m_pathTerrain = pathTerrain;
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00052AC3 File Offset: 0x00050EC3
		public Vector3 GetNavTargetPosition()
		{
			return this.m_pathTerrain.GetValidPathFloorPos(this.m_targetGameObject.transform.position);
		}

		// Token: 0x04000B18 RID: 2840
		private GameObject m_targetGameObject;

		// Token: 0x04000B19 RID: 2841
		private IPathTerrain m_pathTerrain;
	}
}
