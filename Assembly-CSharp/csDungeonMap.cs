using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000272 RID: 626
public abstract class csDungeonMap
{
	// Token: 0x060011F5 RID: 4597 RVA: 0x00073084 File Offset: 0x00071484
	protected void Constructor(int width, int height)
	{
		this.cells = new csDungeonCell[width, height];
		this.bounds = new Rect(0f, 0f, (float)width, (float)height);
		foreach (Vector2 point in this.CellLocations)
		{
			this[point] = new csDungeonCell();
		}
	}

	// Token: 0x1700032B RID: 811
	// (get) Token: 0x060011F6 RID: 4598 RVA: 0x00073108 File Offset: 0x00071508
	public Rect Bounds
	{
		get
		{
			return this.bounds;
		}
	}

	// Token: 0x1700032C RID: 812
	public csDungeonCell this[Vector2 point]
	{
		get
		{
			return this[point.x, point.y];
		}
		set
		{
			this[point.x, point.y] = value;
		}
	}

	// Token: 0x1700032D RID: 813
	public csDungeonCell this[float x, float y]
	{
		get
		{
			return this.cells[(int)x, (int)y];
		}
		set
		{
			this.cells[(int)x, (int)y] = value;
		}
	}

	// Token: 0x1700032E RID: 814
	// (get) Token: 0x060011FB RID: 4603 RVA: 0x00073160 File Offset: 0x00071560
	public int Width
	{
		get
		{
			return (int)this.bounds.width;
		}
	}

	// Token: 0x1700032F RID: 815
	// (get) Token: 0x060011FC RID: 4604 RVA: 0x0007316E File Offset: 0x0007156E
	public int Height
	{
		get
		{
			return (int)this.bounds.height;
		}
	}

	// Token: 0x17000330 RID: 816
	// (get) Token: 0x060011FD RID: 4605 RVA: 0x0007317C File Offset: 0x0007157C
	public IEnumerable<Vector2> CellLocations
	{
		get
		{
			for (int x = 0; x < this.Width; x++)
			{
				for (int y = 0; y < this.Height; y++)
				{
					yield return new Vector2((float)x, (float)y);
				}
			}
			yield break;
		}
	}

	// Token: 0x060011FE RID: 4606 RVA: 0x000731A0 File Offset: 0x000715A0
	public bool HasAdjacentCellInDirection(Vector2 location, csDungeonCell.DirectionType direction)
	{
		if (!this.Bounds.Contains(location))
		{
			return false;
		}
		switch (direction)
		{
		case csDungeonCell.DirectionType.North:
			return location.y > 0f;
		case csDungeonCell.DirectionType.South:
			return location.y < (float)(this.Height - 1);
		case csDungeonCell.DirectionType.East:
			return location.x < (float)(this.Width - 1);
		case csDungeonCell.DirectionType.West:
			return location.x > 0f;
		default:
			return false;
		}
	}

	// Token: 0x060011FF RID: 4607 RVA: 0x00073224 File Offset: 0x00071624
	protected Vector2? GetTargetLocation(Vector2 location, csDungeonCell.DirectionType direction)
	{
		if (!this.HasAdjacentCellInDirection(location, direction))
		{
			return null;
		}
		switch (direction)
		{
		case csDungeonCell.DirectionType.North:
			return new Vector2?(new Vector2(location.x, location.y - 1f));
		case csDungeonCell.DirectionType.South:
			return new Vector2?(new Vector2(location.x, location.y + 1f));
		case csDungeonCell.DirectionType.East:
			return new Vector2?(new Vector2(location.x + 1f, location.y));
		case csDungeonCell.DirectionType.West:
			return new Vector2?(new Vector2(location.x - 1f, location.y));
		default:
			throw new InvalidOperationException();
		}
	}

	// Token: 0x04001272 RID: 4722
	protected csDungeonCell[,] cells;

	// Token: 0x04001273 RID: 4723
	protected Rect bounds;
}
