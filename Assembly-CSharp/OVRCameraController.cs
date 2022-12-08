using System;
using UnityEngine;

// Token: 0x02000102 RID: 258
public class OVRCameraController : OVRComponent
{
	// Token: 0x1700002D RID: 45
	// (get) Token: 0x06000529 RID: 1321 RVA: 0x0003AF8B File Offset: 0x0003938B
	// (set) Token: 0x0600052A RID: 1322 RVA: 0x0003AF93 File Offset: 0x00039393
	public float IPD
	{
		get
		{
			return this.ipd;
		}
		set
		{
			this.ipd = value;
			this.UpdateCamerasDirtyFlag = true;
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x0600052B RID: 1323 RVA: 0x0003AFA3 File Offset: 0x000393A3
	// (set) Token: 0x0600052C RID: 1324 RVA: 0x0003AFAB File Offset: 0x000393AB
	public float VerticalFOV
	{
		get
		{
			return this.verticalFOV;
		}
		set
		{
			this.verticalFOV = value;
			this.UpdateCamerasDirtyFlag = true;
		}
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x0600052D RID: 1325 RVA: 0x0003AFBB File Offset: 0x000393BB
	// (set) Token: 0x0600052E RID: 1326 RVA: 0x0003AFC3 File Offset: 0x000393C3
	public Color BackgroundColor
	{
		get
		{
			return this.backgroundColor;
		}
		set
		{
			this.backgroundColor = value;
			this.UpdateCamerasDirtyFlag = true;
		}
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x0600052F RID: 1327 RVA: 0x0003AFD3 File Offset: 0x000393D3
	// (set) Token: 0x06000530 RID: 1328 RVA: 0x0003AFDB File Offset: 0x000393DB
	public float NearClipPlane
	{
		get
		{
			return this.nearClipPlane;
		}
		set
		{
			this.nearClipPlane = value;
			this.UpdateCamerasDirtyFlag = true;
		}
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x06000531 RID: 1329 RVA: 0x0003AFEB File Offset: 0x000393EB
	// (set) Token: 0x06000532 RID: 1330 RVA: 0x0003AFF3 File Offset: 0x000393F3
	public float FarClipPlane
	{
		get
		{
			return this.farClipPlane;
		}
		set
		{
			this.farClipPlane = value;
			this.UpdateCamerasDirtyFlag = true;
		}
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x0003B004 File Offset: 0x00039404
	private new void Awake()
	{
		base.Awake();
		Camera[] componentsInChildren = base.gameObject.GetComponentsInChildren<Camera>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].name == "CameraLeft")
			{
				this.CameraLeft = componentsInChildren[i];
			}
			if (componentsInChildren[i].name == "CameraRight")
			{
				this.CameraRight = componentsInChildren[i];
			}
		}
		if (this.CameraLeft == null || this.CameraRight == null)
		{
			Debug.LogWarning("WARNING: Unity Cameras in OVRCameraController not found!");
		}
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x0003B0A3 File Offset: 0x000394A3
	private new void Start()
	{
		base.Start();
		this.InitCameraControllerVariables();
		this.UpdateCamerasDirtyFlag = true;
		this.UpdateCameras();
		this.SetMaximumVisualQuality();
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x0003B0C4 File Offset: 0x000394C4
	private new void Update()
	{
		base.Update();
		this.UpdateCameras();
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x0003B0D4 File Offset: 0x000394D4
	public void InitCameraControllerVariables()
	{
		OVRDevice.GetIPD(ref this.ipd);
		OVRDevice.CalculatePhysicalLensOffsets(ref this.LensOffsetLeft, ref this.LensOffsetRight);
		this.VerticalFOV = OVRDevice.VerticalFOV();
		this.AspectRatio = OVRDevice.CalculateAspectRatio();
		OVRDevice.GetDistortionCorrectionCoefficients(ref this.DistK0, ref this.DistK1, ref this.DistK2, ref this.DistK3);
		if (!this.PortraitMode)
		{
			this.PortraitMode = OVRDevice.RenderPortraitMode();
		}
		this.PrevPortraitMode = false;
		if (this.FollowOrientation != null)
		{
			this.OrientationOffset = this.FollowOrientation.rotation;
		}
		else
		{
			this.OrientationOffset = base.transform.rotation;
		}
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x0003B188 File Offset: 0x00039588
	private void UpdateCameras()
	{
		if (this.FollowOrientation != null)
		{
			this.OrientationOffset = this.FollowOrientation.rotation;
		}
		this.SetPortraitMode();
		this.UpdatePlayerEyeHeight();
		if (!this.UpdateCamerasDirtyFlag)
		{
			return;
		}
		float distOffset = 0.5f + this.LensOffsetLeft * 0.5f;
		float perspOffset = this.LensOffsetLeft;
		float eyePositionOffset = -this.IPD * 0.5f;
		this.ConfigureCamera(ref this.CameraLeft, distOffset, perspOffset, eyePositionOffset);
		distOffset = 0.5f + this.LensOffsetRight * 0.5f;
		perspOffset = this.LensOffsetRight;
		eyePositionOffset = this.IPD * 0.5f;
		this.ConfigureCamera(ref this.CameraRight, distOffset, perspOffset, eyePositionOffset);
		this.UpdateCamerasDirtyFlag = false;
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x0003B248 File Offset: 0x00039648
	private bool ConfigureCamera(ref Camera camera, float distOffset, float perspOffset, float eyePositionOffset)
	{
		Vector3 zero = Vector3.zero;
		Vector3 eyeCenterPosition = this.EyeCenterPosition;
		camera.fieldOfView = this.VerticalFOV;
		camera.aspect = this.AspectRatio;
		camera.GetComponent<OVRLensCorrection>()._Center.x = distOffset;
		this.ConfigureCameraLensCorrection(ref camera);
		zero.x = perspOffset;
		camera.GetComponent<OVRCamera>().SetPerspectiveOffset(ref zero);
		camera.GetComponent<OVRCamera>().NeckPosition = this.NeckPosition;
		eyeCenterPosition.x = eyePositionOffset;
		camera.GetComponent<OVRCamera>().EyePosition = eyeCenterPosition;
		camera.backgroundColor = this.BackgroundColor;
		camera.nearClipPlane = this.NearClipPlane;
		camera.farClipPlane = this.FarClipPlane;
		return true;
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x0003B2FC File Offset: 0x000396FC
	private void ConfigureCameraLensCorrection(ref Camera camera)
	{
		float num = 1f / OVRDevice.DistortionScale();
		float num2 = OVRDevice.CalculateAspectRatio();
		float num3 = 1f;
		float num4 = 1f;
		OVRLensCorrection component = camera.GetComponent<OVRLensCorrection>();
		component._Scale.x = num3 / 2f * num;
		component._Scale.y = num4 / 2f * num * num2;
		component._ScaleIn.x = 2f / num3;
		component._ScaleIn.y = 2f / num4 / num2;
		component._HmdWarpParam.x = this.DistK0;
		component._HmdWarpParam.y = this.DistK1;
		component._HmdWarpParam.z = this.DistK2;
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x0003B3BC File Offset: 0x000397BC
	private void SetPortraitMode()
	{
		if (this.PortraitMode != this.PrevPortraitMode)
		{
			Rect rect = new Rect(0f, 0f, 0f, 0f);
			if (this.PortraitMode)
			{
				rect.x = 0f;
				rect.y = 0.5f;
				rect.width = 1f;
				rect.height = 0.5f;
				this.CameraLeft.rect = rect;
				rect.x = 0f;
				rect.y = 0f;
				rect.width = 1f;
				rect.height = 0.499999f;
				this.CameraRight.rect = rect;
			}
			else
			{
				rect.x = 0f;
				rect.y = 0f;
				rect.width = 0.5f;
				rect.height = 1f;
				this.CameraLeft.rect = rect;
				rect.x = 0.5f;
				rect.y = 0f;
				rect.width = 0.499999f;
				rect.height = 1f;
				this.CameraRight.rect = rect;
			}
		}
		this.PrevPortraitMode = this.PortraitMode;
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x0003B504 File Offset: 0x00039904
	private void UpdatePlayerEyeHeight()
	{
		if (this.UsePlayerEyeHeight && !this.PrevUsePlayerEyeHeight)
		{
			float num = 0f;
			if (OVRDevice.GetPlayerEyeHeight(ref num))
			{
				this.NeckPosition.y = num - this.CameraRootPosition.y - this.EyeCenterPosition.y;
			}
		}
		this.PrevUsePlayerEyeHeight = this.UsePlayerEyeHeight;
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x0003B569 File Offset: 0x00039969
	public void SetCameras(ref Camera cameraLeft, ref Camera cameraRight)
	{
		this.CameraLeft = cameraLeft;
		this.CameraRight = cameraRight;
		this.UpdateCamerasDirtyFlag = true;
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x0003B582 File Offset: 0x00039982
	public void GetIPD(ref float ipd)
	{
		ipd = this.IPD;
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x0003B58C File Offset: 0x0003998C
	public void SetIPD(float ipd)
	{
		this.IPD = ipd;
		this.UpdateCamerasDirtyFlag = true;
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x0003B59C File Offset: 0x0003999C
	public void GetVerticalFOV(ref float verticalFOV)
	{
		verticalFOV = this.VerticalFOV;
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x0003B5A6 File Offset: 0x000399A6
	public void SetVerticalFOV(float verticalFOV)
	{
		this.VerticalFOV = verticalFOV;
		this.UpdateCamerasDirtyFlag = true;
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x0003B5B6 File Offset: 0x000399B6
	public void GetAspectRatio(ref float aspecRatio)
	{
		aspecRatio = this.AspectRatio;
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x0003B5C0 File Offset: 0x000399C0
	public void SetAspectRatio(float aspectRatio)
	{
		this.AspectRatio = aspectRatio;
		this.UpdateCamerasDirtyFlag = true;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x0003B5D0 File Offset: 0x000399D0
	public void GetDistortionCoefs(ref float distK0, ref float distK1, ref float distK2, ref float distK3)
	{
		distK0 = this.DistK0;
		distK1 = this.DistK1;
		distK2 = this.DistK2;
		distK3 = this.DistK3;
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x0003B5F3 File Offset: 0x000399F3
	public void SetDistortionCoefs(float distK0, float distK1, float distK2, float distK3)
	{
		this.DistK0 = distK0;
		this.DistK1 = distK1;
		this.DistK2 = distK2;
		this.DistK3 = distK3;
		this.UpdateCamerasDirtyFlag = true;
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x0003B619 File Offset: 0x00039A19
	public void GetCameraRootPosition(ref Vector3 cameraRootPosition)
	{
		cameraRootPosition = this.CameraRootPosition;
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x0003B627 File Offset: 0x00039A27
	public void SetCameraRootPosition(ref Vector3 cameraRootPosition)
	{
		this.CameraRootPosition = cameraRootPosition;
		this.UpdateCamerasDirtyFlag = true;
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x0003B63C File Offset: 0x00039A3C
	public void GetNeckPosition(ref Vector3 neckPosition)
	{
		neckPosition = this.NeckPosition;
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x0003B64A File Offset: 0x00039A4A
	public void SetNeckPosition(Vector3 neckPosition)
	{
		if (!this.UsePlayerEyeHeight)
		{
			this.NeckPosition = neckPosition;
			this.UpdateCamerasDirtyFlag = true;
		}
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x0003B665 File Offset: 0x00039A65
	public void GetEyeCenterPosition(ref Vector3 eyeCenterPosition)
	{
		eyeCenterPosition = this.EyeCenterPosition;
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x0003B673 File Offset: 0x00039A73
	public void SetEyeCenterPosition(Vector3 eyeCenterPosition)
	{
		this.EyeCenterPosition = eyeCenterPosition;
		this.UpdateCamerasDirtyFlag = true;
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x0003B683 File Offset: 0x00039A83
	public void GetOrientationOffset(ref Quaternion orientationOffset)
	{
		orientationOffset = this.OrientationOffset;
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x0003B691 File Offset: 0x00039A91
	public void SetOrientationOffset(Quaternion orientationOffset)
	{
		this.OrientationOffset = orientationOffset;
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x0003B69A File Offset: 0x00039A9A
	public void GetYRotation(ref float yRotation)
	{
		yRotation = this.YRotation;
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x0003B6A4 File Offset: 0x00039AA4
	public void SetYRotation(float yRotation)
	{
		this.YRotation = yRotation;
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x0003B6AD File Offset: 0x00039AAD
	public void GetTrackerRotatesY(ref bool trackerRotatesY)
	{
		trackerRotatesY = this.TrackerRotatesY;
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x0003B6B7 File Offset: 0x00039AB7
	public void SetTrackerRotatesY(bool trackerRotatesY)
	{
		this.TrackerRotatesY = trackerRotatesY;
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x0003B6C0 File Offset: 0x00039AC0
	public bool GetCameraOrientationEulerAngles(ref Vector3 angles)
	{
		if (this.CameraRight == null)
		{
			return false;
		}
		angles = this.CameraRight.transform.rotation.eulerAngles;
		return true;
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x0003B6FF File Offset: 0x00039AFF
	public bool GetCameraOrientation(ref Quaternion quaternion)
	{
		if (this.CameraRight == null)
		{
			return false;
		}
		quaternion = this.CameraRight.transform.rotation;
		return true;
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x0003B72B File Offset: 0x00039B2B
	public bool GetCameraPosition(ref Vector3 position)
	{
		if (this.CameraRight == null)
		{
			return false;
		}
		position = this.CameraRight.transform.position;
		return true;
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0003B757 File Offset: 0x00039B57
	public void GetCamera(ref Camera camera)
	{
		camera = this.CameraRight;
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0003B761 File Offset: 0x00039B61
	public bool AttachGameObjectToCamera(ref GameObject gameObject)
	{
		if (this.CameraRight == null)
		{
			return false;
		}
		gameObject.transform.parent = this.CameraRight.transform;
		return true;
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x0003B790 File Offset: 0x00039B90
	public bool DetachGameObjectFromCamera(ref GameObject gameObject)
	{
		if (this.CameraRight != null && this.CameraRight.transform == gameObject.transform.parent)
		{
			gameObject.transform.parent = null;
			return true;
		}
		return false;
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x0003B7DF File Offset: 0x00039BDF
	public bool GetPlayerEyeHeight(ref float eyeHeight)
	{
		eyeHeight = this.CameraRootPosition.y + this.NeckPosition.y + this.EyeCenterPosition.y;
		return true;
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x0003B807 File Offset: 0x00039C07
	public void SetMaximumVisualQuality()
	{
		QualitySettings.softVegetation = true;
		QualitySettings.maxQueuedFrames = 0;
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		QualitySettings.vSyncCount = 1;
	}

	// Token: 0x040007FF RID: 2047
	private bool UpdateCamerasDirtyFlag;

	// Token: 0x04000800 RID: 2048
	private Camera CameraLeft;

	// Token: 0x04000801 RID: 2049
	private Camera CameraRight;

	// Token: 0x04000802 RID: 2050
	private float LensOffsetLeft;

	// Token: 0x04000803 RID: 2051
	private float LensOffsetRight;

	// Token: 0x04000804 RID: 2052
	private float AspectRatio = 1f;

	// Token: 0x04000805 RID: 2053
	private float DistK0;

	// Token: 0x04000806 RID: 2054
	private float DistK1;

	// Token: 0x04000807 RID: 2055
	private float DistK2;

	// Token: 0x04000808 RID: 2056
	private float DistK3;

	// Token: 0x04000809 RID: 2057
	private Quaternion OrientationOffset = Quaternion.identity;

	// Token: 0x0400080A RID: 2058
	private float YRotation;

	// Token: 0x0400080B RID: 2059
	private float ipd = 0.064f;

	// Token: 0x0400080C RID: 2060
	private float verticalFOV = 90f;

	// Token: 0x0400080D RID: 2061
	public Vector3 CameraRootPosition = new Vector3(0f, 1f, 0f);

	// Token: 0x0400080E RID: 2062
	public Vector3 NeckPosition = new Vector3(0f, 0.7f, 0f);

	// Token: 0x0400080F RID: 2063
	public Vector3 EyeCenterPosition = new Vector3(0f, 0.15f, 0.09f);

	// Token: 0x04000810 RID: 2064
	public bool UsePlayerEyeHeight;

	// Token: 0x04000811 RID: 2065
	private bool PrevUsePlayerEyeHeight;

	// Token: 0x04000812 RID: 2066
	public Transform FollowOrientation;

	// Token: 0x04000813 RID: 2067
	public bool TrackerRotatesY;

	// Token: 0x04000814 RID: 2068
	public bool PortraitMode;

	// Token: 0x04000815 RID: 2069
	private bool PrevPortraitMode;

	// Token: 0x04000816 RID: 2070
	public bool PredictionOn = true;

	// Token: 0x04000817 RID: 2071
	public bool CallInPreRender;

	// Token: 0x04000818 RID: 2072
	public bool WireMode;

	// Token: 0x04000819 RID: 2073
	public bool LensCorrection = true;

	// Token: 0x0400081A RID: 2074
	public bool Chromatic = true;

	// Token: 0x0400081B RID: 2075
	private Color backgroundColor = new Color(0.192f, 0.302f, 0.475f, 1f);

	// Token: 0x0400081C RID: 2076
	private float nearClipPlane = 0.15f;

	// Token: 0x0400081D RID: 2077
	private float farClipPlane = 1000f;
}
