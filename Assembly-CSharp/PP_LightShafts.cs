using System;
using UnityEngine;

// Token: 0x02000063 RID: 99
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/LightShafts")]
public class PP_LightShafts : PostProcessBase
{
	// Token: 0x060001DA RID: 474 RVA: 0x000160C4 File Offset: 0x000144C4
	private void Awake()
	{
		base.material.SetFloat("_Density", this.density);
		base.material.SetFloat("_Weight", this.weight);
		base.material.SetFloat("_Decay", this.decay);
		base.material.SetFloat("_Exposure", this.exposure);
		this.lightSPos = base.GetComponent<Camera>().WorldToViewportPoint(this.lightSource.position);
		base.material.SetVector("_LightSPos", this.lightSPos);
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00016160 File Offset: 0x00014560
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/LightShafts");
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00016172 File Offset: 0x00014572
	private void Update()
	{
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00016174 File Offset: 0x00014574
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.lightSPos = base.GetComponent<Camera>().WorldToViewportPoint(this.lightSource.position);
		if (this.lightSPos.x < 0f || this.lightSPos.x > 1f || this.lightSPos.y < 0f || this.lightSPos.y > 1f || this.lightSPos.z < 0f)
		{
			base.material.SetVector("_LightSPos", new Vector3(0.5f, 0.5f, 0f));
			base.material.SetFloat("_Density", this.density - this.density + 0.1f);
			base.material.SetFloat("_Weight", this.weight);
			base.material.SetFloat("_Decay", this.decay);
			base.material.SetFloat("_Exposure", this.exposure);
		}
		else
		{
			base.material.SetVector("_LightSPos", this.lightSPos);
			base.material.SetFloat("_Density", this.density);
			base.material.SetFloat("_Weight", this.weight);
			base.material.SetFloat("_Decay", this.decay);
			base.material.SetFloat("_Exposure", this.exposure);
		}
		Debug.Log(base.GetComponent<Camera>().WorldToViewportPoint(this.lightSource.position));
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000298 RID: 664
	public Transform lightSource;

	// Token: 0x04000299 RID: 665
	public float density = 1f;

	// Token: 0x0400029A RID: 666
	public float weight = 1f;

	// Token: 0x0400029B RID: 667
	public float decay = 1f;

	// Token: 0x0400029C RID: 668
	public float exposure = 1f;

	// Token: 0x0400029D RID: 669
	private Vector3 lightSPos;
}
