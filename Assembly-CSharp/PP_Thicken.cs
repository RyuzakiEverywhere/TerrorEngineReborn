using System;
using UnityEngine;

// Token: 0x02000083 RID: 131
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Thicken")]
public class PP_Thicken : PostProcessBase
{
	// Token: 0x06000253 RID: 595 RVA: 0x00017615 File Offset: 0x00015A15
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Thicken");
	}

	// Token: 0x06000254 RID: 596 RVA: 0x00017627 File Offset: 0x00015A27
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
