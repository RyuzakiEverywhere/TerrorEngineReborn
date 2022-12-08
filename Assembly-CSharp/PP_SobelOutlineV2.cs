using System;
using UnityEngine;

// Token: 0x02000078 RID: 120
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV2")]
public class PP_SobelOutlineV2 : PostProcessBase
{
	// Token: 0x06000229 RID: 553 RVA: 0x000170D6 File Offset: 0x000154D6
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x0600022A RID: 554 RVA: 0x000170EE File Offset: 0x000154EE
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV2");
	}

	// Token: 0x0600022B RID: 555 RVA: 0x00017100 File Offset: 0x00015500
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002CD RID: 717
	public float threshold = 0.7f;
}
