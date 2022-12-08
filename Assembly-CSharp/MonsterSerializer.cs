using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E0 RID: 480
[ProtoContract]
public sealed class MonsterSerializer
{
	// Token: 0x06000BB1 RID: 2993 RVA: 0x0005F674 File Offset: 0x0005DA74
	public MonsterSerializer(GameObject gameObject)
	{
		MonsterProperties component = gameObject.GetComponent<MonsterProperties>();
		this.walkspeed = component.walkspeed;
		this.runspeed = component.runspeed;
		this.jumpheight = component.jumpheight;
		this.damage = component.damage;
		this.hud = component.hud;
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x0005F6CC File Offset: 0x0005DACC
	public MonsterSerializer(GameObject gameObject, MonsterSerializer component)
	{
		MonsterProperties monsterProperties = gameObject.GetComponent<MonsterProperties>();
		if (monsterProperties == null)
		{
			monsterProperties = gameObject.AddComponent<MonsterProperties>();
		}
		monsterProperties.walkspeed = component.walkspeed;
		monsterProperties.runspeed = component.runspeed;
		monsterProperties.jumpheight = component.jumpheight;
		monsterProperties.damage = component.damage;
		monsterProperties.hud = component.hud;
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x0005F735 File Offset: 0x0005DB35
	public MonsterSerializer()
	{
	}

	// Token: 0x04000D39 RID: 3385
	[ProtoMember(1)]
	public string walkspeed;

	// Token: 0x04000D3A RID: 3386
	[ProtoMember(2)]
	public string runspeed;

	// Token: 0x04000D3B RID: 3387
	[ProtoMember(3)]
	public string jumpheight;

	// Token: 0x04000D3C RID: 3388
	[ProtoMember(4)]
	public string damage;

	// Token: 0x04000D3D RID: 3389
	[ProtoMember(5)]
	public string hud;
}
