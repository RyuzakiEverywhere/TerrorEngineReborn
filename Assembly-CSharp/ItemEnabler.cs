using System;
using Photon;
using UnityEngine;

// Token: 0x02000026 RID: 38
public class ItemEnabler : Photon.MonoBehaviour
{
	// Token: 0x060000A1 RID: 161 RVA: 0x0000A787 File Offset: 0x00008B87
	private void Start()
	{
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x0000A789 File Offset: 0x00008B89
	private void Update()
	{
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x0000A78C File Offset: 0x00008B8C
	private void OnTriggerEnter(Collider obj)
	{
		if (obj.transform.tag == "Player")
		{
			if (this.flashlightbool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().flashlightbool = true;
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 1;
			}
			if (this.lanternbool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().lanternbool = true;
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 2;
			}
			if (this.candlebool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().candlebool = true;
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 3;
			}
			if (this.torchbool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().torchbool = true;
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 4;
			}
			if (this.nvcamerabool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().nvcamerabool = true;
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 5;
			}
			if (this.nvgogglesbool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().nvgogglesbool = true;
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 6;
			}
			if (this.ci1bool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().ci1bool = true;
				Transform ci = obj.gameObject.GetComponent<SwitchEquipment>().ci1;
				ci.gameObject.GetComponent<GetItemInfo>().ammo += float.Parse(GameObject.Find("Item_Type1").GetComponent<CustomItemsProperties>().totalammo);
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 7;
			}
			if (this.ci2bool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().ci2bool = true;
				Transform ci2 = obj.gameObject.GetComponent<SwitchEquipment>().ci2;
				ci2.gameObject.GetComponent<GetItemInfo>().ammo += float.Parse(GameObject.Find("Item_Type2").GetComponent<CustomItemsProperties>().totalammo);
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 8;
			}
			if (this.ci3bool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().ci3bool = true;
				Transform ci3 = obj.gameObject.GetComponent<SwitchEquipment>().ci3;
				ci3.gameObject.GetComponent<GetItemInfo>().ammo += float.Parse(GameObject.Find("Item_Type3").GetComponent<CustomItemsProperties>().totalammo);
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 9;
			}
			if (this.ci4bool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().ci4bool = true;
				Transform ci4 = obj.gameObject.GetComponent<SwitchEquipment>().ci4;
				ci4.gameObject.GetComponent<GetItemInfo>().ammo += float.Parse(GameObject.Find("Item_Type4").GetComponent<CustomItemsProperties>().totalammo);
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 10;
			}
			if (this.ci5bool)
			{
				obj.gameObject.GetComponent<SwitchEquipment>().ci5bool = true;
				Transform ci5 = obj.gameObject.GetComponent<SwitchEquipment>().ci5;
				ci5.GetComponent<GetItemInfo>().ammo = float.Parse(GameObject.Find("Item_Type5").GetComponent<CustomItemsProperties>().totalammo);
				obj.gameObject.GetComponent<SwitchEquipment>().curobj = 11;
			}
			if (obj.GetComponent<PhotonView>().isMine)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Pickupitem"), new Vector3(0.03f, 0.97f, 0f), base.transform.rotation) as GameObject;
				if (this.ci1bool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up an item.";
				}
				if (this.ci2bool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up an item.";
				}
				if (this.ci3bool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up an item.";
				}
				if (this.ci4bool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up an item.";
				}
				if (this.ci5bool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up an item.";
				}
				if (this.flashlightbool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up a flashlight.\n-Press 'Q' to toggle light\n-Press 'TAB' to switch equipment";
				}
				if (this.lanternbool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up a lantern.\n-Press 'Q' to toggle light\n-Press 'TAB' to switch equipment";
				}
				if (this.candlebool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up a candle.\n-Press 'Q' to toggle light\n-Press 'TAB' to switch equipment";
				}
				if (this.torchbool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up a torch.";
				}
				if (this.nvcamerabool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up a night-vision camera.\n-Press 'Q' to toggle light\n-Press 'TAB' to switch equipment";
				}
				if (this.nvgogglesbool)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up night-vision goggles.\n-Press 'Q' to toggle night vision\n-Press 'TAB' to switch equipment";
				}
				if (this.key)
				{
					gameObject.GetComponent<GUIText>().text = "Picked up a Key.";
				}
				else
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x040000DC RID: 220
	public bool flashlightbool;

	// Token: 0x040000DD RID: 221
	public bool lanternbool;

	// Token: 0x040000DE RID: 222
	public bool candlebool;

	// Token: 0x040000DF RID: 223
	public bool torchbool;

	// Token: 0x040000E0 RID: 224
	public bool nvcamerabool;

	// Token: 0x040000E1 RID: 225
	public bool nvgogglesbool;

	// Token: 0x040000E2 RID: 226
	public bool ci1bool;

	// Token: 0x040000E3 RID: 227
	public bool ci2bool;

	// Token: 0x040000E4 RID: 228
	public bool ci3bool;

	// Token: 0x040000E5 RID: 229
	public bool ci4bool;

	// Token: 0x040000E6 RID: 230
	public bool ci5bool;

	// Token: 0x040000E7 RID: 231
	public bool healthpack;

	// Token: 0x040000E8 RID: 232
	public bool key;
}
