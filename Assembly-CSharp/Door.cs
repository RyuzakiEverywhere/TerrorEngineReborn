using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020000CB RID: 203
public class Door : MonoBehaviour
{
	// Token: 0x060003CC RID: 972 RVA: 0x00022D1C File Offset: 0x0002111C
	private void Start()
	{
		this.defaultRot = base.transform.eulerAngles;
		this.openRot = new Vector3(this.defaultRot.x, this.defaultRot.y + this.DoorOpenAngle, this.defaultRot.z);
		if (this.islocked)
		{
			this.nmo = base.transform.Find("body").gameObject.AddComponent<NavMeshObstacle>();
			this.nmo.carving = true;
		}
	}

	// Token: 0x060003CD RID: 973 RVA: 0x00022DA4 File Offset: 0x000211A4
	private void Update()
	{
		if (this.open)
		{
			base.transform.eulerAngles = Vector3.Slerp(base.transform.eulerAngles, this.openRot, Time.deltaTime * this.smooth);
			base.transform.Find("body").GetComponent<BoxCollider>().enabled = false;
		}
		else
		{
			base.transform.eulerAngles = Vector3.Slerp(base.transform.eulerAngles, this.defaultRot, Time.deltaTime * this.smooth);
			base.transform.Find("body").GetComponent<BoxCollider>().enabled = true;
		}
		if (Input.GetKeyDown(KeyCode.E) && this.enter)
		{
			this.open = !this.open;
		}
		if (this.islocked)
		{
			base.transform.eulerAngles = this.defaultRot;
		}
	}

	// Token: 0x060003CE RID: 974 RVA: 0x00022E94 File Offset: 0x00021294
	private void OnGUI()
	{
		if (this.enter)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 90), (float)(Screen.height - 100), 200f, 41f), "<b>Press 'E' to open/close door</b>");
		}
		if (this.showitislocked)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 55), (float)(Screen.height - 100), 150f, 30f), "<b>Door is locked</b>");
		}
	}

	// Token: 0x060003CF RID: 975 RVA: 0x00022F14 File Offset: 0x00021314
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && other.GetComponent<PhotonView>().isMine)
		{
			if (this.keynum == 1 && other.gameObject.GetComponent<PlayerKeys>().key1)
			{
				this.islocked = false;
			}
			if (this.keynum == 2 && other.gameObject.GetComponent<PlayerKeys>().key2)
			{
				this.islocked = false;
			}
			if (this.keynum == 3 && other.gameObject.GetComponent<PlayerKeys>().key3)
			{
				this.islocked = false;
			}
			if (this.keynum == 4 && other.gameObject.GetComponent<PlayerKeys>().key4)
			{
				this.islocked = false;
			}
			if (this.keynum == 5 && other.gameObject.GetComponent<PlayerKeys>().key5)
			{
				this.islocked = false;
			}
			if (this.keynum == 6 && other.gameObject.GetComponent<PlayerKeys>().key6)
			{
				this.islocked = false;
			}
			if (this.keynum == 7 && other.gameObject.GetComponent<PlayerKeys>().key7)
			{
				this.islocked = false;
			}
			if (this.keynum == 8 && other.gameObject.GetComponent<PlayerKeys>().key8)
			{
				this.islocked = false;
			}
			if (this.keynum == 9 && other.gameObject.GetComponent<PlayerKeys>().key9)
			{
				this.islocked = false;
			}
			if (!this.islocked)
			{
				this.enter = true;
			}
			else
			{
				this.showitislocked = true;
			}
		}
		if (other.gameObject.tag == "NPC" && !this.islocked)
		{
			this.open = true;
		}
		if (!this.islocked && this.nmo != null)
		{
			this.nmo.enabled = false;
		}
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x00023126 File Offset: 0x00021526
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player" && other.GetComponent<PhotonView>().isMine)
		{
			this.enter = false;
			this.showitislocked = false;
		}
	}

	// Token: 0x04000448 RID: 1096
	public float smooth = 3f;

	// Token: 0x04000449 RID: 1097
	private float DoorOpenAngle = 75f;

	// Token: 0x0400044A RID: 1098
	private bool open;

	// Token: 0x0400044B RID: 1099
	private bool enter;

	// Token: 0x0400044C RID: 1100
	public int keynum;

	// Token: 0x0400044D RID: 1101
	public bool islocked;

	// Token: 0x0400044E RID: 1102
	public string showtext = "Press 'E' to open the door";

	// Token: 0x0400044F RID: 1103
	private Vector3 defaultRot;

	// Token: 0x04000450 RID: 1104
	private Vector3 openRot;

	// Token: 0x04000451 RID: 1105
	public bool showitislocked;

	// Token: 0x04000452 RID: 1106
	private NavMeshObstacle nmo;
}
