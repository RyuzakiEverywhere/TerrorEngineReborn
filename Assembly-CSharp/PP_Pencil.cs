using System;
using UnityEngine;

// Token: 0x0200006A RID: 106
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Pencil")]
public class PP_Pencil : PostProcessBase
{
	// Token: 0x060001F4 RID: 500 RVA: 0x000166C8 File Offset: 0x00014AC8
	private void Awake()
	{
		if (this.pencilTexture)
		{
			base.material.SetTexture("_PencilTex", this.pencilTexture);
		}
		base.material.SetFloat("_Amount", this.effectStrength);
		base.material.SetFloat("_Brightness", this.brightness);
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00016727 File Offset: 0x00014B27
	private void OnEnable()
	{
		if (!this.pencilTexture)
		{
			Debug.LogWarning("You must set the pencilTexture Texture");
		}
		this.shader = Shader.Find("Hidden/Aubergine/Pencil");
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00016754 File Offset: 0x00014B54
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_PencilTex", this.pencilTexture);
		base.material.SetFloat("_Amount", this.effectStrength);
		base.material.SetFloat("_Brightness", this.brightness);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002A9 RID: 681
	public Texture pencilTexture;

	// Token: 0x040002AA RID: 682
	public float effectStrength = 0.5f;

	// Token: 0x040002AB RID: 683
	public float brightness = 0.5f;
}
