using System;
using UnityEngine;

// Token: 0x020000E1 RID: 225
public class SceneryMapMaker : MonoBehaviour
{
	// Token: 0x0600043C RID: 1084 RVA: 0x00028018 File Offset: 0x00026418
	private void Awake()
	{
		this.type1 = GameObject.Find("Item_Type1").transform;
		this.type2 = GameObject.Find("Item_Type2").transform;
		this.type3 = GameObject.Find("Item_Type3").transform;
		this.type4 = GameObject.Find("Item_Type4").transform;
		this.type5 = GameObject.Find("Item_Type5").transform;
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0002808E File Offset: 0x0002648E
	private void Start()
	{
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x00028090 File Offset: 0x00026490
	private void Update()
	{
		if (this.checkobj != this.currentobj)
		{
			this.checkobj = this.currentobj;
			base.enabled = false;
		}
		if (this.type == 1f)
		{
			this.currentpath = "walls&floors/" + this.currentobj;
		}
		if (this.type == 2f)
		{
			this.currentpath = "Items/" + this.currentobj;
		}
		if (this.type == 3f)
		{
			this.currentpath = "Effects/" + this.currentobj;
		}
		if (this.type == 4f)
		{
			this.currentpath = "Lights/" + this.currentobj;
		}
		if (this.type == 5f)
		{
			this.currentpath = "Doors/" + this.currentobj;
		}
		if (base.gameObject.GetComponent<ToolBarMapMaker>().type == 3)
		{
			this.currentpath = "NPC/NPC";
		}
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x000281A8 File Offset: 0x000265A8
	private void DoWindow0(int windowID)
	{
		GUI.Label(new Rect(15f, 5f, 100f, 20f), "<color=white> Scene</color>");
		if (GUI.Button(new Rect(70f, 5f, 110f, 20f), "Walls & Floor"))
		{
			this.type = 1f;
		}
		if (GUI.Button(new Rect(185f, 5f, 60f, 20f), "Items"))
		{
			this.type = 2f;
		}
		if (GUI.Button(new Rect(250f, 5f, 60f, 20f), "Effects"))
		{
			this.type = 3f;
		}
		if (GUI.Button(new Rect(315f, 5f, 60f, 20f), "Lights"))
		{
			this.type = 4f;
		}
		if (GUI.Button(new Rect(380f, 5f, 60f, 20f), "Doors"))
		{
			this.type = 5f;
		}
		if (GUI.Button(new Rect(445f, 5f, 60f, 20f), "Terrain"))
		{
			this.type = 6f;
		}
		this.scrollPosition = GUI.BeginScrollView(new Rect(10f, 30f, 520f, 380f), this.scrollPosition, new Rect(0f, 0f, 430f, 5100f));
		GUI.Box(new Rect(10f, 10f, 130f, 300f), "Type");
		GUI.Label(new Rect(50f, 240f, 70f, 20f), "Object ID:");
		GUI.Label(new Rect(50f, 260f, 70f, 20f), this.currentobj);
		if (GUI.Button(new Rect(50f, 288f, 50f, 20f), "Mods"))
		{
			this.currentpath = "Mod";
			base.enabled = false;
		}
		if (this.type == 1f)
		{
			if (GUI.Button(new Rect(20f, 30f, 110f, 20f), "Outdoor Walls"))
			{
				this.subtype = 1f;
			}
			if (GUI.Button(new Rect(20f, 50f, 110f, 20f), "Outdoor Floor"))
			{
				this.subtype = 2f;
			}
			if (GUI.Button(new Rect(20f, 70f, 110f, 20f), "Indoor Walls"))
			{
				this.subtype = 3f;
			}
			if (GUI.Button(new Rect(20f, 90f, 110f, 20f), "Indoor Floor"))
			{
				this.subtype = 4f;
			}
			if (GUI.Button(new Rect(20f, 110f, 110f, 20f), "Windows"))
			{
				this.subtype = 5f;
			}
			if (GUI.Button(new Rect(20f, 130f, 110f, 20f), "Blood Tiles"))
			{
				this.subtype = 9f;
			}
			if (GUI.Button(new Rect(20f, 150f, 110f, 20f), "Dungeon"))
			{
				this.subtype = 6f;
			}
			if (GUI.Button(new Rect(20f, 170f, 110f, 20f), "Cave"))
			{
				this.subtype = 7f;
			}
			if (GUI.Button(new Rect(20f, 190f, 110f, 20f), "Scifi"))
			{
				this.subtype = 8f;
			}
			if (this.type == 1f && this.subtype == 1f)
			{
				GUI.Label(new Rect(250f, 10f, 100f, 20f), "Walls");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.odwall1))
				{
					this.currentobj = "odwall1";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.odwall2))
				{
					this.currentobj = "odwall2";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.odwall3))
				{
					this.currentobj = "odwall3";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.odwall4))
				{
					this.currentobj = "odwall4";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.odwall5))
				{
					this.currentobj = "odwall5";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.odwall6))
				{
					this.currentobj = "odwall6";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.odwall7))
				{
					this.currentobj = "odwall7";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.odwall8))
				{
					this.currentobj = "odwall8";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.odwall9))
				{
					this.currentobj = "odwall9";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.odwall10))
				{
					this.currentobj = "odwall10";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.odwall11))
				{
					this.currentobj = "odwall11";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), this.odwall12))
				{
					this.currentobj = "odwall12";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), this.odwall13))
				{
					this.currentobj = "odwall13";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), this.odwall14))
				{
					this.currentobj = "odwall14";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), this.odwall15))
				{
					this.currentobj = "odwall15";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), this.odwall16))
				{
					this.currentobj = "odwall16";
				}
				if (GUI.Button(new Rect(250f, 530f, 100f, 100f), this.odwall17))
				{
					this.currentobj = "odwall17";
				}
				if (GUI.Button(new Rect(350f, 530f, 100f, 100f), this.odwall18))
				{
					this.currentobj = "odwall18";
				}
				if (GUI.Button(new Rect(150f, 630f, 100f, 100f), this.odwall19))
				{
					this.currentobj = "odwall19";
				}
				if (GUI.Button(new Rect(250f, 630f, 100f, 100f), this.odwall20))
				{
					this.currentobj = "odwall20";
				}
				if (GUI.Button(new Rect(350f, 630f, 100f, 100f), this.odwall21))
				{
					this.currentobj = "odwall21";
				}
				if (GUI.Button(new Rect(150f, 730f, 100f, 100f), this.odwall22))
				{
					this.currentobj = "odwall22";
				}
				if (GUI.Button(new Rect(250f, 730f, 100f, 100f), this.odwall23))
				{
					this.currentobj = "odwall23";
				}
				if (GUI.Button(new Rect(350f, 730f, 100f, 100f), this.odwall24))
				{
					this.currentobj = "odwall24";
				}
				if (GUI.Button(new Rect(150f, 830f, 100f, 100f), this.odwall25))
				{
					this.currentobj = "odwall25";
				}
				if (GUI.Button(new Rect(250f, 830f, 100f, 100f), this.odwall26))
				{
					this.currentobj = "odwall26";
				}
				if (GUI.Button(new Rect(350f, 830f, 100f, 100f), this.odwall27))
				{
					this.currentobj = "odwall27";
				}
			}
			if (this.type == 1f && this.subtype == 2f)
			{
				GUI.Label(new Rect(250f, 10f, 100f, 20f), "Floor");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.odfloor1))
				{
					this.currentobj = "odfloor1";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.odfloor2))
				{
					this.currentobj = "odfloor2";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.odfloor3))
				{
					this.currentobj = "odfloor3";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.odfloor4))
				{
					this.currentobj = "odfloor4";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.odfloor5))
				{
					this.currentobj = "odfloor5";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.odfloor6))
				{
					this.currentobj = "odfloor6";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.odfloor7))
				{
					this.currentobj = "odfloor7";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.odfloor8))
				{
					this.currentobj = "odfloor8";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.odfloor9))
				{
					this.currentobj = "odfloor9";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.odfloor10))
				{
					this.currentobj = "odfloor10";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.odfloor11))
				{
					this.currentobj = "odfloor11";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), this.odfloor12))
				{
					this.currentobj = "odfloor12";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), this.odfloor13))
				{
					this.currentobj = "odfloor13";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), this.odfloor14))
				{
					this.currentobj = "odfloor14";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), this.odfloor15))
				{
					this.currentobj = "odfloor15";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), this.odfloor16))
				{
					this.currentobj = "odfloor16";
				}
				if (GUI.Button(new Rect(250f, 530f, 100f, 100f), this.odfloor17))
				{
					this.currentobj = "odfloor17";
				}
				if (GUI.Button(new Rect(350f, 530f, 100f, 100f), this.odfloor18))
				{
					this.currentobj = "odfloor18";
				}
				if (GUI.Button(new Rect(150f, 630f, 100f, 100f), this.odfloor19))
				{
					this.currentobj = "odfloor19";
				}
				if (GUI.Button(new Rect(250f, 630f, 100f, 100f), this.odfloor20))
				{
					this.currentobj = "odfloor20";
				}
				if (GUI.Button(new Rect(350f, 630f, 100f, 100f), this.odfloor21))
				{
					this.currentobj = "odfloor21";
				}
				if (GUI.Button(new Rect(150f, 730f, 100f, 100f), this.odfloor22))
				{
					this.currentobj = "odfloor22";
				}
				if (GUI.Button(new Rect(250f, 730f, 100f, 100f), this.odfloor23))
				{
					this.currentobj = "odfloor23";
				}
				if (GUI.Button(new Rect(350f, 730f, 100f, 100f), this.odfloor24))
				{
					this.currentobj = "odfloor24";
				}
				if (GUI.Button(new Rect(150f, 830f, 100f, 100f), this.odfloor25))
				{
					this.currentobj = "odfloor25";
				}
				if (GUI.Button(new Rect(250f, 830f, 100f, 100f), this.odfloor26))
				{
					this.currentobj = "odfloor26";
				}
				if (GUI.Button(new Rect(350f, 830f, 100f, 100f), this.odfloor27))
				{
					this.currentobj = "odfloor27";
				}
				if (GUI.Button(new Rect(150f, 930f, 100f, 100f), this.odfloor28))
				{
					this.currentobj = "odfloor28";
				}
				if (GUI.Button(new Rect(250f, 930f, 100f, 100f), this.odfloor29))
				{
					this.currentobj = "odfloor29";
				}
				if (GUI.Button(new Rect(350f, 930f, 100f, 100f), this.odfloor30))
				{
					this.currentobj = "odfloor30";
				}
				if (GUI.Button(new Rect(150f, 1030f, 100f, 100f), this.odfloor31))
				{
					this.currentobj = "odfloor31";
				}
				if (GUI.Button(new Rect(250f, 1030f, 100f, 100f), this.odfloor32))
				{
					this.currentobj = "odfloor32";
				}
				if (GUI.Button(new Rect(350f, 1030f, 100f, 100f), this.odfloor33))
				{
					this.currentobj = "odfloor33";
				}
				if (GUI.Button(new Rect(150f, 1130f, 100f, 100f), this.odfloor34))
				{
					this.currentobj = "odfloor34";
				}
				if (GUI.Button(new Rect(250f, 1130f, 100f, 100f), this.odfloor35))
				{
					this.currentobj = "odfloor35";
				}
				if (GUI.Button(new Rect(350f, 1130f, 100f, 100f), this.odfloor36))
				{
					this.currentobj = "odfloor36";
				}
				if (GUI.Button(new Rect(150f, 1230f, 100f, 100f), this.odfloor37))
				{
					this.currentobj = "odfloor37";
				}
				if (GUI.Button(new Rect(250f, 1230f, 100f, 100f), this.odfloor38))
				{
					this.currentobj = "odfloor38";
				}
				if (GUI.Button(new Rect(350f, 1230f, 100f, 100f), this.odfloor39))
				{
					this.currentobj = "odfloor39";
				}
				if (GUI.Button(new Rect(150f, 1330f, 100f, 100f), this.odfloor40))
				{
					this.currentobj = "odfloor40";
				}
				if (GUI.Button(new Rect(250f, 1330f, 100f, 100f), this.odfloor41))
				{
					this.currentobj = "odfloor41";
				}
				if (GUI.Button(new Rect(350f, 1330f, 100f, 100f), this.odfloor42))
				{
					this.currentobj = "odfloor42";
				}
			}
			if (this.type == 1f && this.subtype == 3f)
			{
				GUI.Label(new Rect(250f, 10f, 100f, 20f), "Walls");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.idwall1))
				{
					this.currentobj = "idwall1";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.idwall2))
				{
					this.currentobj = "idwall2";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.idwall3))
				{
					this.currentobj = "idwall3";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.idwall4))
				{
					this.currentobj = "idwall4";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.idwall5))
				{
					this.currentobj = "idwall5";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.idwall6))
				{
					this.currentobj = "idwall6";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.idwall7))
				{
					this.currentobj = "idwall7";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.idwall8))
				{
					this.currentobj = "idwall8";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.idwall9))
				{
					this.currentobj = "idwall9";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.idwall10))
				{
					this.currentobj = "idwall10";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.idwall11))
				{
					this.currentobj = "idwall11";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), this.idwall12))
				{
					this.currentobj = "idwall12";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), this.idwall13))
				{
					this.currentobj = "idwall3";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), this.idwall14))
				{
					this.currentobj = "idwall14";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), this.idwall15))
				{
					this.currentobj = "idwall15";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), this.idwall16))
				{
					this.currentobj = "idwall16";
				}
				if (GUI.Button(new Rect(250f, 530f, 100f, 100f), this.idwall17))
				{
					this.currentobj = "idwall17";
				}
				if (GUI.Button(new Rect(350f, 530f, 100f, 100f), this.idwall18))
				{
					this.currentobj = "idwall18";
				}
				if (GUI.Button(new Rect(150f, 630f, 100f, 100f), this.idwall19))
				{
					this.currentobj = "idwall19";
				}
				if (GUI.Button(new Rect(250f, 630f, 100f, 100f), this.idwall20))
				{
					this.currentobj = "idwall20";
				}
				if (GUI.Button(new Rect(350f, 630f, 100f, 100f), this.idwall21))
				{
					this.currentobj = "idwall21";
				}
				if (GUI.Button(new Rect(150f, 730f, 100f, 100f), this.idwall22))
				{
					this.currentobj = "idwall22";
				}
				if (GUI.Button(new Rect(250f, 730f, 100f, 100f), this.idwall23))
				{
					this.currentobj = "idwall23";
				}
				if (GUI.Button(new Rect(350f, 730f, 100f, 100f), this.idwall24))
				{
					this.currentobj = "idwall24";
				}
				if (GUI.Button(new Rect(150f, 830f, 100f, 100f), this.idwall25))
				{
					this.currentobj = "idwall25";
				}
				if (GUI.Button(new Rect(250f, 830f, 100f, 100f), this.idwall26))
				{
					this.currentobj = "idwall26";
				}
				if (GUI.Button(new Rect(350f, 830f, 100f, 100f), this.idwall27))
				{
					this.currentobj = "idwall27";
				}
				if (GUI.Button(new Rect(150f, 930f, 100f, 100f), this.idwall28))
				{
					this.currentobj = "idwall28";
				}
				if (GUI.Button(new Rect(250f, 930f, 100f, 100f), this.idwall29))
				{
					this.currentobj = "idwall29";
				}
				if (GUI.Button(new Rect(350f, 930f, 100f, 100f), this.idwall30))
				{
					this.currentobj = "idwall30";
				}
				if (GUI.Button(new Rect(150f, 1030f, 100f, 100f), this.idwall31))
				{
					this.currentobj = "idwall31";
				}
				if (GUI.Button(new Rect(250f, 1030f, 100f, 100f), this.idwall32))
				{
					this.currentobj = "idwall32";
				}
				if (GUI.Button(new Rect(350f, 1030f, 100f, 100f), this.idwall33))
				{
					this.currentobj = "idwall33";
				}
				if (GUI.Button(new Rect(150f, 1130f, 100f, 100f), this.idwall34))
				{
					this.currentobj = "idwall34";
				}
				if (GUI.Button(new Rect(250f, 1130f, 100f, 100f), this.idwall35))
				{
					this.currentobj = "idwall35";
				}
				if (GUI.Button(new Rect(350f, 1130f, 100f, 100f), this.idwall36))
				{
					this.currentobj = "idwall36";
				}
				if (GUI.Button(new Rect(150f, 1230f, 100f, 100f), this.idwall37))
				{
					this.currentobj = "idwall37";
				}
				if (GUI.Button(new Rect(250f, 1230f, 100f, 100f), this.idwall38))
				{
					this.currentobj = "idwall38";
				}
				if (GUI.Button(new Rect(350f, 1230f, 100f, 100f), this.idwall39))
				{
					this.currentobj = "idwall39";
				}
				if (GUI.Button(new Rect(150f, 1330f, 100f, 100f), this.idwall40))
				{
					this.currentobj = "idwall40";
				}
				if (GUI.Button(new Rect(250f, 1330f, 100f, 100f), this.idwall41))
				{
					this.currentobj = "idwall41";
				}
				if (GUI.Button(new Rect(350f, 1330f, 100f, 100f), this.idwall42))
				{
					this.currentobj = "idwall42";
				}
				if (GUI.Button(new Rect(150f, 1430f, 100f, 100f), this.idwall43))
				{
					this.currentobj = "idwall43";
				}
				if (GUI.Button(new Rect(250f, 1430f, 100f, 100f), this.idwall44))
				{
					this.currentobj = "idwall44";
				}
				if (GUI.Button(new Rect(350f, 1430f, 100f, 100f), this.idwall45))
				{
					this.currentobj = "idwall45";
				}
				if (GUI.Button(new Rect(150f, 1530f, 100f, 100f), this.idwall46))
				{
					this.currentobj = "idwall46";
				}
				if (GUI.Button(new Rect(250f, 1530f, 100f, 100f), this.idwall47))
				{
					this.currentobj = "idwall47";
				}
				if (GUI.Button(new Rect(350f, 1530f, 100f, 100f), this.idwall48))
				{
					this.currentobj = "idwall48";
				}
				if (GUI.Button(new Rect(150f, 1630f, 100f, 100f), this.idwall49))
				{
					this.currentobj = "idwall49";
				}
				if (GUI.Button(new Rect(250f, 1630f, 100f, 100f), this.idwall50))
				{
					this.currentobj = "idwall50";
				}
				if (GUI.Button(new Rect(350f, 1630f, 100f, 100f), this.idwall51))
				{
					this.currentobj = "idwall51";
				}
				if (GUI.Button(new Rect(150f, 1730f, 100f, 100f), this.idwall52))
				{
					this.currentobj = "idwall52";
				}
				if (GUI.Button(new Rect(250f, 1730f, 100f, 100f), this.idwall53))
				{
					this.currentobj = "idwall53";
				}
				if (GUI.Button(new Rect(350f, 1730f, 100f, 100f), this.idwall54))
				{
					this.currentobj = "idwall54";
				}
				if (GUI.Button(new Rect(150f, 1830f, 100f, 100f), this.idwall55))
				{
					this.currentobj = "idwall55";
				}
				if (GUI.Button(new Rect(250f, 1830f, 100f, 100f), this.idwall56))
				{
					this.currentobj = "idwall56";
				}
				if (GUI.Button(new Rect(350f, 1830f, 100f, 100f), this.idwall57))
				{
					this.currentobj = "idwall57";
				}
				if (GUI.Button(new Rect(150f, 1930f, 100f, 100f), this.idwall58))
				{
					this.currentobj = "idwall58";
				}
				if (GUI.Button(new Rect(250f, 1930f, 100f, 100f), this.idwall59))
				{
					this.currentobj = "idwall59";
				}
				if (GUI.Button(new Rect(350f, 1930f, 100f, 100f), this.idwall60))
				{
					this.currentobj = "idwall60";
				}
				if (GUI.Button(new Rect(150f, 2030f, 100f, 100f), this.idwall61))
				{
					this.currentobj = "idwall61";
				}
				if (GUI.Button(new Rect(250f, 2030f, 100f, 100f), this.idwall62))
				{
					this.currentobj = "idwall62";
				}
				if (GUI.Button(new Rect(350f, 2030f, 100f, 100f), this.idwall63))
				{
					this.currentobj = "idwall63";
				}
				if (GUI.Button(new Rect(150f, 2130f, 100f, 100f), this.idwall64))
				{
					this.currentobj = "idwall64";
				}
				if (GUI.Button(new Rect(250f, 2130f, 100f, 100f), this.idwall65))
				{
					this.currentobj = "idwall65";
				}
				if (GUI.Button(new Rect(350f, 2130f, 100f, 100f), this.idwall66))
				{
					this.currentobj = "idwall66";
				}
				if (GUI.Button(new Rect(150f, 2230f, 100f, 100f), this.idwall67))
				{
					this.currentobj = "idwall67";
				}
				if (GUI.Button(new Rect(250f, 2230f, 100f, 100f), this.idwall68))
				{
					this.currentobj = "idwall68";
				}
				if (GUI.Button(new Rect(350f, 2230f, 100f, 100f), this.idwall69))
				{
					this.currentobj = "idwall69";
				}
				if (GUI.Button(new Rect(150f, 2330f, 100f, 100f), this.idwall70))
				{
					this.currentobj = "idwall70";
				}
				if (GUI.Button(new Rect(250f, 2330f, 100f, 100f), this.idwall71))
				{
					this.currentobj = "idwall71";
				}
				if (GUI.Button(new Rect(350f, 2330f, 100f, 100f), this.idwall72))
				{
					this.currentobj = "idwall72";
				}
				if (GUI.Button(new Rect(150f, 2430f, 100f, 100f), this.idwall73))
				{
					this.currentobj = "idwall73";
				}
				if (GUI.Button(new Rect(250f, 2430f, 100f, 100f), this.idwall74))
				{
					this.currentobj = "idwall74";
				}
				if (GUI.Button(new Rect(350f, 2430f, 100f, 100f), this.idwall75))
				{
					this.currentobj = "idwall75";
				}
				if (GUI.Button(new Rect(150f, 2530f, 100f, 100f), this.idwall76))
				{
					this.currentobj = "idwall76";
				}
				if (GUI.Button(new Rect(250f, 2530f, 100f, 100f), this.idwall77))
				{
					this.currentobj = "idwall77";
				}
				if (GUI.Button(new Rect(350f, 2530f, 100f, 100f), this.idwall78))
				{
					this.currentobj = "idwall78";
				}
				if (GUI.Button(new Rect(150f, 2630f, 100f, 100f), this.idwall79))
				{
					this.currentobj = "idwall79";
				}
				if (GUI.Button(new Rect(250f, 2630f, 100f, 100f), this.idwall80))
				{
					this.currentobj = "idwall80";
				}
				if (GUI.Button(new Rect(350f, 2630f, 100f, 100f), this.idwall81))
				{
					this.currentobj = "idwall81";
				}
				if (GUI.Button(new Rect(150f, 2730f, 100f, 100f), this.idwall82))
				{
					this.currentobj = "idwall82";
				}
				if (GUI.Button(new Rect(250f, 2730f, 100f, 100f), this.idwall83))
				{
					this.currentobj = "idwall83";
				}
				if (GUI.Button(new Rect(350f, 2730f, 100f, 100f), this.idwall84))
				{
					this.currentobj = "idwall84";
				}
				if (GUI.Button(new Rect(150f, 2830f, 100f, 100f), this.idwall85))
				{
					this.currentobj = "idwall85";
				}
				if (GUI.Button(new Rect(250f, 2830f, 100f, 100f), this.idwall86))
				{
					this.currentobj = "idwall86";
				}
				if (GUI.Button(new Rect(350f, 2830f, 100f, 100f), this.idwall87))
				{
					this.currentobj = "idwall87";
				}
				if (GUI.Button(new Rect(150f, 2930f, 100f, 100f), this.idwall88))
				{
					this.currentobj = "idwall88";
				}
				if (GUI.Button(new Rect(250f, 2930f, 100f, 100f), this.idwall89))
				{
					this.currentobj = "idwall89";
				}
				if (GUI.Button(new Rect(350f, 2930f, 100f, 100f), this.idwall90))
				{
					this.currentobj = "idwall90";
				}
				if (GUI.Button(new Rect(150f, 3030f, 100f, 100f), this.idwall91))
				{
					this.currentobj = "idwall91";
				}
				if (GUI.Button(new Rect(250f, 3030f, 100f, 100f), this.idwall92))
				{
					this.currentobj = "idwall93";
				}
				if (GUI.Button(new Rect(350f, 3030f, 100f, 100f), this.idwall93))
				{
					this.currentobj = "idwall93";
				}
				if (GUI.Button(new Rect(150f, 3130f, 100f, 100f), this.idwall94))
				{
					this.currentobj = "idwall94";
				}
				if (GUI.Button(new Rect(250f, 3130f, 100f, 100f), this.idwall95))
				{
					this.currentobj = "idwall95";
				}
				if (GUI.Button(new Rect(350f, 3130f, 100f, 100f), this.idwall96))
				{
					this.currentobj = "idwall96";
				}
				if (GUI.Button(new Rect(150f, 3230f, 100f, 100f), this.idwall97))
				{
					this.currentobj = "idwall97";
				}
				if (GUI.Button(new Rect(250f, 3230f, 100f, 100f), this.idwall98))
				{
					this.currentobj = "idwall98";
				}
				if (GUI.Button(new Rect(350f, 3230f, 100f, 100f), this.idwall99))
				{
					this.currentobj = "idwall99";
				}
				if (GUI.Button(new Rect(150f, 3330f, 100f, 100f), this.idwall100))
				{
					this.currentobj = "idwall100";
				}
				if (GUI.Button(new Rect(250f, 3330f, 100f, 100f), this.idwall101))
				{
					this.currentobj = "idwall101";
				}
				if (GUI.Button(new Rect(350f, 3330f, 100f, 100f), this.idwall102))
				{
					this.currentobj = "idwall102";
				}
				if (GUI.Button(new Rect(150f, 3430f, 100f, 100f), this.idwall103))
				{
					this.currentobj = "idwall103";
				}
				if (GUI.Button(new Rect(250f, 3430f, 100f, 100f), this.idwall104))
				{
					this.currentobj = "idwall104";
				}
				if (GUI.Button(new Rect(350f, 3430f, 100f, 100f), this.idwall105))
				{
					this.currentobj = "idwall105";
				}
			}
			if (this.type == 1f && this.subtype == 4f)
			{
				GUI.Label(new Rect(250f, 10f, 100f, 20f), "Floor");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.idfloor1))
				{
					this.currentobj = "idfloor1";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.idfloor2))
				{
					this.currentobj = "idfloor2";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.idfloor3))
				{
					this.currentobj = "idfloor3";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.idfloor4))
				{
					this.currentobj = "idfloor4";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.idfloor5))
				{
					this.currentobj = "idfloor5";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.idfloor6))
				{
					this.currentobj = "idfloor6";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.idfloor7))
				{
					this.currentobj = "idfloor7";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.idfloor8))
				{
					this.currentobj = "idfloor8";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.idfloor9))
				{
					this.currentobj = "idfloor9";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.idfloor10))
				{
					this.currentobj = "idfloor10";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.idfloor11))
				{
					this.currentobj = "idfloor11";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), this.idfloor12))
				{
					this.currentobj = "idfloor12";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), this.idfloor13))
				{
					this.currentobj = "idfloor13";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), this.idfloor14))
				{
					this.currentobj = "idfloor14";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), this.idfloor15))
				{
					this.currentobj = "idfloor15";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), this.idfloor16))
				{
					this.currentobj = "idfloor16";
				}
				if (GUI.Button(new Rect(250f, 530f, 100f, 100f), this.idfloor17))
				{
					this.currentobj = "idfloor17";
				}
				if (GUI.Button(new Rect(350f, 530f, 100f, 100f), this.idfloor18))
				{
					this.currentobj = "idfloor18";
				}
				if (GUI.Button(new Rect(150f, 630f, 100f, 100f), this.idfloor19))
				{
					this.currentobj = "idfloor19";
				}
				if (GUI.Button(new Rect(250f, 630f, 100f, 100f), this.idfloor20))
				{
					this.currentobj = "idfloor20";
				}
				if (GUI.Button(new Rect(350f, 630f, 100f, 100f), this.idfloor21))
				{
					this.currentobj = "idfloor21";
				}
				if (GUI.Button(new Rect(150f, 730f, 100f, 100f), this.idfloor22))
				{
					this.currentobj = "idfloor22";
				}
				if (GUI.Button(new Rect(250f, 730f, 100f, 100f), this.idfloor23))
				{
					this.currentobj = "idfloor23";
				}
				if (GUI.Button(new Rect(350f, 730f, 100f, 100f), this.idfloor24))
				{
					this.currentobj = "idfloor24";
				}
				if (GUI.Button(new Rect(150f, 830f, 100f, 100f), this.idfloor25))
				{
					this.currentobj = "idfloor25";
				}
				if (GUI.Button(new Rect(250f, 830f, 100f, 100f), this.idfloor26))
				{
					this.currentobj = "idfloor26";
				}
				if (GUI.Button(new Rect(350f, 830f, 100f, 100f), this.idfloor27))
				{
					this.currentobj = "idfloor27";
				}
				if (GUI.Button(new Rect(150f, 930f, 100f, 100f), this.idfloor28))
				{
					this.currentobj = "idfloor28";
				}
				if (GUI.Button(new Rect(250f, 930f, 100f, 100f), this.idfloor29))
				{
					this.currentobj = "idfloor29";
				}
				if (GUI.Button(new Rect(350f, 930f, 100f, 100f), this.idfloor30))
				{
					this.currentobj = "idfloor30";
				}
				if (GUI.Button(new Rect(150f, 1030f, 100f, 100f), this.idfloor31))
				{
					this.currentobj = "idfloor31";
				}
				if (GUI.Button(new Rect(250f, 1030f, 100f, 100f), this.idfloor32))
				{
					this.currentobj = "idfloor32";
				}
				if (GUI.Button(new Rect(350f, 1030f, 100f, 100f), this.idfloor33))
				{
					this.currentobj = "idfloor33";
				}
				if (GUI.Button(new Rect(150f, 1130f, 100f, 100f), this.idfloor34))
				{
					this.currentobj = "idfloor34";
				}
				if (GUI.Button(new Rect(250f, 1130f, 100f, 100f), this.idfloor35))
				{
					this.currentobj = "idfloor35";
				}
				if (GUI.Button(new Rect(350f, 1130f, 100f, 100f), this.idfloor36))
				{
					this.currentobj = "idfloor36";
				}
				if (GUI.Button(new Rect(150f, 1230f, 100f, 100f), this.idfloor37))
				{
					this.currentobj = "idfloor37";
				}
				if (GUI.Button(new Rect(250f, 1230f, 100f, 100f), this.idfloor38))
				{
					this.currentobj = "idfloor38";
				}
				if (GUI.Button(new Rect(350f, 1230f, 100f, 100f), this.idfloor39))
				{
					this.currentobj = "idfloor39";
				}
				if (GUI.Button(new Rect(150f, 1330f, 100f, 100f), this.idfloor40))
				{
					this.currentobj = "idfloor40";
				}
				if (GUI.Button(new Rect(250f, 1330f, 100f, 100f), this.idfloor41))
				{
					this.currentobj = "idfloor41";
				}
				if (GUI.Button(new Rect(350f, 1330f, 100f, 100f), this.idfloor42))
				{
					this.currentobj = "idfloor42";
				}
				if (GUI.Button(new Rect(150f, 1430f, 100f, 100f), this.idfloor43))
				{
					this.currentobj = "idfloor43";
				}
				if (GUI.Button(new Rect(250f, 1430f, 100f, 100f), this.idfloor44))
				{
					this.currentobj = "idfloor44";
				}
				if (GUI.Button(new Rect(350f, 1430f, 100f, 100f), this.idfloor45))
				{
					this.currentobj = "idfloor45";
				}
				if (GUI.Button(new Rect(150f, 1530f, 100f, 100f), this.idfloor46))
				{
					this.currentobj = "idfloor46";
				}
				if (GUI.Button(new Rect(250f, 1530f, 100f, 100f), this.idfloor47))
				{
					this.currentobj = "idfloor47";
				}
				if (GUI.Button(new Rect(350f, 1530f, 100f, 100f), this.idfloor48))
				{
					this.currentobj = "idfloor48";
				}
				if (GUI.Button(new Rect(150f, 1630f, 100f, 100f), this.idfloor49))
				{
					this.currentobj = "idfloor49";
				}
				if (GUI.Button(new Rect(250f, 1630f, 100f, 100f), this.idfloor50))
				{
					this.currentobj = "idfloor50";
				}
				if (GUI.Button(new Rect(350f, 1630f, 100f, 100f), this.idfloor51))
				{
					this.currentobj = "idfloor51";
				}
				if (GUI.Button(new Rect(150f, 1730f, 100f, 100f), this.idfloor52))
				{
					this.currentobj = "idfloor52";
				}
				if (GUI.Button(new Rect(250f, 1730f, 100f, 100f), this.idfloor53))
				{
					this.currentobj = "idfloor53";
				}
				if (GUI.Button(new Rect(350f, 1730f, 100f, 100f), this.idfloor54))
				{
					this.currentobj = "idfloor54";
				}
				if (GUI.Button(new Rect(150f, 1830f, 100f, 100f), this.idfloor55))
				{
					this.currentobj = "idfloor55";
				}
				if (GUI.Button(new Rect(250f, 1830f, 100f, 100f), this.idfloor56))
				{
					this.currentobj = "idfloor56";
				}
				if (GUI.Button(new Rect(350f, 1830f, 100f, 100f), this.idfloor57))
				{
					this.currentobj = "idfloor57";
				}
				if (GUI.Button(new Rect(150f, 1930f, 100f, 100f), this.idfloor58))
				{
					this.currentobj = "idfloor58";
				}
				if (GUI.Button(new Rect(250f, 1930f, 100f, 100f), this.idfloor59))
				{
					this.currentobj = "idfloor59";
				}
				if (GUI.Button(new Rect(350f, 1930f, 100f, 100f), this.idfloor60))
				{
					this.currentobj = "idfloor60";
				}
				if (GUI.Button(new Rect(150f, 2030f, 100f, 100f), this.idfloor61))
				{
					this.currentobj = "idfloor61";
				}
				if (GUI.Button(new Rect(250f, 2030f, 100f, 100f), this.idfloor62))
				{
					this.currentobj = "idfloor62";
				}
				if (GUI.Button(new Rect(350f, 2030f, 100f, 100f), this.idfloor63))
				{
					this.currentobj = "idfloor63";
				}
				if (GUI.Button(new Rect(150f, 2130f, 100f, 100f), this.idfloor64))
				{
					this.currentobj = "idfloor64";
				}
				if (GUI.Button(new Rect(250f, 2130f, 100f, 100f), this.idfloor65))
				{
					this.currentobj = "idfloor65";
				}
				if (GUI.Button(new Rect(350f, 2130f, 100f, 100f), this.idfloor66))
				{
					this.currentobj = "idfloor66";
				}
				if (GUI.Button(new Rect(150f, 2230f, 100f, 100f), this.idfloor67))
				{
					this.currentobj = "idfloor67";
				}
				if (GUI.Button(new Rect(250f, 2230f, 100f, 100f), this.idfloor68))
				{
					this.currentobj = "idfloor68";
				}
				if (GUI.Button(new Rect(350f, 2230f, 100f, 100f), this.idfloor69))
				{
					this.currentobj = "idfloo69";
				}
				if (GUI.Button(new Rect(150f, 2330f, 100f, 100f), this.idfloor70))
				{
					this.currentobj = "idfloor70";
				}
				if (GUI.Button(new Rect(250f, 2330f, 100f, 100f), this.idfloor71))
				{
					this.currentobj = "idfloor71";
				}
				if (GUI.Button(new Rect(350f, 2330f, 100f, 100f), this.idfloor72))
				{
					this.currentobj = "idfloor72";
				}
				if (GUI.Button(new Rect(150f, 2430f, 100f, 100f), this.idfloor73))
				{
					this.currentobj = "idfloor73";
				}
				if (GUI.Button(new Rect(250f, 2430f, 100f, 100f), this.idfloor74))
				{
					this.currentobj = "idfloor74";
				}
				if (GUI.Button(new Rect(350f, 2430f, 100f, 100f), this.idfloor75))
				{
					this.currentobj = "idfloor75";
				}
				if (GUI.Button(new Rect(150f, 2530f, 100f, 100f), this.idfloor76))
				{
					this.currentobj = "idfloor76";
				}
				if (GUI.Button(new Rect(250f, 2530f, 100f, 100f), this.idfloor77))
				{
					this.currentobj = "idfloor77";
				}
				if (GUI.Button(new Rect(350f, 2530f, 100f, 100f), this.idfloor78))
				{
					this.currentobj = "idfloor78";
				}
				if (GUI.Button(new Rect(150f, 2630f, 100f, 100f), this.idfloor79))
				{
					this.currentobj = "idfloor79";
				}
				if (GUI.Button(new Rect(250f, 2630f, 100f, 100f), this.idfloor80))
				{
					this.currentobj = "idfloor80";
				}
				if (GUI.Button(new Rect(350f, 2630f, 100f, 100f), this.idfloor81))
				{
					this.currentobj = "idfloor81";
				}
				if (GUI.Button(new Rect(150f, 2730f, 100f, 100f), this.idfloor82))
				{
					this.currentobj = "idfloor82";
				}
				if (GUI.Button(new Rect(250f, 2730f, 100f, 100f), this.idfloor83))
				{
					this.currentobj = "idfloor83";
				}
				if (GUI.Button(new Rect(350f, 2730f, 100f, 100f), this.idfloor84))
				{
					this.currentobj = "idfloor84";
				}
			}
			if (this.type == 1f && this.subtype == 6f)
			{
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.dfloor))
				{
					this.currentobj = "dfloor";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.dcelling))
				{
					this.currentobj = "dcelling";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.dwall))
				{
					this.currentobj = "dwall";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.ddoorwall))
				{
					this.currentobj = "ddoorwall";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.dcorridor))
				{
					this.currentobj = "dcorridor";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.dcornercorridor))
				{
					this.currentobj = "dcornercorridor";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.dendcorridor))
				{
					this.currentobj = "dendcorridor";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.dcrosscorridor))
				{
					this.currentobj = "dcrosscorridor";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.ddoorcorridor))
				{
					this.currentobj = "ddoorcorridor";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.dcolumn))
				{
					this.currentobj = "dcolumn";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.dscorridor))
				{
					this.currentobj = "dscorridor";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), this.dsxcorridor))
				{
					this.currentobj = "dsxcorridor";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), this.dstairs))
				{
					this.currentobj = "dstairs";
				}
			}
			if (this.type == 1f && this.subtype == 5f)
			{
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.window1))
				{
					this.currentobj = "window1";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.window2))
				{
					this.currentobj = "window2";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.window3))
				{
					this.currentobj = "window3";
				}
			}
			if (this.type == 1f && this.subtype == 7f)
			{
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.cbeamdoorway))
				{
					this.currentobj = "cbeamdoorway";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.ccollapse1))
				{
					this.currentobj = "ccollapse1";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.ccollapse2))
				{
					this.currentobj = "ccollapse2";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.ccorridordownsmall))
				{
					this.currentobj = "ccorridordownsmall";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.ccorridorsplit))
				{
					this.currentobj = "ccorridorsplit";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.ccorridorstraight))
				{
					this.currentobj = "ccorridorstraight";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.ccorridorstraightdown))
				{
					this.currentobj = "ccorridorstraightdown";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.ccorridorstraightup))
				{
					this.currentobj = "ccorridorstraightup";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.ccorridorstraightwide))
				{
					this.currentobj = "ccorridorstraightwide";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.ccorridorupsmall))
				{
					this.currentobj = "ccorridorupsmall";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.cdoor))
				{
					this.currentobj = "cdoor";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), this.croomend))
				{
					this.currentobj = "croomend";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), this.croomopen))
				{
					this.currentobj = "croomopen";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), this.croompillar))
				{
					this.currentobj = "croompillar";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), this.croomplatform))
				{
					this.currentobj = "croomplatform";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), this.ccorridorleft))
				{
					this.currentobj = "ccorridorleft";
				}
				if (GUI.Button(new Rect(250f, 530f, 100f, 100f), this.ccorridorright))
				{
					this.currentobj = "ccorridorright";
				}
				if (GUI.Button(new Rect(350f, 530f, 100f, 100f), this.cwall1))
				{
					this.currentobj = "cwall1";
				}
				if (GUI.Button(new Rect(150f, 630f, 100f, 100f), this.cwall2))
				{
					this.currentobj = "cwall2";
				}
				if (GUI.Button(new Rect(250f, 630f, 100f, 100f), this.cwall3))
				{
					this.currentobj = "cwall3";
				}
				if (GUI.Button(new Rect(350f, 630f, 100f, 100f), this.cwall4))
				{
					this.currentobj = "cwall4";
				}
				if (GUI.Button(new Rect(150f, 730f, 100f, 100f), this.cwall5))
				{
					this.currentobj = "cwall5";
				}
			}
			if (this.type == 1f && this.subtype == 8f)
			{
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.sbarrel))
				{
					this.currentobj = "sbarrel";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.sbridgedown))
				{
					this.currentobj = "sbridgedown";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.sbridgestraight))
				{
					this.currentobj = "sbridgestraight";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.sbridgeup))
				{
					this.currentobj = "sbridgeup";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.shanger))
				{
					this.currentobj = "shanger";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.shouse1))
				{
					this.currentobj = "shouse1";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.shouse2))
				{
					this.currentobj = "shouse2";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.spipes))
				{
					this.currentobj = "spipes";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.splatform))
				{
					this.currentobj = "splatform";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.splatformy))
				{
					this.currentobj = "splatformy";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.sroadarc))
				{
					this.currentobj = "sroadarc";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), this.sroadpads))
				{
					this.currentobj = "sroadpads";
				}
			}
			if (this.type == 1f && this.subtype == 9f)
			{
				GUI.Label(new Rect(250f, 10f, 100f, 20f), "Blood Tiles");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.blood1))
				{
					this.currentobj = "blood_hd1";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.blood2))
				{
					this.currentobj = "blood_hd2";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.blood3))
				{
					this.currentobj = "blood_hd3";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.blood4))
				{
					this.currentobj = "blood_hd4";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.blood5))
				{
					this.currentobj = "blood_hd5";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.blood6))
				{
					this.currentobj = "blood_hd6";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.blood7))
				{
					this.currentobj = "blood_hd7";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.blood8))
				{
					this.currentobj = "blood_hd8";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.blood9))
				{
					this.currentobj = "blood_hd9";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.blood10))
				{
					this.currentobj = "blood_hd10";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.blood11))
				{
					this.currentobj = "blood_hd11";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), this.blood12))
				{
					this.currentobj = "blood_hd12";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), this.blood13))
				{
					this.currentobj = "blood_hd13";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), this.blood14))
				{
					this.currentobj = "blood_hd14";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), this.blood15))
				{
					this.currentobj = "blood_hd15";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), this.blood16))
				{
					this.currentobj = "blood_hd16";
				}
				if (GUI.Button(new Rect(250f, 530f, 100f, 100f), this.blood17))
				{
					this.currentobj = "blood_hd17";
				}
				if (GUI.Button(new Rect(350f, 530f, 100f, 100f), this.blood18))
				{
					this.currentobj = "blood_hd18";
				}
			}
		}
		if (this.type == 4f)
		{
			GUI.Label(new Rect(250f, 10f, 300f, 20f), "Lights");
			if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Area Light"))
			{
				this.currentobj = "Arealight";
			}
			if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Spot Light"))
			{
				this.currentobj = "Spotlight";
			}
			if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Global Light"))
			{
				this.currentobj = "Globallight";
			}
		}
		if (this.type == 3f)
		{
			if (GUI.Button(new Rect(20f, 30f, 110f, 20f), "Fire"))
			{
				this.subtype = 1f;
			}
			if (GUI.Button(new Rect(20f, 50f, 110f, 20f), "Objects"))
			{
				this.subtype = 2f;
			}
			if (GUI.Button(new Rect(20f, 70f, 110f, 20f), "Explosions"))
			{
				this.subtype = 3f;
			}
			if (GUI.Button(new Rect(20f, 90f, 110f, 20f), "Blood"))
			{
				this.subtype = 4f;
			}
			if (GUI.Button(new Rect(20f, 110f, 110f, 20f), "Weather"))
			{
				this.subtype = 5f;
			}
			if (GUI.Button(new Rect(20f, 130f, 110f, 20f), "Misc"))
			{
				this.subtype = 6f;
			}
			if (GUI.Button(new Rect(20f, 150f, 110f, 20f), "Nature"))
			{
				this.subtype = 7f;
			}
			if (GUI.Button(new Rect(20f, 170f, 110f, 20f), "Interactive"))
			{
				this.subtype = 8f;
			}
			if (GUI.Button(new Rect(20f, 190f, 110f, 20f), "Flares"))
			{
				this.subtype = 9f;
			}
			if (this.subtype == 1f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Fire");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Camp Fire"))
				{
					this.currentobj = "Camp_Fire";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Candle"))
				{
					this.currentobj = "Candle";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Fire"))
				{
					this.currentobj = "Fire";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Oil Fire"))
				{
					this.currentobj = "Oil_Fire";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Oil Leak"))
				{
					this.currentobj = "Oil_Leak";
				}
			}
			if (this.subtype == 2f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Objects");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Candles"))
				{
					this.currentobj = "Candles";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Hanging\nTorch"))
				{
					this.currentobj = "HangingTorch";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Lantern"))
				{
					this.currentobj = "Lantern";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Metal Ground\nTorch"))
				{
					this.currentobj = "MetalGroundTorch";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Metal Ground\nTorch2"))
				{
					this.currentobj = "MetalGroundTorch2";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), "Stone Torch"))
				{
					this.currentobj = "StoneTorch";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), "Wall Torch"))
				{
					this.currentobj = "WallTorch";
				}
			}
			if (this.subtype == 3f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Explosions");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Artillery\nStrike"))
				{
					this.currentobj = "ArtilleryStrike";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Atom Bomb"))
				{
					this.currentobj = "AtomBomb";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Explosion"))
				{
					this.currentobj = "Explosion";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Grenade\nExplosion"))
				{
					this.currentobj = "GrenadeExplosion";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Oil\nExplosion"))
				{
					this.currentobj = "OilExplosion";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), "Small\nExplosion"))
				{
					this.currentobj = "SmallExplosion";
				}
			}
			if (this.subtype == 4f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Blood");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Blood\nParticles"))
				{
					this.currentobj = "BloodParticles";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Blood Squirt"))
				{
					this.currentobj = "BloodSquirt";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Blood Squirt2"))
				{
					this.currentobj = "BloodSquirt2";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Blood\nWaterfall"))
				{
					this.currentobj = "BloodWaterfall";
				}
			}
			if (this.subtype == 5f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Weather");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Dust"))
				{
					this.currentobj = "Dust";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Hail"))
				{
					this.currentobj = "Hail";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Rain"))
				{
					this.currentobj = "Rain";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Snow"))
				{
					this.currentobj = "Snow";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Flurries"))
				{
					this.currentobj = "Flurries";
				}
			}
			if (this.subtype == 6f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Misc");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Acid Spray"))
				{
					this.currentobj = "AcidSpray";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Fireworks"))
				{
					this.currentobj = "Fireworks";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Green Gas"))
				{
					this.currentobj = "GreenGas";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Green Mist"))
				{
					this.currentobj = "GreenMist";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Leaves Falling"))
				{
					this.currentobj = "LeavesFalling";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), "Red Orbs\nDash"))
				{
					this.currentobj = "RedOrbsDash";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), "Smoke"))
				{
					this.currentobj = "Smoke";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), "Smoke Large"))
				{
					this.currentobj = "SmokeLarge";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), "Soap Bubbles"))
				{
					this.currentobj = "SoapBubbles";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), "Sparkles"))
				{
					this.currentobj = "Sparkles";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), "Sparks"))
				{
					this.currentobj = "Sparks";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), "Sparks\n(OneShot)"))
				{
					this.currentobj = "Sparks(OneShot)";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), "Cold Water"))
				{
					this.currentobj = "WaterCold";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), "Waterfall"))
				{
					this.currentobj = "WaterFall";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), "Water Hose"))
				{
					this.currentobj = "WaterHose";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), "Hot Water"))
				{
					this.currentobj = "WaterHot";
				}
				if (GUI.Button(new Rect(250f, 530f, 100f, 100f), "White Orbs"))
				{
					this.currentobj = "WhiteOrbs";
				}
				if (GUI.Button(new Rect(350f, 530f, 100f, 100f), "Water"))
				{
					this.currentobj = "Water";
				}
			}
			if (this.subtype == 7f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Nature");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Aspen Tree"))
				{
					this.currentobj = "Aspen Tree";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Cedar Tree"))
				{
					this.currentobj = "Cedar Tree";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Elm Tree"))
				{
					this.currentobj = "Elm Tree";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Fir Tree"))
				{
					this.currentobj = "Fir Tree";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Hickory Tree"))
				{
					this.currentobj = "Hickory Tree";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), "Maple Tree"))
				{
					this.currentobj = "Maple Tree";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), "Oak Tree"))
				{
					this.currentobj = "Oak Tree";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), "Spruce Tree"))
				{
					this.currentobj = "Spruce Tree";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), "Willow Tree"))
				{
					this.currentobj = "Willow Tree";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), "Plant 1"))
				{
					this.currentobj = "Plant 1";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), "Plant 2"))
				{
					this.currentobj = "Plant 2";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), "Plant 3"))
				{
					this.currentobj = "Plant 3";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), "Tall Grass 1"))
				{
					this.currentobj = "Tall Grass 1";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), "Tall Grass 2"))
				{
					this.currentobj = "Tall Grass 2";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), "Tall Grass 3"))
				{
					this.currentobj = "Tall Grass 3";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), "Wind Zone"))
				{
					this.currentobj = "Wind Zone";
				}
			}
			if (this.subtype == 8f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Interactive Objects");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Useable Crate\n(Open/Close)"))
				{
					this.currentobj = "Useable Crate";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Old Chest\n(Open/Close)"))
				{
					this.currentobj = "Old Chest";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Treasure\nChest\n(Open/Close)"))
				{
					this.currentobj = "Treasure Chest";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Dual Doors 1\n(Open/Close)"))
				{
					this.currentobj = "Dual Doors 1";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Dual Doors 2\n(Open/Close)"))
				{
					this.currentobj = "Dual Doors 2";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), "Dual Doors 3\n(Open/Close)"))
				{
					this.currentobj = "Dual Doors 3";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), "Dual Doors 4\n(Open/Close)"))
				{
					this.currentobj = "Dual Doors 4";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), "Dual Gates 1\n(Open/Close)"))
				{
					this.currentobj = "Dual Gates 1";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), "Dual Gates 2\n(Open/Close)"))
				{
					this.currentobj = "Dual Gates 2";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), "Coffin\n(Open/Close)"))
				{
					this.currentobj = "Coffin";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), "Cobweb 1"))
				{
					this.currentobj = "Cobweb 1";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), "Cobweb 2"))
				{
					this.currentobj = "Cobweb 2";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), "Barrier"))
				{
					this.currentobj = "Barrier";
				}
			}
			if (this.subtype == 9f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Flares");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Blade Aperture"))
				{
					this.currentobj = "Blade Aperture";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "35mm Lens"))
				{
					this.currentobj = "35mm Lens";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "85mm Lens"))
				{
					this.currentobj = "85mm Lens";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Plastic Lens"))
				{
					this.currentobj = "Plastic Lens";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Cold Sun"))
				{
					this.currentobj = "Cold Sun";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), "Concert"))
				{
					this.currentobj = "Concert";
				}
				if (GUI.Button(new Rect(150f, 230f, 100f, 100f), "Digicam Lens"))
				{
					this.currentobj = "Digicam Lens";
				}
				if (GUI.Button(new Rect(250f, 230f, 100f, 100f), "Digital Camera"))
				{
					this.currentobj = "Digital Camera";
				}
				if (GUI.Button(new Rect(350f, 230f, 100f, 100f), "Halogen Bulb"))
				{
					this.currentobj = "Halogen Bulb";
				}
				if (GUI.Button(new Rect(150f, 330f, 100f, 100f), "Laser"))
				{
					this.currentobj = "Laser";
				}
				if (GUI.Button(new Rect(250f, 330f, 100f, 100f), "Subtle 1"))
				{
					this.currentobj = "Subtle 1";
				}
				if (GUI.Button(new Rect(350f, 330f, 100f, 100f), "Subtle 2"))
				{
					this.currentobj = "Subtle 2";
				}
				if (GUI.Button(new Rect(150f, 430f, 100f, 100f), "Subtle 3"))
				{
					this.currentobj = "Subtle 3";
				}
				if (GUI.Button(new Rect(250f, 430f, 100f, 100f), "Subtle 4"))
				{
					this.currentobj = "Subtle 4";
				}
				if (GUI.Button(new Rect(350f, 430f, 100f, 100f), "Sun"))
				{
					this.currentobj = "Sun";
				}
				if (GUI.Button(new Rect(150f, 530f, 100f, 100f), "Welding"))
				{
					this.currentobj = "Welding";
				}
			}
		}
		if (this.type == 5f)
		{
			GUI.Label(new Rect(250f, 10f, 100f, 20f), "Doors");
			if (GUI.Button(new Rect(150f, 30f, 100f, 100f), this.door1))
			{
				this.currentobj = "door1";
			}
			if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.door2))
			{
				this.currentobj = "door2";
			}
			if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.door3))
			{
				this.currentobj = "door3";
			}
			if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.door4))
			{
				this.currentobj = "door4";
			}
			if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.door5))
			{
				this.currentobj = "door5";
			}
			if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.door6))
			{
				this.currentobj = "door6";
			}
			if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.door7))
			{
				this.currentobj = "door7";
			}
			if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.door8))
			{
				this.currentobj = "door8";
			}
			if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.door9))
			{
				this.currentobj = "door9";
			}
		}
		if (this.type == 2f)
		{
			if (GUI.Button(new Rect(20f, 30f, 110f, 20f), "Pre-Built"))
			{
				this.subtype = 0f;
			}
			if (GUI.Button(new Rect(20f, 50f, 110f, 20f), "Custom Item#1"))
			{
				this.currentobj = "Custom Item1";
				this.subtype = 1f;
				this.type1.gameObject.GetComponent<CustomItemsProperties>().enabled = true;
				this.type2.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type3.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type4.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type5.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.currentpath = "Items/Custom Item1";
				base.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 70f, 110f, 20f), "Custom Item#2"))
			{
				this.currentobj = "Custom Item2";
				this.subtype = 2f;
				this.type1.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type2.gameObject.GetComponent<CustomItemsProperties>().enabled = true;
				this.type3.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type4.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type5.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.currentpath = "Items/Custom Item2";
				base.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 90f, 110f, 20f), "Custom Item#3"))
			{
				this.currentobj = "Custom Item3";
				this.subtype = 3f;
				this.type1.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type2.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type3.gameObject.GetComponent<CustomItemsProperties>().enabled = true;
				this.type4.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type5.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.currentpath = "Items/Custom Item3";
				base.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 110f, 110f, 20f), "Custom Item#4"))
			{
				this.currentobj = "Custom Item4";
				this.subtype = 4f;
				this.type1.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type2.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type3.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type4.gameObject.GetComponent<CustomItemsProperties>().enabled = true;
				this.type5.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.currentpath = "Items/Custom Item4";
				base.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 130f, 110f, 20f), "Custom Item#5"))
			{
				this.currentobj = "Custom Item5";
				this.subtype = 5f;
				this.type1.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type2.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type3.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type4.gameObject.GetComponent<CustomItemsProperties>().enabled = false;
				this.type5.gameObject.GetComponent<CustomItemsProperties>().enabled = true;
				this.currentpath = "Items/Custom Item5";
				base.enabled = false;
			}
			if (this.subtype == 0f)
			{
				GUI.Label(new Rect(250f, 10f, 300f, 20f), "Pre-built Items");
				if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "Flashlight"))
				{
					this.currentobj = "Flashlight";
				}
				if (GUI.Button(new Rect(250f, 30f, 100f, 100f), "Candle"))
				{
					this.currentobj = "CandleItem";
				}
				if (GUI.Button(new Rect(350f, 30f, 100f, 100f), "Lantern"))
				{
					this.currentobj = "Lantern";
				}
				if (GUI.Button(new Rect(150f, 130f, 100f, 100f), "Flame Torch"))
				{
					this.currentobj = "Flame Torch";
				}
				if (GUI.Button(new Rect(250f, 130f, 100f, 100f), "Nightvision\nCamera"))
				{
					this.currentobj = "Nvcamera";
				}
				if (GUI.Button(new Rect(350f, 130f, 100f, 100f), "Nightvision\nGoggles"))
				{
					this.currentobj = "Nvgoggles";
				}
				GUI.Label(new Rect(250f, 250f, 100f, 20f), "Other:");
				if (GUI.Button(new Rect(150f, 270f, 100f, 100f), "Health Pack"))
				{
					this.currentobj = "Healthpack";
				}
				if (GUI.Button(new Rect(250f, 270f, 100f, 100f), "N/A"))
				{
					this.currentobj = "Health";
				}
				if (GUI.Button(new Rect(350f, 270f, 100f, 100f), "N/A"))
				{
					this.currentobj = "Health";
				}
				if (GUI.Button(new Rect(150f, 370f, 100f, 100f), "N/A"))
				{
					this.currentobj = "Health";
				}
				GUI.Label(new Rect(250f, 490f, 100f, 20f), "Keys:");
				if (GUI.Button(new Rect(150f, 510f, 100f, 100f), "Key ID:1"))
				{
					this.currentobj = "Key1";
				}
				if (GUI.Button(new Rect(250f, 510f, 100f, 100f), "Key ID:2"))
				{
					this.currentobj = "Key2";
				}
				if (GUI.Button(new Rect(350f, 510f, 100f, 100f), "Key ID:3"))
				{
					this.currentobj = "Key3";
				}
				if (GUI.Button(new Rect(150f, 610f, 100f, 100f), "Key ID:4"))
				{
					this.currentobj = "Key4";
				}
				if (GUI.Button(new Rect(250f, 610f, 100f, 100f), "Key ID:5"))
				{
					this.currentobj = "Key5";
				}
				if (GUI.Button(new Rect(350f, 610f, 100f, 100f), "Key ID:6"))
				{
					this.currentobj = "Key6";
				}
				if (GUI.Button(new Rect(150f, 710f, 100f, 100f), "Key ID:7"))
				{
					this.currentobj = "Key7";
				}
				if (GUI.Button(new Rect(250f, 710f, 100f, 100f), "Key ID:8"))
				{
					this.currentobj = "Key8";
				}
				if (GUI.Button(new Rect(350f, 710f, 100f, 100f), "Key ID:9"))
				{
					this.currentobj = "Key9";
				}
			}
		}
		if (this.type == 6f)
		{
			GameObject gameObject = GameObject.Find("TerrainSettings");
			GUI.Label(new Rect(250f, 10f, 100f, 20f), "Terrain");
			if (GUI.Button(new Rect(150f, 30f, 100f, 100f), "None"))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(250f, 30f, 100f, 100f), this.grassland1))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = true;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(350f, 30f, 100f, 100f), this.grassland2))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = true;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(150f, 130f, 100f, 100f), this.grassland3))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = true;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(250f, 130f, 100f, 100f), this.canyonland1))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = true;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(350f, 130f, 100f, 100f), this.canyonland2))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = true;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(150f, 230f, 100f, 100f), this.canyonland3))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = true;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(250f, 230f, 100f, 100f), this.snowland1))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = true;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(350f, 230f, 100f, 100f), this.snowland2))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = true;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(150f, 330f, 100f, 100f), this.snowland3))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = true;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = false;
			}
			if (GUI.Button(new Rect(250f, 330f, 100f, 100f), this.water))
			{
				gameObject.GetComponent<TerrainProperties>().grassland1 = false;
				gameObject.GetComponent<TerrainProperties>().grassland2 = false;
				gameObject.GetComponent<TerrainProperties>().grassland3 = false;
				gameObject.GetComponent<TerrainProperties>().snowland1 = false;
				gameObject.GetComponent<TerrainProperties>().snowland2 = false;
				gameObject.GetComponent<TerrainProperties>().snowland3 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland1 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland2 = false;
				gameObject.GetComponent<TerrainProperties>().canyonland3 = false;
				gameObject.GetComponent<TerrainProperties>().waterwater = true;
			}
		}
		GUI.EndScrollView();
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0002F1A2 File Offset: 0x0002D5A2
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(5, new Rect(5f, 40f, 550f, 430f), new GUI.WindowFunction(this.DoWindow0), string.Empty);
	}

	// Token: 0x040004F8 RID: 1272
	public GUISkin skin;

	// Token: 0x040004F9 RID: 1273
	public Vector2 scrollPosition;

	// Token: 0x040004FA RID: 1274
	public float type;

	// Token: 0x040004FB RID: 1275
	public float subtype;

	// Token: 0x040004FC RID: 1276
	public string currentobj;

	// Token: 0x040004FD RID: 1277
	public string currentpath;

	// Token: 0x040004FE RID: 1278
	public string checkobj;

	// Token: 0x040004FF RID: 1279
	public Texture2D odwall1;

	// Token: 0x04000500 RID: 1280
	public Texture2D odwall2;

	// Token: 0x04000501 RID: 1281
	public Texture2D odwall3;

	// Token: 0x04000502 RID: 1282
	public Texture2D odwall4;

	// Token: 0x04000503 RID: 1283
	public Texture2D odwall5;

	// Token: 0x04000504 RID: 1284
	public Texture2D odwall6;

	// Token: 0x04000505 RID: 1285
	public Texture2D odwall7;

	// Token: 0x04000506 RID: 1286
	public Texture2D odwall8;

	// Token: 0x04000507 RID: 1287
	public Texture2D odwall9;

	// Token: 0x04000508 RID: 1288
	public Texture2D odwall10;

	// Token: 0x04000509 RID: 1289
	public Texture2D odwall11;

	// Token: 0x0400050A RID: 1290
	public Texture2D odwall12;

	// Token: 0x0400050B RID: 1291
	public Texture2D odwall13;

	// Token: 0x0400050C RID: 1292
	public Texture2D odwall14;

	// Token: 0x0400050D RID: 1293
	public Texture2D odwall15;

	// Token: 0x0400050E RID: 1294
	public Texture2D odwall16;

	// Token: 0x0400050F RID: 1295
	public Texture2D odwall17;

	// Token: 0x04000510 RID: 1296
	public Texture2D odwall18;

	// Token: 0x04000511 RID: 1297
	public Texture2D odwall19;

	// Token: 0x04000512 RID: 1298
	public Texture2D odwall20;

	// Token: 0x04000513 RID: 1299
	public Texture2D odwall21;

	// Token: 0x04000514 RID: 1300
	public Texture2D odwall22;

	// Token: 0x04000515 RID: 1301
	public Texture2D odwall23;

	// Token: 0x04000516 RID: 1302
	public Texture2D odwall24;

	// Token: 0x04000517 RID: 1303
	public Texture2D odwall25;

	// Token: 0x04000518 RID: 1304
	public Texture2D odwall26;

	// Token: 0x04000519 RID: 1305
	public Texture2D odwall27;

	// Token: 0x0400051A RID: 1306
	public Texture2D odfloor1;

	// Token: 0x0400051B RID: 1307
	public Texture2D odfloor2;

	// Token: 0x0400051C RID: 1308
	public Texture2D odfloor3;

	// Token: 0x0400051D RID: 1309
	public Texture2D odfloor4;

	// Token: 0x0400051E RID: 1310
	public Texture2D odfloor5;

	// Token: 0x0400051F RID: 1311
	public Texture2D odfloor6;

	// Token: 0x04000520 RID: 1312
	public Texture2D odfloor7;

	// Token: 0x04000521 RID: 1313
	public Texture2D odfloor8;

	// Token: 0x04000522 RID: 1314
	public Texture2D odfloor9;

	// Token: 0x04000523 RID: 1315
	public Texture2D odfloor10;

	// Token: 0x04000524 RID: 1316
	public Texture2D odfloor11;

	// Token: 0x04000525 RID: 1317
	public Texture2D odfloor12;

	// Token: 0x04000526 RID: 1318
	public Texture2D odfloor13;

	// Token: 0x04000527 RID: 1319
	public Texture2D odfloor14;

	// Token: 0x04000528 RID: 1320
	public Texture2D odfloor15;

	// Token: 0x04000529 RID: 1321
	public Texture2D odfloor16;

	// Token: 0x0400052A RID: 1322
	public Texture2D odfloor17;

	// Token: 0x0400052B RID: 1323
	public Texture2D odfloor18;

	// Token: 0x0400052C RID: 1324
	public Texture2D odfloor19;

	// Token: 0x0400052D RID: 1325
	public Texture2D odfloor20;

	// Token: 0x0400052E RID: 1326
	public Texture2D odfloor21;

	// Token: 0x0400052F RID: 1327
	public Texture2D odfloor22;

	// Token: 0x04000530 RID: 1328
	public Texture2D odfloor23;

	// Token: 0x04000531 RID: 1329
	public Texture2D odfloor24;

	// Token: 0x04000532 RID: 1330
	public Texture2D odfloor25;

	// Token: 0x04000533 RID: 1331
	public Texture2D odfloor26;

	// Token: 0x04000534 RID: 1332
	public Texture2D odfloor27;

	// Token: 0x04000535 RID: 1333
	public Texture2D odfloor28;

	// Token: 0x04000536 RID: 1334
	public Texture2D odfloor29;

	// Token: 0x04000537 RID: 1335
	public Texture2D odfloor30;

	// Token: 0x04000538 RID: 1336
	public Texture2D odfloor31;

	// Token: 0x04000539 RID: 1337
	public Texture2D odfloor32;

	// Token: 0x0400053A RID: 1338
	public Texture2D odfloor33;

	// Token: 0x0400053B RID: 1339
	public Texture2D odfloor34;

	// Token: 0x0400053C RID: 1340
	public Texture2D odfloor35;

	// Token: 0x0400053D RID: 1341
	public Texture2D odfloor36;

	// Token: 0x0400053E RID: 1342
	public Texture2D odfloor37;

	// Token: 0x0400053F RID: 1343
	public Texture2D odfloor38;

	// Token: 0x04000540 RID: 1344
	public Texture2D odfloor39;

	// Token: 0x04000541 RID: 1345
	public Texture2D odfloor40;

	// Token: 0x04000542 RID: 1346
	public Texture2D odfloor41;

	// Token: 0x04000543 RID: 1347
	public Texture2D odfloor42;

	// Token: 0x04000544 RID: 1348
	public Texture2D idwall1;

	// Token: 0x04000545 RID: 1349
	public Texture2D idwall2;

	// Token: 0x04000546 RID: 1350
	public Texture2D idwall3;

	// Token: 0x04000547 RID: 1351
	public Texture2D idwall4;

	// Token: 0x04000548 RID: 1352
	public Texture2D idwall5;

	// Token: 0x04000549 RID: 1353
	public Texture2D idwall6;

	// Token: 0x0400054A RID: 1354
	public Texture2D idwall7;

	// Token: 0x0400054B RID: 1355
	public Texture2D idwall8;

	// Token: 0x0400054C RID: 1356
	public Texture2D idwall9;

	// Token: 0x0400054D RID: 1357
	public Texture2D idwall10;

	// Token: 0x0400054E RID: 1358
	public Texture2D idwall11;

	// Token: 0x0400054F RID: 1359
	public Texture2D idwall12;

	// Token: 0x04000550 RID: 1360
	public Texture2D idwall13;

	// Token: 0x04000551 RID: 1361
	public Texture2D idwall14;

	// Token: 0x04000552 RID: 1362
	public Texture2D idwall15;

	// Token: 0x04000553 RID: 1363
	public Texture2D idwall16;

	// Token: 0x04000554 RID: 1364
	public Texture2D idwall17;

	// Token: 0x04000555 RID: 1365
	public Texture2D idwall18;

	// Token: 0x04000556 RID: 1366
	public Texture2D idwall19;

	// Token: 0x04000557 RID: 1367
	public Texture2D idwall20;

	// Token: 0x04000558 RID: 1368
	public Texture2D idwall21;

	// Token: 0x04000559 RID: 1369
	public Texture2D idwall22;

	// Token: 0x0400055A RID: 1370
	public Texture2D idwall23;

	// Token: 0x0400055B RID: 1371
	public Texture2D idwall24;

	// Token: 0x0400055C RID: 1372
	public Texture2D idwall25;

	// Token: 0x0400055D RID: 1373
	public Texture2D idwall26;

	// Token: 0x0400055E RID: 1374
	public Texture2D idwall27;

	// Token: 0x0400055F RID: 1375
	public Texture2D idwall28;

	// Token: 0x04000560 RID: 1376
	public Texture2D idwall29;

	// Token: 0x04000561 RID: 1377
	public Texture2D idwall30;

	// Token: 0x04000562 RID: 1378
	public Texture2D idwall31;

	// Token: 0x04000563 RID: 1379
	public Texture2D idwall32;

	// Token: 0x04000564 RID: 1380
	public Texture2D idwall33;

	// Token: 0x04000565 RID: 1381
	public Texture2D idwall34;

	// Token: 0x04000566 RID: 1382
	public Texture2D idwall35;

	// Token: 0x04000567 RID: 1383
	public Texture2D idwall36;

	// Token: 0x04000568 RID: 1384
	public Texture2D idwall37;

	// Token: 0x04000569 RID: 1385
	public Texture2D idwall38;

	// Token: 0x0400056A RID: 1386
	public Texture2D idwall39;

	// Token: 0x0400056B RID: 1387
	public Texture2D idwall40;

	// Token: 0x0400056C RID: 1388
	public Texture2D idwall41;

	// Token: 0x0400056D RID: 1389
	public Texture2D idwall42;

	// Token: 0x0400056E RID: 1390
	public Texture2D idwall43;

	// Token: 0x0400056F RID: 1391
	public Texture2D idwall44;

	// Token: 0x04000570 RID: 1392
	public Texture2D idwall45;

	// Token: 0x04000571 RID: 1393
	public Texture2D idwall46;

	// Token: 0x04000572 RID: 1394
	public Texture2D idwall47;

	// Token: 0x04000573 RID: 1395
	public Texture2D idwall48;

	// Token: 0x04000574 RID: 1396
	public Texture2D idwall49;

	// Token: 0x04000575 RID: 1397
	public Texture2D idwall50;

	// Token: 0x04000576 RID: 1398
	public Texture2D idwall51;

	// Token: 0x04000577 RID: 1399
	public Texture2D idwall52;

	// Token: 0x04000578 RID: 1400
	public Texture2D idwall53;

	// Token: 0x04000579 RID: 1401
	public Texture2D idwall54;

	// Token: 0x0400057A RID: 1402
	public Texture2D idwall55;

	// Token: 0x0400057B RID: 1403
	public Texture2D idwall56;

	// Token: 0x0400057C RID: 1404
	public Texture2D idwall57;

	// Token: 0x0400057D RID: 1405
	public Texture2D idwall58;

	// Token: 0x0400057E RID: 1406
	public Texture2D idwall59;

	// Token: 0x0400057F RID: 1407
	public Texture2D idwall60;

	// Token: 0x04000580 RID: 1408
	public Texture2D idwall61;

	// Token: 0x04000581 RID: 1409
	public Texture2D idwall62;

	// Token: 0x04000582 RID: 1410
	public Texture2D idwall63;

	// Token: 0x04000583 RID: 1411
	public Texture2D idwall64;

	// Token: 0x04000584 RID: 1412
	public Texture2D idwall65;

	// Token: 0x04000585 RID: 1413
	public Texture2D idwall66;

	// Token: 0x04000586 RID: 1414
	public Texture2D idwall67;

	// Token: 0x04000587 RID: 1415
	public Texture2D idwall68;

	// Token: 0x04000588 RID: 1416
	public Texture2D idwall69;

	// Token: 0x04000589 RID: 1417
	public Texture2D idwall70;

	// Token: 0x0400058A RID: 1418
	public Texture2D idwall71;

	// Token: 0x0400058B RID: 1419
	public Texture2D idwall72;

	// Token: 0x0400058C RID: 1420
	public Texture2D idwall73;

	// Token: 0x0400058D RID: 1421
	public Texture2D idwall74;

	// Token: 0x0400058E RID: 1422
	public Texture2D idwall75;

	// Token: 0x0400058F RID: 1423
	public Texture2D idwall76;

	// Token: 0x04000590 RID: 1424
	public Texture2D idwall77;

	// Token: 0x04000591 RID: 1425
	public Texture2D idwall78;

	// Token: 0x04000592 RID: 1426
	public Texture2D idwall79;

	// Token: 0x04000593 RID: 1427
	public Texture2D idwall80;

	// Token: 0x04000594 RID: 1428
	public Texture2D idwall81;

	// Token: 0x04000595 RID: 1429
	public Texture2D idwall82;

	// Token: 0x04000596 RID: 1430
	public Texture2D idwall83;

	// Token: 0x04000597 RID: 1431
	public Texture2D idwall84;

	// Token: 0x04000598 RID: 1432
	public Texture2D idwall85;

	// Token: 0x04000599 RID: 1433
	public Texture2D idwall86;

	// Token: 0x0400059A RID: 1434
	public Texture2D idwall87;

	// Token: 0x0400059B RID: 1435
	public Texture2D idwall88;

	// Token: 0x0400059C RID: 1436
	public Texture2D idwall89;

	// Token: 0x0400059D RID: 1437
	public Texture2D idwall90;

	// Token: 0x0400059E RID: 1438
	public Texture2D idwall91;

	// Token: 0x0400059F RID: 1439
	public Texture2D idwall92;

	// Token: 0x040005A0 RID: 1440
	public Texture2D idwall93;

	// Token: 0x040005A1 RID: 1441
	public Texture2D idwall94;

	// Token: 0x040005A2 RID: 1442
	public Texture2D idwall95;

	// Token: 0x040005A3 RID: 1443
	public Texture2D idwall96;

	// Token: 0x040005A4 RID: 1444
	public Texture2D idwall97;

	// Token: 0x040005A5 RID: 1445
	public Texture2D idwall98;

	// Token: 0x040005A6 RID: 1446
	public Texture2D idwall99;

	// Token: 0x040005A7 RID: 1447
	public Texture2D idwall100;

	// Token: 0x040005A8 RID: 1448
	public Texture2D idwall101;

	// Token: 0x040005A9 RID: 1449
	public Texture2D idwall102;

	// Token: 0x040005AA RID: 1450
	public Texture2D idwall103;

	// Token: 0x040005AB RID: 1451
	public Texture2D idwall104;

	// Token: 0x040005AC RID: 1452
	public Texture2D idwall105;

	// Token: 0x040005AD RID: 1453
	public Texture2D idfloor1;

	// Token: 0x040005AE RID: 1454
	public Texture2D idfloor2;

	// Token: 0x040005AF RID: 1455
	public Texture2D idfloor3;

	// Token: 0x040005B0 RID: 1456
	public Texture2D idfloor4;

	// Token: 0x040005B1 RID: 1457
	public Texture2D idfloor5;

	// Token: 0x040005B2 RID: 1458
	public Texture2D idfloor6;

	// Token: 0x040005B3 RID: 1459
	public Texture2D idfloor7;

	// Token: 0x040005B4 RID: 1460
	public Texture2D idfloor8;

	// Token: 0x040005B5 RID: 1461
	public Texture2D idfloor9;

	// Token: 0x040005B6 RID: 1462
	public Texture2D idfloor10;

	// Token: 0x040005B7 RID: 1463
	public Texture2D idfloor11;

	// Token: 0x040005B8 RID: 1464
	public Texture2D idfloor12;

	// Token: 0x040005B9 RID: 1465
	public Texture2D idfloor13;

	// Token: 0x040005BA RID: 1466
	public Texture2D idfloor14;

	// Token: 0x040005BB RID: 1467
	public Texture2D idfloor15;

	// Token: 0x040005BC RID: 1468
	public Texture2D idfloor16;

	// Token: 0x040005BD RID: 1469
	public Texture2D idfloor17;

	// Token: 0x040005BE RID: 1470
	public Texture2D idfloor18;

	// Token: 0x040005BF RID: 1471
	public Texture2D idfloor19;

	// Token: 0x040005C0 RID: 1472
	public Texture2D idfloor20;

	// Token: 0x040005C1 RID: 1473
	public Texture2D idfloor21;

	// Token: 0x040005C2 RID: 1474
	public Texture2D idfloor22;

	// Token: 0x040005C3 RID: 1475
	public Texture2D idfloor23;

	// Token: 0x040005C4 RID: 1476
	public Texture2D idfloor24;

	// Token: 0x040005C5 RID: 1477
	public Texture2D idfloor25;

	// Token: 0x040005C6 RID: 1478
	public Texture2D idfloor26;

	// Token: 0x040005C7 RID: 1479
	public Texture2D idfloor27;

	// Token: 0x040005C8 RID: 1480
	public Texture2D idfloor28;

	// Token: 0x040005C9 RID: 1481
	public Texture2D idfloor29;

	// Token: 0x040005CA RID: 1482
	public Texture2D idfloor30;

	// Token: 0x040005CB RID: 1483
	public Texture2D idfloor31;

	// Token: 0x040005CC RID: 1484
	public Texture2D idfloor32;

	// Token: 0x040005CD RID: 1485
	public Texture2D idfloor33;

	// Token: 0x040005CE RID: 1486
	public Texture2D idfloor34;

	// Token: 0x040005CF RID: 1487
	public Texture2D idfloor35;

	// Token: 0x040005D0 RID: 1488
	public Texture2D idfloor36;

	// Token: 0x040005D1 RID: 1489
	public Texture2D idfloor37;

	// Token: 0x040005D2 RID: 1490
	public Texture2D idfloor38;

	// Token: 0x040005D3 RID: 1491
	public Texture2D idfloor39;

	// Token: 0x040005D4 RID: 1492
	public Texture2D idfloor40;

	// Token: 0x040005D5 RID: 1493
	public Texture2D idfloor41;

	// Token: 0x040005D6 RID: 1494
	public Texture2D idfloor42;

	// Token: 0x040005D7 RID: 1495
	public Texture2D idfloor43;

	// Token: 0x040005D8 RID: 1496
	public Texture2D idfloor44;

	// Token: 0x040005D9 RID: 1497
	public Texture2D idfloor45;

	// Token: 0x040005DA RID: 1498
	public Texture2D idfloor46;

	// Token: 0x040005DB RID: 1499
	public Texture2D idfloor47;

	// Token: 0x040005DC RID: 1500
	public Texture2D idfloor48;

	// Token: 0x040005DD RID: 1501
	public Texture2D idfloor49;

	// Token: 0x040005DE RID: 1502
	public Texture2D idfloor50;

	// Token: 0x040005DF RID: 1503
	public Texture2D idfloor51;

	// Token: 0x040005E0 RID: 1504
	public Texture2D idfloor52;

	// Token: 0x040005E1 RID: 1505
	public Texture2D idfloor53;

	// Token: 0x040005E2 RID: 1506
	public Texture2D idfloor54;

	// Token: 0x040005E3 RID: 1507
	public Texture2D idfloor55;

	// Token: 0x040005E4 RID: 1508
	public Texture2D idfloor56;

	// Token: 0x040005E5 RID: 1509
	public Texture2D idfloor57;

	// Token: 0x040005E6 RID: 1510
	public Texture2D idfloor58;

	// Token: 0x040005E7 RID: 1511
	public Texture2D idfloor59;

	// Token: 0x040005E8 RID: 1512
	public Texture2D idfloor60;

	// Token: 0x040005E9 RID: 1513
	public Texture2D idfloor61;

	// Token: 0x040005EA RID: 1514
	public Texture2D idfloor62;

	// Token: 0x040005EB RID: 1515
	public Texture2D idfloor63;

	// Token: 0x040005EC RID: 1516
	public Texture2D idfloor64;

	// Token: 0x040005ED RID: 1517
	public Texture2D idfloor65;

	// Token: 0x040005EE RID: 1518
	public Texture2D idfloor66;

	// Token: 0x040005EF RID: 1519
	public Texture2D idfloor67;

	// Token: 0x040005F0 RID: 1520
	public Texture2D idfloor68;

	// Token: 0x040005F1 RID: 1521
	public Texture2D idfloor69;

	// Token: 0x040005F2 RID: 1522
	public Texture2D idfloor70;

	// Token: 0x040005F3 RID: 1523
	public Texture2D idfloor71;

	// Token: 0x040005F4 RID: 1524
	public Texture2D idfloor72;

	// Token: 0x040005F5 RID: 1525
	public Texture2D idfloor73;

	// Token: 0x040005F6 RID: 1526
	public Texture2D idfloor74;

	// Token: 0x040005F7 RID: 1527
	public Texture2D idfloor75;

	// Token: 0x040005F8 RID: 1528
	public Texture2D idfloor76;

	// Token: 0x040005F9 RID: 1529
	public Texture2D idfloor77;

	// Token: 0x040005FA RID: 1530
	public Texture2D idfloor78;

	// Token: 0x040005FB RID: 1531
	public Texture2D idfloor79;

	// Token: 0x040005FC RID: 1532
	public Texture2D idfloor80;

	// Token: 0x040005FD RID: 1533
	public Texture2D idfloor81;

	// Token: 0x040005FE RID: 1534
	public Texture2D idfloor82;

	// Token: 0x040005FF RID: 1535
	public Texture2D idfloor83;

	// Token: 0x04000600 RID: 1536
	public Texture2D idfloor84;

	// Token: 0x04000601 RID: 1537
	public Texture2D dfloor;

	// Token: 0x04000602 RID: 1538
	public Texture2D dcelling;

	// Token: 0x04000603 RID: 1539
	public Texture2D dwall;

	// Token: 0x04000604 RID: 1540
	public Texture2D ddoorwall;

	// Token: 0x04000605 RID: 1541
	public Texture2D dcorridor;

	// Token: 0x04000606 RID: 1542
	public Texture2D dcornercorridor;

	// Token: 0x04000607 RID: 1543
	public Texture2D dendcorridor;

	// Token: 0x04000608 RID: 1544
	public Texture2D dcrosscorridor;

	// Token: 0x04000609 RID: 1545
	public Texture2D ddoorcorridor;

	// Token: 0x0400060A RID: 1546
	public Texture2D dcolumn;

	// Token: 0x0400060B RID: 1547
	public Texture2D dscorridor;

	// Token: 0x0400060C RID: 1548
	public Texture2D dsxcorridor;

	// Token: 0x0400060D RID: 1549
	public Texture2D dstairs;

	// Token: 0x0400060E RID: 1550
	public Texture2D window1;

	// Token: 0x0400060F RID: 1551
	public Texture2D window2;

	// Token: 0x04000610 RID: 1552
	public Texture2D window3;

	// Token: 0x04000611 RID: 1553
	public Texture2D door1;

	// Token: 0x04000612 RID: 1554
	public Texture2D door2;

	// Token: 0x04000613 RID: 1555
	public Texture2D door3;

	// Token: 0x04000614 RID: 1556
	public Texture2D door4;

	// Token: 0x04000615 RID: 1557
	public Texture2D door5;

	// Token: 0x04000616 RID: 1558
	public Texture2D door6;

	// Token: 0x04000617 RID: 1559
	public Texture2D door7;

	// Token: 0x04000618 RID: 1560
	public Texture2D door8;

	// Token: 0x04000619 RID: 1561
	public Texture2D door9;

	// Token: 0x0400061A RID: 1562
	public Transform type1;

	// Token: 0x0400061B RID: 1563
	public Transform type2;

	// Token: 0x0400061C RID: 1564
	public Transform type3;

	// Token: 0x0400061D RID: 1565
	public Transform type4;

	// Token: 0x0400061E RID: 1566
	public Transform type5;

	// Token: 0x0400061F RID: 1567
	public Texture2D grassland1;

	// Token: 0x04000620 RID: 1568
	public Texture2D grassland2;

	// Token: 0x04000621 RID: 1569
	public Texture2D grassland3;

	// Token: 0x04000622 RID: 1570
	public Texture2D snowland1;

	// Token: 0x04000623 RID: 1571
	public Texture2D snowland2;

	// Token: 0x04000624 RID: 1572
	public Texture2D snowland3;

	// Token: 0x04000625 RID: 1573
	public Texture2D canyonland1;

	// Token: 0x04000626 RID: 1574
	public Texture2D canyonland2;

	// Token: 0x04000627 RID: 1575
	public Texture2D canyonland3;

	// Token: 0x04000628 RID: 1576
	public Texture2D water;

	// Token: 0x04000629 RID: 1577
	public Texture2D cbeamdoorway;

	// Token: 0x0400062A RID: 1578
	public Texture2D cbridge1;

	// Token: 0x0400062B RID: 1579
	public Texture2D cbridge2;

	// Token: 0x0400062C RID: 1580
	public Texture2D cbridge3;

	// Token: 0x0400062D RID: 1581
	public Texture2D cbridgecorner;

	// Token: 0x0400062E RID: 1582
	public Texture2D cbridgelong;

	// Token: 0x0400062F RID: 1583
	public Texture2D cbridgepart;

	// Token: 0x04000630 RID: 1584
	public Texture2D cbridgepost;

	// Token: 0x04000631 RID: 1585
	public Texture2D cbridgerope1;

	// Token: 0x04000632 RID: 1586
	public Texture2D cbridgerope2;

	// Token: 0x04000633 RID: 1587
	public Texture2D ccollapse1;

	// Token: 0x04000634 RID: 1588
	public Texture2D ccollapse2;

	// Token: 0x04000635 RID: 1589
	public Texture2D ccorridordownsmall;

	// Token: 0x04000636 RID: 1590
	public Texture2D ccorridorsplit;

	// Token: 0x04000637 RID: 1591
	public Texture2D ccorridorstraight;

	// Token: 0x04000638 RID: 1592
	public Texture2D ccorridorstraightdown;

	// Token: 0x04000639 RID: 1593
	public Texture2D ccorridorstraightup;

	// Token: 0x0400063A RID: 1594
	public Texture2D ccorridorstraightwide;

	// Token: 0x0400063B RID: 1595
	public Texture2D ccorridorupsmall;

	// Token: 0x0400063C RID: 1596
	public Texture2D cdoor;

	// Token: 0x0400063D RID: 1597
	public Texture2D cledge;

	// Token: 0x0400063E RID: 1598
	public Texture2D cledgebeam;

	// Token: 0x0400063F RID: 1599
	public Texture2D cledgesinglebeam;

	// Token: 0x04000640 RID: 1600
	public Texture2D croomend;

	// Token: 0x04000641 RID: 1601
	public Texture2D croomopen;

	// Token: 0x04000642 RID: 1602
	public Texture2D croompillar;

	// Token: 0x04000643 RID: 1603
	public Texture2D croomplatform;

	// Token: 0x04000644 RID: 1604
	public Texture2D cropeladder1;

	// Token: 0x04000645 RID: 1605
	public Texture2D cropeladder2;

	// Token: 0x04000646 RID: 1606
	public Texture2D ccorridorleft;

	// Token: 0x04000647 RID: 1607
	public Texture2D ccorridorright;

	// Token: 0x04000648 RID: 1608
	public Texture2D cwall1;

	// Token: 0x04000649 RID: 1609
	public Texture2D cwall2;

	// Token: 0x0400064A RID: 1610
	public Texture2D cwall3;

	// Token: 0x0400064B RID: 1611
	public Texture2D cwall4;

	// Token: 0x0400064C RID: 1612
	public Texture2D cwall5;

	// Token: 0x0400064D RID: 1613
	public Texture2D sbarrel;

	// Token: 0x0400064E RID: 1614
	public Texture2D sbridgedown;

	// Token: 0x0400064F RID: 1615
	public Texture2D sbridgestraight;

	// Token: 0x04000650 RID: 1616
	public Texture2D sbridgeup;

	// Token: 0x04000651 RID: 1617
	public Texture2D shanger;

	// Token: 0x04000652 RID: 1618
	public Texture2D shouse1;

	// Token: 0x04000653 RID: 1619
	public Texture2D shouse2;

	// Token: 0x04000654 RID: 1620
	public Texture2D spipes;

	// Token: 0x04000655 RID: 1621
	public Texture2D splatform;

	// Token: 0x04000656 RID: 1622
	public Texture2D splatformy;

	// Token: 0x04000657 RID: 1623
	public Texture2D sroadarc;

	// Token: 0x04000658 RID: 1624
	public Texture2D sroadpads;

	// Token: 0x04000659 RID: 1625
	public Texture2D blood1;

	// Token: 0x0400065A RID: 1626
	public Texture2D blood2;

	// Token: 0x0400065B RID: 1627
	public Texture2D blood3;

	// Token: 0x0400065C RID: 1628
	public Texture2D blood4;

	// Token: 0x0400065D RID: 1629
	public Texture2D blood5;

	// Token: 0x0400065E RID: 1630
	public Texture2D blood6;

	// Token: 0x0400065F RID: 1631
	public Texture2D blood7;

	// Token: 0x04000660 RID: 1632
	public Texture2D blood8;

	// Token: 0x04000661 RID: 1633
	public Texture2D blood9;

	// Token: 0x04000662 RID: 1634
	public Texture2D blood10;

	// Token: 0x04000663 RID: 1635
	public Texture2D blood11;

	// Token: 0x04000664 RID: 1636
	public Texture2D blood12;

	// Token: 0x04000665 RID: 1637
	public Texture2D blood13;

	// Token: 0x04000666 RID: 1638
	public Texture2D blood14;

	// Token: 0x04000667 RID: 1639
	public Texture2D blood15;

	// Token: 0x04000668 RID: 1640
	public Texture2D blood16;

	// Token: 0x04000669 RID: 1641
	public Texture2D blood17;

	// Token: 0x0400066A RID: 1642
	public Texture2D blood18;
}
