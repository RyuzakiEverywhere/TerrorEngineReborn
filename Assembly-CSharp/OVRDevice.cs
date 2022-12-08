using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02000106 RID: 262
public class OVRDevice : MonoBehaviour
{
	// Token: 0x0600056D RID: 1389
	[DllImport("OculusPlugin")]
	private static extern bool OVR_Update(ref OVRDevice.MessageList messageList);

	// Token: 0x0600056E RID: 1390
	[DllImport("OculusPlugin")]
	private static extern bool OVR_Initialize();

	// Token: 0x0600056F RID: 1391
	[DllImport("OculusPlugin")]
	private static extern bool OVR_Destroy();

	// Token: 0x06000570 RID: 1392
	[DllImport("OculusPlugin")]
	private static extern int OVR_GetSensorCount();

	// Token: 0x06000571 RID: 1393
	[DllImport("OculusPlugin")]
	private static extern bool OVR_IsHMDPresent();

	// Token: 0x06000572 RID: 1394
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetSensorOrientation(int sensorID, ref float w, ref float x, ref float y, ref float z);

	// Token: 0x06000573 RID: 1395
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetSensorPredictedOrientation(int sensorID, ref float w, ref float x, ref float y, ref float z);

	// Token: 0x06000574 RID: 1396
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetSensorPredictionTime(int sensorID, ref float predictionTime);

	// Token: 0x06000575 RID: 1397
	[DllImport("OculusPlugin")]
	private static extern bool OVR_SetSensorPredictionTime(int sensorID, float predictionTime);

	// Token: 0x06000576 RID: 1398
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetSensorAccelGain(int sensorID, ref float accelGain);

	// Token: 0x06000577 RID: 1399
	[DllImport("OculusPlugin")]
	private static extern bool OVR_SetSensorAccelGain(int sensorID, float accelGain);

	// Token: 0x06000578 RID: 1400
	[DllImport("OculusPlugin")]
	private static extern bool OVR_EnableYawCorrection(int sensorID, float enable);

	// Token: 0x06000579 RID: 1401
	[DllImport("OculusPlugin")]
	private static extern bool OVR_ResetSensorOrientation(int sensorID);

	// Token: 0x0600057A RID: 1402
	[DllImport("OculusPlugin")]
	private static extern bool OVR_IsSensorPresent(int sensor);

	// Token: 0x0600057B RID: 1403
	[DllImport("OculusPlugin")]
	private static extern IntPtr OVR_GetDisplayDeviceName();

	// Token: 0x0600057C RID: 1404
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetScreenResolution(ref int hResolution, ref int vResolution);

	// Token: 0x0600057D RID: 1405
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetScreenSize(ref float hSize, ref float vSize);

	// Token: 0x0600057E RID: 1406
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetEyeToScreenDistance(ref float eyeToScreenDistance);

	// Token: 0x0600057F RID: 1407
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetInterpupillaryDistance(ref float interpupillaryDistance);

	// Token: 0x06000580 RID: 1408
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetLensSeparationDistance(ref float lensSeparationDistance);

	// Token: 0x06000581 RID: 1409
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetPlayerEyeHeight(ref float eyeHeight);

	// Token: 0x06000582 RID: 1410
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetEyeOffset(ref float leftEye, ref float rightEye);

	// Token: 0x06000583 RID: 1411
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetScreenVCenter(ref float vCenter);

	// Token: 0x06000584 RID: 1412
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GetDistortionCoefficients(ref float k0, ref float k1, ref float k2, ref float k3);

	// Token: 0x06000585 RID: 1413
	[DllImport("OculusPlugin")]
	private static extern bool OVR_RenderPortraitMode();

	// Token: 0x06000586 RID: 1414
	[DllImport("OculusPlugin")]
	private static extern void OVR_ProcessLatencyInputs();

	// Token: 0x06000587 RID: 1415
	[DllImport("OculusPlugin")]
	private static extern bool OVR_DisplayLatencyScreenColor(ref byte r, ref byte g, ref byte b);

	// Token: 0x06000588 RID: 1416
	[DllImport("OculusPlugin")]
	private static extern IntPtr OVR_GetLatencyResultsString();

	// Token: 0x06000589 RID: 1417
	[DllImport("OculusPlugin")]
	private static extern bool OVR_BeginMagAutoCalibraton(int sensor);

	// Token: 0x0600058A RID: 1418
	[DllImport("OculusPlugin")]
	private static extern bool OVR_StopMagAutoCalibraton(int sensor);

