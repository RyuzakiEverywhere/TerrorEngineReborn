using System;
using UnityEngine;

// Token: 0x02000071 RID: 113
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Scanlines")]
public class PP_Scanlines : PostProcessBase
{
	// Token: 0x0600020F RID: 527 RVA: 0x00016C38 File Offset: 0x00015038
	private void Awake()
	{
		base.material.SetFloat("_Intense1", this.intense1);
		base.material.SetFloat("_Intense2", this.intense2);
		base.material.SetFloat("_Count", this.count);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x00016C87 File Offset: 0x00015087
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Scanlines");
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00016C9C File Offset: 0x0001509C
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Intense1", this.intense1);
		base.material.SetFloat("_Intense2", this.intense2);
		base.material.SetFloat("_Count", this.count);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002BD RID: 701
	public float intense1 = 0.9f;

	// Token: 0x040002BE RID: 702
	public float intense2 = 0.5f;

	// Token: 0x040002BF RID: 703
	public float count = 15f;
}
