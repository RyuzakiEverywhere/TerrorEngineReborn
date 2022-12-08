using System;
using ProtoBuf;

// Token: 0x02000231 RID: 561
[ProtoContract]
public enum RenderingPathSerializer
{
	// Token: 0x04001083 RID: 4227
	UsePlayerSettings = -1,
	// Token: 0x04001084 RID: 4228
	VertexLit,
	// Token: 0x04001085 RID: 4229
	Forward,
	// Token: 0x04001086 RID: 4230
	DeferredLighting
}