	// Token: 0x0600058B RID: 1419
	[DllImport("OculusPlugin")]
	private static extern bool OVR_UpdateMagAutoCalibration(int sensor);

	// Token: 0x0600058C RID: 1420
	[DllImport("OculusPlugin")]
	private static extern bool OVR_BeginMagManualCalibration(int sensor);

	// Token: 0x0600058D RID: 1421
	[DllImport("OculusPlugin")]
	private static extern bool OVR_StopMagManualCalibration(int sensor);

	// Token: 0x0600058E RID: 1422
	[DllImport("OculusPlugin")]
	private static extern bool OVR_UpdateMagManualCalibration(int sensor);

	// Token: 0x0600058F RID: 1423
	[DllImport("OculusPlugin")]
	private static extern int OVR_MagManualCalibrationState(int sensor);

	// Token: 0x06000590 RID: 1424
	[DllImport("OculusPlugin")]
	private static extern int OVR_MagNumberOfSamples(int sensor);

	// Token: 0x06000591 RID: 1425
	[DllImport("OculusPlugin")]
	private static extern bool OVR_IsMagCalibrated(int sensor);

	// Token: 0x06000592 RID: 1426
	[DllImport("OculusPlugin")]
	private static extern bool OVR_EnableMagYawCorrection(int sensor, bool enable);

	// Token: 0x06000593 RID: 1427
	[DllImport("OculusPlugin")]
	private static extern bool OVR_IsYawCorrectionEnabled(int sensor);

	// Token: 0x06000594 RID: 1428
	[DllImport("OculusPlugin")]
	private static extern bool OVR_IsMagYawCorrectionInProgress(int sensor);

