using System;
using UnityEngine;

// Token: 0x02000076 RID: 118
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelEdge")]
public class PP_SobelEdge : PostProcessBase
{
	// Token: 0x06000221 RID: 545 RVA: 0x00017012 File Offset: 0x00015412
	private void Awake()
	{
		base.material.SetFloat("_Threshold", this.threshold);
	}

	// Token: 0x06000222 RID: 546 RVA: 0x0001702A File Offset: 0x0001542A
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SobelEdge");
	}

	// Token: 0x06000223 RID: 547 RVA: 0x0001703C File Offset: 0x0001543C
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Threshold", this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002CB RID: 715
	public float threshold = 0.7f;
}
