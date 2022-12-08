using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E5 RID: 485
[ProtoContract]
public sealed class PlayerPrefsSerializer
{
	// Token: 0x06000BC0 RID: 3008 RVA: 0x0005FC80 File Offset: 0x0005E080
	public PlayerPrefsSerializer(GameObject gameObject)
	{
		PlayerPrefsProperties component = gameObject.GetComponent<PlayerPrefsProperties>();
		this.walkspeed = component.walkspeed;
		this.runspeed = component.runspeed;
		this.togglevisible = component.togglevisible;
		this.jumpheight = component.jumpheight;
		this.canpickup = component.canpickup;
		this.cancrouch = component.cancrouch;
		this.hascollider = component.hascollider;
		this.triggerid = component.triggerid;
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x0005FCFC File Offset: 0x0005E0FC
	public PlayerPrefsSerializer(GameObject gameObject, PlayerPrefsSerializer component)
	{
		PlayerPrefsProperties playerPrefsProperties = gameObject.GetComponent<PlayerPrefsProperties>();
		if (playerPrefsProperties == null)
		{
			playerPrefsProperties = gameObject.AddComponent<PlayerPrefsProperties>();
		}
		playerPrefsProperties.walkspeed = component.walkspeed;
		playerPrefsProperties.runspeed = component.runspeed;
		playerPrefsProperties.togglevisible = component.togglevisible;
		playerPrefsProperties.jumpheight = component.jumpheight;
		playerPrefsProperties.canpickup = component.canpickup;
		playerPrefsProperties.cancrouch = component.cancrouch;
		playerPrefsProperties.hascollider = component.hascollider;
		playerPrefsProperties.triggerid = component.triggerid;
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x0005FD89 File Offset: 0x0005E189
	public PlayerPrefsSerializer()
	{
	}

	// Token: 0x04000D67 RID: 3431
	[ProtoMember(1)]
	public string walkspeed;

	// Token: 0x04000D68 RID: 3432
	[ProtoMember(2)]
	public string runspeed;

	// Token: 0x04000D69 RID: 3433
	[ProtoMember(3)]
	public bool togglevisible;

	// Token: 0x04000D6A RID: 3434
	[ProtoMember(4)]
	public string jumpheight;

	// Token: 0x04000D6B RID: 3435
	[ProtoMember(5)]
	public bool canpickup;

	// Token: 0x04000D6C RID: 3436
	[ProtoMember(6)]
	public bool cancrouch;

	// Token: 0x04000D6D RID: 3437
	[ProtoMember(7)]
	public bool hascollider;

	// Token: 0x04000D6E RID: 3438
	[ProtoMember(8)]
	public string triggerid;
}
