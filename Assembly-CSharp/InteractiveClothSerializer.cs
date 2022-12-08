using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000204 RID: 516
[ProtoContract]
public sealed class InteractiveClothSerializer
{
	// Token: 0x06000DD7 RID: 3543 RVA: 0x000644A8 File Offset: 0x000628A8
	public InteractiveClothSerializer(GameObject gameObject, InteractiveClothSerializer component)
	{
	}

	// Token: 0x06000DD8 RID: 3544 RVA: 0x000644B0 File Offset: 0x000628B0
	public InteractiveClothSerializer(GameObject gameObject)
	{
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x000644B8 File Offset: 0x000628B8
	private InteractiveClothSerializer()
	{
	}

	// Token: 0x170001FC RID: 508
	// (get) Token: 0x06000DDA RID: 3546 RVA: 0x000644C0 File Offset: 0x000628C0
	// (set) Token: 0x06000DDB RID: 3547 RVA: 0x000644C8 File Offset: 0x000628C8
	[ProtoMember(1)]
	public float BendingStiffness { get; set; }

	// Token: 0x170001FD RID: 509
	// (get) Token: 0x06000DDC RID: 3548 RVA: 0x000644D1 File Offset: 0x000628D1
	// (set) Token: 0x06000DDD RID: 3549 RVA: 0x000644D9 File Offset: 0x000628D9
	[ProtoMember(2)]
	public float StretchingStiffness { get; set; }

	// Token: 0x170001FE RID: 510
	// (get) Token: 0x06000DDE RID: 3550 RVA: 0x000644E2 File Offset: 0x000628E2
	// (set) Token: 0x06000DDF RID: 3551 RVA: 0x000644EA File Offset: 0x000628EA
	[ProtoMember(3)]
	public float Damping { get; set; }

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x06000DE0 RID: 3552 RVA: 0x000644F3 File Offset: 0x000628F3
	// (set) Token: 0x06000DE1 RID: 3553 RVA: 0x000644FB File Offset: 0x000628FB
	[ProtoMember(4)]
	public float Thickness { get; set; }

	// Token: 0x17000200 RID: 512
	// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x00064504 File Offset: 0x00062904
	// (set) Token: 0x06000DE3 RID: 3555 RVA: 0x0006450C File Offset: 0x0006290C
	[ProtoMember(5)]
	public Vector3Serializer ExternalAcceleration { get; set; }

	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06000DE4 RID: 3556 RVA: 0x00064515 File Offset: 0x00062915
	// (set) Token: 0x06000DE5 RID: 3557 RVA: 0x0006451D File Offset: 0x0006291D
	[ProtoMember(6)]
	public Vector3Serializer RandomAcceleration { get; set; }

	// Token: 0x17000202 RID: 514
	// (get) Token: 0x06000DE6 RID: 3558 RVA: 0x00064526 File Offset: 0x00062926
	// (set) Token: 0x06000DE7 RID: 3559 RVA: 0x0006452E File Offset: 0x0006292E
	[ProtoMember(7)]
	public bool UseGravity { get; set; }

	// Token: 0x17000203 RID: 515
	// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x00064537 File Offset: 0x00062937
	// (set) Token: 0x06000DE9 RID: 3561 RVA: 0x0006453F File Offset: 0x0006293F
	[ProtoMember(8)]
	public bool SelfCollision { get; set; }

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06000DEA RID: 3562 RVA: 0x00064548 File Offset: 0x00062948
	// (set) Token: 0x06000DEB RID: 3563 RVA: 0x00064550 File Offset: 0x00062950
	[ProtoMember(9)]
	public bool Enabled { get; set; }

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06000DEC RID: 3564 RVA: 0x00064559 File Offset: 0x00062959
	// (set) Token: 0x06000DED RID: 3565 RVA: 0x00064561 File Offset: 0x00062961
	[ProtoMember(11)]
	public global::MeshSerializer Mesh { get; set; }

	// Token: 0x17000206 RID: 518
	// (get) Token: 0x06000DEE RID: 3566 RVA: 0x0006456A File Offset: 0x0006296A
	// (set) Token: 0x06000DEF RID: 3567 RVA: 0x00064572 File Offset: 0x00062972
	[ProtoMember(12)]
	public float Friction { get; set; }

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x0006457B File Offset: 0x0006297B
	// (set) Token: 0x06000DF1 RID: 3569 RVA: 0x00064583 File Offset: 0x00062983
	[ProtoMember(13)]
	public float Density { get; set; }

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06000DF2 RID: 3570 RVA: 0x0006458C File Offset: 0x0006298C
	// (set) Token: 0x06000DF3 RID: 3571 RVA: 0x00064594 File Offset: 0x00062994
	[ProtoMember(14)]
	public float Pressure { get; set; }

	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x0006459D File Offset: 0x0006299D
	// (set) Token: 0x06000DF5 RID: 3573 RVA: 0x000645A5 File Offset: 0x000629A5
	[ProtoMember(15)]
	public float CollisionResponse { get; set; }

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x06000DF6 RID: 3574 RVA: 0x000645AE File Offset: 0x000629AE
	// (set) Token: 0x06000DF7 RID: 3575 RVA: 0x000645B6 File Offset: 0x000629B6
	[ProtoMember(16)]
	public float TearFactor { get; set; }

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06000DF8 RID: 3576 RVA: 0x000645BF File Offset: 0x000629BF
	// (set) Token: 0x06000DF9 RID: 3577 RVA: 0x000645C7 File Offset: 0x000629C7
	[ProtoMember(17)]
	public float AttachmentTearFactor { get; set; }

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06000DFA RID: 3578 RVA: 0x000645D0 File Offset: 0x000629D0
	// (set) Token: 0x06000DFB RID: 3579 RVA: 0x000645D8 File Offset: 0x000629D8
	[ProtoMember(18)]
	public float AttachmentResponse { get; set; }
}
