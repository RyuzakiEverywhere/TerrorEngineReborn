using System;
using UnityEngine;

// Token: 0x02000109 RID: 265
public class OVRGUI
{
	// Token: 0x060005C3 RID: 1475 RVA: 0x0003C78F File Offset: 0x0003AB8F
	public void SetCameraController(ref OVRCameraController cameraController)
	{
		this.CameraController = cameraController;
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x0003C799 File Offset: 0x0003AB99
	public void GetFontReplace(ref Font fontReplace)
	{
		fontReplace = this.FontReplace;
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x0003C7A3 File Offset: 0x0003ABA3
	public void SetFontReplace(Font fontReplace)
	{
		this.FontReplace = fontReplace;
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x0003C7AC File Offset: 0x0003ABAC
	public void GetPixelResolution(ref float pixelWidth, ref float pixelHeight)
	{
		pixelWidth = this.PixelWidth;
		pixelHeight = this.PixelHeight;
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x0003C7BE File Offset: 0x0003ABBE
	public void SetPixelResolution(float pixelWidth, float pixelHeight)
	{
		this.PixelWidth = pixelWidth;
		this.PixelHeight = pixelHeight;
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x0003C7CE File Offset: 0x0003ABCE
	public void GetDisplayResolution(ref float Width, ref float Height)
	{
		Width = this.DisplayWidth;
		Height = this.DisplayHeight;
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x0003C7E0 File Offset: 0x0003ABE0
	public void SetDisplayResolution(float Width, float Height)
	{
		this.DisplayWidth = Width;
		this.DisplayHeight = Height;
	}

	// Token: 0x060005CA RID: 1482 RVA: 0x0003C7F0 File Offset: 0x0003ABF0
	public void StereoBox(int X, int Y, int wX, int hY, ref string text, Color color)
	{
		Font font = GUI.skin.font;
		GUI.color = color;
		if (GUI.skin.font != this.FontReplace)
		{
			GUI.skin.font = this.FontReplace;
		}
		float num = this.PixelWidth / this.DisplayWidth;
		this.CalcPositionAndSize((float)X * num, (float)Y * num, (float)wX * num, (float)hY * num, ref this.DrawRect);
		GUI.Box(this.DrawRect, text);
		GUI.skin.font = font;
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x0003C87D File Offset: 0x0003AC7D
	public void StereoBox(float X, float Y, float wX, float hY, ref string text, Color color)
	{
		this.StereoBox((int)(X * this.PixelWidth), (int)(Y * this.PixelHeight), (int)(wX * this.PixelWidth), (int)(hY * this.PixelHeight), ref text, color);
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x0003C8B0 File Offset: 0x0003ACB0
	public void StereoDrawTexture(int X, int Y, int wX, int hY, ref Texture image, Color color)
	{
		GUI.color = color;
		if (GUI.skin.font != this.FontReplace)
		{
			GUI.skin.font = this.FontReplace;
		}
		float num = this.PixelWidth / this.DisplayWidth;
		this.CalcPositionAndSize((float)X * num, (float)Y * num, (float)wX * num, (float)hY * num, ref this.DrawRect);
		GUI.DrawTexture(this.DrawRect, image);
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x0003C927 File Offset: 0x0003AD27
	public void StereoDrawTexture(float X, float Y, float wX, float hY, ref Texture image, Color color)
	{
		this.StereoDrawTexture((int)(X * this.PixelWidth), (int)(Y * this.PixelHeight), (int)(wX * this.PixelWidth), (int)(hY * this.PixelHeight), ref image, color);
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x0003C958 File Offset: 0x0003AD58
	private void CalcPositionAndSize(float X, float Y, float wX, float hY, ref Rect calcPosSize)
	{
		float num = (float)Screen.width / this.PixelWidth;
		float num2 = (float)Screen.height / this.PixelHeight;
		if (this.CameraController != null && this.CameraController.PortraitMode)
		{
			num = (float)Screen.height / this.PixelWidth;
			num2 = (float)Screen.width / this.PixelHeight;
		}
		calcPosSize.x = X * num;
		calcPosSize.width = wX * num;
		calcPosSize.y = Y * num2;
		calcPosSize.height = hY * num2;
	}

	// Token: 0x04000856 RID: 2134
	private Font FontReplace;

	// Token: 0x04000857 RID: 2135
	private OVRCameraController CameraController;

	// Token: 0x04000858 RID: 2136
	private float PixelWidth = 1280f;

	// Token: 0x04000859 RID: 2137
	private float PixelHeight = 800f;

	// Token: 0x0400085A RID: 2138
	private float DisplayWidth = 1280f;

	// Token: 0x0400085B RID: 2139
	private float DisplayHeight = 800f;

	// Token: 0x0400085C RID: 2140
	private Rect DrawRect;
}
