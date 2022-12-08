using System;
using System.Runtime.InteropServices;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200024A RID: 586
[ProtoContract]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct WheelFrictionCurveSerializer
{
	// Token: 0x06001061 RID: 4193 RVA: 0x00067FC8 File Offset: 0x000663C8
	public WheelFrictionCurveSerializer(WheelFrictionCurve data)
	{
		this = default(WheelFrictionCurveSerializer);
		this.ExtremumSlip = data.extremumSlip;
		this.ExtremumValue = data.extremumValue;
		this.AsymptoteSlip = data.asymptoteSlip;
		this.AsymptoteValue = data.asymptoteValue;
		this.Stiffness = data.stiffness;
	}

	// Token: 0x170002FD RID: 765
	// (get) Token: 0x06001062 RID: 4194 RVA: 0x0006801D File Offset: 0x0006641D
	// (set) Token: 0x06001063 RID: 4195 RVA: 0x00068025 File Offset: 0x00066425
	[ProtoMember(1)]
	public float ExtremumSlip { get; set; }

	// Token: 0x170002FE RID: 766
	// (get) Token: 0x06001064 RID: 4196 RVA: 0x0006802E File Offset: 0x0006642E
	// (set) Token: 0x06001065 RID: 4197 RVA: 0x00068036 File Offset: 0x00066436
	[ProtoMember(2)]
	public float ExtremumValue { get; set; }

	// Token: 0x170002FF RID: 767
	// (get) Token: 0x06001066 RID: 4198 RVA: 0x0006803F File Offset: 0x0006643F
	// (set) Token: 0x06001067 RID: 4199 RVA: 0x00068047 File Offset: 0x00066447
	[ProtoMember(3)]
	public float AsymptoteSlip { get; set; }

	// Token: 0x17000300 RID: 768
	// (get) Token: 0x06001068 RID: 4200 RVA: 0x00068050 File Offset: 0x00066450
	// (set) Token: 0x06001069 RID: 4201 RVA: 0x00068058 File Offset: 0x00066458
	[ProtoMember(4)]
	public float AsymptoteValue { get; set; }

	// Token: 0x17000301 RID: 769
	// (get) Token: 0x0600106A RID: 4202 RVA: 0x00068061 File Offset: 0x00066461
	// (set) Token: 0x0600106B RID: 4203 RVA: 0x00068069 File Offset: 0x00066469
	[ProtoMember(5)]
	public float Stiffness { get; set; }

	// Token: 0x0600106C RID: 4204 RVA: 0x00068074 File Offset: 0x00066474
	public static explicit operator WheelFrictionCurve(WheelFrictionCurveSerializer data)
	{
		return new WheelFrictionCurve
		{
			extremumSlip = data.ExtremumSlip,
			extremumValue = data.ExtremumValue,
			asymptoteSlip = data.AsymptoteSlip,
			asymptoteValue = data.AsymptoteValue,
			stiffness = data.Stiffness
		};
	}

	// Token: 0x0600106D RID: 4205 RVA: 0x000680D2 File Offset: 0x000664D2
	public static explicit operator WheelFrictionCurveSerializer(WheelFrictionCurve data)
	{
		return new WheelFrictionCurveSerializer(data);
	}
}
