using System;
using ProtoBuf;

// Token: 0x0200021E RID: 542
[ProtoContract]
public enum AnimationCullingTypeSerializer
{
	// Token: 0x0400100E RID: 4110
	AlwaysAnimate,
	// Token: 0x0400100F RID: 4111
	BasedOnRenderers,
	// Token: 0x04001010 RID: 4112
	BasedOnClipBounds,
	// Token: 0x04001011 RID: 4113
	BasedOnUserBounds
}
