using System;
using ProtoBuf;

// Token: 0x0200022E RID: 558
[ProtoContract]
public enum NetworkStateSynchronizationSerializer
{
	// Token: 0x04001073 RID: 4211
	Off,
	// Token: 0x04001074 RID: 4212
	ReliableDeltaCompressed,
	// Token: 0x04001075 RID: 4213
	Unreliable
}
