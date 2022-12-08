using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000271 RID: 625
public class csDungeonGenerator
{
	// Token: 0x060011E2 RID: 4578 RVA: 0x00073D9E File Offset: 0x0007219E
	public void Constructor()
	{
		this.roomGenerator.Constructor(10, 1, 1, 1, 1);
	}

	// Token: 0x060011E3 RID: 4579 RVA: 0x00073DB1 File Offset: 0x000721B1
	public void Constructor(int width, int height, int changeDirectionModifier, int sparsenessModifier, int deadEndRemovalModifier, csDungeonRoomGenerator roomGenerator)
	{
		this.width = width;
		this.height = height;
		this.changeDirectionModifier = changeDirectionModifier;
		this.sparsenessModifier = sparsenessModifier;
		this.deadEndRemovalModifier = deadEndRemovalModifier;
		this.roomGenerator = roomGenerator;
	}

	// Token: 0x060011E4 RID: 4580 RVA: 0x00073DE0 File Offset: 0x000721E0
	public csDungeon Generate()
	{
		csDungeon csDungeon = new csDungeon();
		csDungeon.Constructor(this.width, this.height);
		csDungeon.FlagAllCellsAsUnvisited();
		this.CreateDenseMaze(csDungeon);
		this.SparsifyMaze(csDungeon);
		this.RemoveDeadEnds(csDungeon);
		this.roomGenerator.PlaceRooms(csDungeon);
		this.roomGenerator.PlaceDoors(csDungeon);
		return csDungeon;
	}

	// Token: 0x060011E5 RID: 4581 RVA: 0x00073E3C File Offset: 0x0007223C
	public void CreateDenseMaze(csDungeon dungeon)
	{
		Vector2 location = dungeon.PickRandomCellAndFlagItAsVisited();
		csDungeonCell.DirectionType previousDirection = csDungeonCell.DirectionType.North;
		while (!dungeon.AllCellsAreVisited)
		{
			csDirectionPicker csDirectionPicker = new csDirectionPicker();
			csDirectionPicker.Constructor(previousDirection, this.changeDirectionModifier);
			csDungeonCell.DirectionType nextDirection = csDirectionPicker.GetNextDirection();
			while (!dungeon.HasAdjacentCellInDirection(location, nextDirection) || dungeon.AdjacentCellInDirectionIsVisited(location, nextDirection))
			{
				if (csDirectionPicker.HasNextDirection)
				{
					nextDirection = csDirectionPicker.GetNextDirection();
				}
				else
				{
					location = dungeon.GetRandomVisitedCell(location);
					csDirectionPicker = new csDirectionPicker();
					csDirectionPicker.Constructor(previousDirection, this.changeDirectionModifier);
					nextDirection = csDirectionPicker.GetNextDirection();
				}
			}
			location = dungeon.CreateCorridor(location, nextDirection);
			dungeon.FlagCellAsVisited(location);
			previousDirection = nextDirection;
		}
	}

	// Token: 0x060011E6 RID: 4582 RVA: 0x00073EE8 File Offset: 0x000722E8
	public void SparsifyMaze(csDungeon dungeon)
	{
		int num = (int)Math.Ceiling((double)this.sparsenessModifier / 100.0 * (double)(dungeon.Width * dungeon.Height));
		IEnumerator<Vector2> enumerator = dungeon.DeadEndCellLocations.GetEnumerator();
		for (int i = 0; i < num; i++)
		{
			if (!enumerator.MoveNext())
			{
				enumerator = dungeon.DeadEndCellLocations.GetEnumerator();
				if (!enumerator.MoveNext())
				{
					break;
				}
			}
			Vector2 vector = enumerator.Current;
			dungeon.CreateWall(vector, dungeon[vector].CalculateDeadEndCorridorDirection());
			dungeon[vector].IsCorridor = false;
		}
	}

