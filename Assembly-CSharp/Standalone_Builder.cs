using System;
using System.Collections;
using System.IO;
using CompilerGenerated;
using UnityEngine;

// Token: 0x020001A0 RID: 416
public class Standalone_Builder : MonoBehaviour
{
	// Token: 0x060009DC RID: 2524 RVA: 0x00056EE8 File Offset: 0x000552E8
	private void Awake()
	{
		if (this.isEditor)
		{
			this.temppath = "C:/TE_TESTS";
		}
		else
		{
			this.temppath = Application.dataPath;
		}
		this.gametitle = this.temppath + "/Menu/game_title.png";
		this.background = this.temppath + "/Menu/background.png";
		this.howtoplay = this.temppath + "/Menu/how_to_play.png";
		this.credits = this.temppath + "/Menu/credits.png";
		this.loadingsceen = this.temppath + "/Menu/loading_screen.png";
		this.singleplayerbutton = this.temppath + "/Menu/singleplayer_button.png";
		this.multiplayerbutton = this.temppath + "/Menu/multiplayer_button.png";
		this.howtoplaybutton = this.temppath + "/Menu/how_to_play_button.png";
		this.settingsbutton = this.temppath + "/Menu/settings_button.png";
		this.creditsbutton = this.temppath + "/Menu/credits_button.png";
		this.quitbutton = this.temppath + "/Menu/quit_button.png";
		this.menumusic = this.temppath + "/Menu/music.ogg";
		if (GameObject.Find("Menu") != null)
		{
			UnityEngine.Object.Destroy(GameObject.Find("Menu"));
		}
	}

