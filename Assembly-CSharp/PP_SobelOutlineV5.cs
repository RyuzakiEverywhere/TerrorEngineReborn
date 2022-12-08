using System;
using UnityEngine;

// Token: 0x0200007B RID: 123
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV5")]
public class PP_SobelOutlineV5 : PostProcessBase
{
	// Token: 0x06000235 RID: 565 RVA: 0x000171FC File Offset: 0x000155FC
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x06000236 RID: 566 RVA: 0x00017214 File Offset: 0x00015614
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV5");
	}

	// Token: 0x06000237 RID: 567 RVA: 0x00017226 File Offset: 0x00015626
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002D0 RID: 720
	public float threshold = 0.7f;
}
