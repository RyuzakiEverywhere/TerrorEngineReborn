using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000249 RID: 585
[ProtoContract]
public struct Vector4Serializer
{
	// Token: 0x0600105E RID: 4190 RVA: 0x00067F66 File Offset: 0x00066366
	public Vector4Serializer(Vector4 data)
	{
		this.X = data.x;
		this.Y = data.y;
		this.Z = data.z;
		this.W = data.w;
	}

	// Token: 0x0600105F RID: 4191 RVA: 0x00067F9C File Offset: 0x0006639C
	public static explicit operator Vector4(Vector4Serializer data)
	{
		return new Vector4(data.X, data.Y, data.Z, data.W);
	}

	// Token: 0x06001060 RID: 4192 RVA: 0x00067FBF File Offset: 0x000663BF
	public static explicit operator Vector4Serializer(Vector4 data)
	{
		return new Vector4Serializer(data);
	}

	// Token: 0x04001105 RID: 4357
	[ProtoMember(1)]
	public float X;

	// Token: 0x04001106 RID: 4358
	[ProtoMember(2)]
	public float Y;

	// Token: 0x04001107 RID: 4359
	[ProtoMember(3)]
	public float Z;

	// Token: 0x04001108 RID: 4360
	[ProtoMember(4)]
	public float W;
}
