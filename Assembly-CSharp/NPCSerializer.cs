using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E2 RID: 482
[ProtoContract]
public sealed class NPCSerializer
{
	// Token: 0x06000BB7 RID: 2999 RVA: 0x0005F7DC File Offset: 0x0005DBDC
	public NPCSerializer(GameObject gameObject)
	{
		NPCProperties component = gameObject.GetComponent<NPCProperties>();
		this.attonsight = component.attonsight;
		this.patrol = component.patrol;
		this.followfromdis = component.followfromdis;
		this.mindistance = component.mindistance;
		this.friendly = component.friendly;
		this.npcmodelname = component.npcmodelname;
		this.walkspeed = component.walkspeed;
		this.runspeed = component.runspeed;
		this.attdis = component.attdis;
		this.damage = component.damage;
		this.health = component.health;
		this.detectbydis = component.detectbydis;
		this.detectbyview = component.detectbyview;
		this.detectdis = component.detectdis;
		this.nodename = component.nodename;
		this.walkonchase = component.walkonchase;
		this.runonpatrol = component.runonpatrol;
		this.hasgravity = component.hasgravity;
		this.causestatic = component.causestatic;
		this.runfollow = component.runfollow;
		this.canrespawn = component.canrespawn;
		this.mindistance = component.mindistance;
		this.wander = component.wander;
		this.playdetectsound = component.playdetectsound;
		this.detectsound = component.detectsound;
		this.footstepsound = component.footstepsound;
		this.attacksound = component.attacksound;
		this.static2d = component.static2d;
		this.staticsound = component.staticsound;
		this.viewsound = component.viewsound;
		this.spottedhud = component.spottedhud;
		this.advancedstatic = component.advancedstatic;
		this.closerpercollect = component.closerpercollect;
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x0005F984 File Offset: 0x0005DD84
	public NPCSerializer(GameObject gameObject, NPCSerializer component)
	{
		NPCProperties npcproperties = gameObject.GetComponent<NPCProperties>();
		if (npcproperties == null)
		{
			npcproperties = gameObject.AddComponent<NPCProperties>();
		}
		npcproperties.attonsight = component.attonsight;
		npcproperties.patrol = component.patrol;
		npcproperties.followfromdis = component.followfromdis;
		npcproperties.mindistance = component.mindistance;
		npcproperties.friendly = component.friendly;
		npcproperties.npcmodelname = component.npcmodelname;
		npcproperties.walkspeed = component.walkspeed;
		npcproperties.runspeed = component.runspeed;
		npcproperties.attdis = component.attdis;
		npcproperties.damage = component.damage;
		npcproperties.health = component.health;
		npcproperties.detectbydis = component.detectbydis;
		npcproperties.detectbyview = component.detectbyview;
		npcproperties.detectdis = component.detectdis;
		npcproperties.nodename = component.nodename;
		npcproperties.walkonchase = component.walkonchase;
		npcproperties.runonpatrol = component.runonpatrol;
		npcproperties.hasgravity = component.hasgravity;
		npcproperties.causestatic = component.causestatic;
		npcproperties.runfollow = component.runfollow;
		npcproperties.canrespawn = component.canrespawn;
		npcproperties.mindistance = component.mindistance;
		npcproperties.wander = component.wander;
		npcproperties.playdetectsound = component.playdetectsound;
		npcproperties.detectsound = component.detectsound;
		npcproperties.footstepsound = component.footstepsound;
		npcproperties.attacksound = component.attacksound;
		npcproperties.static2d = component.static2d;
		npcproperties.staticsound = component.staticsound;
		npcproperties.viewsound = component.viewsound;
		npcproperties.spottedhud = component.spottedhud;
		npcproperties.advancedstatic = component.advancedstatic;
		npcproperties.closerpercollect = component.closerpercollect;
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0005FB3D File Offset: 0x0005DF3D
	public NPCSerializer()
	{
	}

	// Token: 0x04000D41 RID: 3393
	[ProtoMember(1)]
	public bool attonsight;

	// Token: 0x04000D42 RID: 3394
	[ProtoMember(2)]
	public bool patrol;

	// Token: 0x04000D43 RID: 3395
	[ProtoMember(3)]
	public bool followfromdis;

	// Token: 0x04000D44 RID: 3396
	[ProtoMember(4)]
	public string mindistance;

	// Token: 0x04000D45 RID: 3397
	[ProtoMember(5)]
	public bool friendly;

	// Token: 0x04000D46 RID: 3398
	[ProtoMember(6)]
	public string npcmodelname;

	// Token: 0x04000D47 RID: 3399
	[ProtoMember(7)]
	public string walkspeed;

	// Token: 0x04000D48 RID: 3400
	[ProtoMember(8)]
	public string runspeed;

	// Token: 0x04000D49 RID: 3401
	[ProtoMember(9)]
	public string attdis;

	// Token: 0x04000D4A RID: 3402
	[ProtoMember(10)]
	public string damage;

	// Token: 0x04000D4B RID: 3403
	[ProtoMember(11)]
	public string health;

	// Token: 0x04000D4C RID: 3404
	[ProtoMember(12)]
	public bool detectbydis;

	// Token: 0x04000D4D RID: 3405
	[ProtoMember(13)]
	public bool detectbyview;

	// Token: 0x04000D4E RID: 3406
	[ProtoMember(14)]
	public string detectdis;

	// Token: 0x04000D4F RID: 3407
	[ProtoMember(15)]
	public string nodename;

	// Token: 0x04000D50 RID: 3408
	[ProtoMember(16)]
	public bool walkonchase;

	// Token: 0x04000D51 RID: 3409
	[ProtoMember(17)]
	public bool runonpatrol;

	// Token: 0x04000D52 RID: 3410
	[ProtoMember(18)]
	public bool hasgravity;

	// Token: 0x04000D53 RID: 3411
	[ProtoMember(19)]
	public bool causestatic;

	// Token: 0x04000D54 RID: 3412
	[ProtoMember(20)]
	public bool runfollow;

	// Token: 0x04000D55 RID: 3413
	[ProtoMember(21)]
	public bool canrespawn;

	// Token: 0x04000D56 RID: 3414
	[ProtoMember(22)]
	public bool wander;

	// Token: 0x04000D57 RID: 3415
	[ProtoMember(23)]
	public bool playdetectsound;

	// Token: 0x04000D58 RID: 3416
	[ProtoMember(24)]
	public string detectsound;

	// Token: 0x04000D59 RID: 3417
	[ProtoMember(25)]
	public string footstepsound;

	// Token: 0x04000D5A RID: 3418
	[ProtoMember(26)]
	public string attacksound;

	// Token: 0x04000D5B RID: 3419
	[ProtoMember(27)]
	public bool static2d;

	// Token: 0x04000D5C RID: 3420
	[ProtoMember(28)]
	public string staticsound;

	// Token: 0x04000D5D RID: 3421
	[ProtoMember(29)]
	public string viewsound;

	// Token: 0x04000D5E RID: 3422
	[ProtoMember(30)]
	public bool spottedhud;

	// Token: 0x04000D5F RID: 3423
	[ProtoMember(31)]
	public bool advancedstatic;

	// Token: 0x04000D60 RID: 3424
	[ProtoMember(32)]
	public bool closerpercollect;
}
