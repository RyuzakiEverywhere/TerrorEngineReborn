using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000247 RID: 583
[ProtoContract]
public struct Vector2Serializer
{
	// Token: 0x06001058 RID: 4184 RVA: 0x00067EE0 File Offset: 0x000662E0
	public Vector2Serializer(Vector2 data)
	{
		this.X = data.x;
		this.Y = data.y;
	}

	// Token: 0x06001059 RID: 4185 RVA: 0x00067EFC File Offset: 0x000662FC
	public static explicit operator Vector2(Vector2Serializer data)
	{
		return new Vector2(data.X, data.Y);
	}

	// Token: 0x0600105A RID: 4186 RVA: 0x00067F11 File Offset: 0x00066311
	public static explicit operator Vector2Serializer(Vector2 data)
	{
		return new Vector2Serializer(data);
	}

	// Token: 0x04001100 RID: 4352
	[ProtoMember(1)]
	public float X;

	// Token: 0x04001101 RID: 4353
	[ProtoMember(2)]
	public float Y;
}
