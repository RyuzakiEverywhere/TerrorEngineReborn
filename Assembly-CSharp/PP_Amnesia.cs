using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Amnesia")]
public class PP_Amnesia : PostProcessBase
{
	// Token: 0x0600018F RID: 399 RVA: 0x00015884 File Offset: 0x00013C84
	private void Awake()
	{
		base.material.SetFloat("_Density", this.density);
		base.material.SetFloat("_Speed", this.speed);
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000158B2 File Offset: 0x00013CB2
	private void OnEnable()
	{
		this.shader = Shader.Find("Hidden/Aubergine/Amnesia");
	}

	// Token: 0x06000191 RID: 401 RVA: 0x000158C4 File Offset: 0x00013CC4
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Density", this.density);
		base.material.SetFloat("_Speed", this.speed);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000281 RID: 641
	public float density = 1f;

	// Token: 0x04000282 RID: 642
	public float speed = 3f;
}
