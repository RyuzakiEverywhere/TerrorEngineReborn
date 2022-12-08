using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F6 RID: 502
[ProtoContract]
public sealed class MeshRendererSerializer
{
	// Token: 0x06000C93 RID: 3219 RVA: 0x00062350 File Offset: 0x00060750
	public MeshRendererSerializer(GameObject gameObject, MeshRendererSerializer component)
	{
		MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
		if (meshRenderer == null)
		{
			meshRenderer = gameObject.AddComponent<MeshRenderer>();
		}
		meshRenderer.enabled = component.Enabled;
		meshRenderer.castShadows = component.CastShadows;
		meshRenderer.receiveShadows = component.ReceiveShadows;
		meshRenderer.materials = (from materialName in component.MaterialNames
		select (Material)UniSave.TryLoadResource(materialName)).ToArray<Material>();
		meshRenderer.lightmapIndex = component.LightmapIndex;
		meshRenderer.lightmapScaleOffset = (Vector4)component.LightmapTilingOffset;
		meshRenderer.useLightProbes = component.UseLightProbes;
		if (!string.IsNullOrEmpty(component.LightProbeAnchorName))
		{
			meshRenderer.probeAnchor.name = component.LightProbeAnchorName;
		}
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x00062420 File Offset: 0x00060820
	public MeshRendererSerializer(GameObject gameObject)
	{
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		this.Enabled = component.enabled;
		this.CastShadows = component.castShadows;
		this.ReceiveShadows = component.receiveShadows;
		this.MaterialNames = (from material in component.materials
		select material.name).ToArray<string>();
		this.LightmapIndex = component.lightmapIndex;
		this.LightmapTilingOffset = (Vector4Serializer)component.lightmapScaleOffset;
		this.UseLightProbes = component.useLightProbes;
		if (component.probeAnchor != null)
		{
			this.LightProbeAnchorName = component.probeAnchor.name;
		}
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x000624DC File Offset: 0x000608DC
	private MeshRendererSerializer()
	{
	}

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x06000C96 RID: 3222 RVA: 0x000624E4 File Offset: 0x000608E4
	// (set) Token: 0x06000C97 RID: 3223 RVA: 0x000624EC File Offset: 0x000608EC
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x06000C98 RID: 3224 RVA: 0x000624F5 File Offset: 0x000608F5
	// (set) Token: 0x06000C99 RID: 3225 RVA: 0x000624FD File Offset: 0x000608FD
	[ProtoMember(2)]
	public bool CastShadows { get; set; }

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x06000C9A RID: 3226 RVA: 0x00062506 File Offset: 0x00060906
	// (set) Token: 0x06000C9B RID: 3227 RVA: 0x0006250E File Offset: 0x0006090E
	[ProtoMember(3)]
	public bool ReceiveShadows { get; set; }

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x06000C9C RID: 3228 RVA: 0x00062517 File Offset: 0x00060917
	// (set) Token: 0x06000C9D RID: 3229 RVA: 0x0006251F File Offset: 0x0006091F
	[ProtoMember(7)]
	public string[] MaterialNames { get; set; }

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x06000C9E RID: 3230 RVA: 0x00062528 File Offset: 0x00060928
	// (set) Token: 0x06000C9F RID: 3231 RVA: 0x00062530 File Offset: 0x00060930
	[ProtoMember(8)]
	public int LightmapIndex { get; set; }

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x00062539 File Offset: 0x00060939
	// (set) Token: 0x06000CA1 RID: 3233 RVA: 0x00062541 File Offset: 0x00060941
	[ProtoMember(9)]
	public Vector4Serializer LightmapTilingOffset { get; set; }

	// Token: 0x17000176 RID: 374
	// (get) Token: 0x06000CA2 RID: 3234 RVA: 0x0006254A File Offset: 0x0006094A
	// (set) Token: 0x06000CA3 RID: 3235 RVA: 0x00062552 File Offset: 0x00060952
	[ProtoMember(10)]
	public bool UseLightProbes { get; set; }

	// Token: 0x04000E8D RID: 3725
	[ProtoMember(11)]
	public string LightProbeAnchorName;
}
