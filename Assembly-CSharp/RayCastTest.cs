using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
public class RayCastTest : MonoBehaviour
{
	// Token: 0x06000115 RID: 277 RVA: 0x0000FED8 File Offset: 0x0000E2D8
	private void Update()
	{
		Vector3 direction = base.transform.TransformDirection(Vector3.forward);
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, 2f) && raycastHit.transform.tag == "Player")
		{
			base.gameObject.GetComponent<NpcSync>().Chase();
		}
	}
}
