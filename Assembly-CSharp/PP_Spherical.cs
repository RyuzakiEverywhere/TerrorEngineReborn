using System;
using UnityEngine;

// Token: 0x0200007E RID: 126
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Spherical")]
public class PP_Spherical : PostProcessBase
{
	// Token: 0x06000241 RID: 577 RVA: 0x00017317 File Offset: 0x00015717
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Spherical");
	}

	// Token: 0x06000242 RID: 578 RVA: 0x00017329 File Offset: 0x00015729
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
