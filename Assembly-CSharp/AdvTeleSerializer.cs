using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001CD RID: 461
[ProtoContract]
public sealed class AdvTeleSerializer
{
	// Token: 0x06000B74 RID: 2932 RVA: 0x0005E858 File Offset: 0x0005CC58
	public AdvTeleSerializer(GameObject gameObject)
	{
		AdvTeleportProperties component = gameObject.GetComponent<AdvTeleportProperties>();
		this.triggerid = component.triggerid;
		this.player = component.player;
		this.togglevisible = component.togglevisible;
		this.allplayers = component.allplayers;
		this.npc = component.npc;
		this.objects = component.objects;
		this.x = component.x;
		this.y = component.y;
		this.z = component.z;
		this.xpos = component.xpos;
		this.ypos = component.ypos;
		this.zpos = component.zpos;
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x0005E904 File Offset: 0x0005CD04
	public AdvTeleSerializer(GameObject gameObject, AdvTeleSerializer component)
	{
		AdvTeleportProperties advTeleportProperties = gameObject.GetComponent<AdvTeleportProperties>();
		if (advTeleportProperties == null)
		{
			advTeleportProperties = gameObject.AddComponent<AdvTeleportProperties>();
		}
		advTeleportProperties.triggerid = component.triggerid;
		advTeleportProperties.player = component.player;
		advTeleportProperties.togglevisible = component.togglevisible;
		advTeleportProperties.allplayers = component.allplayers;
		advTeleportProperties.npc = component.npc;
		advTeleportProperties.objects = component.objects;
		advTeleportProperties.x = component.x;
		advTeleportProperties.y = component.y;
		advTeleportProperties.z = component.z;
		advTeleportProperties.xpos = component.xpos;
		advTeleportProperties.ypos = component.ypos;
		advTeleportProperties.zpos = component.zpos;
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x0005E9C1 File Offset: 0x0005CDC1
	public AdvTeleSerializer()
	{
	}

	// Token: 0x04000CE5 RID: 3301
	[ProtoMember(1)]
	public string triggerid;

	// Token: 0x04000CE6 RID: 3302
	[ProtoMember(2)]
	public bool player;

	// Token: 0x04000CE7 RID: 3303
	[ProtoMember(3)]
	public bool togglevisible;

	// Token: 0x04000CE8 RID: 3304
	[ProtoMember(4)]
	public bool allplayers;

	// Token: 0x04000CE9 RID: 3305
	[ProtoMember(5)]
	public bool npc;

	// Token: 0x04000CEA RID: 3306
	[ProtoMember(6)]
	public bool objects;

	// Token: 0x04000CEB RID: 3307
	[ProtoMember(7)]
	public bool x;

	// Token: 0x04000CEC RID: 3308
	[ProtoMember(8)]
	public bool y;

	// Token: 0x04000CED RID: 3309
	[ProtoMember(9)]
	public bool z;

	// Token: 0x04000CEE RID: 3310
	[ProtoMember(10)]
	public string xpos;

	// Token: 0x04000CEF RID: 3311
	[ProtoMember(11)]
	public string ypos;

	// Token: 0x04000CF0 RID: 3312
	[ProtoMember(12)]
	public string zpos;
}
