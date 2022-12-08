using System;
using UnityEngine;

// Token: 0x0200007D RID: 125
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV7")]
public class PP_SobelOutlineV7 : PostProcessBase
{
	// Token: 0x0600023D RID: 573 RVA: 0x000172C0 File Offset: 0x000156C0
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x0600023E RID: 574 RVA: 0x000172D8 File Offset: 0x000156D8
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV7");
	}

	// Token: 0x0600023F RID: 575 RVA: 0x000172EA File Offset: 0x000156EA
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002D2 RID: 722
	public float threshold = 0.7f;
}
