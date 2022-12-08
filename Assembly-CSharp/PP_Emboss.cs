using System;
using UnityEngine;

// Token: 0x0200005B RID: 91
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Emboss")]
public class PP_Emboss : PostProcessBase
{
	// Token: 0x060001BF RID: 447 RVA: 0x00015D78 File Offset: 0x00014178
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Emboss");
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00015D8A File Offset: 0x0001418A
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
