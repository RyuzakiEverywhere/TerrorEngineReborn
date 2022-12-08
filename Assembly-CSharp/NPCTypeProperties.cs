using System;
using UnityEngine;

// Token: 0x020000DA RID: 218
public class NPCTypeProperties : MonoBehaviour
{
	// Token: 0x06000418 RID: 1048 RVA: 0x00025C98 File Offset: 0x00024098
	private void Awake()
	{
		this.sc = base.gameObject.GetComponent<SceneryMapMaker>();
		this.type1 = GameObject.Find("NPC_Type1").transform;
		this.type2 = GameObject.Find("NPC_Type2").transform;
		this.type3 = GameObject.Find("NPC_Type3").transform;
		this.type4 = GameObject.Find("NPC_Type4").transform;
		this.type5 = GameObject.Find("NPC_Type5").transform;
		this.type6 = GameObject.Find("NPC_Type6").transform;
		this.type7 = GameObject.Find("NPC_Type7").transform;
		this.type8 = GameObject.Find("NPC_Type8").transform;
		this.type9 = GameObject.Find("NPC_Type9").transform;
		this.type10 = GameObject.Find("NPC_Type10").transform;
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x00025D88 File Offset: 0x00024188
	private void Start()
	{
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x00025D8A File Offset: 0x0002418A
	private void Update()
	{
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x00025D8C File Offset: 0x0002418C
	private void DoWindow0(int windowID)
	{
		if (GUI.Button(new Rect(20f, 35f, 100f, 20f), "NPC Type 1"))
		{
			this.sc.currentpath = "Npc/Npc_one";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 35f, 45f, 20f), "Edit"))
		{
			this.type1.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 55f, 100f, 20f), "NPC Type 2"))
		{
			this.sc.currentpath = "Npc/Npc_two";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 55f, 45f, 20f), "Edit"))
		{
			this.type2.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 75f, 100f, 20f), "NPC Type 3"))
		{
			this.sc.currentpath = "Npc/Npc_three";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 75f, 45f, 20f), "Edit"))
		{
			this.type3.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 95f, 100f, 20f), "NPC Type 4"))
		{
			this.sc.currentpath = "Npc/Npc_four";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 95f, 45f, 20f), "Edit"))
		{
			this.type4.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 115f, 100f, 20f), "NPC Type 5"))
		{
			this.sc.currentpath = "Npc/Npc_five";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 115f, 45f, 20f), "Edit"))
		{
			this.type5.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 135f, 100f, 20f), "NPC Type 6"))
		{
			this.sc.currentpath = "Npc/Npc_six";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 135f, 45f, 20f), "Edit"))
		{
			this.type6.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 155f, 100f, 20f), "NPC Type 7"))
		{
			this.sc.currentpath = "Npc/Npc_seven";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 155f, 45f, 20f), "Edit"))
		{
			this.type7.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 175f, 100f, 20f), "NPC Type 8"))
		{
			this.sc.currentpath = "Npc/Npc_eight";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 175f, 45f, 20f), "Edit"))
		{
			this.type8.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 195f, 100f, 20f), "NPC Type 9"))
		{
			this.sc.currentpath = "Npc/Npc_nine";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 195f, 45f, 20f), "Edit"))
		{
			this.type9.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 215f, 100f, 20f), "NPC Type 10"))
		{
			this.sc.currentpath = "Npc/Npc_ten";
			base.enabled = false;
		}
		if (GUI.Button(new Rect(125f, 215f, 45f, 20f), "Edit"))
		{
			this.type10.gameObject.GetComponent<NPCProperties>().enabled = true;
			base.enabled = false;
		}
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x000262C1 File Offset: 0x000246C1
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(3, new Rect(5f, 40f, 200f, 260f), new GUI.WindowFunction(this.DoWindow0), "NPC Types");
	}

	// Token: 0x040004B4 RID: 1204
	public GUISkin skin;

	// Token: 0x040004B5 RID: 1205
	public SceneryMapMaker sc;

	// Token: 0x040004B6 RID: 1206
	public Transform type1;

	// Token: 0x040004B7 RID: 1207
	public Transform type2;

	// Token: 0x040004B8 RID: 1208
	public Transform type3;

	// Token: 0x040004B9 RID: 1209
	public Transform type4;

	// Token: 0x040004BA RID: 1210
	public Transform type5;

	// Token: 0x040004BB RID: 1211
	public Transform type6;

	// Token: 0x040004BC RID: 1212
	public Transform type7;

	// Token: 0x040004BD RID: 1213
	public Transform type8;

	// Token: 0x040004BE RID: 1214
	public Transform type9;

	// Token: 0x040004BF RID: 1215
	public Transform type10;
}
