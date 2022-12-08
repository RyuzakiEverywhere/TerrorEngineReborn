using System;
using UnityEngine;

// Token: 0x0200008E RID: 142
public class SimplePlayer : MonoBehaviour
{
	// Token: 0x06000278 RID: 632 RVA: 0x00017D9B File Offset: 0x0001619B
	private void Start()
	{
		this.health = this.maxhealth;
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00017DAC File Offset: 0x000161AC
	private void Update()
	{
		this.health += this.recoverSpeed * Time.deltaTime;
		if (this.health > this.maxhealth)
		{
			this.health = this.maxhealth;
		}
		BleedBehavior.minBloodAmount = this.maxBloodIndication * (this.maxhealth - this.health) / this.maxhealth;
	}

	// Token: 0x0600027A RID: 634 RVA: 0x00017E10 File Offset: 0x00016210
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

	// Token: 0x0600027B RID: 635 RVA: 0x00017E92 File Offset: 0x00016292
	private void OnGUI()
	{
		GUI.Label(new Rect(50f, 50f, 100f, 20f), "health: " + Mathf.FloorToInt(this.health));
	}

	// Token: 0x04000300 RID: 768
	[SerializeField]
	private float maxhealth = 100f;

	// Token: 0x04000301 RID: 769
	private float health = 100f;

	// Token: 0x04000302 RID: 770
	[SerializeField]
	private float damageBloodAmount = 3f;

	// Token: 0x04000303 RID: 771
	[SerializeField]
	private float maxBloodIndication = 0.5f;

	// Token: 0x04000304 RID: 772
	[SerializeField]
	private float recoverSpeed = 1f;
}
