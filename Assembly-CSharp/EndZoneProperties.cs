using System;
using UnityEngine;

// Token: 0x020000CE RID: 206
public class EndZoneProperties : MonoBehaviour
{
	// Token: 0x060003DE RID: 990 RVA: 0x00023769 File Offset: 0x00021B69
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x060003DF RID: 991 RVA: 0x00023772 File Offset: 0x00021B72
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x00023789 File Offset: 0x00021B89
	private void Update()
	{
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x0002378B File Offset: 0x00021B8B
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect(5f, 30f, 260f, 160f), new GUI.WindowFunction(this.EndZoneWindow), "End Zone Editor");
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x000237CC File Offset: 0x00021BCC
	private void EndZoneWindow(int windowID)
	{
		this.loadstory = GUI.Toggle(new Rect(20f, 45f, 100f, 20f), this.loadstory, "Load New Story");
		this.togglevisible = GUI.Toggle(new Rect(20f, 125f, 100f, 20f), this.togglevisible, "Enabled At Start");
		if (this.loadstory)
		{
			GUI.Label(new Rect(20f, 70f, 100f, 22f), "Story Name:");
			this.storyname = GUI.TextField(new Rect(20f, 90f, 100f, 22f), this.storyname);
		}
		if (GUI.Button(new Rect(145f, 120f, 100f, 20f), "Save Settings"))
		{
			base.enabled = false;
		}
		GUI.Label(new Rect(170f, 45f, 70f, 22f), "Object ID");
		this.triggerid = GUI.TextField(new Rect(170f, 65f, 70f, 22f), this.triggerid);
	}

	// Token: 0x04000462 RID: 1122
	public GUISkin skin;

	// Token: 0x04000463 RID: 1123
	public bool togglevisible = true;

	// Token: 0x04000464 RID: 1124
	public bool loadstory;

	// Token: 0x04000465 RID: 1125
	public string storyname;

	// Token: 0x04000466 RID: 1126
	public string triggerid;
}
