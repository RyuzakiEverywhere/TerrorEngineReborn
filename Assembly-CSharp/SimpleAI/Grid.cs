using System;
using UnityEngine;

namespace SimpleAI
{
	// Token: 0x0200017D RID: 381
	public class Grid
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x000525AA File Offset: 0x000509AA
		public float Width
		{
			get
			{
				return (float)this.m_numberOfColumns * this.m_cellSize;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x000525BA File Offset: 0x000509BA
		public float Height
		{
			get
			{
				return (float)this.m_numberOfRows * this.m_cellSize;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x000525CA File Offset: 0x000509CA
		public Vector3 Origin
		{
			get
			{
				return this.m_origin;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x000525D2 File Offset: 0x000509D2
		public int NumberOfCells
		{
			get
			{
				return this.m_numberOfRows * this.m_numberOfColumns;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x000525E4 File Offset: 0x000509E4
		public float Left
		{
			get
			{
				return this.Origin.x;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x00052600 File Offset: 0x00050A00
		public float Right
		{
			get
			{
				return this.Origin.x + this.Width;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x00052624 File Offset: 0x00050A24
		public float Top
		{
			get
			{
				return this.Origin.z + this.Height;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x00052648 File Offset: 0x00050A48
		public float Bottom
		{
			get
			{
				return this.Origin.z;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x00052663 File Offset: 0x00050A63
		public float CellSize
		{
			get
			{
				return this.m_cellSize;
			}
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0005266B File Offset: 0x00050A6B
		public virtual void Awake(Vector3 origin, int numRows, int numCols, float cellSize, bool show)
		{
			this.m_origin = origin;
			this.m_numberOfRows = numRows;
			this.m_numberOfColumns = numCols;
			this.m_cellSize = cellSize;
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0005268A File Offset: 0x00050A8A
		public virtual void Update()
		{
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0005268C File Offset: 0x00050A8C
		public virtual void OnDrawGizmos()
		{
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00052690 File Offset: 0x00050A90
		public static void DebugDraw(Vector3 origin, int numRows, int numCols, float cellSize, Color color)
		{
			float d = (float)numCols * cellSize;
			float d2 = (float)numRows * cellSize;
			for (int i = 0; i < numRows + 1; i++)
			{
				Vector3 vector = origin + (float)i * cellSize * Grid.kZAxis;
				Vector3 end = vector + d * Grid.kXAxis;
				Debug.DrawLine(vector, end, color);
			}
			for (int j = 0; j < numCols + 1; j++)
			{
				Vector3 vector2 = origin + (float)j * cellSize * Grid.kXAxis;
				Vector3 end2 = vector2 + d2 * Grid.kZAxis;
				Debug.DrawLine(vector2, end2, color);
			}
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0005273C File Offset: 0x00050B3C
		public Vector3 GetNearestCellCenter(Vector3 pos)
		{
			int cellIndex = this.GetCellIndex(pos);
			Vector3 cellPosition = this.GetCellPosition(cellIndex);
			cellPosition.x += this.m_cellSize / 2f;
			cellPosition.z += this.m_cellSize / 2f;
			return cellPosition;
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00052790 File Offset: 0x00050B90
		public Vector3 GetCellCenter(int index)
		{
			Vector3 cellPosition = this.GetCellPosition(index);
			cellPosition.x += this.m_cellSize / 2f;
			cellPosition.z += this.m_cellSize / 2f;
			return cellPosition;
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x000527DC File Offset: 0x00050BDC
		public Vector3 GetCellPosition(int index)
		{
			int row = this.GetRow(index);
			int column = this.GetColumn(index);
			float x = (float)column * this.m_cellSize;
			float z = (float)row * this.m_cellSize;
			return this.Origin + new Vector3(x, 0f, z);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00052828 File Offset: 0x00050C28
		public int GetCellIndex(Vector3 pos)
		{
			if (!this.IsInBounds(pos))
			{
				return -1;
			}
			pos -= this.Origin;
			int num = (int)(pos.x / this.m_cellSize);
			int num2 = (int)(pos.z / this.m_cellSize);
			return num2 * this.m_numberOfColumns + num;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0005287C File Offset: 0x00050C7C
		public int GetCellIndexClamped(Vector3 pos)
		{
			pos -= this.Origin;
			int num = (int)(pos.x / this.m_cellSize);
			int num2 = (int)(pos.z / this.m_cellSize);
			num = Mathf.Clamp(num, 0, this.m_numberOfColumns - 1);
			num2 = Mathf.Clamp(num2, 0, this.m_numberOfRows - 1);
			return num2 * this.m_numberOfColumns + num;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x000528E4 File Offset: 0x00050CE4
		public Bounds GetCellBounds(int index)
		{
			Vector3 cellPosition = this.GetCellPosition(index);
			cellPosition.x += this.m_cellSize / 2f;
			cellPosition.z += this.m_cellSize / 2f;
			Bounds result = new Bounds(cellPosition, new Vector3(this.m_cellSize, Grid.kDepth, this.m_cellSize));
			return result;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0005294C File Offset: 0x00050D4C
		public Bounds GetGridBounds()
		{
			Vector3 center = this.Origin + this.Width / 2f * Grid.kXAxis + this.Height / 2f * Grid.kZAxis;
			Bounds result = new Bounds(center, new Vector3(this.Width, Grid.kDepth, this.Height));
			return result;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x000529B8 File Offset: 0x00050DB8
		public int GetRow(int index)
		{
			return index / this.m_numberOfColumns;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x000529D0 File Offset: 0x00050DD0
		public int GetColumn(int index)
		{
			return index % this.m_numberOfColumns;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x000529E7 File Offset: 0x00050DE7
		public bool IsInBounds(int col, int row)
		{
			return col >= 0 && col < this.m_numberOfColumns && row >= 0 && row < this.m_numberOfRows;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00052A14 File Offset: 0x00050E14
		public bool IsInBounds(int index)
		{
			return index >= 0 && index < this.NumberOfCells;
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x00052A2C File Offset: 0x00050E2C
		public bool IsInBounds(Vector3 pos)
		{
			return pos.x >= this.Left && pos.x <= this.Right && pos.z <= this.Top && pos.z >= this.Bottom;
		}

		// Token: 0x04000B0F RID: 2831
		protected static readonly Vector3 kXAxis = new Vector3(1f, 0f, 0f);

		// Token: 0x04000B10 RID: 2832
		protected static readonly Vector3 kZAxis = new Vector3(0f, 0f, 1f);

		// Token: 0x04000B11 RID: 2833
		private static readonly float kDepth = 1f;

		// Token: 0x04000B12 RID: 2834
		protected int m_numberOfRows;

		// Token: 0x04000B13 RID: 2835
		protected int m_numberOfColumns;

		// Token: 0x04000B14 RID: 2836
		protected float m_cellSize;

		// Token: 0x04000B15 RID: 2837
		private Vector3 m_origin;
	}
}
