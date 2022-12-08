using System;
using UnityEngine;

// Token: 0x0200005D RID: 93
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/FoggyScreen")]
public class PP_FoggyScreen : PostProcessBase
{
	// Token: 0x060001C5 RID: 453 RVA: 0x00015DFE File Offset: 0x000141FE
	private void Awake()
	{
		base.material.SetVector("_FogColor", this.fogColor);
		base.material.SetFloat("_FogThickness", this.fogThickness);
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x00015E31 File Offset: 0x00014231
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/FoggyScreen");
		base.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x00015E56 File Offset: 0x00014256
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetVector("_FogColor", this.fogColor);
		base.material.SetFloat("_FogThickness", this.fogThickness);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x0400028F RID: 655
	public Color fogColor = Color.gray;

	// Token: 0x04000290 RID: 656
	public float fogThickness = 1f;
}
