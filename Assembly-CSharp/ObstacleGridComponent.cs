using System;
using System.Collections;
using SimpleAI.Navigation;
using UnityEngine;

// Token: 0x02000177 RID: 375
[RequireComponent(typeof(PathGridComponent))]
public class ObstacleGridComponent : MonoBehaviour
{
	// Token: 0x060008DD RID: 2269 RVA: 0x000511B1 File Offset: 0x0004F5B1
	private void Start()
	{
		this.m_pathGrid = base.GetComponent<PathGridComponent>().PathGrid;
		this.Rasterize();
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x000511CC File Offset: 0x0004F5CC
	private void Update()
	{
		if (this.m_rasterizeEveryFrame)
		{
		}
		if (GameObject.Find("Play(Clone)") && !this.hasadded && !this.waiting)
		{
			base.StartCoroutine(this.WaitAndPrint(2f));
			this.waiting = true;
		}
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x00051228 File Offset: 0x0004F628
	private IEnumerator WaitAndPrint(float waitTime)
	{
		this.waiting = true;
		yield return new WaitForSeconds(waitTime);
		this.Rasterize();
		this.hasadded = true;
		yield break;
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x0005124C File Offset: 0x0004F64C
	public void Rasterize()
	{
		for (int i = 0; i < this.m_pathGrid.NumberOfCells; i++)
		{
			this.m_pathGrid.SetSolidity(i, false);
		}
		FootprintComponent[] array = (FootprintComponent[])UnityEngine.Object.FindObjectsOfType(typeof(FootprintComponent));
		foreach (FootprintComponent footprintComponent in array)
		{
			int num = 0;
			int[] obstructedCells = footprintComponent.GetObstructedCells(this.m_pathGrid, out num);
			for (int k = 0; k < num; k++)
			{
				int num2 = obstructedCells[k];
				if (this.m_pathGrid.IsInBounds(num2))
				{
					this.m_pathGrid.SetSolidity(num2, true);
				}
			}
		}
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x00051308 File Offset: 0x0004F708
	private void OnDrawGizmos()
	{
		Gizmos.color = this.m_obstructedCellColor;
		if (this.m_show && this.m_pathGrid != null)
		{
			for (int i = 0; i < this.m_pathGrid.NumberOfCells; i++)
			{
				if (this.m_pathGrid.IsBlocked(i))
				{
					Vector3 cellCenter = this.m_pathGrid.GetCellCenter(i);
					Vector3 size = new Vector3(this.m_pathGrid.CellSize, 0.5f, this.m_pathGrid.CellSize);
					Gizmos.DrawCube(cellCenter, size);
				}
			}
		}
	}

	// Token: 0x04000ADD RID: 2781
	public Color m_obstructedCellColor = Color.red;

	// Token: 0x04000ADE RID: 2782
	public bool m_show;

	// Token: 0x04000ADF RID: 2783
	public bool m_rasterizeEveryFrame = true;

	// Token: 0x04000AE0 RID: 2784
	public bool hasadded;

	// Token: 0x04000AE1 RID: 2785
	public bool waiting;

	// Token: 0x04000AE2 RID: 2786
	private PathGrid m_pathGrid;
}