	// Token: 0x060011E7 RID: 4583 RVA: 0x00073F8C File Offset: 0x0007238C
	public void RemoveDeadEnds(csDungeon dungeon)
	{
		using (IEnumerator<Vector2> enumerator = dungeon.DeadEndCellLocations.GetEnumerator())
		{
			IL_98:
			while (enumerator.MoveNext())
			{
				Vector2 vector = enumerator.Current;
				if (this.ShouldRemoveDeadend())
				{
					Vector2 vector2 = vector;
					for (;;)
					{
						csDirectionPicker csDirectionPicker = new csDirectionPicker();
						csDirectionPicker.Constructor(dungeon[vector2].CalculateDeadEndCorridorDirection(), 100);
						csDungeonCell.DirectionType nextDirection = csDirectionPicker.GetNextDirection();
						while (!dungeon.HasAdjacentCellInDirection(vector2, nextDirection))
						{
							if (!csDirectionPicker.HasNextDirection)
							{
								goto IL_64;
							}
							nextDirection = csDirectionPicker.GetNextDirection();
						}
						vector2 = dungeon.CreateCorridor(vector2, nextDirection);
						if (!dungeon[vector2].IsDeadEnd)
						{
							goto IL_98;
						}
					}
					IL_64:
					throw new InvalidOperationException("This should not happen");
				}
			}
		}
	}

	// Token: 0x060011E8 RID: 4584 RVA: 0x00074060 File Offset: 0x00072460
	public bool ShouldRemoveDeadend()
	{
		return csRandom.Instance.Next(1, 99) < this.deadEndRemovalModifier;
	}

	// Token: 0x060011E9 RID: 4585 RVA: 0x00074078 File Offset: 0x00072478
	public static int[,] ExpandToTiles(csDungeon dungeon)
	{
		int[,] array = new int[dungeon.Width * 2 + 2, dungeon.Height * 2 + 2];
		for (int i = 0; i < dungeon.Width * 2 + 2; i++)
		{
			for (int j = 0; j < dungeon.Height * 2 + 2; j++)
			{
				array[i, j] = 1;
			}
		}
		foreach (Vector2 point in dungeon.CorridorCellLocations)
		{
			Vector2 vector = new Vector2(point.x * 2f + 1f, point.y * 2f + 1f);
			array[(int)vector.x, (int)vector.y] = 2;
			if (dungeon[point].NorthSide == csDungeonCell.SideType.Empty)
			{
				array[(int)vector.x, (int)vector.y - 1] = 2;
			}
			if (dungeon[point].NorthSide == csDungeonCell.SideType.Door)
			{
				array[(int)vector.x, (int)vector.y - 1] = 4;
			}
			if (dungeon[point].NorthSide == csDungeonCell.SideType.Wall)
			{
				array[(int)vector.x, (int)vector.y - 1] = 1;
			}
			if (dungeon[point].SouthSide == csDungeonCell.SideType.Empty)
			{
				array[(int)vector.x, (int)vector.y + 1] = 2;
			}
			if (dungeon[point].SouthSide == csDungeonCell.SideType.Door)
			{
				array[(int)vector.x, (int)vector.y + 1] = 4;
			}
			if (dungeon[point].SouthSide == csDungeonCell.SideType.Wall)
			{
				array[(int)vector.x, (int)vector.y + 1] = 1;
			}
			if (dungeon[point].WestSide == csDungeonCell.SideType.Empty)
			{
				array[(int)vector.x - 1, (int)vector.y] = 2;
			}
			if (dungeon[point].WestSide == csDungeonCell.SideType.Door)
			{
				array[(int)vector.x - 1, (int)vector.y] = 5;
			}
			if (dungeon[point].WestSide == csDungeonCell.SideType.Wall)
			{
				array[(int)vector.x - 1, (int)vector.y] = 1;
			}
			if (dungeon[point].EastSide == csDungeonCell.SideType.Empty)
			{
				array[(int)vector.x + 1, (int)vector.y] = 2;
			}
			if (dungeon[point].EastSide == csDungeonCell.SideType.Door)
			{
				array[(int)vector.x + 1, (int)vector.y] = 5;
			}
			if (dungeon[point].EastSide == csDungeonCell.SideType.Wall)
			{
				array[(int)vector.x + 1, (int)vector.y] = 1;
			}
		}
		foreach (csDungeonRoom csDungeonRoom in dungeon.Rooms)
		{
			Vector2 vector2 = new Vector2(csDungeonRoom.Bounds.xMin * 2f + 1f, csDungeonRoom.Bounds.yMin * 2f + 1f);
			Vector2 vector3 = new Vector2(csDungeonRoom.Bounds.xMax * 2f, csDungeonRoom.Bounds.yMax * 2f);
			for (int k = (int)vector2.x; k < (int)vector3.x; k++)
			{
				for (int l = (int)vector2.y; l < (int)vector3.y; l++)
				{
					array[k, l] = 3;
				}
			}
		}
		List<Vector2> list = new List<Vector2>();
		for (int m = 1; m < dungeon.Width * 2 + 1; m++)
		{
			for (int n = 1; n < dungeon.Height * 2 + 1; n++)
			{
				if (array[m, n] == 1 && array[m - 1, n - 1] == 1 && array[m, n - 1] == 1 && array[m + 1, n - 1] == 1 && array[m - 1, n] == 1 && array[m + 1, n] == 1 && array[m - 1, n + 1] == 1 && array[m, n + 1] == 1 && array[m + 1, n + 1] == 1)
				{
					list.Add(new Vector2((float)m, (float)n));
				}
			}
		}
		foreach (Vector2 vector4 in list)
		{
			array[(int)vector4.x, (int)vector4.y] = 0;
		}
		for (int num = 0; num < dungeon.Width * 2 + 1; num++)
		{
			if (array[num, 0] == 1 && array[num, 1] == 0)
			{
				array[num, 0] = 0;
			}
		}
		for (int num2 = 0; num2 < dungeon.Height * 2 + 1; num2++)
		{
			if (array[0, num2] == 1 && array[1, num2] == 0)
			{
				array[0, num2] = 0;
			}
		}
		return array;
	}

