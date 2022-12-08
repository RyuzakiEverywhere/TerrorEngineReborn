using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200008B RID: 139
public class BakeNavMesh : MonoBehaviour
{
	// Token: 0x0600026C RID: 620 RVA: 0x0001792F File Offset: 0x00015D2F
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			this.BakeNow(string.Empty);
		}
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00017948 File Offset: 0x00015D48
	public void BakeNow(string filePath)
	{
		this.nms.defaultArea = 0;
		this.nms.layerMask = this.sceneryMask;
		this.nms.Bake();
		if (CryptoPlayerPrefs.GetInt("Mode", 0) > 3)
		{
			this.GetMesh();
		}
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00017994 File Offset: 0x00015D94
	private void GetMesh()
	{
		NavMeshTriangulation navMeshTriangulation = NavMesh.CalculateTriangulation();
		Mesh mesh = new Mesh();
		mesh.vertices = navMeshTriangulation.vertices;
		mesh.triangles = navMeshTriangulation.indices;
		if (this.normals == null || this.normals.Length != navMeshTriangulation.vertices.Length)
		{
			this.normals = new Vector3[navMeshTriangulation.vertices.Length];
			for (int i = 0; i < navMeshTriangulation.vertices.Length; i++)
			{
				this.normals[i] = Vector3.up;
			}
		}
		mesh.normals = this.normals;
		this.meshModel = mesh;
		MonoBehaviour.print(this.meshModel.bounds);
		base.GetComponent<MeshFilter>().mesh = this.meshModel;
		base.GetComponent<MeshRenderer>().enabled = !base.GetComponent<MeshRenderer>().enabled;
	}

	// Token: 0x040002E7 RID: 743
	public NavMeshSurface nms;

	// Token: 0x040002E8 RID: 744
	public NavMeshData nmd1;

	// Token: 0x040002E9 RID: 745
	public Mesh meshModel;

	// Token: 0x040002EA RID: 746
	public LayerMask sceneryMask;

	// Token: 0x040002EB RID: 747
	public LayerMask avoidMask;

	// Token: 0x040002EC RID: 748
	private Vector3[] normals;
}
