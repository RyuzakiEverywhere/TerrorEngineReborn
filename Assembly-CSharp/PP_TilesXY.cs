using System;
using UnityEngine;

// Token: 0x02000085 RID: 133
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/TilesXY")]
public class PP_TilesXY : PostProcessBase
{
	// Token: 0x06000259 RID: 601 RVA: 0x00017704 File Offset: 0x00015B04
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/TilesXY");
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00017718 File Offset: 0x00015B18
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("numTilesX", this.numTilesX);
		base.material.SetFloat("numTilesY", this.numTilesY);
		base.material.SetFloat("threshold", this.threshold);
		base.material.SetColor("edgeColor", this.edgeColor);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002DB RID: 731
	public float numTilesX = 32f;

	// Token: 0x040002DC RID: 732
	public float numTilesY = 32f;

	// Token: 0x040002DD RID: 733
	public float threshold = 0.16f;

	// Token: 0x040002DE RID: 734
	public Color edgeColor = Color.grey;
}
