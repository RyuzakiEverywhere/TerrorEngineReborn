using System;
using System.Runtime.InteropServices;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200023C RID: 572
[ProtoContract]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BoundsSerializer
{
	// Token: 0x06001000 RID: 4096 RVA: 0x000675F4 File Offset: 0x000659F4
	public BoundsSerializer(Bounds data)
	{
		this = default(BoundsSerializer);
		this.Center = (Vector3Serializer)data.center;
		this.Size = (Vector3Serializer)data.size;
		this.Extents = (Vector3Serializer)data.extents;
		this.Min = (Vector3Serializer)data.min;
		this.Max = (Vector3Serializer)data.max;
	}

	// Token: 0x170002E0 RID: 736
	// (get) Token: 0x06001001 RID: 4097 RVA: 0x00067662 File Offset: 0x00065A62
	// (set) Token: 0x06001002 RID: 4098 RVA: 0x0006766A File Offset: 0x00065A6A
	[ProtoMember(1)]
	public Vector3Serializer Center { get; set; }

	// Token: 0x170002E1 RID: 737
	// (get) Token: 0x06001003 RID: 4099 RVA: 0x00067673 File Offset: 0x00065A73
	// (set) Token: 0x06001004 RID: 4100 RVA: 0x0006767B File Offset: 0x00065A7B
	[ProtoMember(2)]
	public Vector3Serializer Size { get; set; }

	// Token: 0x170002E2 RID: 738
	// (get) Token: 0x06001005 RID: 4101 RVA: 0x00067684 File Offset: 0x00065A84
	// (set) Token: 0x06001006 RID: 4102 RVA: 0x0006768C File Offset: 0x00065A8C
	[ProtoMember(3)]
	public Vector3Serializer Extents { get; set; }

	// Token: 0x170002E3 RID: 739
	// (get) Token: 0x06001007 RID: 4103 RVA: 0x00067695 File Offset: 0x00065A95
	// (set) Token: 0x06001008 RID: 4104 RVA: 0x0006769D File Offset: 0x00065A9D
	[ProtoMember(4)]
	public Vector3Serializer Min { get; set; }

	// Token: 0x170002E4 RID: 740
	// (get) Token: 0x06001009 RID: 4105 RVA: 0x000676A6 File Offset: 0x00065AA6
	// (set) Token: 0x0600100A RID: 4106 RVA: 0x000676AE File Offset: 0x00065AAE
	[ProtoMember(5)]
	public Vector3Serializer Max { get; set; }

	// Token: 0x0600100B RID: 4107 RVA: 0x000676B8 File Offset: 0x00065AB8
	public static explicit operator Bounds(BoundsSerializer data)
	{
		return new Bounds
		{
			center = (Vector3)data.Center,
			size = (Vector3)data.Size,
			extents = (Vector3)data.Extents,
			min = (Vector3)data.Min,
			max = (Vector3)data.Max
		};
	}

	// Token: 0x0600100C RID: 4108 RVA: 0x0006772F File Offset: 0x00065B2F
	public static explicit operator BoundsSerializer(Bounds data)
	{
		return new BoundsSerializer(data);
	}
}
