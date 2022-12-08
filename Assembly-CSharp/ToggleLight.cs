using System;
using Photon;
using UnityEngine;

// Token: 0x02000045 RID: 69
public class ToggleLight : Photon.MonoBehaviour
{
	// Token: 0x06000153 RID: 339 RVA: 0x00012C57 File Offset: 0x00011057
	private void Start()
	{
	}

	// Token: 0x06000154 RID: 340 RVA: 0x00012C5C File Offset: 0x0001105C
	private void Update()
	{
		if (base.photonView.isMine && Input.GetKeyDown(KeyCode.Q) && !this.outofpower)
		{
			if (!this.isnvgoggles)
			{
				base.photonView.RPC("SwitchLight", PhotonTargets.All, new object[0]);
			}
			else
			{
				base.GetComponent<Light>().enabled = !base.GetComponent<Light>().enabled;
			}
		}
		if (this.outofpower)
		{
			this.DisableLight();
		}
	}

	// Token: 0x06000155 RID: 341 RVA: 0x00012CE1 File Offset: 0x000110E1
	private void DisableLight()
	{
		if (!this.iscustomitem)
		{
			this.lightobj.gameObject.SetActive(false);
		}
		else
		{
			base.GetComponent<Light>().enabled = false;
		}
	}

	// Token: 0x06000156 RID: 342 RVA: 0x00012D10 File Offset: 0x00011110
	private void RemovePower()
	{
		base.photonView.RPC("TOffP", PhotonTargets.All, new object[0]);
	}

	// Token: 0x06000157 RID: 343 RVA: 0x00012D2C File Offset: 0x0001112C
	public void EnableLight()
	{
		base.photonView.RPC("TOnP", PhotonTargets.All, new object[0]);
		if (!this.iscustomitem)
		{
			this.lightobj.gameObject.SetActive(true);
		}
		else
		{
			base.GetComponent<Light>().enabled = true;
		}
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00012D7D File Offset: 0x0001117D
	[RPC]
	private void TOffP()
	{
		this.outofpower = true;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00012D86 File Offset: 0x00011186
	[RPC]
	private void TOnP()
	{
		this.outofpower = false;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x00012D90 File Offset: 0x00011190
	[RPC]
	private void SwitchLight()
	{
		if (!this.iscustomitem)
		{
			this.lightobj.gameObject.SetActive(!this.lightobj.gameObject.activeSelf);
		}
		else
		{
			base.GetComponent<Light>().enabled = !base.GetComponent<Light>().enabled;
		}
	}

	// Token: 0x04000219 RID: 537
	public bool isnvgoggles;

	// Token: 0x0400021A RID: 538
	public bool iscustomitem;

	// Token: 0x0400021B RID: 539
	public bool toggled;

	// Token: 0x0400021C RID: 540
	public Transform lightobj;

	// Token: 0x0400021D RID: 541
	public bool outofpower;
}
