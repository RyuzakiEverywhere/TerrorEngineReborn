using System;
using ProtoBuf;

// Token: 0x0200023D RID: 573
[ProtoContract]
public struct ClothSkinningCoefficientSerializer
{
	// Token: 0x040010C9 RID: 4297
	[ProtoMember(1)]
	public float MaxDistance;

	// Token: 0x040010CA RID: 4298
	[ProtoMember(2)]
	public float MaxDistanceBias;

	// Token: 0x040010CB RID: 4299
	[ProtoMember(3)]
	public float CollisionSphereRadius;

	// Token: 0x040010CC RID: 4300
	[ProtoMember(4)]
	public float CollisionSphereDistance;
}
