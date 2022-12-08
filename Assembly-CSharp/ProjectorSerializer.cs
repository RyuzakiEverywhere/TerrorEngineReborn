using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F3 RID: 499
[ProtoContract]
public sealed class ProjectorSerializer
{
	// Token: 0x06000C5A RID: 3162 RVA: 0x00061D80 File Offset: 0x00060180
	public ProjectorSerializer(GameObject gameObject, ProjectorSerializer component)
	{
		Projector projector = gameObject.GetComponent<Projector>();
		if (projector == null)
		{
			projector = gameObject.AddComponent<Projector>();
		}
		projector.nearClipPlane = component.NearClipPlane;
		projector.farClipPlane = component.FarClipPlane;
		projector.fieldOfView = component.FieldOfView;
		projector.aspectRatio = component.AspectRatio;
		projector.orthographic = component.IsOrthoGraphic;
		projector.orthographic = component.Orthographic;
		projector.orthographicSize = component.OrthographicSize;
		projector.orthographicSize = component.OrthoGraphicSize;
		projector.ignoreLayers = component.IgnoreLayers;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			projector.material = (Material)UniSave.TryLoadResource(component.MaterialName);
		}
		projector.enabled = component.Enabled;
	}

	// Token: 0x06000C5B RID: 3163 RVA: 0x00061E4C File Offset: 0x0006024C
	public ProjectorSerializer(GameObject gameObject)
	{
		Projector component = gameObject.GetComponent<Projector>();
		this.NearClipPlane = component.nearClipPlane;
		this.FarClipPlane = component.farClipPlane;
		this.FieldOfView = component.fieldOfView;
		this.AspectRatio = component.aspectRatio;
		this.IsOrthoGraphic = component.orthographic;
		this.Orthographic = component.orthographic;
		this.OrthographicSize = component.orthographicSize;
		this.OrthoGraphicSize = component.orthographicSize;
		this.IgnoreLayers = component.ignoreLayers;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		this.Enabled = component.enabled;
	}

	// Token: 0x06000C5C RID: 3164 RVA: 0x00061F00 File Offset: 0x00060300
	private ProjectorSerializer()
	{
	}

	// Token: 0x17000159 RID: 345
	// (get) Token: 0x06000C5D RID: 3165 RVA: 0x00061F08 File Offset: 0x00060308
	// (set) Token: 0x06000C5E RID: 3166 RVA: 0x00061F10 File Offset: 0x00060310
	[ProtoMember(1)]
	public float NearClipPlane { get; set; }

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x06000C5F RID: 3167 RVA: 0x00061F19 File Offset: 0x00060319
	// (set) Token: 0x06000C60 RID: 3168 RVA: 0x00061F21 File Offset: 0x00060321
	[ProtoMember(2)]
	public float FarClipPlane { get; set; }

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x06000C61 RID: 3169 RVA: 0x00061F2A File Offset: 0x0006032A
	// (set) Token: 0x06000C62 RID: 3170 RVA: 0x00061F32 File Offset: 0x00060332
	[ProtoMember(3)]
	public float FieldOfView { get; set; }

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x06000C63 RID: 3171 RVA: 0x00061F3B File Offset: 0x0006033B
	// (set) Token: 0x06000C64 RID: 3172 RVA: 0x00061F43 File Offset: 0x00060343
	[ProtoMember(4)]
	public float AspectRatio { get; set; }

	// Token: 0x1700015D RID: 349
	// (get) Token: 0x06000C65 RID: 3173 RVA: 0x00061F4C File Offset: 0x0006034C
	// (set) Token: 0x06000C66 RID: 3174 RVA: 0x00061F54 File Offset: 0x00060354
	[ProtoMember(5)]
	public bool IsOrthoGraphic { get; set; }

	// Token: 0x1700015E RID: 350
	// (get) Token: 0x06000C67 RID: 3175 RVA: 0x00061F5D File Offset: 0x0006035D
	// (set) Token: 0x06000C68 RID: 3176 RVA: 0x00061F65 File Offset: 0x00060365
	[ProtoMember(6)]
	public bool Orthographic { get; set; }

	// Token: 0x1700015F RID: 351
	// (get) Token: 0x06000C69 RID: 3177 RVA: 0x00061F6E File Offset: 0x0006036E
	// (set) Token: 0x06000C6A RID: 3178 RVA: 0x00061F76 File Offset: 0x00060376
	[ProtoMember(7)]
	public float OrthographicSize { get; set; }

	// Token: 0x17000160 RID: 352
	// (get) Token: 0x06000C6B RID: 3179 RVA: 0x00061F7F File Offset: 0x0006037F
	// (set) Token: 0x06000C6C RID: 3180 RVA: 0x00061F87 File Offset: 0x00060387
	[ProtoMember(8)]
	public float OrthoGraphicSize { get; set; }

	// Token: 0x17000161 RID: 353
	// (get) Token: 0x06000C6D RID: 3181 RVA: 0x00061F90 File Offset: 0x00060390
	// (set) Token: 0x06000C6E RID: 3182 RVA: 0x00061F98 File Offset: 0x00060398
	[ProtoMember(9)]
	public int IgnoreLayers { get; set; }

	// Token: 0x17000162 RID: 354
	// (get) Token: 0x06000C6F RID: 3183 RVA: 0x00061FA1 File Offset: 0x000603A1
	// (set) Token: 0x06000C70 RID: 3184 RVA: 0x00061FA9 File Offset: 0x000603A9
	[ProtoMember(10)]
	public string MaterialName { get; set; }

	// Token: 0x17000163 RID: 355
	// (get) Token: 0x06000C71 RID: 3185 RVA: 0x00061FB2 File Offset: 0x000603B2
	// (set) Token: 0x06000C72 RID: 3186 RVA: 0x00061FBA File Offset: 0x000603BA
	[ProtoMember(11)]
	public bool Enabled { get; set; }
}