	// Token: 0x06000595 RID: 1429 RVA: 0x0003BE24 File Offset: 0x0003A224
	private void Awake()
	{
		OVRDevice.InitSensorList(false);
		OVRDevice.InitOrientationSensorList();
		OVRDevice.OVRInit = OVRDevice.OVR_Initialize();
		if (!OVRDevice.OVRInit)
		{
			return;
		}
		OVRDevice.DisplayDeviceName += Marshal.PtrToStringAnsi(OVRDevice.OVR_GetDisplayDeviceName());
		OVRDevice.OVR_GetScreenResolution(ref OVRDevice.HResolution, ref OVRDevice.VResolution);
		OVRDevice.OVR_GetScreenSize(ref OVRDevice.HScreenSize, ref OVRDevice.VScreenSize);
		OVRDevice.OVR_GetEyeToScreenDistance(ref OVRDevice.EyeToScreenDistance);
		OVRDevice.OVR_GetLensSeparationDistance(ref OVRDevice.LensSeparationDistance);
		OVRDevice.OVR_GetEyeOffset(ref OVRDevice.LeftEyeOffset, ref OVRDevice.RightEyeOffset);
		OVRDevice.OVR_GetScreenVCenter(ref OVRDevice.ScreenVCenter);
		OVRDevice.OVR_GetDistortionCoefficients(ref OVRDevice.DistK0, ref OVRDevice.DistK1, ref OVRDevice.DistK2, ref OVRDevice.DistK3);
		if (OVRDevice.HScreenSize < 0.14f)
		{
			OVRDevice.DistortionFitX = 0f;
			OVRDevice.DistortionFitY = 1f;
		}
		else
		{
			OVRDevice.DistortionFitX = -1f;
			OVRDevice.DistortionFitY = 0f;
			OVRDevice.DistortionFitScale = 0.7f;
		}
		OVRDevice.CalculatePhysicalLensOffsets(ref OVRDevice.LensOffsetLeft, ref OVRDevice.LensOffsetRight);
		OVRDevice.SensorCount = OVRDevice.OVR_GetSensorCount();
		if (OVRDevice.PredictionTime > 0f)
		{
			OVRDevice.OVR_SetSensorPredictionTime(OVRDevice.SensorList[0], OVRDevice.PredictionTime);
		}
		else
		{
			OVRDevice.SetPredictionTime(OVRDevice.SensorList[0], this.InitialPredictionTime);
		}
		if (OVRDevice.AccelGain > 0f)
		{
			OVRDevice.OVR_SetSensorAccelGain(OVRDevice.SensorList[0], OVRDevice.AccelGain);
		}
		else
		{
			OVRDevice.SetAccelGain(OVRDevice.SensorList[0], this.InitialAccelGain);
		}
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x0003BFB7 File Offset: 0x0003A3B7
	private void Start()
	{
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x0003BFBC File Offset: 0x0003A3BC
	private void Update()
	{
		OVRDevice.MessageList msgList = OVRDevice.MsgList;
		OVRDevice.OVR_Update(ref OVRDevice.MsgList);
		if (OVRDevice.MsgList.isHMDSensorAttached != 0 && msgList.isHMDSensorAttached == 0)
		{
			OVRMessenger.Broadcast<OVRMainMenu.Device, bool>("Sensor_Attached", OVRMainMenu.Device.HMDSensor, true);
		}
		else if (OVRDevice.MsgList.isHMDSensorAttached == 0 && msgList.isHMDSensorAttached != 0)
		{
			OVRMessenger.Broadcast<OVRMainMenu.Device, bool>("Sensor_Attached", OVRMainMenu.Device.HMDSensor, false);
		}
		if (OVRDevice.MsgList.isHMDAttached != 0 && msgList.isHMDAttached == 0)
		{
			OVRMessenger.Broadcast<OVRMainMenu.Device, bool>("Sensor_Attached", OVRMainMenu.Device.HMD, true);
		}
		else if (OVRDevice.MsgList.isHMDAttached == 0 && msgList.isHMDAttached != 0)
		{
			OVRMessenger.Broadcast<OVRMainMenu.Device, bool>("Sensor_Attached", OVRMainMenu.Device.HMD, false);
		}
		if (OVRDevice.MsgList.isLatencyTesterAttached != 0 && msgList.isLatencyTesterAttached == 0)
		{
			OVRMessenger.Broadcast<OVRMainMenu.Device, bool>("Sensor_Attached", OVRMainMenu.Device.LatencyTester, true);
		}
		else if (OVRDevice.MsgList.isLatencyTesterAttached == 0 && msgList.isLatencyTesterAttached != 0)
		{
			OVRMessenger.Broadcast<OVRMainMenu.Device, bool>("Sensor_Attached", OVRMainMenu.Device.LatencyTester, false);
		}
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x0003C0D3 File Offset: 0x0003A4D3
	private void OnDestroy()
	{
		if (this.ResetTracker)
		{
			OVRDevice.OVR_Destroy();
			OVRDevice.OVRInit = false;
		}
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x0003C0EC File Offset: 0x0003A4EC
	public static bool IsInitialized()
	{
		return OVRDevice.OVRInit;
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x0003C0F3 File Offset: 0x0003A4F3
	public static bool IsHMDPresent()
	{
		return OVRDevice.OVR_IsHMDPresent();
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x0003C0FA File Offset: 0x0003A4FA
	public static bool IsSensorPresent(int sensor)
	{
		return OVRDevice.OVR_IsSensorPresent(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x0003C10C File Offset: 0x0003A50C
	public static bool GetOrientation(int sensor, ref Quaternion q)
	{
		float w = 0f;
		float x = 0f;
		float y = 0f;
		float z = 0f;
		if (OVRDevice.OVR_GetSensorOrientation(OVRDevice.SensorList[sensor], ref w, ref x, ref y, ref z))
		{
			q.w = w;
			q.x = x;
			q.y = y;
			q.z = z;
			OVRDevice.OrientSensor(sensor, ref q);
			return true;
		}
		return false;
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x0003C174 File Offset: 0x0003A574
	public static bool GetPredictedOrientation(int sensor, ref Quaternion q)
	{
		float w = 0f;
		float x = 0f;
		float y = 0f;
		float z = 0f;
		if (OVRDevice.OVR_GetSensorPredictedOrientation(OVRDevice.SensorList[sensor], ref w, ref x, ref y, ref z))
		{
			q.w = w;
			q.x = x;
			q.y = y;
			q.z = z;
			OVRDevice.OrientSensor(sensor, ref q);
			return true;
		}
		return false;
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x0003C1DC File Offset: 0x0003A5DC
	public static bool ResetOrientation(int sensor)
	{
		return OVRDevice.OVR_ResetSensorOrientation(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x0003C1EE File Offset: 0x0003A5EE
	public static float GetPredictionTime(int sensor)
	{
		return OVRDevice.PredictionTime;
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x0003C1F5 File Offset: 0x0003A5F5
	public static bool SetPredictionTime(int sensor, float predictionTime)
	{
		if (predictionTime > 0f && OVRDevice.OVR_SetSensorPredictionTime(OVRDevice.SensorList[sensor], predictionTime))
		{
			OVRDevice.PredictionTime = predictionTime;
			return true;
		}
		return false;
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x0003C221 File Offset: 0x0003A621
	public static float GetAccelGain(int sensor)
	{
		return OVRDevice.AccelGain;
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x0003C228 File Offset: 0x0003A628
	public static bool SetAccelGain(int sensor, float accelGain)
	{
		if (accelGain > 0f && OVRDevice.OVR_SetSensorAccelGain(OVRDevice.SensorList[sensor], accelGain))
		{
			OVRDevice.AccelGain = accelGain;
			return true;
		}
		return false;
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x0003C254 File Offset: 0x0003A654
	public static bool GetDistortionCorrectionCoefficients(ref float k0, ref float k1, ref float k2, ref float k3)
	{
		if (!OVRDevice.OVRInit)
		{
			return false;
		}
		k0 = OVRDevice.DistK0;
		k1 = OVRDevice.DistK1;
		k2 = OVRDevice.DistK2;
		k3 = OVRDevice.DistK3;
		return true;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x0003C27F File Offset: 0x0003A67F
	public static bool SetDistortionCorrectionCoefficients(float k0, float k1, float k2, float k3)
	{
		if (!OVRDevice.OVRInit)
		{
			return false;
		}
		OVRDevice.DistK0 = k0;
		OVRDevice.DistK1 = k1;
		OVRDevice.DistK2 = k2;
		OVRDevice.DistK3 = k3;
		return true;
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x0003C2A6 File Offset: 0x0003A6A6
	public static bool GetPhysicalLensOffsets(ref float lensOffsetLeft, ref float lensOffsetRight)
	{
		if (!OVRDevice.OVRInit)
		{
			return false;
		}
		lensOffsetLeft = OVRDevice.LensOffsetLeft;
		lensOffsetRight = OVRDevice.LensOffsetRight;
		return true;
	}

	// Token: 0x060005A6 RID: 1446 RVA: 0x0003C2C3 File Offset: 0x0003A6C3
	public static bool GetIPD(ref float IPD)
	{
		if (!OVRDevice.OVRInit)
		{
			return false;
		}
		OVRDevice.OVR_GetInterpupillaryDistance(ref IPD);
		return true;
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x0003C2D9 File Offset: 0x0003A6D9
	public static float CalculateAspectRatio()
	{
		if (Application.isEditor)
		{
			return (float)Screen.width * 0.5f / (float)Screen.height;
		}
		return (float)OVRDevice.HResolution * 0.5f / (float)OVRDevice.VResolution;
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x0003C30C File Offset: 0x0003A70C
	public static float VerticalFOV()
	{
		if (!OVRDevice.OVRInit)
		{
			return 90f;
		}
		float num = OVRDevice.VScreenSize / 2f * OVRDevice.DistortionScale();
		return 114.59156f * Mathf.Atan(num / OVRDevice.EyeToScreenDistance);
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x0003C350 File Offset: 0x0003A750
	public static float DistortionScale()
	{
		if (OVRDevice.OVRInit)
		{
			float num;
			if (Mathf.Abs(OVRDevice.DistortionFitX) < 0.0001f && Math.Abs(OVRDevice.DistortionFitY) < 0.0001f)
			{
				num = 1f;
			}
			else
			{
				float num2 = 0.5f * (float)Screen.width / (float)Screen.height;
				float num3 = OVRDevice.DistortionFitX * OVRDevice.DistortionFitScale - OVRDevice.LensOffsetLeft;
				float num4 = OVRDevice.DistortionFitY * OVRDevice.DistortionFitScale / num2;
				float fitRadius = Mathf.Sqrt(num3 * num3 + num4 * num4);
				num = OVRDevice.CalcScale(fitRadius);
			}
			if (num != 0f)
			{
				return num;
			}
		}
		return 1f;
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x0003C3FC File Offset: 0x0003A7FC
	public static void ProcessLatencyInputs()
	{
		OVRDevice.OVR_ProcessLatencyInputs();
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x0003C403 File Offset: 0x0003A803
	public static bool DisplayLatencyScreenColor(ref byte r, ref byte g, ref byte b)
	{
		return OVRDevice.OVR_DisplayLatencyScreenColor(ref r, ref g, ref b);
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x0003C40D File Offset: 0x0003A80D
	public static IntPtr GetLatencyResultsString()
	{
		return OVRDevice.OVR_GetLatencyResultsString();
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x0003C414 File Offset: 0x0003A814
	public static float CalcScale(float fitRadius)
	{
		float num = fitRadius * fitRadius;
		float num2 = fitRadius * (OVRDevice.DistK0 + OVRDevice.DistK1 * num + OVRDevice.DistK2 * num * num + OVRDevice.DistK3 * num * num * num);
		return num2 / fitRadius;
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x0003C450 File Offset: 0x0003A850
	public static bool CalculatePhysicalLensOffsets(ref float leftOffset, ref float rightOffset)
	{
		leftOffset = 0f;
		rightOffset = 0f;
		if (!OVRDevice.OVRInit)
		{
			return false;
		}
		float num = OVRDevice.HScreenSize * 0.5f;
		float num2 = OVRDevice.LensSeparationDistance * 0.5f;
		leftOffset = (num - num2) / num * 2f - 1f;
		rightOffset = num2 / num * 2f - 1f;
		return true;
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x0003C4B4 File Offset: 0x0003A8B4
	public static bool BeginMagAutoCalibration(int sensor)
	{
		return OVRDevice.OVR_BeginMagAutoCalibraton(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x0003C4C6 File Offset: 0x0003A8C6
	public static bool StopMagAutoCalibration(int sensor)
	{
		return OVRDevice.OVR_StopMagAutoCalibraton(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x0003C4D8 File Offset: 0x0003A8D8
	public static bool UpdateMagAutoCalibration(int sensor)
	{
		return OVRDevice.OVR_UpdateMagAutoCalibration(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x0003C4EA File Offset: 0x0003A8EA
	public static bool BeginMagManualCalibration(int sensor)
	{
		return OVRDevice.OVR_BeginMagManualCalibration(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x0003C4FC File Offset: 0x0003A8FC
	public static bool StopMagManualCalibration(int sensor)
	{
		return OVRDevice.OVR_StopMagManualCalibration(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x0003C50E File Offset: 0x0003A90E
	public static bool UpdateMagManualCalibration(int sensor)
	{
		return OVRDevice.OVR_UpdateMagManualCalibration(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x0003C520 File Offset: 0x0003A920
	public static int MagManualCalibrationState(int sensor)
	{
		return OVRDevice.OVR_MagManualCalibrationState(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x0003C532 File Offset: 0x0003A932
	public static int MagNumberOfSamples(int sensor)
	{
		return OVRDevice.OVR_MagNumberOfSamples(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x0003C544 File Offset: 0x0003A944
	public static bool IsMagCalibrated(int sensor)
	{
		return OVRDevice.OVR_IsMagCalibrated(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x0003C556 File Offset: 0x0003A956
	public static bool EnableMagYawCorrection(int sensor, bool enable)
	{
		return OVRDevice.OVR_EnableMagYawCorrection(OVRDevice.SensorList[sensor], enable);
	}

	// Token: 0x060005B9 RID: 1465 RVA: 0x0003C569 File Offset: 0x0003A969
	public static bool IsYawCorrectionEnabled(int sensor)
	{
		return OVRDevice.OVR_IsYawCorrectionEnabled(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x0003C57B File Offset: 0x0003A97B
	public static bool IsMagYawCorrectionInProgress(int sensor)
	{
		return OVRDevice.OVR_IsMagYawCorrectionInProgress(OVRDevice.SensorList[sensor]);
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x0003C590 File Offset: 0x0003A990
	public static void InitSensorList(bool reverse)
	{
		OVRDevice.SensorList.Clear();
		if (reverse)
		{
			OVRDevice.SensorList.Add(0, 1);
			OVRDevice.SensorList.Add(1, 0);
		}
		else
		{
			OVRDevice.SensorList.Add(0, 0);
			OVRDevice.SensorList.Add(1, 1);
		}
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x0003C5E2 File Offset: 0x0003A9E2
	public static void InitOrientationSensorList()
	{
		OVRDevice.SensorOrientationList.Clear();
		OVRDevice.SensorOrientationList.Add(0, OVRDevice.SensorOrientation.Head);
		OVRDevice.SensorOrientationList.Add(1, OVRDevice.SensorOrientation.Other);
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x0003C608 File Offset: 0x0003AA08
	public static void OrientSensor(int sensor, ref Quaternion q)
	{
		if (OVRDevice.SensorOrientationList[sensor] == OVRDevice.SensorOrientation.Head)
		{
			q.x = -q.x;
			q.y = -q.y;
		}
		else if (OVRDevice.SensorOrientationList[sensor] == OVRDevice.SensorOrientation.Other)
		{
			float x = q.x;
			q.x = q.z;
			q.y = -q.y;
			q.z = x;
		}
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x0003C67C File Offset: 0x0003AA7C
	public static bool RenderPortraitMode()
	{
		return OVRDevice.OVR_RenderPortraitMode();
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x0003C683 File Offset: 0x0003AA83
	public static bool GetPlayerEyeHeight(ref float eyeHeight)
	{
		return OVRDevice.OVR_GetPlayerEyeHeight(ref eyeHeight);
	}

	// Token: 0x04000833 RID: 2099
	public float InitialPredictionTime = 0.05f;

	// Token: 0x04000834 RID: 2100
	public float InitialAccelGain = 0.05f;

	// Token: 0x04000835 RID: 2101
	public bool ResetTracker = true;

	// Token: 0x04000836 RID: 2102
	private static OVRDevice.MessageList MsgList = new OVRDevice.MessageList(0, 0, 0);

	// Token: 0x04000837 RID: 2103
	private static bool OVRInit = false;

	// Token: 0x04000838 RID: 2104
	public static int SensorCount = 0;

	// Token: 0x04000839 RID: 2105
	public static string DisplayDeviceName;

	// Token: 0x0400083A RID: 2106
	public static int HResolution;

	// Token: 0x0400083B RID: 2107
	public static int VResolution = 0;

	// Token: 0x0400083C RID: 2108
	public static float HScreenSize;

	// Token: 0x0400083D RID: 2109
	public static float VScreenSize = 0f;

	// Token: 0x0400083E RID: 2110
	public static float EyeToScreenDistance = 0f;

	// Token: 0x0400083F RID: 2111
	public static float LensSeparationDistance = 0f;

	// Token: 0x04000840 RID: 2112
	public static float LeftEyeOffset;

	// Token: 0x04000841 RID: 2113
	public static float RightEyeOffset = 0f;

	// Token: 0x04000842 RID: 2114
	public static float ScreenVCenter = 0f;

	// Token: 0x04000843 RID: 2115
	public static float DistK0;

	// Token: 0x04000844 RID: 2116
	public static float DistK1;

	// Token: 0x04000845 RID: 2117
	public static float DistK2;

	// Token: 0x04000846 RID: 2118
	public static float DistK3 = 0f;

	// Token: 0x04000847 RID: 2119
	public static float DistortionFitScale = 1f;

	// Token: 0x04000848 RID: 2120
	private static float LensOffsetLeft;

	// Token: 0x04000849 RID: 2121
	private static float LensOffsetRight = 0f;

	// Token: 0x0400084A RID: 2122
	private static float DistortionFitX = 0f;

	// Token: 0x0400084B RID: 2123
	private static float DistortionFitY = 1f;

	// Token: 0x0400084C RID: 2124
	private static float PredictionTime = 0f;

	// Token: 0x0400084D RID: 2125
	private static float AccelGain = 0f;

	// Token: 0x0400084E RID: 2126
	private static Dictionary<int, int> SensorList = new Dictionary<int, int>();

	// Token: 0x0400084F RID: 2127
	private static Dictionary<int, OVRDevice.SensorOrientation> SensorOrientationList = new Dictionary<int, OVRDevice.SensorOrientation>();

	// Token: 0x02000107 RID: 263
	public struct MessageList
	{
		// Token: 0x060005C1 RID: 1473 RVA: 0x0003C744 File Offset: 0x0003AB44
		public MessageList(byte HMDSensor, byte HMD, byte LatencyTester)
		{
			this.isHMDSensorAttached = HMDSensor;
			this.isHMDAttached = HMD;
			this.isLatencyTesterAttached = LatencyTester;
		}

		// Token: 0x04000850 RID: 2128
		public byte isHMDSensorAttached;

		// Token: 0x04000851 RID: 2129
		public byte isHMDAttached;

		// Token: 0x04000852 RID: 2130
		public byte isLatencyTesterAttached;
	}

	// Token: 0x02000108 RID: 264
	private enum SensorOrientation
	{
		// Token: 0x04000854 RID: 2132
		Head,
		// Token: 0x04000855 RID: 2133
		Other
	}
}
