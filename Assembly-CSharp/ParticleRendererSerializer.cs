using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001EF RID: 495
[ProtoContract]
public class ParticleRendererSerializer
{
	// Token: 0x06000BF2 RID: 3058 RVA: 0x000614BC File Offset: 0x0005F8BC
	public ParticleRendererSerializer(GameObject gameObject, ParticleRendererSerializer component)
	{
		ParticleRenderer particleRenderer = gameObject.GetComponent<ParticleRenderer>();
		if (particleRenderer == null)
		{
			particleRenderer = gameObject.AddComponent<ParticleRenderer>();
		}
		particleRenderer.enabled = component.Enabled;
		particleRenderer.castShadows = component.CastShadows;
		particleRenderer.receiveShadows = component.ReceiveShadows;
		particleRenderer.materials = (from materialName in component.MaterialNames
		select (Material)UniSave.TryLoadResource(materialName)).ToArray<Material>();
		particleRenderer.lightmapIndex = component.LightmapIndex;
		particleRenderer.lightmapScaleOffset = (Vector4)component.LightmapTilingOffset;
		particleRenderer.useLightProbes = component.UseLightProbes;
		if (!string.IsNullOrEmpty(component.LightProbeAnchorName))
		{
			particleRenderer.probeAnchor.name = component.LightProbeAnchorName;
		}
		particleRenderer.particleRenderMode = (ParticleRenderMode)component.ParticleRenderMode;
		particleRenderer.lengthScale = component.LengthScale;
		particleRenderer.velocityScale = component.VelocityScale;
		particleRenderer.cameraVelocityScale = component.CameraVelocityScale;
		particleRenderer.maxParticleSize = component.MaxParticleSize;
		particleRenderer.uvAnimationXTile = component.UvAnimationXTile;
		particleRenderer.uvAnimationYTile = component.UvAnimationYTile;
		particleRenderer.maxPartileSize = component.MaxPartileSize;
		if (component.UvTiles != null)
		{
			particleRenderer.uvTiles = Array.ConvertAll<RectSerializer, Rect>(component.UvTiles, (RectSerializer element) => (Rect)element);
		}
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x00061624 File Offset: 0x0005FA24
	public ParticleRendererSerializer(GameObject gameObject)
	{
		ParticleRenderer component = gameObject.GetComponent<ParticleRenderer>();
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
		this.ParticleRenderMode = (ParticleRenderModeSerializer)component.particleRenderMode;
		this.LengthScale = component.lengthScale;
		this.VelocityScale = component.velocityScale;
		this.CameraVelocityScale = component.cameraVelocityScale;
		this.MaxParticleSize = component.maxParticleSize;
		this.UvAnimationXTile = component.uvAnimationXTile;
		this.UvAnimationYTile = component.uvAnimationYTile;
		this.MaxPartileSize = component.maxPartileSize;
		if (component.uvTiles != null)
		{
			this.UvTiles = Array.ConvertAll<Rect, RectSerializer>(component.uvTiles, (Rect element) => (RectSerializer)element);
		}
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x00061779 File Offset: 0x0005FB79
	private ParticleRendererSerializer()
	{
	}

	// Token: 0x1700012E RID: 302
	// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x00061781 File Offset: 0x0005FB81
	// (set) Token: 0x06000BF6 RID: 3062 RVA: 0x00061789 File Offset: 0x0005FB89
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x1700012F RID: 303
	// (get) Token: 0x06000BF7 RID: 3063 RVA: 0x00061792 File Offset: 0x0005FB92
	// (set) Token: 0x06000BF8 RID: 3064 RVA: 0x0006179A File Offset: 0x0005FB9A
	[ProtoMember(2)]
	public bool CastShadows { get; set; }

	// Token: 0x17000130 RID: 304
	// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x000617A3 File Offset: 0x0005FBA3
	// (set) Token: 0x06000BFA RID: 3066 RVA: 0x000617AB File Offset: 0x0005FBAB
	[ProtoMember(3)]
	public bool ReceiveShadows { get; set; }

	// Token: 0x17000131 RID: 305
	// (get) Token: 0x06000BFB RID: 3067 RVA: 0x000617B4 File Offset: 0x0005FBB4
	// (set) Token: 0x06000BFC RID: 3068 RVA: 0x000617BC File Offset: 0x0005FBBC
	[ProtoMember(4)]
	public string[] MaterialNames { get; set; }

	// Token: 0x17000132 RID: 306
	// (get) Token: 0x06000BFD RID: 3069 RVA: 0x000617C5 File Offset: 0x0005FBC5
	// (set) Token: 0x06000BFE RID: 3070 RVA: 0x000617CD File Offset: 0x0005FBCD
	[ProtoMember(5)]
	public int LightmapIndex { get; set; }

	// Token: 0x17000133 RID: 307
	// (get) Token: 0x06000BFF RID: 3071 RVA: 0x000617D6 File Offset: 0x0005FBD6
	// (set) Token: 0x06000C00 RID: 3072 RVA: 0x000617DE File Offset: 0x0005FBDE
	[ProtoMember(6)]
	public Vector4Serializer LightmapTilingOffset { get; set; }

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x06000C01 RID: 3073 RVA: 0x000617E7 File Offset: 0x0005FBE7
	// (set) Token: 0x06000C02 RID: 3074 RVA: 0x000617EF File Offset: 0x0005FBEF
	[ProtoMember(7)]
	public bool UseLightProbes { get; set; }

	// Token: 0x17000135 RID: 309
	// (get) Token: 0x06000C03 RID: 3075 RVA: 0x000617F8 File Offset: 0x0005FBF8
	// (set) Token: 0x06000C04 RID: 3076 RVA: 0x00061800 File Offset: 0x0005FC00
	[ProtoMember(8)]
	public string LightProbeAnchorName { get; set; }

	// Token: 0x17000136 RID: 310
	// (get) Token: 0x06000C05 RID: 3077 RVA: 0x00061809 File Offset: 0x0005FC09
	// (set) Token: 0x06000C06 RID: 3078 RVA: 0x00061811 File Offset: 0x0005FC11
	[ProtoMember(9)]
	public ParticleRenderModeSerializer ParticleRenderMode { get; set; }

	// Token: 0x17000137 RID: 311
	// (get) Token: 0x06000C07 RID: 3079 RVA: 0x0006181A File Offset: 0x0005FC1A
	// (set) Token: 0x06000C08 RID: 3080 RVA: 0x00061822 File Offset: 0x0005FC22
	[ProtoMember(10)]
	public float LengthScale { get; set; }

	// Token: 0x17000138 RID: 312
	// (get) Token: 0x06000C09 RID: 3081 RVA: 0x0006182B File Offset: 0x0005FC2B
	// (set) Token: 0x06000C0A RID: 3082 RVA: 0x00061833 File Offset: 0x0005FC33
	[ProtoMember(11)]
	public float VelocityScale { get; set; }

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x06000C0B RID: 3083 RVA: 0x0006183C File Offset: 0x0005FC3C
	// (set) Token: 0x06000C0C RID: 3084 RVA: 0x00061844 File Offset: 0x0005FC44
	[ProtoMember(12)]
	public float CameraVelocityScale { get; set; }

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x06000C0D RID: 3085 RVA: 0x0006184D File Offset: 0x0005FC4D
	// (set) Token: 0x06000C0E RID: 3086 RVA: 0x00061855 File Offset: 0x0005FC55
	[ProtoMember(13)]
	public float MaxParticleSize { get; set; }

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x06000C0F RID: 3087 RVA: 0x0006185E File Offset: 0x0005FC5E
	// (set) Token: 0x06000C10 RID: 3088 RVA: 0x00061866 File Offset: 0x0005FC66
	[ProtoMember(14)]
	public int UvAnimationXTile { get; set; }

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x06000C11 RID: 3089 RVA: 0x0006186F File Offset: 0x0005FC6F
	// (set) Token: 0x06000C12 RID: 3090 RVA: 0x00061877 File Offset: 0x0005FC77
	[ProtoMember(15)]
	public int UvAnimationYTile { get; set; }

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x06000C13 RID: 3091 RVA: 0x00061880 File Offset: 0x0005FC80
	// (set) Token: 0x06000C14 RID: 3092 RVA: 0x00061888 File Offset: 0x0005FC88
	[ProtoMember(16)]
	public float UvAnimationCycles { get; set; }

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x06000C15 RID: 3093 RVA: 0x00061891 File Offset: 0x0005FC91
	// (set) Token: 0x06000C16 RID: 3094 RVA: 0x00061899 File Offset: 0x0005FC99
	[ProtoMember(17)]
	public float MaxPartileSize { get; set; }

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x06000C17 RID: 3095 RVA: 0x000618A2 File Offset: 0x0005FCA2
	// (set) Token: 0x06000C18 RID: 3096 RVA: 0x000618AA File Offset: 0x0005FCAA
	[ProtoMember(18)]
	public RectSerializer[] UvTiles { get; set; }
}
