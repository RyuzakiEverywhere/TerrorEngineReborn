using System;
using UnityEngine;

// Token: 0x0200010F RID: 271
public class OVRMainMenu : MonoBehaviour
{
	// Token: 0x060005EE RID: 1518 RVA: 0x0003D3D0 File Offset: 0x0003B7D0
	private void Awake()
	{
		OVRCameraController[] componentsInChildren = base.gameObject.GetComponentsInChildren<OVRCameraController>();
		if (componentsInChildren.Length == 0)
		{
			Debug.LogWarning("OVRMainMenu: No OVRCameraController attached.");
		}
		else if (componentsInChildren.Length > 1)
		{
			Debug.LogWarning("OVRMainMenu: More then 1 OVRCameraController attached.");
		}
		else
		{
			this.CameraController = componentsInChildren[0];
		}
		OVRPlayerController[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<OVRPlayerController>();
		if (componentsInChildren2.Length == 0)
		{
			Debug.LogWarning("OVRMainMenu: No OVRPlayerController attached.");
		}
		else if (componentsInChildren2.Length > 1)
		{
			Debug.LogWarning("OVRMainMenu: More then 1 OVRPlayerController attached.");
		}
		else
		{
			this.PlayerController = componentsInChildren2[0];
		}
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x0003D468 File Offset: 0x0003B868
	private void Start()
	{
		this.AlphaFadeValue = 1f;
		this.CurrentLevel = 0;
		this.PrevStartDown = false;
		this.PrevHatDown = false;
		this.PrevHatUp = false;
		this.ShowVRVars = false;
		this.OldSpaceHit = false;
		this.strFPS = "FPS: 0";
		this.LoadingLevel = false;
		this.ScenesVisible = false;
		if (this.CameraController != null)
		{
			this.CameraController.InitCameraControllerVariables();
			this.GuiHelper.SetCameraController(ref this.CameraController);
		}
		this.GUIRenderObject = (UnityEngine.Object.Instantiate(Resources.Load("OVRGUIObjectMain")) as GameObject);
		if (this.GUIRenderObject != null && this.GUIRenderTexture == null)
		{
			int num = Screen.width;
			int num2 = Screen.height;
			if (this.CameraController.PortraitMode)
			{
				int num3 = num2;
				num2 = num;
				num = num3;
			}
			this.GUIRenderTexture = new RenderTexture(num, num2, 0);
			this.GuiHelper.SetPixelResolution((float)num, (float)num2);
			this.GuiHelper.SetDisplayResolution((float)OVRDevice.HResolution, (float)OVRDevice.VResolution);
		}
		if (this.GUIRenderTexture != null && this.GUIRenderObject != null)
		{
			this.GUIRenderObject.GetComponent<Renderer>().material.mainTexture = this.GUIRenderTexture;
			if (this.CameraController != null)
			{
				Transform transform = this.GUIRenderObject.transform;
				this.CameraController.AttachGameObjectToCamera(ref this.GUIRenderObject);
				OVRUtils.SetLocalTransform(ref this.GUIRenderObject, ref transform);
				Vector3 localPosition = this.GUIRenderObject.transform.localPosition;
				float num4 = 0f;
				this.CameraController.GetIPD(ref num4);
				localPosition.x -= num4 * 0.5f;
				this.GUIRenderObject.transform.localPosition = localPosition;
				this.GUIRenderObject.SetActive(false);
			}
		}
		this.StoreSnapshot("DEFAULT");
		if (!Application.isEditor)
		{
			Cursor.visible = false;
			Screen.lockCursor = true;
		}
		this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateFPS));
		if (this.CameraController != null)
		{
			this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateIPD));
			this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdatePrediction));
			this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateFOV));
			this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateDistortionCoefs));
			this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateEyeHeightOffset));
		}
		if (this.PlayerController != null)
		{
			this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateSpeedAndRotationScaleMultiplier));
			this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdatePlayerControllerMovement));
		}
		this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateSelectCurrentLevel));
		this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateHandleSnapshots));
		this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateDeviceDetection));
		this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.UpdateResetOrientation));
		OVRMessenger.AddListener<OVRMainMenu.Device, bool>("Sensor_Attached", new OVRCallback<OVRMainMenu.Device, bool>(this.UpdateDeviceDetectionMsgCallback));
		this.MagCal.SetInitialCalibarationState();
		this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.MagCal.UpdateMagYawDriftCorrection));
		this.MagCal.SetOVRCameraController(ref this.CameraController);
		this.Crosshair.Init();
		this.Crosshair.SetCrosshairTexture(ref this.CrosshairImage);
		this.Crosshair.SetOVRCameraController(ref this.CameraController);
		this.Crosshair.SetOVRPlayerController(ref this.PlayerController);
		this.UpdateFunctions = (OVRMainMenu.updateFunctions)Delegate.Combine(this.UpdateFunctions, new OVRMainMenu.updateFunctions(this.Crosshair.UpdateCrosshair));
		this.CheckIfRiftPresent();
		this.ScenesVisible = false;
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x0003D8FC File Offset: 0x0003BCFC
	private void Update()
	{
		if (this.LoadingLevel)
		{
			return;
		}
		this.UpdateFunctions();
		if (Input.GetKeyDown(KeyCode.F11))
		{
			Screen.fullScreen = !Screen.fullScreen;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x0003D950 File Offset: 0x0003BD50
	private void UpdateFPS()
	{
		this.TimeLeft -= Time.deltaTime;
		this.Accum += Time.timeScale / Time.deltaTime;
		this.Frames++;
		if ((double)this.TimeLeft <= 0.0)
		{
			float num = this.Accum / (float)this.Frames;
			if (this.ShowVRVars)
			{
				this.strFPS = string.Format("FPS: {0:F2}", num);
			}
			this.TimeLeft += this.UpdateInterval;
			this.Accum = 0f;
			this.Frames = 0;
		}
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x0003DA00 File Offset: 0x0003BE00
	private void UpdateIPD()
	{
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			float num = 0f;
			this.CameraController.GetIPD(ref num);
			num += this.IPDIncrement;
			this.CameraController.SetIPD(num);
		}
		else if (Input.GetKeyDown(KeyCode.Minus))
		{
			float num2 = 0f;
			this.CameraController.GetIPD(ref num2);
			num2 -= this.IPDIncrement;
			this.CameraController.SetIPD(num2);
		}
		if (this.ShowVRVars)
		{
			float num3 = 0f;
			this.CameraController.GetIPD(ref num3);
			this.strIPD = string.Format("IPD (mm): {0:F4}", num3 * 1000f);
		}
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x0003DAB4 File Offset: 0x0003BEB4
	private void UpdatePrediction()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (!this.CameraController.PredictionOn)
			{
				this.CameraController.PredictionOn = true;
			}
			else
			{
				this.CameraController.PredictionOn = false;
			}
		}
		if (this.CameraController.PredictionOn)
		{
			float num = OVRDevice.GetPredictionTime(0);
			if (Input.GetKeyDown(KeyCode.Comma))
			{
				num -= this.PredictionIncrement;
			}
			else if (Input.GetKeyDown(KeyCode.Period))
			{
				num += this.PredictionIncrement;
			}
			OVRDevice.SetPredictionTime(0, num);
			num = OVRDevice.GetPredictionTime(0) * 1000f;
			if (this.ShowVRVars)
			{
				this.strPrediction = string.Format("Pred (ms): {0:F3}", num);
			}
		}
		else
		{
			this.strPrediction = "Pred: OFF";
		}
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x0003DB88 File Offset: 0x0003BF88
	private void UpdateFOV()
	{
		if (Input.GetKeyDown(KeyCode.LeftBracket))
		{
			float num = 0f;
			this.CameraController.GetVerticalFOV(ref num);
			num -= this.FOVIncrement;
			this.CameraController.SetVerticalFOV(num);
		}
		else if (Input.GetKeyDown(KeyCode.RightBracket))
		{
			float num2 = 0f;
			this.CameraController.GetVerticalFOV(ref num2);
			num2 += this.FOVIncrement;
			this.CameraController.SetVerticalFOV(num2);
		}
		if (this.ShowVRVars)
		{
			float num3 = 0f;
			this.CameraController.GetVerticalFOV(ref num3);
			this.strFOV = string.Format("FOV (deg): {0:F3}", num3);
		}
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x0003DC38 File Offset: 0x0003C038
	private void UpdateDistortionCoefs()
	{
		float distK = 0f;
		float num = 0f;
		float num2 = 0f;
		float distK2 = 0f;
		this.CameraController.GetDistortionCoefs(ref distK, ref num, ref num2, ref distK2);
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			num -= this.DistKIncrement;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			num += this.DistKIncrement;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			num2 -= this.DistKIncrement;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			num2 += this.DistKIncrement;
		}
		this.CameraController.SetDistortionCoefs(distK, num, num2, distK2);
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x0003DCE0 File Offset: 0x0003C0E0
	private void UpdateEyeHeightOffset()
	{
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			Vector3 zero = Vector3.zero;
			this.CameraController.GetNeckPosition(ref zero);
			zero.y -= this.HeightIncrement;
			this.CameraController.SetNeckPosition(zero);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			Vector3 zero2 = Vector3.zero;
			this.CameraController.GetNeckPosition(ref zero2);
			zero2.y += this.HeightIncrement;
			this.CameraController.SetNeckPosition(zero2);
		}
		if (this.ShowVRVars)
		{
			float num = 0f;
			this.CameraController.GetPlayerEyeHeight(ref num);
			this.strHeight = string.Format("Eye Height (m): {0:F3}", num);
		}
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x0003DDA8 File Offset: 0x0003C1A8
	private void UpdateSpeedAndRotationScaleMultiplier()
	{
		float num = 0f;
		this.PlayerController.GetMoveScaleMultiplier(ref num);
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			num -= this.SpeedRotationIncrement;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			num += this.SpeedRotationIncrement;
		}
		this.PlayerController.SetMoveScaleMultiplier(num);
		float num2 = 0f;
		this.PlayerController.GetRotationScaleMultiplier(ref num2);
		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			num2 -= this.SpeedRotationIncrement;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			num2 += this.SpeedRotationIncrement;
		}
		this.PlayerController.SetRotationScaleMultiplier(num2);
		if (this.ShowVRVars)
		{
			this.strSpeedRotationMultipler = string.Format("Spd.X: {0:F2} Rot.X: {1:F2}", num, num2);
		}
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x0003DE78 File Offset: 0x0003C278
	private void UpdatePlayerControllerMovement()
	{
		if (this.PlayerController != null)
		{
			this.PlayerController.SetHaltUpdateMovement(this.ScenesVisible);
		}
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x0003DE9C File Offset: 0x0003C29C
	private void UpdateSelectCurrentLevel()
	{
		this.ShowLevels();
		if (!this.ScenesVisible)
		{
			return;
		}
		this.CurrentLevel = this.GetCurrentLevel();
		if (this.Scenes.Length != 0 && (OVRGamepadController.GPC_GetButton(0) || Input.GetKeyDown(KeyCode.Return)))
		{
			this.LoadingLevel = true;
			Application.LoadLevelAsync(this.Scenes[this.CurrentLevel]);
		}
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x0003DF08 File Offset: 0x0003C308
	private bool ShowLevels()
	{
		if (this.Scenes.Length == 0)
		{
			this.ScenesVisible = false;
			return this.ScenesVisible;
		}
		bool flag = false;
		if (OVRGamepadController.GPC_GetButton(8))
		{
			flag = true;
		}
		if ((!this.PrevStartDown && flag) || Input.GetKeyDown(KeyCode.RightShift))
		{
			if (this.ScenesVisible)
			{
				this.ScenesVisible = false;
			}
			else
			{
				this.ScenesVisible = true;
			}
		}
		this.PrevStartDown = flag;
		return this.ScenesVisible;
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x0003DF8C File Offset: 0x0003C38C
	private int GetCurrentLevel()
	{
		bool flag = false;
		if (OVRGamepadController.GPC_GetButton(5))
		{
			flag = true;
		}
		bool flag2 = false;
		if (OVRGamepadController.GPC_GetButton(5))
		{
			flag2 = true;
		}
		if ((!this.PrevHatDown && flag) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.CurrentLevel = (this.CurrentLevel + 1) % this.SceneNames.Length;
		}
		else if ((!this.PrevHatUp && flag2) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.CurrentLevel--;
			if (this.CurrentLevel < 0)
			{
				this.CurrentLevel = this.SceneNames.Length - 1;
			}
		}
		this.PrevHatDown = flag;
		this.PrevHatUp = flag2;
		return this.CurrentLevel;
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x0003E054 File Offset: 0x0003C454
	private void OnGUI()
	{
		if (Event.current.type != EventType.Repaint)
		{
			return;
		}
		if (this.AlphaFadeValue > 0f)
		{
			this.AlphaFadeValue -= Mathf.Clamp01(Time.deltaTime / this.FadeInTime);
			if (this.AlphaFadeValue >= 0f)
			{
				GUI.color = new Color(0f, 0f, 0f, this.AlphaFadeValue);
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.FadeInTexture);
				return;
			}
			this.AlphaFadeValue = 0f;
		}
		if (this.GUIRenderObject != null)
		{
			if (this.ScenesVisible || this.ShowVRVars || this.Crosshair.IsCrosshairVisible() || this.RiftPresentTimeout > 0f || this.DeviceDetectionTimeout > 0f || (!this.MagCal.Disabled() && !this.MagCal.Ready()))
			{
				this.GUIRenderObject.SetActive(true);
			}
			else
			{
				this.GUIRenderObject.SetActive(false);
			}
		}
		Vector3 one = Vector3.one;
		if (this.CameraController.PortraitMode)
		{
			float num = (float)OVRDevice.HResolution;
			float num2 = (float)OVRDevice.VResolution;
			one.x = num2 / num;
			one.y = num / num2;
		}
		Matrix4x4 matrix = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, one);
		RenderTexture active = RenderTexture.active;
		if (this.GUIRenderTexture != null)
		{
			RenderTexture.active = this.GUIRenderTexture;
			GL.Clear(false, true, new Color(0f, 0f, 0f, 0f));
		}
		this.GuiHelper.SetFontReplace(this.FontReplace);
		if (!this.GUIShowRiftDetected())
		{
			this.GUIShowLevels();
			this.GUIShowVRVariables();
		}
		this.Crosshair.OnGUICrosshair();
		RenderTexture.active = active;
		GUI.matrix = matrix;
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x0003E270 File Offset: 0x0003C670
	private void GUIShowLevels()
	{
		if (this.ScenesVisible)
		{
			GUI.color = new Color(0f, 0f, 0f, 0.5f);
			GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.FadeInTexture);
			GUI.color = Color.white;
			if (this.LoadingLevel)
			{
				string text = "LOADING...";
				this.GuiHelper.StereoBox(this.StartX, this.StartY, this.WidthX, this.WidthY, ref text, Color.yellow);
				return;
			}
			for (int i = 0; i < this.SceneNames.Length; i++)
			{
				Color color;
				if (i == this.CurrentLevel)
				{
					color = Color.yellow;
				}
				else
				{
					color = Color.black;
				}
				int y = this.StartY + i * this.StepY;
				this.GuiHelper.StereoBox(this.StartX, y, this.WidthX, this.WidthY, ref this.SceneNames[i], color);
			}
		}
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x0003E384 File Offset: 0x0003C784
	private void GUIShowVRVariables()
	{
		bool key = Input.GetKey("space");
		if (!this.OldSpaceHit && key)
		{
			if (this.ShowVRVars)
			{
				this.ShowVRVars = false;
			}
			else
			{
				this.ShowVRVars = true;
			}
		}
		this.OldSpaceHit = key;
		int num = this.VRVarsSY;
		if (!this.ShowVRVars)
		{
			if (!this.MagCal.Disabled() && !this.MagCal.Ready())
			{
				this.MagCal.GUIMagYawDriftCorrection(this.VRVarsSX, num, this.VRVarsWidthX, this.VRVarsWidthY, ref this.GuiHelper);
			}
		}
		else
		{
			this.MagCal.GUIMagYawDriftCorrection(this.VRVarsSX, num, this.VRVarsWidthX, this.VRVarsWidthY, ref this.GuiHelper);
			this.GuiHelper.StereoBox(this.VRVarsSX, num += this.StepY, this.VRVarsWidthX, this.VRVarsWidthY, ref this.strFPS, Color.green);
			if (this.CameraController != null)
			{
				this.GuiHelper.StereoBox(this.VRVarsSX, num += this.StepY, this.VRVarsWidthX, this.VRVarsWidthY, ref this.strPrediction, Color.white);
				this.GuiHelper.StereoBox(this.VRVarsSX, num += this.StepY, this.VRVarsWidthX, this.VRVarsWidthY, ref this.strIPD, Color.yellow);
				this.GuiHelper.StereoBox(this.VRVarsSX, num += this.StepY, this.VRVarsWidthX, this.VRVarsWidthY, ref this.strFOV, Color.white);
			}
			if (this.PlayerController != null)
			{
				this.GuiHelper.StereoBox(this.VRVarsSX, num += this.StepY, this.VRVarsWidthX, this.VRVarsWidthY, ref this.strHeight, Color.yellow);
				this.GuiHelper.StereoBox(this.VRVarsSX, num + this.StepY, this.VRVarsWidthX, this.VRVarsWidthY, ref this.strSpeedRotationMultipler, Color.white);
			}
		}
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x0003E5A0 File Offset: 0x0003C9A0
	private void UpdateHandleSnapshots()
	{
		if (Input.GetKeyDown(KeyCode.F2))
		{
			this.LoadSnapshot("DEFAULT");
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			if (Input.GetKey(KeyCode.Tab))
			{
				this.StoreSnapshot("SNAPSHOT1");
			}
			else
			{
				this.LoadSnapshot("SNAPSHOT1");
			}
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			if (Input.GetKey(KeyCode.Tab))
			{
				this.StoreSnapshot("SNAPSHOT2");
			}
			else
			{
				this.LoadSnapshot("SNAPSHOT2");
			}
		}
		if (Input.GetKeyDown(KeyCode.F5))
		{
			if (Input.GetKey(KeyCode.Tab))
			{
				this.StoreSnapshot("SNAPSHOT3");
			}
			else
			{
				this.LoadSnapshot("SNAPSHOT3");
			}
		}
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x0003E670 File Offset: 0x0003CA70
	private bool StoreSnapshot(string snapshotName)
	{
		float num = 0f;
		this.PresetManager.SetCurrentPreset(snapshotName);
		if (this.CameraController != null)
		{
			this.CameraController.GetIPD(ref num);
			this.PresetManager.SetPropertyFloat("IPD", ref num);
			num = OVRDevice.GetPredictionTime(0);
			this.PresetManager.SetPropertyFloat("PREDICTION", ref num);
			this.CameraController.GetVerticalFOV(ref num);
			this.PresetManager.SetPropertyFloat("FOV", ref num);
			Vector3 zero = Vector3.zero;
			this.CameraController.GetNeckPosition(ref zero);
			this.PresetManager.SetPropertyFloat("HEIGHT", ref zero.y);
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			this.CameraController.GetDistortionCoefs(ref num2, ref num3, ref num4, ref num5);
			this.PresetManager.SetPropertyFloat("DISTORTIONK0", ref num2);
			this.PresetManager.SetPropertyFloat("DISTORTIONK1", ref num3);
			this.PresetManager.SetPropertyFloat("DISTORTIONK2", ref num4);
			this.PresetManager.SetPropertyFloat("DISTORTIONK3", ref num5);
		}
		if (this.PlayerController != null)
		{
			this.PlayerController.GetMoveScaleMultiplier(ref num);
			this.PresetManager.SetPropertyFloat("SPEEDMULT", ref num);
			this.PlayerController.GetRotationScaleMultiplier(ref num);
			this.PresetManager.SetPropertyFloat("ROTMULT", ref num);
		}
		return true;
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x0003E7F4 File Offset: 0x0003CBF4
	private bool LoadSnapshot(string snapshotName)
	{
		float num = 0f;
		this.PresetManager.SetCurrentPreset(snapshotName);
		if (this.CameraController != null)
		{
			if (this.PresetManager.GetPropertyFloat("IPD", ref num))
			{
				this.CameraController.SetIPD(num);
			}
			if (this.PresetManager.GetPropertyFloat("PREDICTION", ref num))
			{
				OVRDevice.SetPredictionTime(0, num);
			}
			if (this.PresetManager.GetPropertyFloat("FOV", ref num))
			{
				this.CameraController.SetVerticalFOV(num);
			}
			if (this.PresetManager.GetPropertyFloat("HEIGHT", ref num))
			{
				Vector3 zero = Vector3.zero;
				this.CameraController.GetNeckPosition(ref zero);
				zero.y = num;
				this.CameraController.SetNeckPosition(zero);
			}
			float distK = 0f;
			float distK2 = 0f;
			float distK3 = 0f;
			float distK4 = 0f;
			this.CameraController.GetDistortionCoefs(ref distK, ref distK2, ref distK3, ref distK4);
			if (this.PresetManager.GetPropertyFloat("DISTORTIONK0", ref num))
			{
				distK = num;
			}
			if (this.PresetManager.GetPropertyFloat("DISTORTIONK1", ref num))
			{
				distK2 = num;
			}
			if (this.PresetManager.GetPropertyFloat("DISTORTIONK2", ref num))
			{
				distK3 = num;
			}
			if (this.PresetManager.GetPropertyFloat("DISTORTIONK3", ref num))
			{
				distK4 = num;
			}
			this.CameraController.SetDistortionCoefs(distK, distK2, distK3, distK4);
		}
		if (this.PlayerController != null)
		{
			if (this.PresetManager.GetPropertyFloat("SPEEDMULT", ref num))
			{
				this.PlayerController.SetMoveScaleMultiplier(num);
			}
			if (this.PresetManager.GetPropertyFloat("ROTMULT", ref num))
			{
				this.PlayerController.SetRotationScaleMultiplier(num);
			}
		}
		return true;
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x0003E9C4 File Offset: 0x0003CDC4
	private void CheckIfRiftPresent()
	{
		this.HMDPresent = OVRDevice.IsHMDPresent();
		this.SensorPresent = OVRDevice.IsSensorPresent(0);
		if (!this.HMDPresent || !this.SensorPresent)
		{
			this.RiftPresentTimeout = 5f;
			if (!this.HMDPresent && !this.SensorPresent)
			{
				this.strRiftPresent = "NO HMD AND SENSOR DETECTED";
			}
			else if (!this.HMDPresent)
			{
				this.strRiftPresent = "NO HMD DETECTED";
			}
			else if (!this.SensorPresent)
			{
				this.strRiftPresent = "NO SENSOR DETECTED";
			}
		}
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x0003EA60 File Offset: 0x0003CE60
	private bool GUIShowRiftDetected()
	{
		if (this.RiftPresentTimeout > 0f)
		{
			this.GuiHelper.StereoBox(this.StartX, this.StartY, this.WidthX, this.WidthY, ref this.strRiftPresent, Color.white);
			return true;
		}
		if (this.DeviceDetectionTimeout > 0f)
		{
			this.GuiHelper.StereoBox(this.StartX, this.StartY, this.WidthX, this.WidthY, ref this.strDeviceDetection, Color.white);
			return true;
		}
		return false;
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x0003EAF0 File Offset: 0x0003CEF0
	private void UpdateDeviceDetection()
	{
		if (this.RiftPresentTimeout > 0f)
		{
			this.RiftPresentTimeout -= Time.deltaTime;
		}
		if (this.DeviceDetectionTimeout > 0f)
		{
			this.DeviceDetectionTimeout -= Time.deltaTime;
		}
	}

	// Token: 0x06000605 RID: 1541 RVA: 0x0003EB44 File Offset: 0x0003CF44
	private void UpdateDeviceDetectionMsgCallback(OVRMainMenu.Device device, bool attached)
	{
		if (attached)
		{
			if (device != OVRMainMenu.Device.HMDSensor)
			{
				if (device != OVRMainMenu.Device.HMD)
				{
					if (device == OVRMainMenu.Device.LatencyTester)
					{
						this.strDeviceDetection = "LATENCY SENSOR ATTACHED";
					}
				}
				else
				{
					this.strDeviceDetection = "HMD ATTACHED";
				}
			}
			else
			{
				this.strDeviceDetection = "HMD SENSOR ATTACHED";
			}
		}
		else if (device != OVRMainMenu.Device.HMDSensor)
		{
			if (device != OVRMainMenu.Device.HMD)
			{
				if (device == OVRMainMenu.Device.LatencyTester)
				{
					this.strDeviceDetection = "LATENCY SENSOR DETACHED";
				}
			}
			else
			{
				this.strDeviceDetection = "HMD DETACHED";
			}
		}
		else
		{
			this.strDeviceDetection = "HMD SENSOR DETACHED";
		}
		if (this.AlphaFadeValue == 0f)
		{
			this.DeviceDetectionTimeout = 3f;
		}
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x0003EC09 File Offset: 0x0003D009
	private void UpdateResetOrientation()
	{
		if ((!this.ScenesVisible && OVRGamepadController.GPC_GetButton(5)) || Input.GetKeyDown(KeyCode.B))
		{
			OVRDevice.ResetOrientation(0);
		}
	}

	// Token: 0x04000882 RID: 2178
	private OVRPresetManager PresetManager = new OVRPresetManager();

	// Token: 0x04000883 RID: 2179
	public float FadeInTime = 2f;

	// Token: 0x04000884 RID: 2180
	public Texture FadeInTexture;

	// Token: 0x04000885 RID: 2181
	public Font FontReplace;

	// Token: 0x04000886 RID: 2182
	public string[] SceneNames;

	// Token: 0x04000887 RID: 2183
	public string[] Scenes;

	// Token: 0x04000888 RID: 2184
	private bool ScenesVisible;

	// Token: 0x04000889 RID: 2185
	private int StartX = 490;

	// Token: 0x0400088A RID: 2186
	private int StartY = 300;

	// Token: 0x0400088B RID: 2187
	private int WidthX = 300;

	// Token: 0x0400088C RID: 2188
	private int WidthY = 23;

	// Token: 0x0400088D RID: 2189
	private int VRVarsSX = 553;

	// Token: 0x0400088E RID: 2190
	private int VRVarsSY = 350;

	// Token: 0x0400088F RID: 2191
	private int VRVarsWidthX = 175;

	// Token: 0x04000890 RID: 2192
	private int VRVarsWidthY = 23;

	// Token: 0x04000891 RID: 2193
	private int StepY = 25;

	// Token: 0x04000892 RID: 2194
	private OVRCameraController CameraController;

	// Token: 0x04000893 RID: 2195
	private OVRPlayerController PlayerController;

	// Token: 0x04000894 RID: 2196
	private bool PrevStartDown;

	// Token: 0x04000895 RID: 2197
	private bool PrevHatDown;

	// Token: 0x04000896 RID: 2198
	private bool PrevHatUp;

	// Token: 0x04000897 RID: 2199
	private bool ShowVRVars;

	// Token: 0x04000898 RID: 2200
	private bool OldSpaceHit;

	// Token: 0x04000899 RID: 2201
	private float UpdateInterval = 0.5f;

	// Token: 0x0400089A RID: 2202
	private float Accum;

	// Token: 0x0400089B RID: 2203
	private int Frames;

	// Token: 0x0400089C RID: 2204
	private float TimeLeft;

	// Token: 0x0400089D RID: 2205
	private string strFPS = "FPS: 0";

	// Token: 0x0400089E RID: 2206
	public float IPDIncrement = 0.0025f;

	// Token: 0x0400089F RID: 2207
	private string strIPD = "IPD: 0.000";

	// Token: 0x040008A0 RID: 2208
	public float PredictionIncrement = 0.001f;

	// Token: 0x040008A1 RID: 2209
	private string strPrediction = "Pred: OFF";

	// Token: 0x040008A2 RID: 2210
	public float FOVIncrement = 0.2f;

	// Token: 0x040008A3 RID: 2211
	private string strFOV = "FOV: 0.0f";

	// Token: 0x040008A4 RID: 2212
	public float DistKIncrement = 0.001f;

	// Token: 0x040008A5 RID: 2213
	public float HeightIncrement = 0.01f;

	// Token: 0x040008A6 RID: 2214
	private string strHeight = "Height: 0.0f";

	// Token: 0x040008A7 RID: 2215
	public float SpeedRotationIncrement = 0.05f;

	// Token: 0x040008A8 RID: 2216
	private string strSpeedRotationMultipler = "Spd. X: 0.0f Rot. X: 0.0f";

	// Token: 0x040008A9 RID: 2217
	private bool LoadingLevel;

	// Token: 0x040008AA RID: 2218
	private float AlphaFadeValue = 1f;

	// Token: 0x040008AB RID: 2219
	private int CurrentLevel;

	// Token: 0x040008AC RID: 2220
	private bool HMDPresent;

	// Token: 0x040008AD RID: 2221
	private bool SensorPresent;

	// Token: 0x040008AE RID: 2222
	private float RiftPresentTimeout;

	// Token: 0x040008AF RID: 2223
	private string strRiftPresent = string.Empty;

	// Token: 0x040008B0 RID: 2224
	private float DeviceDetectionTimeout;

	// Token: 0x040008B1 RID: 2225
	private string strDeviceDetection = string.Empty;

	// Token: 0x040008B2 RID: 2226
	private OVRMagCalibration MagCal = new OVRMagCalibration();

	// Token: 0x040008B3 RID: 2227
	private OVRGUI GuiHelper = new OVRGUI();

	// Token: 0x040008B4 RID: 2228
	private GameObject GUIRenderObject;

	// Token: 0x040008B5 RID: 2229
	private RenderTexture GUIRenderTexture;

	// Token: 0x040008B6 RID: 2230
	public Texture CrosshairImage;

	// Token: 0x040008B7 RID: 2231
	private OVRCrosshair Crosshair = new OVRCrosshair();

	// Token: 0x040008B8 RID: 2232
	private OVRMainMenu.updateFunctions UpdateFunctions;

	// Token: 0x02000110 RID: 272
	public enum Device
	{
		// Token: 0x040008BA RID: 2234
		HMDSensor,
		// Token: 0x040008BB RID: 2235
		HMD,
		// Token: 0x040008BC RID: 2236
		LatencyTester
	}

	// Token: 0x02000111 RID: 273
	// (Invoke) Token: 0x06000608 RID: 1544
	private delegate void updateFunctions();
}
