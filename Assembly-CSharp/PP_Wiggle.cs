using System;
using UnityEngine;

// Token: 0x02000088 RID: 136
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Wiggle")]
public class PP_Wiggle : PostProcessBase
{
	// Token: 0x06000262 RID: 610 RVA: 0x0001787E File Offset: 0x00015C7E
	private void Awake()
	{
		base.material.SetFloat("_Speed", this.speed);
		base.material.SetFloat("_Amplitude", this.amplitude);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x000178AC File Offset: 0x00015CAC
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Wiggle");
	}

	// Token: 0x06000264 RID: 612 RVA: 0x000178BE File Offset: 0x00015CBE
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Speed", this.speed);
		base.material.SetFloat("_Amplitude", this.amplitude);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002E3 RID: 739
	public float speed = 10f;

	// Token: 0x040002E4 RID: 740
	public float amplitude = 0.01f;
}
