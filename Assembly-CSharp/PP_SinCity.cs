using System;
using UnityEngine;

// Token: 0x02000075 RID: 117
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SinCity")]
public class PP_SinCity : PostProcessBase
{
	// Token: 0x0600021E RID: 542 RVA: 0x00016FDE File Offset: 0x000153DE
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SinCity");
	}

	// Token: 0x0600021F RID: 543 RVA: 0x00016FF0 File Offset: 0x000153F0
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
