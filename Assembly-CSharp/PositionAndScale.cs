using System;
using Photon;
using UnityEngine;

// Token: 0x020000DF RID: 223
public class PositionAndScale : Photon.MonoBehaviour
{
	// Token: 0x06000434 RID: 1076 RVA: 0x00026BD8 File Offset: 0x00024FD8
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 5 && base.gameObject.GetComponent<PhotonView>() != null && !base.photonView.isMine)
		{
			base.gameObject.GetComponent<EditObjEnable>().toggleon = false;
			EditObjEnable component = base.gameObject.GetComponent<EditObjEnable>();
			component.OnMouseDown();
			if (this.wall)
			{
				base.gameObject.GetComponent<WallProperties>().enabled = false;
			}
			if (this.light)
			{
				base.gameObject.GetComponent<LightProperties>().enabled = false;
			}
			if (this.model)
			{
				base.gameObject.GetComponent<ModelProperties>().enabled = false;
			}
			if (this.effect)
			{
				base.gameObject.GetComponent<EffectProperties>().enabled = false;
			}
			if (this.modobj)
			{
				base.gameObject.GetComponent<ModProperties>().enabled = false;
			}
			if (this.npc)
			{
				base.gameObject.GetComponent<NPCObjProperties>().enabled = false;
			}
			if (this.door)
			{
				base.gameObject.GetComponent<DoorProperties>().enabled = false;
			}
			base.enabled = false;
		}
		if (this.firsttime)
		{
			base.enabled = true;
		}
		else
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x00026D28 File Offset: 0x00025128
	private void Start()
	{
		if (this.firsttime)
		{
			base.enabled = true;
		}
		else
		{
			base.enabled = false;
		}
		this.rotx = base.transform.localEulerAngles.x.ToString();
		this.roty = base.transform.localEulerAngles.y.ToString();
		this.rotz = base.transform.localEulerAngles.z.ToString();
		if (this.firsttime)
		{
			this.scalex = base.transform.localScale.x.ToString();
			this.scaley = base.transform.localScale.y.ToString();
			this.scalez = base.transform.localScale.z.ToString();
			this.firsttime = false;
		}
		this.posx = base.transform.position.x.ToString();
		this.posy = base.transform.position.y.ToString();
		this.posz = base.transform.position.z.ToString();
		base.GetComponent<Renderer>().material.color = Color.white;
		if (this.flip)
		{
			this.rotx = "-90";
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			base.enabled = false;
		}
		if (base.gameObject.GetComponent<LoadMeshFromWeb>() == null)
		{
			GameObject gameObject = Resources.Load(base.gameObject.name.ToString()) as GameObject;
			base.gameObject.GetComponent<PositionAndScale>().objecttype = gameObject.GetComponent<PositionAndScale>().objecttype;
			base.gameObject.GetComponent<PositionAndScale>().flip = gameObject.GetComponent<PositionAndScale>().flip;
			base.gameObject.GetComponent<PositionAndScale>().wall = gameObject.GetComponent<PositionAndScale>().wall;
			base.gameObject.GetComponent<PositionAndScale>().model = gameObject.GetComponent<PositionAndScale>().model;
			base.gameObject.GetComponent<PositionAndScale>().light = gameObject.GetComponent<PositionAndScale>().light;
			base.gameObject.GetComponent<PositionAndScale>().npc = gameObject.GetComponent<PositionAndScale>().npc;
			base.gameObject.GetComponent<PositionAndScale>().effect = gameObject.GetComponent<PositionAndScale>().effect;
			base.gameObject.GetComponent<PositionAndScale>().events = gameObject.GetComponent<PositionAndScale>().events;
			base.gameObject.GetComponent<PositionAndScale>().modobj = gameObject.GetComponent<PositionAndScale>().modobj;
		}
		else
		{
			this.model = true;
		}
		if (base.name.Contains("idwall") || base.name.Contains("odwall"))
		{
			this.iswall = true;
		}
		if (base.name.Contains("idfloor") || base.name.Contains("odfloor"))
		{
			this.isfloor = true;
		}
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x000270B0 File Offset: 0x000254B0
	private void LateUpdate()
	{
		this.skin = (Resources.Load("BoxGUI") as GUISkin);
		base.GetComponent<Renderer>().material.color = Color.green;
		this.curposx = base.transform.position.x.ToString();
		this.curposy = base.transform.position.y.ToString();
		this.curposz = base.transform.position.z.ToString();
		base.transform.position = new Vector3(float.Parse(this.posx), float.Parse(this.posy), float.Parse(this.posz));
		base.transform.localEulerAngles = new Vector3(float.Parse(this.rotx), float.Parse(this.roty), float.Parse(this.rotz));
		base.transform.localScale = new Vector3(float.Parse(this.scalex), float.Parse(this.scaley), float.Parse(this.scalez));
		if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Escape))
		{
			if (CryptoPlayerPrefs.GetInt("Mode", 0) == 5 && base.gameObject.GetComponent<PhotonView>() != null)
			{
				if (this.effect)
				{
					UnityEngine.Object.Destroy(base.gameObject.GetComponent<EffectProperties>().effect);
				}
				PhotonNetwork.Destroy(base.gameObject);
			}
			else
			{
				if (this.effect)
				{
					UnityEngine.Object.Destroy(base.gameObject.GetComponent<EffectProperties>().effect);
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			base.gameObject.GetComponent<EditObjEnable>().toggleon = false;
			EditObjEnable component = base.gameObject.GetComponent<EditObjEnable>();
			component.OnMouseDown();
			if (this.wall)
			{
				base.gameObject.GetComponent<WallProperties>().enabled = false;
				if (base.gameObject.GetComponent<WallProperties>().isdoor)
				{
					base.gameObject.GetComponent<MeshFilter>().mesh = (Resources.Load("doorframe", typeof(Mesh)) as Mesh);
				}
			}
			if (this.light)
			{
				base.gameObject.GetComponent<LightProperties>().enabled = false;
			}
			if (this.model)
			{
				base.gameObject.GetComponent<ModelProperties>().enabled = false;
			}
			if (this.effect)
			{
				base.gameObject.GetComponent<EffectProperties>().showgui = false;
			}
			if (this.door)
			{
				base.gameObject.GetComponent<DoorProperties>().enabled = false;
			}
			if (this.modobj)
			{
				base.gameObject.GetComponent<ModProperties>().enabled = false;
			}
			if (this.npc)
			{
				base.gameObject.GetComponent<NPCObjProperties>().enabled = false;
			}
			base.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.posz = (float.Parse(this.curposz) + 0.5f).ToString();
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.posz = (float.Parse(this.curposz) - 0.5f).ToString();
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			this.posx = (float.Parse(this.curposx) - 0.5f).ToString();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			this.posx = (float.Parse(this.curposx) + 0.5f).ToString();
		}
		if (Input.GetKeyDown(KeyCode.RightBracket))
		{
			this.posy = (float.Parse(this.curposy) + 0.5f).ToString();
		}
		if (Input.GetKeyDown(KeyCode.LeftBracket))
		{
			this.posy = (float.Parse(this.curposy) - 0.5f).ToString();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			this.roty = (float.Parse(this.roty) - 15f).ToString();
		}
		if (base.gameObject.GetComponent<LoadTexture>() != null)
		{
			this.isimported = true;
			this.model = true;
		}
		if (this.iswall)
		{
			Vector3 localScale = base.transform.localScale;
			float x = localScale.x / 4f;
			float y = localScale.y / 4f;
			base.GetComponent<Renderer>().material.mainTextureScale = new Vector2(x, y);
		}
		if (this.isfloor)
		{
			Vector3 localScale2 = base.transform.localScale;
			float x2 = localScale2.x / 2f;
			float y2 = localScale2.z / 2f;
			base.GetComponent<Renderer>().material.mainTextureScale = new Vector2(x2, y2);
		}
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x000275E4 File Offset: 0x000259E4
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Box(new Rect((float)(Screen.width - 250), 30f, 245f, 275f), this.objecttype + " Properties");
		GUI.Label(new Rect((float)(Screen.width - 240), 75f, 240f, 200f), "Position");
		GUI.Label(new Rect((float)(Screen.width - 240), 100f, 30f, 200f), "X:");
		this.posx = GUI.TextField(new Rect((float)(Screen.width - 220), 100f, 50f, 20f), this.posx);
		GUI.Label(new Rect((float)(Screen.width - 170), 100f, 30f, 200f), "Y:");
		this.posy = GUI.TextField(new Rect((float)(Screen.width - 150), 100f, 50f, 20f), this.posy);
		GUI.Label(new Rect((float)(Screen.width - 100), 100f, 30f, 200f), "Z:");
		this.posz = GUI.TextField(new Rect((float)(Screen.width - 80), 100f, 50f, 20f), this.posz);
		GUI.Label(new Rect((float)(Screen.width - 240), 130f, 240f, 200f), "Rotation");
		GUI.Label(new Rect((float)(Screen.width - 240), 155f, 30f, 200f), "X:");
		this.rotx = GUI.TextField(new Rect((float)(Screen.width - 220), 155f, 50f, 20f), this.rotx);
		GUI.Label(new Rect((float)(Screen.width - 170), 155f, 30f, 200f), "Y:");
		this.roty = GUI.TextField(new Rect((float)(Screen.width - 150), 155f, 50f, 20f), this.roty);
		GUI.Label(new Rect((float)(Screen.width - 100), 155f, 30f, 200f), "Z:");
		this.rotz = GUI.TextField(new Rect((float)(Screen.width - 80), 155f, 50f, 20f), this.rotz);
		GUI.Label(new Rect((float)(Screen.width - 240), 185f, 240f, 200f), "Scale");
		GUI.Label(new Rect((float)(Screen.width - 240), 210f, 30f, 200f), "X:");
		this.scalex = GUI.TextField(new Rect((float)(Screen.width - 220), 210f, 50f, 20f), this.scalex);
		GUI.Label(new Rect((float)(Screen.width - 170), 210f, 30f, 200f), "Y:");
		this.scaley = GUI.TextField(new Rect((float)(Screen.width - 150), 210f, 50f, 20f), this.scaley);
		GUI.Label(new Rect((float)(Screen.width - 100), 210f, 30f, 200f), "Z:");
		this.scalez = GUI.TextField(new Rect((float)(Screen.width - 80), 210f, 50f, 20f), this.scalez);
		GUI.Label(new Rect((float)(Screen.width - 240), 235f, 300f, 200f), "Current Pos: ");
		GUI.Label(new Rect((float)(Screen.width - 160), 235f, 300f, 200f), "X:" + this.curposx);
		GUI.Label(new Rect((float)(Screen.width - 115), 235f, 300f, 200f), "Y:" + this.curposy);
		GUI.Label(new Rect((float)(Screen.width - 65), 235f, 300f, 200f), "Z:" + this.curposz);
		if (GUI.Button(new Rect((float)(Screen.width - 40), 42f, 21f, 21f), "X"))
		{
			base.gameObject.GetComponent<EditObjEnable>().toggleon = false;
			EditObjEnable component = base.gameObject.GetComponent<EditObjEnable>();
			component.OnMouseDown();
			if (this.model)
			{
				base.gameObject.GetComponent<ModelProperties>().enabled = false;
			}
			if (this.wall)
			{
				base.gameObject.GetComponent<WallProperties>().enabled = false;
			}
			if (this.light)
			{
				base.gameObject.GetComponent<LightProperties>().enabled = false;
			}
			if (this.effect)
			{
				base.gameObject.GetComponent<EffectProperties>().showgui = false;
				base.gameObject.GetComponent<EffectProperties>().enabled = false;
			}
			if (this.door)
			{
				base.gameObject.GetComponent<DoorProperties>().enabled = false;
			}
			if (this.modobj)
			{
				base.gameObject.GetComponent<ModProperties>().enabled = false;
			}
			if (this.npc)
			{
				base.gameObject.GetComponent<NPCObjProperties>().enabled = false;
			}
			base.enabled = false;
		}
		if (GUI.Button(new Rect((float)(Screen.width - 180), 270f, 100f, 21f), "Editor"))
		{
			if (this.wall)
			{
				base.gameObject.GetComponent<WallProperties>().enabled = !base.gameObject.GetComponent<WallProperties>().enabled;
			}
			if (this.light)
			{
				base.gameObject.GetComponent<LightProperties>().enabled = !base.gameObject.GetComponent<LightProperties>().enabled;
			}
			if (this.model)
			{
				base.gameObject.GetComponent<ModelProperties>().enabled = !base.gameObject.GetComponent<ModelProperties>().enabled;
			}
			if (this.effect)
			{
				base.gameObject.GetComponent<EffectProperties>().showgui = !base.gameObject.GetComponent<EffectProperties>().showgui;
			}
			if (this.events)
			{
				if (base.gameObject.GetComponent<TriggerProperties>() != null)
				{
					base.gameObject.GetComponent<TriggerProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<EndZoneProperties>() != null)
				{
					base.gameObject.GetComponent<EndZoneProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<AudioProperties>() != null)
				{
					base.gameObject.GetComponent<AudioProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<PlayerPrefsProperties>() != null)
				{
					base.gameObject.GetComponent<PlayerPrefsProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<AdvTeleportProperties>() != null)
				{
					base.gameObject.GetComponent<AdvTeleportProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<TimerProperties>() != null)
				{
					base.gameObject.GetComponent<TimerProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<PlayerProperties>() != null)
				{
					base.gameObject.GetComponent<PlayerProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<MonsterProperties>() != null)
				{
					base.gameObject.GetComponent<MonsterProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<NodeProperties>() != null)
				{
					base.gameObject.GetComponent<NodeProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<CameraProperties>() != null)
				{
					base.gameObject.GetComponent<CameraProperties>().enabled = true;
				}
				if (base.gameObject.GetComponent<CinematicProperties>() != null)
				{
					base.gameObject.GetComponent<CinematicProperties>().enabled = true;
				}
			}
			if (this.door)
			{
				base.gameObject.GetComponent<DoorProperties>().enabled = !base.gameObject.GetComponent<DoorProperties>().enabled;
			}
			if (this.modobj)
			{
				base.gameObject.GetComponent<ModProperties>().enabled = !base.gameObject.GetComponent<ModProperties>().enabled;
			}
			if (this.npc)
			{
				base.gameObject.GetComponent<NPCObjProperties>().enabled = !base.gameObject.GetComponent<NPCObjProperties>().enabled;
			}
		}
	}

	// Token: 0x040004DC RID: 1244
	public string objecttype = "Model";

	// Token: 0x040004DD RID: 1245
	public bool flip;

	// Token: 0x040004DE RID: 1246
	public bool wall;

	// Token: 0x040004DF RID: 1247
	public bool model;

	// Token: 0x040004E0 RID: 1248
	public bool effect;

	// Token: 0x040004E1 RID: 1249
	public bool light;

	// Token: 0x040004E2 RID: 1250
	public bool npc;

	// Token: 0x040004E3 RID: 1251
	public bool events;

	// Token: 0x040004E4 RID: 1252
	public bool door;

	// Token: 0x040004E5 RID: 1253
	public bool item;

	// Token: 0x040004E6 RID: 1254
	public bool modobj;

	// Token: 0x040004E7 RID: 1255
	public GUISkin skin;

	// Token: 0x040004E8 RID: 1256
	public string posx;

	// Token: 0x040004E9 RID: 1257
	public string posy;

	// Token: 0x040004EA RID: 1258
	public string posz;

	// Token: 0x040004EB RID: 1259
	public string rotx;

	// Token: 0x040004EC RID: 1260
	public string roty;

	// Token: 0x040004ED RID: 1261
	public string rotz;

	// Token: 0x040004EE RID: 1262
	public string scalex;

	// Token: 0x040004EF RID: 1263
	public string scaley;

	// Token: 0x040004F0 RID: 1264
	public string scalez;

	// Token: 0x040004F1 RID: 1265
	private string curposx;

	// Token: 0x040004F2 RID: 1266
	private string curposy;

	// Token: 0x040004F3 RID: 1267
	private string curposz;

	// Token: 0x040004F4 RID: 1268
	public bool firsttime = true;

	// Token: 0x040004F5 RID: 1269
	public bool isimported;

	// Token: 0x040004F6 RID: 1270
	private bool iswall;

	// Token: 0x040004F7 RID: 1271
	private bool isfloor;
}
