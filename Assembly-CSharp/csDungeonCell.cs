using System;

// Token: 0x0200026D RID: 621
public class csDungeonCell
{
	// Token: 0x1700031E RID: 798
	// (get) Token: 0x060011D2 RID: 4562 RVA: 0x00073C48 File Offset: 0x00072048
	// (set) Token: 0x060011D3 RID: 4563 RVA: 0x00073C50 File Offset: 0x00072050
	public csDungeonCell.SideType NorthSide
	{
		get
		{
			return this.northSide;
		}
		set
		{
			this.northSide = value;
		}
	}

	// Token: 0x1700031F RID: 799
	// (get) Token: 0x060011D4 RID: 4564 RVA: 0x00073C59 File Offset: 0x00072059
	// (set) Token: 0x060011D5 RID: 4565 RVA: 0x00073C61 File Offset: 0x00072061
	public csDungeonCell.SideType SouthSide
	{
		get
		{
			return this.southSide;
		}
		set
		{
			this.southSide = value;
		}
	}

	// Token: 0x17000320 RID: 800
	// (get) Token: 0x060011D6 RID: 4566 RVA: 0x00073C6A File Offset: 0x0007206A
	// (set) Token: 0x060011D7 RID: 4567 RVA: 0x00073C72 File Offset: 0x00072072
	public csDungeonCell.SideType EastSide
	{
		get
		{
			return this.eastSide;
		}
		set
		{
			this.eastSide = value;
		}
	}

	// Token: 0x17000321 RID: 801
	// (get) Token: 0x060011D8 RID: 4568 RVA: 0x00073C7B File Offset: 0x0007207B
	// (set) Token: 0x060011D9 RID: 4569 RVA: 0x00073C83 File Offset: 0x00072083
	public csDungeonCell.SideType WestSide
	{
		get
		{
			return this.westSide;
		}
		set
		{
			this.westSide = value;
		}
	}

	// Token: 0x17000322 RID: 802
	// (get) Token: 0x060011DA RID: 4570 RVA: 0x00073C8C File Offset: 0x0007208C
	// (set) Token: 0x060011DB RID: 4571 RVA: 0x00073C94 File Offset: 0x00072094
	public bool Visited
	{
		get
		{
			return this.visited;
		}
		set
		{
			this.visited = value;
		}
	}

	// Token: 0x17000323 RID: 803
	// (get) Token: 0x060011DC RID: 4572 RVA: 0x00073C9D File Offset: 0x0007209D
	// (set) Token: 0x060011DD RID: 4573 RVA: 0x00073CA5 File Offset: 0x000720A5
	public bool IsCorridor
	{
		get
		{
			return this.isCorridor;
		}
		set
		{
			this.isCorridor = value;
		}
	}

	// Token: 0x17000324 RID: 804
	// (get) Token: 0x060011DE RID: 4574 RVA: 0x00073CAE File Offset: 0x000720AE
	public bool IsDeadEnd
	{
		get
		{
			return this.WallCount == 3;
		}
	}

	// Token: 0x17000325 RID: 805
	// (get) Token: 0x060011DF RID: 4575 RVA: 0x00073CBC File Offset: 0x000720BC
	public int WallCount
	{
		get
		{
			int num = 0;
			if (this.northSide == csDungeonCell.SideType.Wall)
			{
				num++;
			}
			if (this.southSide == csDungeonCell.SideType.Wall)
			{
				num++;
			}
			if (this.westSide == csDungeonCell.SideType.Wall)
			{
				num++;
			}
			if (this.eastSide == csDungeonCell.SideType.Wall)
			{
				num++;
			}
			return num;
		}
	}

	// Token: 0x060011E0 RID: 4576 RVA: 0x00073D0C File Offset: 0x0007210C
	public csDungeonCell.DirectionType CalculateDeadEndCorridorDirection()
	{
		if (!this.IsDeadEnd)
		{
			throw new Exception();
		}
		if (this.northSide == csDungeonCell.SideType.Empty)
		{
			return csDungeonCell.DirectionType.North;
		}
		if (this.southSide == csDungeonCell.SideType.Empty)
		{
			return csDungeonCell.DirectionType.South;
		}
		if (this.westSide == csDungeonCell.SideType.Empty)
		{
			return csDungeonCell.DirectionType.West;
		}
		if (this.eastSide == csDungeonCell.SideType.Empty)
		{
			return csDungeonCell.DirectionType.East;
		}
		throw new Exception();
	}

	// Token: 0x04001256 RID: 4694
	private csDungeonCell.SideType northSide = csDungeonCell.SideType.Wall;

	// Token: 0x04001257 RID: 4695
	private csDungeonCell.SideType southSide = csDungeonCell.SideType.Wall;

	// Token: 0x04001258 RID: 4696
	private csDungeonCell.SideType eastSide = csDungeonCell.SideType.Wall;

	// Token: 0x04001259 RID: 4697
	private csDungeonCell.SideType westSide = csDungeonCell.SideType.Wall;

	// Token: 0x0400125A RID: 4698
	private bool visited;

	// Token: 0x0400125B RID: 4699
	private bool isCorridor;

	// Token: 0x0200026E RID: 622
	public enum SideType
	{
		// Token: 0x0400125D RID: 4701
		Empty,
		// Token: 0x0400125E RID: 4702
		Wall,
		// Token: 0x0400125F RID: 4703
		Door
	}

	// Token: 0x0200026F RID: 623
	public enum DirectionType
	{
		// Token: 0x04001261 RID: 4705
		North,
		// Token: 0x04001262 RID: 4706
		South,
		// Token: 0x04001263 RID: 4707
		East,
		// Token: 0x04001264 RID: 4708
		West
	}

	// Token: 0x02000270 RID: 624
	public enum TileType
	{
		// Token: 0x04001266 RID: 4710
		Void,
		// Token: 0x04001267 RID: 4711
		Rock,
		// Token: 0x04001268 RID: 4712
		Corridor,
		// Token: 0x04001269 RID: 4713
		Room,
		// Token: 0x0400126A RID: 4714
		DoorNS,
		// Token: 0x0400126B RID: 4715
		DoorEW
	}
}
