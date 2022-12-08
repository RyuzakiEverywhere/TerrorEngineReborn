using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000217 RID: 535
[ProtoContract]
public sealed class SkinnedMeshRendererSerializer
{
	// Token: 0x06000F3E RID: 3902 RVA: 0x00066418 File Offset: 0x00064818
	public SkinnedMeshRendererSerializer(GameObject gameObject, SkinnedMeshRendererSerializer component)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
		if (skinnedMeshRenderer == null)
		{
			skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
		}
		skinnedMeshRenderer.enabled = component.Enabled;
		skinnedMeshRenderer.castShadows = component.CastShadows;
		skinnedMeshRenderer.receiveShadows = component.ReceiveShadows;
		Material[] array = new Material[component.MaterialNames.Length];
		int num = 0;
		foreach (string resourceName in component.MaterialNames)
		{
			array[num] = (Material)UniSave.TryLoadResource(resourceName);
			num++;
		}
		skinnedMeshRenderer.materials = array;
		skinnedMeshRenderer.lightmapIndex = component.LightmapIndex;
		skinnedMeshRenderer.lightmapScaleOffset = (Vector4)component.LightmapTilingOffset;
		skinnedMeshRenderer.useLightProbes = component.UseLightProbes;
		if (!string.IsNullOrEmpty(component.LightProbeAnchorName))
		{
			skinnedMeshRenderer.probeAnchor.name = component.LightProbeAnchorName;
		}
		skinnedMeshRenderer.quality = (SkinQuality)component.Quality;
		if (component.SharedMesh != null)
		{
			skinnedMeshRenderer.sharedMesh = (Mesh)component.SharedMesh;
			skinnedMeshRenderer.sharedMesh.name = component.SharedMesh.MeshName;
		}
		skinnedMeshRenderer.updateWhenOffscreen = component.UpdateWhenOffscreen;
		skinnedMeshRenderer.localBounds = (Bounds)component.LocalBounds;
	}

	// Token: 0x06000F3F RID: 3903 RVA: 0x00066560 File Offset: 0x00064960
	public SkinnedMeshRendererSerializer(GameObject gameObject)
	{
		SkinnedMeshRenderer component = gameObject.GetComponent<SkinnedMeshRenderer>();
		this.Enabled = component.enabled;
		this.CastShadows = component.castShadows;
		this.ReceiveShadows = component.receiveShadows;
		this.MaterialNames = new string[component.materials.Length];
		int num = 0;
		foreach (Material material in component.materials)
		{
			this.MaterialNames[num] = material.name;
			num++;
		}
		this.LightmapIndex = component.lightmapIndex;
		this.LightmapTilingOffset = (Vector4Serializer)component.lightmapScaleOffset;
		this.UseLightProbes = component.useLightProbes;
		if (component.probeAnchor != null)
		{
			this.LightProbeAnchorName = component.probeAnchor.name;
		}
		this.Quality = (SkinQualitySerializer)component.quality;
		if (component.sharedMesh != null)
		{
			this.SharedMesh = (global::MeshSerializer)component.sharedMesh;
			this.SharedMesh.MeshName = component.sharedMesh.name;
		}
		this.UpdateWhenOffscreen = component.updateWhenOffscreen;
		this.LocalBounds = (BoundsSerializer)component.localBounds;
	}

	// Token: 0x06000F40 RID: 3904 RVA: 0x00066695 File Offset: 0x00064A95
	private SkinnedMeshRendererSerializer()
	{
	}

	// Token: 0x17000292 RID: 658
	// (get) Token: 0x06000F41 RID: 3905 RVA: 0x0006669D File Offset: 0x00064A9D
	// (set) Token: 0x06000F42 RID: 3906 RVA: 0x000666A5 File Offset: 0x00064AA5
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x17000293 RID: 659
	// (get) Token: 0x06000F43 RID: 3907 RVA: 0x000666AE File Offset: 0x00064AAE
	// (set) Token: 0x06000F44 RID: 3908 RVA: 0x000666B6 File Offset: 0x00064AB6
	[ProtoMember(2)]
	public bool CastShadows { get; set; }

	// Token: 0x17000294 RID: 660
	// (get) Token: 0x06000F45 RID: 3909 RVA: 0x000666BF File Offset: 0x00064ABF
	// (set) Token: 0x06000F46 RID: 3910 RVA: 0x000666C7 File Offset: 0x00064AC7
	[ProtoMember(3)]
	public bool ReceiveShadows { get; set; }

	// Token: 0x17000295 RID: 661
	// (get) Token: 0x06000F47 RID: 3911 RVA: 0x000666D0 File Offset: 0x00064AD0
	// (set) Token: 0x06000F48 RID: 3912 RVA: 0x000666D8 File Offset: 0x00064AD8
	[ProtoMember(4)]
	public string[] MaterialNames { get; set; }

	// Token: 0x17000296 RID: 662
	// (get) Token: 0x06000F49 RID: 3913 RVA: 0x000666E1 File Offset: 0x00064AE1
	// (set) Token: 0x06000F4A RID: 3914 RVA: 0x000666E9 File Offset: 0x00064AE9
	[ProtoMember(5)]
	public int LightmapIndex { get; set; }

	// Token: 0x17000297 RID: 663
	// (get) Token: 0x06000F4B RID: 3915 RVA: 0x000666F2 File Offset: 0x00064AF2
	// (set) Token: 0x06000F4C RID: 3916 RVA: 0x000666FA File Offset: 0x00064AFA
	[ProtoMember(6)]
	public Vector4Serializer LightmapTilingOffset { get; set; }

	// Token: 0x17000298 RID: 664
	// (get) Token: 0x06000F4D RID: 3917 RVA: 0x00066703 File Offset: 0x00064B03
	// (set) Token: 0x06000F4E RID: 3918 RVA: 0x0006670B File Offset: 0x00064B0B
	[ProtoMember(7)]
	public bool UseLightProbes { get; set; }

	// Token: 0x17000299 RID: 665
	// (get) Token: 0x06000F4F RID: 3919 RVA: 0x00066714 File Offset: 0x00064B14
	// (set) Token: 0x06000F50 RID: 3920 RVA: 0x0006671C File Offset: 0x00064B1C
	[ProtoMember(8)]
	public string LightProbeAnchorName { get; set; }

	// Token: 0x1700029A RID: 666
	// (get) Token: 0x06000F51 RID: 3921 RVA: 0x00066725 File Offset: 0x00064B25
	// (set) Token: 0x06000F52 RID: 3922 RVA: 0x0006672D File Offset: 0x00064B2D
	[ProtoMember(9)]
	public TransformSerializer[] Bones { get; set; }

	// Token: 0x1700029B RID: 667
	// (get) Token: 0x06000F53 RID: 3923 RVA: 0x00066736 File Offset: 0x00064B36
	// (set) Token: 0x06000F54 RID: 3924 RVA: 0x0006673E File Offset: 0x00064B3E
	[ProtoMember(10)]
	public SkinQualitySerializer Quality { get; set; }

	// Token: 0x1700029C RID: 668
	// (get) Token: 0x06000F55 RID: 3925 RVA: 0x00066747 File Offset: 0x00064B47
	// (set) Token: 0x06000F56 RID: 3926 RVA: 0x0006674F File Offset: 0x00064B4F
	[ProtoMember(11)]
	public global::MeshSerializer SharedMesh { get; set; }

	// Token: 0x1700029D RID: 669
	// (get) Token: 0x06000F57 RID: 3927 RVA: 0x00066758 File Offset: 0x00064B58
	// (set) Token: 0x06000F58 RID: 3928 RVA: 0x00066760 File Offset: 0x00064B60
	[ProtoMember(12)]
	public bool UpdateWhenOffscreen { get; set; }

	// Token: 0x1700029E RID: 670
	// (get) Token: 0x06000F59 RID: 3929 RVA: 0x00066769 File Offset: 0x00064B69
	// (set) Token: 0x06000F5A RID: 3930 RVA: 0x00066771 File Offset: 0x00064B71
	[ProtoMember(13)]
	public BoundsSerializer LocalBounds { get; set; }
}
