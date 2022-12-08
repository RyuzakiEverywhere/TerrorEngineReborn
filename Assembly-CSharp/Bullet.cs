using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class Bullet : MonoBehaviour
{
	// Token: 0x0600000E RID: 14 RVA: 0x00003A7F File Offset: 0x00001E7F
	private void Start()
	{
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00003A81 File Offset: 0x00001E81
	private void Update()
	{
		base.transform.Translate(Vector3.forward * 35f * Time.deltaTime);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00003AA8 File Offset: 0x00001EA8
	private void OnTriggerStay(Collider hit)
	{
		if (hit.GetComponent<Collider>().tag == "NPC")
		{
			hit.GetComponent<Collider>().GetComponent<NpcSync>().curhealth -= float.Parse(base.gameObject.name);
			if (this.showblood)
			{
				UnityEngine.Object.Instantiate<Transform>(this.blood, base.transform.position, base.transform.rotation);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject, 0.2f);
		}
		if (hit.GetComponent<Collider>().tag == "PNPC" && hit.GetComponent<Collider>().GetComponent<PhotonView>().isMine)
		{
			hit.GetComponent<Collider>().GetComponent<PNPCMechanics>().health -= float.Parse(base.gameObject.name);
			if (this.showblood)
			{
				UnityEngine.Object.Instantiate<Transform>(this.blood, base.transform.position, base.transform.rotation);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject, 0.2f);
		}
	}

	// Token: 0x0400000F RID: 15
	public bool showblood;

	// Token: 0x04000010 RID: 16
	public Transform blood;

	// Token: 0x04000011 RID: 17
	private RaycastHit hit;
}
