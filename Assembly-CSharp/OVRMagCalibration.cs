using System;
using UnityEngine;

// Token: 0x0200010D RID: 269
public class OVRMagCalibration
{
	// Token: 0x060005E2 RID: 1506 RVA: 0x0003CBBE File Offset: 0x0003AFBE
	public void SetInitialCalibarationState()
	{
		if (OVRDevice.IsMagCalibrated(0) && OVRDevice.IsYawCorrectionEnabled(0))
		{
			this.MagCalState = OVRMagCalibration.MagCalibrationState.MagReady;
		}
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x0003CBDD File Offset: 0x0003AFDD
	public bool Disabled()
	{
		return this.MagCalState == OVRMagCalibration.MagCalibrationState.MagDisabled;
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x0003CBED File Offset: 0x0003AFED
	public bool Ready()
	{
		return this.MagCalState == OVRMagCalibration.MagCalibrationState.MagReady;
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x0003CBFE File Offset: 0x0003AFFE
	public void SetOVRCameraController(ref OVRCameraController cameraController)
	{
		this.CameraController = cameraController;
	}

	// Token: 0x060005E6 RID: 1510 RVA: 0x0003CC08 File Offset: 0x0003B008
	public void ShowGeometry(bool show)
	{
		if (this.GeometryReference == null)
		{
			this.GeometryReference = (UnityEngine.Object.Instantiate(Resources.Load("OVRMagReference")) as GameObject);
			this.GeometryReferenceMarkMat = this.GeometryReference.transform.Find("Mark").GetComponent<Renderer>().material;
		}
		if (this.GeometryReference != null)
		{
			this.GeometryReference.SetActive(show);
			this.AttachGeometryToCamera(show, ref this.GeometryReference);
		}
		if (this.GeometryCompass == null)
		{
			this.GeometryCompass = (UnityEngine.Object.Instantiate(Resources.Load("OVRMagCompass")) as GameObject);
		}
		if (this.GeometryCompass != null)
		{
			this.GeometryCompass.SetActive(show);
			this.AttachGeometryToCamera(show, ref this.GeometryCompass);
		}
	}

	// Token: 0x060005E7 RID: 1511 RVA: 0x0003CCE4 File Offset: 0x0003B0E4
	public void AttachGeometryToCamera(bool attach, ref GameObject go)
	{
		if (this.CameraController != null && attach)
		{
			this.CameraController.AttachGameObjectToCamera(ref go);
			OVRUtils.SetLocalTransformIdentity(ref go);
			Vector3 localPosition = go.transform.localPosition;
			float num = 0f;
			this.CameraController.GetIPD(ref num);
			localPosition.x -= num * 0.5f;
			go.transform.localPosition = localPosition;
		}
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x0003CD60 File Offset: 0x0003B160
	public void UpdateGeometry()
	{
		if (!this.MagShowGeometry)
		{
			return;
		}
		if (this.CameraController == null)
		{
			return;
		}
		if (this.GeometryReference == null || this.GeometryCompass == null)
		{
			return;
		}
		Quaternion identity = Quaternion.identity;
		if (this.CameraController != null && this.CameraController.PredictionOn)
		{
			OVRDevice.GetPredictedOrientation(0, ref identity);
		}
		else
		{
			OVRDevice.GetOrientation(0, ref identity);
		}
		Vector3 localEulerAngles = this.GeometryCompass.transform.localEulerAngles;
		localEulerAngles.y = -identity.eulerAngles.y + this.CurEulerRef.y;
		this.GeometryCompass.transform.localEulerAngles = localEulerAngles;
		if (this.GeometryReferenceMarkMat != null)
		{
			Color value = Color.red;
			if (OVRDevice.IsMagYawCorrectionInProgress(0))
			{
				value = Color.green;
			}
			this.GeometryReferenceMarkMat.SetColor("_Color", value);
		}
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x0003CE6C File Offset: 0x0003B26C
	public void UpdateMagYawDriftCorrection()
	{
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.X))
		{
			this.MagAutoCalibrate = true;
			flag = true;
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			this.MagAutoCalibrate = false;
			flag = true;
		}
		if (flag)
		{
			if (this.MagCalState == OVRMagCalibration.MagCalibrationState.MagDisabled)
			{
				if (!this.MagAutoCalibrate)
				{
					this.MagCalState = OVRMagCalibration.MagCalibrationState.MagManualGetReady;
					return;
				}
				OVRDevice.BeginMagAutoCalibration(0);
				this.MagCalState = OVRMagCalibration.MagCalibrationState.MagCalibrating;
			}
			else
			{
				if (this.MagCalState != OVRMagCalibration.MagCalibrationState.MagManualGetReady)
				{
					if (this.MagAutoCalibrate)
					{
						OVRDevice.StopMagAutoCalibration(0);
					}
					else
					{
						OVRDevice.StopMagManualCalibration(0);
					}
					OVRDevice.EnableMagYawCorrection(0, false);
					this.MagCalState = OVRMagCalibration.MagCalibrationState.MagDisabled;
					this.MagShowGeometry = false;
					this.ShowGeometry(this.MagShowGeometry);
					return;
				}
				this.EnableYawCorrection(0);
				OVRDevice.BeginMagManualCalibration(0);
				this.MagCalState = OVRMagCalibration.MagCalibrationState.MagCalibrating;
			}
		}
		if (this.MagCalState == OVRMagCalibration.MagCalibrationState.MagCalibrating)
		{
			if (this.MagAutoCalibrate)
			{
				OVRDevice.UpdateMagAutoCalibration(0);
			}
			else
			{
				OVRDevice.UpdateMagManualCalibration(0);
			}
			if (OVRDevice.IsMagCalibrated(0))
			{
				if (this.MagAutoCalibrate)
				{
					this.EnableYawCorrection(0);
				}
				this.MagCalState = OVRMagCalibration.MagCalibrationState.MagReady;
			}
		}
		if (this.MagCalState == OVRMagCalibration.MagCalibrationState.MagReady)
		{
			if (Input.GetKeyDown(KeyCode.F6))
			{
				if (!this.MagShowGeometry)
				{
					this.MagShowGeometry = true;
					this.ShowGeometry(this.MagShowGeometry);
				}
				else
				{
					this.MagShowGeometry = false;
					this.ShowGeometry(this.MagShowGeometry);
				}
			}
			this.UpdateGeometry();
		}
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x0003CFF0 File Offset: 0x0003B3F0
	public void GUIMagYawDriftCorrection(int xLoc, int yLoc, int xWidth, int yWidth, ref OVRGUI guiHelper)
	{
		string text = string.Empty;
		Color color = Color.red;
		int num = xLoc;
		int num2 = xWidth;
		switch (this.MagCalState)
		{
		case OVRMagCalibration.MagCalibrationState.MagDisabled:
			text = "Mag Calibration OFF";
			break;
		case OVRMagCalibration.MagCalibrationState.MagManualGetReady:
			text = "Manual Calibration: Look Forward, Press 'Z'..";
			color = Color.white;
			num -= 75;
			num2 += 150;
			break;
		case OVRMagCalibration.MagCalibrationState.MagCalibrating:
			if (this.MagCalTimerFlash > 0.2f)
			{
				this.FormatCalibratingString(ref text);
			}
			this.MagCalTimerFlash -= Time.deltaTime;
			if (this.MagCalTimerFlash < 0f)
			{
				this.MagCalTimerFlash += 0.5f;
			}
			color = Color.white;
			num -= 75;
			num2 += 150;
			break;
		case OVRMagCalibration.MagCalibrationState.MagReady:
			if (OVRDevice.IsMagYawCorrectionInProgress(0))
			{
				if (this.MagCalTimerFlash > 0.2f)
				{
					text = "Mag CORRECTING...";
				}
				this.MagCalTimerFlash -= Time.deltaTime;
				if (this.MagCalTimerFlash < 0f)
				{
					this.MagCalTimerFlash += 0.5f;
				}
				num -= 75;
				num2 += 150;
				color = Color.green;
			}
			else
			{
				text = "Mag Correction ON";
				color = Color.red;
			}
			break;
		}
		guiHelper.StereoBox(num, yLoc, num2, yWidth, ref text, color);
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x0003D14C File Offset: 0x0003B54C
	private void FormatCalibratingString(ref string str)
	{
		if (this.MagAutoCalibrate)
		{
			str = string.Format("Mag Calibrating (AUTO)... Point {0} set", OVRDevice.MagNumberOfSamples(0));
		}
		else
		{
			str = "Mag Calibrating (MANUAL)... LOOK ";
			switch (OVRDevice.MagManualCalibrationState(0))
			{
			case 0:
				str += "FORWARD";
				break;
			case 1:
				str += "UP";
				break;
			case 2:
				str += "LEFT";
				break;
			case 3:
				str += "RIGHT";
				break;
			case 4:
				str += "UPPER-RIGHT";
				break;
			case 5:
				str = "MANUAL CALIBRATION FAILED. PLEASE TRY AGAIN.";
				break;
			}
		}
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x0003D21C File Offset: 0x0003B61C
	private void EnableYawCorrection(int sensor)
	{
		OVRDevice.EnableMagYawCorrection(sensor, true);
		Quaternion identity = Quaternion.identity;
		if (this.CameraController != null && this.CameraController.PredictionOn)
		{
			OVRDevice.GetPredictedOrientation(sensor, ref identity);
		}
		else
		{
			OVRDevice.GetOrientation(sensor, ref identity);
		}
		this.CurEulerRef = identity.eulerAngles;
	}

	// Token: 0x04000874 RID: 2164
	private bool MagAutoCalibrate;

	// Token: 0x04000875 RID: 2165
	private OVRMagCalibration.MagCalibrationState MagCalState;

	// Token: 0x04000876 RID: 2166
	private float MagCalTimerFlash = 0.5f;

	// Token: 0x04000877 RID: 2167
	private Vector3 CurEulerRef = Vector3.zero;

	// Token: 0x04000878 RID: 2168
	private bool MagShowGeometry;

	// Token: 0x04000879 RID: 2169
	public OVRCameraController CameraController;

	// Token: 0x0400087A RID: 2170
	public GameObject GeometryReference;

	// Token: 0x0400087B RID: 2171
	public GameObject GeometryCompass;

	// Token: 0x0400087C RID: 2172
	public Material GeometryReferenceMarkMat;

	// Token: 0x0200010E RID: 270
	public enum MagCalibrationState
	{
		// Token: 0x0400087E RID: 2174
		MagDisabled,
		// Token: 0x0400087F RID: 2175
		MagManualGetReady,
		// Token: 0x04000880 RID: 2176
		MagCalibrating,
		// Token: 0x04000881 RID: 2177
		MagReady
	}
}
