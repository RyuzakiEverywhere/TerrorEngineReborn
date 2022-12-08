using System;
using UnityEngine;

// Token: 0x02000069 RID: 105
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Noise")]
public class PP_Noise : PostProcessBase
{
	// Token: 0x060001F0 RID: 496 RVA: 0x00016658 File Offset: 0x00014A58
	private void Awake()
	{
		base.material.SetFloat("_NoiseScale", this.noiseScale);
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00016670 File Offset: 0x00014A70
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Noise");
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00016682 File Offset: 0x00014A82
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_NoiseScale", this.noiseScale);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002A8 RID: 680
	public float noiseScale = 0.5f;
}
