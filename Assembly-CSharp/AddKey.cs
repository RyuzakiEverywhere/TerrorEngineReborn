using System;
using Photon;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class AddKey : Photon.MonoBehaviour
{
	// Token: 0x06000002 RID: 2 RVA: 0x00002B3D File Offset: 0x00000F3D
	private void Start()
	{
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002B40 File Offset: 0x00000F40
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (this.key1)
			{
				other.gameObject.GetComponent<PlayerKeys>().key1 = true;
			}
			if (this.key2)
			{
				other.gameObject.GetComponent<PlayerKeys>().key2 = true;
			}
			if (this.key3)
			{
				other.gameObject.GetComponent<PlayerKeys>().key3 = true;
			}
			if (this.key4)
			{
				other.gameObject.GetComponent<PlayerKeys>().key4 = true;
			}
			if (this.key5)
			{
				other.gameObject.GetComponent<PlayerKeys>().key5 = true;
			}
			if (this.key6)
			{
				other.gameObject.GetComponent<PlayerKeys>().key6 = true;
			}
			if (this.key7)
			{
				other.gameObject.GetComponent<PlayerKeys>().key7 = true;
			}
			if (this.key8)
			{
				other.gameObject.GetComponent<PlayerKeys>().key8 = true;
			}
			if (this.key9)
			{
				other.gameObject.GetComponent<PlayerKeys>().key9 = true;
			}
			if (other.GetComponent<PhotonView>().isMine)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04000001 RID: 1
	public bool key1;

	// Token: 0x04000002 RID: 2
	public bool key2;

	// Token: 0x04000003 RID: 3
	public bool key3;

	// Token: 0x04000004 RID: 4
	public bool key4;

	// Token: 0x04000005 RID: 5
	public bool key5;

	// Token: 0x04000006 RID: 6
	public bool key6;

	// Token: 0x04000007 RID: 7
	public bool key7;

	// Token: 0x04000008 RID: 8
	public bool key8;

	// Token: 0x04000009 RID: 9
	public bool key9;
}
