using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200002A RID: 42
public class LoadNPC : MonoBehaviour
{
	// Token: 0x060000B0 RID: 176 RVA: 0x0000BD10 File Offset: 0x0000A110
	private void Update()
	{
		this.npcname = base.gameObject.GetComponent<NPCProperties>().npcmodelname;
		if (this.npcname != null && this.npcname != string.Empty && !this.hasname)
		{
			base.StartCoroutine(this.Loltart());
		}
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x0000BD6C File Offset: 0x0000A16C
	private IEnumerator Loltart()
	{
		this.hasname = true;
		this.url = Application.dataPath + "/Characters/NPC/" + this.npcname + ".npc";
		WWW www = WWW.LoadFromCacheOrDownload("file://" + this.url, 1);
		yield return www;
		AssetBundle bundle = www.assetBundle;
		this.NPC = (bundle.LoadAsset("npc", typeof(GameObject)) as GameObject);
		this.hasloadedmodel = true;
		bundle.Unload(false);
		yield break;
	}

	// Token: 0x04000101 RID: 257
	public string url;

	// Token: 0x04000102 RID: 258
	public string npcname;

	// Token: 0x04000103 RID: 259
	public GameObject NPC;

	// Token: 0x04000104 RID: 260
	public bool hasloadedmodel;

	// Token: 0x04000105 RID: 261
	public bool hasname;
}
