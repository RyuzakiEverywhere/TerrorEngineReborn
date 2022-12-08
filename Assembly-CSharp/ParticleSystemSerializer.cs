using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F2 RID: 498
[ProtoContract]
public sealed class ParticleSystemSerializer
{
	// Token: 0x06000C3D RID: 3133 RVA: 0x00061C50 File Offset: 0x00060050
	public ParticleSystemSerializer(GameObject gameObject, ParticleSystemSerializer component)
	{
		ParticleSystem x = gameObject.GetComponent<ParticleSystem>();
		if (x == null)
		{
			x = gameObject.AddComponent<ParticleSystem>();
		}
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x00061C80 File Offset: 0x00060080
	public ParticleSystemSerializer(GameObject gameObject)
	{
		ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x00061C9A File Offset: 0x0006009A
	private ParticleSystemSerializer()
	{
	}

	// Token: 0x1700014C RID: 332
	// (get) Token: 0x06000C40 RID: 3136 RVA: 0x00061CA2 File Offset: 0x000600A2
	// (set) Token: 0x06000C41 RID: 3137 RVA: 0x00061CAA File Offset: 0x000600AA
	[ProtoMember(1)]
	public float StartDelay { get; set; }

	// Token: 0x1700014D RID: 333
	// (get) Token: 0x06000C42 RID: 3138 RVA: 0x00061CB3 File Offset: 0x000600B3
	// (set) Token: 0x06000C43 RID: 3139 RVA: 0x00061CBB File Offset: 0x000600BB
	[ProtoMember(2)]
	public bool Loop { get; set; }

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00061CC4 File Offset: 0x000600C4
	// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00061CCC File Offset: 0x000600CC
	[ProtoMember(3)]
	public bool PlayOnAwake { get; set; }

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x06000C46 RID: 3142 RVA: 0x00061CD5 File Offset: 0x000600D5
	// (set) Token: 0x06000C47 RID: 3143 RVA: 0x00061CDD File Offset: 0x000600DD
	[ProtoMember(4)]
	public float Time { get; set; }

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x06000C48 RID: 3144 RVA: 0x00061CE6 File Offset: 0x000600E6
	// (set) Token: 0x06000C49 RID: 3145 RVA: 0x00061CEE File Offset: 0x000600EE
	[ProtoMember(5)]
	public float PlaybackSpeed { get; set; }

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x06000C4A RID: 3146 RVA: 0x00061CF7 File Offset: 0x000600F7
	// (set) Token: 0x06000C4B RID: 3147 RVA: 0x00061CFF File Offset: 0x000600FF
	[ProtoMember(6)]
	public bool EnableEmission { get; set; }

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x06000C4C RID: 3148 RVA: 0x00061D08 File Offset: 0x00060108
	// (set) Token: 0x06000C4D RID: 3149 RVA: 0x00061D10 File Offset: 0x00060110
	[ProtoMember(7)]
	public float EmissionRate { get; set; }

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x06000C4E RID: 3150 RVA: 0x00061D19 File Offset: 0x00060119
	// (set) Token: 0x06000C4F RID: 3151 RVA: 0x00061D21 File Offset: 0x00060121
	[ProtoMember(8)]
	public float StartSpeed { get; set; }

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x06000C50 RID: 3152 RVA: 0x00061D2A File Offset: 0x0006012A
	// (set) Token: 0x06000C51 RID: 3153 RVA: 0x00061D32 File Offset: 0x00060132
	[ProtoMember(9)]
	public float StartSize { get; set; }

	// Token: 0x17000155 RID: 341
	// (get) Token: 0x06000C52 RID: 3154 RVA: 0x00061D3B File Offset: 0x0006013B
	// (set) Token: 0x06000C53 RID: 3155 RVA: 0x00061D43 File Offset: 0x00060143
	[ProtoMember(10)]
	public ColorSerializer StartColor { get; set; }

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x06000C54 RID: 3156 RVA: 0x00061D4C File Offset: 0x0006014C
	// (set) Token: 0x06000C55 RID: 3157 RVA: 0x00061D54 File Offset: 0x00060154
	[ProtoMember(11)]
	public float StartRotation { get; set; }

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x06000C56 RID: 3158 RVA: 0x00061D5D File Offset: 0x0006015D
	// (set) Token: 0x06000C57 RID: 3159 RVA: 0x00061D65 File Offset: 0x00060165
	[ProtoMember(12)]
	public float StartLifetime { get; set; }

	// Token: 0x17000158 RID: 344
	// (get) Token: 0x06000C58 RID: 3160 RVA: 0x00061D6E File Offset: 0x0006016E
	// (set) Token: 0x06000C59 RID: 3161 RVA: 0x00061D76 File Offset: 0x00060176
	[ProtoMember(13)]
	public float GravityModifier { get; set; }
}
