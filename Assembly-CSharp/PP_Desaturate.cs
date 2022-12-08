using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Desaturate")]
public class PP_Desaturate : PostProcessBase
{
	// Token: 0x060001AE RID: 430 RVA: 0x00015BEE File Offset: 0x00013FEE
	private void Awake()
	{
		base.material.SetFloat("_Amount", this.desaturate);
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00015C06 File Offset: 0x00014006
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Desaturate");
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00015C18 File Offset: 0x00014018
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Amount", this.desaturate);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x0400028B RID: 651
	public float desaturate = 0.5f;
}
