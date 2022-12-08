using System;
using UnityEngine;

// Token: 0x0200006F RID: 111
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Raindrops")]
public class PP_Raindrops : PostProcessBase
{
	// Token: 0x06000207 RID: 519 RVA: 0x00016A04 File Offset: 0x00014E04
	private void Awake()
	{
		if (this.bumpTexture)
		{
			base.material.SetTexture("_BumpTex", this.bumpTexture);
		}
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00016A2C File Offset: 0x00014E2C
	private void OnEnable()
	{
		if (!this.bumpTexture)
		{
			Debug.LogWarning("You must set the bumpTexture Texture");
		}
		this.shader = Shader.Find("Hidden/Aubergine/Raindrops");
	}

	// Token: 0x06000209 RID: 521 RVA: 0x00016A58 File Offset: 0x00014E58
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_BumpTex", this.bumpTexture);
		base.material.SetFloat("_Amount", this.bumpAmount);
		base.material.SetFloat("_SpeedX", this.speedX);
		base.material.SetFloat("_SpeedY", this.speedY);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x040002B4 RID: 692
	public Texture bumpTexture;

	// Token: 0x040002B5 RID: 693
	public float bumpAmount = 0.7f;

	// Token: 0x040002B6 RID: 694
	public float speedX;

	// Token: 0x040002B7 RID: 695
	public float speedY = 0.1f;
}
