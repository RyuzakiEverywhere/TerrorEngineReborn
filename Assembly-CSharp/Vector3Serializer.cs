using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000248 RID: 584
[ProtoContract]
[Serializable]
public struct Vector3Serializer
{
	// Token: 0x0600105B RID: 4187 RVA: 0x00067F19 File Offset: 0x00066319
	public Vector3Serializer(Vector3 data)
	{
		this.X = data.x;
		this.Y = data.y;
		this.Z = data.z;
	}

	// Token: 0x0600105C RID: 4188 RVA: 0x00067F42 File Offset: 0x00066342
	public static explicit operator Vector3(Vector3Serializer data)
	{
		return new Vector3(data.X, data.Y, data.Z);
	}

	// Token: 0x0600105D RID: 4189 RVA: 0x00067F5E File Offset: 0x0006635E
	public static explicit operator Vector3Serializer(Vector3 data)
	{
		return new Vector3Serializer(data);
	}

	// Token: 0x04001102 RID: 4354
	[ProtoMember(1)]
	public float X;

	// Token: 0x04001103 RID: 4355
	[ProtoMember(2)]
	public float Y;

	// Token: 0x04001104 RID: 4356
	[ProtoMember(3)]
	public float Z;
}
