using System;
using UnityEngine;

// Token: 0x02000082 RID: 130
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/ThermalVisionV2")]
public class PP_ThermalVisionV2 : PostProcessBase
{
	// Token: 0x0600024F RID: 591 RVA: 0x000174B0 File Offset: 0x000158B0
	private void Awake()
	{
		if (this.thermalTex)
		{
			base.material.SetTexture("_ThermalTex", this.thermalTex);
		}
		if (this.noiseTex)
		{
			base.material.SetTexture("_NoiseTex", this.noiseTex);
		}
		base.material.SetFloat("_NoiseAmount", this.noiseAmount);
	}

	// Token: 0x06000250 RID: 592 RVA: 0x00017520 File Offset: 0x00015920
	private void OnEnable()
	{
		if (!this.noiseTex || !this.thermalTex)
		{
			Debug.LogWarning("You must set the necessary textures");
		}
		this.shader = Shader.Find("Hidden/Aubergine/ThermalVisionV2");
		base.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	// Token: 0x06000251 RID: 593 RVA: 0x0001757C File Offset: 0x0001597C
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_ThermalTex", this.thermalTex);
		base.material.SetTexture("_NoiseTex", this.noiseTex);
		base.material.SetFloat("_NoiseAmount", this.noiseAmount);
		Matrix4x4 inverse = (base.GetComponent<Camera>().projectionMatrix * base.GetComponent<Camera>().worldToCameraMatrix).inverse;
		base.material.SetMatrix("_ViewProjectInverse", inverse);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002D5 RID: 725
	public Texture thermalTex;

	// Token: 0x040002D6 RID: 726
	public Texture noiseTex;

	// Token: 0x040002D7 RID: 727
	public float noiseAmount = 0.3f;
}
