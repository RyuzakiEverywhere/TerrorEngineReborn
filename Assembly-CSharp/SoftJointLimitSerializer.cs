using System;
using System.Runtime.InteropServices;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000246 RID: 582
[ProtoContract]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct SoftJointLimitSerializer
{
	// Token: 0x0600104D RID: 4173 RVA: 0x00067E47 File Offset: 0x00066247
	public SoftJointLimitSerializer(SoftJointLimit data)
	{
		this = default(SoftJointLimitSerializer);
		this.Limit = data.limit;
	}

	// Token: 0x170002F9 RID: 761
	// (get) Token: 0x0600104E RID: 4174 RVA: 0x00067E5D File Offset: 0x0006625D
	// (set) Token: 0x0600104F RID: 4175 RVA: 0x00067E65 File Offset: 0x00066265
	[ProtoMember(1)]
	public float Limit { get; set; }

	// Token: 0x170002FA RID: 762
	// (get) Token: 0x06001050 RID: 4176 RVA: 0x00067E6E File Offset: 0x0006626E
	// (set) Token: 0x06001051 RID: 4177 RVA: 0x00067E76 File Offset: 0x00066276
	[ProtoMember(2)]
	public float Spring { get; set; }

	// Token: 0x170002FB RID: 763
	// (get) Token: 0x06001052 RID: 4178 RVA: 0x00067E7F File Offset: 0x0006627F
	// (set) Token: 0x06001053 RID: 4179 RVA: 0x00067E87 File Offset: 0x00066287
	[ProtoMember(3)]
	public float Damper { get; set; }

	// Token: 0x170002FC RID: 764
	// (get) Token: 0x06001054 RID: 4180 RVA: 0x00067E90 File Offset: 0x00066290
	// (set) Token: 0x06001055 RID: 4181 RVA: 0x00067E98 File Offset: 0x00066298
	[ProtoMember(4)]
	public float Bounciness { get; set; }

	// Token: 0x06001056 RID: 4182 RVA: 0x00067EA4 File Offset: 0x000662A4
	public static explicit operator SoftJointLimit(SoftJointLimitSerializer data)
	{
		return new SoftJointLimit
		{
			limit = data.Limit,
			bounciness = data.Bounciness
		};
	}

	// Token: 0x06001057 RID: 4183 RVA: 0x00067ED8 File Offset: 0x000662D8
	public static explicit operator SoftJointLimitSerializer(SoftJointLimit data)
	{
		return new SoftJointLimitSerializer(data);
	}
}
