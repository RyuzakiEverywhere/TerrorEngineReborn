using System;
using ProtoBuf;

// Token: 0x02000236 RID: 566
[ProtoContract]
[Flags]
public enum TerrainRenderFlagsSerializer
{
	// Token: 0x0400109F RID: 4255
	heightmap = 0,
	// Token: 0x040010A0 RID: 4256
	trees = 1,
	// Token: 0x040010A1 RID: 4257
	details = 2,
	// Token: 0x040010A2 RID: 4258
	all = 3
}
