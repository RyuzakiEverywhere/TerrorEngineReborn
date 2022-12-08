using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class ExplosionDestroy : MonoBehaviour
{
	// Token: 0x0600007C RID: 124 RVA: 0x00009705 File Offset: 0x00007B05
	private void Start()
	{
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00009707 File Offset: 0x00007B07
	private void Update()
	{
		UnityEngine.Object.Destroy(base.GetComponent<Collider>(), 1f);
	}
}
