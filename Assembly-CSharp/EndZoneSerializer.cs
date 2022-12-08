using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D5 RID: 469
[ProtoContract]
public sealed class EndZoneSerializer
{
	// Token: 0x06000B8C RID: 2956 RVA: 0x0005EF78 File Offset: 0x0005D378
	public EndZoneSerializer(GameObject gameObject)
	{
		EndZoneProperties component = gameObject.GetComponent<EndZoneProperties>();
		this.loadstory = component.loadstory;
		this.storyname = component.storyname;
		this.togglevisible = component.togglevisible;
		this.triggerid = component.triggerid;
	}

	// Token: 0x06000B8D RID: 2957 RVA: 0x0005EFC4 File Offset: 0x0005D3C4
	public EndZoneSerializer(GameObject gameObject, EndZoneSerializer component)
	{
		EndZoneProperties endZoneProperties = gameObject.GetComponent<EndZoneProperties>();
		if (endZoneProperties == null)
		{
			endZoneProperties = gameObject.AddComponent<EndZoneProperties>();
		}
		endZoneProperties.loadstory = component.loadstory;
		endZoneProperties.storyname = component.storyname;
		endZoneProperties.togglevisible = component.togglevisible;
		endZoneProperties.triggerid = component.triggerid;
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x0005F021 File Offset: 0x0005D421
	public EndZoneSerializer()
	{
	}

	// Token: 0x04000D15 RID: 3349
	[ProtoMember(1)]
	public bool loadstory;

	// Token: 0x04000D16 RID: 3350
	[ProtoMember(2)]
	public string storyname;

	// Token: 0x04000D17 RID: 3351
	[ProtoMember(3)]
	public bool togglevisible;

	// Token: 0x04000D18 RID: 3352
	[ProtoMember(4)]
	public string triggerid;
}
