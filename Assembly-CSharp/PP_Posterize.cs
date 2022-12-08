using System;
using UnityEngine;

// Token: 0x0200006C RID: 108
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Posterize")]
public class PP_Posterize : PostProcessBase
{
	// Token: 0x060001FC RID: 508 RVA: 0x00016867 File Offset: 0x00014C67
	private void Awake()
	{
		base.material.SetFloat("_Colors", this.colors);
		base.material.SetFloat("_Gamma", this.gamma);
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00016895 File Offset: 0x00014C95
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Posterize");
	}

	// Token: 0x060001FE RID: 510 RVA: 0x000168A7 File Offset: 0x00014CA7
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Colors", this.colors);
		base.material.SetFloat("_Gamma", this.gamma);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002AE RID: 686
	public float colors = 4f;

	// Token: 0x040002AF RID: 687
	public float gamma = 1f;
}
