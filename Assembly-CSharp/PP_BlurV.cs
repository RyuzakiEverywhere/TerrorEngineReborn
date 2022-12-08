using System;
using UnityEngine;

// Token: 0x02000053 RID: 83
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BlurV")]
public class PP_BlurV : PostProcessBase
{
	// Token: 0x060001A3 RID: 419 RVA: 0x00015A9A File Offset: 0x00013E9A
	private void Awake()
	{
		base.material.SetFloat("_BlurMulti", this.blurMultiplier);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00015AB2 File Offset: 0x00013EB2
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/BlurV");
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00015AC4 File Offset: 0x00013EC4
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_BlurMulti", this.blurMultiplier);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000287 RID: 647
	public float blurMultiplier = 1f;
}
