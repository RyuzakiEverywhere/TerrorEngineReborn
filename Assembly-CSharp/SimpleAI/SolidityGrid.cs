using System;
using UnityEngine;

namespace SimpleAI
{
	// Token: 0x02000198 RID: 408
	public class SolidityGrid : Grid
	{
		// Token: 0x060009BD RID: 2493 RVA: 0x00052AE8 File Offset: 0x00050EE8
		public override void Awake(Vector3 origin, int numRows, int numCols, float cellSize, bool show)
		{
			base.Awake(origin, numRows, numCols, cellSize, show);
			this.m_solidList = new bool[numCols, numRows];
			for (int i = 0; i < numCols; i++)
			{
				for (int j = 0; j < numRows; j++)
				{
					this.m_solidList[i, j] = false;
				}
			}
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00052B41 File Offset: 0x00050F41
		public void SetSolidity(bool[,] solidityList)
		{
			this.m_solidList = (bool[,])solidityList.Clone();
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x00052B54 File Offset: 0x00050F54
		public void SetSolidity(int cellIndex, bool bSolid)
		{
			if (!base.IsInBounds(cellIndex))
			{
				return;
			}
			int column = base.GetColumn(cellIndex);
			int row = base.GetRow(cellIndex);
			this.m_solidList[column, row] = bSolid;
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x00052B8C File Offset: 0x00050F8C
		public void SetSolidity(Vector3 cellPos, bool bSolid)
		{
			int cellIndex = base.GetCellIndex(cellPos);
			this.SetSolidity(cellIndex, bSolid);
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x00052BAC File Offset: 0x00050FAC
		public void Raycast2D(Ray ray, out Vector3 isectPt)
		{
			isectPt = new Vector3(0f, 0f, 0f);
			int cellIndex = base.GetCellIndex(ray.origin);
			if (cellIndex < 0 || cellIndex >= base.NumberOfCells)
			{
				return;
			}
			int num = base.GetColumn(cellIndex);
			int num2 = base.GetRow(cellIndex);
			int num3 = Math.Sign(ray.direction.x);
			int num4 = Math.Sign(ray.direction.y);
			Vector3 cellPosition = base.GetCellPosition(cellIndex);
			float num5 = (num3 >= 0) ? (cellPosition.x + this.m_cellSize) : cellPosition.x;
			float num6 = (num4 >= 0) ? cellPosition.z : (cellPosition.z - this.m_cellSize);
			float num7 = Vector3.Angle(Grid.kXAxis, ray.direction);
			float f = num7 * 0.017453292f;
			float num8 = Mathf.Cos(f);
			float num9 = Mathf.Sin(f);
			float num10 = Math.Abs((num5 - ray.origin.x) / num8);
			float num11 = Math.Abs((num6 - ray.origin.y) / num9);
			float num12 = Math.Abs(this.m_cellSize / num8);
			float num13 = Math.Abs(this.m_cellSize / num9);
			bool flag = false;
			bool flag2 = false;
			int num14 = num;
			int num15 = num2;
			int index = -1;
			while (!flag)
			{
				if (num10 < num11)
				{
					num14 = num;
					num10 += num12;
					num += num3;
				}
				else
				{
					num15 = num2;
					num11 += num13;
					num2 += num4;
				}
				if (!base.IsInBounds(num, num2))
				{
					index = base.GetCellIndex(new Vector3((float)num15, (float)num14, 0f));
					flag = true;
					flag2 = true;
				}
				else if (this.m_solidList[num, num2])
				{
					index = base.GetCellIndex(new Vector3((float)num2, (float)num, 0f));
					flag = true;
				}
			}
			if (flag2)
			{
				Bounds gridBounds = base.GetGridBounds();
				float distance = 0f;
				bool flag3 = gridBounds.IntersectRay(ray, out distance);
				if (flag3)
				{
					isectPt = ray.GetPoint(distance);
				}
			}
			else
			{
				Bounds cellBounds = base.GetCellBounds(index);
				float distance2 = 0f;
				bool flag3 = cellBounds.IntersectRay(ray, out distance2);
				if (flag3)
				{
					isectPt = ray.GetPoint(distance2);
				}
			}
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00052E24 File Offset: 0x00051224
		public bool IsBlocked(Vector3 pos)
		{
			int cellIndex = base.GetCellIndex(pos);
			if (!base.IsInBounds(cellIndex))
			{
				return true;
			}
			int column = base.GetColumn(cellIndex);
			int row = base.GetRow(cellIndex);
			return this.m_solidList[column, row];
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00052E68 File Offset: 0x00051268
		public bool IsBlocked(int index)
		{
			int row = base.GetRow(index);
			int column = base.GetColumn(index);
			return !base.IsInBounds(column, row) || this.m_solidList[column, row];
		}

		// Token: 0x04000B58 RID: 2904
		private bool[,] m_solidList;
	}
}
