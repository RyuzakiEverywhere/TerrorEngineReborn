using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x02000185 RID: 389
	public class PathGrid : SolidityGrid, IPathTerrain, IPlanningWorld
	{
		// Token: 0x0600093A RID: 2362 RVA: 0x00052EA1 File Offset: 0x000512A1
		public PathGrid()
		{
			this.m_heightmap = null;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00052EB0 File Offset: 0x000512B0
		public void Awake(Vector3 origin, int numRows, int numCols, float cellSize, bool show, IHeightmap heightmap)
		{
			base.Awake(origin, numRows, numCols, cellSize, show);
			this.m_heightmap = heightmap;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00052EC7 File Offset: 0x000512C7
		public bool HasHeightMap()
		{
			return this.m_heightmap != null;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00052ED8 File Offset: 0x000512D8
		public int GetNeighbors(int index, ref int[] neighbors)
		{
			neighbors = new int[4];
			for (int i = 0; i < 4; i++)
			{
				neighbors[i] = this.GetNeighbor(index, (PathGrid.eNeighborDirection)i);
			}
			return 4;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x00052F0C File Offset: 0x0005130C
		public int GetNumNodes()
		{
			return base.NumberOfCells;
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00052F14 File Offset: 0x00051314
		public float GetGCost(int startIndex, int goalIndex)
		{
			Vector3 pathNodePos = this.GetPathNodePos(startIndex);
			Vector3 pathNodePos2 = this.GetPathNodePos(goalIndex);
			return Vector3.Distance(pathNodePos, pathNodePos2);
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00052F3C File Offset: 0x0005133C
		public float GetHCost(int startIndex, int goalIndex)
		{
			Vector3 pathNodePos = this.GetPathNodePos(startIndex);
			Vector3 pathNodePos2 = this.GetPathNodePos(goalIndex);
			float num = 2f;
			float num2 = num * Vector3.Distance(pathNodePos, pathNodePos2);
			return num2 + Mathf.Abs(pathNodePos2.y - pathNodePos.y) * 1f;
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00052F87 File Offset: 0x00051387
		public bool IsNodeBlocked(int index)
		{
			return base.IsBlocked(index);
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00052F90 File Offset: 0x00051390
		public Vector3 GetPathNodePos(int index)
		{
			Vector3 vector = base.GetCellPosition(index);
			vector += new Vector3(this.m_cellSize / 2f, 0f, this.m_cellSize / 2f);
			vector.y = this.GetTerrainHeight(vector);
			return vector;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00052FE0 File Offset: 0x000513E0
		public int GetPathNodeIndex(Vector3 pos)
		{
			int num = base.GetCellIndex(pos);
			if (!base.IsInBounds(num))
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00053004 File Offset: 0x00051404
		public void ComputePortalsForPathSmoothing(Vector3[] roughPath, out Vector3[] aLeftPortalEndPts, out Vector3[] aRightPortalEndPts)
		{
			GridPortalComputer.ComputePortals(roughPath, this, out aLeftPortalEndPts, out aRightPortalEndPts);
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00053010 File Offset: 0x00051410
		public Vector3 GetValidPathFloorPos(Vector3 position)
		{
			Vector3 b = position;
			float num = this.m_cellSize / 4f;
			Bounds gridBounds = base.GetGridBounds();
			position.x = Mathf.Clamp(position.x, gridBounds.min.x + num, gridBounds.max.x - num);
			position.y = base.Origin.y;
			position.z = Mathf.Clamp(position.z, gridBounds.min.z + num, gridBounds.max.z - num);
			int cellIndex = base.GetCellIndex(position);
			if (base.IsBlocked(cellIndex))
			{
				int[] array = null;
				int neighbors = this.GetNeighbors(cellIndex, ref array);
				float num2 = float.MaxValue;
				for (int i = 0; i < neighbors; i++)
				{
					int index = array[i];
					if (!base.IsBlocked(index))
					{
						Vector3 cellCenter = base.GetCellCenter(index);
						float sqrMagnitude = (cellCenter - b).sqrMagnitude;
						if (sqrMagnitude < num2)
						{
							num2 = sqrMagnitude;
							position = cellCenter;
						}
					}
				}
			}
			return position;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0005313C File Offset: 0x0005153C
		public float GetTerrainHeight(Vector3 position)
		{
			if (this.m_heightmap == null)
			{
				return base.Origin.y;
			}
			return this.m_heightmap.SampleHeight(position);
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00053170 File Offset: 0x00051570
		public PathGrid.eNeighborDirection GetNeighborDirection(int index, int neighborIndex)
		{
			for (int i = 0; i < 4; i++)
			{
				int neighbor = this.GetNeighbor(index, (PathGrid.eNeighborDirection)i);
				if (neighbor == neighborIndex)
				{
					return (PathGrid.eNeighborDirection)i;
				}
			}
			return PathGrid.eNeighborDirection.kNoNeighbor;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x000531A4 File Offset: 0x000515A4
		private int GetNeighbor(int index, PathGrid.eNeighborDirection neighborDirection)
		{
			Vector3 cellCenter = base.GetCellCenter(index);
			switch (neighborDirection)
			{
			case PathGrid.eNeighborDirection.kLeft:
				cellCenter.x -= this.m_cellSize;
				break;
			case PathGrid.eNeighborDirection.kTop:
				cellCenter.z += this.m_cellSize;
				break;
			case PathGrid.eNeighborDirection.kRight:
				cellCenter.x += this.m_cellSize;
				break;
			case PathGrid.eNeighborDirection.kBottom:
				cellCenter.z -= this.m_cellSize;
				break;
			}
			int num = base.GetCellIndex(cellCenter);
			if (!base.IsInBounds(num))
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x04000B1A RID: 2842
		private IHeightmap m_heightmap;

		// Token: 0x02000186 RID: 390
		public enum eNeighborDirection
		{
			// Token: 0x04000B1C RID: 2844
			kNoNeighbor = -1,
			// Token: 0x04000B1D RID: 2845
			kLeft,
			// Token: 0x04000B1E RID: 2846
			kTop,
			// Token: 0x04000B1F RID: 2847
			kRight,
			// Token: 0x04000B20 RID: 2848
			kBottom,
			// Token: 0x04000B21 RID: 2849
			kNumNeighbors
		}
	}
}
