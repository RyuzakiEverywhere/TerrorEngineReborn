using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000207 RID: 519
[ProtoContract]
public sealed class SkinnedClothSerializer
{
	// Token: 0x06000E3A RID: 3642 RVA: 0x00064B62 File Offset: 0x00062F62
	public SkinnedClothSerializer(GameObject gameObject, SkinnedClothSerializer component)
	{
	}

	// Token: 0x06000E3B RID: 3643 RVA: 0x00064B6A File Offset: 0x00062F6A
	public SkinnedClothSerializer(GameObject gameObject)
	{
	}

	// Token: 0x06000E3C RID: 3644 RVA: 0x00064B72 File Offset: 0x00062F72
	private SkinnedClothSerializer()
	{
	}

	// Token: 0x17000229 RID: 553
	// (get) Token: 0x06000E3D RID: 3645 RVA: 0x00064B7A File Offset: 0x00062F7A
	// (set) Token: 0x06000E3E RID: 3646 RVA: 0x00064B82 File Offset: 0x00062F82
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x1700022A RID: 554
	// (get) Token: 0x06000E3F RID: 3647 RVA: 0x00064B8B File Offset: 0x00062F8B
	// (set) Token: 0x06000E40 RID: 3648 RVA: 0x00064B93 File Offset: 0x00062F93
	[ProtoMember(2)]
	public float BendingStiffness { get; set; }

	// Token: 0x1700022B RID: 555
	// (get) Token: 0x06000E41 RID: 3649 RVA: 0x00064B9C File Offset: 0x00062F9C
	// (set) Token: 0x06000E42 RID: 3650 RVA: 0x00064BA4 File Offset: 0x00062FA4
	[ProtoMember(3)]
	public float StretchingStiffness { get; set; }

	// Token: 0x1700022C RID: 556
	// (get) Token: 0x06000E43 RID: 3651 RVA: 0x00064BAD File Offset: 0x00062FAD
	// (set) Token: 0x06000E44 RID: 3652 RVA: 0x00064BB5 File Offset: 0x00062FB5
	[ProtoMember(4)]
	public float Damping { get; set; }

	// Token: 0x1700022D RID: 557
	// (get) Token: 0x06000E45 RID: 3653 RVA: 0x00064BBE File Offset: 0x00062FBE
	// (set) Token: 0x06000E46 RID: 3654 RVA: 0x00064BC6 File Offset: 0x00062FC6
	[ProtoMember(5)]
	public float Thickness { get; set; }

	// Token: 0x1700022E RID: 558
	// (get) Token: 0x06000E47 RID: 3655 RVA: 0x00064BCF File Offset: 0x00062FCF
	// (set) Token: 0x06000E48 RID: 3656 RVA: 0x00064BD7 File Offset: 0x00062FD7
	[ProtoMember(6)]
	public Vector3Serializer ExternalAcceleration { get; set; }

	// Token: 0x1700022F RID: 559
	// (get) Token: 0x06000E49 RID: 3657 RVA: 0x00064BE0 File Offset: 0x00062FE0
	// (set) Token: 0x06000E4A RID: 3658 RVA: 0x00064BE8 File Offset: 0x00062FE8
	[ProtoMember(7)]
	public Vector3Serializer RandomAcceleration { get; set; }

	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06000E4B RID: 3659 RVA: 0x00064BF1 File Offset: 0x00062FF1
	// (set) Token: 0x06000E4C RID: 3660 RVA: 0x00064BF9 File Offset: 0x00062FF9
	[ProtoMember(8)]
	public bool UseGravity { get; set; }

	// Token: 0x17000231 RID: 561
	// (get) Token: 0x06000E4D RID: 3661 RVA: 0x00064C02 File Offset: 0x00063002
	// (set) Token: 0x06000E4E RID: 3662 RVA: 0x00064C0A File Offset: 0x0006300A
	[ProtoMember(9)]
	public bool SelfCollision { get; set; }

	// Token: 0x17000232 RID: 562
	// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00064C13 File Offset: 0x00063013
	// (set) Token: 0x06000E50 RID: 3664 RVA: 0x00064C1B File Offset: 0x0006301B
	[ProtoMember(10)]
	public ClothSkinningCoefficientSerializer[] Coefficients { get; set; }

	// Token: 0x17000233 RID: 563
	// (get) Token: 0x06000E51 RID: 3665 RVA: 0x00064C24 File Offset: 0x00063024
	// (set) Token: 0x06000E52 RID: 3666 RVA: 0x00064C2C File Offset: 0x0006302C
	[ProtoMember(11)]
	public float WorldVelocityScale { get; set; }

	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06000E53 RID: 3667 RVA: 0x00064C35 File Offset: 0x00063035
	// (set) Token: 0x06000E54 RID: 3668 RVA: 0x00064C3D File Offset: 0x0006303D
	[ProtoMember(12)]
	public float WorldAccelerationScale { get; set; }
}
