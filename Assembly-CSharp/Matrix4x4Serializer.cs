using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000243 RID: 579
[ProtoContract]
public struct Matrix4x4Serializer
{
	// Token: 0x06001032 RID: 4146 RVA: 0x00067A3C File Offset: 0x00065E3C
	public Matrix4x4Serializer(Matrix4x4 data)
	{
		this.M00 = data.m00;
		this.M10 = data.m10;
		this.M20 = data.m20;
		this.M30 = data.m30;
		this.M01 = data.m01;
		this.M11 = data.m11;
		this.M21 = data.m21;
		this.M31 = data.m31;
		this.M02 = data.m02;
		this.M12 = data.m12;
		this.M22 = data.m22;
		this.M32 = data.m32;
		this.M03 = data.m03;
		this.M13 = data.m13;
		this.M23 = data.m23;
		this.M33 = data.m33;
	}

	// Token: 0x06001033 RID: 4147 RVA: 0x00067B1C File Offset: 0x00065F1C
	public static explicit operator Matrix4x4(Matrix4x4Serializer data)
	{
		return new Matrix4x4
		{
			m00 = data.M00,
			m10 = data.M10,
			m20 = data.M20,
			m30 = data.M30,
			m01 = data.M01,
			m11 = data.M11,
			m21 = data.M21,
			m31 = data.M31,
			m02 = data.M02,
			m12 = data.M12,
			m22 = data.M22,
			m32 = data.M32,
			m03 = data.M03,
			m13 = data.M13,
			m23 = data.M23,
			m33 = data.M33
		};
	}

	// Token: 0x06001034 RID: 4148 RVA: 0x00067C12 File Offset: 0x00066012
	public static explicit operator Matrix4x4Serializer(Matrix4x4 data)
	{
		return new Matrix4x4Serializer(data);
	}

	// Token: 0x040010DF RID: 4319
	[ProtoMember(1)]
	public float M00;

	// Token: 0x040010E0 RID: 4320
	[ProtoMember(2)]
	public float M10;

	// Token: 0x040010E1 RID: 4321
	[ProtoMember(3)]
	public float M20;

	// Token: 0x040010E2 RID: 4322
	[ProtoMember(4)]
	public float M30;

	// Token: 0x040010E3 RID: 4323
	[ProtoMember(5)]
	public float M01;

	// Token: 0x040010E4 RID: 4324
	[ProtoMember(6)]
	public float M11;

	// Token: 0x040010E5 RID: 4325
	[ProtoMember(7)]
	public float M21;

	// Token: 0x040010E6 RID: 4326
	[ProtoMember(8)]
	public float M31;

	// Token: 0x040010E7 RID: 4327
	[ProtoMember(9)]
	public float M02;

	// Token: 0x040010E8 RID: 4328
	[ProtoMember(10)]
	public float M12;

	// Token: 0x040010E9 RID: 4329
	[ProtoMember(11)]
	public float M22;

	// Token: 0x040010EA RID: 4330
	[ProtoMember(12)]
	public float M32;

	// Token: 0x040010EB RID: 4331
	[ProtoMember(13)]
	public float M03;

	// Token: 0x040010EC RID: 4332
	[ProtoMember(14)]
	public float M13;

	// Token: 0x040010ED RID: 4333
	[ProtoMember(15)]
	public float M23;

	// Token: 0x040010EE RID: 4334
	[ProtoMember(16)]
	public float M33;
}
