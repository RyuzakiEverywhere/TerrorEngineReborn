using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
public class GeneratorSelector : MonoBehaviour
{
	// Token: 0x06000339 RID: 825 RVA: 0x0001F338 File Offset: 0x0001D738
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0001F34F File Offset: 0x0001D74F
	private void Update()
	{
	}

	// Token: 0x0600033B RID: 827 RVA: 0x0001F354 File Offset: 0x0001D754
	private void SettingsWindow(int windowID)
	{
		if (GUI.Button(new Rect(15f, 85f, 175f, 20f), "Dungeon Generator"))
		{
			base.enabled = false;
		}
		if (GUI.Button(new Rect(130f, 165f, 60f, 20f), "Back"))
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600033C RID: 828 RVA: 0x0001F3BF File Offset: 0x0001D7BF
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(12, new Rect(5f, 30f, 205f, 200f), new GUI.WindowFunction(this.SettingsWindow), "Generator Wizard");
	}

	// Token: 0x040003A2 RID: 930
	public GUISkin skin;
}
