using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000036 RID: 54
public class PNPCMechanics : Photon.MonoBehaviour
{
	// Token: 0x060000EA RID: 234 RVA: 0x0000E7A4 File Offset: 0x0000CBA4
	private void OnEnable()
	{
		this.pnpcmodel = base.transform.Find("npc-pos/npc(Clone)").gameObject;
		this.mp = GameObject.Find("Events/Monster Start Point").GetComponent<MonsterProperties>();
		this.runspeed = float.Parse(this.mp.runspeed);
		this.walkspeed = float.Parse(this.mp.walkspeed);
		if (base.photonView.isMine)
		{
			this.cm = base.gameObject.GetComponent<NPCMovement>();
			this.cm.jumpSpeed = float.Parse(this.mp.jumpheight);
			this.damage = float.Parse(this.mp.damage);
			this.startpos = base.transform.position;
		}
		base.gameObject.layer = 2;
		this.pnpcmodel.gameObject.layer = 2;
		MeshRenderer[] componentsInChildren = this.pnpcmodel.gameObject.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			Material[] materials = meshRenderer.materials;
			foreach (Material material in materials)
			{
				material.shader = Shader.Find("Legacy Shaders/Transparent/Cutout/Diffuse");
			}
			meshRenderer.materials = materials;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = this.pnpcmodel.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			Material[] materials2 = skinnedMeshRenderer.materials;
			foreach (Material material2 in materials2)
			{
				material2.shader = Shader.Find("Legacy Shaders/Transparent/Cutout/Diffuse");
			}
			skinnedMeshRenderer.materials = materials2;
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x0000E97C File Offset: 0x0000CD7C
	private void Start()
	{
		if (base.photonView.isMine)
		{
			GameObject.Find("PNPCHUD").GetComponent<GUITexture>().enabled = true;
		}
		GameObject.Find("BlackScreen").GetComponent<GUITexture>().enabled = false;
		base.InvokeRepeating("ScanForTarget", 0f, this.scanFrequency);
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000E9DC File Offset: 0x0000CDDC
	private void Update()
	{
		if (base.photonView.isMine)
		{
			base.GetComponent<PlayerHandlerNPC>().curanimation = this.curanimation;
			this.curanimation = base.GetComponent<PlayerHandlerNPC>().curanimation;
			this.players = GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject gameObject in this.players)
			{
				if (gameObject.GetComponent<Light>() == null)
				{
					gameObject.AddComponent<Light>();
					gameObject.GetComponent<Light>().color = Color.red;
					gameObject.GetComponent<Light>().range = 10f;
				}
			}
			if (Input.GetKeyDown(KeyCode.Mouse0) && !this.die)
			{
				this.curanimation = 3;
				base.photonView.RPC("Attack", PhotonTargets.All, new object[0]);
			}
			if (this.health <= 0f)
			{
				this.curanimation = 4;
				base.photonView.RPC("Die", PhotonTargets.All, new object[0]);
			}
			RenderSettings.ambientLight = Color.white;
			if (this.attack)
			{
				base.StartCoroutine(this.AttackWait());
				this.wait = false;
			}
			if (Input.GetKeyDown(KeyCode.LeftShift) && !this.attack)
			{
				this.run = true;
				this.cm.speed = this.runspeed;
			}
			if (Input.GetKeyUp(KeyCode.LeftShift) && !this.attack)
			{
				this.run = false;
				this.cm.speed = this.walkspeed;
			}
			if (this.oldpos != base.transform.position)
			{
				if (!this.attack && !this.die)
				{
					if (this.run)
					{
						this.curanimation = 2;
					}
					else
					{
						this.curanimation = 1;
					}
				}
			}
			else if (!this.attack && !this.die)
			{
				this.curanimation = 0;
			}
		}
		else
		{
			this.curanimation = base.GetComponent<PlayerHandlerNPC>().curanimation;
		}
		if (this.curanimation == 0)
		{
			this.pnpcmodel.GetComponent<Animation>().CrossFade("idle");
		}
		if (this.curanimation == 1)
		{
			this.pnpcmodel.GetComponent<Animation>().CrossFade("walk");
		}
		if (this.curanimation == 2)
		{
			this.pnpcmodel.GetComponent<Animation>().CrossFade("run");
		}
		if (this.curanimation == 3)
		{
			this.pnpcmodel.GetComponent<Animation>().CrossFade("attack");
		}
		if (this.curanimation == 4)
		{
			this.pnpcmodel.GetComponent<Animation>().CrossFade("death");
		}
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000ECA0 File Offset: 0x0000D0A0
	private void LateUpdate()
	{
		this.oldpos = base.transform.position;
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000ECB4 File Offset: 0x0000D0B4
	private IEnumerator DieWait()
	{
		this.wait = true;
		if (base.photonView.isMine)
		{
			this.curanimation = 4;
		}
		if (base.photonView.isMine)
		{
			base.gameObject.GetComponent<NPCMovement>().enabled = false;
		}
		yield return new WaitForSeconds(5f);
		if (base.photonView.isMine)
		{
			base.gameObject.GetComponent<NPCMovement>().enabled = true;
		}
		this.health = 100f;
		base.transform.position = this.startpos;
		this.die = false;
		this.wait = false;
		yield break;
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0000ECD0 File Offset: 0x0000D0D0
	private IEnumerator AttackWait()
	{
		if (base.photonView.isMine)
		{
			this.curanimation = 3;
		}
		this.wait = true;
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(0.5f);
		this.wait = false;
		this.attack = false;
		yield break;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x0000ECEB File Offset: 0x0000D0EB
	private void ScanForTarget()
	{
		this.target = this.GetNearestTaggedObject();
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x0000ECFC File Offset: 0x0000D0FC
	private GameObject GetNearestTaggedObject()
	{
		float num = float.PositiveInfinity;
		this.players = GameObject.FindGameObjectsWithTag("Player");
		GameObject result = null;
		foreach (GameObject gameObject in this.players)
		{
			Vector3 position = gameObject.transform.position;
			float sqrMagnitude = (position - base.transform.position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				result = gameObject;
				num = sqrMagnitude;
			}
		}
		return result;
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x0000ED80 File Offset: 0x0000D180
	private void AttackNow()
	{
		if (this.target != null)
		{
			this.curdis = Vector3.Distance(this.target.transform.position, base.transform.position);
			if (this.curdis <= 8f)
			{
				this.damage = float.Parse(GameObject.FindGameObjectWithTag("MonsterStartPoint").GetComponent<MonsterProperties>().damage);
				this.target.GetComponent<PlayerHealth>().health -= this.damage;
			}
		}
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x0000EE10 File Offset: 0x0000D210
	[RPC]
	private void Attack()
	{
		this.attack = true;
		this.AttackNow();
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0000EE1F File Offset: 0x0000D21F
	[RPC]
	private void Die()
	{
		this.die = true;
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000EE28 File Offset: 0x0000D228
	[RPC]
	private void Run()
	{
		this.run = true;
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x0000EE31 File Offset: 0x0000D231
	[RPC]
	private void StopRun()
	{
		this.run = false;
	}

	// Token: 0x04000159 RID: 345
	public GameObject pnpcmodel;

	// Token: 0x0400015A RID: 346
	public GameObject[] players;

	// Token: 0x0400015B RID: 347
	public MonsterProperties mp;

	// Token: 0x0400015C RID: 348
	public NPCMovement cm;

	// Token: 0x0400015D RID: 349
	public float walkspeed;

	// Token: 0x0400015E RID: 350
	public float runspeed;

	// Token: 0x0400015F RID: 351
	public float jumpheight;

	// Token: 0x04000160 RID: 352
	public float damage;

	// Token: 0x04000161 RID: 353
	public float health = 100f;

	// Token: 0x04000162 RID: 354
	public Transform attackobj;

	// Token: 0x04000163 RID: 355
	public GameObject curattobj;

	// Token: 0x04000164 RID: 356
	public Vector3 startpos;

	// Token: 0x04000165 RID: 357
	public float scanFrequency = 1f;

	// Token: 0x04000166 RID: 358
	public GameObject target;

	// Token: 0x04000167 RID: 359
	public float curdis;

	// Token: 0x04000168 RID: 360
	public bool die;

	// Token: 0x04000169 RID: 361
	public bool wait;

	// Token: 0x0400016A RID: 362
	public bool attack;

	// Token: 0x0400016B RID: 363
	public Vector3 oldpos;

	// Token: 0x0400016C RID: 364
	public bool run;

	// Token: 0x0400016D RID: 365
	public int curanimation;
}
