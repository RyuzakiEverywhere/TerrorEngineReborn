using System;
using UnityEngine;

// Token: 0x0200007C RID: 124
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV6")]
public class PP_SobelOutlineV6 : PostProcessBase
{
	// Token: 0x06000239 RID: 569 RVA: 0x0001725E File Offset: 0x0001565E
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x0600023A RID: 570 RVA: 0x00017276 File Offset: 0x00015676
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV6");
	}

	// Token: 0x0600023B RID: 571 RVA: 0x00017288 File Offset: 0x00015688
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002D1 RID: 721
	public float threshold = 0.7f;
}
