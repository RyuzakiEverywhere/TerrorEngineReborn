using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200025C RID: 604
public class TestGUI : MonoBehaviour
{
	// Token: 0x1700030F RID: 783
	// (get) Token: 0x060010F5 RID: 4341 RVA: 0x0006B8A5 File Offset: 0x00069CA5
	// (set) Token: 0x060010F6 RID: 4342 RVA: 0x0006B8B2 File Offset: 0x00069CB2
	public string STRING
	{
		get
		{
			return SC.ToString(this._STRING);
		}
		set
		{
			this._STRING = SC.FromString(value);
		}
	}

	// Token: 0x17000310 RID: 784
	// (get) Token: 0x060010F7 RID: 4343 RVA: 0x0006B8C0 File Offset: 0x00069CC0
	// (set) Token: 0x060010F8 RID: 4344 RVA: 0x0006B8CD File Offset: 0x00069CCD
	public string STRING2
	{
		get
		{
			return SC.ToString(this._STRING2);
		}
		set
		{
			this._STRING2 = SC.FromString(value);
		}
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x0006B8DB File Offset: 0x00069CDB
	private void Awake()
	{
		this._textStyle = new GUIStyle();
	}

	// Token: 0x060010FA RID: 4346 RVA: 0x0006B8E8 File Offset: 0x00069CE8
	private void Start()
	{
		this._textStyle.fontSize = 26;
		this._STRING = "E2193590";
		this._STRING2 = this.o10;
		if (TestGUI.Instance != null && TestGUI.Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		TestGUI.Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		UniSave.OnLoadingFailed += this.UniSave_OnLoadingFailed;
		UniSave.OnSavingCompleted += this.UniSave_OnSavingCompleted;
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
		this.serverid = CryptoPlayerPrefs.GetString("serverid", string.Empty);
		if (!this._ingame)
		{
		}
		if (Application.loadedLevelName == "MainMenu")
		{
			this.CurrentState = new TestGUI.GUIState(this.MainMenu);
		}
		else
		{
			this.CurrentState = new TestGUI.GUIState(this.InGame);
		}
	}

	// Token: 0x060010FB RID: 4347 RVA: 0x0006BB00 File Offset: 0x00069F00
	private IEnumerator CreditsToMenu()
	{
		Transform cam = GameObject.Find("Main Camera").transform;
		Transform newpos = GameObject.Find("MainPos").transform;
		cam.position = Vector3.MoveTowards(cam.position, newpos.position, 10f * Time.deltaTime);
		yield return new WaitForSeconds(0.2f);
		this.creditsscreen.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x060010FC RID: 4348 RVA: 0x0006BB1C File Offset: 0x00069F1C
	private IEnumerator SettingsToMenu()
	{
		Transform cam = GameObject.Find("Main Camera").transform;
		Transform newpos = GameObject.Find("MainPos").transform;
		cam.position = Vector3.MoveTowards(cam.position, newpos.position, 15f * Time.deltaTime);
		yield return new WaitForSeconds(0.5f);
		this.settingsscreen.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x060010FD RID: 4349 RVA: 0x0006BB38 File Offset: 0x00069F38
	private void Update()
	{
		if (CryptoPlayerPrefs.GetInt("customserver", 0) != 2)
		{
			CryptoPlayerPrefs.SetString("serverid", "55d895ae-814e-4544-aa61-4ec75a84a878");
		}
		else
		{
			CryptoPlayerPrefs.SetString("serverid", this.serverid);
			this.customserver = true;
		}
		if ((this._ingame && this.CurrentState != new TestGUI.GUIState(this.MainMenu) && this.CurrentState != new TestGUI.GUIState(this.ErrorPrompt) && Input.GetKeyDown(KeyCode.Tab) && CryptoPlayerPrefs.GetInt("Mode", 0) == 4) || (this._ingame && this.CurrentState != new TestGUI.GUIState(this.MainMenu) && this.CurrentState != new TestGUI.GUIState(this.ErrorPrompt) && GameObject.Find("File(Clone)")))
		{
			this.CurrentState = new TestGUI.GUIState(this.NewStoryOptions);
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			this.playload = "Load";
		}
		else
		{
			this.playload = "Play";
		}
		if (this.Anaglyph3d)
		{
			this.OVRMode = false;
			PlayerPrefs.SetString("CamMode", "Analygraph");
		}
		if (this.OVRMode)
		{
			this.Anaglyph3d = false;
			PlayerPrefs.SetString("CamMode", "OVR");
		}
		if (!this.Anaglyph3d && !this.OVRMode)
		{
			PlayerPrefs.SetString("CamMode", "Normal");
		}
		if (!this._ingame)
		{
			if (this.CurrentState == new TestGUI.GUIState(this.MainMenu))
			{
				Transform transform = GameObject.Find("Main Camera").transform;
				Transform transform2 = GameObject.Find("MainPos").transform;
				transform.position = Vector3.MoveTowards(transform.position, transform2.position, 10f * Time.deltaTime);
			}
			if (this.CurrentState == new TestGUI.GUIState(this.Credits))
			{
				Transform transform3 = GameObject.Find("Main Camera").transform;
				Transform transform4 = GameObject.Find("CreditsPos").transform;
				transform3.position = Vector3.MoveTowards(transform3.position, transform4.position, 10f * Time.deltaTime);
			}
			if (this.CurrentState == new TestGUI.GUIState(this.Settings))
			{
				Transform transform5 = GameObject.Find("Main Camera").transform;
				Transform transform6 = GameObject.Find("SettingsPos").transform;
				transform5.position = Vector3.MoveTowards(transform5.position, transform6.position, 10f * Time.deltaTime);
			}
		}
	}

	// Token: 0x060010FE RID: 4350 RVA: 0x0006BE18 File Offset: 0x0006A218
	private void InGame()
	{
		this._ingame = true;
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(MouseLook));
		foreach (MouseLook mouseLook in array)
		{
			mouseLook.enabled = true;
		}
	}

	// Token: 0x060010FF RID: 4351 RVA: 0x0006BE62 File Offset: 0x0006A262
	private void NotInGame()
	{
		this._ingame = false;
		this.CurrentState = new TestGUI.GUIState(this.MainMenu);
	}

	// Token: 0x06001100 RID: 4352 RVA: 0x0006BE80 File Offset: 0x0006A280
	private void MainMenu()
	{
		GUI.skin = this.MenuWindowSkin;
		this.windowRect = new Rect(30f, 100f, 290f, (float)(Screen.height - 120));
		this.windowRect = GUI.Window(0, this.windowRect, new GUI.WindowFunction(this.MainMenuWindow), "Main Menu");
	}

	// Token: 0x06001101 RID: 4353 RVA: 0x0006BEE0 File Offset: 0x0006A2E0
	private void DoFrameSkull(int windowID)
	{
		Vector2 vector = new Vector2(0f, 0f);
		float num = 370f;
		float height = 136f;
		vector.x = (this.windowRect.width - num) / 2f;
		GUI.Label(new Rect(vector.x, vector.y, num, height), string.Empty, "windowSkull");
	}

	// Token: 0x06001102 RID: 4354 RVA: 0x0006BF50 File Offset: 0x0006A350
	private void MainMenuWindow(int windowID)
	{
		if (CryptoPlayerPrefs.GetString("E410675", string.Empty) != this._STRING && GUI.Button(new Rect(0f, (float)(Screen.height - 25), 200f, 25f), "Create an account"))
		{
			Application.OpenURL("http://zeoworks.com/");
		}
		GUI.skin = this.MenuWindowSkin;
		if (GUI.Button(new Rect(45f, 90f, 200f, 25f), "Play A Story"))
		{
			CryptoPlayerPrefs.SetInt("Mode", 1);
			this._menuOption = "Load";
			this._refreshSavesList = true;
			this.CurrentState = new TestGUI.GUIState(this.LoadSaveMenu);
		}
		if (GUI.Button(new Rect(45f, 130f, 200f, 25f), this.multiplayer))
		{
			CryptoPlayerPrefs.SetInt("Mode", 2);
			this._menuOption = "Load";
			this._refreshSavesList = true;
			Application.LoadLevel("Lobby");
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (GUI.Button(new Rect(45f, 170f, 200f, 25f), this.storycreator))
		{
			CryptoPlayerPrefs.SetInt("Mode", 4);
			this._menuOption = "Load";
			this._refreshSavesList = true;
			this._ingame = false;
			this.CurrentState = new TestGUI.GUIState(this.CreatorOptions);
		}
		if (GUI.Button(new Rect(45f, 210f, 200f, 25f), "Character Selection"))
		{
			this.characterselection.gameObject.SetActive(true);
			GameObject.Find("Main Camera").gameObject.SetActive(false);
			base.gameObject.gameObject.SetActive(false);
		}
		if (GUI.Button(new Rect(45f, 260f, 200f, 25f), "Settings"))
		{
			this.CurrentState = new TestGUI.GUIState(this.Settings);
			Transform transform = GameObject.Find("Main Camera").transform;
			this.settingsscreen.gameObject.SetActive(true);
			Transform transform2 = GameObject.Find("SettingsPos").transform;
			transform.position = Vector3.MoveTowards(transform.position, transform2.position, 3f * Time.deltaTime);
		}
		if (GUI.Button(new Rect(45f, 300f, 200f, 25f), "Controls & Credits"))
		{
			this.CurrentState = new TestGUI.GUIState(this.Credits);
			Transform transform3 = GameObject.Find("Main Camera").transform;
			this.creditsscreen.gameObject.SetActive(true);
			Transform transform4 = GameObject.Find("CreditsPos").transform;
			transform3.position = Vector3.MoveTowards(transform3.position, transform4.position, 3f * Time.deltaTime);
		}
		if (GUI.Button(new Rect(45f, 340f, 200f, 25f), "Quit"))
		{
			CryptoPlayerPrefs.SetInt("intro", 1);
			Application.Quit();
		}
	}

	// Token: 0x06001103 RID: 4355 RVA: 0x0006C280 File Offset: 0x0006A680
	private void MultiPlayerOptions()
	{
		if (GUI.Button(new Rect(30f, (float)(Screen.height / 2 - 100), 200f, 25f), "Host A Game") && CryptoPlayerPrefs.GetString("E410675", string.Empty) == this._STRING)
		{
			CryptoPlayerPrefs.SetInt("Mode", 2);
			this._menuOption = "Load";
			this._refreshSavesList = true;
			this.CurrentState = new TestGUI.GUIState(this.SelectAmountOfPlayers);
		}
		if (GUI.Button(new Rect(30f, (float)(Screen.height / 2 - 75), 200f, 25f), "Join A Game") && CryptoPlayerPrefs.GetString("E410675", string.Empty) == this._STRING)
		{
			CryptoPlayerPrefs.SetInt("Mode", 3);
			this._menuOption = "Load";
			this._refreshSavesList = true;
			this.CurrentState = new TestGUI.GUIState(this.LoadSaveMenu);
		}
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height / 2) + 232.5f, 75f, 25f), "Back"))
		{
			this.CurrentState = new TestGUI.GUIState(this.MainMenu);
		}
	}

