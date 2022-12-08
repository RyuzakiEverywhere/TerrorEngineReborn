using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000B5 RID: 181
public class InfiniteMapBuilderSpawn : MonoBehaviour
{
	// Token: 0x06000355 RID: 853 RVA: 0x0001F910 File Offset: 0x0001DD10
	private void Start()
	{
		if (!this.PlayerCamera)
		{
			this.PlayerCamera = Camera.main;
		}
		InfiniteMapBuilderSpawn._PlayerCamera = this.PlayerCamera;
		InfiniteMapBuilderSpawn._TileX = this.TileX;
		InfiniteMapBuilderSpawn._TileZ = this.TileZ;
		InfiniteMapBuilderSpawn._SizeOfMap = this.SizeOfMap;
		float far = this.PlayerCamera.far;
		InfiniteMapBuilderSpawn.FarDistance = 25f;
		InfiniteMapBuilderSpawn.MapPool = new ObjectPool(10, this.MapPrefabs.ToArray());
		GameObject objectFromPool = InfiniteMapBuilderSpawn.MapPool.GetObjectFromPool();
		objectFromPool.transform.position = base.transform.position;
		this.FarDistanceShow = InfiniteMapBuilderSpawn.FarDistance;
	}

	// Token: 0x040003AD RID: 941
	public List<GameObject> MapPrefabs = new List<GameObject>();

	// Token: 0x040003AE RID: 942
	public Camera PlayerCamera;

	// Token: 0x040003AF RID: 943
	public static Camera _PlayerCamera;

	// Token: 0x040003B0 RID: 944
	public float SizeOfMap = 50f;

	// Token: 0x040003B1 RID: 945
	public static float _SizeOfMap;

	// Token: 0x040003B2 RID: 946
	public bool TileX = true;

	// Token: 0x040003B3 RID: 947
	public bool TileZ = true;

	// Token: 0x040003B4 RID: 948
	public static bool _TileX;

	// Token: 0x040003B5 RID: 949
	public static bool _TileZ;

	// Token: 0x040003B6 RID: 950
	public float FarDistanceShow;

	// Token: 0x040003B7 RID: 951
	public static float FarDistance;

	// Token: 0x040003B8 RID: 952
	public static ObjectPool MapPool;

	// Token: 0x040003B9 RID: 953
	private GameObject Cube;
}
