using System;
using Photon;
using UnityEngine;

// Token: 0x02000043 RID: 67
public class SyncAnimation : Photon.MonoBehaviour
{
	// Token: 0x0600012D RID: 301 RVA: 0x000112C0 File Offset: 0x0000F6C0
	private void Awake()
	{
		this.uma = base.gameObject.GetComponent<UpdateMyAnimation>();
		this.p = GameObject.Find("Animations").GetComponent<PlayerAnimations>();
		SettingsProperties component = GameObject.Find("Settings").GetComponent<SettingsProperties>();
		if (component.camtype == 0)
		{
			this.thirdperson = false;
			this.enablethirdperson = true;
			this.cantoggleview = true;
			this.isCinematic = false;
		}
		if (component.camtype == 1)
		{
			this.thirdperson = false;
			this.enablethirdperson = false;
			this.cantoggleview = false;
			this.isCinematic = false;
		}
		if (component.camtype == 2)
		{
			this.thirdperson = true;
			this.enablethirdperson = true;
			this.cantoggleview = false;
			this.isCinematic = false;
		}
		if (component.camtype == 3)
		{
			this.thirdperson = true;
			this.enablethirdperson = true;
			this.cantoggleview = false;
			this.isCinematic = true;
		}
	}

	// Token: 0x0600012E RID: 302 RVA: 0x000113A4 File Offset: 0x0000F7A4
	private void Update()
	{
		if (base.photonView.isMine && !this.hasmod)
		{
			this.modelsource = GameObject.Find(PlayerPrefs.GetString("Character"));
			if (this.modelsource != null)
			{
				this.modname = PlayerPrefs.GetString("Character");
				base.photonView.RPC("GetModelName", PhotonTargets.AllBuffered, new object[]
				{
					this.modname
				});
			}
		}
		if (base.photonView.isMine && this.enablethirdperson && this.cantoggleview && !this.isCinematic && Input.GetKeyDown(KeyCode.V))
		{
			this.thirdperson = !this.thirdperson;
		}
		if (base.photonView.isMine && this.thirdperson)
		{
			this.changenow = false;
			if (!this.isCinematic)
			{
				this.maincam.localPosition = new Vector3(0f, 0.3f, -0.8f);
				this.ovrcam.localPosition = new Vector3(0f, 0.3f, -0.8f);
			}
		}
		else if (!this.changenow && !this.isCinematic && base.photonView.isMine)
		{
			this.maincam.localPosition = new Vector3(0f, 0f, --0f);
			this.ovrcam.localPosition = new Vector3(0f, 0f, --0f);
			this.changenow = true;
		}
		if (this.playermodel != null)
		{
			this.crouch = this.uma.crouch;
			this.run = this.uma.run;
			this.walkforward = this.uma.walkforward;
			this.walkbackward = this.uma.walkbackward;
			this.walkleft = this.uma.walkleft;
			this.walkright = this.uma.walkright;
			this.idle = this.uma.idle;
			this.check = this.uma.check;
			this.parkour = this.uma.parkour;
			this.onwall = this.uma.onwall;
			this.onwallclimbingup = this.uma.onwallclimbingup;
			this.onwallclimbing = this.uma.onwallclimbing;
			this.vault = this.uma.vault;
			this.rope = this.uma.rope;
			this.onropeclimbing = this.uma.onropeclimbing;
			this.jump = this.uma.jump;
			this.melee = this.uma.melee;
			this.die = this.uma.die;
			this.noitem = this.uma.noitem;
			this.onehand = this.uma.onehand;
			this.twohand = this.uma.twohand;
			this.twohandweapon = this.uma.twohandweapon;
			if (base.photonView.isMine)
			{
				if (!this.die && !this.idle && !this.jump && this.walkforward && this.run && !this.crouch && !this.parkour)
				{
					this.ph.curanimation = 2;
				}
				if (!this.die && !this.idle && !this.jump && this.walkforward && !this.run && !this.crouch && !this.parkour)
				{
					this.ph.curanimation = 1;
				}
				if (!this.die && !this.idle && !this.jump && this.walkforward && !this.run && this.crouch && !this.parkour)
				{
					this.ph.curanimation = 4;
				}
				if (!this.die && this.idle && !this.jump && !this.walkforward && this.crouch && !this.run && !this.parkour)
				{
					this.ph.curanimation = 3;
				}
				if (!this.die && !this.jump && this.idle && !this.walkforward && !this.crouch && !this.run && !this.parkour)
				{
					this.ph.curanimation = 0;
				}
				if (!this.die && this.jump && !this.parkour)
				{
					this.ph.curanimation = 5;
				}
				if (!this.die && this.parkour && this.onwall && !this.onwallclimbing && !this.onwallclimbingup)
				{
					this.ph.curanimation = 6;
				}
				if (!this.die && this.parkour && this.onwall && this.onwallclimbing && !this.onwallclimbingup)
				{
					this.ph.curanimation = 7;
				}
				if (!this.die && this.parkour && this.onwall && !this.onwallclimbing && this.onwallclimbingup)
				{
					this.ph.curanimation = 7;
				}
				if (!this.die && this.parkour && this.vault)
				{
					this.ph.curanimation = 8;
				}
				if (!this.die && this.parkour && this.rope)
				{
					this.ph.curanimation = 9;
				}
				if (!this.die && this.parkour && this.rope && this.onropeclimbing)
				{
					this.ph.curanimation = 10;
				}
				if (this.die)
				{
					this.ph.curanimation = 11;
				}
			}
		}
		else
		{
			this.playermodel = base.transform.Find("model");
		}
		if (GameObject.Find(this.modname).GetComponent<Spawnmpmodel>().hasloadedmod && this.playermodel == null && this.hasmod)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GameObject.Find(this.modname).GetComponent<Spawnmpmodel>().playermodobject, base.transform.position, base.transform.rotation);
			gameObject.transform.parent = base.gameObject.transform;
			this.playermodel = gameObject.transform.Find("model");
			if (gameObject.transform.Find("model/mesh"))
			{
				Material[] materials = gameObject.transform.Find("model/mesh").GetComponent<SkinnedMeshRenderer>().materials;
				foreach (Material material in materials)
				{
					if (!material.shader.name.Contains("Transparent"))
					{
						material.shader = Shader.Find("Legacy Shaders/Diffuse");
					}
					else
					{
						material.shader = Shader.Find("Legacy Shaders/Transparent/Cutout/Diffuse");
					}
				}
				gameObject.transform.Find("model/mesh").GetComponent<SkinnedMeshRenderer>().materials = materials;
			}
			this.playermodel.GetComponent<Animation>().AddClip(this.p.onehand, "player-1h");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.twohand, "player-2h");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.twohandweapon, "player-2hweapon");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.crawling, "player-crawling");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.crouch, "player-crouch");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.die, "player-die");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.idle, "player-idle");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.jump, "player-jump");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.melee, "player-melee");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.movingbackwards, "player-movingbackwards");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.movingforward, "player-movingforward");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.movingleft, "player-movingleft");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.movingright, "player-movingright");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.onrope, "player-onrope");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.onropemoving, "player-onropemoving");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.onwall, "player-onwall");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.onwallclimbing, "player-onwallclimbing");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.onwallclimbingup, "player-onwallclimbingup");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.run, "player-run");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.vault, "player-vault");
			this.playermodel.GetComponent<Animation>()["player-vault"].speed = 0.5f;
			this.playermodel.GetComponent<Animation>().AddClip(this.p.walk1h, "walk-1h");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.walk2h, "walk-2h");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.walk2hweapon, "walk-2hweapon");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.run1h, "run-1h");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.run2h, "run-2h");
			this.playermodel.GetComponent<Animation>().AddClip(this.p.run2hweapon, "run-2hweapon");
			this.mix = this.playermodel.Find("Bip01/Bip01 Pelvis/Bip01 Spine");
		}
		if (base.photonView.isMine && !this.enablethirdperson)
		{
			this.playermodel.transform.Find("mesh").GetComponent<Renderer>().enabled = false;
		}
		if (base.photonView.isMine && !this.thirdperson && this.enablethirdperson)
		{
			this.playermodel.transform.Find("mesh").GetComponent<Renderer>().enabled = false;
		}
		if (base.photonView.isMine && this.thirdperson && this.enablethirdperson)
		{
			this.playermodel.transform.Find("mesh").GetComponent<Renderer>().enabled = true;
		}
		if (this.hasmod && this.playermodel != null)
		{
			if (this.ph.curanimation == 0)
			{
				this.Idle1();
			}
			if (this.ph.curanimation == 1)
			{
				this.Walk1();
			}
			if (this.ph.curanimation == 2)
			{
				this.Run1();
			}
			if (this.ph.curanimation == 3)
			{
				this.Crouch1();
			}
			if (this.ph.curanimation == 4)
			{
				this.Crawling1();
			}
			if (this.ph.curanimation == 5)
			{
				this.Jump1();
			}
			if (this.ph.curanimation == 6)
			{
				this.OnWall1();
			}
			if (this.ph.curanimation == 7)
			{
				this.OnWallClimbing1();
			}
			if (this.ph.curanimation == 8)
			{
				this.Vault1();
			}
			if (this.ph.curanimation == 9)
			{
				this.Rope1();
			}
			if (this.ph.curanimation == 10)
			{
				this.OnRopeClimbing1();
			}
			if (this.ph.curanimation == 11)
			{
				this.Die1();
			}
		}
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00012110 File Offset: 0x00010510
	private void Idle1()
	{
		if (!this.onehand && !this.twohand && !this.twohandweapon)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-idle");
		}
		if (this.onehand)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-1h");
		}
		if (this.twohand)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-2h");
		}
		if (this.twohandweapon)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-2hweapon");
		}
	}

	// Token: 0x06000130 RID: 304 RVA: 0x000121C8 File Offset: 0x000105C8
	private void Walk1()
	{
		if (!this.onehand && !this.twohand && !this.twohandweapon)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-movingforward");
		}
		if (this.onehand)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("walk-1h");
		}
		if (this.twohand)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("walk-2h");
		}
		if (this.twohandweapon)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("walk-2hweapon");
		}
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00012280 File Offset: 0x00010680
	private void Run1()
	{
		if (!this.onehand && !this.twohand && !this.twohandweapon)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-run");
		}
		if (this.onehand)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("run-1h");
		}
		if (this.twohand)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("run-2h");
		}
		if (this.twohandweapon)
		{
			this.playermodel.gameObject.GetComponent<Animation>().CrossFade("run-2hweapon");
		}
	}

	// Token: 0x06000132 RID: 306 RVA: 0x00012337 File Offset: 0x00010737
	private void Jump1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-jump");
	}

	// Token: 0x06000133 RID: 307 RVA: 0x00012353 File Offset: 0x00010753
	private void Crouch1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-crouch");
	}

	// Token: 0x06000134 RID: 308 RVA: 0x0001236F File Offset: 0x0001076F
	private void Crawling1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-crawling");
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0001238B File Offset: 0x0001078B
	private void OnWall1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-onwall");
	}

	// Token: 0x06000136 RID: 310 RVA: 0x000123A7 File Offset: 0x000107A7
	private void OnWallClimbing1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-onwallclimbing");
	}

	// Token: 0x06000137 RID: 311 RVA: 0x000123C3 File Offset: 0x000107C3
	private void OnWallClimbingup1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-onwallclimbingup");
	}

	// Token: 0x06000138 RID: 312 RVA: 0x000123DF File Offset: 0x000107DF
	private void Vault1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-vault");
	}

	// Token: 0x06000139 RID: 313 RVA: 0x000123FB File Offset: 0x000107FB
	private void Rope1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-onrope");
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00012417 File Offset: 0x00010817
	private void OnRopeClimbing1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-onropemoving");
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00012433 File Offset: 0x00010833
	private void Die1()
	{
		this.playermodel.gameObject.GetComponent<Animation>().CrossFade("player-die");
	}

	// Token: 0x0600013C RID: 316 RVA: 0x0001244F File Offset: 0x0001084F
	private void Idle()
	{
		this.Idle1();
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00012457 File Offset: 0x00010857
	private void Walk()
	{
		this.Walk1();
	}

	// Token: 0x0600013E RID: 318 RVA: 0x0001245F File Offset: 0x0001085F
	private void Run()
	{
		this.Run1();
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00012467 File Offset: 0x00010867
	private void Jump()
	{
		this.Jump1();
	}

	// Token: 0x06000140 RID: 320 RVA: 0x0001246F File Offset: 0x0001086F
	private void Crouch()
	{
		this.Crouch1();
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00012477 File Offset: 0x00010877
	private void Crawling()
	{
		this.Crawling1();
	}

	// Token: 0x06000142 RID: 322 RVA: 0x0001247F File Offset: 0x0001087F
	private void OnWall()
	{
		this.OnWall1();
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00012487 File Offset: 0x00010887
	private void OnWallClimbing()
	{
		this.OnWallClimbing1();
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0001248F File Offset: 0x0001088F
	private void OnWallClimbingup()
	{
		this.OnWallClimbingup1();
	}

	// Token: 0x06000145 RID: 325 RVA: 0x00012497 File Offset: 0x00010897
	private void Vault()
	{
		this.Vault1();
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0001249F File Offset: 0x0001089F
	private void Rope()
	{
		this.Rope1();
	}

	// Token: 0x06000147 RID: 327 RVA: 0x000124A7 File Offset: 0x000108A7
	private void OnRopeClimbing()
	{
		this.OnRopeClimbing1();
	}

	// Token: 0x06000148 RID: 328 RVA: 0x000124AF File Offset: 0x000108AF
	private void Die()
	{
		this.Die1();
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000124B7 File Offset: 0x000108B7
	[RPC]
	private void GetModelName(string p)
	{
		if (base.photonView.isMine)
		{
			p = this.modname;
		}
		this.modname = p;
		this.hasmod = true;
		Debug.Log("Loaded " + this.modname);
	}

	// Token: 0x040001D5 RID: 469
	public bool crouch;

	// Token: 0x040001D6 RID: 470
	public bool run;

	// Token: 0x040001D7 RID: 471
	public bool walkforward;

	// Token: 0x040001D8 RID: 472
	public bool walkbackward;

	// Token: 0x040001D9 RID: 473
	public bool walkleft;

	// Token: 0x040001DA RID: 474
	public bool walkright;

	// Token: 0x040001DB RID: 475
	public bool idle;

	// Token: 0x040001DC RID: 476
	public Transform playermodel;

	// Token: 0x040001DD RID: 477
	public bool check = true;

	// Token: 0x040001DE RID: 478
	public bool parkour;

	// Token: 0x040001DF RID: 479
	public bool onwall;

	// Token: 0x040001E0 RID: 480
	public bool onwallclimbingup;

	// Token: 0x040001E1 RID: 481
	public bool onwallclimbing;

	// Token: 0x040001E2 RID: 482
	public bool vault;

	// Token: 0x040001E3 RID: 483
	public bool rope;

	// Token: 0x040001E4 RID: 484
	public bool onropeclimbing;

	// Token: 0x040001E5 RID: 485
	public bool jump;

	// Token: 0x040001E6 RID: 486
	public bool melee;

	// Token: 0x040001E7 RID: 487
	public bool die;

	// Token: 0x040001E8 RID: 488
	public bool noitem;

	// Token: 0x040001E9 RID: 489
	public bool onehand;

	// Token: 0x040001EA RID: 490
	public bool twohand;

	// Token: 0x040001EB RID: 491
	public bool twohandweapon;

	// Token: 0x040001EC RID: 492
	public UpdateMyAnimation uma;

	// Token: 0x040001ED RID: 493
	public PlayerAnimations p;

	// Token: 0x040001EE RID: 494
	public PlayerHandler ph;

	// Token: 0x040001EF RID: 495
	public Transform mix;

	// Token: 0x040001F0 RID: 496
	public bool hasmod;

	// Token: 0x040001F1 RID: 497
	public string modname;

	// Token: 0x040001F2 RID: 498
	public GameObject modelsource;

	// Token: 0x040001F3 RID: 499
	public bool thirdperson;

	// Token: 0x040001F4 RID: 500
	public bool enablethirdperson;

	// Token: 0x040001F5 RID: 501
	public bool cantoggleview;

	// Token: 0x040001F6 RID: 502
	public bool isCinematic;

	// Token: 0x040001F7 RID: 503
	public Transform maincam;

	// Token: 0x040001F8 RID: 504
	public Transform ovrcam;

	// Token: 0x040001F9 RID: 505
	public bool changenow;
}
