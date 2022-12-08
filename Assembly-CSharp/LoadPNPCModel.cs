using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200002B RID: 43
public class LoadPNPCModel : MonoBehaviour
{
	// Token: 0x060000B3 RID: 179 RVA: 0x0000BEC1 File Offset: 0x0000A2C1
	private void Start()
	{
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x0000BEC4 File Offset: 0x0000A2C4
	private void Update()
	{
		this.playermodname = base.gameObject.GetComponent<LoadPlayerModel>().playermodname;
		if (this.playermodname != null && !this.hasname && !this.hasloadedmod)
		{
			base.StartCoroutine(this.Loltart());
		}
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x0000BF18 File Offset: 0x0000A318
	private IEnumerator Loltart()
	{
		this.hasname = true;
		this.url = Application.dataPath + "/Characters/NPC/" + this.playermodname + ".npc";
		WWW www = WWW.LoadFromCacheOrDownload("file://" + this.url, 1);
		yield return www;
		AssetBundle bundle = www.assetBundle;
		this.playermodobject = (bundle.LoadAsset("npc", typeof(GameObject)) as GameObject);
		if (this.ispnpc)
		{
			base.gameObject.AddComponent<PNPCMechanics>();
		}
		this.hasloadedmod = true;
		bundle.Unload(false);
		yield break;
	}

	// Token: 0x04000106 RID: 262
	public string url;

	// Token: 0x04000107 RID: 263
	public string playermodname;

	// Token: 0x04000108 RID: 264
	public GameObject playermodobject;

	// Token: 0x04000109 RID: 265
	public bool hasloadedmod;

	// Token: 0x0400010A RID: 266
	public bool hasname;

	// Token: 0x0400010B RID: 267
	public bool ispnpc;
}
