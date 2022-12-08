using System;
using UnityEngine;

// Token: 0x02000073 RID: 115
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/ScreenWaves")]
public class PP_ScreenWaves : PostProcessBase
{
	// Token: 0x06000217 RID: 535 RVA: 0x00016EA2 File Offset: 0x000152A2
	private void Awake()
	{
		base.material.SetFloat("_Speed", this.speed);
		base.material.SetFloat("_Amplitude", this.amplitude);
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00016ED0 File Offset: 0x000152D0
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/ScreenWaves");
	}

	// Token: 0x06000219 RID: 537 RVA: 0x00016EE2 File Offset: 0x000152E2
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Speed", this.speed);
		base.material.SetFloat("_Amplitude", this.amplitude);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002C5 RID: 709
	public float speed = 10f;

	// Token: 0x040002C6 RID: 710
	public float amplitude = 0.09f;
}
