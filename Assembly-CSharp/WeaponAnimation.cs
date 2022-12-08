using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class WeaponAnimation : MonoBehaviour
{
	// Token: 0x06000173 RID: 371 RVA: 0x00014544 File Offset: 0x00012944
	private void Start()
	{
		if (base.gameObject.name == "ic1")
		{
			this.itemtype = GameObject.Find("Item_Type1").GetComponent<CustomItemsProperties>();
			if (this.itemtype.onehand)
			{
				this.onehand = true;
			}
			if (this.itemtype.twohand)
			{
				this.twohand = true;
			}
			if (this.itemtype.twohandweapon)
			{
				this.twohandweapon = true;
			}
			if (this.itemtype.canmelee)
			{
				this.canmelee = true;
			}
		}
		if (base.gameObject.name == "ic2")
		{
			this.itemtype = GameObject.Find("Item_Type2").GetComponent<CustomItemsProperties>();
			if (this.itemtype.onehand)
			{
				this.onehand = true;
			}
			if (this.itemtype.twohand)
			{
				this.twohand = true;
			}
			if (this.itemtype.twohandweapon)
			{
				this.twohandweapon = true;
			}
			if (this.itemtype.canmelee)
			{
				this.canmelee = true;
			}
		}
		if (base.gameObject.name == "ic3")
		{
			this.itemtype = GameObject.Find("Item_Type3").GetComponent<CustomItemsProperties>();
			if (this.itemtype.onehand)
			{
				this.onehand = true;
			}
			if (this.itemtype.twohand)
			{
				this.twohand = true;
			}
			if (this.itemtype.twohandweapon)
			{
				this.twohandweapon = true;
			}
			if (this.itemtype.canmelee)
			{
				this.canmelee = true;
			}
		}
		if (base.gameObject.name == "ic4")
		{
			this.itemtype = GameObject.Find("Item_Type4").GetComponent<CustomItemsProperties>();
			if (this.itemtype.onehand)
			{
				this.onehand = true;
			}
			if (this.itemtype.twohand)
			{
				this.twohand = true;
			}
			if (this.itemtype.twohandweapon)
			{
				this.twohandweapon = true;
			}
			if (this.itemtype.canmelee)
			{
				this.canmelee = true;
			}
		}
		if (base.gameObject.name == "ic5")
		{
			this.itemtype = GameObject.Find("Item_Type5").GetComponent<CustomItemsProperties>();
			if (this.itemtype.onehand)
			{
				this.onehand = true;
			}
			if (this.itemtype.twohand)
			{
				this.twohand = true;
			}
			if (this.itemtype.twohandweapon)
			{
				this.twohandweapon = true;
			}
			if (this.itemtype.canmelee)
			{
				this.canmelee = true;
			}
		}
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00014808 File Offset: 0x00012C08
	private void Update()
	{
		if (this.onehand)
		{
			this.sa.noitem = false;
			this.sa.onehand = true;
			this.sa.twohand = false;
			this.sa.twohandweapon = false;
		}
		if (this.twohand)
		{
			this.sa.noitem = false;
			this.sa.onehand = false;
			this.sa.twohand = true;
			this.sa.twohandweapon = false;
		}
		if (this.twohandweapon)
		{
			this.sa.noitem = false;
			this.sa.onehand = false;
			this.sa.twohand = false;
			this.sa.twohandweapon = true;
		}
	}

	// Token: 0x0400025C RID: 604
	public bool onehand;

	// Token: 0x0400025D RID: 605
	public bool twohand;

	// Token: 0x0400025E RID: 606
	public bool twohandweapon;

	// Token: 0x0400025F RID: 607
	public bool canmelee;

	// Token: 0x04000260 RID: 608
	public UpdateMyAnimation sa;

	// Token: 0x04000261 RID: 609
	public CustomItemsProperties itemtype;
}
