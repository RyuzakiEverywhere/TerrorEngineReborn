using System;
using System.IO;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class NPCProperties : MonoBehaviour
{
	// Token: 0x06000412 RID: 1042 RVA: 0x00025018 File Offset: 0x00023418
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			if (this.walkspeed == "1")
			{
				this.walkspeed = "2";
			}
			if (this.runspeed == "1")
			{
				this.walkspeed = "2";
			}
			base.enabled = false;
		}
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x00025090 File Offset: 0x00023490
	private void Update()
	{
		if ((CryptoPlayerPrefs.GetInt("Mode", 0) == 1 && this.npcmodelname != null) || (CryptoPlayerPrefs.GetInt("Mode", 0) == 2 && this.npcmodelname != null) || (CryptoPlayerPrefs.GetInt("Mode", 0) == 3 && this.npcmodelname != null))
		{
			base.gameObject.AddComponent<LoadNPC>();
			base.enabled = false;
		}
		if (this.staticsound == null)
		{
			this.staticsound = "growl.ogg";
		}
		if (this.viewsound == null)
		{
			this.viewsound = "growl.ogg";
		}
		if (this.causestatic)
		{
			this.advancedstatic = false;
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 21)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0002515C File Offset: 0x0002355C
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
		this.listoffiles = Directory.GetFiles(Application.dataPath + "/Characters/NPC/", "*.npc");
		this.listofnpc = this.listoffiles;
		for (int i = 0; i < this.listofnpc.Length; i++)
		{
			string text = Application.dataPath + "/Characters/NPC/";
			string oldValue = ".npc";
			if (this.listofnpc[i].Contains(text))
			{
				this.listofnpc[i] = this.listofnpc[i].Replace(text, string.Empty);
				this.listofnpc[i] = this.listofnpc[i].Replace(oldValue, string.Empty);
			}
		}
		if (!this.closerpercollect || false)
		{
			this.closerpercollect = false;
		}
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0002523C File Offset: 0x0002363C
	private void TriggerWindow(int windowID)
	{
		GUI.Box(new Rect(20f, 45f, 180f, 90f), "NPC Mode:");
		if (this.footstepsound == null)
		{
			this.footstepsound = "footsteps.ogg";
		}
		if (this.attacksound == null)
		{
			this.attacksound = "hit1.ogg";
		}
		if (this.attonsight)
		{
			if (GUI.Button(new Rect(62f, 80f, 100f, 40f), "Attack On \n Sight"))
			{
				this.attonsight = false;
				this.patrol = true;
				this.followfromdis = false;
				this.friendly = false;
			}
			this.wander = GUI.Toggle(new Rect(52f, 290f, 150f, 20f), this.wander, "Wander-(Move Around)");
		}
		if (this.patrol)
		{
			if (GUI.Button(new Rect(62f, 80f, 100f, 40f), "Patrol & Attack \n On Sight"))
			{
				this.attonsight = false;
				this.patrol = false;
				this.followfromdis = true;
				this.friendly = false;
			}
			this.runonpatrol = GUI.Toggle(new Rect(52f, 290f, 100f, 20f), this.runonpatrol, "Run During Patrol");
		}
		if (this.followfromdis)
		{
			this.causestatic = GUI.Toggle(new Rect(52f, 190f, 100f, 20f), this.causestatic, "Cause Simple Static");
			this.advancedstatic = GUI.Toggle(new Rect(52f, 205f, 100f, 20f), this.advancedstatic, "Cause Adv-Camera Static");
			this.runfollow = GUI.Toggle(new Rect(52f, 220f, 100f, 20f), this.runfollow, "Run");
			GUI.Label(new Rect(42f, 245f, 120f, 20f), "Minimum Distance");
			if (!this.closerpercollect)
			{
				this.mindistance = GUI.TextField(new Rect(42f, 265f, 40f, 22f), this.mindistance);
			}
			else
			{
				GUI.TextArea(new Rect(42f, 265f, 120f, 22f), "Closer per-Collect");
			}
			if (GUI.Button(new Rect(62f, 80f, 100f, 40f), "Follow From \n Distance"))
			{
				this.attonsight = false;
				this.patrol = false;
				this.followfromdis = false;
				this.friendly = true;
			}
			GUI.Label(new Rect(52f, 350f, 100f, 20f), "In-View Sound:");
			this.viewsound = GUI.TextField(new Rect(52f, 370f, 100f, 20f), this.viewsound);
			this.spottedhud = GUI.Toggle(new Rect(52f, 390f, 100f, 20f), this.spottedhud, "Show In-view HUD");
			this.closerpercollect = GUI.Toggle(new Rect(52f, 410f, 100f, 20f), this.closerpercollect, "Closer Distance per-Collect");
			GUI.Label(new Rect(52f, 290f, 100f, 20f), "Nearby Sound:");
			this.static2d = GUI.Toggle(new Rect(52f, 310f, 100f, 20f), this.static2d, "Sound 2D?");
			this.staticsound = GUI.TextField(new Rect(52f, 325f, 100f, 20f), this.staticsound);
		}
		if (this.friendly)
		{
			if (GUI.Button(new Rect(62f, 80f, 100f, 40f), "Friendly \n (No Attack)"))
			{
				this.attonsight = true;
				this.patrol = false;
				this.followfromdis = false;
				this.friendly = false;
			}
		}
		GUI.Label(new Rect(40f, 145f, 90f, 22f), "Model Name:");
		GUI.Label(new Rect(150f, 164f, 40f, 22f), " .npc");
		this.npcmodelname = GUI.TextField(new Rect(40f, 165f, 120f, 22f), this.npcmodelname);
		GUI.Box(new Rect(220f, 45f, 120f, 280f), "Main Properties");
		GUI.Label(new Rect(230f, 75f, 80f, 20f), "Walk Speed");
		this.walkspeed = GUI.TextField(new Rect(230f, 95f, 40f, 22f), this.walkspeed);
		GUI.Label(new Rect(230f, 125f, 80f, 20f), "Run Speed");
		this.runspeed = GUI.TextField(new Rect(230f, 145f, 40f, 22f), this.runspeed);
		GUI.Label(new Rect(230f, 175f, 80f, 20f), "Attack Dis");
		this.attdis = GUI.TextField(new Rect(230f, 195f, 40f, 22f), this.attdis);
		GUI.Label(new Rect(230f, 225f, 80f, 20f), "Damage");
		this.damage = GUI.TextField(new Rect(230f, 245f, 40f, 22f), this.damage);
		GUI.Label(new Rect(230f, 275f, 80f, 20f), "Health");
		this.health = GUI.TextField(new Rect(230f, 295f, 40f, 22f), this.health);
		if (this.attonsight || this.patrol)
		{
			GUI.Label(new Rect(52f, 200f, 110f, 20f), "Player Detection");
			if (this.detectbydis)
			{
				GUI.Label(new Rect(52f, 245f, 60f, 20f), "Radius");
				this.detectdis = GUI.TextField(new Rect(112f, 245f, 50f, 22f), this.detectdis);
				if (GUI.Button(new Rect(52f, 225f, 110f, 20f), "via Distance"))
				{
					this.detectbydis = false;
					this.detectbyview = true;
				}
			}
			if (this.detectbyview)
			{
				GUI.Label(new Rect(52f, 245f, 60f, 20f), "Radius");
				this.detectdis = GUI.TextField(new Rect(112f, 245f, 50f, 22f), this.detectdis);
				if (GUI.Button(new Rect(52f, 225f, 110f, 20f), "via Eye-Sight"))
				{
					this.detectbydis = true;
					this.detectbyview = false;
				}
			}
			this.walkonchase = GUI.Toggle(new Rect(52f, 270f, 100f, 20f), this.walkonchase, "Walk During Chase");
			this.playdetectsound = GUI.Toggle(new Rect(52f, 310f, 100f, 20f), this.playdetectsound, "Play Detect Audio");
			this.detectsound = GUI.TextField(new Rect(52f, 325f, 100f, 20f), this.detectsound);
			GUI.Label(new Rect(52f, 345f, 100f, 20f), "Step Sound:");
			this.footstepsound = GUI.TextField(new Rect(52f, 365f, 100f, 20f), this.footstepsound);
			GUI.Label(new Rect(52f, 385f, 100f, 20f), "Attack Sound:");
			this.attacksound = GUI.TextField(new Rect(52f, 405f, 100f, 20f), this.attacksound);
		}
		this.hasgravity = GUI.Toggle(new Rect(220f, 330f, 120f, 20f), this.hasgravity, "Has Gravity");
		this.canrespawn = GUI.Toggle(new Rect(220f, 350f, 120f, 20f), this.canrespawn, "Can Respawn");
		if (GUI.Button(new Rect(250f, 410f, 100f, 20f), "Save Settings"))
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x00025B84 File Offset: 0x00023F84
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(6, new Rect(5f, 30f, 370f, 447f), new GUI.WindowFunction(this.TriggerWindow), "NPC-Type Editor");
		GUI.Box(new Rect(371f, 40f, 130f, 45f), "NPC Model List");
		if (GUI.Button(new Rect(371f, 67f, 130f, 21f), "Show/Hide List"))
		{
			this.showlist = !this.showlist;
		}
		if (this.showlist)
		{
			for (int i = 0; i < this.listofnpc.Length; i++)
			{
				if (GUI.Button(new Rect(371f, (float)(91 + 21 * i), 130f, 21f), this.listofnpc[i]))
				{
					this.npcmodelname = this.listofnpc[i];
					this.showlist = false;
				}
			}
		}
	}

	// Token: 0x0400048E RID: 1166
	public GUISkin skin;

	// Token: 0x0400048F RID: 1167
	public bool attonsight = true;

	// Token: 0x04000490 RID: 1168
	public bool patrol;

	// Token: 0x04000491 RID: 1169
	public bool followfromdis;

	// Token: 0x04000492 RID: 1170
	public bool friendly;

	// Token: 0x04000493 RID: 1171
	public string npcmodelname;

	// Token: 0x04000494 RID: 1172
	public string walkspeed = "4";

	// Token: 0x04000495 RID: 1173
	public string runspeed = "8";

	// Token: 0x04000496 RID: 1174
	public string attdis = "2";

	// Token: 0x04000497 RID: 1175
	public string damage = "50";

	// Token: 0x04000498 RID: 1176
	public string health = "100";

	// Token: 0x04000499 RID: 1177
	public bool detectbydis;

	// Token: 0x0400049A RID: 1178
	public bool detectbyview = true;

	// Token: 0x0400049B RID: 1179
	public string detectdis = "10";

	// Token: 0x0400049C RID: 1180
	public string nodename;

	// Token: 0x0400049D RID: 1181
	public bool walkonchase;

	// Token: 0x0400049E RID: 1182
	public bool runonpatrol;

	// Token: 0x0400049F RID: 1183
	public bool hasgravity = true;

	// Token: 0x040004A0 RID: 1184
	public bool causestatic = true;

	// Token: 0x040004A1 RID: 1185
	public bool runfollow;

	// Token: 0x040004A2 RID: 1186
	public bool canrespawn;

	// Token: 0x040004A3 RID: 1187
	public string mindistance = "20";

	// Token: 0x040004A4 RID: 1188
	public bool wander;

	// Token: 0x040004A5 RID: 1189
	public string[] listoffiles;

	// Token: 0x040004A6 RID: 1190
	public string[] listofnpc;

	// Token: 0x040004A7 RID: 1191
	public FileInfo[] info;

	// Token: 0x040004A8 RID: 1192
	public Vector2 scrollPosition;

	// Token: 0x040004A9 RID: 1193
	public bool playdetectsound;

	// Token: 0x040004AA RID: 1194
	public string detectsound = "growl.ogg";

	// Token: 0x040004AB RID: 1195
	public string footstepsound = "footsteps.ogg";

	// Token: 0x040004AC RID: 1196
	public string attacksound = "hit1.ogg";

	// Token: 0x040004AD RID: 1197
	public bool showlist;

	// Token: 0x040004AE RID: 1198
	public bool static2d;

	// Token: 0x040004AF RID: 1199
	public string staticsound;

	// Token: 0x040004B0 RID: 1200
	public string viewsound;

	// Token: 0x040004B1 RID: 1201
	public bool spottedhud;

	// Token: 0x040004B2 RID: 1202
	public bool advancedstatic;

	// Token: 0x040004B3 RID: 1203
	public bool closerpercollect;
}
