using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200023E RID: 574
[ProtoContract]
public struct ColorSerializer
{
	// Token: 0x0600100D RID: 4109 RVA: 0x00067737 File Offset: 0x00065B37
	public ColorSerializer(Color data)
	{
		this.R = data.r;
		this.G = data.g;
		this.B = data.b;
		this.A = data.a;
	}

	// Token: 0x0600100E RID: 4110 RVA: 0x0006776D File Offset: 0x00065B6D
	public static explicit operator Color(ColorSerializer data)
	{
		return new Color(data.R, data.G, data.B, data.A);
	}

	// Token: 0x0600100F RID: 4111 RVA: 0x00067790 File Offset: 0x00065B90
	public static explicit operator ColorSerializer(Color data)
	{
		return new ColorSerializer(data);
	}

	// Token: 0x040010CD RID: 4301
	[ProtoMember(1)]
	public float R;

	// Token: 0x040010CE RID: 4302
	[ProtoMember(2)]
	public float G;

	// Token: 0x040010CF RID: 4303
	[ProtoMember(3)]
	public float B;

	// Token: 0x040010D0 RID: 4304
	[ProtoMember(4)]
	public float A;
}
