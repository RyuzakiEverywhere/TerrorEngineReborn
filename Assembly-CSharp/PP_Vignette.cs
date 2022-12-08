using System;
using UnityEngine;

// Token: 0x02000087 RID: 135
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Vignette")]
public class PP_Vignette : PostProcessBase
{
	// Token: 0x0600025F RID: 607 RVA: 0x00017813 File Offset: 0x00015C13
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Vignette");
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00017825 File Offset: 0x00015C25
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Radius", this.radius);
		base.material.SetFloat("_Darkness", this.darkness);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002E1 RID: 737
	public float radius = 3f;

	// Token: 0x040002E2 RID: 738
	public float darkness = 0.5f;
}
