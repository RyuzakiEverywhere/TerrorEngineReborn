using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000278 RID: 632
[ExecuteInEditMode]
public class coDungeonGenerator : MonoBehaviour
{
	// Token: 0x17000338 RID: 824
	// (get) Token: 0x06001237 RID: 4663 RVA: 0x00075519 File Offset: 0x00073919
	public csDungeon Dungeon
	{
		get
		{
			return this.m_dungeon;
		}
	}

	// Token: 0x17000339 RID: 825
	// (get) Token: 0x06001238 RID: 4664 RVA: 0x00075521 File Offset: 0x00073921
	// (set) Token: 0x06001239 RID: 4665 RVA: 0x00075529 File Offset: 0x00073929
	public coDungeonGenerator.enDungeonSize DungeonSize
	{
		get
		{
			return this.m_dungeonSize;
		}
		set
		{
			this.m_dungeonSize = value;
		}
	}

	// Token: 0x1700033A RID: 826
	// (get) Token: 0x0600123A RID: 4666 RVA: 0x00075532 File Offset: 0x00073932
	// (set) Token: 0x0600123B RID: 4667 RVA: 0x0007553A File Offset: 0x0007393A
	public int RoomCount
	{
		get
		{
			return this.m_roomCount;
		}
		set
		{
			this.m_roomCount = Mathf.Clamp(value, 1, 25);
		}
	}

	// Token: 0x1700033B RID: 827
	// (get) Token: 0x0600123C RID: 4668 RVA: 0x0007554B File Offset: 0x0007394B
	// (set) Token: 0x0600123D RID: 4669 RVA: 0x00075553 File Offset: 0x00073953
	public coDungeonGenerator.enRoomSize RoomSizeMIN
	{
		get
		{
			return this.m_roomSizeMIN;
		}
		set
		{
			this.m_roomSizeMIN = value;
		}
	}

	// Token: 0x1700033C RID: 828
	// (get) Token: 0x0600123E RID: 4670 RVA: 0x0007555C File Offset: 0x0007395C
	// (set) Token: 0x0600123F RID: 4671 RVA: 0x00075564 File Offset: 0x00073964
	public coDungeonGenerator.enRoomSize RoomSizeMAX
	{
		get
		{
			return this.m_roomSizeMAX;
		}
		set
		{
			this.m_roomSizeMAX = value;
		}
	}

	// Token: 0x1700033D RID: 829
	// (get) Token: 0x06001240 RID: 4672 RVA: 0x0007556D File Offset: 0x0007396D
	// (set) Token: 0x06001241 RID: 4673 RVA: 0x00075575 File Offset: 0x00073975
	public coDungeonGenerator.enCorridors Corridors
	{
		get
		{
			return this.m_corridors;
		}
		set
		{
			this.m_corridors = value;
		}
	}

	// Token: 0x1700033E RID: 830
	// (get) Token: 0x06001242 RID: 4674 RVA: 0x0007557E File Offset: 0x0007397E
	// (set) Token: 0x06001243 RID: 4675 RVA: 0x00075586 File Offset: 0x00073986
	public coDungeonGenerator.enTwists Twists
	{
		get
		{
			return this.m_twists;
		}
		set
		{
			this.m_twists = value;
		}
	}

	// Token: 0x1700033F RID: 831
	// (get) Token: 0x06001244 RID: 4676 RVA: 0x0007558F File Offset: 0x0007398F
	// (set) Token: 0x06001245 RID: 4677 RVA: 0x00075597 File Offset: 0x00073997
	public coDungeonGenerator.enDeadEnds DeadEnds
	{
		get
		{
			return this.m_deadEnds;
		}
		set
		{
			this.m_deadEnds = value;
		}
	}

