using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV4")]
public class PP_SobelOutlineV4 : PostProcessBase
{
	// Token: 0x06000231 RID: 561 RVA: 0x0001719A File Offset: 0x0001559A
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x06000232 RID: 562 RVA: 0x000171B2 File Offset: 0x000155B2
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV4");
	}

	// Token: 0x06000233 RID: 563 RVA: 0x000171C4 File Offset: 0x000155C4
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002CF RID: 719
	public float threshold = 0.7f;
}
