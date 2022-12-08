using System;
using UnityEngine;

// Token: 0x02000062 RID: 98
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/LensCircle")]
public class PP_LensCircle : PostProcessBase
{
	// Token: 0x060001D7 RID: 471 RVA: 0x00016041 File Offset: 0x00014441
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/LensCircle");
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00016053 File Offset: 0x00014453
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_RadiusX", this.radiusX);
		base.material.SetFloat("_RadiusY", this.radiusY);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000296 RID: 662
	public float radiusX = 1f;

	// Token: 0x04000297 RID: 663
	public float radiusY;
}
