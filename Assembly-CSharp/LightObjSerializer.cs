using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D9 RID: 473
[ProtoContract]
public sealed class LightObjSerializer
{
	// Token: 0x06000B9C RID: 2972 RVA: 0x0005F158 File Offset: 0x0005D558
	public LightObjSerializer(GameObject gameObject)
	{
		LightProperties component = gameObject.GetComponent<LightProperties>();
		this.toggleshadow = component.toggleshadow;
		this.toggleflicker = component.toggleflicker;
		this.togglevisible = component.togglevisible;
		this.noflare = component.noflare;
		this.mmflare = component.mmflare;
		this.streetlight = component.streetlight;
		this.smallflare = component.smallflare;
		this.sun = component.sun;
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x0005F1D4 File Offset: 0x0005D5D4
	public LightObjSerializer(GameObject gameObject, LightObjSerializer component)
	{
		LightProperties lightProperties = gameObject.GetComponent<LightProperties>();
		if (lightProperties == null)
		{
			lightProperties = gameObject.AddComponent<LightProperties>();
		}
		lightProperties.toggleshadow = component.toggleshadow;
		lightProperties.toggleflicker = component.toggleflicker;
		lightProperties.togglevisible = component.togglevisible;
		lightProperties.noflare = component.noflare;
		lightProperties.mmflare = component.mmflare;
		lightProperties.streetlight = component.streetlight;
		lightProperties.smallflare = component.smallflare;
		lightProperties.sun = component.sun;
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x0005F261 File Offset: 0x0005D661
	public LightObjSerializer()
	{
	}

	// Token: 0x04000D1B RID: 3355
	[ProtoMember(1)]
	public bool toggleshadow;

	// Token: 0x04000D1C RID: 3356
	[ProtoMember(2)]
	public bool toggleflicker;

	// Token: 0x04000D1D RID: 3357
	[ProtoMember(3)]
	public bool togglevisible;

	// Token: 0x04000D1E RID: 3358
	[ProtoMember(4)]
	public bool noflare;

	// Token: 0x04000D1F RID: 3359
	[ProtoMember(5)]
	public bool mmflare;

	// Token: 0x04000D20 RID: 3360
	[ProtoMember(6)]
	public bool streetlight;

	// Token: 0x04000D21 RID: 3361
	[ProtoMember(7)]
	public bool smallflare;

	// Token: 0x04000D22 RID: 3362
	[ProtoMember(8)]
	public bool sun;
}
