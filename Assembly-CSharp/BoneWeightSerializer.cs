using System;
using System.Runtime.InteropServices;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200023B RID: 571
[ProtoContract]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BoneWeightSerializer
{
	// Token: 0x06000FED RID: 4077 RVA: 0x00067460 File Offset: 0x00065860
	public BoneWeightSerializer(BoneWeight data)
	{
		this = default(BoneWeightSerializer);
		this.Weight0 = data.weight0;
		this.Weight1 = data.weight1;
		this.Weight2 = data.weight2;
		this.Weight3 = data.weight3;
		this.BoneIndex0 = data.boneIndex0;
		this.BoneIndex1 = data.boneIndex1;
		this.BoneIndex2 = data.boneIndex2;
		this.BoneIndex3 = data.boneIndex3;
	}

	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000FEE RID: 4078 RVA: 0x000674DC File Offset: 0x000658DC
	// (set) Token: 0x06000FEF RID: 4079 RVA: 0x000674E4 File Offset: 0x000658E4
	[ProtoMember(1)]
	public float Weight0 { get; set; }

	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x000674ED File Offset: 0x000658ED
	// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x000674F5 File Offset: 0x000658F5
	[ProtoMember(2)]
	public float Weight1 { get; set; }

	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x000674FE File Offset: 0x000658FE
	// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x00067506 File Offset: 0x00065906
	[ProtoMember(3)]
	public float Weight2 { get; set; }

	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x0006750F File Offset: 0x0006590F
	// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x00067517 File Offset: 0x00065917
	[ProtoMember(4)]
	public float Weight3 { get; set; }

	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x00067520 File Offset: 0x00065920
	// (set) Token: 0x06000FF7 RID: 4087 RVA: 0x00067528 File Offset: 0x00065928
	[ProtoMember(5)]
	public int BoneIndex0 { get; set; }

	// Token: 0x170002DD RID: 733
	// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x00067531 File Offset: 0x00065931
	// (set) Token: 0x06000FF9 RID: 4089 RVA: 0x00067539 File Offset: 0x00065939
	[ProtoMember(6)]
	public int BoneIndex1 { get; set; }

	// Token: 0x170002DE RID: 734
	// (get) Token: 0x06000FFA RID: 4090 RVA: 0x00067542 File Offset: 0x00065942
	// (set) Token: 0x06000FFB RID: 4091 RVA: 0x0006754A File Offset: 0x0006594A
	[ProtoMember(7)]
	public int BoneIndex2 { get; set; }

	// Token: 0x170002DF RID: 735
	// (get) Token: 0x06000FFC RID: 4092 RVA: 0x00067553 File Offset: 0x00065953
	// (set) Token: 0x06000FFD RID: 4093 RVA: 0x0006755B File Offset: 0x0006595B
	[ProtoMember(8)]
	public int BoneIndex3 { get; set; }

	// Token: 0x06000FFE RID: 4094 RVA: 0x00067564 File Offset: 0x00065964
	public static explicit operator BoneWeight(BoneWeightSerializer data)
	{
		return new BoneWeight
		{
			weight0 = data.Weight0,
			weight1 = data.Weight1,
			weight2 = data.Weight2,
			weight3 = data.Weight3,
			boneIndex0 = data.BoneIndex0,
			boneIndex1 = data.BoneIndex1,
			boneIndex2 = data.BoneIndex2,
			boneIndex3 = data.BoneIndex3
		};
	}

	// Token: 0x06000FFF RID: 4095 RVA: 0x000675EC File Offset: 0x000659EC
	public static explicit operator BoneWeightSerializer(BoneWeight data)
	{
		return new BoneWeightSerializer(data);
	}
}
