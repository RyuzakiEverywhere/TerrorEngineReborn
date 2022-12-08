using System;
using UnityEngine;

// Token: 0x02000079 RID: 121
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV3")]
public class PP_SobelOutlineV3 : PostProcessBase
{
	// Token: 0x0600022D RID: 557 RVA: 0x00017138 File Offset: 0x00015538
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x0600022E RID: 558 RVA: 0x00017150 File Offset: 0x00015550
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV3");
	}

	// Token: 0x0600022F RID: 559 RVA: 0x00017162 File Offset: 0x00015562
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002CE RID: 718
	public float threshold = 0.7f;
}
