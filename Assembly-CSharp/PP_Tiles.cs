using System;
using UnityEngine;

// Token: 0x02000084 RID: 132
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Tiles")]
public class PP_Tiles : PostProcessBase
{
	// Token: 0x06000256 RID: 598 RVA: 0x0001765F File Offset: 0x00015A5F
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Tiles");
	}

	// Token: 0x06000257 RID: 599 RVA: 0x00017674 File Offset: 0x00015A74
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("numTiles", this.numTiles);
		base.material.SetFloat("threshold", this.threshold);
		base.material.SetColor("edgeColor", this.edgeColor);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002D8 RID: 728
	public float numTiles = 32f;

	// Token: 0x040002D9 RID: 729
	public float threshold = 0.16f;

	// Token: 0x040002DA RID: 730
	public Color edgeColor = Color.grey;
}
