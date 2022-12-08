using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SecurityCamera")]
public class PP_SecurityCamera : PostProcessBase
{
	// Token: 0x0600021B RID: 539 RVA: 0x00016F51 File Offset: 0x00015351
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/SecurityCamera");
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00016F64 File Offset: 0x00015364
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Speed", this.speed);
		base.material.SetFloat("_Thickness", this.thickness);
		base.material.SetFloat("_Luminance", this.luminance);
		base.material.SetFloat("_Darkness", this.darkness);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002C7 RID: 711
	public float speed = 2f;

	// Token: 0x040002C8 RID: 712
	public float thickness = 3f;

	// Token: 0x040002C9 RID: 713
	public float luminance = 0.5f;

	// Token: 0x040002CA RID: 714
	public float darkness = 0.75f;
}
