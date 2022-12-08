using System;
using UnityEngine;

// Token: 0x0200001E RID: 30
public class FaceTest : MonoBehaviour
{
	// Token: 0x0600007F RID: 127 RVA: 0x00009721 File Offset: 0x00007B21
	private void Start()
	{
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00009724 File Offset: 0x00007B24
	private void Update()
	{
		float num = 10f;
		if (Vector3.Angle(this.player.transform.forward, base.transform.position - this.player.transform.position) < num)
		{
			this.player.active = false;
		}
	}

	// Token: 0x040000BC RID: 188
	public GameObject player;
}
