using System;
using System.Runtime.InteropServices;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000241 RID: 577
[ProtoContract]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct JointMotorSerializer
{
	// Token: 0x06001026 RID: 4134 RVA: 0x00067918 File Offset: 0x00065D18
	public JointMotorSerializer(JointMotor data)
	{
		this = default(JointMotorSerializer);
		this.TargetVelocity = data.targetVelocity;
		this.Force = data.force;
		this.FreeSpin = data.freeSpin;
	}

	// Token: 0x170002ED RID: 749
	// (get) Token: 0x06001027 RID: 4135 RVA: 0x00067948 File Offset: 0x00065D48
	// (set) Token: 0x06001028 RID: 4136 RVA: 0x00067950 File Offset: 0x00065D50
	[ProtoMember(1)]
	public float TargetVelocity { get; set; }

	// Token: 0x170002EE RID: 750
	// (get) Token: 0x06001029 RID: 4137 RVA: 0x00067959 File Offset: 0x00065D59
	// (set) Token: 0x0600102A RID: 4138 RVA: 0x00067961 File Offset: 0x00065D61
	[ProtoMember(2)]
	public float Force { get; set; }

	// Token: 0x170002EF RID: 751
	// (get) Token: 0x0600102B RID: 4139 RVA: 0x0006796A File Offset: 0x00065D6A
	// (set) Token: 0x0600102C RID: 4140 RVA: 0x00067972 File Offset: 0x00065D72
	[ProtoMember(3)]
	public bool FreeSpin { get; set; }

	// Token: 0x0600102D RID: 4141 RVA: 0x0006797C File Offset: 0x00065D7C
	public static explicit operator JointMotor(JointMotorSerializer data)
	{
		return new JointMotor
		{
			targetVelocity = data.TargetVelocity,
			force = data.Force,
			freeSpin = data.FreeSpin
		};
	}

	// Token: 0x0600102E RID: 4142 RVA: 0x000679BE File Offset: 0x00065DBE
	public static explicit operator JointMotorSerializer(JointMotor data)
	{
		return new JointMotorSerializer(data);
	}
}
