using System;
using ProtoBuf;

// Token: 0x02000232 RID: 562
[ProtoContract]
[Flags]
public enum RigidbodyConstraintsSerializer
{
	// Token: 0x04001088 RID: 4232
	None = 0,
	// Token: 0x04001089 RID: 4233
	FreezePositionX = 1,
	// Token: 0x0400108A RID: 4234
	FreezePositionY = 2,
	// Token: 0x0400108B RID: 4235
	FreezePositionZ = 3,
	// Token: 0x0400108C RID: 4236
	FreezeRotationX = 4,
	// Token: 0x0400108D RID: 4237
	FreezeRotationY = 5,
	// Token: 0x0400108E RID: 4238
	FreezeRotationZ = 6,
	// Token: 0x0400108F RID: 4239
	FreezePosition = 7,
	// Token: 0x04001090 RID: 4240
	FreezeRotation = 8,
	// Token: 0x04001091 RID: 4241
	FreezeAll = 9
}
