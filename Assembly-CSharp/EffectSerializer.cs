using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D3 RID: 467
[ProtoContract]
public sealed class EffectSerializer
{
	// Token: 0x06000B86 RID: 2950 RVA: 0x0005EE70 File Offset: 0x0005D270
	public EffectSerializer(GameObject gameObject)
	{
		EffectProperties component = gameObject.GetComponent<EffectProperties>();
		this.togglevisible = component.togglevisible;
		this.triggerdeactivate = component.triggerdeactivate;
		this.triggerid = component.triggerid;
		this.effectobj = component.effectobj;
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x0005EEBC File Offset: 0x0005D2BC
	public EffectSerializer(GameObject gameObject, EffectSerializer component)
	{
		EffectProperties effectProperties = gameObject.GetComponent<EffectProperties>();
		if (effectProperties == null)
		{
			effectProperties = gameObject.AddComponent<EffectProperties>();
		}
		effectProperties.togglevisible = component.togglevisible;
		effectProperties.triggerdeactivate = component.triggerdeactivate;
		effectProperties.triggerid = component.triggerid;
		effectProperties.effectobj = component.effectobj;
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x0005EF19 File Offset: 0x0005D319
	public EffectSerializer()
	{
	}

	// Token: 0x04000D11 RID: 3345
	[ProtoMember(1)]
	public bool togglevisible;

	// Token: 0x04000D12 RID: 3346
	[ProtoMember(2)]
	public bool triggerdeactivate;

	// Token: 0x04000D13 RID: 3347
	[ProtoMember(3)]
	public string triggerid;

	// Token: 0x04000D14 RID: 3348
	[ProtoMember(4)]
	public string effectobj;
}
