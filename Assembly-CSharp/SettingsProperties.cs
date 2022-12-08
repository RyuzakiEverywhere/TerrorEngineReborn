using System;
using UnityEngine;

// Token: 0x020000ED RID: 237
public class SettingsProperties : MonoBehaviour
{
	// Token: 0x06000471 RID: 1137 RVA: 0x00033A30 File Offset: 0x00031E30
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3 || CryptoPlayerPrefs.GetInt("Mode", 0) == 21)
		{
			base.enabled = false;
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			GameObject.Find("EditorCam").gameObject.SetActive(false);
		}
		this.npcgrid = GameObject.Find("NPCGrid");
		this.npcgrid.gameObject.SetActive(false);
		if (false || !this.useinv)
		{
			this.useinv = false;
		}
		if (false || !this.usesunshine)
		{
			this.usesunshine = false;
			this.rsun = 1f;
			this.gsun = 1f;
			this.bsun = 1f;
			this.rsunlight = 0.5f;
			this.gsunlight = 0.5f;
			this.bsunlight = 0.5f;
			this.sunrotx = "25";
			this.sunroty = "180";
			this.sunrotz = "0";
		}
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x00033B98 File Offset: 0x00031F98
	private void Start()
	{
		if ((CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5) && this.lockstory && this.authorname != CryptoPlayerPrefs.GetString("E602397", string.Empty))
		{
			Application.LoadLevel(0);
		}
		if (false || !this.usesunshine)
		{
			this.usesunshine = false;
			this.rsun = 1f;
			this.gsun = 1f;
			this.bsun = 1f;
			this.rsunlight = 0.5f;
			this.gsunlight = 0.5f;
			this.bsunlight = 0.5f;
			this.sunrotx = "25";
			this.sunroty = "180";
			this.sunrotz = "0";
		}
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x00033C74 File Offset: 0x00032074
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.x = base.transform.position.x;
		position.y = base.transform.position.y;
		position.z = (float)this.gridsize;
		base.transform.position = position;
		if ((this.authorname == null || this.authorname == string.Empty) && (CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5))
		{
			this.authorname = CryptoPlayerPrefs.GetString("E602397", string.Empty);
		}
		if (this.gameovername == null || this.gameovername == string.Empty)
		{
			this.gameovername = " ";
			this.winname = " ";
		}
		if (this.footsteps == null || this.footsteps == string.Empty)
		{
			this.footsteps = "footsteps.wav";
		}
		RenderSettings.ambientLight = new Color(this.rlight, this.glight, this.blight);
		if (this.objplayer == null)
		{
			this.objplayer = GameObject.FindWithTag("editorobj");
			this.rainobj = GameObject.Find("Rain").transform;
			this.dustobj = GameObject.Find("Dust").transform;
			this.flurriesobj = GameObject.Find("Flurries").transform;
			this.snowobj = GameObject.Find("Snow").transform;
			this.hailobj = GameObject.Find("Hail").transform;
		}
		else
		{
			if (this.Crease)
			{
				this.objplayer.GetComponent<Crease>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<Crease>().enabled = false;
			}
			if (this.blur)
			{
				this.objplayer.GetComponent<Blur>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<Blur>().enabled = false;
			}
			if (this.greyscale)
			{
				this.objplayer.GetComponent<GrayscaleEffect>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<GrayscaleEffect>().enabled = false;
			}
			if (this.sepiatone)
			{
				this.objplayer.GetComponent<SepiaToneEffect>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<SepiaToneEffect>().enabled = false;
			}
			if (this.noise)
			{
				this.objplayer.GetComponent<NoiseEffect>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<NoiseEffect>().enabled = false;
			}
			if (this.enhancecontrast)
			{
				this.objplayer.GetComponent<ContrastEnhance>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<ContrastEnhance>().enabled = false;
			}
			if (this.FakeSSAO)
			{
				this.objplayer.GetComponent<PP_FakeSSAO>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_FakeSSAO>().enabled = false;
			}
			if (this.CrossHatch)
			{
				this.objplayer.GetComponent<PP_CrossHatch>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_CrossHatch>().enabled = false;
			}
			if (this.Charcoal)
			{
				this.objplayer.GetComponent<PP_Charcoal>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Charcoal>().enabled = false;
			}
			if (this.FourBit)
			{
				this.objplayer.GetComponent<PP_4Bit>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_4Bit>().enabled = false;
			}
			if (this.SobelOutlineV2)
			{
				this.objplayer.GetComponent<PP_SobelOutlineV2>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_SobelOutlineV2>().enabled = false;
			}
			if (this.HDR)
			{
				this.objplayer.GetComponent<PP_HDR>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_HDR>().enabled = false;
			}
			if (this.LightWave)
			{
				this.objplayer.GetComponent<PP_LightWave>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_LightWave>().enabled = false;
			}
			if (this.SecurityCamera)
			{
				this.objplayer.GetComponent<PP_SecurityCamera>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_SecurityCamera>().enabled = false;
			}
			if (this.BlackAndWhite)
			{
				this.objplayer.GetComponent<PP_BlackAndWhite>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_BlackAndWhite>().enabled = false;
			}
			if (this.Holywood)
			{
				this.objplayer.GetComponent<PP_Holywood>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Holywood>().enabled = false;
			}
			if (this.RadialBlur)
			{
				this.objplayer.GetComponent<PP_RadialBlur>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_RadialBlur>().enabled = false;
			}
			if (this.Goodrays1)
			{
				this.objplayer.GetComponent<PP_Godrays1>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Godrays1>().enabled = false;
			}
			if (this.Amnesia)
			{
				this.objplayer.GetComponent<PP_Amnesia>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Amnesia>().enabled = false;
			}
			if (this.Noise)
			{
				this.objplayer.GetComponent<PP_Noise>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Noise>().enabled = false;
			}
			if (this.FoggyScreen)
			{
				this.objplayer.GetComponent<PP_FoggyScreen>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_FoggyScreen>().enabled = false;
			}
			if (this.ThermalVision)
			{
				this.objplayer.GetComponent<PP_ThermalVision>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_ThermalVision>().enabled = false;
			}
			if (this.NightVision)
			{
				this.objplayer.GetComponent<PP_NightVision>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_NightVision>().enabled = false;
			}
			if (this.Bleach)
			{
				this.objplayer.GetComponent<PP_Bleach>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Bleach>().enabled = false;
			}
			if (this.Scanlines)
			{
				this.objplayer.GetComponent<PP_Scanlines>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Scanlines>().enabled = false;
			}
			if (this.Vignette)
			{
				this.objplayer.GetComponent<PP_Vignette>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Vignette>().enabled = false;
			}
			if (this.Wiggle)
			{
				this.objplayer.GetComponent<PP_Wiggle>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Wiggle>().enabled = false;
			}
			if (this.SobelEdge)
			{
				this.objplayer.GetComponent<PP_SobelEdge>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_SobelEdge>().enabled = false;
			}
			if (this.SinCity)
			{
				this.objplayer.GetComponent<PP_SinCity>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_SinCity>().enabled = false;
			}
			if (this.Pulse)
			{
				this.objplayer.GetComponent<PP_Pulse>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Pulse>().enabled = false;
			}
			if (this.Posterize)
			{
				this.objplayer.GetComponent<PP_Posterize>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Posterize>().enabled = false;
			}
			if (this.Pixelated)
			{
				this.objplayer.GetComponent<PP_Pixelated>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Pixelated>().enabled = false;
			}
			if (this.Negative)
			{
				this.objplayer.GetComponent<PP_Negative>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Negative>().enabled = false;
			}
			if (this.LensCircle)
			{
				this.objplayer.GetComponent<PP_LensCircle>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_LensCircle>().enabled = false;
			}
			if (this.Frost)
			{
				this.objplayer.GetComponent<PP_Frost>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Frost>().enabled = false;
			}
			if (this.EdgeDetect)
			{
				this.objplayer.GetComponent<PP_EdgeDetect>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_EdgeDetect>().enabled = false;
			}
			if (this.Desaturate)
			{
				this.objplayer.GetComponent<PP_Desaturate>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_Desaturate>().enabled = false;
			}
			if (this.sa)
			{
				this.objplayer.GetComponent<PP_StereoAnaglyph_AmberBlue>().enabled = true;
			}
			else
			{
				this.objplayer.GetComponent<PP_StereoAnaglyph_AmberBlue>().enabled = false;
			}
			if (this.rain)
			{
				this.rainobj.gameObject.SetActive(true);
			}
			else
			{
				this.rainobj.gameObject.SetActive(false);
			}
			if (this.dust)
			{
				this.dustobj.gameObject.SetActive(true);
			}
			else
			{
				this.dustobj.gameObject.SetActive(false);
			}
			if (this.flurries)
			{
				this.flurriesobj.gameObject.SetActive(true);
			}
			else
			{
				this.flurriesobj.gameObject.SetActive(false);
			}
			if (this.hail)
			{
				this.hailobj.gameObject.SetActive(true);
			}
			else
			{
				this.hailobj.gameObject.SetActive(false);
			}
			if (this.snow)
			{
				this.snowobj.gameObject.SetActive(true);
			}
			else
			{
				this.snowobj.gameObject.SetActive(false);
			}
			if (this.skyboxnull)
			{
				RenderSettings.skybox = null;
			}
			if (this.skybox1)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Sunny2 Skybox") as Material);
			}
			if (this.skybox2)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Sunny3 Skybox") as Material);
			}
			if (this.skybox3)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Overcast2 Skybox") as Material);
			}
			if (this.skybox4)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Eerie Skybox") as Material);
			}
			if (this.skybox5)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/DawnDusk Skybox") as Material);
			}
			if (this.skybox6)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/MoonShine Skybox") as Material);
			}
			if (this.skybox7)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/StarryNight Skybox") as Material);
			}
			if (this.skybox8)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Black Skybox") as Material);
			}
		}
		if (this.shownpcgrid)
		{
			this.npcgrid.gameObject.SetActive(true);
		}
		else
		{
			this.npcgrid.gameObject.SetActive(false);
		}
		this.showgridsize = this.gridsize.ToString() + "x" + this.gridsize.ToString();
		GameObject.Find("EditorCam").GetComponent<Camera>().farClipPlane = this.fov;
		if (this.usesunshine)
		{
			this.sunshine.gameObject.gameObject.SetActive(true);
			Light component = this.sunshine.Find("Sunlight").GetComponent<Light>();
			component.transform.localEulerAngles = new Vector3(float.Parse(this.sunrotx), float.Parse(this.sunroty), float.Parse(this.sunrotz));
			component.color = new Color(this.rsunlight, this.gsunlight, this.bsunlight);
			this.sunshine.GetComponent<Sunshine>().ScatterColor = new Color(this.rsun, this.gsun, this.bsun);
		}
		else
		{
			this.sunshine.gameObject.gameObject.SetActive(false);
			this.usesunshine = false;
			this.rsun = 1f;
			this.gsun = 1f;
			this.bsun = 1f;
			this.rsunlight = 0.5f;
			this.gsunlight = 0.5f;
			this.bsunlight = 0.5f;
			this.sunrotx = "25";
			this.sunroty = "180";
			this.sunrotz = "0";
		}
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x0003495C File Offset: 0x00032D5C
	private void SettingsWindow(int windowID)
	{
		GUI.Box(new Rect(20f, 285f, 180f, 90f), "Game Mode");
		if (this.escape && GUI.Button(new Rect(52f, 320f, 120f, 20f), "Escape"))
		{
			this.collect = true;
			this.collectandescape = false;
			this.escape = false;
			this.killnpc = false;
		}
		if (this.collect && GUI.Button(new Rect(52f, 320f, 120f, 20f), "Collect"))
		{
			this.collect = false;
			this.collectandescape = true;
			this.escape = false;
			this.killnpc = false;
		}
		if (this.collectandescape && GUI.Button(new Rect(52f, 320f, 120f, 20f), "Collect & Escape"))
		{
			this.collect = false;
			this.collectandescape = false;
			this.escape = false;
			this.killnpc = true;
		}
		if (this.killnpc && GUI.Button(new Rect(52f, 320f, 120f, 20f), "Kill NPC & Escape"))
		{
			this.collect = false;
			this.collectandescape = false;
			this.escape = true;
			this.killnpc = false;
		}
		this.versus = GUI.Toggle(new Rect(30f, 350f, 160f, 20f), this.versus, "Versus (Multiplayer Only)");
		if (this.versus)
		{
			this.canrespawn = false;
		}
		GUI.Box(new Rect(220f, 45f, 230f, 330f), "Properties");
		GUI.Box(new Rect(20f, 45f, 180f, 215f), "Player Vision");
		if (GUI.Button(new Rect(40f, 80f, 140f, 20f), "Advanced Settings"))
		{
			this.showvisionmenu = true;
		}
		GUI.Label(new Rect(40f, 105f, 100f, 22f), "Fog Settings");
		GUI.Label(new Rect(40f, 125f, 60f, 22f), "Red:");
		this.rfog = GUI.HorizontalSlider(new Rect(100f, 127f, 90f, 22f), this.rfog, 0f, 1f);
		GUI.Label(new Rect(40f, 145f, 60f, 22f), "Green:");
		this.gfog = GUI.HorizontalSlider(new Rect(100f, 147f, 90f, 22f), this.gfog, 0f, 1f);
		GUI.Label(new Rect(40f, 165f, 60f, 22f), "Blue:");
		this.bfog = GUI.HorizontalSlider(new Rect(100f, 167f, 90f, 22f), this.bfog, 0f, 1f);
		GUI.Label(new Rect(40f, 185f, 60f, 22f), "Density:");
		this.fogdens = GUI.HorizontalSlider(new Rect(100f, 187f, 90f, 22f), this.fogdens, 0.001f, 0.3f);
		GUI.Label(new Rect(290f, 83f, 100f, 22f), "Skybox");
		if (this.skyboxnull && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Null"))
		{
			this.skyboxnull = false;
			this.skybox1 = true;
			this.skybox2 = false;
			this.skybox3 = false;
			this.skybox4 = false;
			this.skybox5 = false;
			this.skybox6 = false;
			this.skybox7 = false;
			this.sky = (Resources.Load("Skyboxes/Sunny2 Skybox") as Material);
			this.ChangeSky();
		}
		if (this.skybox1 && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Sunny 1"))
		{
			this.skyboxnull = false;
			this.skybox1 = false;
			this.skybox2 = true;
			this.skybox3 = false;
			this.skybox4 = false;
			this.skybox5 = false;
			this.skybox6 = false;
			this.skybox7 = false;
			this.skybox8 = false;
			this.sky = (Resources.Load("Skyboxes/Sunny3 Skybox") as Material);
			this.ChangeSky();
		}
		if (this.skybox2 && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Sunny 2"))
		{
			this.skyboxnull = false;
			this.skybox1 = false;
			this.skybox2 = false;
			this.skybox3 = true;
			this.skybox4 = false;
			this.skybox5 = false;
			this.skybox6 = false;
			this.skybox7 = false;
			this.skybox8 = false;
			this.sky = (Resources.Load("Skyboxes/Overcast2 Skybox") as Material);
			this.ChangeSky();
		}
		if (this.skybox3 && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Overcast 1"))
		{
			this.skyboxnull = false;
			this.skybox1 = false;
			this.skybox2 = false;
			this.skybox3 = false;
			this.skybox4 = true;
			this.skybox5 = false;
			this.skybox6 = false;
			this.skybox7 = false;
			this.skybox8 = false;
			this.sky = (Resources.Load("Skyboxes/Eerie Skybox") as Material);
			this.ChangeSky();
		}
		if (this.skybox4 && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Overcast 2"))
		{
			this.skyboxnull = false;
			this.skybox1 = false;
			this.skybox2 = false;
			this.skybox3 = false;
			this.skybox4 = false;
			this.skybox5 = true;
			this.skybox6 = false;
			this.skybox7 = false;
			this.skybox8 = false;
			this.sky = (Resources.Load("Skyboxes/DawnDusk Skybox") as Material);
			this.ChangeSky();
		}
		if (this.skybox5 && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Dusk"))
		{
			this.skyboxnull = false;
			this.skybox1 = false;
			this.skybox2 = false;
			this.skybox3 = false;
			this.skybox4 = false;
			this.skybox5 = false;
			this.skybox6 = true;
			this.skybox7 = false;
			this.skybox8 = false;
			this.sky = (Resources.Load("Skyboxes/MoonShine Skybox") as Material);
			this.ChangeSky();
		}
		if (this.skybox6 && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Night 1"))
		{
			this.skyboxnull = false;
			this.skybox1 = false;
			this.skybox2 = false;
			this.skybox3 = false;
			this.skybox4 = false;
			this.skybox5 = false;
			this.skybox6 = false;
			this.skybox7 = true;
			this.skybox8 = false;
			this.sky = (Resources.Load("Skyboxes/StarryNight Skybox") as Material);
			this.ChangeSky();
		}
		if (this.skybox7 && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Night 2"))
		{
			this.skyboxnull = false;
			this.skybox1 = false;
			this.skybox2 = false;
			this.skybox3 = false;
			this.skybox4 = false;
			this.skybox5 = false;
			this.skybox6 = false;
			this.skybox7 = false;
			this.skybox8 = true;
			this.sky = (Resources.Load("Skyboxes/Black") as Material);
			this.ChangeSky();
		}
		if (this.skybox8 && GUI.Button(new Rect(290f, 105f, 100f, 20f), "Black"))
		{
			this.skyboxnull = true;
			this.skybox1 = false;
			this.skybox2 = false;
			this.skybox3 = false;
			this.skybox4 = false;
			this.skybox5 = false;
			this.skybox6 = false;
			this.skybox7 = false;
			this.skybox8 = false;
			this.sky = null;
			this.ChangeSky();
		}
		GUI.Label(new Rect(290f, 135f, 100f, 22f), "Default Lighting");
		GUI.Label(new Rect(230f, 158f, 60f, 22f), "Red:");
		this.rlight = GUI.HorizontalSlider(new Rect(290f, 162f, 100f, 22f), this.rlight, 0f, 1f);
		GUI.Label(new Rect(230f, 178f, 60f, 22f), "Green:");
		this.glight = GUI.HorizontalSlider(new Rect(290f, 182f, 100f, 22f), this.glight, 0f, 1f);
		GUI.Label(new Rect(230f, 198f, 60f, 22f), "Blue:");
		this.blight = GUI.HorizontalSlider(new Rect(290f, 202f, 100f, 22f), this.blight, 0f, 1f);
		if (GUI.Button(new Rect(230f, 240f, 140f, 20f), "Volumetric Sunshine"))
		{
			this.showsunshinemenu = true;
		}
		GUI.Label(new Rect(230f, 280f, 60f, 22f), "Weather:");
		this.dust = GUI.Toggle(new Rect(230f, 300f, 75f, 22f), this.dust, "Dust");
		this.hail = GUI.Toggle(new Rect(230f, 320f, 75f, 22f), this.hail, "Hail");
		this.rain = GUI.Toggle(new Rect(230f, 340f, 75f, 22f), this.rain, "Rain");
		this.snow = GUI.Toggle(new Rect(305f, 300f, 75f, 22f), this.snow, "Snow");
		this.flurries = GUI.Toggle(new Rect(305f, 320f, 75f, 22f), this.flurries, "Flurries");
		GUI.Label(new Rect(40f, 220f, 120f, 22f), "Field Of View");
		this.fov = GUI.HorizontalSlider(new Rect(40f, 240f, 120f, 22f), this.fov, 0f, 500f);
		this.gridsize = 1000;
		if (this.shownpcgrid && this.ignorthis)
		{
			if (GUI.Button(new Rect(240f, 385f, 30f, 20f), "+"))
			{
				this.gridsize += 10;
			}
			if (GUI.Button(new Rect(210f, 385f, 30f, 20f), "-"))
			{
				this.gridsize -= 10;
			}
		}
		this.lockstory = GUI.Toggle(new Rect(300f, 355f, 140f, 22f), this.lockstory, "Lock Story To Author");
		GUI.Box(new Rect(20f, 385f, 430f, 80f), "Other");
		this.shownpcgrid = GUI.Toggle(new Rect(30f, 440f, 120f, 20f), this.shownpcgrid, "Show NPC Grid");
		if (this.shownpcgrid)
		{
			GUI.Label(new Rect(140f, 440f, 100f, 20f), this.showgridsize);
		}
		this.canrespawn = GUI.Toggle(new Rect(30f, 418f, 170f, 22f), this.canrespawn, "Can respawn (Multiplayer)");
		this.useinv = GUI.Toggle(new Rect(30f, 396f, 120f, 22f), this.useinv, "Inventory System");
		GUI.Label(new Rect(330f, 405f, 100f, 25f), "Camera Type");
		if (this.camtype == 0 && GUI.Button(new Rect(310f, 430f, 120f, 20f), "1st & 3rd Person"))
		{
			this.camtype = 1;
		}
		if (this.camtype == 1 && GUI.Button(new Rect(310f, 430f, 120f, 20f), "1st Person Only"))
		{
			this.camtype = 2;
		}
		if (this.camtype == 2 && GUI.Button(new Rect(310f, 430f, 120f, 20f), "3rd Person Only"))
		{
			this.camtype = 3;
		}
		if (this.camtype == 3 && GUI.Button(new Rect(310f, 430f, 120f, 20f), "Cinematic"))
		{
			this.camtype = 0;
		}
		if (GUI.Button(new Rect(340f, 475f, 120f, 20f), "Save Settings"))
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x00035796 File Offset: 0x00033B96
	private void ChangeSky()
	{
		RenderSettings.skybox = this.sky;
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x000357A4 File Offset: 0x00033BA4
	private void Vision(int windowID)
	{
		GUI.Box(new Rect(20f, 40f, 440f, 355f), "Camera Effects");
		this.Crease = GUI.Toggle(new Rect(40f, 80f, 100f, 22f), this.Crease, "Crease");
		this.blur = GUI.Toggle(new Rect(40f, 100f, 100f, 22f), this.blur, "Blur");
		this.greyscale = GUI.Toggle(new Rect(40f, 120f, 100f, 22f), this.greyscale, "Greyscale");
		this.sepiatone = GUI.Toggle(new Rect(40f, 140f, 100f, 22f), this.sepiatone, "Sepia Tone");
		this.noise = GUI.Toggle(new Rect(40f, 160f, 100f, 22f), this.noise, "Static");
		this.enhancecontrast = GUI.Toggle(new Rect(40f, 180f, 100f, 22f), this.enhancecontrast, "Enhance");
		this.FakeSSAO = GUI.Toggle(new Rect(40f, 200f, 100f, 22f), this.FakeSSAO, "Fake SSAO");
		this.CrossHatch = GUI.Toggle(new Rect(40f, 220f, 100f, 22f), this.CrossHatch, "Cross Hatch");
		this.Charcoal = GUI.Toggle(new Rect(40f, 240f, 100f, 22f), this.Charcoal, "Charcoal");
		this.FourBit = GUI.Toggle(new Rect(40f, 260f, 100f, 22f), this.FourBit, "4 Bit");
		this.SobelOutlineV2 = GUI.Toggle(new Rect(40f, 280f, 100f, 22f), this.SobelOutlineV2, "Cartoon");
		this.HDR = GUI.Toggle(new Rect(40f, 300f, 100f, 22f), this.HDR, "HDR");
		this.LightWave = GUI.Toggle(new Rect(40f, 320f, 100f, 22f), this.LightWave, "Light Wave");
		this.SecurityCamera = GUI.Toggle(new Rect(40f, 340f, 100f, 22f), this.SecurityCamera, "Camera");
		this.BlackAndWhite = GUI.Toggle(new Rect(40f, 360f, 100f, 22f), this.BlackAndWhite, "Black&White");
		this.Holywood = GUI.Toggle(new Rect(160f, 80f, 100f, 22f), this.Holywood, "Holywood");
		this.RadialBlur = GUI.Toggle(new Rect(160f, 100f, 100f, 22f), this.RadialBlur, "Radial Blur");
		this.Goodrays1 = GUI.Toggle(new Rect(160f, 120f, 100f, 22f), this.Goodrays1, "God Rays");
		this.Amnesia = GUI.Toggle(new Rect(160f, 140f, 100f, 22f), this.Amnesia, "Amnesia");
		this.FoggyScreen = GUI.Toggle(new Rect(160f, 160f, 100f, 22f), this.FoggyScreen, "Foggy Screen");
		this.ThermalVision = GUI.Toggle(new Rect(160f, 180f, 105f, 22f), this.ThermalVision, "Thermal Vision");
		this.NightVision = GUI.Toggle(new Rect(160f, 200f, 100f, 22f), this.NightVision, "Night Vision");
		this.Bleach = GUI.Toggle(new Rect(160f, 220f, 100f, 22f), this.Bleach, "Bleach");
		this.Scanlines = GUI.Toggle(new Rect(160f, 240f, 100f, 22f), this.Scanlines, "Scanlines");
		this.Vignette = GUI.Toggle(new Rect(160f, 260f, 100f, 22f), this.Vignette, "Vignette");
		this.Wiggle = GUI.Toggle(new Rect(160f, 280f, 100f, 22f), this.Wiggle, "Wiggle");
		this.SobelEdge = GUI.Toggle(new Rect(160f, 300f, 100f, 22f), this.SobelEdge, "Sobel Edge");
		this.SinCity = GUI.Toggle(new Rect(160f, 320f, 100f, 22f), this.SinCity, "Sin-City");
		this.Pulse = GUI.Toggle(new Rect(160f, 340f, 100f, 22f), this.Pulse, "Pulse");
		this.Noise = GUI.Toggle(new Rect(160f, 360f, 100f, 22f), this.Noise, "Noise");
		this.Posterize = GUI.Toggle(new Rect(280f, 80f, 100f, 22f), this.Posterize, "Posterize");
		this.Pixelated = GUI.Toggle(new Rect(280f, 100f, 100f, 22f), this.Pixelated, "Pixelated");
		this.Negative = GUI.Toggle(new Rect(280f, 120f, 100f, 22f), this.Negative, "Negative");
		this.LensCircle = GUI.Toggle(new Rect(280f, 140f, 100f, 22f), this.LensCircle, "Lens Circle");
		this.Frost = GUI.Toggle(new Rect(280f, 160f, 100f, 22f), this.Frost, "Frost");
		this.EdgeDetect = GUI.Toggle(new Rect(280f, 180f, 100f, 22f), this.EdgeDetect, "Edge Detect");
		this.Desaturate = GUI.Toggle(new Rect(280f, 200f, 100f, 22f), this.Desaturate, "Desaturate");
		this.sa = GUI.Toggle(new Rect(280f, 220f, 130f, 22f), this.sa, "Stereo Anaglyph");
		GUI.Label(new Rect(280f, 240f, 100f, 20f), "Game Over:");
		this.gameovername = GUI.TextField(new Rect(280f, 260f, 100f, 20f), this.gameovername);
		GUI.Label(new Rect(280f, 280f, 100f, 20f), "Win:");
		this.winname = GUI.TextField(new Rect(280f, 300f, 100f, 20f), this.winname);
		GUI.Label(new Rect(280f, 320f, 100f, 20f), "Footsteps:");
		this.footsteps = GUI.TextField(new Rect(280f, 340f, 100f, 20f), this.footsteps);
		if (GUI.Button(new Rect(340f, 410f, 120f, 20f), "Save / Back"))
		{
			this.showvisionmenu = false;
		}
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x00035FE4 File Offset: 0x000343E4
	private void SunShineMenu(int windowID)
	{
		GUI.Box(new Rect(20f, 40f, 300f, 395f), "Volumetric Properties");
		this.usesunshine = GUI.Toggle(new Rect(30f, 80f, 200f, 22f), this.usesunshine, "Use Volumetric Sunshine");
		GUI.Label(new Rect(50f, 115f, 100f, 22f), "Ray Color:");
		GUI.Label(new Rect(30f, 138f, 60f, 22f), "Red:");
		this.rsun = GUI.HorizontalSlider(new Rect(100f, 142f, 100f, 22f), this.rsun, 0f, 1f);
		GUI.Label(new Rect(30f, 158f, 60f, 22f), "Green:");
		this.gsun = GUI.HorizontalSlider(new Rect(100f, 162f, 100f, 22f), this.gsun, 0f, 1f);
		GUI.Label(new Rect(30f, 178f, 60f, 22f), "Blue:");
		this.bsun = GUI.HorizontalSlider(new Rect(100f, 182f, 100f, 22f), this.bsun, 0f, 1f);
		GUI.Label(new Rect(50f, 215f, 100f, 22f), "Light Color:");
		GUI.Label(new Rect(30f, 238f, 60f, 22f), "Red:");
		this.rsunlight = GUI.HorizontalSlider(new Rect(100f, 242f, 100f, 22f), this.rsunlight, 0f, 1f);
		GUI.Label(new Rect(30f, 258f, 60f, 22f), "Green:");
		this.gsunlight = GUI.HorizontalSlider(new Rect(100f, 262f, 100f, 22f), this.gsunlight, 0f, 1f);
		GUI.Label(new Rect(30f, 278f, 60f, 22f), "Blue:");
		this.bsunlight = GUI.HorizontalSlider(new Rect(100f, 282f, 100f, 22f), this.bsunlight, 0f, 1f);
		GUI.Label(new Rect(50f, 315f, 100f, 22f), "Sun Rotation:");
		GUI.Label(new Rect(30f, 338f, 60f, 22f), "X rot:");
		this.sunrotx = GUI.TextField(new Rect(100f, 340f, 100f, 20f), this.sunrotx);
		GUI.Label(new Rect(30f, 358f, 60f, 22f), "Y rot:");
		this.sunroty = GUI.TextField(new Rect(100f, 360f, 100f, 20f), this.sunroty);
		GUI.Label(new Rect(30f, 378f, 60f, 22f), "Z rot:");
		this.sunrotz = GUI.TextField(new Rect(100f, 380f, 100f, 20f), this.sunrotz);
		if (GUI.Button(new Rect(200f, 450f, 120f, 20f), "Save / Back"))
		{
			this.showsunshinemenu = false;
		}
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x000363CC File Offset: 0x000347CC
	private void OnGUI()
	{
		GUI.skin = this.skin;
		if (!this.showvisionmenu && !this.showsunshinemenu)
		{
			GUI.Window(6, new Rect(5f, 30f, 480f, 510f), new GUI.WindowFunction(this.SettingsWindow), "Story Settings");
		}
		if (this.showvisionmenu)
		{
			GUI.Window(7, new Rect(5f, 30f, 480f, 440f), new GUI.WindowFunction(this.Vision), "Advanced Settings");
		}
		if (this.showsunshinemenu)
		{
			GUI.Window(8, new Rect(5f, 30f, 340f, 480f), new GUI.WindowFunction(this.SunShineMenu), "Volumetric Sunshine");
		}
		RenderSettings.fogColor = new Color(this.rfog, this.gfog, this.bfog);
		RenderSettings.fogDensity = this.fogdens;
	}

	// Token: 0x040006C1 RID: 1729
	public GameObject objplayer;

	// Token: 0x040006C2 RID: 1730
	public GUISkin skin;

	// Token: 0x040006C3 RID: 1731
	public bool escape = true;

	// Token: 0x040006C4 RID: 1732
	public bool collect;

	// Token: 0x040006C5 RID: 1733
	public bool collectandescape;

	// Token: 0x040006C6 RID: 1734
	public bool killnpc;

	// Token: 0x040006C7 RID: 1735
	public bool versus;

	// Token: 0x040006C8 RID: 1736
	public bool skyboxnull = true;

	// Token: 0x040006C9 RID: 1737
	public bool skybox1;

	// Token: 0x040006CA RID: 1738
	public bool skybox2;

	// Token: 0x040006CB RID: 1739
	public bool skybox3;

	// Token: 0x040006CC RID: 1740
	public bool skybox4;

	// Token: 0x040006CD RID: 1741
	public bool skybox5;

	// Token: 0x040006CE RID: 1742
	public bool skybox6;

	// Token: 0x040006CF RID: 1743
	public bool skybox7;

	// Token: 0x040006D0 RID: 1744
	public bool skybox8;

	// Token: 0x040006D1 RID: 1745
	public Material sky;

	// Token: 0x040006D2 RID: 1746
	public float rlight = 25f;

	// Token: 0x040006D3 RID: 1747
	public float glight = 25f;

	// Token: 0x040006D4 RID: 1748
	public float blight = 25f;

	// Token: 0x040006D5 RID: 1749
	public bool dust;

	// Token: 0x040006D6 RID: 1750
	public bool hail;

	// Token: 0x040006D7 RID: 1751
	public bool rain;

	// Token: 0x040006D8 RID: 1752
	public bool snow;

	// Token: 0x040006D9 RID: 1753
	public bool flurries;

	// Token: 0x040006DA RID: 1754
	public bool Crease;

	// Token: 0x040006DB RID: 1755
	public bool blur;

	// Token: 0x040006DC RID: 1756
	public bool greyscale;

	// Token: 0x040006DD RID: 1757
	public bool sepiatone;

	// Token: 0x040006DE RID: 1758
	public bool noise;

	// Token: 0x040006DF RID: 1759
	public bool enhancecontrast;

	// Token: 0x040006E0 RID: 1760
	public float fov = 50f;

	// Token: 0x040006E1 RID: 1761
	public bool nofog = true;

	// Token: 0x040006E2 RID: 1762
	public bool fargrey;

	// Token: 0x040006E3 RID: 1763
	public bool farblack;

	// Token: 0x040006E4 RID: 1764
	public bool neargrey;

	// Token: 0x040006E5 RID: 1765
	public bool nearblack;

	// Token: 0x040006E6 RID: 1766
	public Transform dustobj;

	// Token: 0x040006E7 RID: 1767
	public Transform flurriesobj;

	// Token: 0x040006E8 RID: 1768
	public Transform hailobj;

	// Token: 0x040006E9 RID: 1769
	public Transform rainobj;

	// Token: 0x040006EA RID: 1770
	public Transform snowobj;

	// Token: 0x040006EB RID: 1771
	public GameObject npcgrid;

	// Token: 0x040006EC RID: 1772
	private bool shownpcgrid;

	// Token: 0x040006ED RID: 1773
	public int gridsize = 1000;

	// Token: 0x040006EE RID: 1774
	public string showgridsize;

	// Token: 0x040006EF RID: 1775
	public bool ignorthis;

	// Token: 0x040006F0 RID: 1776
	public bool showvisionmenu;

	// Token: 0x040006F1 RID: 1777
	public bool showsunshinemenu;

	// Token: 0x040006F2 RID: 1778
	public float rfog = 25f;

	// Token: 0x040006F3 RID: 1779
	public float gfog = 25f;

	// Token: 0x040006F4 RID: 1780
	public float bfog = 25f;

	// Token: 0x040006F5 RID: 1781
	public float fogdens = 0.001f;

	// Token: 0x040006F6 RID: 1782
	public bool FakeSSAO;

	// Token: 0x040006F7 RID: 1783
	public bool CrossHatch;

	// Token: 0x040006F8 RID: 1784
	public bool Charcoal;

	// Token: 0x040006F9 RID: 1785
	public bool FourBit;

	// Token: 0x040006FA RID: 1786
	public bool SobelOutlineV2;

	// Token: 0x040006FB RID: 1787
	public bool HDR;

	// Token: 0x040006FC RID: 1788
	public bool LightWave;

	// Token: 0x040006FD RID: 1789
	public bool SecurityCamera;

	// Token: 0x040006FE RID: 1790
	public bool BlackAndWhite;

	// Token: 0x040006FF RID: 1791
	public bool Holywood;

	// Token: 0x04000700 RID: 1792
	public bool RadialBlur;

	// Token: 0x04000701 RID: 1793
	public bool Goodrays1;

	// Token: 0x04000702 RID: 1794
	public bool Amnesia;

	// Token: 0x04000703 RID: 1795
	public bool Noise;

	// Token: 0x04000704 RID: 1796
	public bool FoggyScreen;

	// Token: 0x04000705 RID: 1797
	public bool ThermalVision;

	// Token: 0x04000706 RID: 1798
	public bool NightVision;

	// Token: 0x04000707 RID: 1799
	public bool Bleach;

	// Token: 0x04000708 RID: 1800
	public bool Scanlines;

	// Token: 0x04000709 RID: 1801
	public bool Vignette;

	// Token: 0x0400070A RID: 1802
	public bool Wiggle;

	// Token: 0x0400070B RID: 1803
	public bool SobelEdge;

	// Token: 0x0400070C RID: 1804
	public bool SinCity;

	// Token: 0x0400070D RID: 1805
	public bool Pulse;

	// Token: 0x0400070E RID: 1806
	public bool Posterize;

	// Token: 0x0400070F RID: 1807
	public bool Pixelated;

	// Token: 0x04000710 RID: 1808
	public bool Negative;

	// Token: 0x04000711 RID: 1809
	public bool LensCircle;

	// Token: 0x04000712 RID: 1810
	public bool Frost;

	// Token: 0x04000713 RID: 1811
	public bool EdgeDetect;

	// Token: 0x04000714 RID: 1812
	public bool Desaturate;

	// Token: 0x04000715 RID: 1813
	public bool sa;

	// Token: 0x04000716 RID: 1814
	public string authorname;

	// Token: 0x04000717 RID: 1815
	public bool lockstory;

	// Token: 0x04000718 RID: 1816
	public string gameovername;

	// Token: 0x04000719 RID: 1817
	public string winname;

	// Token: 0x0400071A RID: 1818
	public string footsteps = "footsteps.wav";

	// Token: 0x0400071B RID: 1819
	public bool canrespawn = true;

	// Token: 0x0400071C RID: 1820
	public int camtype;

	// Token: 0x0400071D RID: 1821
	public bool useinv = true;

	// Token: 0x0400071E RID: 1822
	public Transform sunshine;

	// Token: 0x0400071F RID: 1823
	public bool usesunshine;

	// Token: 0x04000720 RID: 1824
	public float rsun = 1f;

	// Token: 0x04000721 RID: 1825
	public float gsun = 1f;

	// Token: 0x04000722 RID: 1826
	public float bsun = 1f;

	// Token: 0x04000723 RID: 1827
	public float rsunlight = 0.5f;

	// Token: 0x04000724 RID: 1828
	public float gsunlight = 0.5f;

	// Token: 0x04000725 RID: 1829
	public float bsunlight = 0.5f;

	// Token: 0x04000726 RID: 1830
	public string sunrotx = "25.0";

	// Token: 0x04000727 RID: 1831
	public string sunroty = "180.0";

	// Token: 0x04000728 RID: 1832
	public string sunrotz = "0.0";
}
