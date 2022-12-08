using System;
using UnityEngine;

// Token: 0x0200006E RID: 110
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/RadialBlur")]
public class PP_RadialBlur : PostProcessBase
{
	// Token: 0x06000203 RID: 515 RVA: 0x0001696B File Offset: 0x00014D6B
	private void Awake()
	{
		base.material.SetFloat("_CenterX", this.centerX);
		base.material.SetFloat("_CenterY", this.centerY);
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00016999 File Offset: 0x00014D99
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/RadialBlur");
	}

	// Token: 0x06000205 RID: 517 RVA: 0x000169AB File Offset: 0x00014DAB
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_CenterX", this.centerX);
		base.material.SetFloat("_CenterY", this.centerY);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002B2 RID: 690
	public float centerX = 0.5f;

	// Token: 0x040002B3 RID: 691
	public float centerY = 0.5f;
}
