using System;
using UnityEngine;

// Token: 0x0200024B RID: 587
public class CheckLoading : MonoBehaviour
{
	// Token: 0x0600106F RID: 4207 RVA: 0x000680E2 File Offset: 0x000664E2
	private void Start()
	{
		base.gameObject.GetComponent<Loading>().enabled = true;
	}

	// Token: 0x06001070 RID: 4208 RVA: 0x000680F5 File Offset: 0x000664F5
	private void Update()
	{
	}
}
