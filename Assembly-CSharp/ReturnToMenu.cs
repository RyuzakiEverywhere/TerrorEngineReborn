using System;
using UnityEngine;

// Token: 0x02000168 RID: 360
public class ReturnToMenu : MonoBehaviour
{
	// Token: 0x0600088D RID: 2189 RVA: 0x0004FC8D File Offset: 0x0004E08D
	private void Start()
	{
		CryptoPlayerPrefs.SetInt("Mode", 1);
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x0004FC9A File Offset: 0x0004E09A
	private void Update()
	{
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x0004FC9C File Offset: 0x0004E09C
	private void OnGUI()
	{
		GUI.skin = this.guiSkin;
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), (float)(Screen.height - 100), 200f, 30f), "Return To Main Menu"))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	// Token: 0x04000AA3 RID: 2723
	public GUISkin guiSkin;
}
