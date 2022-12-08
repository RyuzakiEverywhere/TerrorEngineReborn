using System;
using UnityEngine;

// Token: 0x020000F2 RID: 242
public class MazeMapProperties : MonoBehaviour
{
	// Token: 0x0600048D RID: 1165 RVA: 0x00037BAF File Offset: 0x00035FAF
	private void Start()
	{
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x00037BB1 File Offset: 0x00035FB1
	private void Update()
	{
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x00037BB4 File Offset: 0x00035FB4
	private void SettingsWindow(int windowID)
	{
		GUI.Box(new Rect(20f, 50f, 180f, 190f), "Map Size");
		GUI.Label(new Rect(52f, 90f, 120f, 20f), "Global Size:");
		if (this.tiny && GUI.Button(new Rect(52f, 110f, 120f, 20f), "Tiny"))
		{
			this.tiny = false;
			this.small = true;
			this.medium = false;
			this.large = false;
			this.huge = false;
		}
		if (this.small && GUI.Button(new Rect(52f, 110f, 120f, 20f), "Small"))
		{
			this.tiny = false;
			this.small = false;
			this.medium = true;
			this.large = false;
			this.huge = false;
		}
		if (this.medium && GUI.Button(new Rect(52f, 110f, 120f, 20f), "Medium"))
		{
			this.tiny = false;
			this.small = false;
			this.medium = false;
			this.large = true;
			this.huge = false;
		}
		if (this.large && GUI.Button(new Rect(52f, 110f, 120f, 20f), "Large"))
		{
			this.tiny = false;
			this.small = false;
			this.medium = false;
			this.large = false;
			this.huge = true;
		}
		if (this.huge && GUI.Button(new Rect(52f, 110f, 120f, 20f), "Huge"))
		{
			this.tiny = true;
			this.small = false;
			this.medium = false;
			this.large = false;
			this.huge = false;
		}
		GUI.Label(new Rect(52f, 135f, 120f, 20f), "Max Room Count:");
		this.roomcount = GUI.TextField(new Rect(82f, 155f, 60f, 20f), this.roomcount);
		GUI.Label(new Rect(52f, 180f, 120f, 20f), "Max Room Size:");
		if (this.rtiny && GUI.Button(new Rect(52f, 200f, 120f, 20f), "Tiny"))
		{
			this.rtiny = false;
			this.rsmall = true;
			this.rmedium = false;
			this.rlarge = false;
			this.rhuge = false;
		}
		if (this.rsmall && GUI.Button(new Rect(52f, 200f, 120f, 20f), "Small"))
		{
			this.rtiny = false;
			this.rsmall = false;
			this.rmedium = true;
			this.rlarge = false;
			this.rhuge = false;
		}
		if (this.rmedium && GUI.Button(new Rect(52f, 200f, 120f, 20f), "Medium"))
		{
			this.rtiny = false;
			this.rsmall = false;
			this.rmedium = false;
			this.rlarge = true;
			this.rhuge = false;
		}
		if (this.rlarge && GUI.Button(new Rect(52f, 200f, 120f, 20f), "Large"))
		{
			this.rtiny = false;
			this.rsmall = false;
			this.rmedium = false;
			this.rlarge = false;
			this.rhuge = true;
		}
		if (this.rhuge && GUI.Button(new Rect(52f, 200f, 120f, 20f), "Huge"))
		{
			this.rtiny = true;
			this.rsmall = false;
			this.rmedium = false;
			this.rlarge = false;
			this.rhuge = false;
		}
		this.addroof = GUI.Toggle(new Rect(52f, 250f, 120f, 20f), this.addroof, "Include Celling");
		this.addtorch = GUI.Toggle(new Rect(52f, 270f, 120f, 20f), this.addtorch, "Include Torches");
		GUI.Box(new Rect(210f, 50f, 180f, 300f), "Main Settings");
		GUI.Label(new Rect(242f, 90f, 120f, 20f), "Type:");
		if (this.maze && GUI.Button(new Rect(242f, 110f, 120f, 20f), "Maze"))
		{
			this.maze = false;
			this.dungeon = true;
			this.sparse = false;
		}
		if (this.dungeon && GUI.Button(new Rect(242f, 110f, 120f, 20f), "Dungeon"))
		{
			this.maze = false;
			this.dungeon = false;
			this.sparse = true;
		}
		if (this.sparse && GUI.Button(new Rect(242f, 110f, 120f, 20f), "Sparse"))
		{
			this.maze = true;
			this.dungeon = false;
			this.sparse = false;
		}
		GUI.Label(new Rect(242f, 140f, 120f, 20f), "Corridor Turns:");
		if (this.straight && GUI.Button(new Rect(242f, 160f, 120f, 20f), "Straight"))
		{
			this.straight = false;
			this.minor = true;
			this.major = false;
		}
		if (this.minor && GUI.Button(new Rect(242f, 160f, 120f, 20f), "Minor"))
		{
			this.straight = false;
			this.minor = false;
			this.major = true;
		}
		if (this.major && GUI.Button(new Rect(242f, 160f, 120f, 20f), "Major"))
		{
			this.straight = true;
			this.minor = false;
			this.major = false;
		}
		GUI.Label(new Rect(242f, 190f, 120f, 20f), "Wall ID:");
		this.idwall = GUI.TextField(new Rect(242f, 210f, 120f, 20f), this.idwall);
		GUI.Label(new Rect(242f, 230f, 120f, 20f), "Floor ID:");
		this.idfloor = GUI.TextField(new Rect(242f, 250f, 120f, 20f), this.idfloor);
		GUI.Label(new Rect(242f, 270f, 120f, 20f), "Doorway ID:");
		this.iddoor = GUI.TextField(new Rect(242f, 290f, 120f, 20f), this.iddoor);
		if (GUI.Button(new Rect(340f, 385f, 120f, 20f), "Generate Map"))
		{
			if (this.tiny)
			{
				this.dgm.Tiny();
			}
			if (this.small)
			{
				this.dgm.Small();
			}
			if (this.medium)
			{
				this.dgm.Medium();
			}
			if (this.large)
			{
				this.dgm.Large();
			}
			if (this.huge)
			{
				this.dgm.Huge();
			}
			this.dgm.m_roomCount = Mathf.FloorToInt(float.Parse(this.roomcount));
			if (this.rtiny)
			{
				this.dgm.RTiny();
			}
			if (this.rsmall)
			{
				this.dgm.RSmall();
			}
			if (this.rmedium)
			{
				this.dgm.RMedium();
			}
			if (this.rlarge)
			{
				this.dgm.RLarge();
			}
			if (this.rhuge)
			{
				this.dgm.RHuge();
			}
			if (this.maze)
			{
				this.dgm.Maze();
			}
			if (this.dungeon)
			{
				this.dgm.Dungeon1();
			}
			if (this.sparse)
			{
				this.dgm.Sparse();
			}
			if (this.straight)
			{
				this.dgm.Straight();
			}
			if (this.minor)
			{
				this.dgm.Minor();
			}
			if (this.major)
			{
				this.dgm.Major();
			}
			this.dim.m_prefab_Wall = Resources.Load<GameObject>("walls&floors/" + this.idwall);
			this.dim.m_prefab_Floor = Resources.Load<GameObject>("walls&floors/" + this.idfloor);
			this.dim.m_prefab_Doorway = Resources.Load<GameObject>("walls&floors/" + this.iddoor);
			if (this.addtorch)
			{
				this.dim.m_prefab_Torch = Resources.Load<GameObject>("Effects/WallTorch");
			}
			this.dgm.DestroyDungeon();
			bool flag = false;
			int num = 0;
			int roomCount = this.dgm.RoomCount;
			while (!flag && num < 25)
			{
				this.dgm.CreateDungeon();
				flag = this.dim.ImplementDungeon();
				if (flag)
				{
					this.dgm.RoomCount = roomCount;
				}
				else
				{
					this.dgm.RoomCount--;
					num++;
				}
			}
			base.enabled = false;
		}
		if (GUI.Button(new Rect(275f, 385f, 60f, 20f), "Back"))
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x000385FD File Offset: 0x000369FD
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(11, new Rect(5f, 30f, 480f, 425f), new GUI.WindowFunction(this.SettingsWindow), "Simple Map Generator");
	}

	// Token: 0x0400077A RID: 1914
	public coDungeonGenerator dgm;

	// Token: 0x0400077B RID: 1915
	public coDungeonImplementorModular dim;

	// Token: 0x0400077C RID: 1916
	public GUISkin skin;

	// Token: 0x0400077D RID: 1917
	public bool tiny;

	// Token: 0x0400077E RID: 1918
	public bool small;

	// Token: 0x0400077F RID: 1919
	public bool medium = true;

	// Token: 0x04000780 RID: 1920
	public bool large;

	// Token: 0x04000781 RID: 1921
	public bool huge;

	// Token: 0x04000782 RID: 1922
	public bool rtiny;

	// Token: 0x04000783 RID: 1923
	public bool rsmall;

	// Token: 0x04000784 RID: 1924
	public bool rmedium = true;

	// Token: 0x04000785 RID: 1925
	public bool rlarge;

	// Token: 0x04000786 RID: 1926
	public bool rhuge;

	// Token: 0x04000787 RID: 1927
	public string roomcount = "5";

	// Token: 0x04000788 RID: 1928
	public bool maze = true;

	// Token: 0x04000789 RID: 1929
	public bool dungeon;

	// Token: 0x0400078A RID: 1930
	public bool sparse;

	// Token: 0x0400078B RID: 1931
	public bool straight;

	// Token: 0x0400078C RID: 1932
	public bool minor = true;

	// Token: 0x0400078D RID: 1933
	public bool major;

	// Token: 0x0400078E RID: 1934
	public string idwall = "idwall50";

	// Token: 0x0400078F RID: 1935
	public string idfloor = "idfloor13";

	// Token: 0x04000790 RID: 1936
	public string iddoor = "idwall1";

	// Token: 0x04000791 RID: 1937
	public bool addroof;

	// Token: 0x04000792 RID: 1938
	public bool addtorch;
}
