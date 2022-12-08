using System;
using UnityEngine;

// Token: 0x02000081 RID: 129
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/ThermalVision")]
public class PP_ThermalVision : PostProcessBase
{
	// Token: 0x0600024C RID: 588 RVA: 0x0001747A File Offset: 0x0001587A
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/ThermalVision");
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0001748C File Offset: 0x0001588C
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
