using System;
using UnityEngine;

// Token: 0x020000DE RID: 222
public class PlayerPrefsProperties : MonoBehaviour
{
	// Token: 0x0600042E RID: 1070 RVA: 0x00026930 File Offset: 0x00024D30
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x00026939 File Offset: 0x00024D39
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x00026950 File Offset: 0x00024D50
	private void Update()
	{
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x00026952 File Offset: 0x00024D52
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect(5f, 30f, 270f, 220f), new GUI.WindowFunction(this.PrefsWindow), "Player Prefs Editor");
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x00026990 File Offset: 0x00024D90
	private void PrefsWindow(int windowID)
	{
		GUI.Label(new Rect(20f, 45f, 100f, 22f), "Walk Speed:");
		this.walkspeed = GUI.TextField(new Rect(105f, 45f, 40f, 22f), this.walkspeed);
		GUI.Label(new Rect(20f, 70f, 100f, 22f), "Run Speed:");
		this.runspeed = GUI.TextField(new Rect(105f, 70f, 40f, 22f), this.runspeed);
		GUI.Label(new Rect(20f, 95f, 100f, 22f), "Jump Height:");
		this.jumpheight = GUI.TextField(new Rect(105f, 95f, 40f, 22f), this.jumpheight);
		this.canpickup = GUI.Toggle(new Rect(20f, 120f, 100f, 20f), this.canpickup, "Can Pickup Objects");
		this.cancrouch = GUI.Toggle(new Rect(20f, 140f, 100f, 20f), this.cancrouch, "Can Crawl");
		this.hascollider = GUI.Toggle(new Rect(20f, 160f, 100f, 20f), this.hascollider, "Can Move");
		this.togglevisible = GUI.Toggle(new Rect(20f, 180f, 100f, 20f), this.togglevisible, "Enabled At Start");
		GUI.Label(new Rect(180f, 45f, 70f, 22f), "Object ID");
		this.triggerid = GUI.TextField(new Rect(180f, 65f, 70f, 22f), this.triggerid);
		if (GUI.Button(new Rect(155f, 180f, 100f, 20f), "Save Settings"))
		{
			base.enabled = false;
		}
	}

	// Token: 0x040004D3 RID: 1235
	public GUISkin skin;

	// Token: 0x040004D4 RID: 1236
	public bool togglevisible = true;

	// Token: 0x040004D5 RID: 1237
	public string walkspeed = "4";

	// Token: 0x040004D6 RID: 1238
	public string runspeed = "8";

	// Token: 0x040004D7 RID: 1239
	public string jumpheight = "9";

	// Token: 0x040004D8 RID: 1240
	public bool canpickup = true;

	// Token: 0x040004D9 RID: 1241
	public bool cancrouch = true;

	// Token: 0x040004DA RID: 1242
	public bool hascollider = true;

	// Token: 0x040004DB RID: 1243
	public string triggerid;
}
