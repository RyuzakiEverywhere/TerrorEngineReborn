using System;
using Photon;
using UnityEngine;

// Token: 0x02000122 RID: 290
public class GameManager : Photon.MonoBehaviour
{
	// Token: 0x06000678 RID: 1656 RVA: 0x00040804 File Offset: 0x0003EC04
	public void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			UnityEngine.Object.Destroy(GameObject.Find("Menu"));
		}
		if (!PhotonNetwork.connected)
		{
			Application.LoadLevel(Application.loadedLevel - 1);
			return;
		}
		PhotonNetwork.isMessageQueueRunning = true;
		GameObject.Find("NAV_MESH_GRID").GetComponent<BakeNavMesh>().BakeNow(string.Empty);
		this.spawnpoint = GameObject.FindWithTag("StartPoint").transform;
		this.spawnpoint.Translate(0f, 2f, 0f, Space.World);
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 1)
		{
			PhotonNetwork.Instantiate(this.playerPrefab.name + "2", this.spawnpoint.position, Quaternion.identity, 0);
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			PhotonNetwork.Instantiate(this.playerPrefab.name, this.spawnpoint.position, Quaternion.identity, 0);
		}
		UnityEngine.Object.Destroy(this.spawnpoint);
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x00040948 File Offset: 0x0003ED48
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			this.isPaused = !this.isPaused;
			if (this.isPaused)
			{
				if (PhotonNetwork.offlineMode)
				{
					Time.timeScale = 0.001f;
				}
			}
			else if (PhotonNetwork.offlineMode)
			{
				Time.timeScale = 1f;
			}
		}
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x000409A8 File Offset: 0x0003EDA8
	private void OnGUI()
	{
		if (this.isPaused)
		{
			GUI.Box(new Rect(-10f, -10f, (float)(Screen.width + 20), (float)(Screen.height + 20)), string.Empty);
			GUI.Label(new Rect((float)(Screen.width / 2 - 33), (float)(Screen.height / 2 - 20), 120f, 40f), "<size=15><b>PAUSED</b></size>");
			GUI.Label(new Rect((float)(Screen.width / 2 - 60), (float)(Screen.height / 2 + 40), 160f, 40f), "<b>(Press TAB to quit)</b>");
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				PhotonNetwork.LeaveRoom();
				Application.LoadLevel("MainMenu");
			}
		}
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x00040A64 File Offset: 0x0003EE64
	public void OnLeftRoom()
	{
		Debug.Log("OnLeftRoom (local)");
		Application.LoadLevel(Application.loadedLevelName);
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x00040A7C File Offset: 0x0003EE7C
	public void OnMasterClientSwitched(PhotonPlayer player)
	{
		Debug.Log("OnMasterClientSwitched: " + player);
		if (PhotonNetwork.connected)
		{
			base.photonView.RPC("SendChatMessage", PhotonNetwork.masterClient, new object[]
			{
				"Hi master! From:" + PhotonNetwork.player
			});
			base.photonView.RPC("SendChatMessage", PhotonTargets.All, new object[]
			{
				"The Host Has Left The Game"
			});
			PhotonNetwork.LeaveRoom();
		}
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x00040AF4 File Offset: 0x0003EEF4
	public void OnDisconnectedFromPhoton()
	{
		Debug.Log("OnDisconnectedFromPhoton");
		Application.LoadLevel(Application.loadedLevelName);
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x00040B0A File Offset: 0x0003EF0A
	public void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		Debug.Log("OnPhotonPlayerConnected: " + player);
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x00040B1C File Offset: 0x0003EF1C
	public void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		Debug.Log("OnPlayerDisconneced: " + player);
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x00040B2E File Offset: 0x0003EF2E
	public void OnReceivedRoomList()
	{
		Debug.Log("OnReceivedRoomList");
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x00040B3A File Offset: 0x0003EF3A
	public void OnReceivedRoomListUpdate()
	{
		Debug.Log("OnReceivedRoomListUpdate");
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x00040B46 File Offset: 0x0003EF46
	public void OnConnectedToPhoton()
	{
		Debug.Log("OnConnectedToPhoton");
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x00040B52 File Offset: 0x0003EF52
	public void OnFailedToConnectToPhoton()
	{
		Debug.Log("OnFailedToConnectToPhoton");
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x00040B5E File Offset: 0x0003EF5E
	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
		Debug.Log("OnPhotonInstantiate " + info.sender);
	}

	// Token: 0x040008EC RID: 2284
	public Transform playerPrefab;

	// Token: 0x040008ED RID: 2285
	public Transform spawnpoint;

	// Token: 0x040008EE RID: 2286
	private bool isPaused;
}
