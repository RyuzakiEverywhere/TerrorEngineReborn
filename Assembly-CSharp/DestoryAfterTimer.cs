using System;
using UnityEngine;

// Token: 0x02000018 RID: 24
public class DestoryAfterTimer : MonoBehaviour
{
	// Token: 0x06000064 RID: 100 RVA: 0x00008503 File Offset: 0x00006903
	private void Start()
	{
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00008505 File Offset: 0x00006905
	private void Update()
	{
		UnityEngine.Object.Destroy(base.gameObject, this.timer);
	}

	// Token: 0x0400009B RID: 155
	public float timer = 0.03f;
}
