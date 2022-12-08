using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000025 RID: 37
public class GlobalEventsSync : MonoBehaviour
{
	// Token: 0x0600009C RID: 156 RVA: 0x0000A5F4 File Offset: 0x000089F4
	private void Start()
	{
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000A5F8 File Offset: 0x000089F8
	private void Update()
	{
		if (GameObject.Find("Play(Clone)") != null && !this.synced && this.orgtrigger.Length == 0)
		{
			base.StartCoroutine(this.WaitAndPrint(0.1f));
			this.synced = true;
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000A64C File Offset: 0x00008A4C
	private IEnumerator WaitAndPrint(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		this.synced = false;
		this.Sync();
		yield break;
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000A670 File Offset: 0x00008A70
	private void Sync()
	{
		this.orgtrigger = GameObject.FindGameObjectsWithTag("Event");
		this.newtrigger = GameObject.FindGameObjectsWithTag("OnlineEvent");
		for (int i = 0; i < this.orgtrigger.Length; i++)
		{
			this.orgtrigger[i].name = "Org Event" + i.ToString();
		}
	}

	// Token: 0x040000D8 RID: 216
	public bool syncevents;

	// Token: 0x040000D9 RID: 217
	public bool synced;

	// Token: 0x040000DA RID: 218
	public GameObject[] orgtrigger;

	// Token: 0x040000DB RID: 219
	public GameObject[] newtrigger;
}
