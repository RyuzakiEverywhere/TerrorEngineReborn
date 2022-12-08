using System;
using UnityEngine;

// Token: 0x0200019E RID: 414
public class SpiderScript : MonoBehaviour
{
	// Token: 0x060009D3 RID: 2515 RVA: 0x000554B3 File Offset: 0x000538B3
	private void Start()
	{
	}

	// Token: 0x060009D4 RID: 2516 RVA: 0x000554B5 File Offset: 0x000538B5
	private void Update()
	{
		if (!base.GetComponent<Animation>().isPlaying)
		{
			base.GetComponent<Animation>().Play("idle");
		}
	}
}
