using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x02000187 RID: 391
	public static class GridPortalComputer
	{
		// Token: 0x06000949 RID: 2377 RVA: 0x00053254 File Offset: 0x00051654
		public static void ComputePortals(Vector3[] roughPath, PathGrid grid, out Vector3[] aLeftEndPts, out Vector3[] aRightEndPts)
		{
			aLeftEndPts = null;
			aRightEndPts = null;
			if (roughPath.Length < 2)
			{
				return;
			}
			aLeftEndPts = new Vector3[roughPath.Length - 1];
			aRightEndPts = new Vector3[roughPath.Length - 1];
			for (int i = 0; i < roughPath.Length - 1; i++)
			{
				Vector3 startPos = roughPath[i];
				Vector3 endPos = roughPath[i + 1];
				Vector3 vector;
				Vector3 vector2;
				GridPortalComputer.ComputePortal(startPos, endPos, grid, out vector, out vector2);
				aLeftEndPts[i] = vector;
				aRightEndPts[i] = vector2;
			}
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x000532E4 File Offset: 0x000516E4
		private static void ComputePortal(Vector3 startPos, Vector3 endPos, PathGrid grid, out Vector3 leftPoint, out Vector3 rightPoint)
		{
			leftPoint = Vector3.zero;
			rightPoint = Vector3.zero;
			int cellIndex = grid.GetCellIndex(startPos);
			int cellIndex2 = grid.GetCellIndex(endPos);
			Bounds cellBounds = grid.GetCellBounds(cellIndex);
			switch (grid.GetNeighborDirection(cellIndex, cellIndex2))
			{
			case PathGrid.eNeighborDirection.kLeft:
				leftPoint = new Vector3(cellBounds.min.x, grid.Origin.y, cellBounds.min.z);
				rightPoint = new Vector3(cellBounds.min.x, grid.Origin.y, cellBounds.max.z);
				break;
			case PathGrid.eNeighborDirection.kTop:
				leftPoint = new Vector3(cellBounds.min.x, grid.Origin.y, cellBounds.max.z);
				rightPoint = new Vector3(cellBounds.max.x, grid.Origin.y, cellBounds.max.z);
				break;
			case PathGrid.eNeighborDirection.kRight:
				leftPoint = new Vector3(cellBounds.max.x, grid.Origin.y, cellBounds.max.z);
				rightPoint = new Vector3(cellBounds.max.x, grid.Origin.y, cellBounds.min.z);
				break;
			case PathGrid.eNeighborDirection.kBottom:
				leftPoint = new Vector3(cellBounds.max.x, grid.Origin.y, cellBounds.min.z);
				rightPoint = new Vector3(cellBounds.min.x, grid.Origin.y, cellBounds.min.z);
				break;
			default:
				Debug.LogError("ComputePortal failed to find a neighbor");
				break;
			}
		}
	}
}
