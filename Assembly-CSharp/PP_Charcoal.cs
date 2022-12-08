using System;
using UnityEngine;

// Token: 0x02000054 RID: 84
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Charcoal")]
public class PP_Charcoal : PostProcessBase
{
	// Token: 0x060001A7 RID: 423 RVA: 0x00015AFC File Offset: 0x00013EFC
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Charcoal");
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00015B0E File Offset: 0x00013F0E
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetVector("_LineColor", this.lineColor);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000288 RID: 648
	public Color lineColor = Color.black;
}
