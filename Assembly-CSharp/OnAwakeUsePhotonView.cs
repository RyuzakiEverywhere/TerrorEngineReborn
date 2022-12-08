using System;
using Photon;
using UnityEngine;

// Token: 0x02000152 RID: 338
[RequireComponent(typeof(PhotonView))]
public class OnAwakeUsePhotonView : Photon.MonoBehaviour
{
	// Token: 0x0600083A RID: 2106 RVA: 0x0004B2E2 File Offset: 0x000496E2
	private void Awake()
	{
		if (!base.photonView.isMine)
		{
			return;
		}
		base.photonView.RPC("OnAwakeRPC", PhotonTargets.All, new object[0]);
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x0004B30C File Offset: 0x0004970C
	private void Start()
	{
		if (!base.photonView.isMine)
		{
			return;
		}
		base.photonView.RPC("OnAwakeRPC", PhotonTargets.All, new object[]
		{
			1
		});
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x0004B33F File Offset: 0x0004973F
	[RPC]
	public void OnAwakeRPC()
	{
		Debug.Log("RPC: 'OnAwakeRPC' PhotonView: " + base.photonView);
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x0004B356 File Offset: 0x00049756
	[RPC]
	public void OnAwakeRPC(byte myParameter)
	{
		Debug.Log(string.Concat(new object[]
		{
			"RPC: 'OnAwakeRPC' Parameter: ",
			myParameter,
			" PhotonView: ",
			base.photonView
		}));
	}
}
