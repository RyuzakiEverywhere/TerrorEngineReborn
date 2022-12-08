using System;
using UnityEngine;

// Token: 0x020000FD RID: 253
[ExecuteInEditMode]
public class NightVisionEffect : MonoBehaviour
{
	// Token: 0x1700002C RID: 44
	// (get) Token: 0x0600050F RID: 1295 RVA: 0x0003A14C File Offset: 0x0003854C
	private Material material
	{
		get
		{
			if (this.curMaterial == null)
			{
				this.curMaterial = new Material(this.nightVisionShader);
				this.curMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.curMaterial;
		}
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x0003A183 File Offset: 0x00038583
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (!this.nightVisionShader && !this.nightVisionShader.isSupported)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x0003A1C0 File Offset: 0x000385C0
	private void Update()
	{
		this.contrast = Mathf.Clamp(this.contrast, this.contrastRange.x, this.contrastRange.y);
		this.brightness = Mathf.Clamp(this.brightness, this.brightnessRange.x, this.brightnessRange.y);
		this.randomValue = (float)UnityEngine.Random.Range(-1, 1);
		this.distortion = Mathf.Clamp(this.distortion, this.distortionRange.x, this.distortionRange.y);
		this.scale = Mathf.Clamp(this.scale, this.scaleRange.x, this.scaleRange.y);
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x0003A278 File Offset: 0x00038678
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.nightVisionShader != null)
		{
			this.material.SetFloat("_Contrast", this.contrast);
			this.material.SetFloat("_Brightness", this.brightness);
			this.material.SetColor("_NightVisionColor", this.nightVisionColor);
			this.material.SetFloat("_RandomValue", this.randomValue);
			this.material.SetFloat("_distortion", this.distortion);
			this.material.SetFloat("_scale", this.scale);
			if (this.vignetteTexture && this.hasVignetteTexture)
			{
				this.material.SetFloat("_hasVignetteTex", 1f);
				this.material.SetTexture("_VignetteTex", this.vignetteTexture);
			}
			else
			{
				this.material.SetFloat("_hasVignetteTex", 0f);
			}
			if (this.scanLineTexture && this.hasScanLineTexture)
			{
				this.material.SetFloat("_hasScanLineTex", 1f);
				this.material.SetTexture("_ScanLineTex", this.scanLineTexture);
				this.material.SetFloat("_ScanLineTileAmount", this.scanLineTileAmount);
			}
			else
			{
				this.material.SetFloat("_hasScanLineTex", 0f);
			}
			if (this.nightVisionNoise && this.hasNightVisionNoise)
			{
				this.material.SetFloat("_hasNoiseTex", 1f);
				this.material.SetTexture("_NoiseTex", this.nightVisionNoise);
				this.material.SetFloat("_NoiseXSpeed", this.noiseXSpeed);
				this.material.SetFloat("_NoiseYSpeed", this.noiseYSpeed);
			}
			else
			{
				this.material.SetFloat("_hasNoiseTex", 0f);
			}
			Graphics.Blit(sourceTexture, destTexture, this.material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	// Token: 0x040007DA RID: 2010
	public Shader nightVisionShader;

	// Token: 0x040007DB RID: 2011
	public float contrast = 2f;

	// Token: 0x040007DC RID: 2012
	public float brightness = 0.1f;

	// Token: 0x040007DD RID: 2013
	public Color nightVisionColor = Color.green;

	// Token: 0x040007DE RID: 2014
	public bool hasVignetteTexture = true;

	// Token: 0x040007DF RID: 2015
	public Texture2D vignetteTexture;

	// Token: 0x040007E0 RID: 2016
	public bool hasScanLineTexture = true;

	// Token: 0x040007E1 RID: 2017
	public Texture2D scanLineTexture;

	// Token: 0x040007E2 RID: 2018
	public float scanLineTileAmount = 4f;

	// Token: 0x040007E3 RID: 2019
	public bool hasNightVisionNoise = true;

	// Token: 0x040007E4 RID: 2020
	public Texture2D nightVisionNoise;

	// Token: 0x040007E5 RID: 2021
	public float noiseXSpeed = 100f;

	// Token: 0x040007E6 RID: 2022
	public float noiseYSpeed = 100f;

	// Token: 0x040007E7 RID: 2023
	public float distortion = 0.2f;

	// Token: 0x040007E8 RID: 2024
	public float scale = 1f;

	// Token: 0x040007E9 RID: 2025
	private float randomValue;

	// Token: 0x040007EA RID: 2026
	private Material curMaterial;

	// Token: 0x040007EB RID: 2027
	[HideInInspector]
	public Vector2 contrastRange = new Vector2(0f, 4f);

	// Token: 0x040007EC RID: 2028
	[HideInInspector]
	public Vector2 brightnessRange = new Vector2(0f, 1f);

	// Token: 0x040007ED RID: 2029
	[HideInInspector]
	public Vector2 distortionRange = new Vector2(-1f, 1f);

	// Token: 0x040007EE RID: 2030
	[HideInInspector]
	public Vector2 scaleRange = new Vector2(0f, 1f);
}
