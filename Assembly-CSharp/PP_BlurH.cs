using System;
using UnityEngine;

// Token: 0x02000052 RID: 82
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BlurH")]
public class PP_BlurH : PostProcessBase
{
	// Token: 0x0600019F RID: 415 RVA: 0x00015A38 File Offset: 0x00013E38
	private void Awake()
	{
		base.material.SetFloat("_BlurMulti", this.blurMultiplier);
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x00015A50 File Offset: 0x00013E50
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/BlurH");
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x00015A62 File Offset: 0x00013E62
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_BlurMulti", this.blurMultiplier);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000286 RID: 646
	public float blurMultiplier = 1f;
}
