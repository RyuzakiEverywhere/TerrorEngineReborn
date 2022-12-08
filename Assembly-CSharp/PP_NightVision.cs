using System;
using UnityEngine;

// Token: 0x02000067 RID: 103
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/NightVision")]
public class PP_NightVision : PostProcessBase
{
	// Token: 0x060001E9 RID: 489 RVA: 0x000164A4 File Offset: 0x000148A4
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/NightVision");
	}

	// Token: 0x060001EA RID: 490 RVA: 0x000164B6 File Offset: 0x000148B6
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
