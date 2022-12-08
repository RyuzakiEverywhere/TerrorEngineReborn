using System;
using UnityEngine;

// Token: 0x02000274 RID: 628
public class csDungeonRoomGenerator
{
	// Token: 0x06001205 RID: 4613 RVA: 0x00074845 File Offset: 0x00072C45
	public void Constructor()
	{
	}

	// Token: 0x06001206 RID: 4614 RVA: 0x00074847 File Offset: 0x00072C47
	public void Constructor(int noOfRoomsToPlace, int minRoomWidth, int maxRoomWidth, int minRoomHeight, int maxRoomHeight)
	{
		this.noOfRoomsToPlace = noOfRoomsToPlace;
		this.minRoomWidth = minRoomWidth;
		this.maxRoomWidth = maxRoomWidth;
		this.minRoomHeight = minRoomHeight;
		this.maxRoomHeight = maxRoomHeight;
	}

	// Token: 0x17000331 RID: 817
	// (get) Token: 0x06001207 RID: 4615 RVA: 0x0007486E File Offset: 0x00072C6E
	// (set) Token: 0x06001208 RID: 4616 RVA: 0x00074876 File Offset: 0x00072C76
	public int NoOfRoomsToPlace
	{
		get
		{
			return this.noOfRoomsToPlace;
		}
		set
		{
			this.noOfRoomsToPlace = value;
		}
	}

	// Token: 0x17000332 RID: 818
	// (get) Token: 0x06001209 RID: 4617 RVA: 0x0007487F File Offset: 0x00072C7F
	// (set) Token: 0x0600120A RID: 4618 RVA: 0x00074887 File Offset: 0x00072C87
	public int MinRoomWidth
	{
		get
		{
			return this.minRoomWidth;
		}
		set
		{
			this.minRoomWidth = value;
		}
	}

	// Token: 0x17000333 RID: 819
	// (get) Token: 0x0600120B RID: 4619 RVA: 0x00074890 File Offset: 0x00072C90
	// (set) Token: 0x0600120C RID: 4620 RVA: 0x00074898 File Offset: 0x00072C98
	public int MaxRoomWidth
	{
		get
		{
			return this.maxRoomWidth;
		}
		set
		{
			this.maxRoomWidth = value;
		}
	}

	// Token: 0x17000334 RID: 820
	// (get) Token: 0x0600120D RID: 4621 RVA: 0x000748A1 File Offset: 0x00072CA1
	// (set) Token: 0x0600120E RID: 4622 RVA: 0x000748A9 File Offset: 0x00072CA9
	public int MinRoomHeight
	{
		get
		{
			return this.minRoomHeight;
		}
		set
		{
			this.minRoomHeight = value;
		}
	}

	// Token: 0x17000335 RID: 821
	// (get) Token: 0x0600120F RID: 4623 RVA: 0x000748B2 File Offset: 0x00072CB2
	// (set) Token: 0x06001210 RID: 4624 RVA: 0x000748BA File Offset: 0x00072CBA
	public int MaxRoomHeight
	{
		get
		{
			return this.maxRoomHeight;
		}
		set
		{
			this.maxRoomHeight = value;
		}
	}

	// Token: 0x06001211 RID: 4625 RVA: 0x000748C4 File Offset: 0x00072CC4
	public csDungeonRoom CreateRoom(bool forceSmall)
	{
		csDungeonRoom csDungeonRoom = new csDungeonRoom();
		csDungeonRoom.Constructor(csRandom.Instance.Next((!forceSmall) ? this.minRoomWidth : 1, (!forceSmall) ? this.maxRoomWidth : 1), csRandom.Instance.Next((!forceSmall) ? this.minRoomHeight : 1, (!forceSmall) ? this.maxRoomHeight : 1));
		csDungeonRoom.InitializeRoomCells();
		return csDungeonRoom;
	}

	// Token: 0x06001212 RID: 4626 RVA: 0x00074940 File Offset: 0x00072D40
	public void PlaceRooms(csDungeon dungeon)
	{
		int num = 0;
		for (int i = 0; i < this.noOfRoomsToPlace; i++)
		{
			csDungeonRoom room = null;
			room = this.CreateRoom(false);
			int num2 = 0;
			Vector2? vector = null;
			foreach (Vector2 vector2 in dungeon.CorridorCellLocations)
			{
				int num3 = this.CalculateRoomPlacementScore(vector2, room, dungeon);
				if (num3 > num2)
				{
					num2 = num3;
					vector = new Vector2?(vector2);
				}
			}
			if (vector != null)
			{
				this.PlaceRoom(vector.Value, room, dungeon);
				num++;
			}
		}
	}

