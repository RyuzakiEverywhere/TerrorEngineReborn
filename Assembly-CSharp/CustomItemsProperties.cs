using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000015 RID: 21
public class CustomItemsProperties : MonoBehaviour
{
	// Token: 0x06000053 RID: 83 RVA: 0x00006C9C File Offset: 0x0000509C
	private void Awake()
	{
		if (base.GetComponent<Light>().type == LightType.Area)
		{
			this.arealight = true;
		}
		else
		{
			this.spotlight = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.blue)
		{
			this.blue = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.cyan)
		{
			this.cyan = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.green)
		{
			this.green = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.grey)
		{
			this.grey = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.magenta)
		{
			this.magenta = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.red)
		{
			this.red = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.white)
		{
			this.white = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.yellow)
		{
			this.yellow = true;
		}
		if (base.gameObject.GetComponent<Light>().color == new Color(1f, 0.76f, 0.16f))
		{
			this.orange = true;
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			this.showgui = true;
			base.enabled = false;
		}
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00006E64 File Offset: 0x00005264
	private IEnumerator LoadName(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		base.gameObject.GetComponent<CustomItemModel>().Objpath = this.modelname;
		base.gameObject.GetComponent<CustomItemModel>().enabled = true;
		yield break;
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00006E88 File Offset: 0x00005288
	private void Start()
	{
		this.lightrange = base.gameObject.GetComponent<Light>().range.ToString();
		if (base.GetComponent<Light>().type == LightType.Area)
		{
			this.arealight = true;
		}
		else
		{
			this.spotlight = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.blue)
		{
			this.blue = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.cyan)
		{
			this.cyan = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.green)
		{
			this.green = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.grey)
		{
			this.grey = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.magenta)
		{
			this.magenta = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.red)
		{
			this.red = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.white)
		{
			this.white = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.yellow)
		{
			this.yellow = true;
		}
		if (base.gameObject.GetComponent<Light>().color == new Color(1f, 0.76f, 0.16f))
		{
			this.orange = true;
		}
		base.StartCoroutine(this.LoadName(1f));
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00007054 File Offset: 0x00005454
	private void Update()
	{
		if (this.showgui)
		{
			if (this.arealight)
			{
				base.GetComponent<Light>().type = LightType.Point;
			}
			if (this.spotlight)
			{
				base.GetComponent<Light>().type = LightType.Spot;
			}
			if (this.blue)
			{
				base.gameObject.GetComponent<Light>().color = Color.blue;
			}
			if (this.cyan)
			{
				base.gameObject.GetComponent<Light>().color = Color.cyan;
			}
			if (this.green)
			{
				base.gameObject.GetComponent<Light>().color = Color.green;
			}
			if (this.grey)
			{
				base.gameObject.GetComponent<Light>().color = Color.grey;
			}
			if (this.magenta)
			{
				base.gameObject.GetComponent<Light>().color = Color.magenta;
			}
			if (this.red)
			{
				base.gameObject.GetComponent<Light>().color = Color.red;
			}
			if (this.white)
			{
				base.gameObject.GetComponent<Light>().color = Color.white;
			}
			if (this.yellow)
			{
				base.gameObject.GetComponent<Light>().color = Color.yellow;
			}
			if (this.orange)
			{
				base.gameObject.GetComponent<Light>().color = new Color(1f, 0.76f, 0.16f);
			}
			base.gameObject.GetComponent<Light>().range = float.Parse(this.lightrange);
		}
		if (GameObject.Find("Play(Clone)") && this.sound == null && this.canshoot && !this.isloadingsound)
		{
			base.StartCoroutine("LoadAudio");
		}
	}

	// Token: 0x06000057 RID: 87 RVA: 0x0000722C File Offset: 0x0000562C
	private IEnumerator LoadAudio()
	{
		this.isloadingsound = true;
		if (this.sound == null)
		{
			WWW audio2 = new WWW("file:///" + Application.dataPath + "/Audio/" + this.firesound);
			yield return audio2;
			this.audioc = audio2.GetAudioClip();
			this.sound = this.audioc;
			base.enabled = false;
		}
		yield break;
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00007248 File Offset: 0x00005648
	private void DoWindow2(int windowID)
	{
		if (this.showgui)
		{
			GUI.Label(new Rect(45f, 30f, 100f, 20f), "Model Name");
			this.modelname = GUI.TextField(new Rect(35f, 50f, 100f, 20f), this.modelname);
			if (GUI.Button(new Rect(385f, 300f, 100f, 20f), "Save Settings"))
			{
				base.enabled = false;
			}
			GUI.Box(new Rect(20f, 95f, 130f, 55f), "Wield Animation");
			if (this.onehand && GUI.Button(new Rect(35f, 120f, 100f, 20f), "One Hand"))
			{
				this.onehand = false;
				this.twohand = true;
				this.twohandweapon = false;
			}
			if (this.twohand && GUI.Button(new Rect(35f, 120f, 100f, 20f), "Both Hands"))
			{
				this.onehand = false;
				this.twohand = false;
				this.twohandweapon = true;
			}
			if (this.twohandweapon && GUI.Button(new Rect(35f, 120f, 100f, 20f), "2H Weapon"))
			{
				this.onehand = true;
				this.twohand = false;
				this.twohandweapon = false;
			}
			GUI.Box(new Rect(160f, 45f, 160f, 250f), "Light");
			this.castlight = GUI.Toggle(new Rect(180f, 80f, 100f, 20f), this.castlight, "Cast Light");
			this.pressftotoggle = GUI.Toggle(new Rect(180f, 100f, 130f, 20f), this.pressftotoggle, "Press 'F' to toggle");
			GUI.Label(new Rect(180f, 125f, 100f, 20f), "Light Range:");
			this.lightrange = GUI.TextField(new Rect(180f, 145f, 100f, 20f), this.lightrange);
			GUI.Label(new Rect(180f, 170f, 100f, 20f), "Light Type:");
			if (this.arealight && GUI.Button(new Rect(180f, 190f, 100f, 20f), "Area Light"))
			{
				this.arealight = false;
				this.spotlight = true;
			}
			if (this.spotlight && GUI.Button(new Rect(180f, 190f, 100f, 20f), "Spot Light"))
			{
				this.arealight = true;
				this.spotlight = false;
			}
			GUI.Label(new Rect(180f, 215f, 100f, 20f), "Light Color:");
			if (this.white && GUI.Button(new Rect(180f, 235f, 100f, 20f), "White"))
			{
				this.white = false;
				this.blue = true;
				this.cyan = false;
				this.green = false;
				this.grey = false;
				this.magenta = false;
				this.red = false;
				this.yellow = false;
				this.orange = false;
			}
			if (this.blue && GUI.Button(new Rect(180f, 235f, 100f, 20f), "Blue"))
			{
				this.white = false;
				this.blue = false;
				this.cyan = true;
				this.green = false;
				this.grey = false;
				this.magenta = false;
				this.red = false;
				this.yellow = false;
				this.orange = false;
			}
			if (this.cyan && GUI.Button(new Rect(180f, 235f, 100f, 20f), "Cyan"))
			{
				this.white = false;
				this.blue = false;
				this.cyan = false;
				this.green = true;
				this.grey = false;
				this.magenta = false;
				this.red = false;
				this.yellow = false;
				this.orange = false;
			}
			if (this.green && GUI.Button(new Rect(180f, 235f, 100f, 20f), "Green"))
			{
				this.white = false;
				this.blue = false;
				this.cyan = false;
				this.green = false;
				this.grey = true;
				this.magenta = false;
				this.red = false;
				this.yellow = false;
				this.orange = false;
			}
			if (this.grey && GUI.Button(new Rect(180f, 235f, 100f, 20f), "Grey"))
			{
				this.white = false;
				this.blue = false;
				this.cyan = false;
				this.green = false;
				this.grey = false;
				this.magenta = true;
				this.red = false;
				this.yellow = false;
				this.orange = false;
			}
			if (this.magenta && GUI.Button(new Rect(180f, 235f, 100f, 20f), "Magenta"))
			{
				this.white = false;
				this.blue = false;
				this.cyan = false;
				this.green = false;
				this.grey = false;
				this.magenta = false;
				this.red = true;
				this.yellow = false;
				this.orange = false;
			}
			if (this.red && GUI.Button(new Rect(180f, 235f, 100f, 20f), "Red"))
			{
				this.white = false;
				this.blue = false;
				this.cyan = false;
				this.green = false;
				this.grey = false;
				this.magenta = false;
				this.red = false;
				this.yellow = true;
				this.orange = false;
			}
			if (this.yellow && GUI.Button(new Rect(180f, 235f, 100f, 20f), "Yellow"))
			{
				this.white = false;
				this.blue = false;
				this.cyan = false;
				this.green = false;
				this.grey = false;
				this.magenta = false;
				this.red = false;
				this.yellow = false;
				this.orange = true;
			}
			if (this.orange && GUI.Button(new Rect(180f, 235f, 100f, 20f), "Orange"))
			{
				this.white = true;
				this.blue = false;
				this.cyan = false;
				this.green = false;
				this.grey = false;
				this.magenta = false;
				this.red = false;
				this.yellow = false;
				this.orange = false;
			}
			GUI.Box(new Rect(330f, 45f, 160f, 250f), "Weapon");
			this.canmelee = GUI.Toggle(new Rect(350f, 80f, 100f, 20f), this.canmelee, "Can Melee");
			this.canshoot = GUI.Toggle(new Rect(350f, 100f, 100f, 20f), this.canshoot, "Can Shoot");
			if (this.singleshot && GUI.Button(new Rect(350f, 120f, 100f, 20f), "Single-Shot"))
			{
				this.singleshot = false;
				this.multishot = true;
			}
			if (this.multishot && GUI.Button(new Rect(350f, 120f, 100f, 20f), "Automatic"))
			{
				this.singleshot = true;
				this.multishot = false;
			}
			GUI.Label(new Rect(350f, 145f, 100f, 20f), "Fire Speed:");
			this.delay = GUI.TextField(new Rect(350f, 165f, 100f, 20f), this.delay);
			GUI.Label(new Rect(350f, 185f, 100f, 20f), "Total Ammo:");
			this.totalammo = GUI.TextField(new Rect(350f, 205f, 100f, 20f), this.totalammo);
			GUI.Label(new Rect(350f, 225f, 100f, 20f), "Damage:");
			this.damage = GUI.TextField(new Rect(350f, 245f, 100f, 20f), this.damage);
			if (this.canshoot)
			{
				GUI.Box(new Rect(20f, 165f, 130f, 90f), "Shoot Sound");
				this.firesound = GUI.TextField(new Rect(35f, 190f, 100f, 20f), this.firesound);
				this.showblood = GUI.Toggle(new Rect(35f, 215f, 100f, 20f), this.showblood, "Show Blood");
			}
		}
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00007BE0 File Offset: 0x00005FE0
	private void OnGUI()
	{
		GUI.skin = this.skin;
		if (this.showgui)
		{
			GUI.Label(new Rect(250f, 60f, 300f, 20f), this.itemtypenum);
			GUI.Window(1, new Rect(5f, 40f, 515f, 340f), new GUI.WindowFunction(this.DoWindow2), this.itemtypenum);
		}
	}

	// Token: 0x0400006F RID: 111
	public string itemtypenum;

	// Token: 0x04000070 RID: 112
	public bool togglevisible;

	// Token: 0x04000071 RID: 113
	public GUISkin skin;

	// Token: 0x04000072 RID: 114
	public string modelname;

	// Token: 0x04000073 RID: 115
	public bool onehand = true;

	// Token: 0x04000074 RID: 116
	public bool twohand;

	// Token: 0x04000075 RID: 117
	public bool twohandweapon;

	// Token: 0x04000076 RID: 118
	public bool castlight;

	// Token: 0x04000077 RID: 119
	public bool pressftotoggle;

	// Token: 0x04000078 RID: 120
	public bool arealight = true;

	// Token: 0x04000079 RID: 121
	public bool spotlight;

	// Token: 0x0400007A RID: 122
	public string lightrange = "10";

	// Token: 0x0400007B RID: 123
	public bool blue;

	// Token: 0x0400007C RID: 124
	public bool cyan;

	// Token: 0x0400007D RID: 125
	public bool green;

	// Token: 0x0400007E RID: 126
	public bool grey;

	// Token: 0x0400007F RID: 127
	public bool magenta;

	// Token: 0x04000080 RID: 128
	public bool red;

	// Token: 0x04000081 RID: 129
	public bool white = true;

	// Token: 0x04000082 RID: 130
	public bool yellow;

	// Token: 0x04000083 RID: 131
	public bool orange;

	// Token: 0x04000084 RID: 132
	public bool canmelee = true;

	// Token: 0x04000085 RID: 133
	public bool canshoot;

	// Token: 0x04000086 RID: 134
	public bool singleshot;

	// Token: 0x04000087 RID: 135
	public bool multishot;

	// Token: 0x04000088 RID: 136
	public string delay;

	// Token: 0x04000089 RID: 137
	public string totalammo;

	// Token: 0x0400008A RID: 138
	public string damage;

	// Token: 0x0400008B RID: 139
	public string firesound;

	// Token: 0x0400008C RID: 140
	public AudioClip sound;

	// Token: 0x0400008D RID: 141
	public bool isloadingsound;

	// Token: 0x0400008E RID: 142
	public AudioClip audioc;

	// Token: 0x0400008F RID: 143
	public bool showgui;

	// Token: 0x04000090 RID: 144
	public bool showblood = true;
}
