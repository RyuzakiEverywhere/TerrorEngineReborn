using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200021A RID: 538
[ProtoContract]
public sealed class AnimationStateSerializer
{
	// Token: 0x06000F93 RID: 3987 RVA: 0x00066C88 File Offset: 0x00065088
	public AnimationStateSerializer(AnimationState data)
	{
		this.Enabled = data.enabled;
		this.Weight = data.weight;
		this.WrapMode = (WrapModeSerializer)data.wrapMode;
		this.Time = data.time;
		this.NormalizedTime = data.normalizedTime;
		this.Speed = data.speed;
		this.NormalizedSpeed = data.normalizedSpeed;
		this.Layer = data.layer;
		this.Name = data.name;
		this.BlendMode = (AnimationBlendModeSerializer)data.blendMode;
		this.ClipName = data.clip.name;
	}

	// Token: 0x06000F94 RID: 3988 RVA: 0x00066D24 File Offset: 0x00065124
	private AnimationStateSerializer()
	{
	}

	// Token: 0x170002B8 RID: 696
	// (get) Token: 0x06000F95 RID: 3989 RVA: 0x00066D2C File Offset: 0x0006512C
	// (set) Token: 0x06000F96 RID: 3990 RVA: 0x00066D34 File Offset: 0x00065134
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x06000F97 RID: 3991 RVA: 0x00066D3D File Offset: 0x0006513D
	// (set) Token: 0x06000F98 RID: 3992 RVA: 0x00066D45 File Offset: 0x00065145
	[ProtoMember(2)]
	public float Weight { get; set; }

	// Token: 0x170002BA RID: 698
	// (get) Token: 0x06000F99 RID: 3993 RVA: 0x00066D4E File Offset: 0x0006514E
	// (set) Token: 0x06000F9A RID: 3994 RVA: 0x00066D56 File Offset: 0x00065156
	[ProtoMember(3)]
	public WrapModeSerializer WrapMode { get; set; }

	// Token: 0x170002BB RID: 699
	// (get) Token: 0x06000F9B RID: 3995 RVA: 0x00066D5F File Offset: 0x0006515F
	// (set) Token: 0x06000F9C RID: 3996 RVA: 0x00066D67 File Offset: 0x00065167
	[ProtoMember(4)]
	public float Time { get; set; }

	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06000F9D RID: 3997 RVA: 0x00066D70 File Offset: 0x00065170
	// (set) Token: 0x06000F9E RID: 3998 RVA: 0x00066D78 File Offset: 0x00065178
	[ProtoMember(5)]
	public float NormalizedTime { get; set; }

	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06000F9F RID: 3999 RVA: 0x00066D81 File Offset: 0x00065181
	// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x00066D89 File Offset: 0x00065189
	[ProtoMember(6)]
	public float Speed { get; set; }

	// Token: 0x170002BE RID: 702
	// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x00066D92 File Offset: 0x00065192
	// (set) Token: 0x06000FA2 RID: 4002 RVA: 0x00066D9A File Offset: 0x0006519A
	[ProtoMember(7)]
	public float NormalizedSpeed { get; set; }

	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x00066DA3 File Offset: 0x000651A3
	// (set) Token: 0x06000FA4 RID: 4004 RVA: 0x00066DAB File Offset: 0x000651AB
	[ProtoMember(8)]
	public int Layer { get; set; }

	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x06000FA5 RID: 4005 RVA: 0x00066DB4 File Offset: 0x000651B4
	// (set) Token: 0x06000FA6 RID: 4006 RVA: 0x00066DBC File Offset: 0x000651BC
	[ProtoMember(9)]
	public string Name { get; set; }

	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06000FA7 RID: 4007 RVA: 0x00066DC5 File Offset: 0x000651C5
	// (set) Token: 0x06000FA8 RID: 4008 RVA: 0x00066DCD File Offset: 0x000651CD
	[ProtoMember(10)]
	public AnimationBlendModeSerializer BlendMode { get; set; }

	// Token: 0x06000FA9 RID: 4009 RVA: 0x00066DD8 File Offset: 0x000651D8
	public static explicit operator AnimationState(AnimationStateSerializer data)
	{
		return new AnimationState
		{
			enabled = data.Enabled,
			weight = data.Weight,
			wrapMode = (WrapMode)data.WrapMode,
			time = data.Time,
			normalizedTime = data.NormalizedTime,
			speed = data.Speed,
			normalizedSpeed = data.NormalizedSpeed,
			layer = data.Layer,
			name = data.Name,
			blendMode = (AnimationBlendMode)data.BlendMode
		};
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x00066E66 File Offset: 0x00065266
	public static explicit operator AnimationStateSerializer(AnimationState data)
	{
		return new AnimationStateSerializer(data);
	}

	// Token: 0x04000FDF RID: 4063
	[ProtoMember(11)]
	public string ClipName;
}
