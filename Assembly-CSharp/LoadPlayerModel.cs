using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200002C RID: 44
public class LoadPlayerModel : MonoBehaviour
{
	// Token: 0x060000B7 RID: 183 RVA: 0x0000C090 File Offset: 0x0000A490
	private void Update()
	{
		this.playermodname = base.gameObject.GetComponent<LoadPlayerModel>().playermodname;
		if (this.playermodname != null && !this.hasname && !this.hasloadedmod)
		{
			base.StartCoroutine(this.Loltart());
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0000C0E4 File Offset: 0x0000A4E4
	private IEnumerator Loltart()
	{
		this.hasname = true;
		this.url = Application.dataPath + "/Characters/Players/Default_Player.player";
		WWW www = WWW.LoadFromCacheOrDownload("file://" + this.url, 1);
		yield return www;
		AssetBundle bundle = www.assetBundle;
		this.playermodobject = (bundle.LoadAsset("playermodel", typeof(GameObject)) as GameObject);
		this.hasloadedmod = true;
		bundle.Unload(false);
		yield break;
	}

	// Token: 0x0400010C RID: 268
	public string url;

	// Token: 0x0400010D RID: 269
	public string playermodname;

	// Token: 0x0400010E RID: 270
	public GameObject playermodobject;

	// Token: 0x0400010F RID: 271
	public bool hasloadedmod;

	// Token: 0x04000110 RID: 272
	public bool hasname;
}
