using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/EdgeDetect")]
public class PP_EdgeDetect : PostProcessBase
{
	// Token: 0x060001BC RID: 444 RVA: 0x00015D4F File Offset: 0x0001414F
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/EdgeDetect");
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00015D61 File Offset: 0x00014161
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
