using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000022 RID: 34
public class GetDataEvent : Photon.MonoBehaviour
{
	// Token: 0x0600008B RID: 139 RVA: 0x00009A95 File Offset: 0x00007E95
	private void Start()
	{
		base.StartCoroutine(this.WaitAndPrint(0.5f));
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00009AAC File Offset: 0x00007EAC
	private IEnumerator WaitAndPrint(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		base.gameObject.AddComponent<TriggerZone>();
		yield break;
	}

	// Token: 0x040000C5 RID: 197
	public string path;

	// Token: 0x040000C6 RID: 198
	public GameObject org;

	// Token: 0x040000C7 RID: 199
	public string type;
}
