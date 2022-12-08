using System;
using UnityEngine;

// Token: 0x0200004F RID: 79
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BlackAndWhite")]
public class PP_BlackAndWhite : PostProcessBase
{
	// Token: 0x06000193 RID: 403 RVA: 0x00015912 File Offset: 0x00013D12
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x06000194 RID: 404 RVA: 0x0001592A File Offset: 0x00013D2A
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/BlackAndWhite");
	}

	// Token: 0x06000195 RID: 405 RVA: 0x0001593C File Offset: 0x00013D3C
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000283 RID: 643
	public float threshold = 0.5f;
}
