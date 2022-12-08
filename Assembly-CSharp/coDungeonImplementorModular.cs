using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200027F RID: 639
[Serializable]
public class coDungeonImplementorModular : coDungeonImplementor
{
	// Token: 0x17000340 RID: 832
	// (get) Token: 0x0600125C RID: 4700 RVA: 0x0007577A File Offset: 0x00073B7A
	// (set) Token: 0x0600125D RID: 4701 RVA: 0x00075782 File Offset: 0x00073B82
	public GameObject Floor
	{
		get
		{
			return this.m_prefab_Floor;
		}
		set
		{
			this.m_prefab_Floor = value;
		}
	}

	// Token: 0x17000341 RID: 833
	// (get) Token: 0x0600125E RID: 4702 RVA: 0x0007578B File Offset: 0x00073B8B
	// (set) Token: 0x0600125F RID: 4703 RVA: 0x00075793 File Offset: 0x00073B93
	public GameObject Wall
	{
		get
		{
			return this.m_prefab_Wall;
		}
		set
		{
			this.m_prefab_Wall = value;
		}
	}

	// Token: 0x17000342 RID: 834
	// (get) Token: 0x06001260 RID: 4704 RVA: 0x0007579C File Offset: 0x00073B9C
	// (set) Token: 0x06001261 RID: 4705 RVA: 0x000757A4 File Offset: 0x00073BA4
	public GameObject Door
	{
		get
		{
			return this.m_prefab_Door;
		}
		set
		{
			this.m_prefab_Door = value;
		}
	}

	// Token: 0x17000343 RID: 835
	// (get) Token: 0x06001262 RID: 4706 RVA: 0x000757AD File Offset: 0x00073BAD
	// (set) Token: 0x06001263 RID: 4707 RVA: 0x000757B5 File Offset: 0x00073BB5
	public GameObject DoorWay
	{
		get
		{
			return this.m_prefab_Doorway;
		}
		set
		{
			this.m_prefab_Doorway = value;
		}
	}

