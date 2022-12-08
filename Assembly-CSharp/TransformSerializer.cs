using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000219 RID: 537
[ProtoContract]
public sealed class TransformSerializer
{
	// Token: 0x06000F7A RID: 3962 RVA: 0x00066A3C File Offset: 0x00064E3C
	public TransformSerializer(GameObject gameObject, TransformSerializer component)
	{
		gameObject.transform.position = (Vector3)component.Position;
		gameObject.transform.localPosition = (Vector3)component.LocalPosition;
		gameObject.transform.eulerAngles = (Vector3)component.EulerAngles;
		gameObject.transform.localEulerAngles = (Vector3)component.LocalEulerAngles;
		gameObject.transform.right = (Vector3)component.Right;
		gameObject.transform.up = (Vector3)component.Up;
		gameObject.transform.forward = (Vector3)component.Forward;
		gameObject.transform.localScale = (Vector3)component.LocalScale;
	}

	// Token: 0x06000F7B RID: 3963 RVA: 0x00066B00 File Offset: 0x00064F00
	public TransformSerializer(GameObject gameObject)
	{
		this.Position = (Vector3Serializer)gameObject.transform.position;
		this.LocalPosition = (Vector3Serializer)gameObject.transform.localPosition;
		this.EulerAngles = (Vector3Serializer)gameObject.transform.eulerAngles;
		this.LocalEulerAngles = (Vector3Serializer)gameObject.transform.localEulerAngles;
		this.Right = (Vector3Serializer)gameObject.transform.right;
		this.Up = (Vector3Serializer)gameObject.transform.up;
		this.Forward = (Vector3Serializer)gameObject.transform.forward;
		this.LocalScale = (Vector3Serializer)gameObject.transform.localScale;
	}

	// Token: 0x06000F7C RID: 3964 RVA: 0x00066BC3 File Offset: 0x00064FC3
	public TransformSerializer()
	{
	}

	// Token: 0x170002AD RID: 685
	// (get) Token: 0x06000F7D RID: 3965 RVA: 0x00066BCB File Offset: 0x00064FCB
	// (set) Token: 0x06000F7E RID: 3966 RVA: 0x00066BD3 File Offset: 0x00064FD3
	[ProtoMember(1)]
	public Vector3Serializer Position { get; set; }

	// Token: 0x170002AE RID: 686
	// (get) Token: 0x06000F7F RID: 3967 RVA: 0x00066BDC File Offset: 0x00064FDC
	// (set) Token: 0x06000F80 RID: 3968 RVA: 0x00066BE4 File Offset: 0x00064FE4
	[ProtoMember(2)]
	public Vector3Serializer LocalPosition { get; set; }

	// Token: 0x170002AF RID: 687
	// (get) Token: 0x06000F81 RID: 3969 RVA: 0x00066BED File Offset: 0x00064FED
	// (set) Token: 0x06000F82 RID: 3970 RVA: 0x00066BF5 File Offset: 0x00064FF5
	[ProtoMember(3)]
	public Vector3Serializer EulerAngles { get; set; }

	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x06000F83 RID: 3971 RVA: 0x00066BFE File Offset: 0x00064FFE
	// (set) Token: 0x06000F84 RID: 3972 RVA: 0x00066C06 File Offset: 0x00065006
	[ProtoMember(4)]
	public Vector3Serializer LocalEulerAngles { get; set; }

	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x06000F85 RID: 3973 RVA: 0x00066C0F File Offset: 0x0006500F
	// (set) Token: 0x06000F86 RID: 3974 RVA: 0x00066C17 File Offset: 0x00065017
	[ProtoMember(5)]
	public Vector3Serializer Right { get; set; }

	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x06000F87 RID: 3975 RVA: 0x00066C20 File Offset: 0x00065020
	// (set) Token: 0x06000F88 RID: 3976 RVA: 0x00066C28 File Offset: 0x00065028
	[ProtoMember(6)]
	public Vector3Serializer Up { get; set; }

	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x06000F89 RID: 3977 RVA: 0x00066C31 File Offset: 0x00065031
	// (set) Token: 0x06000F8A RID: 3978 RVA: 0x00066C39 File Offset: 0x00065039
	[ProtoMember(7)]
	public Vector3Serializer Forward { get; set; }

	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x06000F8B RID: 3979 RVA: 0x00066C42 File Offset: 0x00065042
	// (set) Token: 0x06000F8C RID: 3980 RVA: 0x00066C4A File Offset: 0x0006504A
	[ProtoMember(8)]
	public QuaternionSerializer Rotation { get; set; }

	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x06000F8D RID: 3981 RVA: 0x00066C53 File Offset: 0x00065053
	// (set) Token: 0x06000F8E RID: 3982 RVA: 0x00066C5B File Offset: 0x0006505B
	[ProtoMember(9)]
	public QuaternionSerializer LocalRotation { get; set; }

	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x06000F8F RID: 3983 RVA: 0x00066C64 File Offset: 0x00065064
	// (set) Token: 0x06000F90 RID: 3984 RVA: 0x00066C6C File Offset: 0x0006506C
	[ProtoMember(10)]
	public Vector3Serializer LocalScale { get; set; }

	// Token: 0x170002B7 RID: 695
	// (get) Token: 0x06000F91 RID: 3985 RVA: 0x00066C75 File Offset: 0x00065075
	// (set) Token: 0x06000F92 RID: 3986 RVA: 0x00066C7D File Offset: 0x0006507D
	[ProtoMember(11)]
	public TransformSerializer Parent { get; set; }
}
