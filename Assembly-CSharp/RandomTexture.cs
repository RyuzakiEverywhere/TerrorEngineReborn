using System;
using UnityEngine;

// Token: 0x020001BE RID: 446
public class RandomTexture : MonoBehaviour
{
	// Token: 0x06000A9A RID: 2714 RVA: 0x0005CDFE File Offset: 0x0005B1FE
	private void Awake()
	{
		this.num = UnityEngine.Random.Range(0, this.textures.Length);
		base.GetComponent<Renderer>().material.mainTexture = this.textures[this.num];
	}

	// Token: 0x04000C83 RID: 3203
	public Texture2D[] textures;

	// Token: 0x04000C84 RID: 3204
	private int num;
}
