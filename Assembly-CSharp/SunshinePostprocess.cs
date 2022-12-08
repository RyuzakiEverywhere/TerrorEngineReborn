using System;
using UnityEngine;

// Token: 0x020001B8 RID: 440
[ExecuteInEditMode]
public class SunshinePostprocess : MonoBehaviour
{
	// Token: 0x06000A7E RID: 2686 RVA: 0x0005C878 File Offset: 0x0005AC78
	private void OnEnable()
	{
		this.sunshineCamera = base.GetComponent<SunshineCamera>();
	}

	// Token: 0x06000A7F RID: 2687 RVA: 0x0005C888 File Offset: 0x0005AC88
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.sunshineCamera == null)
		{
			this.sunshineCamera = base.GetComponent<SunshineCamera>();
		}
		if (this.sunshineCamera != null && this.sunshineCamera.enabled)
		{
			this.sunshineCamera.OnPostProcess(source, destination);
		}
		else
		{
			Graphics.Blit(source, destination);
			base.enabled = false;
		}
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x0005C8F3 File Offset: 0x0005ACF3
	public static void Blit(RenderTexture source, RenderTexture destination, Material material, int pass)
	{
		Graphics.Blit(source, destination, material, pass);
	}

	// Token: 0x04000C70 RID: 3184
	private SunshineCamera sunshineCamera;
}
