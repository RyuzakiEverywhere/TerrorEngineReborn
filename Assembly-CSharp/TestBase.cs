using System;
using Photon;

// Token: 0x02000159 RID: 345
public class TestBase : MonoBehaviour
{
	// Token: 0x0600084B RID: 2123 RVA: 0x0004B6E2 File Offset: 0x00049AE2
	public virtual void Start()
	{
		PhotonNetwork.autoJoinLobby = false;
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x0004B6EA File Offset: 0x00049AEA
	private void Update()
	{
		if (this.ConnectInUpdate && this.AutoConnect)
		{
			this.ConnectInUpdate = false;
			PhotonNetwork.ConnectUsingSettings("1");
		}
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x0004B713 File Offset: 0x00049B13
	public virtual void OnConnectedToMaster()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x0004B71A File Offset: 0x00049B1A
	public virtual void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null, true, true, 4);
	}

	// Token: 0x04000A56 RID: 2646
	public bool AutoConnect;

	// Token: 0x04000A57 RID: 2647
	public int GuiSpace;

	// Token: 0x04000A58 RID: 2648
	private bool ConnectInUpdate = true;
}
