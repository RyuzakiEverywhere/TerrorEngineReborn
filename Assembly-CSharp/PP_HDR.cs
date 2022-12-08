using System;
using UnityEngine;

// Token: 0x02000060 RID: 96
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/HDR")]
public class PP_HDR : PostProcessBase
{
	// Token: 0x060001D0 RID: 464 RVA: 0x00015F7F File Offset: 0x0001437F
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/HDR");
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00015F91 File Offset: 0x00014391
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Amount", this.amount);
		base.material.SetFloat("_Multiplier", this.multiplier);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000293 RID: 659
	public float amount = 0.045f;

	// Token: 0x04000294 RID: 660
	public float multiplier = 1f;
}