	// Token: 0x06001213 RID: 4627 RVA: 0x00074A08 File Offset: 0x00072E08
	public int CalculateRoomPlacementScore(Vector2 location, csDungeonRoom room, csDungeon dungeon)
	{
		if (dungeon.Bounds.Contains(location) && dungeon.Bounds.Contains(new Vector2(location.x + (float)room.Width + 1f, location.y + (float)room.Height + 1f)))
		{
			int num = 0;
			foreach (Vector2 vector in room.CellLocations)
			{
				Vector2 vector2 = new Vector2(location.x + vector.x, location.y + vector.y);
				if (dungeon.AdjacentCellInDirectionIsCorridor(vector2, csDungeonCell.DirectionType.North))
				{
					num++;
				}
				if (dungeon.AdjacentCellInDirectionIsCorridor(vector2, csDungeonCell.DirectionType.South))
				{
					num++;
				}
				if (dungeon.AdjacentCellInDirectionIsCorridor(vector2, csDungeonCell.DirectionType.West))
				{
					num++;
				}
				if (dungeon.AdjacentCellInDirectionIsCorridor(vector2, csDungeonCell.DirectionType.East))
				{
					num++;
				}
				if (dungeon[vector2].IsCorridor)
				{
					num += 3;
				}
				foreach (csDungeonRoom csDungeonRoom in dungeon.Rooms)
				{
					if (csDungeonRoom.Bounds.Contains(vector2))
					{
						return 0;
					}
				}
			}
			return num;
		}
		return 0;
	}

	// Token: 0x06001214 RID: 4628 RVA: 0x00074BA8 File Offset: 0x00072FA8
	public void PlaceRoom(Vector2 location, csDungeonRoom room, csDungeon dungeon)
	{
		room.SetLocation(location);
		foreach (Vector2 point in room.CellLocations)
		{
			Vector2 vector = new Vector2(location.x + point.x, location.y + point.y);
			dungeon[vector].NorthSide = room[point].NorthSide;
			dungeon[vector].SouthSide = room[point].SouthSide;
			dungeon[vector].WestSide = room[point].WestSide;
			dungeon[vector].EastSide = room[point].EastSide;
			if (point.x == 0f && dungeon.HasAdjacentCellInDirection(vector, csDungeonCell.DirectionType.West))
			{
				dungeon.CreateWall(vector, csDungeonCell.DirectionType.West);
			}
			if (point.x == (float)(room.Width - 1) && dungeon.HasAdjacentCellInDirection(vector, csDungeonCell.DirectionType.East))
			{
				dungeon.CreateWall(vector, csDungeonCell.DirectionType.East);
			}
			if (point.y == 0f && dungeon.HasAdjacentCellInDirection(vector, csDungeonCell.DirectionType.North))
			{
				dungeon.CreateWall(vector, csDungeonCell.DirectionType.North);
			}
			if (point.y == (float)(room.Height - 1) && dungeon.HasAdjacentCellInDirection(vector, csDungeonCell.DirectionType.South))
			{
				dungeon.CreateWall(vector, csDungeonCell.DirectionType.South);
			}
		}
		dungeon.AddRoom(room);
	}

	// Token: 0x06001215 RID: 4629 RVA: 0x00074D40 File Offset: 0x00073140
	public void PlaceDoors(csDungeon dungeon)
	{
		foreach (csDungeonRoom csDungeonRoom in dungeon.Rooms)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			foreach (Vector2 vector in csDungeonRoom.CellLocations)
			{
				Vector2 location = new Vector2(csDungeonRoom.Bounds.x + vector.x, csDungeonRoom.Bounds.y + vector.y);
				if (vector.x == 0f && dungeon.AdjacentCellInDirectionIsCorridor(location, csDungeonCell.DirectionType.West) && !flag3)
				{
					dungeon.CreateDoor(location, csDungeonCell.DirectionType.West);
					flag3 = true;
				}
				if (vector.x == (float)(csDungeonRoom.Width - 1) && dungeon.AdjacentCellInDirectionIsCorridor(location, csDungeonCell.DirectionType.East) && !flag4)
				{
					dungeon.CreateDoor(location, csDungeonCell.DirectionType.East);
					flag4 = true;
				}
				if (vector.y == 0f && dungeon.AdjacentCellInDirectionIsCorridor(location, csDungeonCell.DirectionType.North) && !flag)
				{
					dungeon.CreateDoor(location, csDungeonCell.DirectionType.North);
					flag = true;
				}
				if (vector.y == (float)(csDungeonRoom.Height - 1) && dungeon.AdjacentCellInDirectionIsCorridor(location, csDungeonCell.DirectionType.South) && !flag2)
				{
					dungeon.CreateDoor(location, csDungeonCell.DirectionType.South);
					flag2 = true;
				}
			}
		}
	}

	// Token: 0x04001274 RID: 4724
	private int maxRoomHeight = 6;

	// Token: 0x04001275 RID: 4725
	private int maxRoomWidth = 6;

	// Token: 0x04001276 RID: 4726
	private int minRoomHeight = 1;

	// Token: 0x04001277 RID: 4727
	private int minRoomWidth = 1;

	// Token: 0x04001278 RID: 4728
	private int noOfRoomsToPlace = 10;
}
