using System;
using UnityEngine;

// Token: 0x02000051 RID: 81
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BloomSimple")]
public class PP_BloomSimple : PostProcessBase
{
	// Token: 0x0600019B RID: 411 RVA: 0x000159D6 File Offset: 0x00013DD6
	private void Awake()
	{
		base.material.SetFloat("_Strength", this.strength);
	}

	// Token: 0x0600019C RID: 412 RVA: 0x000159EE File Offset: 0x00013DEE
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/BloomSimple");
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00015A00 File Offset: 0x00013E00
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Strength", this.strength);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000285 RID: 645
	public float strength = 0.5f;
}
