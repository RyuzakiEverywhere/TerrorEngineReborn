using System;
using UnityEngine;

// Token: 0x0200005C RID: 92
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/FakeSSAO")]
public class PP_FakeSSAO : PostProcessBase
{
	// Token: 0x060001C2 RID: 450 RVA: 0x00015DA8 File Offset: 0x000141A8
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/FakeSSAO");
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x00015DBA File Offset: 0x000141BA
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_BaseC", (float)this.baseC);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x0400028E RID: 654
	public int baseC = 4;
}
