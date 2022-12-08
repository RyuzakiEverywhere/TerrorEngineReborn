using System;
using UnityEngine;

// Token: 0x02000273 RID: 627
public class csDungeonRoom : csDungeonMap
{
	// Token: 0x06001201 RID: 4609 RVA: 0x000746E1 File Offset: 0x00072AE1
	public new void Constructor(int width, int height)
	{
		base.Constructor(width, height);
	}

	// Token: 0x06001202 RID: 4610 RVA: 0x000746EC File Offset: 0x00072AEC
	public void InitializeRoomCells()
	{
		foreach (Vector2 point in base.CellLocations)
		{
			csDungeonCell csDungeonCell = new csDungeonCell();
			csDungeonCell.WestSide = ((point.x != this.bounds.x) ? csDungeonCell.SideType.Empty : csDungeonCell.SideType.Wall);
			csDungeonCell.EastSide = ((point.x != this.bounds.width - 1f) ? csDungeonCell.SideType.Empty : csDungeonCell.SideType.Wall);
			csDungeonCell.NorthSide = ((point.y != this.bounds.y) ? csDungeonCell.SideType.Empty : csDungeonCell.SideType.Wall);
			csDungeonCell.SouthSide = ((point.y != this.bounds.height - 1f) ? csDungeonCell.SideType.Empty : csDungeonCell.SideType.Wall);
			base[point] = csDungeonCell;
		}
	}

	// Token: 0x06001203 RID: 4611 RVA: 0x000747E8 File Offset: 0x00072BE8
	public void SetLocation(Vector2 location)
	{
		this.bounds = new Rect(location.x, location.y, this.bounds.width, this.bounds.height);
	}
}
