using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

// Token: 0x0200026C RID: 620
public class csDungeon : csDungeonMap
{
	// Token: 0x060011C1 RID: 4545 RVA: 0x0007343A File Offset: 0x0007183A
	public new void Constructor(int width, int height)
	{
		base.Constructor(width, height);
	}

	// Token: 0x060011C2 RID: 4546 RVA: 0x00073444 File Offset: 0x00071844
	internal void AddRoom(csDungeonRoom room)
	{
		this.rooms.Add(room);
	}

	// Token: 0x060011C3 RID: 4547 RVA: 0x00073454 File Offset: 0x00071854
	public void FlagAllCellsAsUnvisited()
	{
		foreach (Vector2 point in base.CellLocations)
		{
			base[point].Visited = false;
		}
	}

	// Token: 0x060011C4 RID: 4548 RVA: 0x000734B4 File Offset: 0x000718B4
	public Vector2 PickRandomCellAndFlagItAsVisited()
	{
		Vector2 vector = new Vector2((float)csRandom.Instance.Next(base.Width - 1), (float)csRandom.Instance.Next(base.Height - 1));
		this.FlagCellAsVisited(vector);
		return vector;
	}

	// Token: 0x060011C5 RID: 4549 RVA: 0x000734F8 File Offset: 0x000718F8
	public bool AdjacentCellInDirectionIsVisited(Vector2 location, csDungeonCell.DirectionType direction)
	{
		Vector2? targetLocation = base.GetTargetLocation(location, direction);
		if (targetLocation == null)
		{
			return false;
		}
		switch (direction)
		{
		case csDungeonCell.DirectionType.North:
			return base[targetLocation.Value].Visited;
		case csDungeonCell.DirectionType.South:
			return base[targetLocation.Value].Visited;
		case csDungeonCell.DirectionType.East:
			return base[targetLocation.Value].Visited;
		case csDungeonCell.DirectionType.West:
			return base[targetLocation.Value].Visited;
		default:
			throw new InvalidOperationException();
		}
	}

	// Token: 0x060011C6 RID: 4550 RVA: 0x0007358C File Offset: 0x0007198C
	public bool AdjacentCellInDirectionIsCorridor(Vector2 location, csDungeonCell.DirectionType direction)
	{
		Vector2? targetLocation = base.GetTargetLocation(location, direction);
		if (targetLocation == null)
		{
			return false;
		}
		switch (direction)
		{
		case csDungeonCell.DirectionType.North:
			return base[targetLocation.Value].IsCorridor;
		case csDungeonCell.DirectionType.South:
			return base[targetLocation.Value].IsCorridor;
		case csDungeonCell.DirectionType.East:
			return base[targetLocation.Value].IsCorridor;
		case csDungeonCell.DirectionType.West:
			return base[targetLocation.Value].IsCorridor;
		default:
			return false;
		}
	}

	// Token: 0x060011C7 RID: 4551 RVA: 0x0007361C File Offset: 0x00071A1C
	public void FlagCellAsVisited(Vector2 location)
	{
		if (!base.Bounds.Contains(location))
		{
			throw new ArgumentException("Location is outside of Dungeon bounds", "location");
		}
		if (base[location].Visited)
		{
			throw new ArgumentException("Location is already visited", "location");
		}
		base[location].Visited = true;
		this.visitedCells.Add(location);
	}

	// Token: 0x060011C8 RID: 4552 RVA: 0x00073688 File Offset: 0x00071A88
	public Vector2 GetRandomVisitedCell(Vector2 location)
	{
		if (this.visitedCells.Count == 0)
		{
			throw new InvalidOperationException("There are no visited cells to return.");
		}
		int index = csRandom.Instance.Next(this.visitedCells.Count - 1);
		while (this.visitedCells[index] == location)
		{
			index = csRandom.Instance.Next(this.visitedCells.Count - 1);
		}
		return this.visitedCells[index];
	}

	// Token: 0x060011C9 RID: 4553 RVA: 0x00073708 File Offset: 0x00071B08
	public Vector2 CreateCorridor(Vector2 location, csDungeonCell.DirectionType direction)
	{
		Vector2 vector = this.CreateSide(location, direction, csDungeonCell.SideType.Empty);
		base[location].IsCorridor = true;
		base[vector].IsCorridor = true;
		return vector;
	}

	// Token: 0x060011CA RID: 4554 RVA: 0x0007373A File Offset: 0x00071B3A
	public Vector2 CreateWall(Vector2 location, csDungeonCell.DirectionType direction)
	{
		return this.CreateSide(location, direction, csDungeonCell.SideType.Wall);
	}

	// Token: 0x060011CB RID: 4555 RVA: 0x00073745 File Offset: 0x00071B45
	public Vector2 CreateDoor(Vector2 location, csDungeonCell.DirectionType direction)
	{
		return this.CreateSide(location, direction, csDungeonCell.SideType.Door);
	}

	// Token: 0x060011CC RID: 4556 RVA: 0x00073750 File Offset: 0x00071B50
	private Vector2 CreateSide(Vector2 location, csDungeonCell.DirectionType direction, csDungeonCell.SideType sideType)
	{
		Vector2? targetLocation = base.GetTargetLocation(location, direction);
		if (targetLocation == null)
		{
			throw new ArgumentException("There is no adjacent cell in the given direction", "location");
		}
		switch (direction)
		{
		case csDungeonCell.DirectionType.North:
			base[location].NorthSide = sideType;
			base[targetLocation.Value].SouthSide = sideType;
			break;
		case csDungeonCell.DirectionType.South:
			base[location].SouthSide = sideType;
			base[targetLocation.Value].NorthSide = sideType;
			break;
		case csDungeonCell.DirectionType.East:
			base[location].EastSide = sideType;
			base[targetLocation.Value].WestSide = sideType;
			break;
		case csDungeonCell.DirectionType.West:
			base[location].WestSide = sideType;
			base[targetLocation.Value].EastSide = sideType;
			break;
		}
		return targetLocation.Value;
	}

	// Token: 0x1700031A RID: 794
	// (get) Token: 0x060011CD RID: 4557 RVA: 0x0007383B File Offset: 0x00071C3B
	public ReadOnlyCollection<csDungeonRoom> Rooms
	{
		get
		{
			return this.rooms.AsReadOnly();
		}
	}

	// Token: 0x1700031B RID: 795
	// (get) Token: 0x060011CE RID: 4558 RVA: 0x00073848 File Offset: 0x00071C48
	public IEnumerable<Vector2> DeadEndCellLocations
	{
		get
		{
			foreach (Vector2 point in base.CellLocations)
			{
				if (base[point].IsDeadEnd)
				{
					yield return point;
				}
			}
			yield break;
		}
	}

	// Token: 0x1700031C RID: 796
	// (get) Token: 0x060011CF RID: 4559 RVA: 0x0007386C File Offset: 0x00071C6C
	public IEnumerable<Vector2> CorridorCellLocations
	{
		get
		{
			foreach (Vector2 point in base.CellLocations)
			{
				if (base[point].IsCorridor)
				{
					yield return point;
				}
			}
			yield break;
		}
	}

	// Token: 0x1700031D RID: 797
	// (get) Token: 0x060011D0 RID: 4560 RVA: 0x0007388F File Offset: 0x00071C8F
	public bool AllCellsAreVisited
	{
		get
		{
			return this.visitedCells.Count == base.Width * base.Height;
		}
	}

	// Token: 0x04001254 RID: 4692
	private List<Vector2> visitedCells = new List<Vector2>();

	// Token: 0x04001255 RID: 4693
	private List<csDungeonRoom> rooms = new List<csDungeonRoom>();
}
