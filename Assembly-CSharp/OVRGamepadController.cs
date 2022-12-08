using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x0200010A RID: 266
public class OVRGamepadController : MonoBehaviour
{
	// Token: 0x060005D0 RID: 1488
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GamepadController_Initialize();

	// Token: 0x060005D1 RID: 1489
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GamepadController_Destroy();

	// Token: 0x060005D2 RID: 1490
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GamepadController_Update();

	// Token: 0x060005D3 RID: 1491
	[DllImport("OculusPlugin")]
	private static extern float OVR_GamepadController_GetAxis(int axis);

	// Token: 0x060005D4 RID: 1492
	[DllImport("OculusPlugin")]
	private static extern bool OVR_GamepadController_GetButton(int button);

	// Token: 0x060005D5 RID: 1493 RVA: 0x0003C9EF File Offset: 0x0003ADEF
	public static bool GPC_Initialize()
	{
		return OVRGamepadController.OVR_GamepadController_Initialize();
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x0003C9F6 File Offset: 0x0003ADF6
	public static bool GPC_Destroy()
	{
		return OVRGamepadController.OVR_GamepadController_Destroy();
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x0003C9FD File Offset: 0x0003ADFD
	public static bool GPC_Update()
	{
		return OVRGamepadController.OVR_GamepadController_Update();
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x0003CA04 File Offset: 0x0003AE04
	public static float GPC_GetAxis(int axis)
	{
		return OVRGamepadController.OVR_GamepadController_GetAxis(axis);
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x0003CA0C File Offset: 0x0003AE0C
	public static bool GPC_GetButton(int button)
	{
		return OVRGamepadController.OVR_GamepadController_GetButton(button);
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x0003CA14 File Offset: 0x0003AE14
	public static bool GPC_IsAvailable()
	{
		return OVRGamepadController.GPC_Available;
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x0003CA1C File Offset: 0x0003AE1C
	private void GPC_Test()
	{
		Debug.Log(string.Format("LT:{0:F3} RT:{1:F3} LX:{2:F3} LY:{3:F3} RX:{4:F3} RY:{5:F3}", new object[]
		{
			OVRGamepadController.GPC_GetAxis(4),
			OVRGamepadController.GPC_GetAxis(5),
			OVRGamepadController.GPC_GetAxis(0),
			OVRGamepadController.GPC_GetAxis(1),
			OVRGamepadController.GPC_GetAxis(2),
			OVRGamepadController.GPC_GetAxis(3)
		}));
		Debug.Log(string.Format("A:{0} B:{1} X:{2} Y:{3} U:{4} D:{5} L:{6} R:{7} SRT:{8} BK:{9} LS:{10} RS:{11} L1{12} R1{13}", new object[]
		{
			OVRGamepadController.GPC_GetButton(0),
			OVRGamepadController.GPC_GetButton(1),
			OVRGamepadController.GPC_GetButton(2),
			OVRGamepadController.GPC_GetButton(3),
			OVRGamepadController.GPC_GetButton(4),
			OVRGamepadController.GPC_GetButton(5),
			OVRGamepadController.GPC_GetButton(6),
			OVRGamepadController.GPC_GetButton(7),
			OVRGamepadController.GPC_GetButton(8),
			OVRGamepadController.GPC_GetButton(9),
			OVRGamepadController.GPC_GetButton(10),
			OVRGamepadController.GPC_GetButton(11),
			OVRGamepadController.GPC_GetButton(12),
			OVRGamepadController.GPC_GetButton(13)
		}));
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x0003CB76 File Offset: 0x0003AF76
	private void Awake()
	{
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x0003CB78 File Offset: 0x0003AF78
	private void Start()
	{
		OVRGamepadController.GPC_Available = OVRGamepadController.GPC_Initialize();
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x0003CB84 File Offset: 0x0003AF84
	private void Update()
	{
		OVRGamepadController.GPC_Available = OVRGamepadController.GPC_Update();
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x0003CB90 File Offset: 0x0003AF90
	private void OnDestroy()
	{
		OVRGamepadController.GPC_Destroy();
		OVRGamepadController.GPC_Available = false;
	}

	// Token: 0x0400085D RID: 2141
	private static bool GPC_Available;

	// Token: 0x0200010B RID: 267
	public enum Axis
	{
		// Token: 0x0400085F RID: 2143
		LeftXAxis,
		// Token: 0x04000860 RID: 2144
		LeftYAxis,
		// Token: 0x04000861 RID: 2145
		RightXAxis,
		// Token: 0x04000862 RID: 2146
		RightYAxis,
		// Token: 0x04000863 RID: 2147
		LeftTrigger,
		// Token: 0x04000864 RID: 2148
		RightTrigger
	}

	// Token: 0x0200010C RID: 268
	public enum Button
	{
		// Token: 0x04000866 RID: 2150
		A,
		// Token: 0x04000867 RID: 2151
		B,
		// Token: 0x04000868 RID: 2152
		X,
		// Token: 0x04000869 RID: 2153
		Y,
		// Token: 0x0400086A RID: 2154
		Up,
		// Token: 0x0400086B RID: 2155
		Down,
		// Token: 0x0400086C RID: 2156
		Left,
		// Token: 0x0400086D RID: 2157
		Right,
		// Token: 0x0400086E RID: 2158
		Start,
		// Token: 0x0400086F RID: 2159
		Back,
		// Token: 0x04000870 RID: 2160
		LStick,
		// Token: 0x04000871 RID: 2161
		RStick,
		// Token: 0x04000872 RID: 2162
		L1,
		// Token: 0x04000873 RID: 2163
		R1
	}
}
