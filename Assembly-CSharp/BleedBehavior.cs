using System;
using UnityEngine;

// Token: 0x0200008C RID: 140
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/BloodOverlay")]
public class BleedBehavior : MonoBehaviour
{
	// Token: 0x06000270 RID: 624 RVA: 0x00017AE7 File Offset: 0x00015EE7
	private void Awake()
	{
		this._material = new Material(this.Shader);
		this._material.SetTexture("_BlendTex", this.Image);
		this._material.SetTexture("_BumpMap", this.Normals);
	}

	// Token: 0x06000271 RID: 625 RVA: 0x00017B28 File Offset: 0x00015F28
	public void Update()
	{
		if (this.autoFadeOut && BleedBehavior.BloodAmount > 0f)
		{
			BleedBehavior.BloodAmount -= this.autoFadeOutAbsReduc * Time.deltaTime;
			BleedBehavior.BloodAmount *= Mathf.Pow(1f - this.autoFadeOutRelReduc, Time.deltaTime);
			BleedBehavior.BloodAmount = Mathf.Max(BleedBehavior.BloodAmount, 0f);
		}
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00017B9C File Offset: 0x00015F9C
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!Application.isPlaying)
		{
			this._material.SetTexture("_BlendTex", this.Image);
			this._material.SetTexture("_BumpMap", this.Normals);
			float num = Mathf.Clamp01(this.TestingBloodAmount) * (1f - BleedBehavior.minBloodAmount) + BleedBehavior.minBloodAmount;
			num = Mathf.Clamp01(num * (this.maxAlpha - this.minAlpha) + this.minAlpha);
			num = Mathf.Lerp(this.prevBloodAmount, num, Mathf.Clamp01(this.updateSpeed * Time.deltaTime));
			this._material.SetFloat("_BlendAmount", num);
			this.prevBloodAmount = num;
		}
		else
		{
			float num2 = Mathf.Clamp01(BleedBehavior.BloodAmount) * (1f - BleedBehavior.minBloodAmount) + BleedBehavior.minBloodAmount;
			num2 = Mathf.Clamp01(num2 * (this.maxAlpha - this.minAlpha) + this.minAlpha);
			num2 = Mathf.Lerp(this.prevBloodAmount, num2, Mathf.Clamp01(this.updateSpeed * Time.deltaTime));
			this._material.SetFloat("_BlendAmount", num2);
			this.prevBloodAmount = num2;
		}
		this._material.SetFloat("_EdgeSharpness", this.EdgeSharpness);
		this._material.SetFloat("_Distortion", this.distortion);
		Graphics.Blit(source, destination, this._material);
	}

	// Token: 0x040002ED RID: 749
	public static float BloodAmount;

	// Token: 0x040002EE RID: 750
	public float TestingBloodAmount = 0.5f;

	// Token: 0x040002EF RID: 751
	public static float minBloodAmount;

	// Token: 0x040002F0 RID: 752
	public float EdgeSharpness = 1f;

	// Token: 0x040002F1 RID: 753
	public float minAlpha;

	// Token: 0x040002F2 RID: 754
	public float maxAlpha = 1f;

	// Token: 0x040002F3 RID: 755
	public float distortion = 0.2f;

	// Token: 0x040002F4 RID: 756
	public bool autoFadeOut = true;

	// Token: 0x040002F5 RID: 757
	public float autoFadeOutAbsReduc = 0.05f;

	// Token: 0x040002F6 RID: 758
	public float autoFadeOutRelReduc = 0.5f;

	// Token: 0x040002F7 RID: 759
	public float updateSpeed = 20f;

	// Token: 0x040002F8 RID: 760
	private float prevBloodAmount;

	// Token: 0x040002F9 RID: 761
	public Texture2D Image;

	// Token: 0x040002FA RID: 762
	public Texture2D Normals;

	// Token: 0x040002FB RID: 763
	public Shader Shader;

	// Token: 0x040002FC RID: 764
	private Material _material;
}
