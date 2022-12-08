using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/LightWave")]
public class PP_LightWave : PostProcessBase
{
	// Token: 0x060001DF RID: 479 RVA: 0x00016362 File Offset: 0x00014762
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/LightWave");
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00016374 File Offset: 0x00014774
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Red", this.red);
		base.material.SetFloat("_Green", this.green);
		base.material.SetFloat("_Blue", this.blue);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x0400029E RID: 670
	public float red = 4f;

	// Token: 0x0400029F RID: 671
	public float green = 4f;

	// Token: 0x040002A0 RID: 672
	public float blue = 4f;
}
