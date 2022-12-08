using System;
using Photon;
using UnityEngine;

// Token: 0x0200019B RID: 411
public class SmoothNPC : Photon.MonoBehaviour
{
	// Token: 0x060009CA RID: 2506 RVA: 0x00054CE9 File Offset: 0x000530E9
	private void Start()
	{
		this.cc = base.GetComponent<CapsuleCollider>();
	}

	// Token: 0x060009CB RID: 2507 RVA: 0x00054CF8 File Offset: 0x000530F8
	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(base.transform.position);
			stream.SendNext(base.transform.rotation);
			if (this.cc)
			{
				stream.SendNext(this.cc.center);
				stream.SendNext(this.cc.height);
			}
		}
		else if (!base.photonView.isMine)
		{
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			this.capsulePos = (Vector3)stream.ReceiveNext();
			this.capsuleScale = (float)stream.ReceiveNext();
		}
	}

	// Token: 0x060009CC RID: 2508 RVA: 0x00054DD4 File Offset: 0x000531D4
	private void Update()
	{
		if (!base.photonView.isMine)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, this.correctPlayerPos, Time.deltaTime * 8f);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.correctPlayerRot, Time.deltaTime * 8f);
			if (this.cc.height != this.capsulePos.y && this.cc.height != this.capsuleScale)
			{
				this.cc.center = this.capsulePos;
				this.cc.height = this.capsuleScale;
			}
		}
	}

	// Token: 0x04000B59 RID: 2905
	private CapsuleCollider cc;

	// Token: 0x04000B5A RID: 2906
	private Vector3 correctPlayerPos = new Vector3(0f, -100f, 0f);

	// Token: 0x04000B5B RID: 2907
	private Quaternion correctPlayerRot = Quaternion.identity;

	// Token: 0x04000B5C RID: 2908
	private Vector3 capsulePos = Vector3.zero;

	// Token: 0x04000B5D RID: 2909
	private float capsuleScale;
}
