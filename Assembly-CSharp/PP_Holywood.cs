using System;
using UnityEngine;

// Token: 0x02000061 RID: 97
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Holywood")]
public class PP_Holywood : PostProcessBase
{
	// Token: 0x060001D3 RID: 467 RVA: 0x00015FDF File Offset: 0x000143DF
	private void Awake()
	{
		base.material.SetFloat("_LumThreshold", this.lumThreshold);
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x00015FF7 File Offset: 0x000143F7
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Holywood");
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x00016009 File Offset: 0x00014409
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_LumThreshold", this.lumThreshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000295 RID: 661
	public float lumThreshold = 0.13f;
}
