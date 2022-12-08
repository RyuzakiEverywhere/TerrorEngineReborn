using System;
using ProtoBuf;

// Token: 0x0200023A RID: 570
[ProtoContract]
public enum WrapModeSerializer
{
	// Token: 0x040010B6 RID: 4278
	Once,
	// Token: 0x040010B7 RID: 4279
	Loop,
	// Token: 0x040010B8 RID: 4280
	PingPong,
	// Token: 0x040010B9 RID: 4281
	Default,
	// Token: 0x040010BA RID: 4282
	ClampForever,
	// Token: 0x040010BB RID: 4283
	Clamp
}
