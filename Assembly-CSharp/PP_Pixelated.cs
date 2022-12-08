using System;
using UnityEngine;

// Token: 0x0200006B RID: 107
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Pixelated")]
public class PP_Pixelated : PostProcessBase
{
	// Token: 0x060001F8 RID: 504 RVA: 0x000167CE File Offset: 0x00014BCE
	private void Awake()
	{
		base.material.SetFloat("_PixWidth", this.pixWidth);
		base.material.SetFloat("_PixHeight", this.pixHeight);
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x000167FC File Offset: 0x00014BFC
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Pixelated");
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0001680E File Offset: 0x00014C0E
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_PixWidth", this.pixWidth);
		base.material.SetFloat("_PixHeight", this.pixHeight);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002AC RID: 684
	public float pixWidth = 6f;

	// Token: 0x040002AD RID: 685
	public float pixHeight = 6f;
}
