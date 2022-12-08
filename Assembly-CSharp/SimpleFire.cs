using System;
using UnityEngine;

// Token: 0x0200008D RID: 141
public class SimpleFire : MonoBehaviour
{
	// Token: 0x06000275 RID: 629 RVA: 0x00017D19 File Offset: 0x00016119
	private void OnTriggerStay(Collider other)
	{
		this.DoDamage(other);
	}

	// Token: 0x06000276 RID: 630 RVA: 0x00017D22 File Offset: 0x00016122
	private void DoDamage(Collider other)
	{
		if (Time.time > this.lastDamageTime + this.damageDelay)
		{
			other.SendMessageUpwards("Damage", this.damage);
			this.lastDamageTime = Time.time;
		}
	}

	// Token: 0x040002FD RID: 765
	[SerializeField]
	private int damage = 10;

	// Token: 0x040002FE RID: 766
	[SerializeField]
	private float damageDelay = 1f;

	// Token: 0x040002FF RID: 767
	private float lastDamageTime;
}
