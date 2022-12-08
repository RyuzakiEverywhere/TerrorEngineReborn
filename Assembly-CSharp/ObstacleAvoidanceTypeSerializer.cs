using System;
using ProtoBuf;

// Token: 0x0200022F RID: 559
[ProtoContract]
public enum ObstacleAvoidanceTypeSerializer
{
	// Token: 0x04001077 RID: 4215
	NoObstacleAvoidance,
	// Token: 0x04001078 RID: 4216
	LowQualityObstacleAvoidance,
	// Token: 0x04001079 RID: 4217
	MedQualityObstacleAvoidance,
	// Token: 0x0400107A RID: 4218
	GoodQualityObstacleAvoidance,
	// Token: 0x0400107B RID: 4219
	HighQualityObstacleAvoidance
}
