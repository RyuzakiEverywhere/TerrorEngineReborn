using System;
using Photon;
using UnityEngine;

// Token: 0x0200003A RID: 58
public class PlayerHealth : Photon.MonoBehaviour
{
	// Token: 0x06000101 RID: 257 RVA: 0x0000F395 File Offset: 0x0000D795
	private void Start()
	{
		this.health = this.maxhealth;
		if (base.photonView.isMine)
		{
			GameObject.Find("PlayerHUD").GetComponent<GUITexture>().enabled = true;
		}
	}

	// Token: 0x06000102 RID: 258 RVA: 0x0000F3C8 File Offset: 0x0000D7C8
	private void Update()
	{
		if (base.photonView.isMine)
		{
			this.health += this.recoverSpeed * Time.deltaTime;
			if (this.health > this.maxhealth)
			{
				this.health = this.maxhealth;
			}
			BleedBehavior.minBloodAmount = this.maxBloodIndication * (this.maxhealth - this.health) / this.maxhealth;
			if (this.health <= 0f && base.photonView.isMine)
			{
				base.gameObject.GetComponent<Death>().isdead = true;
				base.gameObject.GetComponent<Death>().movecam = true;
				base.gameObject.GetComponent<Death>().enabled = true;
				base.enabled = false;
			}
		}
	}

	// Token: 0x06000103 RID: 259 RVA: 0x0000F498 File Offset: 0x0000D898
	public void Damage(int amount)
	{
		BleedBehavior.BloodAmount += Mathf.Clamp01(this.damageBloodAmount * (float)amount / this.health);
		this.health -= (float)amount;
		if (this.health <= 0f)
		{
			this.health = this.maxhealth;
			Debug.Log("Player died, resetting health");
		}
		BleedBehavior.minBloodAmount = this.maxBloodIndication * (this.maxhealth - this.health) / this.maxhealth;
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0000F51A File Offset: 0x0000D91A
	private void OnGUI()
	{
	}

	// Token: 0x0400018C RID: 396
	[SerializeField]
	public float maxhealth = 100f;

	// Token: 0x0400018D RID: 397
	public float health = 100f;

	// Token: 0x0400018E RID: 398
	[SerializeField]
	private float damageBloodAmount = 3f;

	// Token: 0x0400018F RID: 399
	[SerializeField]
	private float maxBloodIndication = 0.5f;

	// Token: 0x04000190 RID: 400
	[SerializeField]
	private float recoverSpeed = 1f;
}
