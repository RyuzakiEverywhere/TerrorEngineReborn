using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000163 RID: 355
public class PreviewMenu : MonoBehaviour
{
	// Token: 0x06000874 RID: 2164 RVA: 0x0004E258 File Offset: 0x0004C658
	private void Start()
	{
	}

	// Token: 0x06000875 RID: 2165 RVA: 0x0004E25A File Offset: 0x0004C65A
	public void ShowNow()
	{
		base.StartCoroutine(this.Begin());
	}

	// Token: 0x06000876 RID: 2166 RVA: 0x0004E26C File Offset: 0x0004C66C
	private IEnumerator Begin()
	{
		this.allimagesloaded = false;
		WWW www = new WWW("file:///" + this.sb.gametitle);
		yield return www;
		this.title = www.texture;
		if (this.sb.allowmultiplayer)
		{
			WWW www2 = new WWW("file:///" + this.sb.multiplayerbutton);
			yield return www2;
			this.mpbutton = www2.texture;
			this.mppos = 31;
		}
		else
		{
			this.mppos = 0;
		}
		WWW www3 = new WWW("file:///" + this.sb.singleplayerbutton);
		yield return www3;
		this.playbutton = www3.texture;
		WWW www4 = new WWW("file:///" + this.sb.howtoplaybutton);
		yield return www4;
		this.howtoplaybutton = www4.texture;
		WWW www5 = new WWW("file:///" + this.sb.settingsbutton);
		yield return www5;
		this.settingsbutton = www5.texture;
		WWW www6 = new WWW("file:///" + this.sb.creditsbutton);
		yield return www6;
		this.creditsbutton = www6.texture;
		WWW www7 = new WWW("file:///" + this.sb.quitbutton);
		yield return www7;
		this.quitbutton = www7.texture;
		if (this.sb.background.Contains(".png"))
		{
			WWW www8 = new WWW("file:///" + this.sb.background);
			yield return www8;
			this.background = www8.texture;
		}
		else
		{
			WWW www9 = new WWW("file:///" + this.sb.background);
			yield return www9;
			this.backgroundmov = www9.GetMovieTexture();
			this.backgroundmov.Play();
			this.backgroundmov.loop = true;
		}
		WWW www10 = new WWW("file:///" + this.sb.credits);
		yield return www10;
		this.credits = www10.texture;
		WWW www11 = new WWW("file:///" + this.sb.howtoplay);
		yield return www11;
		this.howtoplay = www11.texture;
		if (this.sb.menumusic != string.Empty)
		{
			WWW www12 = new WWW("file:///" + this.sb.menumusic);
			yield return www12;
			this.menumusic.GetComponent<AudioSource>().clip = www12.GetAudioClip();
			this.menumusic.GetComponent<AudioSource>().Play();
		}
		this.showmenu = true;
		this.allimagesloaded = true;
		Resources.UnloadUnusedAssets();
		yield break;
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x0004E288 File Offset: 0x0004C688
	private void OnGUI()
	{
		if (this.allimagesloaded)
		{
			GUI.skin = this.MenuSkin;
			if (this.sb.background.Contains(".png"))
			{
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.background);
			}
			else
			{
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.backgroundmov);
			}
			if (this.showmenu)
			{
				GUI.DrawTexture(new Rect(20f, (float)(Screen.height / 2 - 61), 175f, 30f), this.playbutton);
				if (GUI.Button(new Rect(20f, (float)(Screen.height / 2 - 61), 175f, 30f), string.Empty))
				{
				}
				if (this.sb.allowmultiplayer)
				{
					GUI.DrawTexture(new Rect(20f, (float)(Screen.height / 2 - 30), 175f, 30f), this.mpbutton);
					if (GUI.Button(new Rect(20f, (float)(Screen.height / 2 - 30), 175f, 30f), string.Empty))
					{
					}
				}
				GUI.DrawTexture(new Rect(20f, (float)(Screen.height / 2 - 30 + this.mppos), 175f, 30f), this.howtoplaybutton);
				if (GUI.Button(new Rect(20f, (float)(Screen.height / 2 - 30 + this.mppos), 175f, 30f), string.Empty))
				{
					this.showmenu = false;
					this.showhowtoplay = true;
				}
				GUI.DrawTexture(new Rect(20f, (float)(Screen.height / 2 + 1 + this.mppos), 175f, 30f), this.settingsbutton);
				if (GUI.Button(new Rect(20f, (float)(Screen.height / 2 + 1 + this.mppos), 175f, 30f), string.Empty))
				{
				}
				GUI.DrawTexture(new Rect(20f, (float)(Screen.height / 2 + 32 + this.mppos), 175f, 30f), this.creditsbutton);
				if (GUI.Button(new Rect(20f, (float)(Screen.height / 2 + 32 + this.mppos), 175f, 30f), string.Empty))
				{
					this.showmenu = false;
					this.showcredits = true;
				}
				GUI.DrawTexture(new Rect(20f, (float)(Screen.height / 2 + 63 + this.mppos), 175f, 30f), this.quitbutton);
				if (GUI.Button(new Rect(20f, (float)(Screen.height / 2 + 63 + this.mppos), 175f, 30f), string.Empty))
				{
					this.sb.showmenueditor = true;
					this.allimagesloaded = false;
					UnityEngine.Object.Destroy(this.title);
					UnityEngine.Object.Destroy(this.background);
					UnityEngine.Object.Destroy(this.backgroundmov);
					UnityEngine.Object.Destroy(this.credits);
					UnityEngine.Object.Destroy(this.howtoplay);
					UnityEngine.Object.Destroy(this.playbutton);
					UnityEngine.Object.Destroy(this.mpbutton);
					UnityEngine.Object.Destroy(this.howtoplaybutton);
					UnityEngine.Object.Destroy(this.settingsbutton);
					UnityEngine.Object.Destroy(this.creditsbutton);
					UnityEngine.Object.Destroy(this.quitbutton);
					if (this.sb.menumusic != string.Empty)
					{
						this.menumusic.GetComponent<AudioSource>().Stop();
						UnityEngine.Object.Destroy(this.menumusic.GetComponent<AudioSource>().clip);
					}
				}
			}
			if (this.showcredits)
			{
				GUI.skin = this.SettingsSkin;
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.credits);
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height - 50), 75f, 25f), "Back"))
				{
					this.showcredits = false;
					this.showmenu = true;
				}
			}
			if (this.showhowtoplay)
			{
				GUI.skin = this.SettingsSkin;
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.howtoplay);
				if (GUI.Button(new Rect((float)(Screen.width - 100), (float)(Screen.height - 50), 75f, 25f), "Back"))
				{
					this.showhowtoplay = false;
					this.showmenu = true;
				}
			}
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 200), 20f, 400f, 100f), this.title);
		}
	}

	// Token: 0x04000A83 RID: 2691
	public Standalone_Builder sb;

	// Token: 0x04000A84 RID: 2692
	public bool allimagesloaded;

	// Token: 0x04000A85 RID: 2693
	public bool showmenu;

	// Token: 0x04000A86 RID: 2694
	public Texture2D background;

	// Token: 0x04000A87 RID: 2695
	public MovieTexture backgroundmov;

	// Token: 0x04000A88 RID: 2696
	public Texture2D title;

	// Token: 0x04000A89 RID: 2697
	public Texture2D credits;

	// Token: 0x04000A8A RID: 2698
	public Texture2D howtoplay;

	// Token: 0x04000A8B RID: 2699
	public Texture2D playbutton;

	// Token: 0x04000A8C RID: 2700
	public Texture2D mpbutton;

	// Token: 0x04000A8D RID: 2701
	public Texture2D howtoplaybutton;

	// Token: 0x04000A8E RID: 2702
	public Texture2D settingsbutton;

	// Token: 0x04000A8F RID: 2703
	public Texture2D creditsbutton;

	// Token: 0x04000A90 RID: 2704
	public Texture2D quitbutton;

	// Token: 0x04000A91 RID: 2705
	public GUISkin MenuSkin;

	// Token: 0x04000A92 RID: 2706
	public GUISkin SettingsSkin;

	// Token: 0x04000A93 RID: 2707
	public bool showcredits;

	// Token: 0x04000A94 RID: 2708
	public bool showhowtoplay;

	// Token: 0x04000A95 RID: 2709
	public GameObject menumusic;

	// Token: 0x04000A96 RID: 2710
	public int mppos;
}
