using System;
using UnityEngine;

// Token: 0x0200007F RID: 127
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/StereoAnaglyph_AmberBlue")]
public class PP_StereoAnaglyph_AmberBlue : PostProcessBase
{
	// Token: 0x06000244 RID: 580 RVA: 0x0001734B File Offset: 0x0001574B
	private void Awake()
	{
		base.material.SetFloat("_Distance", this.distance);
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00017363 File Offset: 0x00015763
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/StereoAnaglyph_AmberBlue");
	}

	// Token: 0x06000246 RID: 582 RVA: 0x00017378 File Offset: 0x00015778
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Distance", this.distance);
		base.material.SetFloat("_TexSizeX", (float)source.width);
		base.material.SetFloat("_TexSizeY", (float)source.height);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002D3 RID: 723
	public float distance = 0.005f;
}
