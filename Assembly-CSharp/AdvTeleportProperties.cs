using System;
using UnityEngine;

// Token: 0x020000C4 RID: 196
public class AdvTeleportProperties : MonoBehaviour
{
	// Token: 0x060003AA RID: 938 RVA: 0x00021F28 File Offset: 0x00020328
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x060003AB RID: 939 RVA: 0x00021F31 File Offset: 0x00020331
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00021F48 File Offset: 0x00020348
	private void Update()
	{
	}

	// Token: 0x060003AD RID: 941 RVA: 0x00021F4C File Offset: 0x0002034C
	private void TeleWindow(int windowID)
	{
		GUI.Label(new Rect(335f, 45f, 70f, 22f), "Object ID");
		this.triggerid = GUI.TextField(new Rect(335f, 65f, 70f, 22f), this.triggerid);
		GUI.Label(new Rect(20f, 45f, 70f, 22f), "Teleport:");
		this.player = GUI.Toggle(new Rect(20f, 75f, 100f, 20f), this.player, "Single Player");
		this.allplayers = GUI.Toggle(new Rect(20f, 95f, 100f, 20f), this.allplayers, "All Players");
		this.npc = GUI.Toggle(new Rect(20f, 115f, 100f, 20f), this.npc, "NPC");
		this.objects = GUI.Toggle(new Rect(20f, 135f, 100f, 20f), this.objects, "Objects");
		GUI.Label(new Rect(150f, 45f, 70f, 22f), "Position:");
		this.x = GUI.Toggle(new Rect(150f, 75f, 20f, 20f), this.x, "X");
		this.y = GUI.Toggle(new Rect(150f, 95f, 20f, 20f), this.y, "Y");
		this.z = GUI.Toggle(new Rect(150f, 115f, 20f, 20f), this.z, "Z");
		if (this.x)
		{
			this.xpos = GUI.TextField(new Rect(175f, 70f, 50f, 22f), this.xpos);
		}
		if (this.y)
		{
			this.ypos = GUI.TextField(new Rect(175f, 90f, 50f, 22f), this.ypos);
		}
		if (this.z)
		{
			this.zpos = GUI.TextField(new Rect(175f, 110f, 50f, 22f), this.zpos);
		}
		if (GUI.Button(new Rect(320f, 160f, 100f, 20f), "Save Settings"))
		{
			base.enabled = false;
		}
		this.togglevisible = GUI.Toggle(new Rect(205f, 165f, 130f, 20f), this.togglevisible, "Enabled At Start");
	}

	// Token: 0x060003AE RID: 942 RVA: 0x00022232 File Offset: 0x00020632
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect(5f, 30f, 440f, 200f), new GUI.WindowFunction(this.TeleWindow), "Advanced Teleport Editor");
	}

	// Token: 0x04000423 RID: 1059
	public GUISkin skin;

	// Token: 0x04000424 RID: 1060
	public bool togglevisible = true;

	// Token: 0x04000425 RID: 1061
	public string triggerid = "Teleport1";

	// Token: 0x04000426 RID: 1062
	public bool player;

	// Token: 0x04000427 RID: 1063
	public bool allplayers;

	// Token: 0x04000428 RID: 1064
	public bool npc;

	// Token: 0x04000429 RID: 1065
	public bool objects;

	// Token: 0x0400042A RID: 1066
	public bool x;

	// Token: 0x0400042B RID: 1067
	public bool y;

	// Token: 0x0400042C RID: 1068
	public bool z;

	// Token: 0x0400042D RID: 1069
	public string xpos = "0";

	// Token: 0x0400042E RID: 1070
	public string ypos = "0";

	// Token: 0x0400042F RID: 1071
	public string zpos = "0";
}
