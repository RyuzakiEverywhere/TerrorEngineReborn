using System;
using UnityEngine;

// Token: 0x020000D8 RID: 216
public class NPCObjProperties : MonoBehaviour
{
	// Token: 0x0600040C RID: 1036 RVA: 0x00024DFC File Offset: 0x000231FC
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x00024E05 File Offset: 0x00023205
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x00024E1C File Offset: 0x0002321C
	private void Update()
	{
		if (!base.gameObject.GetComponent<PositionAndScale>().enabled)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x00024E3C File Offset: 0x0002323C
	private void WallWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 350f));
		this.togglevisible = GUI.Toggle(new Rect(40f, 20f, 100f, 20f), this.togglevisible, "Enabled At Start");
		if (!this.togglevisible)
		{
			GUI.Label(new Rect(40f, 40f, 160f, 20f), "Activate ID");
			this.triggerid = GUI.TextField(new Rect(40f, 60f, 50f, 20f), this.triggerid);
		}
		GUI.EndScrollView();
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x00024F20 File Offset: 0x00023320
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.WallWindow), "Editor");
	}

	// Token: 0x04000489 RID: 1161
	public GUISkin skin;

	// Token: 0x0400048A RID: 1162
	public Vector2 scrollPosition;

	// Token: 0x0400048B RID: 1163
	public bool togglevisible = true;

	// Token: 0x0400048C RID: 1164
	public string triggerid;

	// Token: 0x0400048D RID: 1165
	public bool test;
}
