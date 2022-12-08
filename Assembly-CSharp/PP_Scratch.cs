using System;
using UnityEngine;

// Token: 0x02000072 RID: 114
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Scratch")]
public class PP_Scratch : PostProcessBase
{
	// Token: 0x06000213 RID: 531 RVA: 0x00016D2C File Offset: 0x0001512C
	private void Awake()
	{
		if (this.noiseTexture)
		{
			base.material.SetTexture("_Noise", this.noiseTexture);
		}
		base.material.SetTexture("_Noise", this.noiseTexture);
		base.material.SetFloat("_Speed1", this.speed1);
		base.material.SetFloat("_Speed2", this.speed2);
		base.material.SetFloat("_Intensity", this.intensity);
		base.material.SetFloat("_ScratchWidth", this.scratchWidth);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x00016DCD File Offset: 0x000151CD
	private void OnEnable()
	{
		if (!this.noiseTexture)
		{
			Debug.LogWarning("You must set the noiseTexture Texture");
		}
		this.shader = Shader.Find("Hidden/Aubergine/Scratch");
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00016DFC File Offset: 0x000151FC
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_Noise", this.noiseTexture);
		base.material.SetFloat("_Speed1", this.speed1);
		base.material.SetFloat("_Speed2", this.speed2);
		base.material.SetFloat("_Intensity", this.intensity);
		base.material.SetFloat("_ScratchWidth", this.scratchWidth);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002C0 RID: 704
	public Texture noiseTexture;

	// Token: 0x040002C1 RID: 705
	public float speed1 = 0.03f;

	// Token: 0x040002C2 RID: 706
	public float speed2 = 0.01f;

	// Token: 0x040002C3 RID: 707
	public float intensity = 0.5f;

	// Token: 0x040002C4 RID: 708
	public float scratchWidth = 0.01f;
}
