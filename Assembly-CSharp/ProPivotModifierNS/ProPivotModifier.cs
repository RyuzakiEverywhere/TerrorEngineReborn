using System;
using UnityEngine;

namespace ProPivotModifierNS
{
	// Token: 0x02000164 RID: 356
	public static class ProPivotModifier
	{
		// Token: 0x06000878 RID: 2168 RVA: 0x0004ED3F File Offset: 0x0004D13F
		private static bool VertexOnWrongPos(Vector3 vert)
		{
			return vert.x < 0f || vert.y < 0f || vert.z < 0f;
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0004ED74 File Offset: 0x0004D174
		public static void MovePivotLeft(Mesh meshToMove, Transform referencePivot)
		{
			ProPivotModifier.MovePivotToPointinBoundingBox(meshToMove, referencePivot, ProPivotModifier.BOUNDING_BOX_SIDE.LEFT);
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x0004ED7E File Offset: 0x0004D17E
		public static void MovePivotRight(Mesh meshToMove, Transform referencePivot)
		{
			ProPivotModifier.MovePivotToPointinBoundingBox(meshToMove, referencePivot, ProPivotModifier.BOUNDING_BOX_SIDE.RIGHT);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x0004ED88 File Offset: 0x0004D188
		public static void MovePivotTop(Mesh meshToMove, Transform referencePivot)
		{
			ProPivotModifier.MovePivotToPointinBoundingBox(meshToMove, referencePivot, ProPivotModifier.BOUNDING_BOX_SIDE.TOP);
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x0004ED92 File Offset: 0x0004D192
		public static void MovePivotBottom(Mesh meshToMove, Transform referencePivot)
		{
			ProPivotModifier.MovePivotToPointinBoundingBox(meshToMove, referencePivot, ProPivotModifier.BOUNDING_BOX_SIDE.BOTTOM);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0004ED9C File Offset: 0x0004D19C
		public static void MovePivotFront(Mesh meshToMove, Transform referencePivot)
		{
			ProPivotModifier.MovePivotToPointinBoundingBox(meshToMove, referencePivot, ProPivotModifier.BOUNDING_BOX_SIDE.FRONT);
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0004EDA6 File Offset: 0x0004D1A6
		public static void MovePivotBack(Mesh meshToMove, Transform referencePivot)
		{
			ProPivotModifier.MovePivotToPointinBoundingBox(meshToMove, referencePivot, ProPivotModifier.BOUNDING_BOX_SIDE.BACK);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0004EDB0 File Offset: 0x0004D1B0
		private static void MovePivotToPointinBoundingBox(Mesh meshToMove, Transform referencePivot, ProPivotModifier.BOUNDING_BOX_SIDE direction)
		{
			ProPivotModifier.CenterPivot(meshToMove, referencePivot);
			Vector3[] vertices = meshToMove.vertices;
			Vector3[] array = new Vector3[vertices.Length];
			ProPivotModifier.MeshInfo meshInfo = new ProPivotModifier.MeshInfo(meshToMove, referencePivot);
			Vector3 zero = Vector3.zero;
			switch (direction)
			{
			case ProPivotModifier.BOUNDING_BOX_SIDE.LEFT:
				zero = new Vector3(-meshInfo.SmallestPos.x, 0f, 0f);
				break;
			case ProPivotModifier.BOUNDING_BOX_SIDE.RIGHT:
				zero = new Vector3(meshInfo.SmallestPos.x, 0f, 0f);
				break;
			case ProPivotModifier.BOUNDING_BOX_SIDE.TOP:
				zero = new Vector3(0f, -meshInfo.SmallestPos.y, 0f);
				break;
			case ProPivotModifier.BOUNDING_BOX_SIDE.BOTTOM:
				zero = new Vector3(0f, meshInfo.SmallestPos.y, 0f);
				break;
			case ProPivotModifier.BOUNDING_BOX_SIDE.FRONT:
				zero = new Vector3(0f, 0f, -meshInfo.SmallestPos.z);
				break;
			case ProPivotModifier.BOUNDING_BOX_SIDE.BACK:
				zero = new Vector3(0f, 0f, meshInfo.SmallestPos.z);
				break;
			default:
				Debug.LogError("Uknown bounding box direction: " + direction);
				break;
			}
			Vector3 b = (meshInfo.BiggestPos - meshInfo.SmallestPos) / 2f + zero;
			bool flag = true;
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = vertices[i] - referencePivot.transform.InverseTransformPoint(meshInfo.SmallestPosTransformed);
				if (ProPivotModifier.VertexOnWrongPos(array[i]))
				{
					flag = false;
				}
			}
			if (!flag)
			{
				array = ProPivotModifier.ReOrganizeVertices(array);
			}
			for (int j = 0; j < array.Length; j++)
			{
				array[j] -= b;
			}
			meshToMove.vertices = array;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x0004EFD0 File Offset: 0x0004D3D0
		public static void CenterPivot(Mesh meshToCenter, Transform referencePivot)
		{
			Vector3[] vertices = meshToCenter.vertices;
			Vector3[] array = new Vector3[vertices.Length];
			ProPivotModifier.MeshInfo meshInfo = new ProPivotModifier.MeshInfo(meshToCenter, referencePivot);
			Vector3 b = (meshInfo.BiggestPos - meshInfo.SmallestPos) / 2f;
			bool flag = true;
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = vertices[i] - referencePivot.transform.InverseTransformPoint(meshInfo.SmallestPosTransformed);
				if (ProPivotModifier.VertexOnWrongPos(array[i]))
				{
					flag = false;
				}
			}
			if (!flag)
			{
				array = ProPivotModifier.ReOrganizeVertices(array);
			}
			for (int j = 0; j < array.Length; j++)
			{
				array[j] -= b;
			}
			meshToCenter.vertices = array;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x0004F0BC File Offset: 0x0004D4BC
		private static Vector3[] ReOrganizeVertices(Vector3[] verts)
		{
			Vector3 b = verts[0];
			for (int i = 0; i < verts.Length; i++)
			{
				b = new Vector3((verts[i].x >= b.x) ? b.x : verts[i].x, (verts[i].y >= b.y) ? b.y : verts[i].y, (verts[i].z >= b.z) ? b.z : verts[i].z);
			}
			b = new Vector3((b.x >= 0f) ? 0f : Mathf.Abs(b.x), (b.y >= 0f) ? 0f : Mathf.Abs(b.y), (b.z >= 0f) ? 0f : Mathf.Abs(b.z));
			for (int j = 0; j < verts.Length; j++)
			{
				verts[j] += b;
			}
			return verts;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0004F22C File Offset: 0x0004D62C
		public static void AverageCenterPivot(Mesh meshToCenter, Vector3 initialPivotPos)
		{
			Vector3[] vertices = meshToCenter.vertices;
			Vector3[] array = new Vector3[vertices.Length];
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < vertices.Length; i++)
			{
				vector += initialPivotPos + vertices[i];
			}
			vector = new Vector3(vector.x / (float)vertices.Length, vector.y / (float)vertices.Length, vector.z / (float)vertices.Length);
			for (int j = 0; j < vertices.Length; j++)
			{
				array[j] = vertices[j] + initialPivotPos - vector;
			}
			meshToCenter.vertices = array;
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0004F2EC File Offset: 0x0004D6EC
		public static void MoveSelectedMesh(Mesh meshToMove, Vector3 displacement)
		{
			Vector3[] vertices = meshToMove.vertices;
			Vector3[] array = new Vector3[vertices.Length];
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = vertices[i] + displacement;
			}
			meshToMove.vertices = array;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0004F344 File Offset: 0x0004D744
		public static void RotateSelectedMesh(Mesh meshToRotate, Vector3 angle)
		{
			Vector3[] vertices = meshToRotate.vertices;
			Vector3[] array = new Vector3[vertices.Length];
			Vector3[] normals = meshToRotate.normals;
			Vector3[] array2 = new Vector3[normals.Length];
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = new Vector3((vertices[i].x * Mathf.Cos(0.017453292f * angle.y) + vertices[i].z * Mathf.Sin(0.017453292f * angle.y)) * (float)((angle.y == 0f) ? 0 : 1) + vertices[i].x * (float)((angle.x == 0f) ? 0 : 1) + (vertices[i].x * Mathf.Cos(0.017453292f * angle.z) + vertices[i].y * Mathf.Sin(0.017453292f * angle.z)) * (float)((angle.z == 0f) ? 0 : 1), vertices[i].y * (float)((angle.y == 0f) ? 0 : 1) + (vertices[i].y * Mathf.Cos(0.017453292f * angle.x) + vertices[i].z * Mathf.Sin(0.017453292f * angle.x)) * (float)((angle.x == 0f) ? 0 : 1) + (-vertices[i].x * Mathf.Sin(0.017453292f * angle.z) + vertices[i].y * Mathf.Cos(0.017453292f * angle.z)) * (float)((angle.z == 0f) ? 0 : 1), (-vertices[i].x * Mathf.Sin(0.017453292f * angle.y) + vertices[i].z * Mathf.Cos(0.017453292f * angle.y)) * (float)((angle.y == 0f) ? 0 : 1) + (-vertices[i].y * Mathf.Sin(0.017453292f * angle.x) + vertices[i].z * Mathf.Cos(0.017453292f * angle.x)) * (float)((angle.x == 0f) ? 0 : 1) + vertices[i].z * (float)((angle.z == 0f) ? 0 : 1));
				array2[i] = new Vector3((normals[i].x * Mathf.Cos(0.017453292f * angle.y) + normals[i].z * Mathf.Sin(0.017453292f * angle.y)) * (float)((angle.y == 0f) ? 0 : 1) + normals[i].x * (float)((angle.x == 0f) ? 0 : 1) + (normals[i].x * Mathf.Cos(0.017453292f * angle.z) + normals[i].y * Mathf.Sin(0.017453292f * angle.z)) * (float)((angle.z == 0f) ? 0 : 1), normals[i].y * (float)((angle.y == 0f) ? 0 : 1) + (normals[i].y * Mathf.Cos(0.017453292f * angle.x) + normals[i].z * Mathf.Sin(0.017453292f * angle.x)) * (float)((angle.x == 0f) ? 0 : 1) + (-normals[i].x * Mathf.Sin(0.017453292f * angle.z) + normals[i].y * Mathf.Cos(0.017453292f * angle.z)) * (float)((angle.z == 0f) ? 0 : 1), (-normals[i].x * Mathf.Sin(0.017453292f * angle.y) + normals[i].z * Mathf.Cos(0.017453292f * angle.y)) * (float)((angle.y == 0f) ? 0 : 1) + (-normals[i].y * Mathf.Sin(0.017453292f * angle.x) + normals[i].z * Mathf.Cos(0.017453292f * angle.x)) * (float)((angle.x == 0f) ? 0 : 1) + normals[i].z * (float)((angle.z == 0f) ? 0 : 1));
			}
			meshToRotate.vertices = array;
			meshToRotate.normals = array2;
		}

		// Token: 0x02000165 RID: 357
		public class MeshInfo
		{
			// Token: 0x06000885 RID: 2181 RVA: 0x0004F8FC File Offset: 0x0004DCFC
			public MeshInfo(Mesh meshToProcess, Transform referencePivot)
			{
				this.smallestPosTransformed = referencePivot.transform.TransformPoint(meshToProcess.vertices[0]);
				Vector3 vector = referencePivot.transform.TransformPoint(meshToProcess.vertices[0]);
				this.smallestPos = meshToProcess.vertices[0];
				this.biggestPos = meshToProcess.vertices[0];
				for (int i = 0; i < meshToProcess.vertices.Length; i++)
				{
					vector = referencePivot.transform.TransformPoint(meshToProcess.vertices[i]);
					this.smallestPosTransformed = new Vector3((vector.x >= this.smallestPosTransformed.x) ? this.smallestPosTransformed.x : vector.x, (vector.y >= this.smallestPosTransformed.y) ? this.smallestPosTransformed.y : vector.y, (vector.z >= this.smallestPosTransformed.z) ? this.smallestPosTransformed.z : vector.z);
					this.smallestPos = new Vector3((meshToProcess.vertices[i].x >= this.smallestPos.x) ? this.smallestPos.x : meshToProcess.vertices[i].x, (meshToProcess.vertices[i].y >= this.smallestPos.y) ? this.smallestPos.y : meshToProcess.vertices[i].y, (meshToProcess.vertices[i].z >= this.smallestPos.z) ? this.smallestPos.z : meshToProcess.vertices[i].z);
					this.biggestPos = new Vector3((meshToProcess.vertices[i].x <= this.biggestPos.x) ? this.biggestPos.x : meshToProcess.vertices[i].x, (meshToProcess.vertices[i].y <= this.biggestPos.y) ? this.biggestPos.y : meshToProcess.vertices[i].y, (meshToProcess.vertices[i].z <= this.biggestPos.z) ? this.biggestPos.z : meshToProcess.vertices[i].z);
				}
			}

			// Token: 0x17000082 RID: 130
			// (get) Token: 0x06000886 RID: 2182 RVA: 0x0004FBE9 File Offset: 0x0004DFE9
			public Vector3 SmallestPos
			{
				get
				{
					return this.smallestPos;
				}
			}

			// Token: 0x17000083 RID: 131
			// (get) Token: 0x06000887 RID: 2183 RVA: 0x0004FBF1 File Offset: 0x0004DFF1
			public Vector3 BiggestPos
			{
				get
				{
					return this.biggestPos;
				}
			}

			// Token: 0x17000084 RID: 132
			// (get) Token: 0x06000888 RID: 2184 RVA: 0x0004FBF9 File Offset: 0x0004DFF9
			public Vector3 SmallestPosTransformed
			{
				get
				{
					return this.smallestPosTransformed;
				}
			}

			// Token: 0x04000A97 RID: 2711
			private Vector3 smallestPos;

			// Token: 0x04000A98 RID: 2712
			private Vector3 biggestPos;

			// Token: 0x04000A99 RID: 2713
			private Vector3 smallestPosTransformed;
		}

		// Token: 0x02000166 RID: 358
		private enum BOUNDING_BOX_SIDE
		{
			// Token: 0x04000A9B RID: 2715
			LEFT,
			// Token: 0x04000A9C RID: 2716
			RIGHT,
			// Token: 0x04000A9D RID: 2717
			TOP,
			// Token: 0x04000A9E RID: 2718
			BOTTOM,
			// Token: 0x04000A9F RID: 2719
			FRONT,
			// Token: 0x04000AA0 RID: 2720
			BACK
		}
	}
}
