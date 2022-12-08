using System;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class KeyProperties : MonoBehaviour
{
	// Token: 0x060003F1 RID: 1009 RVA: 0x000245ED File Offset: 0x000229ED
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x00024604 File Offset: 0x00022A04
	private void Update()
	{
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x00024608 File Offset: 0x00022A08
	private void WallWindow(int windowID)
	{
		GUI.Label(new Rect(30f, 45f, 180f, 200f), "Key ID");
		this.keyname = GUI.TextField(new Rect(30f, 65f, 100f, 20f), this.keyname);
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x00024664 File Offset: 0x00022A64
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.WallWindow), "Editor");
	}

	// Token: 0x04000475 RID: 1141
	public GUISkin skin;

	// Token: 0x04000476 RID: 1142
	public string keyname = "1";
}
