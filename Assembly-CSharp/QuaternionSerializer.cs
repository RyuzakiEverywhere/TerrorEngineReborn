using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000244 RID: 580
[ProtoContract]
public struct QuaternionSerializer
{
	// Token: 0x06001035 RID: 4149 RVA: 0x00067C1A File Offset: 0x0006601A
	public QuaternionSerializer(Quaternion data)
	{
		this.X = data.x;
		this.Y = data.y;
		this.Z = data.z;
		this.W = data.w;
	}

	// Token: 0x06001036 RID: 4150 RVA: 0x00067C50 File Offset: 0x00066050
	public static explicit operator Quaternion(QuaternionSerializer data)
	{
		return new Quaternion(data.X, data.Y, data.Z, data.W);
	}

	// Token: 0x06001037 RID: 4151 RVA: 0x00067C73 File Offset: 0x00066073
	public static explicit operator QuaternionSerializer(Quaternion data)
	{
		return new QuaternionSerializer(data);
	}

	// Token: 0x040010EF RID: 4335
	[ProtoMember(1)]
	public float X;

	// Token: 0x040010F0 RID: 4336
	[ProtoMember(2)]
	public float Y;

	// Token: 0x040010F1 RID: 4337
	[ProtoMember(3)]
	public float Z;

	// Token: 0x040010F2 RID: 4338
	[ProtoMember(4)]
	public float W;
}
