using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000041 RID: 65
public class Spawnmpmodel : Photon.MonoBehaviour
{
	// Token: 0x0600011E RID: 286 RVA: 0x000103C0 File Offset: 0x0000E7C0
	private void Awake()
	{
		if (base.photonView.isMine)
		{
			if (PlayerPrefs.GetString("Character") == null || PlayerPrefs.GetString("Character") == string.Empty)
			{
				PlayerPrefs.SetString("Character", "Default_Male.player");
			}
			this.playermodname = PlayerPrefs.GetString("Character");
		}
	}

	// Token: 0x0600011F RID: 287 RVA: 0x00010424 File Offset: 0x0000E824
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(0.2f);
		if (base.photonView.isMine)
		{
			if (GameObject.Find(PlayerPrefs.GetString("Character")) == null)
			{
				base.photonView.RPC("LoadModel", PhotonTargets.AllBuffered, new object[]
				{
					this.playermodname
				});
			}
			else
			{
				base.photonView.RPC("LoadModel2", PhotonTargets.AllBuffered, new object[]
				{
					this.playermodname
				});
			}
		}
		yield break;
	}

	// Token: 0x06000120 RID: 288 RVA: 0x00010440 File Offset: 0x0000E840
	private void Update()
	{
		if (this.loadmod && !this.isloading)
		{
			base.gameObject.name = this.playermodname;
			base.StartCoroutine(this.Loltart());
		}
		if (this.getmod && !this.isloading)
		{
			base.StartCoroutine(this.PreloadModel());
		}
	}

	// Token: 0x06000121 RID: 289 RVA: 0x000104A4 File Offset: 0x0000E8A4
	private IEnumerator PreloadModel()
	{
		this.isloading = true;
		while (GameObject.Find(this.playermodname).GetComponent<Spawnmpmodel>().playermodobject == null)
		{
			yield return new WaitForSeconds(0.1f);
			yield return null;
		}
		this.playermodobject = GameObject.Find(this.playermodname).GetComponent<Spawnmpmodel>().playermodobject;
		this.hasloadedmod = true;
		this.hasname = true;
		yield break;
	}

	// Token: 0x06000122 RID: 290 RVA: 0x000104C0 File Offset: 0x0000E8C0
	private IEnumerator Loltart()
	{
		this.isloading = true;
		this.url = Application.dataPath + "/Characters/Players/" + this.playermodname;
		WWW www = WWW.LoadFromCacheOrDownload("file://" + this.url, 1);
		yield return www;
		AssetBundle bundle = www.assetBundle;
		this.playermodobject = (bundle.LoadAsset("playermodel", typeof(GameObject)) as GameObject);
		this.hasloadedmod = true;
		this.hasname = true;
		bundle.Unload(false);
		yield break;
	}

	// Token: 0x06000123 RID: 291 RVA: 0x000104DB File Offset: 0x0000E8DB
	[RPC]
	private void LoadModel(string p)
	{
		if (base.photonView.isMine)
		{
			p = this.playermodname;
		}
		this.playermodname = p;
		this.loadmod = true;
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00010503 File Offset: 0x0000E903
	[RPC]
	private void LoadModel2(string p)
	{
		if (base.photonView.isMine)
		{
			p = this.playermodname;
		}
		this.playermodname = p;
		this.getmod = true;
	}

	// Token: 0x040001B0 RID: 432
	public string url;

	// Token: 0x040001B1 RID: 433
	public string playermodname;

	// Token: 0x040001B2 RID: 434
	public GameObject playermodobject;

	// Token: 0x040001B3 RID: 435
	public bool hasloadedmod;

	// Token: 0x040001B4 RID: 436
	public bool hasname;

	// Token: 0x040001B5 RID: 437
	public bool loadmod;

	// Token: 0x040001B6 RID: 438
	public bool getmod;

	// Token: 0x040001B7 RID: 439
	public bool isloading;
}
