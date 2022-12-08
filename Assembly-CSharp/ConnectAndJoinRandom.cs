using System;
using Photon;
using UnityEngine;

// Token: 0x0200014E RID: 334
public class ConnectAndJoinRandom : Photon.MonoBehaviour
{
	// Token: 0x06000828 RID: 2088 RVA: 0x0004B002 File Offset: 0x00049402
	public virtual void Start()
	{
		PhotonNetwork.autoJoinLobby = false;
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x0004B00A File Offset: 0x0004940A
	private void Update()
	{
		if (this.ConnectInUpdate && this.AutoConnect)
		{
			this.ConnectInUpdate = false;
			Debug.Log("Update() was called by Unity. Scene is loaded. Let's connect to the Photon Master Server. Calling: PhotonNetwork.JoinRandomRoom();");
			PhotonNetwork.ConnectUsingSettings("1");
		}
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x0004B03D File Offset: 0x0004943D
	public virtual void OnConnectedToMaster()
	{
		Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
		PhotonNetwork.JoinRandomRoom();
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x0004B04E File Offset: 0x0004944E
	public virtual void OnPhotonRandomJoinFailed()
	{
		Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: (null, true, true, 4);");
		PhotonNetwork.CreateRoom(null, true, true, 4);
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x0004B063 File Offset: 0x00049463
	public void OnJoinedRoom()
	{
		Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
	}

	// Token: 0x04000A44 RID: 2628
	public bool AutoConnect;

	// Token: 0x04000A45 RID: 2629
	public int GuiSpace;

	// Token: 0x04000A46 RID: 2630
	private bool ConnectInUpdate = true;
}