	// Token: 0x06001246 RID: 4678 RVA: 0x000755A0 File Offset: 0x000739A0
	public void DestroyDungeon()
	{
		this.m_dungeon = null;
		List<GameObject> list = new List<GameObject>();
		IEnumerator enumerator = base.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				list.Add(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		list.ForEach(delegate(GameObject child)
		{
			UnityEngine.Object.DestroyImmediate(child);
		});
		list.Clear();
		list.TrimExcess();
	}

	// Token: 0x06001247 RID: 4679 RVA: 0x00075648 File Offset: 0x00073A48
	public void CreateDungeon()
	{
		this.DestroyDungeon();
		csDungeonRoomGenerator csDungeonRoomGenerator = new csDungeonRoomGenerator();
		csDungeonRoomGenerator.Constructor(this.m_roomCount, (int)this.m_roomSizeMIN, (int)this.m_roomSizeMAX, (int)this.m_roomSizeMIN, (int)this.m_roomSizeMAX);
		csDungeonGenerator csDungeonGenerator = new csDungeonGenerator();
		csDungeonGenerator.Constructor((int)this.m_dungeonSize, (int)this.m_dungeonSize, (int)this.m_twists, (int)this.m_corridors, (int)this.m_deadEnds, csDungeonRoomGenerator);
		this.m_dungeon = csDungeonGenerator.Generate();
	}

	// Token: 0x06001248 RID: 4680 RVA: 0x000756BC File Offset: 0x00073ABC
	public void Tiny()
	{
		this.m_dungeonSize = coDungeonGenerator.enDungeonSize.Tiny;
	}

	// Token: 0x06001249 RID: 4681 RVA: 0x000756C5 File Offset: 0x00073AC5
	public void Small()
	{
		this.m_dungeonSize = coDungeonGenerator.enDungeonSize.Small;
	}

	// Token: 0x0600124A RID: 4682 RVA: 0x000756CE File Offset: 0x00073ACE
	public void Medium()
	{
		this.m_dungeonSize = coDungeonGenerator.enDungeonSize.Medium;
	}

	// Token: 0x0600124B RID: 4683 RVA: 0x000756D8 File Offset: 0x00073AD8
	public void Large()
	{
		this.m_dungeonSize = coDungeonGenerator.enDungeonSize.Large;
	}

	// Token: 0x0600124C RID: 4684 RVA: 0x000756E2 File Offset: 0x00073AE2
	public void Huge()
	{
		this.m_dungeonSize = coDungeonGenerator.enDungeonSize.Huge;
	}

	// Token: 0x0600124D RID: 4685 RVA: 0x000756EC File Offset: 0x00073AEC
	public void RTiny()
	{
		this.m_roomSizeMAX = coDungeonGenerator.enRoomSize.Tiny;
	}

	// Token: 0x0600124E RID: 4686 RVA: 0x000756F5 File Offset: 0x00073AF5
	public void RSmall()
	{
		this.m_roomSizeMAX = coDungeonGenerator.enRoomSize.Small;
	}

	// Token: 0x0600124F RID: 4687 RVA: 0x000756FE File Offset: 0x00073AFE
	public void RMedium()
	{
		this.m_roomSizeMAX = coDungeonGenerator.enRoomSize.Medium;
	}

	// Token: 0x06001250 RID: 4688 RVA: 0x00075707 File Offset: 0x00073B07
	public void RLarge()
	{
		this.m_roomSizeMAX = coDungeonGenerator.enRoomSize.Large;
	}

	// Token: 0x06001251 RID: 4689 RVA: 0x00075710 File Offset: 0x00073B10
	public void RHuge()
	{
		this.m_roomSizeMAX = coDungeonGenerator.enRoomSize.Huge;
	}

	// Token: 0x06001252 RID: 4690 RVA: 0x00075719 File Offset: 0x00073B19
	public void Maze()
	{
		this.m_corridors = coDungeonGenerator.enCorridors.Maze;
	}

	// Token: 0x06001253 RID: 4691 RVA: 0x00075723 File Offset: 0x00073B23
	public void Dungeon1()
	{
		this.m_corridors = coDungeonGenerator.enCorridors.Dungeon;
	}

	// Token: 0x06001254 RID: 4692 RVA: 0x0007572D File Offset: 0x00073B2D
	public void Sparse()
	{
		this.m_corridors = coDungeonGenerator.enCorridors.Sparse;
	}

	// Token: 0x06001255 RID: 4693 RVA: 0x00075737 File Offset: 0x00073B37
	public void Straight()
	{
		this.m_twists = coDungeonGenerator.enTwists.Straight;
	}

	// Token: 0x06001256 RID: 4694 RVA: 0x00075740 File Offset: 0x00073B40
	public void Minor()
	{
		this.m_twists = coDungeonGenerator.enTwists.Minor;
	}

	// Token: 0x06001257 RID: 4695 RVA: 0x0007574A File Offset: 0x00073B4A
	public void Major()
	{
		this.m_twists = coDungeonGenerator.enTwists.Major;
	}

	// Token: 0x04001284 RID: 4740
	public csDungeon m_dungeon;

	// Token: 0x04001285 RID: 4741
	public coDungeonGenerator.enDungeonSize m_dungeonSize = coDungeonGenerator.enDungeonSize.Small;

	// Token: 0x04001286 RID: 4742
	public int m_roomCount = 5;

	// Token: 0x04001287 RID: 4743
	public coDungeonGenerator.enRoomSize m_roomSizeMIN = coDungeonGenerator.enRoomSize.Small;

	// Token: 0x04001288 RID: 4744
	public coDungeonGenerator.enRoomSize m_roomSizeMAX = coDungeonGenerator.enRoomSize.Small;

	// Token: 0x04001289 RID: 4745
	public coDungeonGenerator.enCorridors m_corridors = coDungeonGenerator.enCorridors.Dungeon;

	// Token: 0x0400128A RID: 4746
	public coDungeonGenerator.enTwists m_twists = coDungeonGenerator.enTwists.Minor;

	// Token: 0x0400128B RID: 4747
	public coDungeonGenerator.enDeadEnds m_deadEnds;

	// Token: 0x02000279 RID: 633
	public enum enDungeonSize
	{
		// Token: 0x0400128E RID: 4750
		Tiny = 4,
		// Token: 0x0400128F RID: 4751
		Small = 8,
		// Token: 0x04001290 RID: 4752
		Medium = 12,
		// Token: 0x04001291 RID: 4753
		Large = 24,
		// Token: 0x04001292 RID: 4754
		Huge = 32
	}

	// Token: 0x0200027A RID: 634
	public enum enRoomSize
	{
		// Token: 0x04001294 RID: 4756
		Tiny = 1,
		// Token: 0x04001295 RID: 4757
		Small,
		// Token: 0x04001296 RID: 4758
		Medium,
		// Token: 0x04001297 RID: 4759
		Large,
		// Token: 0x04001298 RID: 4760
		Huge
	}

	// Token: 0x0200027B RID: 635
	public enum enCorridors
	{
		// Token: 0x0400129A RID: 4762
		Maze = 30,
		// Token: 0x0400129B RID: 4763
		Dungeon = 60,
		// Token: 0x0400129C RID: 4764
		Sparse = 80
	}

	// Token: 0x0200027C RID: 636
	public enum enTwists
	{
		// Token: 0x0400129E RID: 4766
		Straight,
		// Token: 0x0400129F RID: 4767
		Minor = 50,
		// Token: 0x040012A0 RID: 4768
		Major = 100
	}

	// Token: 0x0200027D RID: 637
	public enum enDeadEnds
	{
		// Token: 0x040012A2 RID: 4770
		Allow,
		// Token: 0x040012A3 RID: 4771
		Remove = 100
	}
}
