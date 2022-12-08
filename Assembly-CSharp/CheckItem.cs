using System;
using Photon;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class CheckItem : Photon.MonoBehaviour
{
	// Token: 0x06000027 RID: 39 RVA: 0x00004A4D File Offset: 0x00002E4D
	private void Start()
	{
		this.pp = GameObject.FindGameObjectWithTag("StartPoint").GetComponent<PlayerProperties>();
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00004A64 File Offset: 0x00002E64
	private void Update()
	{
		if (base.transform.Find("playermodel(Clone)") != null && base.photonView.isMine)
		{
			if (this.pp.torch)
			{
				base.gameObject.GetComponent<SwitchEquipment>().flashlightbool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 1;
			}
			if (this.pp.candle)
			{
				base.gameObject.GetComponent<SwitchEquipment>().candlebool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 3;
			}
			if (this.pp.lantern)
			{
				base.gameObject.GetComponent<SwitchEquipment>().lanternbool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 2;
			}
			if (this.pp.flametorch)
			{
				base.gameObject.GetComponent<SwitchEquipment>().torchbool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 4;
			}
			if (this.pp.nvcamera)
			{
				base.gameObject.GetComponent<SwitchEquipment>().nvcamerabool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 5;
			}
			if (this.pp.nvgoggles)
			{
				base.gameObject.GetComponent<SwitchEquipment>().nvgogglesbool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 6;
			}
			if (this.pp.cione)
			{
				base.gameObject.GetComponent<SwitchEquipment>().ci1bool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 7;
			}
			if (this.pp.citwo)
			{
				base.gameObject.GetComponent<SwitchEquipment>().ci2bool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 8;
			}
			if (this.pp.cithree)
			{
				base.gameObject.GetComponent<SwitchEquipment>().ci3bool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 9;
			}
			if (this.pp.cifour)
			{
				base.gameObject.GetComponent<SwitchEquipment>().ci4bool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 10;
			}
			if (this.pp.cifive)
			{
				base.gameObject.GetComponent<SwitchEquipment>().ci5bool = true;
				base.gameObject.GetComponent<SwitchEquipment>().curobj = 11;
			}
			base.enabled = false;
		}
	}

	// Token: 0x04000036 RID: 54
	public PlayerProperties pp;
}