	// Token: 0x17000326 RID: 806
	// (get) Token: 0x060011EA RID: 4586 RVA: 0x00074684 File Offset: 0x00072A84
	// (set) Token: 0x060011EB RID: 4587 RVA: 0x0007468C File Offset: 0x00072A8C
	public int Width
	{
		get
		{
			return this.width;
		}
		set
		{
			this.width = value;
		}
	}

	// Token: 0x17000327 RID: 807
	// (get) Token: 0x060011EC RID: 4588 RVA: 0x00074695 File Offset: 0x00072A95
	// (set) Token: 0x060011ED RID: 4589 RVA: 0x0007469D File Offset: 0x00072A9D
	public int Height
	{
		get
		{
			return this.height;
		}
		set
		{
			this.height = value;
		}
	}

	// Token: 0x17000328 RID: 808
	// (get) Token: 0x060011EE RID: 4590 RVA: 0x000746A6 File Offset: 0x00072AA6
	// (set) Token: 0x060011EF RID: 4591 RVA: 0x000746AE File Offset: 0x00072AAE
	public int ChangeDirectionModifier
	{
		get
		{
			return this.changeDirectionModifier;
		}
		set
		{
			this.changeDirectionModifier = value;
		}
	}

	// Token: 0x17000329 RID: 809
	// (get) Token: 0x060011F0 RID: 4592 RVA: 0x000746B7 File Offset: 0x00072AB7
	// (set) Token: 0x060011F1 RID: 4593 RVA: 0x000746BF File Offset: 0x00072ABF
	public int SparsenessModifier
	{
		get
		{
			return this.sparsenessModifier;
		}
		set
		{
			this.sparsenessModifier = value;
		}
	}

	// Token: 0x1700032A RID: 810
	// (get) Token: 0x060011F2 RID: 4594 RVA: 0x000746C8 File Offset: 0x00072AC8
	// (set) Token: 0x060011F3 RID: 4595 RVA: 0x000746D0 File Offset: 0x00072AD0
	public int DeadEndRemovalModifier
	{
		get
		{
			return this.deadEndRemovalModifier;
		}
		set
		{
			this.deadEndRemovalModifier = value;
		}
	}

	// Token: 0x0400126C RID: 4716
	private int width = 25;

	// Token: 0x0400126D RID: 4717
	private int height = 25;

	// Token: 0x0400126E RID: 4718
	private int changeDirectionModifier = 30;

	// Token: 0x0400126F RID: 4719
	private int sparsenessModifier = 70;

	// Token: 0x04001270 RID: 4720
	private int deadEndRemovalModifier = 50;

	// Token: 0x04001271 RID: 4721
	private csDungeonRoomGenerator roomGenerator = new csDungeonRoomGenerator();
}
