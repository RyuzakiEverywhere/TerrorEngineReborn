using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E1 RID: 481
[ProtoContract]
public sealed class NPCObjSerializer
{
	// Token: 0x06000BB4 RID: 2996 RVA: 0x0005F740 File Offset: 0x0005DB40
	public NPCObjSerializer(GameObject gameObject)
	{
		NPCObjProperties component = gameObject.GetComponent<NPCObjProperties>();
		this.togglevisible = component.togglevisible;
		this.triggerid = component.triggerid;
		this.test = component.test;
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0005F780 File Offset: 0x0005DB80
	public NPCObjSerializer(GameObject gameObject, NPCObjSerializer component)
	{
		NPCObjProperties npcobjProperties = gameObject.GetComponent<NPCObjProperties>();
		if (npcobjProperties == null)
		{
			npcobjProperties = gameObject.AddComponent<NPCObjProperties>();
		}
		npcobjProperties.togglevisible = component.togglevisible;
		npcobjProperties.triggerid = component.triggerid;
		npcobjProperties.test = component.test;
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0005F7D1 File Offset: 0x0005DBD1
	public NPCObjSerializer()
	{
	}

	// Token: 0x04000D3E RID: 3390
	[ProtoMember(1)]
	public bool togglevisible;

	// Token: 0x04000D3F RID: 3391
	[ProtoMember(2)]
	public string triggerid;

	// Token: 0x04000D40 RID: 3392
	[ProtoMember(3)]
	public bool test;
}
