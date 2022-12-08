using System;
using SimpleAI.Navigation;
using UnityEngine;

// Token: 0x02000175 RID: 373
public class HeightmapComponent_UnityTerrain : MonoBehaviour, IHeightmap
{
	// Token: 0x060008D0 RID: 2256 RVA: 0x00051015 File Offset: 0x0004F415
	private void Start()
	{
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x00051017 File Offset: 0x0004F417
	private void Update()
	{
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x00051019 File Offset: 0x0004F419
	public float SampleHeight(Vector3 position)
	{
		return this.m_terrain.SampleHeight(position);
	}

	// Token: 0x04000AD9 RID: 2777
	public Terrain m_terrain;
}
