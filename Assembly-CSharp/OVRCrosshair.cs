using System;
using UnityEngine;

// Token: 0x02000105 RID: 261
public class OVRCrosshair
{
	// Token: 0x06000563 RID: 1379 RVA: 0x0003B972 File Offset: 0x00039D72
	public void SetCrosshairTexture(ref Texture image)
	{
		this.ImageCrosshair = image;
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x0003B97C File Offset: 0x00039D7C
	public void SetOVRCameraController(ref OVRCameraController cameraController)
	{
		this.CameraController = cameraController;
		this.CameraController.GetCamera(ref this.MainCam);
		if (this.CameraController.PortraitMode)
		{
			float deadZoneX = this.DeadZoneX;
			this.DeadZoneX = this.DeadZoneY;
			this.DeadZoneY = deadZoneX;
		}
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x0003B9CC File Offset: 0x00039DCC
	public void SetOVRPlayerController(ref OVRPlayerController playerController)
	{
		this.PlayerController = playerController;
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0003B9D6 File Offset: 0x00039DD6
	public bool IsCrosshairVisible()
	{
		return this.FadeVal > 0f;
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x0003B9EC File Offset: 0x00039DEC
	public void Init()
	{
		this.DisplayCrosshair = false;
		this.CollisionWithGeometry = false;
		this.FadeVal = 0f;
		this.ScreenWidth = (float)Screen.width;
		this.ScreenHeight = (float)Screen.height;
		this.XL = this.ScreenWidth * 0.5f;
		this.YL = this.ScreenHeight * 0.5f;
	}

	// Token: 0x06000568 RID: 1384 RVA: 0x0003BA4E File Offset: 0x00039E4E
	public void UpdateCrosshair()
	{
		this.ShouldDisplayCrosshair();
		this.CollisionWithGeometryCheck();
	}

	// Token: 0x06000569 RID: 1385 RVA: 0x0003BA60 File Offset: 0x00039E60
	public void OnGUICrosshair()
	{
		if (this.DisplayCrosshair && !this.CollisionWithGeometry)
		{
			this.FadeVal += Time.deltaTime / this.FadeTime;
		}
		else
		{
			this.FadeVal -= Time.deltaTime / this.FadeTime;
		}
		this.FadeVal = Mathf.Clamp(this.FadeVal, 0f, 1f);
		if (this.PlayerController != null)
		{
			this.PlayerController.SetAllowMouseRotation(false);
		}
		if (this.ImageCrosshair != null && this.FadeVal != 0f)
		{
			if (this.PlayerController != null)
			{
				this.PlayerController.SetAllowMouseRotation(true);
			}
			GUI.color = new Color(1f, 1f, 1f, this.FadeVal * this.FadeScale);
			this.XL += Input.GetAxis("Mouse X") * this.ScaleSpeedX;
			if (this.XL < this.DeadZoneX)
			{
				if (this.PlayerController != null)
				{
					this.PlayerController.SetAllowMouseRotation(false);
				}
				this.XL = this.DeadZoneX - 0.001f;
			}
			else if (this.XL > (float)Screen.width - this.DeadZoneX)
			{
				if (this.PlayerController != null)
				{
					this.PlayerController.SetAllowMouseRotation(false);
				}
				this.XL = this.ScreenWidth - this.DeadZoneX + 0.001f;
			}
			this.YL -= Input.GetAxis("Mouse Y") * this.ScaleSpeedY;
			if (this.YL < this.DeadZoneY)
			{
				if (this.YL < 0f)
				{
					this.YL = 0f;
				}
			}
			else if (this.YL > this.ScreenHeight - this.DeadZoneY && this.YL > this.ScreenHeight)
			{
				this.YL = this.ScreenHeight;
			}
			bool flag = true;
			if (this.PlayerController != null)
			{
				this.PlayerController.GetAllowMouseRotation(ref flag);
			}
			if (flag)
			{
				GUI.DrawTexture(new Rect(this.XL - (float)this.ImageCrosshair.width * 0.5f, this.YL - (float)this.ImageCrosshair.height * 0.5f, (float)this.ImageCrosshair.width, (float)this.ImageCrosshair.height), this.ImageCrosshair);
			}
			GUI.color = Color.white;
		}
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x0003BD18 File Offset: 0x0003A118
	private bool ShouldDisplayCrosshair()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			if (!this.DisplayCrosshair)
			{
				this.DisplayCrosshair = true;
				this.XL = this.ScreenWidth * 0.5f;
				this.YL = this.ScreenHeight * 0.5f;
			}
			else
			{
				this.DisplayCrosshair = false;
			}
		}
		return this.DisplayCrosshair;
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x0003BD7C File Offset: 0x0003A17C
	private bool CollisionWithGeometryCheck()
	{
		this.CollisionWithGeometry = false;
		Vector3 position = this.MainCam.transform.position;
		Vector3 vector = Vector3.forward;
		vector = this.MainCam.transform.rotation * vector;
		vector *= this.CrosshairDistance;
		Vector3 end = position + vector;
		RaycastHit raycastHit;
		if (Physics.Linecast(position, end, out raycastHit) && !raycastHit.collider.isTrigger)
		{
			this.CollisionWithGeometry = true;
		}
		return this.CollisionWithGeometry;
	}

	// Token: 0x04000821 RID: 2081
	public Texture ImageCrosshair;

	// Token: 0x04000822 RID: 2082
	public OVRCameraController CameraController;

	// Token: 0x04000823 RID: 2083
	public OVRPlayerController PlayerController;

	// Token: 0x04000824 RID: 2084
	public float FadeTime = 0.3f;

	// Token: 0x04000825 RID: 2085
	public float FadeScale = 0.6f;

	// Token: 0x04000826 RID: 2086
	public float CrosshairDistance = 1f;

	// Token: 0x04000827 RID: 2087
	private float DeadZoneX = 400f;

	// Token: 0x04000828 RID: 2088
	private float DeadZoneY = 75f;

	// Token: 0x04000829 RID: 2089
	private float ScaleSpeedX = 7f;

	// Token: 0x0400082A RID: 2090
	private float ScaleSpeedY = 7f;

	// Token: 0x0400082B RID: 2091
	private bool DisplayCrosshair;

	// Token: 0x0400082C RID: 2092
	private bool CollisionWithGeometry;

	// Token: 0x0400082D RID: 2093
	private float FadeVal;

	// Token: 0x0400082E RID: 2094
	private Camera MainCam;

	// Token: 0x0400082F RID: 2095
	private float XL;

	// Token: 0x04000830 RID: 2096
	private float YL;

	// Token: 0x04000831 RID: 2097
	private float ScreenWidth = 1280f;

	// Token: 0x04000832 RID: 2098
	private float ScreenHeight = 800f;
}
