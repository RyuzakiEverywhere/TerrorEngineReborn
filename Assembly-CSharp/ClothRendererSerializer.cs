using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001FF RID: 511
[ProtoContract]
public sealed class ClothRendererSerializer
{
	// Token: 0x06000D4E RID: 3406 RVA: 0x000636C4 File Offset: 0x00061AC4
	public ClothRendererSerializer(GameObject gameObject, ClothRendererSerializer component)
	{
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x000636CC File Offset: 0x00061ACC
	public ClothRendererSerializer(GameObject gameObject)
	{
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x000636D4 File Offset: 0x00061AD4
	private ClothRendererSerializer()
	{
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x06000D51 RID: 3409 RVA: 0x000636DC File Offset: 0x00061ADC
	// (set) Token: 0x06000D52 RID: 3410 RVA: 0x000636E4 File Offset: 0x00061AE4
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x06000D53 RID: 3411 RVA: 0x000636ED File Offset: 0x00061AED
	// (set) Token: 0x06000D54 RID: 3412 RVA: 0x000636F5 File Offset: 0x00061AF5
	[ProtoMember(2)]
	public bool CastShadows { get; set; }

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x06000D55 RID: 3413 RVA: 0x000636FE File Offset: 0x00061AFE
	// (set) Token: 0x06000D56 RID: 3414 RVA: 0x00063706 File Offset: 0x00061B06
	[ProtoMember(3)]
	public bool ReceiveShadows { get; set; }

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x06000D57 RID: 3415 RVA: 0x0006370F File Offset: 0x00061B0F
	// (set) Token: 0x06000D58 RID: 3416 RVA: 0x00063717 File Offset: 0x00061B17
	[ProtoMember(4)]
	public string[] MaterialNames { get; set; }

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06000D59 RID: 3417 RVA: 0x00063720 File Offset: 0x00061B20
	// (set) Token: 0x06000D5A RID: 3418 RVA: 0x00063728 File Offset: 0x00061B28
	[ProtoMember(5)]
	public int LightmapIndex { get; set; }

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06000D5B RID: 3419 RVA: 0x00063731 File Offset: 0x00061B31
	// (set) Token: 0x06000D5C RID: 3420 RVA: 0x00063739 File Offset: 0x00061B39
	[ProtoMember(6)]
	public Vector4Serializer LightmapTilingOffset { get; set; }

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x06000D5D RID: 3421 RVA: 0x00063742 File Offset: 0x00061B42
	// (set) Token: 0x06000D5E RID: 3422 RVA: 0x0006374A File Offset: 0x00061B4A
	[ProtoMember(7)]
	public bool UseLightProbes { get; set; }

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x06000D5F RID: 3423 RVA: 0x00063753 File Offset: 0x00061B53
	// (set) Token: 0x06000D60 RID: 3424 RVA: 0x0006375B File Offset: 0x00061B5B
	[ProtoMember(9)]
	public bool PauseWhenNotVisible { get; set; }

	// Token: 0x04000EDF RID: 3807
	[ProtoMember(8)]
	public string LightProbeAnchor;
}
