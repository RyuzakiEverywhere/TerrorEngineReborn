using System;
using UnityEngine;

// Token: 0x020000D4 RID: 212
public class ModProperties : MonoBehaviour
{
	// Token: 0x060003F9 RID: 1017 RVA: 0x00024873 File Offset: 0x00022C73
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0002487C File Offset: 0x00022C7C
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x00024893 File Offset: 0x00022C93
	private void Update()
	{
		if (!base.gameObject.GetComponent<PositionAndScale>().enabled)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x000248B4 File Offset: 0x00022CB4
	private void WallWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 350f));
		this.togglevisible = GUI.Toggle(new Rect(40f, 60f, 100f, 20f), this.togglevisible, "Enabled At Start");
		if (base.gameObject.GetComponent<PreviewMod>() == null)
		{
			if (GUI.Button(new Rect(40f, 80f, 100f, 20f), "Preview"))
			{
				base.gameObject.AddComponent<PreviewMod>();
			}
		}
		else if (base.gameObject.GetComponent<PreviewMod>().hasmod && GUI.Button(new Rect(40f, 80f, 100f, 20f), "Remove"))
		{
			base.gameObject.GetComponent<PreviewMod>().des = true;
		}
		GUI.Label(new Rect(40f, 20f, 100f, 20f), "Mod Name:");
		this.modname = GUI.TextField(new Rect(40f, 40f, 140f, 22f), this.modname);
		GUI.EndScrollView();
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x00024A2C File Offset: 0x00022E2C
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.WallWindow), "Editor");
	}

	// Token: 0x0400047B RID: 1147
	public string modname;

	// Token: 0x0400047C RID: 1148
	public GUISkin skin;

	// Token: 0x0400047D RID: 1149
	public Vector2 scrollPosition;

	// Token: 0x0400047E RID: 1150
	public bool togglevisible = true;
}
