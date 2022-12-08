using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000218 RID: 536
[ProtoContract]
public sealed class TerrainSerializer
{
	// Token: 0x06000F5B RID: 3931 RVA: 0x0006677C File Offset: 0x00064B7C
	public TerrainSerializer(GameObject gameObject, TerrainSerializer component)
	{
		Terrain terrain = gameObject.GetComponent<Terrain>();
		if (terrain == null)
		{
			terrain = gameObject.AddComponent<Terrain>();
		}
		if (!string.IsNullOrEmpty(component.TerrainDataName))
		{
			terrain.terrainData = (TerrainData)UniSave.TryLoadResource(component.TerrainDataName);
		}
		terrain.enabled = component.Enabled;
		terrain.treeDistance = component.TreeDistance;
		terrain.treeBillboardDistance = component.TreeBillboardDistance;
		terrain.treeCrossFadeLength = component.TreeCrossFadeLength;
		terrain.treeMaximumFullLODCount = component.TreeMaximumFullLODCount;
		terrain.detailObjectDistance = component.DetailObjectDistance;
		terrain.detailObjectDensity = component.DetailObjectDensity;
		terrain.heightmapPixelError = component.HeightmapPixelError;
		terrain.heightmapMaximumLOD = component.HeightmapMaximumLOD;
		terrain.basemapDistance = component.BasemapDistance;
		terrain.lightmapIndex = component.LightmapIndex;
		terrain.castShadows = component.CastShadows;
		terrain.editorRenderFlags = (TerrainRenderFlags)component.EditorRenderFlags;
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x0006686C File Offset: 0x00064C6C
	public TerrainSerializer(GameObject gameObject)
	{
		Terrain component = gameObject.GetComponent<Terrain>();
		if (component.terrainData != null)
		{
			this.TerrainDataName = component.terrainData.name;
		}
		this.Enabled = component.enabled;
		this.TreeDistance = component.treeDistance;
		this.TreeBillboardDistance = component.treeBillboardDistance;
		this.TreeCrossFadeLength = component.treeCrossFadeLength;
		this.TreeMaximumFullLODCount = component.treeMaximumFullLODCount;
		this.DetailObjectDistance = component.detailObjectDistance;
		this.DetailObjectDensity = component.detailObjectDensity;
		this.HeightmapPixelError = component.heightmapPixelError;
		this.HeightmapMaximumLOD = component.heightmapMaximumLOD;
		this.BasemapDistance = component.basemapDistance;
		this.LightmapIndex = component.lightmapIndex;
		this.CastShadows = component.castShadows;
		this.EditorRenderFlags = (TerrainRenderFlagsSerializer)component.editorRenderFlags;
	}

	// Token: 0x06000F5D RID: 3933 RVA: 0x00066944 File Offset: 0x00064D44
	private TerrainSerializer()
	{
	}

	// Token: 0x1700029F RID: 671
	// (get) Token: 0x06000F5E RID: 3934 RVA: 0x0006694C File Offset: 0x00064D4C
	// (set) Token: 0x06000F5F RID: 3935 RVA: 0x00066954 File Offset: 0x00064D54
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x170002A0 RID: 672
	// (get) Token: 0x06000F60 RID: 3936 RVA: 0x0006695D File Offset: 0x00064D5D
	// (set) Token: 0x06000F61 RID: 3937 RVA: 0x00066965 File Offset: 0x00064D65
	[ProtoMember(2)]
	public string TerrainDataName { get; set; }

	// Token: 0x170002A1 RID: 673
	// (get) Token: 0x06000F62 RID: 3938 RVA: 0x0006696E File Offset: 0x00064D6E
	// (set) Token: 0x06000F63 RID: 3939 RVA: 0x00066976 File Offset: 0x00064D76
	[ProtoMember(3)]
	public float TreeDistance { get; set; }

	// Token: 0x170002A2 RID: 674
	// (get) Token: 0x06000F64 RID: 3940 RVA: 0x0006697F File Offset: 0x00064D7F
	// (set) Token: 0x06000F65 RID: 3941 RVA: 0x00066987 File Offset: 0x00064D87
	[ProtoMember(4)]
	public float TreeBillboardDistance { get; set; }

	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x06000F66 RID: 3942 RVA: 0x00066990 File Offset: 0x00064D90
	// (set) Token: 0x06000F67 RID: 3943 RVA: 0x00066998 File Offset: 0x00064D98
	[ProtoMember(5)]
	public float TreeCrossFadeLength { get; set; }

	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x06000F68 RID: 3944 RVA: 0x000669A1 File Offset: 0x00064DA1
	// (set) Token: 0x06000F69 RID: 3945 RVA: 0x000669A9 File Offset: 0x00064DA9
	[ProtoMember(6)]
	public int TreeMaximumFullLODCount { get; set; }

	// Token: 0x170002A5 RID: 677
	// (get) Token: 0x06000F6A RID: 3946 RVA: 0x000669B2 File Offset: 0x00064DB2
	// (set) Token: 0x06000F6B RID: 3947 RVA: 0x000669BA File Offset: 0x00064DBA
	[ProtoMember(7)]
	public float DetailObjectDistance { get; set; }

	// Token: 0x170002A6 RID: 678
	// (get) Token: 0x06000F6C RID: 3948 RVA: 0x000669C3 File Offset: 0x00064DC3
	// (set) Token: 0x06000F6D RID: 3949 RVA: 0x000669CB File Offset: 0x00064DCB
	[ProtoMember(8)]
	public float DetailObjectDensity { get; set; }

	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x06000F6E RID: 3950 RVA: 0x000669D4 File Offset: 0x00064DD4
	// (set) Token: 0x06000F6F RID: 3951 RVA: 0x000669DC File Offset: 0x00064DDC
	[ProtoMember(9)]
	public float HeightmapPixelError { get; set; }

	// Token: 0x170002A8 RID: 680
	// (get) Token: 0x06000F70 RID: 3952 RVA: 0x000669E5 File Offset: 0x00064DE5
	// (set) Token: 0x06000F71 RID: 3953 RVA: 0x000669ED File Offset: 0x00064DED
	[ProtoMember(10)]
	public int HeightmapMaximumLOD { get; set; }

	// Token: 0x170002A9 RID: 681
	// (get) Token: 0x06000F72 RID: 3954 RVA: 0x000669F6 File Offset: 0x00064DF6
	// (set) Token: 0x06000F73 RID: 3955 RVA: 0x000669FE File Offset: 0x00064DFE
	[ProtoMember(11)]
	public float BasemapDistance { get; set; }

	// Token: 0x170002AA RID: 682
	// (get) Token: 0x06000F74 RID: 3956 RVA: 0x00066A07 File Offset: 0x00064E07
	// (set) Token: 0x06000F75 RID: 3957 RVA: 0x00066A0F File Offset: 0x00064E0F
	[ProtoMember(12)]
	public int LightmapIndex { get; set; }

	// Token: 0x170002AB RID: 683
	// (get) Token: 0x06000F76 RID: 3958 RVA: 0x00066A18 File Offset: 0x00064E18
	// (set) Token: 0x06000F77 RID: 3959 RVA: 0x00066A20 File Offset: 0x00064E20
	[ProtoMember(13)]
	public bool CastShadows { get; set; }

	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06000F78 RID: 3960 RVA: 0x00066A29 File Offset: 0x00064E29
	// (set) Token: 0x06000F79 RID: 3961 RVA: 0x00066A31 File Offset: 0x00064E31
	[ProtoMember(14)]
	public TerrainRenderFlagsSerializer EditorRenderFlags { get; set; }
}
