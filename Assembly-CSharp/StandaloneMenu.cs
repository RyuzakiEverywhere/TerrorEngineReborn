using System;
using System.Collections;
using System.IO;
using UnityEngine;

// Token: 0x0200019F RID: 415
public class StandaloneMenu : MonoBehaviour
{
	// Token: 0x060009D6 RID: 2518 RVA: 0x00055570 File Offset: 0x00053970
	private void OnEnable()
	{
		if (this.iseditor)
		{
			this.thepath = "C:/TE_TESTS";
		}
		else
		{
			this.thepath = Application.dataPath;
		}
		if (!File.Exists(this.thepath + "/Menu/" + this.background1))
		{
			this.background1 = "background.ogv";
		}
		if (!File.Exists(this.thepath + "/Menu/" + this.menumusic1))
		{
			this.menumusic1 = "music.ogg";
		}
		string[] array = File.ReadAllLines(this.thepath + "/mainData2");
		this.firstlevel = array[0];
		if (this.firstlevel == "levelselect")
		{
			this.levelselect = true;
			this.curpic = this.naimage;
		}
		this.playermodel = array[1];
		PlayerPrefs.SetString("Character", this.playermodel);
		if (array[2] == "1")
		{
			this.allowmultiplayer = true;
			this.photonid = array[3];
			CryptoPlayerPrefs.SetString("serverid", this.photonid);
		}
		if (Screen.fullScreen)
		{
			this.fullscreen = true;
		}
		Screen.fullScreen = this.fullscreen;
		if (PlayerPrefs.GetString("CamMode") == "Analygraph")
		{
			this.Anaglyph3d = true;
		}
		if (PlayerPrefs.GetString("CamMode") == "OVR")
		{
			this.OVRMode = true;
		}
		if (Screen.fullScreen)
		{
			this.fullscreen = true;
		}
		Screen.fullScreen = this.fullscreen;
		if (PlayerPrefs.GetInt("bloom") != 2)
		{
			PlayerPrefs.SetInt("bloom", 1);
			this.showbloom = true;
		}
		if (PlayerPrefs.GetInt("motionblur") != 2)
		{
			PlayerPrefs.SetInt("motionblur", 1);
			this.motionblur = true;
		}
		if (PlayerPrefs.GetInt("hud") != 2)
		{
			PlayerPrefs.SetInt("hud", 1);
			this.showhud = true;
		}
		this.sensitivity = PlayerPrefs.GetFloat("sensitivity");
		if (false || PlayerPrefs.GetFloat("sensitivity") == 0f)
		{
			PlayerPrefs.SetFloat("sensitivity", 5f);
		}
		if (this.sensitivity == 0f)
		{
			PlayerPrefs.SetFloat("sensitivity", 5f);
		}
		this.sensitivity = PlayerPrefs.GetFloat("sensitivity");
	}

	// Token: 0x060009D7 RID: 2519 RVA: 0x000557D1 File Offset: 0x00053BD1
	private void Update()
	{
		PlayerPrefs.SetString("Character", this.playermodel);
		if (this.allowmultiplayer)
		{
			CryptoPlayerPrefs.SetString("serverid", this.photonid);
		}
		Screen.lockCursor = false;
		Cursor.visible = true;
	}