	// Token: 0x060009DD RID: 2525 RVA: 0x00057047 File Offset: 0x00055447
	private void Update()
	{
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x0005704C File Offset: 0x0005544C
	private IEnumerator BuildGame()
	{
		this.showstoryselector = false;
		this.showbuilding = true;
		yield return new WaitForSeconds(1f);
		this.buildingtext = string.Concat(new string[]
		{
			"Building '",
			this.gamename,
			"' as standalone game...\nOnce complete '",
			this.gamename,
			"' will be located in the 'Builds' folder"
		});
		DirectoryInfo directoryInfo = new DirectoryInfo(this.temppath);
		Standalone_Builder.DirectoryCopy(this.temppath + "/Resources/Template" + this.bitversion, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			string.Empty
		}), true);
		Directory.Move(string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/Template_Data"
		}), string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data"
		}));
		yield return new WaitForSeconds(0.2f);
		File.Move(string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/Template.exe"
		}), string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			".exe"
		}));
		File.Copy(Application.dataPath + "/Characters/Players/" + this.playermodel, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Characters/Players/",
			this.playermodel
		}));
		File.Copy(this.gametitle, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/game_title.png"
		}));
		if (this.background.Contains(".png"))
		{
			File.Copy(this.background, string.Concat(new string[]
			{
				directoryInfo.Parent.ToString(),
				"/Builds/",
				this.gamename,
				this.bitversion,
				"/",
				this.gamename,
				"_Data/Menu/background.png"
			}));
		}
		else
		{
			File.Copy(this.background, string.Concat(new string[]
			{
				directoryInfo.Parent.ToString(),
				"/Builds/",
				this.gamename,
				this.bitversion,
				"/",
				this.gamename,
				"_Data/Menu/background.ogv"
			}));
		}
		File.Copy(this.credits, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/credits.png"
		}));
		File.Copy(this.loadingsceen, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/loading_screen.png"
		}));
		File.Copy(this.howtoplay, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/how_to_play.png"
		}));
		File.Copy(this.singleplayerbutton, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/singleplayer_button.png"
		}));
		if (this.multiplayerbutton != string.Empty)
		{
			File.Copy(this.multiplayerbutton, string.Concat(new string[]
			{
				directoryInfo.Parent.ToString(),
				"/Builds/",
				this.gamename,
				this.bitversion,
				"/",
				this.gamename,
				"_Data/Menu/multiplayer_button.png"
			}));
		}
		File.Copy(this.creditsbutton, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/credits_button.png"
		}));
		File.Copy(this.howtoplaybutton, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/how_to_play_button.png"
		}));
		File.Copy(this.settingsbutton, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/settings_button.png"
		}));
		File.Copy(this.quitbutton, string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/Menu/quit_button.png"
		}));
		if (this.menumusic.Contains(".ogg"))
		{
			File.Copy(this.menumusic, string.Concat(new string[]
			{
				directoryInfo.Parent.ToString(),
				"/Builds/",
				this.gamename,
				this.bitversion,
				"/",
				this.gamename,
				"_Data/Menu/music.ogg"
			}));
		}
		else if (this.menumusic.Contains(".wav"))
		{
			File.Copy(this.menumusic, string.Concat(new string[]
			{
				directoryInfo.Parent.ToString(),
				"/Builds/",
				this.gamename,
				this.bitversion,
				"/",
				this.gamename,
				"_Data/Menu/music.wav"
			}));
		}
		string[] thedata = new string[4];
		string[] alllevels = this.levels.Split(new char[]
		{
			"\n"[0]
		});
		DirectoryInfo directoryInfo2 = new DirectoryInfo(Application.dataPath);
		CryptoPlayerPrefs.SetInt("TotalLevels", alllevels.Length - 1);
		CryptoPlayerPrefs.SetInt("CurLevel", 1);
		CryptoPlayerPrefs.SetInt("Mode", 21);
		CryptoPlayerPrefs.SetString("path", directoryInfo.Parent.ToString() + "/Builds");
		CryptoPlayerPrefs.SetString("GameName", this.gamename);
		CryptoPlayerPrefs.SetString("BitVersion", this.bitversion);
		for (int i = 0; i < alllevels.Length; i++)
		{
			if (i != alllevels.Length - 1)
			{
				if (!File.Exists(string.Concat(new string[]
				{
					directoryInfo.Parent.ToString(),
					"/Builds/",
					this.gamename,
					this.bitversion,
					"/Levels/",
					alllevels[i],
					".story"
				})))
				{
					File.Copy(directoryInfo2.Parent.ToString() + "/Levels/" + alllevels[i] + ".story", string.Concat(new string[]
					{
						directoryInfo.Parent.ToString(),
						"/Builds/",
						this.gamename,
						this.bitversion,
						"/Levels/",
						alllevels[i],
						".story"
					}));
					File.Copy(directoryInfo2.Parent.ToString() + "/Levels/" + alllevels[i] + ".info", string.Concat(new string[]
					{
						directoryInfo.Parent.ToString(),
						"/Builds/",
						this.gamename,
						this.bitversion,
						"/Levels/",
						alllevels[i],
						".info"
					}));
					if (this.allowlevelselect && File.Exists(string.Concat(new string[]
					{
						directoryInfo.Parent.ToString(),
						"/Builds/",
						this.gamename,
						this.bitversion,
						"/Levels/",
						alllevels[i],
						".png"
					})))
					{
						File.Copy(directoryInfo2.Parent.ToString() + "/Levels/" + alllevels[i] + ".png", string.Concat(new string[]
						{
							directoryInfo.Parent.ToString(),
							"/Builds/",
							this.gamename,
							this.bitversion,
							"/Levels/",
							alllevels[i],
							".png"
						}));
					}
				}
				this.curlevel++;
				CryptoPlayerPrefs.SetString("level" + this.curlevel.ToString(), alllevels[i]);
			}
			if (i == 0 && !this.allowlevelselect)
			{
				thedata[0] = alllevels[i];
			}
		}
		if (this.allowlevelselect)
		{
			thedata[0] = "levelselect";
		}
		thedata[1] = this.playermodel;
		if (this.allowmultiplayer)
		{
			thedata[2] = "1";
			thedata[3] = this.photonid;
		}
		else
		{
			thedata[2] = "0";
			thedata[3] = "null";
		}
		File.WriteAllLines(string.Concat(new string[]
		{
			directoryInfo.Parent.ToString(),
			"/Builds/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data/mainData2"
		}), thedata);
		UniSave.Load(CryptoPlayerPrefs.GetString("level1", string.Empty));
		yield break;
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x00057068 File Offset: 0x00055468
	private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (!directoryInfo.Exists)
		{
			throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
		}
		if (Directory.Exists(destDirName))
		{
			Debug.Log("GAME ALREADY EXSISTS");
			Directory.Move(destDirName, destDirName + "_OLD" + UnityEngine.Random.Range(0, 1000));
			Directory.CreateDirectory(destDirName);
		}
		else
		{
			Directory.CreateDirectory(destDirName);
		}
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			string destFileName = Path.Combine(destDirName, fileInfo.Name);
			fileInfo.CopyTo(destFileName, false);
		}
		if (copySubDirs)
		{
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
				Standalone_Builder.DirectoryCopy(directoryInfo2.FullName, destDirName2, copySubDirs);
			}
		}
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x00057170 File Offset: 0x00055570
	private void OnGUI()
	{
		GUI.skin = this.skin1;
		if (this.showgamename)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height / 2 - 50), 300f, 100f), "Please enter a name for your game");
			this.gamename = GUI.TextField(new Rect((float)(Screen.width / 2 - 140), (float)(Screen.height / 2 - 22), 280f, 22f), this.gamename);
			GUI.Label(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 + 70), 400f, 150f), "Welcome to the standalone game creator!  Here you will be able to build your own .exe games from Terror Engine which you can zip and share with your friends!  You will be asked to customize your games main menu and menu music.  To begin, please enter the name of your new game and click continue.\n\nNOTICE: This will be the name of the .exe.");
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 140), (float)(Screen.height / 2 + 10), 280f, 32f), "Continue"))
			{
				this.showgamename = false;
			}
		}
		else if (this.showtutorial)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 110), 400f, 200f), "Game Name: " + this.gamename + "\n\nNext, you will be asked to select a game title image, background images, button images and menu music from your computer for your main menu.  Background images include: 'Main Menu background','How To Play Screen', 'Loading Screen' and 'Credits Screen'.  Button images include: 'Singleplayer Button', 'How To Play Button', 'Settings Button', 'Credits Button' and 'Quit Button'.\n\n-PNG is the only supported image format.\n-OGG and WAV are the only supported audio format for menu music.\n-For the Main Menu Background you can also use OGV video format.");
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 140), (float)(Screen.height / 2 + 110), 280f, 32f), "Continue"))
			{
				this.showtutorial = false;
				this.showmenueditor = true;
			}
		}
		if (this.showmenueditor)
		{
			GUI.Box(new Rect(50f, 50f, 400f, 500f), "Menu Editor");
			GUI.Label(new Rect(60f, 100f, 150f, 22f), "Game Title Image:");
			this.gametitle = GUI.TextField(new Rect(200f, 100f, 200f, 22f), this.gametitle);
			if (GUI.Button(new Rect(405f, 100f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Opengametitle));
			}
			GUI.Label(new Rect(60f, 130f, 150f, 22f), "Menu Background:");
			this.background = GUI.TextField(new Rect(200f, 130f, 200f, 22f), this.background);
			if (GUI.Button(new Rect(405f, 130f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Openbackground));
			}
			GUI.Label(new Rect(60f, 160f, 150f, 22f), "How To Play Screen:");
			this.howtoplay = GUI.TextField(new Rect(200f, 160f, 200f, 22f), this.howtoplay);
			if (GUI.Button(new Rect(405f, 160f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Openhowtoplay));
			}
			GUI.Label(new Rect(60f, 190f, 150f, 22f), "Credits Screen:");
			this.credits = GUI.TextField(new Rect(200f, 190f, 200f, 22f), this.credits);
			if (GUI.Button(new Rect(405f, 190f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Opencredits));
			}
			GUI.Label(new Rect(60f, 220f, 150f, 22f), "Loading Screen:");
			this.loadingsceen = GUI.TextField(new Rect(200f, 220f, 200f, 22f), this.loadingsceen);
			if (GUI.Button(new Rect(405f, 220f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Openloadingscreen));
			}
			GUI.Label(new Rect(60f, 250f, 150f, 22f), "Singleplayer Button:");
			this.singleplayerbutton = GUI.TextField(new Rect(200f, 250f, 200f, 22f), this.singleplayerbutton);
			if (GUI.Button(new Rect(405f, 250f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Opensingleplayerb));
			}
			GUI.Label(new Rect(60f, 280f, 150f, 22f), "How To Play Button:");
			this.howtoplaybutton = GUI.TextField(new Rect(200f, 280f, 200f, 22f), this.howtoplaybutton);
			if (GUI.Button(new Rect(405f, 280f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Openhowtoplayb));
			}
			GUI.Label(new Rect(60f, 310f, 150f, 22f), "Settings Button:");
			this.settingsbutton = GUI.TextField(new Rect(200f, 310f, 200f, 22f), this.settingsbutton);
			if (GUI.Button(new Rect(405f, 310f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Opensettingsb));
			}
			GUI.Label(new Rect(60f, 340f, 150f, 22f), "Credits Button:");
			this.creditsbutton = GUI.TextField(new Rect(200f, 340f, 200f, 22f), this.creditsbutton);
			if (GUI.Button(new Rect(405f, 340f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Opencreditsb));
			}
			GUI.Label(new Rect(60f, 370f, 150f, 22f), "Quit Button:");
			this.quitbutton = GUI.TextField(new Rect(200f, 370f, 200f, 22f), this.quitbutton);
			if (GUI.Button(new Rect(405f, 370f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Openquitb));
			}
			GUI.Label(new Rect(60f, 400f, 150f, 22f), "Menu Music:");
			this.menumusic = GUI.TextField(new Rect(200f, 400f, 200f, 22f), this.menumusic);
			if (GUI.Button(new Rect(405f, 400f, 35f, 22f), "..."))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Openmenumusic));
			}
			if (GUI.Button(new Rect(60f, 430f, 380f, 30f), "Preview"))
			{
				PreviewMenu component = base.gameObject.GetComponent<PreviewMenu>();
				component.ShowNow();
				this.showmenueditor = false;
			}
			this.allowmultiplayer = GUI.Toggle(new Rect(60f, 460f, 200f, 22f), this.allowmultiplayer, "Allow Multiplayer");
			this.allowlevelselect = GUI.Toggle(new Rect(320f, 460f, 200f, 22f), this.allowlevelselect, "Allow Level Select");
			if (this.allowmultiplayer)
			{
				GUI.Label(new Rect(60f, 490f, 150f, 22f), "Multiplayer Button:");
				this.multiplayerbutton = GUI.TextField(new Rect(200f, 490f, 200f, 22f), this.multiplayerbutton);
				GUI.Label(new Rect(60f, 520f, 100f, 22f), "Photon APP ID:");
				this.photonid = GUI.TextField(new Rect(165f, 520f, 120f, 22f), this.photonid);
				if (GUI.Button(new Rect(405f, 490f, 35f, 22f), "..."))
				{
					UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.Openmultiplayerb));
				}
			}
			if (GUI.Button(new Rect(340f, 520f, 100f, 20f), "Continue"))
			{
				this.showmenueditor = false;
				this.showplayermodel = true;
			}
		}
		if (this.showplayermodel)
		{
			GUILayout.BeginArea(new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height / 2 - 200), 300f, 400f));
			GUI.Box(new Rect(0f, 0f, 300f, 400f), "Select a player model");
			DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
			string text = string.Concat(new object[]
			{
				directoryInfo.ToString(),
				Path.DirectorySeparatorChar,
				"Characters",
				Path.DirectorySeparatorChar,
				"Players",
				Path.DirectorySeparatorChar
			});
			string[] files = Directory.GetFiles(text, "*.player");
			string[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = text;
				string oldValue = ".player";
				if (array[i].Contains(text2))
				{
					array[i] = array[i].Replace(text2, string.Empty);
					array[i] = array[i].Replace(oldValue, string.Empty);
				}
			}
			GUILayout.Space(30f);
			this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, new GUILayoutOption[0]);
			foreach (string text3 in array)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(text3, new GUILayoutOption[0]))
				{
					this.playermodel = text3 + ".player";
					this.showplayermodel = false;
					this.showstoryselector = true;
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}
		if (this.showstoryselector)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 220), (float)(Screen.height / 2 - 270), 440f, 540f), "Select levels you wish to have in your game");
			DirectoryInfo directoryInfo2 = new DirectoryInfo(Application.dataPath);
			string text4 = string.Concat(new object[]
			{
				directoryInfo2.Parent.ToString(),
				Path.DirectorySeparatorChar,
				"Levels",
				Path.DirectorySeparatorChar
			});
			string[] files2 = Directory.GetFiles(text4, "*.story");
			string[] array3 = files2;
			for (int k = 0; k < array3.Length; k++)
			{
				string text5 = text4;
				string oldValue2 = ".story";
				if (array3[k].Contains(text5))
				{
					array3[k] = array3[k].Replace(text5, string.Empty);
					array3[k] = array3[k].Replace(oldValue2, string.Empty);
				}
			}
			this.scrollPos2 = GUI.BeginScrollView(new Rect((float)(Screen.width / 2 + 10), (float)(Screen.height / 2 - 200), 180f, 300f), this.scrollPos2, new Rect(0f, 0f, 150f, (float)(30 * array3.Length)));
			for (int l = 0; l < array3.Length; l++)
			{
				if (GUI.Button(new Rect(10f, (float)(10 + 30 * l), (float)(50 + array3[l].Length * 6), 30f), array3[l]))
				{
					this.levels = this.levels + array3[l] + "\n";
					this.templevel = array3[l] + "\n";
				}
			}
			GUI.EndScrollView();
			GUI.Label(new Rect((float)(Screen.width / 2 - 145), (float)(Screen.height / 2 - 222), 200f, 22f), "Selected Levels");
			GUI.Box(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 200), 200f, 300f), this.levels);
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 + 100), 200f, 22f), "Reset"))
			{
				this.levels = string.Empty;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 190), (float)(Screen.height / 2 + 182), 380f, 32f), "Build 32BIT"))
			{
				this.bitversion = " (32bit)";
				base.StartCoroutine(this.BuildGame());
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 190), (float)(Screen.height / 2 + 214), 380f, 32f), "Build 64BIT"))
			{
				this.bitversion = " (64bit)";
				base.StartCoroutine(this.BuildGame());
			}
		}
		if (GUI.Button(new Rect(10f, 0f, 150f, 32f), "Quit To Main Menu"))
		{
			Application.LoadLevel("MainMenu");
		}
		if (this.showbuilding)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 125), (float)(Screen.height / 2 - 11), 250f, 50f), this.buildingtext);
		}
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x0005802E File Offset: 0x0005642E
	private void Opengametitle(string pathToFile)
	{
		this.gametitle = pathToFile;
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x00058037 File Offset: 0x00056437
	private void Openbackground(string pathToFile)
	{
		this.background = pathToFile;
	}

	// Token: 0x060009E3 RID: 2531 RVA: 0x00058040 File Offset: 0x00056440
	private void Openhowtoplay(string pathToFile)
	{
		this.howtoplay = pathToFile;
	}

	// Token: 0x060009E4 RID: 2532 RVA: 0x00058049 File Offset: 0x00056449
	private void Opencredits(string pathToFile)
	{
		this.credits = pathToFile;
	}

	// Token: 0x060009E5 RID: 2533 RVA: 0x00058052 File Offset: 0x00056452
	private void Openloadingscreen(string pathToFile)
	{
		this.loadingsceen = pathToFile;
	}

	// Token: 0x060009E6 RID: 2534 RVA: 0x0005805B File Offset: 0x0005645B
	private void Opensingleplayerb(string pathToFile)
	{
		this.singleplayerbutton = pathToFile;
	}

	// Token: 0x060009E7 RID: 2535 RVA: 0x00058064 File Offset: 0x00056464
	private void Openmultiplayerb(string pathToFile)
	{
		this.multiplayerbutton = pathToFile;
	}

	// Token: 0x060009E8 RID: 2536 RVA: 0x0005806D File Offset: 0x0005646D
	private void Openhowtoplayb(string pathToFile)
	{
		this.howtoplaybutton = pathToFile;
	}

	// Token: 0x060009E9 RID: 2537 RVA: 0x00058076 File Offset: 0x00056476
	private void Opensettingsb(string pathToFile)
	{
		this.settingsbutton = pathToFile;
	}

	// Token: 0x060009EA RID: 2538 RVA: 0x0005807F File Offset: 0x0005647F
	private void Opencreditsb(string pathToFile)
	{
		this.creditsbutton = pathToFile;
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x00058088 File Offset: 0x00056488
	private void Openquitb(string pathToFile)
	{
		this.quitbutton = pathToFile;
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x00058091 File Offset: 0x00056491
	private void Openmenumusic(string pathToFile)
	{
		this.menumusic = pathToFile;
	}

	// Token: 0x04000B9A RID: 2970
	public bool isEditor;

	// Token: 0x04000B9B RID: 2971
	public GUISkin skin1;

	// Token: 0x04000B9C RID: 2972
	public string gamename;

	// Token: 0x04000B9D RID: 2973
	public string gametitle;

	// Token: 0x04000B9E RID: 2974
	public string background;

	// Token: 0x04000B9F RID: 2975
	public string howtoplay;

	// Token: 0x04000BA0 RID: 2976
	public string credits;

	// Token: 0x04000BA1 RID: 2977
	public string loadingsceen;

	// Token: 0x04000BA2 RID: 2978
	public string singleplayerbutton;

	// Token: 0x04000BA3 RID: 2979
	public string howtoplaybutton;

	// Token: 0x04000BA4 RID: 2980
	public string settingsbutton;

	// Token: 0x04000BA5 RID: 2981
	public string creditsbutton;

	// Token: 0x04000BA6 RID: 2982
	public string quitbutton;

	// Token: 0x04000BA7 RID: 2983
	public bool allowmultiplayer;

	// Token: 0x04000BA8 RID: 2984
	public bool allowlevelselect;

	// Token: 0x04000BA9 RID: 2985
	public string multiplayerbutton;

	// Token: 0x04000BAA RID: 2986
	public string photonid;

	// Token: 0x04000BAB RID: 2987
	public string menumusic;

	// Token: 0x04000BAC RID: 2988
	public string playermodel;

	// Token: 0x04000BAD RID: 2989
	public string levels;

	// Token: 0x04000BAE RID: 2990
	private Vector2 scrollPos = Vector2.zero;

	// Token: 0x04000BAF RID: 2991
	private Vector2 scrollPos2 = Vector2.zero;

	// Token: 0x04000BB0 RID: 2992
	private Vector2 scrollPos3 = Vector2.zero;

	// Token: 0x04000BB1 RID: 2993
	private bool showgamename = true;

	// Token: 0x04000BB2 RID: 2994
	private bool showtutorial = true;

	// Token: 0x04000BB3 RID: 2995
	public bool showmenueditor;

	// Token: 0x04000BB4 RID: 2996
	private bool showplayermodel;

	// Token: 0x04000BB5 RID: 2997
	private bool showstoryselector;

	// Token: 0x04000BB6 RID: 2998
	private string templevel;

	// Token: 0x04000BB7 RID: 2999
	private bool showbuilding;

	// Token: 0x04000BB8 RID: 3000
	private string buildingtext = "Preparing Build... Please wait";

	// Token: 0x04000BB9 RID: 3001
	private string bitversion = " (32bit)";

	// Token: 0x04000BBA RID: 3002
	private string temppath;

	// Token: 0x04000BBB RID: 3003
	private int totallevels;

	// Token: 0x04000BBC RID: 3004
	private int curlevel;

	// Token: 0x04000BBD RID: 3005
	private int levelnum;
}
