using System;
using UnityEngine;

// Token: 0x0200004D RID: 77
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/4Bit")]
public class PP_4Bit : PostProcessBase
{
	// Token: 0x0600018C RID: 396 RVA: 0x00015818 File Offset: 0x00013C18
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/4Bit");
	}

	// Token: 0x0600018D RID: 397 RVA: 0x0001582A File Offset: 0x00013C2A
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_BitDepth", (float)this.bitDepth);
		base.material.SetFloat("_Contrast", this.contrast);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x0400027F RID: 639
	public int bitDepth = 1;

	// Token: 0x04000280 RID: 640
	public float contrast = 1f;
}
