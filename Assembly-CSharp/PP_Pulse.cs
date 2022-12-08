using System;
using UnityEngine;

// Token: 0x0200006D RID: 109
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Pulse")]
public class PP_Pulse : PostProcessBase
{
	// Token: 0x06000200 RID: 512 RVA: 0x00016900 File Offset: 0x00014D00
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Pulse");
	}

	// Token: 0x06000201 RID: 513 RVA: 0x00016912 File Offset: 0x00014D12
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Speed", this.speed);
		base.material.SetFloat("_Distance", this.distance);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002B0 RID: 688
	public float speed = 5f;

	// Token: 0x040002B1 RID: 689
	public float distance = 0.1f;
}
