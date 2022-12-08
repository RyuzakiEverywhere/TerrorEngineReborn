using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000021 RID: 33
public class GameOver : MonoBehaviour
{
	// Token: 0x06000088 RID: 136 RVA: 0x00009890 File Offset: 0x00007C90
	private IEnumerator Start()
	{
		Screen.lockCursor = false;
		Cursor.visible = true;
		if (!this.win)
		{
			this.url = CryptoPlayerPrefs.GetString("gameover", string.Empty);
		}
		else
		{
			this.url = CryptoPlayerPrefs.GetString("win", string.Empty);
		}
		if (!(this.url == string.Empty) && this.url != null && !(this.url == " "))
		{
			WWW www = new WWW("file:///" + Application.dataPath + "/Images/" + this.url);
			yield return www;
			this.tex = www.texture;
		}
		yield break;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x000098AC File Offset: 0x00007CAC
	private void OnGUI()
	{
		GUI.skin = this.guiskin1;
		GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.tex);
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height / 2 + 100), 100f, 21f), "Main Menu"))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	// Token: 0x040000C1 RID: 193
	public Texture2D tex;

	// Token: 0x040000C2 RID: 194
	public GUISkin guiskin1;

	// Token: 0x040000C3 RID: 195
	public string url = "http://images.earthcam.comec_metrosourcams/fridays.jpg";

	// Token: 0x040000C4 RID: 196
	public bool win;
}
