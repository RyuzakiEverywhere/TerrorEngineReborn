using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200021C RID: 540
[ProtoContract]
public class MeshSerializer
{
	// Token: 0x06000FBE RID: 4030 RVA: 0x00066F28 File Offset: 0x00065328
	public MeshSerializer(Mesh data)
	{
		this.Vertices = Array.ConvertAll<Vector3, Vector3Serializer>(data.vertices, (Vector3 element) => (Vector3Serializer)element);
		this.Normals = Array.ConvertAll<Vector3, Vector3Serializer>(data.normals, (Vector3 element) => (Vector3Serializer)element);
		this.Tangents = Array.ConvertAll<Vector4, Vector4Serializer>(data.tangents, (Vector4 element) => (Vector4Serializer)element);
		this.Uv = Array.ConvertAll<Vector2, Vector2Serializer>(data.uv, (Vector2 element) => (Vector2Serializer)element);
		this.Uv2 = Array.ConvertAll<Vector2, Vector2Serializer>(data.uv2, (Vector2 element) => (Vector2Serializer)element);
		this.Uv1 = Array.ConvertAll<Vector2, Vector2Serializer>(data.uv2, (Vector2 element) => (Vector2Serializer)element);
		this.Bounds = (BoundsSerializer)data.bounds;
		this.Colors = Array.ConvertAll<Color, ColorSerializer>(data.colors, (Color element) => (ColorSerializer)element);
		this.Triangles = data.triangles;
		this.SubMeshCount = data.subMeshCount;
		this.BoneWeights = Array.ConvertAll<BoneWeight, BoneWeightSerializer>(data.boneWeights, (BoneWeight element) => (BoneWeightSerializer)element);
		this.Bindposes = Array.ConvertAll<Matrix4x4, Matrix4x4Serializer>(data.bindposes, (Matrix4x4 element) => (Matrix4x4Serializer)element);
		this.MeshName = data.name;
	}

	// Token: 0x06000FBF RID: 4031 RVA: 0x0006710E File Offset: 0x0006550E
	private MeshSerializer()
	{
	}

	// Token: 0x170002CB RID: 715
	// (get) Token: 0x06000FC0 RID: 4032 RVA: 0x00067116 File Offset: 0x00065516
	// (set) Token: 0x06000FC1 RID: 4033 RVA: 0x0006711E File Offset: 0x0006551E
	[ProtoMember(1)]
	public Vector3Serializer[] Vertices { get; set; }

	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06000FC2 RID: 4034 RVA: 0x00067127 File Offset: 0x00065527
	// (set) Token: 0x06000FC3 RID: 4035 RVA: 0x0006712F File Offset: 0x0006552F
	[ProtoMember(2)]
	public Vector3Serializer[] Normals { get; set; }

	// Token: 0x170002CD RID: 717
	// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x00067138 File Offset: 0x00065538
	// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x00067140 File Offset: 0x00065540
	[ProtoMember(3)]
	public Vector4Serializer[] Tangents { get; set; }

	// Token: 0x170002CE RID: 718
	// (get) Token: 0x06000FC6 RID: 4038 RVA: 0x00067149 File Offset: 0x00065549
	// (set) Token: 0x06000FC7 RID: 4039 RVA: 0x00067151 File Offset: 0x00065551
	[ProtoMember(4)]
	public Vector2Serializer[] Uv { get; set; }

	// Token: 0x170002CF RID: 719
	// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x0006715A File Offset: 0x0006555A
	// (set) Token: 0x06000FC9 RID: 4041 RVA: 0x00067162 File Offset: 0x00065562
	[ProtoMember(5)]
	public Vector2Serializer[] Uv2 { get; set; }

	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06000FCA RID: 4042 RVA: 0x0006716B File Offset: 0x0006556B
	// (set) Token: 0x06000FCB RID: 4043 RVA: 0x00067173 File Offset: 0x00065573
	[ProtoMember(6)]
	public Vector2Serializer[] Uv1 { get; set; }

