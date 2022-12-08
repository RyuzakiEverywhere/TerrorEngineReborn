using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F1 RID: 497
[ProtoContract]
public sealed class LineRendererSerializer
{
	// Token: 0x06000C28 RID: 3112 RVA: 0x00061A08 File Offset: 0x0005FE08
	public LineRendererSerializer(GameObject gameObject, LineRendererSerializer component)
	{
		LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
		if (lineRenderer == null)
		{
			lineRenderer = gameObject.AddComponent<LineRenderer>();
		}
		lineRenderer.enabled = component.Enabled;
		lineRenderer.castShadows = component.CastShadows;
		lineRenderer.receiveShadows = component.ReceiveShadows;
		lineRenderer.materials = (from materialName in component.MaterialNames
		select (Material)UniSave.TryLoadResource(materialName)).ToArray<Material>();
		lineRenderer.lightmapIndex = component.LightmapIndex;
		lineRenderer.lightmapScaleOffset = (Vector4)component.LightmapTilingOffset;
		lineRenderer.useLightProbes = component.UseLightProbes;
		if (component.LightProbeAnchor != null)
		{
			lineRenderer.probeAnchor.name = component.LightProbeAnchor;
		}
		lineRenderer.useWorldSpace = component.UseWorldSpace;
	}

	// Token: 0x06000C29 RID: 3113 RVA: 0x00061AE0 File Offset: 0x0005FEE0
	public LineRendererSerializer(GameObject gameObject)
	{
		LineRenderer component = gameObject.GetComponent<LineRenderer>();
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
			this.LightProbeAnchor = component.probeAnchor.name;
		}
		this.UseWorldSpace = component.useWorldSpace;
	}

	// Token: 0x06000C2A RID: 3114 RVA: 0x00061BA8 File Offset: 0x0005FFA8
	private LineRendererSerializer()
	{
	}

	// Token: 0x17000144 RID: 324
	// (get) Token: 0x06000C2B RID: 3115 RVA: 0x00061BB0 File Offset: 0x0005FFB0
	// (set) Token: 0x06000C2C RID: 3116 RVA: 0x00061BB8 File Offset: 0x0005FFB8
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x17000145 RID: 325
	// (get) Token: 0x06000C2D RID: 3117 RVA: 0x00061BC1 File Offset: 0x0005FFC1
	// (set) Token: 0x06000C2E RID: 3118 RVA: 0x00061BC9 File Offset: 0x0005FFC9
	[ProtoMember(2)]
	public bool CastShadows { get; set; }

	// Token: 0x17000146 RID: 326
	// (get) Token: 0x06000C2F RID: 3119 RVA: 0x00061BD2 File Offset: 0x0005FFD2
	// (set) Token: 0x06000C30 RID: 3120 RVA: 0x00061BDA File Offset: 0x0005FFDA
	[ProtoMember(3)]
	public bool ReceiveShadows { get; set; }

	// Token: 0x17000147 RID: 327
	// (get) Token: 0x06000C31 RID: 3121 RVA: 0x00061BE3 File Offset: 0x0005FFE3
	// (set) Token: 0x06000C32 RID: 3122 RVA: 0x00061BEB File Offset: 0x0005FFEB
	[ProtoMember(4)]
	public string[] MaterialNames { get; set; }

	// Token: 0x17000148 RID: 328
	// (get) Token: 0x06000C33 RID: 3123 RVA: 0x00061BF4 File Offset: 0x0005FFF4
	// (set) Token: 0x06000C34 RID: 3124 RVA: 0x00061BFC File Offset: 0x0005FFFC
	[ProtoMember(5)]
	public int LightmapIndex { get; set; }

	// Token: 0x17000149 RID: 329
	// (get) Token: 0x06000C35 RID: 3125 RVA: 0x00061C05 File Offset: 0x00060005
	// (set) Token: 0x06000C36 RID: 3126 RVA: 0x00061C0D File Offset: 0x0006000D
	[ProtoMember(6)]
	public Vector4Serializer LightmapTilingOffset { get; set; }

	// Token: 0x1700014A RID: 330
	// (get) Token: 0x06000C37 RID: 3127 RVA: 0x00061C16 File Offset: 0x00060016
	// (set) Token: 0x06000C38 RID: 3128 RVA: 0x00061C1E File Offset: 0x0006001E
	[ProtoMember(7)]
	public bool UseLightProbes { get; set; }

	// Token: 0x1700014B RID: 331
	// (get) Token: 0x06000C39 RID: 3129 RVA: 0x00061C27 File Offset: 0x00060027
	// (set) Token: 0x06000C3A RID: 3130 RVA: 0x00061C2F File Offset: 0x0006002F
	[ProtoMember(9)]
	public bool UseWorldSpace { get; set; }

	// Token: 0x04000E5B RID: 3675
	[ProtoMember(8)]
	public string LightProbeAnchor;
}
