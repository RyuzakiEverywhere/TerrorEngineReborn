using System;
using SimpleAI.Navigation;
using UnityEngine;

// Token: 0x0200017B RID: 379
public abstract class PathTerrainComponent : MonoBehaviour
{
	// Token: 0x1700008E RID: 142
	// (get) Token: 0x06000902 RID: 2306 RVA: 0x00051675 File Offset: 0x0004FA75
	public IPathTerrain PathTerrain
	{
		get
		{
			return this.m_pathTerrain;
		}
	}

	// Token: 0x04000AFC RID: 2812
	protected IPathTerrain m_pathTerrain;
}
