using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E7 RID: 487
[ProtoContract]
public sealed class PosandscaleSerializer
{
	// Token: 0x06000BC6 RID: 3014 RVA: 0x0005FF80 File Offset: 0x0005E380
	public PosandscaleSerializer(GameObject gameObject)
	{
		PositionAndScale component = gameObject.GetComponent<PositionAndScale>();
		this.objecttype = component.objecttype;
		this.wall = component.wall;
		this.model = component.model;
		this.npc = component.npc;
		this.events = component.events;
		this.effect = component.effect;
		this.light = component.light;
		this.door = component.door;
		this.item = component.item;
		this.modobj = component.modobj;
		this.scalex = component.scalex;
		this.scalez = component.scalez;
		this.scaley = component.scaley;
		this.firsttime = component.firsttime;
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x00060044 File Offset: 0x0005E444
	public PosandscaleSerializer(GameObject gameObject, PosandscaleSerializer component)
	{
		PositionAndScale positionAndScale = gameObject.GetComponent<PositionAndScale>();
		if (positionAndScale == null)
		{
			positionAndScale = gameObject.AddComponent<PositionAndScale>();
		}
		positionAndScale.objecttype = component.objecttype;
		positionAndScale.wall = component.wall;
		positionAndScale.model = component.model;
		positionAndScale.npc = component.npc;
		positionAndScale.events = component.events;
		positionAndScale.effect = component.effect;
		positionAndScale.light = component.light;
		positionAndScale.door = component.door;
		positionAndScale.item = component.item;
		positionAndScale.modobj = component.modobj;
		positionAndScale.scalex = component.scalex;
		positionAndScale.scaley = component.scaley;
		positionAndScale.scalez = component.scalez;
		positionAndScale.firsttime = component.firsttime;
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x00060119 File Offset: 0x0005E519
	public PosandscaleSerializer()
	{
	}

	// Token: 0x04000D80 RID: 3456
	[ProtoMember(1)]
	public string objecttype;

	// Token: 0x04000D81 RID: 3457
	[ProtoMember(2)]
	public bool wall;

	// Token: 0x04000D82 RID: 3458
	[ProtoMember(3)]
	public bool model;

	// Token: 0x04000D83 RID: 3459
	[ProtoMember(4)]
	public bool npc;

	// Token: 0x04000D84 RID: 3460
	[ProtoMember(5)]
	public bool events;

	// Token: 0x04000D85 RID: 3461
	[ProtoMember(6)]
	public bool effect;

	// Token: 0x04000D86 RID: 3462
	[ProtoMember(7)]
	public bool light;

	// Token: 0x04000D87 RID: 3463
	[ProtoMember(8)]
	public bool door;

	// Token: 0x04000D88 RID: 3464
	[ProtoMember(9)]
	public bool item;

	// Token: 0x04000D89 RID: 3465
	[ProtoMember(10)]
	public bool modobj;

	// Token: 0x04000D8A RID: 3466
	[ProtoMember(11)]
	public string scalex;

	// Token: 0x04000D8B RID: 3467
	[ProtoMember(12)]
	public string scaley;

	// Token: 0x04000D8C RID: 3468
	[ProtoMember(13)]
	public string scalez;

	// Token: 0x04000D8D RID: 3469
	[ProtoMember(14)]
	public bool firsttime;
}
