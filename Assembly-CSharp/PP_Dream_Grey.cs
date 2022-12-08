using System;
using UnityEngine;

// Token: 0x02000059 RID: 89
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Dream_Grey")]
public class PP_Dream_Grey : PostProcessBase
{
	// Token: 0x060001B9 RID: 441 RVA: 0x00015D26 File Offset: 0x00014126
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Dream_Grey");
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00015D38 File Offset: 0x00014138
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
