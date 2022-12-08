using System;
using Photon;
using UnityEngine;

// Token: 0x02000153 RID: 339
[RequireComponent(typeof(PhotonView))]
public class OnClickDestroy : Photon.MonoBehaviour
{
	// Token: 0x0600083F RID: 2111 RVA: 0x0004B392 File Offset: 0x00049792
	private void OnClick()
	{
		if (!this.DestroyByRpc)
		{
			PhotonNetwork.Destroy(base.gameObject);
		}
		else
		{
			base.photonView.RPC("DestroyRpc", PhotonTargets.AllBuffered, new object[0]);
		}
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x0004B3C6 File Offset: 0x000497C6
	[RPC]
	public void DestroyRpc()
	{
		UnityEngine.Object.Destroy(base.gameObject);
		PhotonNetwork.UnAllocateViewID(base.photonView.viewID);
	}

	// Token: 0x04000A4C RID: 2636
	public bool DestroyByRpc;
}