	// Token: 0x060009D8 RID: 2520 RVA: 0x0005580C File Offset: 0x00053C0C
	private IEnumerator Start()
	{
		this.allimagesloaded = false;
		WWW www = new WWW("file:///" + this.thepath + "/Menu/" + this.gametitle1);
		yield return www;
		this.title = www.texture;
		if (this.allowmultiplayer)
		{
			WWW www2 = new WWW("file:///" + this.thepath + "/Menu/" + this.multiplayerbutton1);
			yield return www2;
			this.mpbutton = www2.texture;
			this.mppos = 31;
		}
		else
		{
			this.mppos = 0;
		}
		WWW www3 = new WWW("file:///" + this.thepath + "/Menu/" + this.singleplayerbutton1);
		yield return www3;
		this.playbutton = www3.texture;
		WWW www4 = new WWW("file:///" + this.thepath + "/Menu/" + this.howtoplaybutton1);
		yield return www4;
		this.howtoplaybutton = www4.texture;
		WWW www5 = new WWW("file:///" + this.thepath + "/Menu/" + this.settingsbutton1);
		yield return www5;
		this.settingsbutton = www5.texture;
		WWW www6 = new WWW("file:///" + this.thepath + "/Menu/" + this.creditsbutton1);
		yield return www6;
		this.creditsbutton = www6.texture;
		WWW www7 = new WWW("file:///" + this.thepath + "/Menu/" + this.quitbutton1);
		yield return www7;
		this.quitbutton = www7.texture;
		WWW www8 = new WWW("file:///" + this.thepath + "/Menu/" + this.loading1);
		yield return www8;
		this.loading = www8.texture;
		if (this.background1.Contains(".png"))
		{
			WWW www9 = new WWW("file:///" + this.thepath + "/Menu/" + this.background1);
			yield return www9;
			this.background = www9.texture;
		}
		else
		{
			WWW www10 = new WWW("file:///" + this.thepath + "/Menu/" + this.background1);
			yield return www10;
			this.backgroundmov = www10.GetMovieTexture();
			this.backgroundmov.Play();
			this.backgroundmov.loop = true;
		}
		WWW www11 = new WWW("file:///" + this.thepath + "/Menu/" + this.credits1);
		yield return www11;
		this.credits = www11.texture;
		WWW www12 = new WWW("file:///" + this.thepath + "/Menu/" + this.howtoplay1);
		yield return www12;
		this.howtoplay = www12.texture;
		if (this.menumusic1 != string.Empty)
		{
			WWW www13 = new WWW("file:///" + this.thepath + "/Menu/" + this.menumusic1);
			yield return www13;
			this.menumusic.GetComponent<AudioSource>().clip = www13.GetAudioClip();
			this.menumusic.GetComponent<AudioSource>().Play();
		}
		this.showmenu = true;
		this.allimagesloaded = true;
		Resources.UnloadUnusedAssets();
		CryptoPlayerPrefs.SetString("E410675", "000");
		yield break;
	}