	// Token: 0x06001264 RID: 4708 RVA: 0x000757C0 File Offset: 0x00073BC0
	public override bool ImplementDungeon()
	{
		this.m_scaleH = this.m_scale / 2f;
		coDungeonGenerator coDungeonGenerator = (coDungeonGenerator)base.transform.GetComponent(typeof(coDungeonGenerator));
		if (coDungeonGenerator)
		{
			foreach (Vector2 vector in coDungeonGenerator.Dungeon.CellLocations)
			{
				if (coDungeonGenerator.Dungeon[vector].SouthSide == csDungeonCell.SideType.Wall && coDungeonGenerator.Dungeon[vector].NorthSide == csDungeonCell.SideType.Wall && coDungeonGenerator.Dungeon[vector].EastSide == csDungeonCell.SideType.Wall && coDungeonGenerator.Dungeon[vector].WestSide == csDungeonCell.SideType.Wall)
				{
					Vector3 position = new Vector3(vector.x * this.m_scale, 1f, vector.y * this.m_scale);
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Dirt, position, Quaternion.Euler(-90f, 0f, 0f));
				}
				if (coDungeonGenerator.Dungeon[vector].SouthSide != csDungeonCell.SideType.Wall || coDungeonGenerator.Dungeon[vector].NorthSide != csDungeonCell.SideType.Wall || coDungeonGenerator.Dungeon[vector].EastSide != csDungeonCell.SideType.Wall || coDungeonGenerator.Dungeon[vector].WestSide != csDungeonCell.SideType.Wall)
				{
					Vector3 vector2 = new Vector3(vector.x * this.m_scale, 0f, vector.y * this.m_scale);
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Floor, vector2, Quaternion.Euler(0f, 0f, 0f));
					gameObject2.name = "walls&floors/" + this.m_prefab_Floor.name;
					if (base.gameObject.GetComponent<MazeMapProperties>().addroof)
					{
						GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Floor, vector2 + new Vector3(0f, 4f, 0f), Quaternion.Euler(0f, 0f, 0f));
						gameObject3.name = "walls&floors/" + this.m_prefab_Floor.name;
					}
					if (coDungeonGenerator.Dungeon[vector].SouthSide == csDungeonCell.SideType.Wall)
					{
						Vector3 vector3 = vector2;
						vector3.z += this.m_scaleH;
						if (!this.ObjectExists(vector3))
						{
							GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Wall, vector3, Quaternion.Euler(0f, 180f, 0f));
							gameObject4.name = "walls&floors/" + this.m_prefab_Wall.name;
							if (this.m_prefab_Torch && UnityEngine.Random.Range(0f, 1f) > 0.5f)
							{
								Vector3 position2 = vector3;
								position2.y += 1.75f;
								position2.z -= 0.05f;
								GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Torch, position2, Quaternion.Euler(0f, 180f, 0f));
							}
						}
					}
					if (coDungeonGenerator.Dungeon[vector].NorthSide == csDungeonCell.SideType.Wall)
					{
						Vector3 vector4 = vector2;
						vector4.z -= this.m_scaleH;
						if (!this.ObjectExists(vector4))
						{
							GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Wall, vector4, Quaternion.Euler(0f, 180f, 0f));
							gameObject6.name = "walls&floors/" + this.m_prefab_Wall.name;
							if (this.m_prefab_Torch && UnityEngine.Random.Range(0f, 1f) > 0.5f)
							{
								Vector3 position3 = vector4;
								position3.y += 1.75f;
								position3.z += 0.05f;
								GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Torch, position3, Quaternion.Euler(0f, 0f, 0f));
							}
						}
					}
					if (coDungeonGenerator.Dungeon[vector].EastSide == csDungeonCell.SideType.Wall)
					{
						Vector3 vector5 = vector2;
						vector5.x += this.m_scaleH;
						if (!this.ObjectExists(vector5))
						{
							GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Wall, vector5, Quaternion.Euler(0f, 90f, 0f));
							gameObject8.name = "walls&floors/" + this.m_prefab_Wall.name;
							if (this.m_prefab_Torch && UnityEngine.Random.Range(0f, 1f) > 0.5f)
							{
								Vector3 position4 = vector5;
								position4.y += 1.75f;
								position4.x -= 0.05f;
								GameObject gameObject9 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Torch, position4, Quaternion.Euler(0f, 270f, 0f));
							}
						}
					}
					if (coDungeonGenerator.Dungeon[vector].WestSide == csDungeonCell.SideType.Wall)
					{
						Vector3 vector6 = vector2;
						vector6.x -= this.m_scaleH;
						if (!this.ObjectExists(vector6))
						{
							GameObject gameObject10 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Wall, vector6, Quaternion.Euler(0f, 90f, 0f));
							gameObject10.name = "walls&floors/" + this.m_prefab_Wall.name;
							if (this.m_prefab_Torch && UnityEngine.Random.Range(0f, 1f) > 0.5f)
							{
								Vector3 position5 = vector6;
								position5.y += 1.75f;
								position5.x += 0.05f;
								GameObject gameObject11 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Torch, position5, Quaternion.Euler(0f, 90f, 0f));
							}
						}
					}
					if (coDungeonGenerator.Dungeon[vector].SouthSide == csDungeonCell.SideType.Door)
					{
						Vector3 vector7 = vector2;
						vector7.z += this.m_scaleH;
						if (!this.ObjectExists(vector7))
						{
							GameObject gameObject12 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Doorway, vector7, Quaternion.Euler(0f, -180f, 0f));
							gameObject12.GetComponent<WallProperties>().iswall = false;
							gameObject12.GetComponent<WallProperties>().isdoor = true;
							gameObject12.name = "walls&floors/" + this.m_prefab_Doorway.name;
							Vector3 position6 = vector7;
							position6.x += this.m_scaleH * 0.33f;
							GameObject gameObject13 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Door, position6, Quaternion.Euler(0f, 0f, 0f));
						}
					}
					if (coDungeonGenerator.Dungeon[vector].NorthSide == csDungeonCell.SideType.Door)
					{
						Vector3 vector8 = vector2;
						vector8.z -= this.m_scaleH;
						if (!this.ObjectExists(vector8))
						{
							Vector3 position7 = vector8;
							position7.x += this.m_scaleH * 0.33f;
							GameObject gameObject14 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Door, position7, Quaternion.Euler(0f, 0f, 0f));
						}
					}
					if (coDungeonGenerator.Dungeon[vector].EastSide == csDungeonCell.SideType.Door)
					{
						Vector3 vector9 = vector2;
						vector9.x += this.m_scaleH;
						if (!this.ObjectExists(vector9))
						{
							GameObject gameObject15 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Doorway, vector9, Quaternion.Euler(0f, -90f, 0f));
							gameObject15.GetComponent<WallProperties>().iswall = false;
							gameObject15.GetComponent<WallProperties>().isdoor = true;
							gameObject15.name = "walls&floors/" + this.m_prefab_Doorway.name;
							Vector3 position8 = vector9;
							position8.z += this.m_scaleH * 0.33f;
							GameObject gameObject16 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Door, position8, Quaternion.Euler(0f, -90f, 0f));
						}
					}
					if (coDungeonGenerator.Dungeon[vector].WestSide == csDungeonCell.SideType.Door)
					{
						Vector3 vector10 = vector2;
						vector10.x -= this.m_scaleH;
						if (!this.ObjectExists(vector10))
						{
							Vector3 position9 = vector10;
							position9.z += this.m_scaleH * 0.33f;
							GameObject gameObject17 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Door, position9, Quaternion.Euler(0f, -90f, 0f));
						}
					}
					Vector3 vector11 = Vector3.zero;
					vector11 = vector2;
					vector11.z += this.m_scaleH;
					vector11.x += this.m_scaleH;
					if (!this.ObjectExists(vector11) && (coDungeonGenerator.Dungeon[vector].SouthSide != csDungeonCell.SideType.Empty || coDungeonGenerator.Dungeon[vector].EastSide != csDungeonCell.SideType.Empty))
					{
						GameObject gameObject18 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Pillar, vector11, Quaternion.Euler(-90f, 0f, 0f));
					}
					vector11 = vector2;
					vector11.z -= this.m_scaleH;
					vector11.x -= this.m_scaleH;
					if (!this.ObjectExists(vector11) && (coDungeonGenerator.Dungeon[vector].NorthSide != csDungeonCell.SideType.Empty || coDungeonGenerator.Dungeon[vector].WestSide != csDungeonCell.SideType.Empty))
					{
						GameObject gameObject19 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Pillar, vector11, Quaternion.Euler(-90f, 0f, 0f));
					}
					vector11 = vector2;
					vector11.z += this.m_scaleH;
					vector11.x -= this.m_scaleH;
					if (!this.ObjectExists(vector11) && (coDungeonGenerator.Dungeon[vector].SouthSide != csDungeonCell.SideType.Empty || coDungeonGenerator.Dungeon[vector].WestSide != csDungeonCell.SideType.Empty))
					{
						GameObject gameObject20 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Pillar, vector11, Quaternion.Euler(-90f, 0f, 0f));
					}
					vector11 = vector2;
					vector11.z -= this.m_scaleH;
					vector11.x += this.m_scaleH;
					if (!this.ObjectExists(vector11) && (coDungeonGenerator.Dungeon[vector].NorthSide != csDungeonCell.SideType.Empty || coDungeonGenerator.Dungeon[vector].EastSide != csDungeonCell.SideType.Empty))
					{
						GameObject gameObject21 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Pillar, vector11, Quaternion.Euler(-90f, 0f, 0f));
					}
					Vector3 vector12 = Vector3.zero;
					vector12 = vector2;
					vector12.y += 0.5f;
					if (!this.ObjectExists(vector12) && this.IsBigRoom(coDungeonGenerator, vector) && coDungeonGenerator.Dungeon[vector].SouthSide == csDungeonCell.SideType.Wall && coDungeonGenerator.Dungeon[vector].EastSide == csDungeonCell.SideType.Wall)
					{
						GameObject gameObject22 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Gargoyle, vector12, Quaternion.Euler(-90f, 135f, 0f));
					}
					if (!this.ObjectExists(vector12) && this.IsBigRoom(coDungeonGenerator, vector) && coDungeonGenerator.Dungeon[vector].SouthSide == csDungeonCell.SideType.Wall && coDungeonGenerator.Dungeon[vector].WestSide == csDungeonCell.SideType.Wall)
					{
						GameObject gameObject23 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Gargoyle, vector12, Quaternion.Euler(-90f, 45f, 0f));
					}
					if (!this.ObjectExists(vector12) && this.IsBigRoom(coDungeonGenerator, vector) && coDungeonGenerator.Dungeon[vector].NorthSide == csDungeonCell.SideType.Wall && coDungeonGenerator.Dungeon[vector].EastSide == csDungeonCell.SideType.Wall)
					{
						GameObject gameObject24 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Gargoyle, vector12, Quaternion.Euler(-90f, 235f, 0f));
					}
					if (!this.ObjectExists(vector12) && this.IsBigRoom(coDungeonGenerator, vector) && coDungeonGenerator.Dungeon[vector].NorthSide == csDungeonCell.SideType.Wall && coDungeonGenerator.Dungeon[vector].WestSide == csDungeonCell.SideType.Wall)
					{
						GameObject gameObject25 = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab_Gargoyle, vector12, Quaternion.Euler(-90f, 315f, 0f));
					}
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06001265 RID: 4709 RVA: 0x00076490 File Offset: 0x00074890
	private bool ValidLocation(coDungeonGenerator dG, float x, float y)
	{
		foreach (Vector2 vector in dG.Dungeon.CellLocations)
		{
			if (vector.x == x && vector.y == y)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001266 RID: 4710 RVA: 0x0007650C File Offset: 0x0007490C
	private bool ObjectExists(Vector3 pos)
	{
		IEnumerator enumerator = base.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				if (transform.position == pos)
				{
					return true;
				}
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
		return false;
	}

	// Token: 0x06001267 RID: 4711 RVA: 0x00076588 File Offset: 0x00074988
	private bool IsBigRoom(coDungeonGenerator dG, Vector2 pos)
	{
		foreach (csDungeonRoom csDungeonRoom in dG.Dungeon.Rooms)
		{
			if (csDungeonRoom.Bounds.width != 1f && csDungeonRoom.Bounds.height != 1f && csDungeonRoom.Bounds.Contains(pos))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x040012A4 RID: 4772
	public GameObject m_prefab_Floor;

	// Token: 0x040012A5 RID: 4773
	public GameObject m_prefab_Wall;

	// Token: 0x040012A6 RID: 4774
	public GameObject m_prefab_Pillar;

	// Token: 0x040012A7 RID: 4775
	public GameObject m_prefab_Door;

	// Token: 0x040012A8 RID: 4776
	public GameObject m_prefab_Doorway;

	// Token: 0x040012A9 RID: 4777
	public GameObject m_prefab_Torch;

	// Token: 0x040012AA RID: 4778
	public GameObject m_prefab_Gargoyle;

	// Token: 0x040012AB RID: 4779
	public GameObject m_prefab_Dirt;

	// Token: 0x040012AC RID: 4780
	public float m_scale = 1.515f;

	// Token: 0x040012AD RID: 4781
	private float m_scaleH;

	// Token: 0x02000280 RID: 640
	private enum enCellDirection
	{
		// Token: 0x040012AF RID: 4783
		North,
		// Token: 0x040012B0 RID: 4784
		South,
		// Token: 0x040012B1 RID: 4785
		East,
		// Token: 0x040012B2 RID: 4786
		West
	}
}
