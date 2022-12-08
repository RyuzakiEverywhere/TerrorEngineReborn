using System;
using UnityEngine;

// Token: 0x02000066 RID: 102
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Negative")]
public class PP_Negative : PostProcessBase
{
	// Token: 0x060001E6 RID: 486 RVA: 0x0001647B File Offset: 0x0001487B
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Negative");
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0001648D File Offset: 0x0001488D
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
