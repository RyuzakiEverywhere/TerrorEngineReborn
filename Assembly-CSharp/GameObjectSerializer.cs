using System;
using System.Collections.Generic;
using ProtoBuf;

// Token: 0x0200021B RID: 539
[ProtoContract]
public sealed class GameObjectSerializer
{
	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x06000FAC RID: 4012 RVA: 0x00066E8C File Offset: 0x0006528C
	// (set) Token: 0x06000FAD RID: 4013 RVA: 0x00066E94 File Offset: 0x00065294
	[ProtoMember(1)]
	public string Name { get; set; }

	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x06000FAE RID: 4014 RVA: 0x00066E9D File Offset: 0x0006529D
	// (set) Token: 0x06000FAF RID: 4015 RVA: 0x00066EA5 File Offset: 0x000652A5
	[ProtoMember(2)]
	public HideFlagsSerializer HideFlags { get; set; }

	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x06000FB0 RID: 4016 RVA: 0x00066EAE File Offset: 0x000652AE
	// (set) Token: 0x06000FB1 RID: 4017 RVA: 0x00066EB6 File Offset: 0x000652B6
	[ProtoMember(3)]
	public bool IsStatic { get; set; }

	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x00066EBF File Offset: 0x000652BF
	// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x00066EC7 File Offset: 0x000652C7
	[ProtoMember(4)]
	public int Layer { get; set; }

	// Token: 0x170002C6 RID: 710
	// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x00066ED0 File Offset: 0x000652D0
	// (set) Token: 0x06000FB5 RID: 4021 RVA: 0x00066ED8 File Offset: 0x000652D8
	[ProtoMember(5)]
	public bool Active { get; set; }

	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x06000FB6 RID: 4022 RVA: 0x00066EE1 File Offset: 0x000652E1
	// (set) Token: 0x06000FB7 RID: 4023 RVA: 0x00066EE9 File Offset: 0x000652E9
	[ProtoMember(6)]
	public string Tag { get; set; }

	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x00066EF2 File Offset: 0x000652F2
	// (set) Token: 0x06000FB9 RID: 4025 RVA: 0x00066EFA File Offset: 0x000652FA
	[ProtoMember(10)]
	public Vector3Serializer LocalPosition { get; set; }

	// Token: 0x170002C9 RID: 713
	// (get) Token: 0x06000FBA RID: 4026 RVA: 0x00066F03 File Offset: 0x00065303
	// (set) Token: 0x06000FBB RID: 4027 RVA: 0x00066F0B File Offset: 0x0006530B
	[ProtoMember(11)]
	public Vector3Serializer LocalScale { get; set; }

	// Token: 0x170002CA RID: 714
	// (get) Token: 0x06000FBC RID: 4028 RVA: 0x00066F14 File Offset: 0x00065314
	// (set) Token: 0x06000FBD RID: 4029 RVA: 0x00066F1C File Offset: 0x0006531C
	[ProtoMember(12)]
	public QuaternionSerializer LocalRotation { get; set; }

	// Token: 0x04000FE6 RID: 4070
	[ProtoMember(7)]
	public string UniqueName;

	// Token: 0x04000FE7 RID: 4071
	[ProtoMember(8)]
	public List<object> Components = new List<object>();

	// Token: 0x04000FE8 RID: 4072
	[ProtoMember(9)]
	public List<GameObjectSerializer> Children = new List<GameObjectSerializer>();
}
