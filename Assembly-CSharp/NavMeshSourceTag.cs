using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000258 RID: 600
[DefaultExecutionOrder(-200)]
public class NavMeshSourceTag : MonoBehaviour
{
	// Token: 0x060010E6 RID: 4326 RVA: 0x0006B00C File Offset: 0x0006940C
	private void OnEnable()
	{
		MeshFilter component = base.GetComponent<MeshFilter>();
		if (component != null)
		{
			NavMeshSourceTag.m_Meshes.Add(component);
		}
		Terrain component2 = base.GetComponent<Terrain>();
		if (component2 != null)
		{
			NavMeshSourceTag.m_Terrains.Add(component2);
		}
	}

	// Token: 0x060010E7 RID: 4327 RVA: 0x0006B058 File Offset: 0x00069458
	private void OnDisable()
	{
		MeshFilter component = base.GetComponent<MeshFilter>();
		if (component != null)
		{
			NavMeshSourceTag.m_Meshes.Remove(component);
		}
		Terrain component2 = base.GetComponent<Terrain>();
		if (component2 != null)
		{
			NavMeshSourceTag.m_Terrains.Remove(component2);
		}
	}

	// Token: 0x060010E8 RID: 4328 RVA: 0x0006B0A4 File Offset: 0x000694A4
	public static void Collect(ref List<NavMeshBuildSource> sources)
	{
		sources.Clear();
		for (int i = 0; i < NavMeshSourceTag.m_Meshes.Count; i++)
		{
			MeshFilter meshFilter = NavMeshSourceTag.m_Meshes[i];
			if (!(meshFilter == null))
			{
				Mesh sharedMesh = meshFilter.sharedMesh;
				if (!(sharedMesh == null))
				{
					NavMeshBuildSource item = default(NavMeshBuildSource);
					item.shape = NavMeshBuildSourceShape.Mesh;
					item.sourceObject = sharedMesh;
					item.transform = meshFilter.transform.localToWorldMatrix;
					item.area = 0;
					sources.Add(item);
				}
			}
		}
		for (int j = 0; j < NavMeshSourceTag.m_Terrains.Count; j++)
		{
			Terrain terrain = NavMeshSourceTag.m_Terrains[j];
			if (!(terrain == null))
			{
				NavMeshBuildSource item2 = default(NavMeshBuildSource);
				item2.shape = NavMeshBuildSourceShape.Terrain;
				item2.sourceObject = terrain.terrainData;
				item2.transform = Matrix4x4.TRS(terrain.transform.position, Quaternion.identity, Vector3.one);
				item2.area = 0;
				sources.Add(item2);
			}
		}
	}

	// Token: 0x04001176 RID: 4470
	public static List<MeshFilter> m_Meshes = new List<MeshFilter>();

	// Token: 0x04001177 RID: 4471
	public static List<Terrain> m_Terrains = new List<Terrain>();
}
