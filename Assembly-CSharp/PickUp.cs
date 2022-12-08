using System;
using Photon;
using UnityEngine;

// Token: 0x020000DD RID: 221
public class PickUp : Photon.MonoBehaviour
{
	// Token: 0x06000428 RID: 1064 RVA: 0x00026605 File Offset: 0x00024A05
	private void Start()
	{
		this.isObjectHeld = false;
		this.objectHeld = null;
		if (!GameObject.Find("Events/Player Start Point").GetComponent<PlayerProperties>().canpickup)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x00026638 File Offset: 0x00024A38
	private void Update()
	{
		if (Input.GetKey(KeyCode.F))
		{
			this.pickableObjects = GameObject.FindGameObjectsWithTag("CanPickup");
			if (!this.isObjectHeld)
			{
				this.tryPickObject();
			}
			else
			{
				this.holdObject();
				this.showicon = false;
			}
		}
		else
		{
			this.showicon = false;
		}
		if (Input.GetKeyUp(KeyCode.F) && this.isObjectHeld)
		{
			this.isObjectHeld = false;
			this.objectHeld.GetComponent<Rigidbody>().useGravity = true;
		}
		if (Input.GetKeyUp(KeyCode.F) && this.cantshowpickup)
		{
			this.cantshowpickup = false;
		}
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x000266E0 File Offset: 0x00024AE0
	private void tryPickObject()
	{
		Ray ray = this.playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		this.showicon = true;
		RaycastHit raycastHit;
		Physics.Raycast(ray, out raycastHit);
		foreach (GameObject x in this.pickableObjects)
		{
			if (x == raycastHit.collider.gameObject)
			{
				if (PhotonNetwork.isMasterClient)
				{
					this.isObjectHeld = true;
					this.objectHeld = x;
					this.objectHeld.GetComponent<Rigidbody>().useGravity = false;
				}
				else
				{
					this.cantshowpickup = true;
				}
			}
		}
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00026794 File Offset: 0x00024B94
	private void holdObject()
	{
		Ray ray = this.playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		Vector3 a = this.playerCam.transform.position + ray.direction * 2f;
		Vector3 position = this.objectHeld.transform.position;
		this.objectHeld.GetComponent<Rigidbody>().velocity = (a - position) * 10f;
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x00026820 File Offset: 0x00024C20
	private void OnGUI()
	{
		if (this.showicon)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 16), (float)(Screen.height / 2 - 16), 34f, 34f), this.pickupicon);
		}
		if (this.isObjectHeld)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 16), (float)(Screen.height / 2 - 16), 34f, 34f), this.holdicon);
		}
		if (this.cantshowpickup)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 60), (float)(Screen.height / 2 - 15), 120f, 45f), this.canticon);
		}
	}

	// Token: 0x040004C9 RID: 1225
	public GameObject[] pickableObjects;

	// Token: 0x040004CA RID: 1226
	public GameObject playerCam;

	// Token: 0x040004CB RID: 1227
	public Texture2D pickupicon;

	// Token: 0x040004CC RID: 1228
	public Texture2D holdicon;

	// Token: 0x040004CD RID: 1229
	public Texture2D canticon;

	// Token: 0x040004CE RID: 1230
	private Ray playerAim;

	// Token: 0x040004CF RID: 1231
	private GameObject objectHeld;

	// Token: 0x040004D0 RID: 1232
	private bool isObjectHeld;

	// Token: 0x040004D1 RID: 1233
	private bool showicon;

	// Token: 0x040004D2 RID: 1234
	private bool cantshowpickup;
}
