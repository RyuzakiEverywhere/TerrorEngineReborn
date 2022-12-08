using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D1 RID: 465
[ProtoContract]
public sealed class CustomItemsSerializer
{
	// Token: 0x06000B80 RID: 2944 RVA: 0x0005EBE8 File Offset: 0x0005CFE8
	public CustomItemsSerializer(GameObject gameObject)
	{
		CustomItemsProperties component = gameObject.GetComponent<CustomItemsProperties>();
		this.modelname = component.modelname;
		this.onehand = component.onehand;
		this.twohand = component.twohand;
		this.twohandweapon = component.twohandweapon;
		this.castlight = component.castlight;
		this.pressftotoggle = component.pressftotoggle;
		this.canmelee = component.canmelee;
		this.togglevisible = component.togglevisible;
		this.canshoot = component.canshoot;
		this.singleshot = component.singleshot;
		this.multishot = component.multishot;
		this.delay = component.delay;
		this.totalammo = component.totalammo;
		this.damage = component.damage;
		this.firesound = component.firesound;
		this.showblood = component.showblood;
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x0005ECC4 File Offset: 0x0005D0C4
	public CustomItemsSerializer(GameObject gameObject, CustomItemsSerializer component)
	{
		CustomItemsProperties customItemsProperties = gameObject.GetComponent<CustomItemsProperties>();
		if (customItemsProperties == null)
		{
			customItemsProperties = gameObject.AddComponent<CustomItemsProperties>();
		}
		customItemsProperties.modelname = component.modelname;
		customItemsProperties.onehand = component.onehand;
		customItemsProperties.twohand = component.twohand;
		customItemsProperties.twohandweapon = component.twohandweapon;
		customItemsProperties.castlight = component.castlight;
		customItemsProperties.pressftotoggle = component.pressftotoggle;
		customItemsProperties.canmelee = component.canmelee;
		customItemsProperties.togglevisible = component.togglevisible;
		customItemsProperties.canshoot = component.canshoot;
		customItemsProperties.singleshot = component.singleshot;
		customItemsProperties.multishot = component.multishot;
		customItemsProperties.delay = component.delay;
		customItemsProperties.totalammo = component.totalammo;
		customItemsProperties.damage = component.damage;
		customItemsProperties.firesound = component.firesound;
		customItemsProperties.showblood = component.showblood;
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x0005EDB1 File Offset: 0x0005D1B1
	public CustomItemsSerializer()
	{
	}

	// Token: 0x04000CFD RID: 3325
	[ProtoMember(1)]
	public string modelname;

	// Token: 0x04000CFE RID: 3326
	[ProtoMember(2)]
	public bool onehand;

	// Token: 0x04000CFF RID: 3327
	[ProtoMember(3)]
	public bool twohand;

	// Token: 0x04000D00 RID: 3328
	[ProtoMember(4)]
	public bool twohandweapon;

	// Token: 0x04000D01 RID: 3329
	[ProtoMember(5)]
	public bool castlight;

	// Token: 0x04000D02 RID: 3330
	[ProtoMember(6)]
	public bool pressftotoggle;

	// Token: 0x04000D03 RID: 3331
	[ProtoMember(7)]
	public bool canmelee;

	// Token: 0x04000D04 RID: 3332
	[ProtoMember(8)]
	public bool togglevisible;

	// Token: 0x04000D05 RID: 3333
	[ProtoMember(9)]
	public bool canshoot;

	// Token: 0x04000D06 RID: 3334
	[ProtoMember(10)]
	public bool singleshot;

	// Token: 0x04000D07 RID: 3335
	[ProtoMember(11)]
	public bool multishot;

	// Token: 0x04000D08 RID: 3336
	[ProtoMember(12)]
	public string delay;

	// Token: 0x04000D09 RID: 3337
	[ProtoMember(13)]
	public string totalammo;

	// Token: 0x04000D0A RID: 3338
	[ProtoMember(14)]
	public string damage;

	// Token: 0x04000D0B RID: 3339
	[ProtoMember(15)]
	public string firesound;

	// Token: 0x04000D0C RID: 3340
	[ProtoMember(16)]
	public bool showblood;
}
