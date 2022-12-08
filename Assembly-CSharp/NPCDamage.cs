using System;
using UnityEngine;

// Token: 0x02000030 RID: 48
public class NPCDamage : MonoBehaviour
{
	// Token: 0x060000C9 RID: 201 RVA: 0x0000C83D File Offset: 0x0000AC3D
	private void Start()
	{
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000C83F File Offset: 0x0000AC3F
	private void Update()
	{
		base.transform.Translate(Vector3.forward * Time.deltaTime);
	}

	// Token: 0x060000CB RID: 203 RVA: 0x0000C85C File Offset: 0x0000AC5C
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerHealth>().health -= this.damage;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400011E RID: 286
	public float damage;
}
