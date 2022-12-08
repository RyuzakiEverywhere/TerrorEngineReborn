using System;
using UnityEngine;

// Token: 0x02000103 RID: 259
[RequireComponent(typeof(Camera))]
public class OVRCameraStripped : OVRComponent
{
	// Token: 0x0600055A RID: 1370 RVA: 0x0003B834 File Offset: 0x00039C34
	private new void Start()
	{
		base.Start();
		if (this.CameraTexture == null && this.CameraTextureScale != 1f)
		{
			int width = (int)((float)Screen.width / 2f * this.CameraTextureScale);
			int height = (int)((float)Screen.height * this.CameraTextureScale);
			this.CameraTexture = new RenderTexture(width, height, 24);
			this.CameraTexture.antiAliasing = QualitySettings.antiAliasing;
		}
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x0003B8AB File Offset: 0x00039CAB
	private void OnPreRender()
	{
		if (this.CameraTexture != null)
		{
			Graphics.SetRenderTarget(this.CameraTexture);
		}
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x0003B8CC File Offset: 0x00039CCC
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture source2 = source;
		if (this.CameraTexture != null)
		{
			source2 = this.CameraTexture;
		}
		Graphics.Blit(source2, destination);
	}

	// Token: 0x0400081E RID: 2078
	private RenderTexture CameraTexture;

	// Token: 0x0400081F RID: 2079
	private float CameraTextureScale = 1f;
}
