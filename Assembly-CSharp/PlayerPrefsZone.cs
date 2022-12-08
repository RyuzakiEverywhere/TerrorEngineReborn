using System;
using UnityEngine;

// Token: 0x0200003D RID: 61
public class PlayerPrefsZone : MonoBehaviour
{
	// Token: 0x0600010E RID: 270 RVA: 0x0000F7A1 File Offset: 0x0000DBA1
	private void Awake()
	{
	}

	// Token: 0x0600010F RID: 271 RVA: 0x0000F7A3 File Offset: 0x0000DBA3
	private void Update()
	{
	}

	// Token: 0x06000110 RID: 272 RVA: 0x0000F7A8 File Offset: 0x0000DBA8
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player" && other.gameObject.GetComponent<PhotonView>().isMine)
		{
			if (base.gameObject.GetComponent<PlayerPrefsProperties>().cancrouch)
			{
				other.GetComponent<Crouch>().enabled = true;
			}
			else
			{
				other.GetComponent<Crouch>().enabled = false;
			}
			if (base.gameObject.GetComponent<PlayerPrefsProperties>().canpickup)
			{
				other.GetComponent<PickUp>().enabled = true;
			}
			else
			{
				other.GetComponent<PickUp>().enabled = false;
			}
			if (!base.gameObject.GetComponent<PlayerPrefsProperties>().hascollider)
			{
				other.GetComponent<CharacterController>().enabled = false;
			}
			else
			{
				other.GetComponent<CharacterController>().enabled = true;
			}
			UnityEngine.Object.Instantiate(Resources.Load("NewPrefs"), new Vector3(float.Parse(base.gameObject.GetComponent<PlayerPrefsProperties>().walkspeed), float.Parse(base.gameObject.GetComponent<PlayerPrefsProperties>().runspeed), float.Parse(base.gameObject.GetComponent<PlayerPrefsProperties>().jumpheight)), base.transform.rotation);
		}
	}
}
