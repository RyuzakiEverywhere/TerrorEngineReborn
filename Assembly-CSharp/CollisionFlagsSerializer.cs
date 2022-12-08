using System;
using ProtoBuf;

// Token: 0x02000224 RID: 548
[ProtoContract]
public enum CollisionFlagsSerializer
{
	// Token: 0x04001042 RID: 4162
	None,
	// Token: 0x04001043 RID: 4163
	Sides,
	// Token: 0x04001044 RID: 4164
	Above,
	// Token: 0x04001045 RID: 4165
	Below,
	// Token: 0x04001046 RID: 4166
	CollidedSides,
	// Token: 0x04001047 RID: 4167
	CollidedAbove,
	// Token: 0x04001048 RID: 4168
	CollidedBelow
}
