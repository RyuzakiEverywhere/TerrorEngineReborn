using System;
using UnityEngine;

// Token: 0x02000070 RID: 112
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Ripple")]
public class PP_Ripple : PostProcessBase
{
	// Token: 0x0600020B RID: 523 RVA: 0x00016AF4 File Offset: 0x00014EF4
	private void Awake()
	{
		base.material.SetFloat("_Speed", this.speed);
		base.material.SetFloat("_Amount", this.amount);
		base.material.SetFloat("_Strength", this.strength);
		base.material.SetFloat("_OffsetX", this.offsetX);
		base.material.SetFloat("_OffsetY", this.offsetY);
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00016B6F File Offset: 0x00014F6F
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Ripple");
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00016B84 File Offset: 0x00014F84
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Speed", this.speed);
		base.material.SetFloat("_Amount", this.amount);
		base.material.SetFloat("_Strength", this.strength);
		base.material.SetFloat("_OffsetX", this.offsetX);
		base.material.SetFloat("_OffsetY", this.offsetY);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002B8 RID: 696
	public float speed = 4f;

	// Token: 0x040002B9 RID: 697
	public float amount = 16f;

	// Token: 0x040002BA RID: 698
	public float strength = 0.009f;

	// Token: 0x040002BB RID: 699
	public float offsetX;

	// Token: 0x040002BC RID: 700
	public float offsetY;
}
