using System;
using UnityEngine;

// Token: 0x02000068 RID: 104
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/NightVisionV2")]
public class PP_NightVisionV2 : PostProcessBase
{
	// Token: 0x060001EC RID: 492 RVA: 0x000164FC File Offset: 0x000148FC
	private void Awake()
	{
		if (this.noiseTex)
		{
			base.material.SetTexture("_NoiseTex", this.noiseTex);
		}
		base.material.SetFloat("_NoiseAmount", this.noiseAmount);
		base.material.SetFloat("_LumThreshold", this.lumThreshold);
		base.material.SetFloat("_BrightenFactor", this.brightenFactor);
		base.material.SetVector("_VisionColor", this.visionColor);
	}

	// Token: 0x060001ED RID: 493 RVA: 0x0001658C File Offset: 0x0001498C
	private void OnEnable()
	{
		if (!this.noiseTex)
		{
			Debug.LogWarning("You must set the noiseTex Texture");
		}
		this.shader = Shader.Find("Hidden/Aubergine/NightVisionV2");
	}

	// Token: 0x060001EE RID: 494 RVA: 0x000165B8 File Offset: 0x000149B8
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_NoiseTex", this.noiseTex);
		base.material.SetFloat("_NoiseAmount", this.noiseAmount);
		base.material.SetFloat("_LumThreshold", this.lumThreshold);
		base.material.SetFloat("_BrightenFactor", this.brightenFactor);
		base.material.SetVector("_VisionColor", this.visionColor);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002A3 RID: 675
	public Texture noiseTex;

	// Token: 0x040002A4 RID: 676
	public float noiseAmount = 0.9f;

	// Token: 0x040002A5 RID: 677
	public float lumThreshold = 0.2f;

	// Token: 0x040002A6 RID: 678
	public float brightenFactor = 2f;

	// Token: 0x040002A7 RID: 679
	public Color visionColor = Color.green;
}
