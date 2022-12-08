using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F4 RID: 500
[ProtoContract]
public sealed class TrailRendererSerializer
{
	// Token: 0x06000C73 RID: 3187 RVA: 0x00061FC4 File Offset: 0x000603C4
	public TrailRendererSerializer(GameObject gameObject, TrailRendererSerializer component)
	{
		TrailRenderer trailRenderer = gameObject.GetComponent<TrailRenderer>();
		if (trailRenderer == null)
		{
			trailRenderer = gameObject.AddComponent<TrailRenderer>();
		}
		trailRenderer.enabled = component.Enabled;
		trailRenderer.castShadows = component.CastShadows;
		trailRenderer.receiveShadows = component.ReceiveShadows;
		trailRenderer.materials = (from materialName in component.MaterialNames
		select (Material)UniSave.TryLoadResource(materialName)).ToArray<Material>();
		trailRenderer.lightmapIndex = component.LightmapIndex;
		trailRenderer.lightmapScaleOffset = (Vector4)component.LightmapTilingOffset;
		trailRenderer.useLightProbes = component.UseLightProbes;
		if (component.LightProbeAnchor != null)
		{
			trailRenderer.probeAnchor.name = component.LightProbeAnchor;
		}
		trailRenderer.time = component.Time;
		trailRenderer.startWidth = component.StartWidth;
		trailRenderer.endWidth = component.EndWidth;
		trailRenderer.autodestruct = component.Autodestruct;
	}

	// Token: 0x06000C74 RID: 3188 RVA: 0x000620C0 File Offset: 0x000604C0
	public TrailRendererSerializer(GameObject gameObject)
	{
		TrailRenderer component = gameObject.GetComponent<TrailRenderer>();
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
		this.Time = component.time;
		this.StartWidth = component.startWidth;
		this.EndWidth = component.endWidth;
		this.Autodestruct = component.autodestruct;
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x000621AC File Offset: 0x000605AC
	private TrailRendererSerializer()
	{
	}

	// Token: 0x17000164 RID: 356
	// (get) Token: 0x06000C76 RID: 3190 RVA: 0x000621B4 File Offset: 0x000605B4
	// (set) Token: 0x06000C77 RID: 3191 RVA: 0x000621BC File Offset: 0x000605BC
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x17000165 RID: 357
	// (get) Token: 0x06000C78 RID: 3192 RVA: 0x000621C5 File Offset: 0x000605C5
	// (set) Token: 0x06000C79 RID: 3193 RVA: 0x000621CD File Offset: 0x000605CD
	[ProtoMember(2)]
	public bool CastShadows { get; set; }

	// Token: 0x17000166 RID: 358
	// (get) Token: 0x06000C7A RID: 3194 RVA: 0x000621D6 File Offset: 0x000605D6
	// (set) Token: 0x06000C7B RID: 3195 RVA: 0x000621DE File Offset: 0x000605DE
	[ProtoMember(3)]
	public bool ReceiveShadows { get; set; }

	// Token: 0x17000167 RID: 359
	// (get) Token: 0x06000C7C RID: 3196 RVA: 0x000621E7 File Offset: 0x000605E7
	// (set) Token: 0x06000C7D RID: 3197 RVA: 0x000621EF File Offset: 0x000605EF
	[ProtoMember(4)]
	public string[] MaterialNames { get; set; }

	// Token: 0x17000168 RID: 360
	// (get) Token: 0x06000C7E RID: 3198 RVA: 0x000621F8 File Offset: 0x000605F8
	// (set) Token: 0x06000C7F RID: 3199 RVA: 0x00062200 File Offset: 0x00060600
	[ProtoMember(5)]
	public int LightmapIndex { get; set; }

	// Token: 0x17000169 RID: 361
	// (get) Token: 0x06000C80 RID: 3200 RVA: 0x00062209 File Offset: 0x00060609
	// (set) Token: 0x06000C81 RID: 3201 RVA: 0x00062211 File Offset: 0x00060611
	[ProtoMember(6)]
	public Vector4Serializer LightmapTilingOffset { get; set; }

	// Token: 0x1700016A RID: 362
	// (get) Token: 0x06000C82 RID: 3202 RVA: 0x0006221A File Offset: 0x0006061A
	// (set) Token: 0x06000C83 RID: 3203 RVA: 0x00062222 File Offset: 0x00060622
	[ProtoMember(7)]
	public bool UseLightProbes { get; set; }

	// Token: 0x1700016B RID: 363
	// (get) Token: 0x06000C84 RID: 3204 RVA: 0x0006222B File Offset: 0x0006062B
	// (set) Token: 0x06000C85 RID: 3205 RVA: 0x00062233 File Offset: 0x00060633
	[ProtoMember(9)]
	public float Time { get; set; }

	// Token: 0x1700016C RID: 364
	// (get) Token: 0x06000C86 RID: 3206 RVA: 0x0006223C File Offset: 0x0006063C
	// (set) Token: 0x06000C87 RID: 3207 RVA: 0x00062244 File Offset: 0x00060644
	[ProtoMember(10)]
	public float StartWidth { get; set; }

	// Token: 0x1700016D RID: 365
	// (get) Token: 0x06000C88 RID: 3208 RVA: 0x0006224D File Offset: 0x0006064D
	// (set) Token: 0x06000C89 RID: 3209 RVA: 0x00062255 File Offset: 0x00060655
	[ProtoMember(11)]
	public float EndWidth { get; set; }

	// Token: 0x1700016E RID: 366
	// (get) Token: 0x06000C8A RID: 3210 RVA: 0x0006225E File Offset: 0x0006065E
	// (set) Token: 0x06000C8B RID: 3211 RVA: 0x00062266 File Offset: 0x00060666
	[ProtoMember(12)]
	public bool Autodestruct { get; set; }

	// Token: 0x04000E7E RID: 3710
	[ProtoMember(8)]
	public string LightProbeAnchor;
}
