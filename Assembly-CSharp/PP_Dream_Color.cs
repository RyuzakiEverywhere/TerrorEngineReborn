using System;
using UnityEngine;

// Token: 0x02000058 RID: 88
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Dream_Color")]
public class PP_Dream_Color : PostProcessBase
{
	// Token: 0x060001B6 RID: 438 RVA: 0x00015CFD File Offset: 0x000140FD
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Dream_Color");
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00015D0F File Offset: 0x0001410F
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
