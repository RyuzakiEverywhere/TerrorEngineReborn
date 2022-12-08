using System;
using System.Collections;
using Photon;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000034 RID: 52
public class NpcSync : Photon.MonoBehaviour
{
	// Token: 0x060000D8 RID: 216 RVA: 0x0000CD94 File Offset: 0x0000B194
	private void Awake()
	{
		if (base.gameObject.name == "NPC1(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type1");
		}
		if (base.gameObject.name == "NPC2(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type2");
		}
		if (base.gameObject.name == "NPC3(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type3");
		}
		if (base.gameObject.name == "NPC4(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type4");
		}
		if (base.gameObject.name == "NPC5(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type5");
		}
		if (base.gameObject.name == "NPC6(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type6");
		}
		if (base.gameObject.name == "NPC7(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type7");
		}
		if (base.gameObject.name == "NPC8(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type8");
		}
		if (base.gameObject.name == "NPC9(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type9");
		}
		if (base.gameObject.name == "NPC10(Clone)")
		{
			this.typeobj = GameObject.Find("NPC_Type10");
		}
		this.npctype = this.typeobj.GetComponent<NPCProperties>();
		this.sethealth = this.npctype.health;
		this.curhealth = float.Parse(this.npctype.health);
		this.firstpos = base.transform.position;
		base.StartCoroutine(this.LoadAudio());
		this.nma = base.GetComponent<NavMeshAgent>();
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0000CFA8 File Offset: 0x0000B3A8
	private void Start()
	{
		if (this.npctype.walkonchase)
		{
			this.walkonchase = true;
		}
		if (this.npctype.friendly)
		{
			this.friendly = true;
		}
		if (this.npctype.closerpercollect)
		{
			this.closerpercollect = true;
		}
		if (this.npctype.followfromdis)
		{
			this.followfromdis = true;
			this.arrivaldis = float.Parse(this.npctype.mindistance);
			this.nma.stoppingDistance = this.arrivaldis;
			base.gameObject.GetComponent<Interaction_Chase>().enabled = true;
			this.chase = true;
			if (!this.npctype.runfollow)
			{
				this.walkonchase = true;
			}
			if (this.npctype.causestatic)
			{
				this.usestatic = true;
			}
		}
		else
		{
			this.nma.stoppingDistance = float.Parse(this.npctype.attdis) - 0.5f;
		}
		if (this.npctype.attonsight)
		{
			this.wait = true;
		}
		if (this.npctype.wander && this.npctype.attonsight)
		{
			this.wander = true;
		}
		if (this.npctype.patrol)
		{
			this.patrol = true;
		}
		if (this.npctype.detectbydis)
		{
			this.viadis = true;
			base.gameObject.GetComponent<FindPlayers>().detectbydis = true;
			this.curdis = float.Parse(this.npctype.detectdis);
			base.gameObject.GetComponent<FindPlayers>().curdis = this.curdis;
		}
		if (this.npctype.detectbyview)
		{
			this.viaeyesight = true;
			base.gameObject.GetComponent<FindPlayers>().detectbyview = true;
			this.curdis = float.Parse(this.npctype.detectdis);
			base.gameObject.GetComponent<FindPlayers>().curdis = this.curdis;
		}
		this.attdis = float.Parse(this.npctype.attdis);
		this.spotdis = float.Parse(this.npctype.detectdis);
		base.gameObject.GetComponent<FindPlayers>().spotdis = this.spotdis;
		base.gameObject.GetComponent<FindPlayers>().attdis = this.attdis;
		this.damage = float.Parse(this.npctype.damage);
		this.doors = GameObject.FindGameObjectsWithTag("Door");
		foreach (GameObject gameObject in this.doors)
		{
			Physics.IgnoreCollision(gameObject.GetComponent<Rigidbody>().GetComponent<Collider>(), gameObject.GetComponent<Collider>());
		}
		if (this.npctype.static2d)
		{
			this.static2d = true;
		}
		if (this.npctype.staticsound != string.Empty && this.followfromdis)
		{
			this.playstaticsound = true;
		}
		this.spothudtex = (Resources.Load("spotted") as Texture2D);
		this.advancedstatic = this.npctype.advancedstatic;
	}

	// Token: 0x060000DA RID: 218 RVA: 0x0000D2C0 File Offset: 0x0000B6C0
	private void Update()
	{
		if (!this.dead)
		{
			if (this.npctype.walkspeed == "1")
			{
				this.npctype.walkspeed = "2.1";
			}
			if (this.npctype.runspeed == "1")
			{
				this.npctype.runspeed = "2.1";
			}
			if (this.followfromdis && Vector3.Distance(base.GetComponent<FindPlayers>().target.transform.position, base.transform.position) < this.arrivaldis)
			{
				this.nma.velocity = Vector3.zero;
				this.nma.ResetPath();
			}
			if (!this.friendly)
			{
				if (base.transform.Find("npc-pos/npc(Clone)") != null && !this.hasmod)
				{
					this.hasmod = true;
					this.model = base.transform.Find("npc-pos/npc(Clone)").gameObject;
				}
				if (this.patrol && !this.chase)
				{
					base.gameObject.GetComponent<Interaction_Patrol>().enabled = true;
					if (!base.GetComponent<AudioSource>().isPlaying && !this.playstaticsound)
					{
						base.GetComponent<AudioSource>().clip = this.footstepsound;
						base.GetComponent<AudioSource>().Play();
					}
					if (!this.npctype.runonpatrol)
					{
						if (!base.GetComponent<AudioSource>().isPlaying && !this.playstaticsound)
						{
							base.GetComponent<AudioSource>().spatialBlend = 1f;
							base.GetComponent<AudioSource>().pitch = 1f;
						}
						if (this.nma.hasPath)
						{
							this.model.GetComponent<Animation>().CrossFade("walk");
						}
						else
						{
							this.model.GetComponent<Animation>().CrossFade("idle");
						}
						this.nma.speed = float.Parse(this.npctype.walkspeed);
					}
					else
					{
						if (!base.GetComponent<AudioSource>().isPlaying && !this.playstaticsound)
						{
							base.GetComponent<AudioSource>().spatialBlend = 1f;
							base.GetComponent<AudioSource>().pitch = 2f;
						}
						if (this.nma.hasPath)
						{
							this.model.GetComponent<Animation>().CrossFade("run");
						}
						else
						{
							this.model.GetComponent<Animation>().CrossFade("idle");
						}
						this.nma.speed = float.Parse(this.npctype.runspeed);
					}
				}
				else
				{
					base.gameObject.GetComponent<Interaction_Patrol>().enabled = false;
				}
				if (this.wander && this.wait && !this.chase)
				{
					base.gameObject.GetComponent<Interaction_Wander>().enabled = true;
					this.nma.speed = float.Parse(this.npctype.walkspeed);
					if (this.nma.hasPath)
					{
						this.model.GetComponent<Animation>().CrossFade("walk");
					}
					else
					{
						this.model.GetComponent<Animation>().CrossFade("idle");
					}
				}
				else
				{
					base.gameObject.GetComponent<Interaction_Wander>().enabled = false;
				}
				if (this.chase && !this.attack)
				{
					if (!base.GetComponent<AudioSource>().isPlaying && !this.playdetect)
					{
						base.GetComponent<AudioSource>().spatialBlend = 0f;
						base.GetComponent<AudioSource>().pitch = 1f;
						base.GetComponent<AudioSource>().clip = this.detectsound;
						base.GetComponent<AudioSource>().Play();
						this.playdetect = true;
					}
					base.gameObject.GetComponent<Interaction_Chase>().enabled = true;
					this.wait = false;
					this.wander = false;
					this.patrol = false;
					if (!base.GetComponent<AudioSource>().isPlaying && !this.playstaticsound)
					{
						base.GetComponent<AudioSource>().spatialBlend = 1f;
						base.GetComponent<AudioSource>().clip = this.footstepsound;
						base.GetComponent<AudioSource>().Play();
					}
					if (this.walkonchase)
					{
						if (!this.playstaticsound)
						{
							base.GetComponent<AudioSource>().spatialBlend = 1f;
							base.GetComponent<AudioSource>().pitch = 1f;
						}
						this.nma.speed = float.Parse(this.npctype.walkspeed);
						if (!this.attack)
						{
							if (this.nma.hasPath)
							{
								this.model.GetComponent<Animation>().CrossFade("walk");
							}
							else
							{
								this.model.GetComponent<Animation>().CrossFade("idle");
							}
						}
					}
					else
					{
						if (!this.playstaticsound)
						{
							base.GetComponent<AudioSource>().spatialBlend = 1f;
							base.GetComponent<AudioSource>().pitch = 2f;
						}
						this.nma.speed = float.Parse(this.npctype.runspeed);
						if (!this.attack)
						{
							if (this.nma.hasPath)
							{
								this.model.GetComponent<Animation>().CrossFade("run");
							}
							else
							{
								this.model.GetComponent<Animation>().CrossFade("idle");
							}
						}
					}
				}
				else
				{
					base.gameObject.GetComponent<Interaction_Chase>().enabled = false;
				}
				if (this.chase && base.gameObject.GetComponent<FindPlayers>().target != null)
				{
					if (this.attdis >= base.gameObject.GetComponent<FindPlayers>().newdis && base.gameObject.GetComponent<FindPlayers>().target != null && !this.attack && !this.beginattack && !this.followfromdis)
					{
						base.photonView.RPC("AttackMode", PhotonTargets.All, new object[0]);
					}
					if (this.followfromdis && this.attdis >= base.gameObject.GetComponent<FindPlayers>().newdis && !this.attack && !this.beginattack)
					{
						float num = 40f;
						if (Vector3.Angle(base.gameObject.GetComponent<FindPlayers>().target.transform.forward, base.transform.position - base.gameObject.GetComponent<FindPlayers>().target.transform.position) < num)
						{
							base.photonView.RPC("AttackMode", PhotonTargets.All, new object[0]);
						}
					}
				}
				if (this.attack && !this.beginattack)
				{
					base.StartCoroutine(this.AttackPlayer(0f));
				}
			}
		}
		if (this.curhealth <= 0f && !this.dead)
		{
			base.photonView.RPC("SyncDeath", PhotonTargets.All, new object[0]);
		}
		if (this.checkdeath)
		{
			base.StartCoroutine(this.Death(0f));
			this.checkdeath = false;
		}
		if (this.norespawn)
		{
			base.GetComponent<Collider>().enabled = false;
			base.GetComponent<Rigidbody>().useGravity = false;
			this.dead = true;
		}
		if (this.playstaticsound && !this.attack && this.npctype.staticsound != string.Empty && this.followfromdis)
		{
			if (!base.GetComponent<AudioSource>().isPlaying && this.viewsound != null && this.nma.hasPath)
			{
				float num2 = 40f;
				if (Vector3.Angle(base.gameObject.GetComponent<FindPlayers>().target.transform.forward, base.transform.position - base.gameObject.GetComponent<FindPlayers>().target.transform.position) < num2)
				{
					base.GetComponent<AudioSource>().spatialBlend = 0f;
					base.GetComponent<AudioSource>().pitch = 1f;
					base.GetComponent<AudioSource>().clip = this.viewsound;
					base.GetComponent<AudioSource>().Play();
					if (this.npctype.spottedhud)
					{
						base.StartCoroutine(this.SpotHUDEffect(1f));
					}
				}
			}
			if (!base.GetComponent<AudioSource>().isPlaying)
			{
				if (this.static2d)
				{
					base.GetComponent<AudioSource>().spatialBlend = 0f;
					base.GetComponent<AudioSource>().pitch = 1f;
				}
				else
				{
					base.GetComponent<AudioSource>().spatialBlend = 1f;
					base.GetComponent<AudioSource>().pitch = 1f;
				}
				base.GetComponent<AudioSource>().clip = this.staticsound;
				base.GetComponent<AudioSource>().Play();
			}
		}
		if (this.followfromdis && this.closerpercollect)
		{
			string s = GameObject.FindGameObjectsWithTag("collect").Length.ToString();
			this.nma.stoppingDistance = float.Parse(s) * 2.5f;
		}
		if (this.nma.remainingDistance <= this.nma.stoppingDistance)
		{
			this.nma.velocity = Vector3.zero;
			this.nma.ResetPath();
		}
	}

	// Token: 0x060000DB RID: 219 RVA: 0x0000DC50 File Offset: 0x0000C050
	private IEnumerator SpotHUDEffect(float waitTime)
	{
		this.spothud = true;
		yield return new WaitForSeconds(waitTime);
		this.spothud = false;
		yield break;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x0000DC74 File Offset: 0x0000C074
	private IEnumerator DealDamage(float waitTime)
	{
		yield return new WaitForSeconds(this.model.GetComponent<Animation>()["attack"].length / 2f / 2f / 2f);
		base.gameObject.GetComponent<FindPlayers>().target.GetComponent<PlayerHealth>().health -= this.damage;
		yield break;
	}

	// Token: 0x060000DD RID: 221 RVA: 0x0000DC90 File Offset: 0x0000C090
	private IEnumerator AttackPlayer(float waitTime)
	{
		this.beginattack = true;
		base.GetComponent<AudioSource>().pitch = 1f;
		base.GetComponent<AudioSource>().spatialBlend = 0f;
		base.GetComponent<AudioSource>().Stop();
		base.GetComponent<AudioSource>().clip = this.attacksound;
		base.GetComponent<AudioSource>().Play();
		this.model.GetComponent<Animation>().CrossFade("attack");
		base.gameObject.GetComponent<Interaction_Chase>().enabled = false;
		base.StartCoroutine(this.DealDamage(0f));
		yield return new WaitForSeconds(this.model.GetComponent<Animation>()["attack"].length);
		this.attack = false;
		this.beginattack = false;
		base.gameObject.GetComponent<Interaction_Chase>().enabled = true;
		yield break;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x0000DCAC File Offset: 0x0000C0AC
	private IEnumerator Death(float waitTime)
	{
		this.checkdeath = false;
		base.GetComponent<AudioSource>().Stop();
		this.model.GetComponent<Animation>().CrossFade("death");
		base.gameObject.GetComponent<Interaction_Chase>().enabled = false;
		base.gameObject.GetComponent<Interaction_Patrol>().enabled = false;
		base.gameObject.GetComponent<Interaction_Wander>().enabled = false;
		this.nma.enabled = false;
		base.GetComponent<Rigidbody>().useGravity = false;
		base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
		base.GetComponent<Collider>().isTrigger = true;
		yield return new WaitForSeconds(5f);
		if (!this.npctype.canrespawn)
		{
			base.photonView.RPC("IsDead", PhotonTargets.All, new object[0]);
		}
		else
		{
			base.GetComponent<Rigidbody>().useGravity = false;
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
			base.GetComponent<Collider>().isTrigger = false;
			base.transform.position = this.firstpos;
			this.curhealth = float.Parse(this.sethealth);
			this.nma.enabled = true;
			this.dead = false;
			this.Start();
		}
		yield break;
	}

	// Token: 0x060000DF RID: 223 RVA: 0x0000DCC7 File Offset: 0x0000C0C7
	public void Chase()
	{
		base.photonView.RPC("ChaseMode", PhotonTargets.AllBuffered, new object[0]);
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x0000DCE0 File Offset: 0x0000C0E0
	private IEnumerator LoadAudio()
	{
		if (this.npctype.playdetectsound)
		{
			WWW audio = new WWW("file:///" + Application.dataPath + "/Audio/" + this.npctype.detectsound);
			yield return audio;
			AudioClip audioc = audio.GetAudioClip();
			this.detectsound = audioc;
		}
		if (this.npctype.footstepsound != string.Empty)
		{
			WWW audio2 = new WWW("file:///" + Application.dataPath + "/Audio/" + this.npctype.footstepsound);
			yield return audio2;
			AudioClip audioc2 = audio2.GetAudioClip();
			this.footstepsound = audioc2;
		}
		if (this.npctype.attacksound != string.Empty)
		{
			WWW audio3 = new WWW("file:///" + Application.dataPath + "/Audio/" + this.npctype.attacksound);
			yield return audio3;
			AudioClip audioc3 = audio3.GetAudioClip();
			this.attacksound = audioc3;
		}
		if (this.npctype.staticsound != string.Empty && this.followfromdis)
		{
			WWW audio4 = new WWW("file:///" + Application.dataPath + "/Audio/" + this.npctype.staticsound);
			yield return audio4;
			AudioClip audioc4 = audio4.GetAudioClip();
			this.staticsound = audioc4;
		}
		if (this.npctype.viewsound != string.Empty && this.followfromdis)
		{
			WWW audio5 = new WWW("file:///" + Application.dataPath + "/Audio/" + this.npctype.viewsound);
			yield return audio5;
			AudioClip audioc5 = audio5.GetAudioClip();
			this.viewsound = audioc5;
		}
		yield break;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x0000DCFB File Offset: 0x0000C0FB
	private void OnGUI()
	{
		if (this.spothud)
		{
			GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.spothudtex);
		}
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x0000DD2E File Offset: 0x0000C12E
	[RPC]
	private void ChaseMode()
	{
		this.chase = true;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x0000DD37 File Offset: 0x0000C137
	[RPC]
	private void AttackMode()
	{
		this.attack = true;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x0000DD40 File Offset: 0x0000C140
	[RPC]
	private void SyncDeath()
	{
		this.checkdeath = true;
		this.dead = true;
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x0000DD50 File Offset: 0x0000C150
	[RPC]
	private void IsDead()
	{
		this.norespawn = true;
	}

	// Token: 0x0400012A RID: 298
	public bool wait;

	// Token: 0x0400012B RID: 299
	public bool attack;

	// Token: 0x0400012C RID: 300
	public bool patrol;

	// Token: 0x0400012D RID: 301
	public bool chase;

	// Token: 0x0400012E RID: 302
	public bool wander;

	// Token: 0x0400012F RID: 303
	public bool ffd;

	// Token: 0x04000130 RID: 304
	public bool friendly;

	// Token: 0x04000131 RID: 305
	public bool dead;

	// Token: 0x04000132 RID: 306
	public bool checkdeath;

	// Token: 0x04000133 RID: 307
	public bool followfromdis;

	// Token: 0x04000134 RID: 308
	public bool usestatic;

	// Token: 0x04000135 RID: 309
	public Transform playerdamage;

	// Token: 0x04000136 RID: 310
	public bool walkonchase;

	// Token: 0x04000137 RID: 311
	public float damage;

	// Token: 0x04000138 RID: 312
	public float attdis;

	// Token: 0x04000139 RID: 313
	public float spotdis;

	// Token: 0x0400013A RID: 314
	public bool viadis;

	// Token: 0x0400013B RID: 315
	public bool viaeyesight;

	// Token: 0x0400013C RID: 316
	public float curdis;

	// Token: 0x0400013D RID: 317
	public bool closerpercollect;

	// Token: 0x0400013E RID: 318
	private NPCProperties npctype;

	// Token: 0x0400013F RID: 319
	private GameObject typeobj;

	// Token: 0x04000140 RID: 320
	private bool hasmod;

	// Token: 0x04000141 RID: 321
	public GameObject model;

	// Token: 0x04000142 RID: 322
	public bool beginattack;

	// Token: 0x04000143 RID: 323
	public Vector3 oldpos;

	// Token: 0x04000144 RID: 324
	public Vector3 firstpos;

	// Token: 0x04000145 RID: 325
	public string sethealth;

	// Token: 0x04000146 RID: 326
	public float curhealth;

	// Token: 0x04000147 RID: 327
	public bool norespawn;

	// Token: 0x04000148 RID: 328
	public Transform npcdam;

	// Token: 0x04000149 RID: 329
	public AudioClip detectsound;

	// Token: 0x0400014A RID: 330
	public AudioClip footstepsound;

	// Token: 0x0400014B RID: 331
	public AudioClip attacksound;

	// Token: 0x0400014C RID: 332
	public AudioClip viewsound;

	// Token: 0x0400014D RID: 333
	public bool playdetect;

	// Token: 0x0400014E RID: 334
	public GameObject[] doors;

	// Token: 0x0400014F RID: 335
	public AudioClip staticsound;

	// Token: 0x04000150 RID: 336
	public bool playstaticsound;

	// Token: 0x04000151 RID: 337
	public bool static2d;

	// Token: 0x04000152 RID: 338
	public bool spothud;

	// Token: 0x04000153 RID: 339
	public Texture2D spothudtex;

	// Token: 0x04000154 RID: 340
	public bool advancedstatic;

	// Token: 0x04000155 RID: 341
	private NavMeshAgent nma;

	// Token: 0x04000156 RID: 342
	private float arrivaldis;
}
