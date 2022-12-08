using System;
using SimpleAI;
using SimpleAI.Navigation;
using UnityEngine;

// Token: 0x02000179 RID: 377
public class PathGridComponent : PathTerrainComponent
{
	// Token: 0x1700008C RID: 140
	// (get) Token: 0x060008F1 RID: 2289 RVA: 0x000516B2 File Offset: 0x0004FAB2
	public PathGrid PathGrid
	{
		get
		{
			return this.m_pathTerrain as PathGrid;
		}
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x000516C0 File Offset: 0x0004FAC0
	private void Awake()
	{
		this.m_pathTerrain = new PathGrid();
		this.settings = GameObject.Find("Settings");
		this.setprop = this.settings.GetComponent<SettingsProperties>();
		Vector3 position = this.settings.transform.position;
		this.m_numberOfRows = 2000;
		this.m_numberOfColumns = 2000;
		this.m_cellSize = 0.5f;
		base.transform.position = new Vector3(-500f, 0f, -500f);
		HeightmapComponent_UnityTerrain component = base.GetComponent<HeightmapComponent_UnityTerrain>();
		this.PathGrid.Awake(base.transform.position, this.m_numberOfRows, this.m_numberOfColumns, this.m_cellSize, this.m_debugShow, component);
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x00051780 File Offset: 0x0004FB80
	private void OnDrawGizmos()
	{
		Gizmos.color = this.m_debugColor;
		if (this.m_debugShow)
		{
			Grid.DebugDraw(base.transform.position, this.m_numberOfRows, this.m_numberOfColumns, this.m_cellSize, Gizmos.color);
		}
		Gizmos.DrawCube(base.transform.position, new Vector3(0.25f, 0.25f, 0.25f));
	}

	// Token: 0x04000AEA RID: 2794
	public int m_numberOfRows = 10;

	// Token: 0x04000AEB RID: 2795
	public int m_numberOfColumns = 10;

	// Token: 0x04000AEC RID: 2796
	public float m_cellSize = 1f;

	// Token: 0x04000AED RID: 2797
	public bool m_debugShow = true;

	// Token: 0x04000AEE RID: 2798
	public Color m_debugColor = Color.white;

	// Token: 0x04000AEF RID: 2799
	public GameObject settings;

	// Token: 0x04000AF0 RID: 2800
	public SettingsProperties setprop;
}
