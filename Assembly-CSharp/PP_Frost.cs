using System;
using UnityEngine;

// Token: 0x0200005E RID: 94
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Frost")]
public class PP_Frost : PostProcessBase
{
	// Token: 0x060001C9 RID: 457 RVA: 0x00015EA9 File Offset: 0x000142A9
	private void Awake()
	{
		if (this.noiseMap)
		{
			base.material.SetTexture("_NoiseMap", this.noiseMap);
		}
	}

	// Token: 0x060001CA RID: 458 RVA: 0x00015ED1 File Offset: 0x000142D1
	private void OnEnable()
	{
		if (!this.noiseMap)
		{
			Debug.LogWarning("You must set the noiseMap Texture");
		}
		this.shader = Shader.Find("Hidden/Aubergine/Frost");
	}

	// Token: 0x060001CB RID: 459 RVA: 0x00015EFD File Offset: 0x000142FD
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_NoiseMap", this.noiseMap);
		base.material.SetFloat("_Amount", this.frequenzy);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000291 RID: 657
	public Texture noiseMap;

	// Token: 0x04000292 RID: 658
	public float frequenzy = 1f;
}