	// Token: 0x060009D9 RID: 2521 RVA: 0x00055828 File Offset: 0x00053C28
	private IEnumerator ChangeImage(string image)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
		if (File.Exists(directoryInfo.Parent.ToString() + "/Levels/" + image + ".png"))
		{
			WWW www21 = new WWW(string.Concat(new string[]
			{
				"file:///",
				directoryInfo.Parent.ToString(),
				"/Levels/",
				image,
				".png"
			}));
			yield return www21;
			this.curpic = www21.texture;
		}
		else
		{
			this.curpic = this.naimage;
		}
		yield break;
	}

	// Token: 0x060009DA RID: 2522 RVA: 0x0005584C File Offset: 0x00053C4C
	private void OnGUI()
	{
		if (this.allimagesloaded)
		{
			GUI.skin = this.MenuSkin;
			if (this.background1.Contains(".png"))
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
					if (!this.levelselect)
					{
						GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.loading);
						this.showloading = true;
						CryptoPlayerPrefs.SetInt("Mode", 1);
						UniSave.Load(this.firstlevel);
						GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.loading);
					}
					else
					{
						this.showmenu = false;
						this.showlevelselect = true;
					}
				}
				if (this.allowmultiplayer)
				{
					GUI.DrawTexture(new Rect(20f, (float)(Screen.height / 2 - 30), 175f, 30f), this.mpbutton);
					if (GUI.Button(new Rect(20f, (float)(Screen.height / 2 - 30), 175f, 30f), string.Empty))
					{
						CryptoPlayerPrefs.SetInt("Mode", 2);
						Application.LoadLevel("Lobby");
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
					this.showmenu = false;
					this.settingsenabled = true;
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
					Application.Quit();
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
			if (this.settingsenabled)
			{
				GUI.skin = this.SettingsSkin;
				GUI.Label(new Rect(18f, 100f, 140f, 25f), "Graphics Quality");
				if (GUI.Button(new Rect(10f, 130f, 120f, 25f), "Fastest"))
				{
					QualitySettings.SetQualityLevel(0);
				}
				if (GUI.Button(new Rect(10f, 155f, 120f, 25f), "Fast"))
				{
					QualitySettings.SetQualityLevel(1);
				}
				if (GUI.Button(new Rect(10f, 180f, 120f, 25f), "Low"))
				{
					QualitySettings.SetQualityLevel(2);
				}
				if (GUI.Button(new Rect(10f, 205f, 120f, 25f), "Average"))
				{
					QualitySettings.SetQualityLevel(3);
				}
				if (GUI.Button(new Rect(10f, 230f, 120f, 25f), "High"))
				{
					QualitySettings.SetQualityLevel(4);
				}
				if (GUI.Button(new Rect(10f, 255f, 120f, 25f), "Highest"))
				{
					QualitySettings.SetQualityLevel(5);
				}
				GUI.Label(new Rect((float)(Screen.width - 126), 100f, 140f, 25f), "Screen Resolution");
				if (GUI.Button(new Rect((float)(Screen.width - 130), 130f, 120f, 25f), "640x480"))
				{
					Screen.SetResolution(640, 480, false);
				}
				if (GUI.Button(new Rect((float)(Screen.width - 130), 155f, 120f, 25f), "800x600"))
				{
					Screen.SetResolution(800, 600, false);
				}
				if (GUI.Button(new Rect((float)(Screen.width - 130), 180f, 120f, 25f), "1024x768"))
				{
					Screen.SetResolution(1024, 768, false);
				}
				if (GUI.Button(new Rect((float)(Screen.width - 130), 205f, 120f, 25f), "1280x600"))
				{
					Screen.SetResolution(1280, 600, false);
				}
				if (GUI.Button(new Rect((float)(Screen.width - 130), 230f, 120f, 25f), "1280x720"))
				{
					Screen.SetResolution(1280, 720, false);
				}
				if (GUI.Button(new Rect((float)(Screen.width - 130), 255f, 120f, 25f), "1280x768"))
				{
					Screen.SetResolution(1280, 768, false);
				}
				if (GUI.Button(new Rect((float)(Screen.width - 130), 280f, 120f, 25f), "1360x768"))
				{
					Screen.SetResolution(1360, 768, false);
				}
				if (GUI.Button(new Rect((float)(Screen.width - 130), 305f, 120f, 25f), "1366x768"))
				{
					Screen.SetResolution(1366, 768, false);
				}
				Screen.fullScreen = this.fullscreen;
				this.fullscreen = GUI.Toggle(new Rect(10f, 290f, 150f, 30f), this.fullscreen, "Full-Screen");
				this.Anaglyph3d = GUI.Toggle(new Rect(10f, 320f, 150f, 30f), this.Anaglyph3d, "3D Anaglyph Mode");
				this.OVRMode = GUI.Toggle(new Rect(10f, 350f, 150f, 30f), this.OVRMode, "Oculus Rift Mode");
				this.showbloom = GUI.Toggle(new Rect(10f, 380f, 150f, 30f), this.showbloom, "Bloom Effect");
				this.motionblur = GUI.Toggle(new Rect(10f, 410f, 150f, 30f), this.motionblur, "Motion Blur");
				this.showhud = GUI.Toggle(new Rect(10f, 440f, 150f, 30f), this.showhud, "Display HUD");
				GUI.Box(new Rect(175f, 100f, 210f, 60f), string.Empty);
				GUI.Label(new Rect(230f, 100f, 140f, 25f), "Mouse Sensitivity");
				this.sensitivity = GUI.HorizontalSlider(new Rect(180f, 130f, 200f, 25f), this.sensitivity, 0f, 20f);
				CryptoPlayerPrefs.SetInt("customserver", 1);
				this.sensitivity = GUI.HorizontalSlider(new Rect(180f, 130f, 200f, 25f), this.sensitivity, 0f, 20f);
				GUI.Box(new Rect((float)(Screen.width / 2), (float)(Screen.height - 150), 400f, 100f), string.Concat(new object[]
				{
					"Machine Information: \n GPU: ",
					SystemInfo.graphicsDeviceName,
					"\n GPU Memory: ",
					SystemInfo.graphicsMemorySize,
					"MB\n CPU: ",
					SystemInfo.processorType,
					"\n RAM: ",
					SystemInfo.systemMemorySize,
					"MB"
				}));
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height - 50), 75f, 25f), "Back"))
				{
					this.settingsenabled = false;
					this.showmenu = true;
					PlayerPrefs.SetString("CamMode", "Normal");
					if (this.Anaglyph3d)
					{
						PlayerPrefs.SetString("CamMode", "Analygraph");
					}
					if (this.OVRMode)
					{
						PlayerPrefs.SetString("CamMode", "OVR");
					}
				}
				if (!this.showbloom)
				{
					PlayerPrefs.SetInt("bloom", 2);
				}
				else
				{
					PlayerPrefs.SetInt("bloom", 1);
				}
				if (!this.motionblur)
				{
					PlayerPrefs.SetInt("motionblur", 2);
				}
				else
				{
					PlayerPrefs.SetInt("motionblur", 1);
				}
				if (!this.showhud)
				{
					PlayerPrefs.SetInt("hud", 2);
				}
				else
				{
					PlayerPrefs.SetInt("hud", 1);
				}
				PlayerPrefs.SetFloat("sensitivity", this.sensitivity);
			}
			if (this.showlevelselect)
			{
				GUI.skin = this.SettingsSkin;
				GUI.Box(new Rect(10f, 100f, 250f, 400f), "Select A Level");
				GUI.DrawTexture(new Rect((float)(Screen.width - 400), (float)(Screen.height / 2 - 150), 300f, 300f), this.curpic);
				DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
				string text = string.Concat(new object[]
				{
					directoryInfo.Parent.ToString(),
					Path.DirectorySeparatorChar,
					"Levels",
					Path.DirectorySeparatorChar
				});
				string[] files = Directory.GetFiles(text, "*.story");
				string[] array = files;
				for (int i = 0; i < array.Length; i++)
				{
					string text2 = text;
					string oldValue = ".story";
					if (array[i].Contains(text2))
					{
						array[i] = array[i].Replace(text2, string.Empty);
						array[i] = array[i].Replace(oldValue, string.Empty);
					}
				}
				this.scrollPos2 = GUI.BeginScrollView(new Rect(20f, 120f, 230f, 370f), this.scrollPos2, new Rect(0f, 0f, 200f, (float)(30 * array.Length + 10)));
				for (int j = 0; j < array.Length; j++)
				{
					if (GUI.Button(new Rect(10f, (float)(10 + 30 * j), (float)(50 + array[j].Length * 6), 30f), array[j]))
					{
						base.StartCoroutine(this.ChangeImage(array[j]));
						this.selectedstory = array[j];
					}
				}
				GUI.EndScrollView();
				if (GUI.Button(new Rect((float)(Screen.width - 400), (float)(Screen.height / 2 + 150), 300f, 30f), "Play"))
				{
					GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.loading);
					this.showloading = true;
					CryptoPlayerPrefs.SetInt("Mode", 1);
					UniSave.Load(this.selectedstory);
					GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.loading);
				}
				if (GUI.Button(new Rect(10f, (float)(Screen.height - 40), 75f, 30f), "Back"))
				{
					this.showmenu = true;
					this.showlevelselect = false;
				}
			}
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 200), 20f, 400f, 100f), this.title);
		}
	}

	// Token: 0x04000B65 RID: 2917
	public bool iseditor;

	// Token: 0x04000B66 RID: 2918
	private string thepath;

	// Token: 0x04000B67 RID: 2919
	public string firstlevel;

	// Token: 0x04000B68 RID: 2920
	public string photonid;

	// Token: 0x04000B69 RID: 2921
	public bool allimagesloaded;

	// Token: 0x04000B6A RID: 2922
	public bool showmenu;

	// Token: 0x04000B6B RID: 2923
	public Texture2D background;

	// Token: 0x04000B6C RID: 2924
	public MovieTexture backgroundmov;

	// Token: 0x04000B6D RID: 2925
	public Texture2D title;

	// Token: 0x04000B6E RID: 2926
	public Texture2D credits;

	// Token: 0x04000B6F RID: 2927
	public Texture2D howtoplay;

	// Token: 0x04000B70 RID: 2928
	public Texture2D playbutton;

	// Token: 0x04000B71 RID: 2929
	public Texture2D howtoplaybutton;

	// Token: 0x04000B72 RID: 2930
	public Texture2D settingsbutton;

	// Token: 0x04000B73 RID: 2931
	public Texture2D creditsbutton;

	// Token: 0x04000B74 RID: 2932
	public Texture2D quitbutton;

	// Token: 0x04000B75 RID: 2933
	public Texture2D mpbutton;

	// Token: 0x04000B76 RID: 2934
	public GUISkin MenuSkin;

	// Token: 0x04000B77 RID: 2935
	public GUISkin SettingsSkin;

	// Token: 0x04000B78 RID: 2936
	public bool settingsenabled;

	// Token: 0x04000B79 RID: 2937
	public bool fullscreen;

	// Token: 0x04000B7A RID: 2938
	public bool showbloom;

	// Token: 0x04000B7B RID: 2939
	public bool motionblur;

	// Token: 0x04000B7C RID: 2940
	public bool showhud;

	// Token: 0x04000B7D RID: 2941
	public float sensitivity;

	// Token: 0x04000B7E RID: 2942
	public bool Anaglyph3d;

	// Token: 0x04000B7F RID: 2943
	public bool OVRMode;

	// Token: 0x04000B80 RID: 2944
	public bool showcredits;

	// Token: 0x04000B81 RID: 2945
	public bool showhowtoplay;

	// Token: 0x04000B82 RID: 2946
	public Texture2D loading;

	// Token: 0x04000B83 RID: 2947
	public bool showloading;

	// Token: 0x04000B84 RID: 2948
	public bool showlevelselect;

	// Token: 0x04000B85 RID: 2949
	public Vector2 scrollPos2;

	// Token: 0x04000B86 RID: 2950
	private string gametitle1 = "game_title.png";

	// Token: 0x04000B87 RID: 2951
	private string background1 = "background.png";

	// Token: 0x04000B88 RID: 2952
	private string howtoplay1 = "how_to_play.png";

	// Token: 0x04000B89 RID: 2953
	private string credits1 = "credits.png";

	// Token: 0x04000B8A RID: 2954
	private string singleplayerbutton1 = "singleplayer_button.png";

	// Token: 0x04000B8B RID: 2955
	private string howtoplaybutton1 = "how_to_play_button.png";

	// Token: 0x04000B8C RID: 2956
	private string settingsbutton1 = "settings_button.png";

	// Token: 0x04000B8D RID: 2957
	private string creditsbutton1 = "credits_button.png";

	// Token: 0x04000B8E RID: 2958
	private string quitbutton1 = "quit_button.png";

	// Token: 0x04000B8F RID: 2959
	private string loading1 = "loading_screen.png";

	// Token: 0x04000B90 RID: 2960
	public bool allowmultiplayer;

	// Token: 0x04000B91 RID: 2961
	private string multiplayerbutton1 = "multiplayer_button.png";

	// Token: 0x04000B92 RID: 2962
	public string playermodel;

	// Token: 0x04000B93 RID: 2963
	public bool levelselect;

	// Token: 0x04000B94 RID: 2964
	private string menumusic1 = "music.wav";

	// Token: 0x04000B95 RID: 2965
	public GameObject menumusic;

	// Token: 0x04000B96 RID: 2966
	private Texture2D curpic;

	// Token: 0x04000B97 RID: 2967
	public Texture2D naimage;

	// Token: 0x04000B98 RID: 2968
	private string selectedstory;

	// Token: 0x04000B99 RID: 2969
	public int mppos;
}
