using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/LineArt")]
public class PP_LineArt : PostProcessBase
{
	// Token: 0x060001E2 RID: 482 RVA: 0x000163EE File Offset: 0x000147EE
	private void Awake()
	{
		base.material.SetVector("_LineColor", this.lineColor);
		base.material.SetFloat("_LineAmount", this.lineAmount);
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00016421 File Offset: 0x00014821
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/LineArt");
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00016433 File Offset: 0x00014833
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetVector("_LineColor", this.lineColor);
		base.material.SetFloat("_LineAmount", this.lineAmount);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002A1 RID: 673
	public Color lineColor = Color.black;

	// Token: 0x040002A2 RID: 674
	public float lineAmount = 80f;
}
