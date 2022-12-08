using System;
using UnityEngine;

// Token: 0x02000057 RID: 87
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Displacement")]
public class PP_Displace : PostProcessBase
{
	// Token: 0x060001B2 RID: 434 RVA: 0x00015C50 File Offset: 0x00014050
	private void Awake()
	{
		if (this.bumpTexture)
		{
			base.material.SetTexture("_BumpTex", this.bumpTexture);
		}
		base.material.SetFloat("_Amount", this.bumpAmount);
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00015C8E File Offset: 0x0001408E
	private void OnEnable()
	{
		if (!this.bumpTexture)
		{
			Debug.LogWarning("You must set the bumpTexture Texture");
		}
		this.shader = Shader.Find("Hidden/Aubergine/Displacement");
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00015CBA File Offset: 0x000140BA
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_BumpTex", this.bumpTexture);
		base.material.SetFloat("_Amount", this.bumpAmount);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x0400028C RID: 652
	public Texture bumpTexture;

	// Token: 0x0400028D RID: 653
	public float bumpAmount = 0.5f;
}
