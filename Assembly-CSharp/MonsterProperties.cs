using System;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class MonsterProperties : MonoBehaviour
{
	// Token: 0x06000403 RID: 1027 RVA: 0x00024B82 File Offset: 0x00022F82
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x00024B8B File Offset: 0x00022F8B
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x00024BA2 File Offset: 0x00022FA2
	private void Update()
	{
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x00024BA4 File Offset: 0x00022FA4
	private void TriggerWindow(int windowID)
	{
		GUI.Box(new Rect(20f, 45f, 130f, 260f), "Player Traits:");
		GUI.Label(new Rect(30f, 80f, 100f, 22f), "Walk Speed:");
		this.walkspeed = GUI.TextField(new Rect(30f, 100f, 40f, 22f), this.walkspeed);
		GUI.Label(new Rect(30f, 120f, 100f, 22f), "Run Speed:");
		this.runspeed = GUI.TextField(new Rect(30f, 140f, 40f, 22f), this.runspeed);
		GUI.Label(new Rect(30f, 160f, 100f, 22f), "Jump Height:");
		this.jumpheight = GUI.TextField(new Rect(30f, 180f, 40f, 22f), this.jumpheight);
		GUI.Label(new Rect(30f, 200f, 100f, 22f), "Damage:");
		this.damage = GUI.TextField(new Rect(30f, 220f, 40f, 22f), this.damage);
		GUI.Label(new Rect(30f, 250f, 100f, 22f), "HUD Graphic:");
		this.hud = GUI.TextField(new Rect(30f, 270f, 100f, 22f), this.hud);
		if (GUI.Button(new Rect(55f, 312f, 100f, 22f), "Save Settings"))
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x00024D84 File Offset: 0x00023184
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(10, new Rect(5f, 30f, 175f, 350f), new GUI.WindowFunction(this.TriggerWindow), "Player Monster Editor");
	}

	// Token: 0x04000483 RID: 1155
	public GUISkin skin;

	// Token: 0x04000484 RID: 1156
	public string walkspeed = "3";

	// Token: 0x04000485 RID: 1157
	public string runspeed = "7";

	// Token: 0x04000486 RID: 1158
	public string jumpheight = "9";

	// Token: 0x04000487 RID: 1159
	public string damage = "50";

	// Token: 0x04000488 RID: 1160
	public string hud = "Default.png";
}
