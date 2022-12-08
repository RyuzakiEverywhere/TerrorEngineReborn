using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001DD RID: 477
[ProtoContract]
public sealed class ModSerializer
{
	// Token: 0x06000BA8 RID: 2984 RVA: 0x0005F398 File Offset: 0x0005D798
	public ModSerializer(GameObject gameObject)
	{
		ModProperties component = gameObject.GetComponent<ModProperties>();
		this.modname = component.modname;
		this.togglevisible = component.togglevisible;
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x0005F3CC File Offset: 0x0005D7CC
	public ModSerializer(GameObject gameObject, ModSerializer component)
	{
		ModProperties modProperties = gameObject.GetComponent<ModProperties>();
		if (modProperties == null)
		{
			modProperties = gameObject.AddComponent<ModProperties>();
		}
		modProperties.modname = component.modname;
		modProperties.togglevisible = component.togglevisible;
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x0005F411 File Offset: 0x0005D811
	public ModSerializer()
	{
	}

	// Token: 0x04000D25 RID: 3365
	[ProtoMember(1)]
	public string modname;

	// Token: 0x04000D26 RID: 3366
	[ProtoMember(2)]
	public bool togglevisible;
}
