using System;
using UnityEngine;

// Token: 0x02000077 RID: 119
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV1")]
public class PP_SobelOutlineV1 : PostProcessBase
{
	// Token: 0x06000225 RID: 549 RVA: 0x00017074 File Offset: 0x00015474
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x06000226 RID: 550 RVA: 0x0001708C File Offset: 0x0001548C
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV1");
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0001709E File Offset: 0x0001549E
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002CC RID: 716
	public float threshold = 0.7f;
}
