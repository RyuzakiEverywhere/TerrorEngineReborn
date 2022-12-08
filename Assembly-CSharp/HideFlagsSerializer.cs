using System;
using ProtoBuf;

// Token: 0x02000228 RID: 552
[ProtoContract]
public enum HideFlagsSerializer
{
	// Token: 0x04001057 RID: 4183
	HideInHierarchy,
	// Token: 0x04001058 RID: 4184
	HideInInspector,
	// Token: 0x04001059 RID: 4185
	DontSave,
	// Token: 0x0400105A RID: 4186
	NotEditable,
	// Token: 0x0400105B RID: 4187
	HideAndDontSave
}
