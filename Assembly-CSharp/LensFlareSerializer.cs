using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F0 RID: 496
[ProtoContract]
public sealed class LensFlareSerializer
{
	// Token: 0x06000C1D RID: 3101 RVA: 0x000618D8 File Offset: 0x0005FCD8
	public LensFlareSerializer(GameObject gameObject, LensFlareSerializer component)
	{
		LensFlare lensFlare = gameObject.GetComponent<LensFlare>();
		if (lensFlare == null)
		{
			lensFlare = gameObject.AddComponent<LensFlare>();
		}
		if (!string.IsNullOrEmpty(component.FlareName))
		{
			lensFlare.flare = (Flare)UniSave.TryLoadResource(component.FlareName);
		}
		lensFlare.brightness = component.Brightness;
		lensFlare.color = (Color)component.Color;
		lensFlare.enabled = component.Enabled;
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x00061954 File Offset: 0x0005FD54
	public LensFlareSerializer(GameObject gameObject)
	{
		LensFlare component = gameObject.GetComponent<LensFlare>();
		if (component.flare != null)
		{
			this.FlareName = component.flare.name;
		}
		this.Brightness = component.brightness;
		this.Color = (ColorSerializer)component.color;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x000619B9 File Offset: 0x0005FDB9
	private LensFlareSerializer()
	{
	}

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x06000C20 RID: 3104 RVA: 0x000619C1 File Offset: 0x0005FDC1
	// (set) Token: 0x06000C21 RID: 3105 RVA: 0x000619C9 File Offset: 0x0005FDC9
	[ProtoMember(1)]
	public string FlareName { get; set; }

	// Token: 0x17000141 RID: 321
	// (get) Token: 0x06000C22 RID: 3106 RVA: 0x000619D2 File Offset: 0x0005FDD2
	// (set) Token: 0x06000C23 RID: 3107 RVA: 0x000619DA File Offset: 0x0005FDDA
	[ProtoMember(2)]
	public float Brightness { get; set; }

	// Token: 0x17000142 RID: 322
	// (get) Token: 0x06000C24 RID: 3108 RVA: 0x000619E3 File Offset: 0x0005FDE3
	// (set) Token: 0x06000C25 RID: 3109 RVA: 0x000619EB File Offset: 0x0005FDEB
	[ProtoMember(3)]
	public ColorSerializer Color { get; set; }

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x06000C26 RID: 3110 RVA: 0x000619F4 File Offset: 0x0005FDF4
	// (set) Token: 0x06000C27 RID: 3111 RVA: 0x000619FC File Offset: 0x0005FDFC
	[ProtoMember(4)]
	public bool Enabled { get; set; }
}
