using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Godrays1")]
public class PP_Godrays1 : PostProcessBase
{
	// Token: 0x060001CD RID: 461 RVA: 0x00015F40 File Offset: 0x00014340
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Godrays1");
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00015F52 File Offset: 0x00014352
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