	// Token: 0x06001104 RID: 4356 RVA: 0x0006C3D0 File Offset: 0x0006A7D0
	private void SelectAmountOfPlayers()
	{
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 105), (float)(Screen.height / 2 + 75), 200f, 25f), "Continue") && CryptoPlayerPrefs.GetString("E410675", string.Empty) == this._STRING)
		{
			CryptoPlayerPrefs.SetInt("Mode", 2);
			this._menuOption = "Load";
			this._refreshSavesList = true;
			this.CurrentState = new TestGUI.GUIState(this.LoadSaveMenu);
		}
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 40), (float)(Screen.height / 2) + 232.5f, 75f, 25f), "Back"))
		{
			this.CurrentState = new TestGUI.GUIState(this.MainMenu);
		}
		GUI.Label(new Rect((float)(Screen.width / 2 - 20), (float)(Screen.height / 2 - 80), 50f, 75f), this.aop.ToString());
		CryptoPlayerPrefs.SetInt("TotalPlayers", this.aop);
		GUI.skin = null;
		GUI.Label(new Rect((float)(Screen.width / 2 - 60), (float)(Screen.height / 2 - 115), 150f, 75f), "Number Of Players");
		if (GUI.Button(new Rect((float)(Screen.width / 2 + 25), (float)(Screen.height / 2), 50f, 50f), "+"))
		{
			this.aop++;
		}
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 85), (float)(Screen.height / 2), 50f, 50f), "-"))
		{
			this.aop--;
		}
		GUI.skin = this.MenuSkin;
		if (this.aop > 6)
		{
			this.aop = 2;
		}
		if (this.aop < 2)
		{
			this.aop = 6;
		}
	}

	// Token: 0x06001105 RID: 4357 RVA: 0x0006C5D8 File Offset: 0x0006A9D8
	private void Settings()
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
		if (GUI.Button(new Rect((float)(Screen.width - 130), 130f, 120f, 25f), "700x540"))
		{
			Screen.SetResolution(700, 540, false);
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
		if (GUI.Button(new Rect((float)(Screen.width - 130), 305f, 120f, 25f), "1920x1080"))
		{
			Screen.SetResolution(1920, 1080, false);
		}
		Screen.fullScreen = this.fullscreen;
		this.fullscreen = GUI.Toggle(new Rect(10f, 290f, 110f, 30f), this.fullscreen, "Full-Screen");
		this.Anaglyph3d = GUI.Toggle(new Rect(10f, 320f, 130f, 30f), this.Anaglyph3d, "3D Anaglyph Mode");
		this.OVRMode = GUI.Toggle(new Rect(10f, 350f, 130f, 30f), this.OVRMode, "Oculus Rift Mode");
		this.showbloom = GUI.Toggle(new Rect(10f, 380f, 110f, 30f), this.showbloom, "Bloom Effect");
		this.motionblur = GUI.Toggle(new Rect(10f, 410f, 110f, 30f), this.motionblur, "Motion Blur");
		this.showhud = GUI.Toggle(new Rect(10f, 440f, 110f, 30f), this.showhud, "Display HUD");
		GUI.Box(new Rect(175f, 100f, 210f, 60f), string.Empty);
		GUI.Label(new Rect(230f, 100f, 140f, 25f), "Mouse Sensitivity");
		this.sensitivity = GUI.HorizontalSlider(new Rect(180f, 130f, 200f, 25f), this.sensitivity, 0f, 20f);
		GUI.Box(new Rect(175f, 170f, 270f, 100f), string.Empty);
		GUI.Label(new Rect(180f, 170f, 250f, 25f), "Multiplayer Photon Server ID:");
		if (GUI.Button(new Rect(180f, 195f, 82f, 25f), "Main Server"))
		{
			this.customserver = false;
			CryptoPlayerPrefs.SetInt("customserver", 1);
		}
		if (GUI.Button(new Rect(265f, 195f, 102f, 25f), "Custom Server"))
		{
			this.serverid = string.Empty;
			this.customserver = true;
			CryptoPlayerPrefs.SetInt("customserver", 2);
		}
		if (this.customserver)
		{
			this.serverid = GUI.TextField(new Rect(180f, 230f, 260f, 25f), this.serverid);
		}
		this.sensitivity = GUI.HorizontalSlider(new Rect(180f, 130f, 200f, 25f), this.sensitivity, 0f, 20f);
		GUI.skin = this.MenuSkin;
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
			this.CurrentState = new TestGUI.GUIState(this.MainMenu);
			base.StartCoroutine(this.SettingsToMenu());
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

	// Token: 0x06001106 RID: 4358 RVA: 0x0006CD78 File Offset: 0x0006B178
	private void Credits()
	{
		GUI.skin = this.SettingsSkin;
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), (float)(Screen.height / 2 + 195), 100f, 25f), "Controls"))
		{
			this.controls = true;
		}
		if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2 + 195), 100f, 25f), "Credits"))
		{
			this.controls = false;
		}
		if (!this.controls)
		{
			GUI.skin = this.SettingsSkin;
			this.scrollPosition = GUI.BeginScrollView(new Rect(30f, 100f, (float)(Screen.width - 60), (float)(Screen.height - 200)), this.scrollPosition, new Rect(0f, 0f, (float)(Screen.width - 200), 1350f));
			GUI.Label(new Rect(30f, 0f, (float)(Screen.width - 60), 100f), "Created By:\nSean Toman\n\nWebsite:\nHttp://www.zeoworks.com/");
			GUI.DrawTexture(new Rect(10f, 90f, 230f, 100f), this.zeologo);
			GUI.Label(new Rect(30f, 200f, (float)(Screen.width - 60), 1200f), this.credits);
			GUI.EndScrollView();
		}
		else
		{
			this.scrollPosition = GUI.BeginScrollView(new Rect(30f, 100f, (float)(Screen.width - 60), (float)(Screen.height - 200)), this.scrollPosition, new Rect(0f, 0f, (float)(Screen.width - 200), 1200f));
			GUI.Label(new Rect(30f, 0f, (float)(Screen.width - 60), 1200f), this.controlstext);
			GUI.EndScrollView();
		}
		GUI.skin = this.MenuSkin;
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 37), (float)(Screen.height / 2 + 220), 75f, 25f), "Back"))
		{
			this.CurrentState = new TestGUI.GUIState(this.MainMenu);
			base.StartCoroutine(this.CreditsToMenu());
		}
	}

	// Token: 0x06001107 RID: 4359 RVA: 0x0006CFD4 File Offset: 0x0006B3D4
	private void CreatorOptions()
	{
		GUI.skin = this.MenuWindowSkin;
		GUI.Box(new Rect((float)(Screen.width / 2 - 230), (float)(Screen.height / 2 - 95), 400f, 260f), string.Empty);
		GUI.BeginGroup(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 50), 320f, 425f));
		string str;
		if (CryptoPlayerPrefs.GetString("E410675", string.Empty) == this._STRING)
		{
			str = string.Empty;
		}
		else
		{
			str = " (Must Login)";
		}
		if (GUI.Button(new Rect(20f, 20f, 300f, 25f), "Create Or Load A Story/Level"))
		{
			this.CurrentState = new TestGUI.GUIState(this.NewStoryOptions);
		}
		if (GUI.Button(new Rect(20f, 55f, 300f, 25f), "Obj To Model Converter" + str) && CryptoPlayerPrefs.GetString("E410675", string.Empty) == this._STRING)
		{
			Application.LoadLevel("ModelConverter");
		}
		if (GUI.Button(new Rect(20f, 90f, 300f, 25f), "Build A Standalone Game" + str) && CryptoPlayerPrefs.GetString("E410675", string.Empty) == this._STRING)
		{
			this.CurrentState = new TestGUI.GUIState(this.NotInGame);
			Application.LoadLevel("StandaloneBuilder");
			base.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 125f, 300f, 25f), "Back"))
		{
			this.CurrentState = new TestGUI.GUIState(this.NotInGame);
			Application.LoadLevel("MainMenu");
			base.gameObject.GetComponent<database>().enabled = true;
			base.enabled = false;
		}
		GUI.EndGroup();
	}

	// Token: 0x06001108 RID: 4360 RVA: 0x0006D1E4 File Offset: 0x0006B5E4
	private void NewStoryOptions()
	{
		GUI.skin = this.MenuWindowSkin;
		GUI.Box(new Rect((float)(Screen.width / 2 - 180), (float)(Screen.height / 2 - 95), 300f, 220f), string.Empty);
		GUI.BeginGroup(new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height / 2 - 50), 320f, 425f));
		if (!this._ingame)
		{
			if (GUI.Button(new Rect(20f, 20f, 200f, 25f), "New Story"))
			{
				Application.LoadLevel("MapMaker");
				this.CurrentState = new TestGUI.GUIState(this.InGame);
			}
			if (GUI.Button(new Rect(20f, 55f, 200f, 25f), "Load Story"))
			{
				this._menuOption = "Load";
				this._refreshSavesList = true;
				this.CurrentState = new TestGUI.GUIState(this.LoadSaveMenu);
			}
			if (GUI.Button(new Rect(20f, 90f, 200f, 25f), "Back"))
			{
				this.CurrentState = new TestGUI.GUIState(this.NotInGame);
				Application.LoadLevel("MainMenu");
				base.gameObject.GetComponent<database>().enabled = true;
				base.enabled = false;
			}
		}
		else
		{
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(MouseLook));
			foreach (MouseLook mouseLook in array)
			{
				mouseLook.enabled = false;
			}
			if (CryptoPlayerPrefs.GetString("E410675", string.Empty) == this._STRING)
			{
				string empty = string.Empty;
			}
			if (GUI.Button(new Rect(20f, 0f, 200f, 25f), "Back to Scene"))
			{
				this.CurrentState = new TestGUI.GUIState(this.InGame);
			}
			if (GUI.Button(new Rect(20f, 35f, 200f, 25f), "Save Story"))
			{
				if (CryptoPlayerPrefs.GetString("E410675", string.Empty) == this._STRING)
				{
					this._menuOption = "Save";
					this._refreshSavesList = true;
					this.CurrentState = new TestGUI.GUIState(this.LoadSaveMenu);
				}
				else
				{
					int num = 0;
					ModelProperties[] array3 = UnityEngine.Object.FindObjectsOfType(typeof(ModelProperties)) as ModelProperties[];
					foreach (ModelProperties modelProperties in array3)
					{
						if (modelProperties.name.Contains("model"))
						{
							num++;
						}
					}
					if (num <= int.Parse(this._STRING2))
					{
						this._menuOption = "Save";
						this._refreshSavesList = true;
						this.CurrentState = new TestGUI.GUIState(this.LoadSaveMenu);
					}
				}
			}
			if (GUI.Button(new Rect(20f, 70f, 200f, 25f), "Load Story"))
			{
				this._menuOption = "Load";
				this._refreshSavesList = true;
				this.CurrentState = new TestGUI.GUIState(this.LoadSaveMenu);
			}
			if (GUI.Button(new Rect(20f, 105f, 200f, 25f), "Quit to Main Menu"))
			{
				this.CurrentState = new TestGUI.GUIState(this.NotInGame);
				Application.LoadLevel("MainMenu");
				base.gameObject.GetComponent<database>().enabled = true;
				base.enabled = false;
			}
		}
		GUI.EndGroup();
	}

	// Token: 0x06001109 RID: 4361 RVA: 0x0006D5AC File Offset: 0x0006B9AC
	private void LoadSaveMenu()
	{
		if (this._refreshSavesList)
		{
			this.Saves = UniSave.GetSaves();
			this._refreshSavesList = false;
		}
		int num = this.Saves.Length;
		int num2 = 0;
		this._selStrings = new string[num];
		if (this.Saves.Length > 0)
		{
			this._saveFileInfoText = Environment.NewLine + this.Saves[this._selectedSaveIndex].Name + Environment.NewLine + this.Saves[this._selectedSaveIndex].Date;
			this.newstory = this.Saves[this._selectedSaveIndex].Name;
		}
		else
		{
			this._saveFileInfoText = string.Empty;
		}
		this.newstory = this.Saves[this._selectedSaveIndex].Name;
		if (this.curstory != this.newstory)
		{
			base.gameObject.GetComponent<LoadDescription>().newstory = this.newstory;
			this.curstory = this.newstory;
		}
		GUI.skin = this.LevelSelector;
		GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 270), (float)(Screen.height / 2 - 202), 200f, 140f), this.storyimage);
		GUI.Box(new Rect(0f, (float)(Screen.height / 2 - 52), (float)(Screen.width - 330), (float)(Screen.height / 2 - 32)), "Description");
		GUI.Box(new Rect(0f, (float)(Screen.height - 75), (float)(Screen.width - 330), 75f), this._saveFileInfoText);
		this._scrollViewVector2 = GUI.BeginScrollView(new Rect(10f, (float)(Screen.height / 2 - 32), (float)(Screen.width - 350), (float)(Screen.height / 2 - 62)), this._scrollViewVector2, new Rect(0f, (float)(Screen.height / 2 - 52), (float)(Screen.width - 370), 1000f), false, false);
		GUI.Label(new Rect(0f, (float)(Screen.height / 2 - 32), (float)(Screen.width - 360), 2000f), this.description);
		GUI.EndScrollView();
		GUI.BeginGroup(new Rect((float)(Screen.width - 325), (float)(Screen.height - 75), 300f, 75f));
		GUI.EndGroup();
		GUI.skin = this.LevelSelector;
		if (this._menuOption == "Load")
		{
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 70), (float)(Screen.height / 2 - 152), 75f, 30f), this.playload) && this.Saves.Length > 0)
			{
				UniSave.Load(this.Saves[this._selectedSaveIndex].Name);
				this.CurrentState = new TestGUI.GUIState(this.InGame);
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 70), (float)(Screen.height / 2 - 122), 75f, 30f), "Delete") && this.Saves.Length > 0 && !this._showDeletePrompt)
			{
				this._showDeletePrompt = true;
			}
		}
		if (this._showDeletePrompt)
		{
			GUILayout.Window(0, new Rect((float)(Screen.width / 2 - 750), (float)(Screen.height / 2 - 100), 500f, 200f), new GUI.WindowFunction(this.DeletePrompt), "Are you sure you want to delete \"" + this.Saves[this._selectedSaveIndex].Name + "\"?", new GUILayoutOption[0]);
		}
		else if (this._menuOption == "Save")
		{
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 70), (float)(Screen.height / 2 - 152), 75f, 30f), "New Save") && !this._showNewSaveWindow)
			{
				this._showNewSaveWindow = true;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 70), (float)(Screen.height / 2 - 122), 75f, 30f), "Overwrite") && this.Saves.Length > 0 && !this._showOverwritePrompt)
			{
				this._showOverwritePrompt = true;
			}
		}
		if (this._showNewSaveWindow)
		{
			this._showOverwritePrompt = false;
			GUILayout.Window(0, new Rect((float)(Screen.width - 320), (float)(Screen.height - 150), 320f, 150f), new GUI.WindowFunction(this.NewSaveWindow), "New Save", new GUILayoutOption[0]);
		}
		if (this._showOverwritePrompt)
		{
			this._showNewSaveWindow = false;
			GUILayout.Window(0, new Rect((float)(Screen.width - 320), (float)(Screen.height - 100), 320f, 100f), new GUI.WindowFunction(this.OverwriteWindow), "Overwrite \"" + this.Saves[this._selectedSaveIndex].Name + "\"?", new GUILayoutOption[0]);
		}
		int num3 = Screen.height / 2 - 212;
		GUI.BeginGroup(new Rect((float)(Screen.width - 325), (float)(Screen.height / 2 - 212), 320f, (float)(Screen.height - num3)));
		this._scrollViewVector = GUI.BeginScrollView(new Rect(0f, 10f, 320f, 350f), this._scrollViewVector, new Rect(0f, 0f, 300f, (float)(Screen.height - num3 + (this._amountOfElements - 5) * 70)), false, false);
		this._amountOfElements = 0;
		foreach (SaveFileInfo saveFileInfo in this.Saves)
		{
			this._selStrings[num2] = Environment.NewLine + saveFileInfo.Name + Environment.NewLine + Environment.NewLine;
			this._amountOfElements++;
			num2++;
		}
		GUILayout.BeginArea(new Rect(10f, 0f, 280f, (float)(Screen.height - num3 + (this._amountOfElements - 5) * 70)));
		this._selectedSaveIndex = GUILayout.SelectionGrid(this._selectedSaveIndex, this._selStrings, 1, new GUILayoutOption[0]);
		GUILayout.EndArea();
		GUI.EndScrollView();
		GUI.EndGroup();
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 70), (float)(Screen.height / 2 - 92), 75f, 30f), "Back"))
		{
			if ((CryptoPlayerPrefs.GetInt("Mode", 0) == 4 && GameObject.Find("isMenu") == null) || (CryptoPlayerPrefs.GetInt("Mode", 0) == 5 && GameObject.Find("isMenu") == null))
			{
				this.CurrentState = new TestGUI.GUIState(this.InGame);
			}
			else
			{
				this.CurrentState = new TestGUI.GUIState(this.MainMenu);
			}
		}
	}

	// Token: 0x0600110A RID: 4362 RVA: 0x0006DCE4 File Offset: 0x0006C0E4
	private void DeletePrompt(int windowID)
	{
		if (GUILayout.Button("Yes", new GUILayoutOption[0]))
		{
			UniSave.Delete(this.Saves[this._selectedSaveIndex].Name);
			if (this._selectedSaveIndex > 0)
			{
				this._selectedSaveIndex--;
			}
			this._refreshSavesList = true;
			this._showDeletePrompt = false;
		}
		else if (GUILayout.Button("No", new GUILayoutOption[0]))
		{
			this._showDeletePrompt = false;
		}
	}

	// Token: 0x0600110B RID: 4363 RVA: 0x0006DD68 File Offset: 0x0006C168
	private void OverwriteWindow(int windowID)
	{
		if (GUILayout.Button("Yes", new GUILayoutOption[0]))
		{
			UniSave.Save(this.Saves[this._selectedSaveIndex].Name);
			this._showOverwritePrompt = false;
		}
		else if (GUILayout.Button("No", new GUILayoutOption[0]))
		{
			this._showOverwritePrompt = false;
		}
	}

	// Token: 0x0600110C RID: 4364 RVA: 0x0006DDCC File Offset: 0x0006C1CC
	private void NewSaveWindow(int windowID)
	{
		this._newSaveName = GUILayout.TextField(this._newSaveName, 200, new GUILayoutOption[0]);
		if (GUILayout.Button("Save", new GUILayoutOption[0]) && !string.IsNullOrEmpty(this._newSaveName))
		{
			UniSave.Save(this._newSaveName);
			this._newSaveName = string.Empty;
			this._showNewSaveWindow = false;
		}
		if (GUILayout.Button("Cancel", new GUILayoutOption[0]))
		{
			this._showNewSaveWindow = false;
		}
	}

	// Token: 0x0600110D RID: 4365 RVA: 0x0006DE54 File Offset: 0x0006C254
	private void ErrorPrompt()
	{
		GUI.Box(new Rect(0f, (float)(Screen.height / 2 - 100), (float)Screen.width, 50f), "Loading failed:" + Environment.NewLine + this._errorMessage);
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height / 2 + 75), 100f, 50f), "Back"))
		{
			UnityEngine.Object.Destroy(Loading.Instance.gameObject);
			Application.LoadLevel("Menu");
			this._ingame = false;
			this.CurrentState = new TestGUI.GUIState(this.MainMenu);
		}
	}

	// Token: 0x0600110E RID: 4366 RVA: 0x0006DF04 File Offset: 0x0006C304
	private void OnGUI()
	{
		GUI.skin = this.MenuSkin;
		this.CurrentState();
		if (!this._ingame)
		{
			GUI.skin = this.MenuSkin;
			GUI.Label(new Rect((float)(Screen.width / 2 - 45), 85f, 350f, 350f), "Reborn");
			GUI.skin = this.SettingsSkin;
			if (GUI.Button(new Rect((float)(Screen.width - 150), (float)(Screen.height - 50), 150f, 25f), "ZeoWorks Website"))
			{
				Application.OpenURL("http://zeoworks.com/");
			}
			if (GUI.Button(new Rect((float)(Screen.width - 150), (float)(Screen.height - 25), 150f, 25f), "Facebook"))
			{
				Application.OpenURL("https://www.facebook.com/zeoworksofficial");
			}
		}
		GUI.skin = null;
		while (UniSave.IsSaving)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height / 2 - 20), 100f, 40f), "Saving...", this._textStyle);
		}
		if (this._showSaveCompletedText)
		{
			if ((DateTime.Now - this._startTime).Seconds < 4)
			{
				this._refreshSavesList = true;
			}
			else
			{
				this._showSaveCompletedText = false;
			}
		}
	}

	// Token: 0x0600110F RID: 4367 RVA: 0x0006E071 File Offset: 0x0006C471
	private void UniSave_OnLoadingFailed(Exception exception)
	{
		this._errorMessage = exception.Message;
		this.CurrentState = new TestGUI.GUIState(this.ErrorPrompt);
	}

	// Token: 0x06001110 RID: 4368 RVA: 0x0006E091 File Offset: 0x0006C491
	private void UniSave_OnSavingCompleted()
	{
		this._startTime = DateTime.Now;
		this._showSaveCompletedText = true;
	}

	// Token: 0x06001111 RID: 4369 RVA: 0x0006E0A5 File Offset: 0x0006C4A5
	private void OnLevelWasLoaded()
	{
	}

	// Token: 0x04001185 RID: 4485
	public Vector2 scrollPosition = Vector2.zero;

	// Token: 0x04001186 RID: 4486
	public GUISkin MenuSkin;

	// Token: 0x04001187 RID: 4487
	public GUISkin MenuWindowSkin;

	// Token: 0x04001188 RID: 4488
	public GUISkin LevelSelector;

	// Token: 0x04001189 RID: 4489
	public GUISkin SettingsSkin;

	// Token: 0x0400118A RID: 4490
	public static TestGUI Instance;

	// Token: 0x0400118B RID: 4491
	public TestGUI.GUIState CurrentState;

	// Token: 0x0400118C RID: 4492
	public bool Anaglyph3d;

	// Token: 0x0400118D RID: 4493
	public bool OVRMode;

	// Token: 0x0400118E RID: 4494
	public GameObject characterselection;

	// Token: 0x0400118F RID: 4495
	private bool _ingame;

	// Token: 0x04001190 RID: 4496
	private Vector2 _scrollViewVector = Vector2.zero;

	// Token: 0x04001191 RID: 4497
	private Vector2 _scrollViewVector2 = Vector2.zero;

	// Token: 0x04001192 RID: 4498
	private string[] _selStrings;

	// Token: 0x04001193 RID: 4499
	private string _saveFileInfoText;

	// Token: 0x04001194 RID: 4500
	public int _selectedSaveIndex;

	// Token: 0x04001195 RID: 4501
	public string curstory;

	// Token: 0x04001196 RID: 4502
	public string newstory;

	// Token: 0x04001197 RID: 4503
	public string description;

	// Token: 0x04001198 RID: 4504
	public Texture2D storyimage;

	// Token: 0x04001199 RID: 4505
	private int _amountOfElements;

	// Token: 0x0400119A RID: 4506
	public string o10;

	// Token: 0x0400119B RID: 4507
	private bool _showDeletePrompt;

	// Token: 0x0400119C RID: 4508
	private bool _showOverwritePrompt;

	// Token: 0x0400119D RID: 4509
	private bool _showSavingPrompt;

	// Token: 0x0400119E RID: 4510
	private bool _showNewSaveWindow;

	// Token: 0x0400119F RID: 4511
	private string _newSaveName = string.Empty;

	// Token: 0x040011A0 RID: 4512
	private string _menuOption;

	// Token: 0x040011A1 RID: 4513
	private bool _refreshSavesList;

	// Token: 0x040011A2 RID: 4514
	public SaveFileInfo[] Saves;

	// Token: 0x040011A3 RID: 4515
	public string credits;

	// Token: 0x040011A4 RID: 4516
	public Texture2D zeologo;

	// Token: 0x040011A5 RID: 4517
	private string _errorMessage;

	// Token: 0x040011A6 RID: 4518
	public int aop = 2;

	// Token: 0x040011A7 RID: 4519
	public bool fullscreen;

	// Token: 0x040011A8 RID: 4520
	public bool showbloom;

	// Token: 0x040011A9 RID: 4521
	public bool motionblur;

	// Token: 0x040011AA RID: 4522
	public bool showhud;

	// Token: 0x040011AB RID: 4523
	public float sensitivity;

	// Token: 0x040011AC RID: 4524
	private GUIStyle _textStyle;

	// Token: 0x040011AD RID: 4525
	private bool _showSaveCompletedText;

	// Token: 0x040011AE RID: 4526
	private DateTime _startTime;

	// Token: 0x040011AF RID: 4527
	private DateTime _endTime;

	// Token: 0x040011B0 RID: 4528
	public string multiplayer = "Multi-Player";

	// Token: 0x040011B1 RID: 4529
	public string storycreator = "Story/Game Creator";

	// Token: 0x040011B2 RID: 4530
	public string playload = "Load";

	// Token: 0x040011B3 RID: 4531
	public bool controls;

	// Token: 0x040011B4 RID: 4532
	public string controlstext;

	// Token: 0x040011B5 RID: 4533
	protected string _STRING;

	// Token: 0x040011B6 RID: 4534
	protected string _STRING2;

	// Token: 0x040011B7 RID: 4535
	public string serverid;

	// Token: 0x040011B8 RID: 4536
	public bool customserver;

	// Token: 0x040011B9 RID: 4537
	public Rect windowRect = new Rect(20f, 20f, 120f, 50f);

	// Token: 0x040011BA RID: 4538
	public Rect windowRect2 = new Rect(20f, 20f, 120f, 50f);

	// Token: 0x040011BB RID: 4539
	public Transform creditsscreen;

	// Token: 0x040011BC RID: 4540
	public Transform mainscreen;

	// Token: 0x040011BD RID: 4541
	public Transform settingsscreen;

	// Token: 0x040011BE RID: 4542
	public string version;

	// Token: 0x0200025D RID: 605
	// (Invoke) Token: 0x06001113 RID: 4371
	public delegate void GUIState();
}
