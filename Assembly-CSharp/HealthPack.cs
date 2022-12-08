using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public class HealthPack : MonoBehaviour
{
	// Token: 0x0600034B RID: 843 RVA: 0x0001F63B File Offset: 0x0001DA3B
	private void Start()
	{
	}

	// Token: 0x0600034C RID: 844 RVA: 0x0001F63D File Offset: 0x0001DA3D
	private void Update()
	{
	}

	// Token: 0x0600034D RID: 845 RVA: 0x0001F640 File Offset: 0x0001DA40
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player" && other.gameObject.GetComponent<PhotonView>().isMine)
		{
			other.gameObject.GetComponent<PlayerHealth>().health = 100f;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
