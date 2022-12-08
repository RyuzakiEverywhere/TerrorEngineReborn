using System;
using System.Runtime.InteropServices;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000240 RID: 576
[ProtoContract]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct JointLimitsSerializer
{
	// Token: 0x0600101B RID: 4123 RVA: 0x00067874 File Offset: 0x00065C74
	public JointLimitsSerializer(JointLimits data)
	{
		this = default(JointLimitsSerializer);
		this.Min = data.min;
		this.Max = data.max;
	}

	// Token: 0x170002E9 RID: 745
	// (get) Token: 0x0600101C RID: 4124 RVA: 0x00067897 File Offset: 0x00065C97
	// (set) Token: 0x0600101D RID: 4125 RVA: 0x0006789F File Offset: 0x00065C9F
	[ProtoMember(1)]
	public float Min { get; set; }

	// Token: 0x170002EA RID: 746
	// (get) Token: 0x0600101E RID: 4126 RVA: 0x000678A8 File Offset: 0x00065CA8
	// (set) Token: 0x0600101F RID: 4127 RVA: 0x000678B0 File Offset: 0x00065CB0
	[ProtoMember(2)]
	public float MinBounce { get; set; }

	// Token: 0x170002EB RID: 747
	// (get) Token: 0x06001020 RID: 4128 RVA: 0x000678B9 File Offset: 0x00065CB9
	// (set) Token: 0x06001021 RID: 4129 RVA: 0x000678C1 File Offset: 0x00065CC1
	[ProtoMember(3)]
	public float Max { get; set; }

	// Token: 0x170002EC RID: 748
	// (get) Token: 0x06001022 RID: 4130 RVA: 0x000678CA File Offset: 0x00065CCA
	// (set) Token: 0x06001023 RID: 4131 RVA: 0x000678D2 File Offset: 0x00065CD2
	[ProtoMember(4)]
	public float MaxBounce { get; set; }

	// Token: 0x06001024 RID: 4132 RVA: 0x000678DC File Offset: 0x00065CDC
	public static explicit operator JointLimits(JointLimitsSerializer data)
	{
		return new JointLimits
		{
			min = data.Min,
			max = data.Max
		};
	}

	// Token: 0x06001025 RID: 4133 RVA: 0x00067910 File Offset: 0x00065D10
	public static explicit operator JointLimitsSerializer(JointLimits data)
	{
		return new JointLimitsSerializer(data);
	}
}
