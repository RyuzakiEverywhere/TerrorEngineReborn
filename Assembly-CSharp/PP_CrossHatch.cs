using System;
using UnityEngine;

// Token: 0x02000055 RID: 85
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/CrossHatch")]
public class PP_CrossHatch : PostProcessBase
{
	// Token: 0x060001AA RID: 426 RVA: 0x00015B56 File Offset: 0x00013F56
	private void Awake()
	{
		base.material.SetVector("_LineColor", this.lineColor);
		base.material.SetFloat("_LineWidth", this.lineWidth);
	}

	// Token: 0x060001AB RID: 427 RVA: 0x00015B89 File Offset: 0x00013F89
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/CrossHatch");
	}

	// Token: 0x060001AC RID: 428 RVA: 0x00015B9B File Offset: 0x00013F9B
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetVector("_LineColor", this.lineColor);
		base.material.SetFloat("_LineWidth", this.lineWidth);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000289 RID: 649
	public Color lineColor = Color.red;

	// Token: 0x0400028A RID: 650
	public float lineWidth = 0.005f;
}