	// Token: 0x170002D1 RID: 721
	// (get) Token: 0x06000FCC RID: 4044 RVA: 0x0006717C File Offset: 0x0006557C
	// (set) Token: 0x06000FCD RID: 4045 RVA: 0x00067184 File Offset: 0x00065584
	[ProtoMember(7)]
	public BoundsSerializer Bounds { get; set; }

	// Token: 0x170002D2 RID: 722
	// (get) Token: 0x06000FCE RID: 4046 RVA: 0x0006718D File Offset: 0x0006558D
	// (set) Token: 0x06000FCF RID: 4047 RVA: 0x00067195 File Offset: 0x00065595
	[ProtoMember(8)]
	public ColorSerializer[] Colors { get; set; }

	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x0006719E File Offset: 0x0006559E
	// (set) Token: 0x06000FD1 RID: 4049 RVA: 0x000671A6 File Offset: 0x000655A6
	[ProtoMember(9)]
	public int[] Triangles { get; set; }

	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x000671AF File Offset: 0x000655AF
	// (set) Token: 0x06000FD3 RID: 4051 RVA: 0x000671B7 File Offset: 0x000655B7
	[ProtoMember(10)]
	public int SubMeshCount { get; set; }

	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06000FD4 RID: 4052 RVA: 0x000671C0 File Offset: 0x000655C0
	// (set) Token: 0x06000FD5 RID: 4053 RVA: 0x000671C8 File Offset: 0x000655C8
	[ProtoMember(11)]
	public BoneWeightSerializer[] BoneWeights { get; set; }

	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x000671D1 File Offset: 0x000655D1
	// (set) Token: 0x06000FD7 RID: 4055 RVA: 0x000671D9 File Offset: 0x000655D9
	[ProtoMember(12)]
	public Matrix4x4Serializer[] Bindposes { get; set; }

	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x000671E2 File Offset: 0x000655E2
	// (set) Token: 0x06000FD9 RID: 4057 RVA: 0x000671EA File Offset: 0x000655EA
	[ProtoMember(13)]
	public string MeshName { get; set; }

	// Token: 0x06000FDA RID: 4058 RVA: 0x000671F4 File Offset: 0x000655F4
	public static explicit operator Mesh(global::MeshSerializer data)
	{
		Mesh mesh = new Mesh();
		mesh.vertices = Array.ConvertAll<Vector3Serializer, Vector3>(data.Vertices, (Vector3Serializer element) => (Vector3)element);
		mesh.normals = Array.ConvertAll<Vector3Serializer, Vector3>(data.Normals, (Vector3Serializer element) => (Vector3)element);
		mesh.tangents = Array.ConvertAll<Vector4Serializer, Vector4>(data.Tangents, (Vector4Serializer element) => (Vector4)element);
		mesh.uv = Array.ConvertAll<Vector2Serializer, Vector2>(data.Uv, (Vector2Serializer element) => (Vector2)element);
		mesh.uv2 = Array.ConvertAll<Vector2Serializer, Vector2>(data.Uv2, (Vector2Serializer element) => (Vector2)element);
		mesh.bounds = (Bounds)data.Bounds;
		mesh.triangles = data.Triangles;
		mesh.subMeshCount = data.SubMeshCount;
		mesh.name = data.MeshName;
		Mesh mesh2 = mesh;
		if (data.Colors != null)
		{
			mesh2.colors = Array.ConvertAll<ColorSerializer, Color>(data.Colors, (ColorSerializer element) => (Color)element);
		}
		if (data.BoneWeights != null)
		{
			mesh2.boneWeights = Array.ConvertAll<BoneWeightSerializer, BoneWeight>(data.BoneWeights, (BoneWeightSerializer element) => (BoneWeight)element);
		}
		if (data.Bindposes != null)
		{
			mesh2.bindposes = Array.ConvertAll<Matrix4x4Serializer, Matrix4x4>(data.Bindposes, (Matrix4x4Serializer element) => (Matrix4x4)element);
		}
		return mesh2;
	}

	// Token: 0x06000FDB RID: 4059 RVA: 0x000673D0 File Offset: 0x000657D0
	public static explicit operator global::MeshSerializer(Mesh data)
	{
		return new global::MeshSerializer(data);
	}
}
