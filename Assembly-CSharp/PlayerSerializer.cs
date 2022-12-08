using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E6 RID: 486
[ProtoContract]
public sealed class PlayerSerializer
{
	// Token: 0x06000BC3 RID: 3011 RVA: 0x0005FD94 File Offset: 0x0005E194
	public PlayerSerializer(GameObject gameObject)
	{
		PlayerProperties component = gameObject.GetComponent<PlayerProperties>();
		this.cione = component.cione;
		this.citwo = component.citwo;
		this.cithree = component.cithree;
		this.cifour = component.cifour;
		this.cifive = component.cifive;
		this.torch = component.torch;
		this.candle = component.candle;
		this.lantern = component.lantern;
		this.flametorch = component.flametorch;
		this.nvcamera = component.nvcamera;
		this.nvgoggles = component.nvgoggles;
		this.walkspeed = component.walkspeed;
		this.runspeed = component.runspeed;
		this.jumpheight = component.jumpheight;
		this.canpickup = component.canpickup;
		this.cancrouch = component.cancrouch;
		this.hud = component.hud;
	}

	// Token: 0x06000BC4 RID: 3012 RVA: 0x0005FE7C File Offset: 0x0005E27C
	public PlayerSerializer(GameObject gameObject, PlayerSerializer component)
	{
		PlayerProperties playerProperties = gameObject.GetComponent<PlayerProperties>();
		if (playerProperties == null)
		{
			playerProperties = gameObject.AddComponent<PlayerProperties>();
		}
		playerProperties.cione = component.cione;
		playerProperties.citwo = component.citwo;
		playerProperties.cithree = component.cithree;
		playerProperties.cifour = component.cifour;
		playerProperties.cifive = component.cifive;
		playerProperties.torch = component.torch;
		playerProperties.candle = component.candle;
		playerProperties.lantern = component.lantern;
		playerProperties.flametorch = component.flametorch;
		playerProperties.nvcamera = component.nvcamera;
		playerProperties.nvgoggles = component.nvgoggles;
		playerProperties.walkspeed = component.walkspeed;
		playerProperties.runspeed = component.runspeed;
		playerProperties.jumpheight = component.jumpheight;
		playerProperties.canpickup = component.canpickup;
		playerProperties.cancrouch = component.cancrouch;
		playerProperties.hud = component.hud;
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0005FF75 File Offset: 0x0005E375
	public PlayerSerializer()
	{
	}

	// Token: 0x04000D6F RID: 3439
	[ProtoMember(1)]
	public bool cione;

	// Token: 0x04000D70 RID: 3440
	[ProtoMember(2)]
	public bool citwo;

	// Token: 0x04000D71 RID: 3441
	[ProtoMember(3)]
	public bool cithree;

	// Token: 0x04000D72 RID: 3442
	[ProtoMember(4)]
	public bool cifour;

	// Token: 0x04000D73 RID: 3443
	[ProtoMember(5)]
	public bool cifive;

	// Token: 0x04000D74 RID: 3444
	[ProtoMember(6)]
	public bool torch;

	// Token: 0x04000D75 RID: 3445
	[ProtoMember(7)]
	public bool candle;

	// Token: 0x04000D76 RID: 3446
	[ProtoMember(8)]
	public bool lantern;

	// Token: 0x04000D77 RID: 3447
	[ProtoMember(9)]
	public bool flametorch;

	// Token: 0x04000D78 RID: 3448
	[ProtoMember(10)]
	public bool nvcamera;

	// Token: 0x04000D79 RID: 3449
	[ProtoMember(11)]
	public bool nvgoggles;

	// Token: 0x04000D7A RID: 3450
	[ProtoMember(12)]
	public string walkspeed;

	// Token: 0x04000D7B RID: 3451
	[ProtoMember(13)]
	public string runspeed;

	// Token: 0x04000D7C RID: 3452
	[ProtoMember(14)]
	public string jumpheight;

	// Token: 0x04000D7D RID: 3453
	[ProtoMember(15)]
	public bool canpickup;

	// Token: 0x04000D7E RID: 3454
	[ProtoMember(16)]
	public bool cancrouch;

	// Token: 0x04000D7F RID: 3455
	[ProtoMember(17)]
	public string hud;
}
