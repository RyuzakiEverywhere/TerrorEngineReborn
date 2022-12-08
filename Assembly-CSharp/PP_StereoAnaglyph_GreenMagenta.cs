using System;
using UnityEngine;

// Token: 0x02000080 RID: 128
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/StereoAnaglyph_GreenMagenta")]
public class PP_StereoAnaglyph_GreenMagenta : PostProcessBase
{
	// Token: 0x06000248 RID: 584 RVA: 0x000173E9 File Offset: 0x000157E9
	private void Awake()
	{
		base.material.SetFloat("_Distance", this.distance);
	}

	// Token: 0x06000249 RID: 585 RVA: 0x00017401 File Offset: 0x00015801
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/StereoAnaglyph_GreenMagenta");
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00017414 File Offset: 0x00015814
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Distance", this.distance);
		base.material.SetFloat("_TexSizeX", (float)source.width);
		base.material.SetFloat("_TexSizeY", (float)source.height);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002D4 RID: 724
	public float distance = 0.001f;
}
