using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class GetItemInfo : Photon.MonoBehaviour
{
	// Token: 0x0600008E RID: 142 RVA: 0x00009B75 File Offset: 0x00007F75
	private void Awake()
	{
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00009B78 File Offset: 0x00007F78
	private void Start()
	{
		this.itemtypes = GameObject.Find("ITEMTypes");
		if (base.gameObject.name == "ic1")
		{
			this.infoobj = this.itemtypes.transform.Find("Item_Type1");
		}
		if (base.gameObject.name == "ic2")
		{
			this.infoobj = this.itemtypes.transform.Find("Item_Type2");
		}
		if (base.gameObject.name == "ic3")
		{
			this.infoobj = this.itemtypes.transform.Find("Item_Type3");
		}
		if (base.gameObject.name == "ic4")
		{
			this.infoobj = this.itemtypes.transform.Find("Item_Type4");
		}
		if (base.gameObject.name == "ic5")
		{
			this.infoobj = this.itemtypes.transform.Find("Item_Type5");
		}
		this.info = this.infoobj.gameObject.GetComponent<CustomItemsProperties>();
		if (this.info.castlight)
		{
			base.gameObject.AddComponent<Light>();
			base.gameObject.GetComponent<Light>().color = this.infoobj.GetComponent<Light>().color;
			base.gameObject.GetComponent<Light>().type = this.infoobj.GetComponent<Light>().type;
			base.gameObject.GetComponent<Light>().range = this.infoobj.GetComponent<Light>().range;
			if (this.info.spotlight)
			{
				base.gameObject.GetComponent<Light>().spotAngle = 50f;
			}
		}
		this.ammo = float.Parse(this.info.totalammo);
		this.totalammo = float.Parse(this.info.totalammo);
		this.player = base.gameObject.GetComponent<ItemPlacement>().player;
		this.sa = this.player.GetComponent<SyncAnimation>();
		if (this.info.showblood)
		{
			this.Bullet = this.Bulletwithblood;
		}
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00009DC4 File Offset: 0x000081C4
	private void Update()
	{
		if (!base.photonView.isMine)
		{
			base.gameObject.transform.localEulerAngles = new Vector3(350f, 276f, 264f);
		}
		if (Input.GetKey(KeyCode.Q))
		{
			this.isshooting = false;
			base.gameObject.GetComponent<SyncAnimation>().noitem = true;
			base.gameObject.GetComponent<SyncAnimation>().onehand = false;
			base.gameObject.GetComponent<SyncAnimation>().twohand = false;
			base.gameObject.GetComponent<SyncAnimation>().twohandweapon = false;
		}
		if (base.GetComponent<AudioSource>().clip == null && this.info.sound != null)
		{
			base.GetComponent<AudioSource>().clip = this.info.sound;
		}
		if (base.photonView.isMine && Input.GetKeyDown(KeyCode.Mouse0) && this.info.canshoot && !this.isshooting && this.ammo > 0f)
		{
			if (this.info.multishot)
			{
				base.photonView.RPC("ShootSync", PhotonTargets.All, new object[0]);
			}
			else
			{
				this.ammo -= 1f;
				this.camshake.shakecam = true;
				base.gameObject.GetComponent<itemAnimation>().shoot = true;
				base.photonView.RPC("ShootSyncSingle", PhotonTargets.All, new object[0]);
			}
		}
		if (base.photonView.isMine && Input.GetKeyUp(KeyCode.Mouse0) && this.info.canshoot && this.info.multishot)
		{
			base.photonView.RPC("StopShootSync", PhotonTargets.All, new object[0]);
		}
		if (base.photonView.isMine && Input.GetKeyDown(KeyCode.Mouse1) && this.info.canmelee && !this.ismelee)
		{
			base.photonView.RPC("MeleeSync", PhotonTargets.All, new object[0]);
		}
		if (this.fire)
		{
			base.StartCoroutine(this.Shoot(float.Parse(this.info.delay)));
		}
		if (this.melee && !this.ismelee)
		{
			if (base.photonView.isMine)
			{
				base.gameObject.GetComponent<itemAnimation>().melee = true;
			}
			base.StartCoroutine(this.MeleeAttack(float.Parse(this.info.delay)));
		}
		if (this.multifiring && !this.isshooting)
		{
			base.StartCoroutine(this.Shoot(float.Parse(this.info.delay)));
		}
		if (this.info.onehand)
		{
			this.player.GetComponent<SyncAnimation>().noitem = false;
			this.player.GetComponent<SyncAnimation>().onehand = true;
			this.player.GetComponent<SyncAnimation>().twohand = false;
			this.player.GetComponent<SyncAnimation>().twohandweapon = false;
		}
		if (this.info.twohand)
		{
			this.player.GetComponent<SyncAnimation>().noitem = false;
			this.player.GetComponent<SyncAnimation>().onehand = false;
			this.player.GetComponent<SyncAnimation>().twohand = true;
			this.player.GetComponent<SyncAnimation>().twohandweapon = false;
		}
		if (this.info.twohandweapon)
		{
			this.player.GetComponent<SyncAnimation>().noitem = false;
			this.player.GetComponent<SyncAnimation>().onehand = false;
			this.player.GetComponent<SyncAnimation>().twohand = false;
			this.player.GetComponent<SyncAnimation>().twohandweapon = true;
		}
		if (this.ammo < 0f)
		{
			this.ammo = 0f;
		}
		if (this.totalammo < this.ammo)
		{
			this.ammo = this.totalammo;
		}
	}

	// Token: 0x06000091 RID: 145 RVA: 0x0000A1E4 File Offset: 0x000085E4
	private IEnumerator MeleeAttack(float waitTime)
	{
		this.ismelee = true;
		this.sa.melee = true;
		yield return new WaitForSeconds(waitTime);
		this.sa.melee = false;
		this.melee = false;
		this.ismelee = false;
		yield break;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x0000A208 File Offset: 0x00008608
	private IEnumerator Shoot(float waitTime)
	{
		if (this.ammo > 0f)
		{
			this.isshooting = true;
			yield return new WaitForSeconds(waitTime);
			this.camshake.shakecam = true;
			base.gameObject.GetComponent<itemAnimation>().shoot = true;
			this.ammo -= 1f;
			if (base.GetComponent<AudioSource>().clip != null)
			{
				base.GetComponent<AudioSource>().Play();
			}
			Transform obj = UnityEngine.Object.Instantiate<Transform>(this.Bullet, this.firepos.position, this.firepos.rotation);
			obj.gameObject.name = this.info.damage;
			this.isshooting = false;
		}
		yield break;
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0000A22C File Offset: 0x0000862C
	private void OnGUI()
	{
		if (base.photonView.isMine && this.info.canshoot)
		{
			GUI.Label(new Rect((float)(Screen.width - 100), (float)(Screen.height - 125), 1000f, 30f), "Ammo: " + this.ammo.ToString());
		}
	}

	// Token: 0x06000094 RID: 148 RVA: 0x0000A29A File Offset: 0x0000869A
	[RPC]
	private void ShootSync()
	{
		this.multifiring = true;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000A2A3 File Offset: 0x000086A3
	[RPC]
	private void StopShootSync()
	{
		this.multifiring = false;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0000A2AC File Offset: 0x000086AC
	[RPC]
	private void ShootSyncSingle()
	{
		if (base.GetComponent<AudioSource>().clip != null)
		{
			base.GetComponent<AudioSource>().Play();
		}
		Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Bullet, this.firepos.position, this.firepos.rotation);
		transform.gameObject.name = this.info.damage;
	}

	// Token: 0x06000097 RID: 151 RVA: 0x0000A314 File Offset: 0x00008714
	[RPC]
	private void MeleeSync()
	{
		this.melee = true;
		Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Bullet, this.firepos.position, this.firepos.rotation);
		UnityEngine.Object.Instantiate(Resources.Load("woosh"), this.firepos.position, this.firepos.rotation);
		transform.gameObject.AddComponent<DestoryAfterTimer>();
		transform.gameObject.name = this.info.damage;
	}

	// Token: 0x040000C8 RID: 200
	public Transform infoobj;

	// Token: 0x040000C9 RID: 201
	public CustomItemsProperties info;

	// Token: 0x040000CA RID: 202
	public Transform Bullet;

	// Token: 0x040000CB RID: 203
	public Transform Bulletwithblood;

	// Token: 0x040000CC RID: 204
	public bool isshooting;

	// Token: 0x040000CD RID: 205
	public Transform firepos;

	// Token: 0x040000CE RID: 206
	public bool fire;

	// Token: 0x040000CF RID: 207
	public GameObject itemtypes;

	// Token: 0x040000D0 RID: 208
	public float ammo;

	// Token: 0x040000D1 RID: 209
	public float totalammo;

	// Token: 0x040000D2 RID: 210
	public GameObject player;

	// Token: 0x040000D3 RID: 211
	public bool melee;

	// Token: 0x040000D4 RID: 212
	public bool ismelee;

	// Token: 0x040000D5 RID: 213
	public CameraShootShake camshake;

	// Token: 0x040000D6 RID: 214
	public SyncAnimation sa;

	// Token: 0x040000D7 RID: 215
	public bool multifiring;
}
