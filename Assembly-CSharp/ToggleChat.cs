using System;
using UnityEngine;

// Token: 0x02000160 RID: 352
public class ToggleChat : MonoBehaviour
{
	// Token: 0x06000869 RID: 2153 RVA: 0x0004E008 File Offset: 0x0004C408
	private void Start()
	{
		base.gameObject.GetComponent<Chat>().enabled = false;
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x0004E01B File Offset: 0x0004C41B
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			base.gameObject.GetComponent<Chat>().enabled = !base.gameObject.GetComponent<Chat>().enabled;
		}
	}
}
