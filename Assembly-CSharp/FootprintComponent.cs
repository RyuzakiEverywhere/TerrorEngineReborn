using System;
using SimpleAI;
using UnityEngine;

// Token: 0x02000174 RID: 372
public class FootprintComponent : MonoBehaviour
{
	// Token: 0x060008CB RID: 2251 RVA: 0x00050BC4 File Offset: 0x0004EFC4
	private void Awake()
	{
		this.m_numObstructedCellPoolRows = 0;
		this.m_numObstructedCellPoolColumns = 0;
		this.m_obstructedCellPool = null;
		if (!base.gameObject.name.Contains("walls&floors"))
		{
			base.gameObject.layer = 15;
			if (base.GetComponent<Collider>() != null)
			{
				base.GetComponent<Collider>().isTrigger = false;
			}
		}
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x00050C2C File Offset: 0x0004F02C
	public int[] GetObstructedCells(Grid grid, out int numObstructedCells)
	{
		numObstructedCells = 0;
		if (base.GetComponent<Collider>() == null)
		{
			return null;
		}
		Bounds bounds = base.GetComponent<Collider>().bounds;
		bounds.Expand(this.m_scale);
		Vector3 vector = new Vector3(bounds.min.x, grid.Origin.y, bounds.max.z);
		Vector3 vector2 = new Vector3(bounds.max.x, grid.Origin.y, bounds.max.z);
		Vector3 vector3 = new Vector3(bounds.min.x, grid.Origin.y, bounds.min.z);
		Vector3 vector4 = new Vector3(bounds.max.x, grid.Origin.y, bounds.min.z);
		Vector3 normalized = (vector2 - vector).normalized;
		Vector3 normalized2 = (vector - vector3).normalized;
		float x = bounds.size.x;
		float z = bounds.size.z;
		if (this.m_showBoundingBox)
		{
			Debug.DrawLine(vector, vector2);
			Debug.DrawLine(vector2, vector4);
			Debug.DrawLine(vector4, vector3);
			Debug.DrawLine(vector3, vector);
		}
		this.UpdateObstructedCellPool(grid);
		for (int i = 0; i < this.m_numObstructedCellPoolRows; i++)
		{
			float num = (float)i * grid.CellSize;
			for (int j = 0; j < this.m_numObstructedCellPoolColumns; j++)
			{
				float num2 = (float)j * grid.CellSize;
				Vector3 pos = vector3 + normalized * num2 + normalized2 * num;
				pos.x = Mathf.Clamp(pos.x, bounds.min.x, bounds.max.x);
				pos.z = Mathf.Clamp(pos.z, bounds.min.z, bounds.max.z);
				if (grid.IsInBounds(pos))
				{
					int cellIndex = grid.GetCellIndex(pos);
					this.m_obstructedCellPool[numObstructedCells] = cellIndex;
					numObstructedCells++;
				}
				if (num2 > x)
				{
					break;
				}
			}
			if (num > z)
			{
				break;
			}
		}
		return this.m_obstructedCellPool;
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x00050EDC File Offset: 0x0004F2DC
	private void UpdateObstructedCellPool(Grid grid)
	{
		Bounds bounds = base.GetComponent<Collider>().bounds;
		bounds.Expand(this.m_scale);
		int num = (int)(bounds.size.z / grid.CellSize) + 2;
		int num2 = (int)(bounds.size.x / grid.CellSize) + 2;
		int num3 = num * num2;
		if (this.m_obstructedCellPool == null || num3 != this.m_obstructedCellPool.Length)
		{
			this.m_obstructedCellPool = new int[num3];
			this.m_numObstructedCellPoolRows = num;
			this.m_numObstructedCellPoolColumns = num2;
		}
		for (int i = 0; i < this.m_obstructedCellPool.Length; i++)
		{
			this.m_obstructedCellPool[i] = -1;
		}
		if (!base.gameObject.name.Contains("walls&floors"))
		{
			base.gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 1f, 1f);
		}
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x00050FD6 File Offset: 0x0004F3D6
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "NPC")
		{
			other.transform.position = other.gameObject.GetComponent<NpcSync>().firstpos;
		}
	}

	// Token: 0x04000AD4 RID: 2772
	public bool m_showBoundingBox = true;

	// Token: 0x04000AD5 RID: 2773
	public float m_scale = 0.1f;

	// Token: 0x04000AD6 RID: 2774
	private int[] m_obstructedCellPool;

	// Token: 0x04000AD7 RID: 2775
	private int m_numObstructedCellPoolRows;

	// Token: 0x04000AD8 RID: 2776
	private int m_numObstructedCellPoolColumns;
}
