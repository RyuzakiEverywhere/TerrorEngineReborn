using System;
using UnityEngine;

// Token: 0x02000050 RID: 80
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Bleach")]
public class PP_Bleach : PostProcessBase
{
	// Token: 0x06000197 RID: 407 RVA: 0x00015974 File Offset: 0x00013D74
	private void Awake()
	{
		base.material.SetFloat("_Opacity", this.opacity);
	}

	// Token: 0x06000198 RID: 408 RVA: 0x0001598C File Offset: 0x00013D8C
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Bleach");
	}

	// Token: 0x06000199 RID: 409 RVA: 0x0001599E File Offset: 0x00013D9E
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Opacity", this.opacity);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000284 RID: 644
	public float opacity = 0.1f;
}
