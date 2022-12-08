using System;
using Photon;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class EndGame : Photon.MonoBehaviour
{
	// Token: 0x0600006A RID: 106 RVA: 0x000086F8 File Offset: 0x00006AF8
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00008727 File Offset: 0x00006B27
	private void Start()
	{
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00008729 File Offset: 0x00006B29
	private void Update()
	{
	}

	// Token: 0x0600006D RID: 109 RVA: 0x0000872C File Offset: 0x00006B2C
	public void End()
	{
		if (this.storyname == null || this.storyname == string.Empty)
		{
			base.photonView.RPC("EndMPGame", PhotonTargets.AllBuffered, new object[0]);
		}
		else
		{
			base.photonView.RPC("SwitchStory", PhotonTargets.AllBuffered, new object[0]);
		}
	}

	// Token: 0x0600006E RID: 110 RVA: 0x0000878C File Offset: 0x00006B8C
	public void NewStory()
	{
		CryptoPlayerPrefs.SetString("curstory", this.storyname);
		Application.LoadLevel(5);
	}

	// Token: 0x0600006F RID: 111 RVA: 0x000087A4 File Offset: 0x00006BA4
	[RPC]
	private void EndMPGame()
	{
		PhotonNetwork.LeaveRoom();
		if (PhotonNetwork.isMasterClient)
		{
			Application.LoadLevel(4);
		}
		else
		{
			Application.LoadLevel(7);
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x000087C6 File Offset: 0x00006BC6
	[RPC]
	private void SwitchStory()
	{
		PhotonNetwork.LeaveRoom();
		this.NewStory();
	}

	// Token: 0x040000A5 RID: 165
	public string storyname;
}
