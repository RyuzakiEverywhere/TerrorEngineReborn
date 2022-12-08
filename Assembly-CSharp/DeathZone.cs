using System;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class DeathZone : MonoBehaviour
{
	// Token: 0x06000060 RID: 96 RVA: 0x000083FF File Offset: 0x000067FF
	private void Start()
	{
		if (base.gameObject.GetComponent<BoxCollider>() != null)
		{
			base.gameObject.GetComponent<BoxCollider>().isTrigger = true;
		}
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00008428 File Offset: 0x00006828
	private void Update()
	{
	}

	// Token: 0x06000062 RID: 98 RVA: 0x0000842C File Offset: 0x0000682C
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player" && other.gameObject.GetComponent<PhotonView>().isMine)
		{
			other.gameObject.GetComponent<PlayerHealth>().health = -1f;
		}
		if (other.transform.tag == "NPC")
		{
			other.gameObject.GetComponent<NpcSync>().curhealth = -1f;
		}
		if (other.transform.tag == "PNPC" && other.gameObject.GetComponent<PhotonView>().isMine)
		{
			other.gameObject.GetComponent<PNPCMechanics>().health = -1f;
		}
	}
}
