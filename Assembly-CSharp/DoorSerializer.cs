using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D2 RID: 466
[ProtoContract]
public sealed class DoorSerializer
{
	// Token: 0x06000B83 RID: 2947 RVA: 0x0005EDBC File Offset: 0x0005D1BC
	public DoorSerializer(GameObject gameObject)
	{
		DoorProperties component = gameObject.GetComponent<DoorProperties>();
		this.togglevisible = component.togglevisible;
		this.triggerid = component.triggerid;
		this.islocked = component.islocked;
		this.keyid = component.keyid;
	}

	// Token: 0x06000B84 RID: 2948 RVA: 0x0005EE08 File Offset: 0x0005D208
	public DoorSerializer(GameObject gameObject, DoorSerializer component)
	{
		DoorProperties doorProperties = gameObject.GetComponent<DoorProperties>();
		if (doorProperties == null)
		{
			doorProperties = gameObject.AddComponent<DoorProperties>();
		}
		doorProperties.togglevisible = component.togglevisible;
		doorProperties.triggerid = component.triggerid;
		doorProperties.islocked = component.islocked;
		doorProperties.keyid = component.keyid;
	}

	// Token: 0x06000B85 RID: 2949 RVA: 0x0005EE65 File Offset: 0x0005D265
	public DoorSerializer()
	{
	}

	// Token: 0x04000D0D RID: 3341
	[ProtoMember(1)]
	public bool togglevisible;

	// Token: 0x04000D0E RID: 3342
	[ProtoMember(2)]
	public string triggerid;

	// Token: 0x04000D0F RID: 3343
	[ProtoMember(3)]
	public bool islocked;

	// Token: 0x04000D10 RID: 3344
	[ProtoMember(4)]
	public int keyid;
}
