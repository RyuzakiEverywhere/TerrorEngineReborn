using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/ToneMap")]
public class PP_ToneMap : PostProcessBase
{
	// Token: 0x0600025C RID: 604 RVA: 0x000177A8 File Offset: 0x00015BA8
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/ToneMap");
	}

	// Token: 0x0600025D RID: 605 RVA: 0x000177BA File Offset: 0x00015BBA
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Exposure", this.exposure);
		base.material.SetFloat("_Gamma", this.gamma);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002DF RID: 735
	public float exposure = 0.1f;

	// Token: 0x040002E0 RID: 736
	public float gamma = 1f;
}
