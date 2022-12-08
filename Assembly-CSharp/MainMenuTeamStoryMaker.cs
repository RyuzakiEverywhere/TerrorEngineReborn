using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000128 RID: 296
public class MainMenuTeamStoryMaker : MonoBehaviour
{
	// Token: 0x060006B0 RID: 1712 RVA: 0x000423D8 File Offset: 0x000407D8
	private void Awake()
	{
		if (!PhotonNetwork.connected)
		{
			PhotonNetwork.ConnectUsingSettings("1.0");
		}
		if (string.IsNullOrEmpty(PhotonNetwork.playerName))
		{
			PhotonNetwork.playerName = "Guest" + UnityEngine.Random.Range(1, 9999);
		}
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x00042428 File Offset: 0x00040828
	private void OnGUI()
	{
		if (!PhotonNetwork.connected)
		{
			if (PhotonNetwork.connectionState == ConnectionState.Connecting)
			{
				GUILayout.Label("Connecting " + PhotonNetwork.networkingPeer.ServerAddress, new GUILayoutOption[0]);
				GUILayout.Label(Time.time.ToString(), new GUILayoutOption[0]);
			}
			else
			{
				GUILayout.Label("Not connected. Check console output.", new GUILayoutOption[0]);
			}
			if (this.connectFailed)
			{
				GUILayout.Label("Connection failed. Check setup and use Setup Wizard to fix configuration.", new GUILayoutOption[0]);
				GUILayout.Label(string.Format("Server: {0}:{1}", new object[]
				{
					PhotonNetwork.PhotonServerSettings.ServerAddress,
					PhotonNetwork.PhotonServerSettings.ServerPort
				}), new GUILayoutOption[0]);
				GUILayout.Label("AppId: " + PhotonNetwork.PhotonServerSettings.AppID, new GUILayoutOption[0]);
				if (GUILayout.Button("Try Again", new GUILayoutOption[]
				{
					GUILayout.Width(100f)
				}))
				{
					this.connectFailed = false;
					PhotonNetwork.ConnectUsingSettings("1.0");
				}
			}
			return;
		}
		GUI.skin.box.fontStyle = FontStyle.Bold;
		GUI.Box(new Rect((float)((Screen.width - 400) / 2), (float)((Screen.height - 350) / 2), 400f, 300f), "Join or Create a Room");
		GUILayout.BeginArea(new Rect((float)((Screen.width - 400) / 2), (float)((Screen.height - 350) / 2), 400f, 300f));
		GUILayout.Space(25f);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label("Player name:", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		});
		PhotonNetwork.playerName = GUILayout.TextField(PhotonNetwork.playerName, new GUILayoutOption[0]);
		GUILayout.Space(105f);
		if (GUI.changed)
		{
			PlayerPrefs.SetString("playerName", PhotonNetwork.playerName);
		}
		GUILayout.EndHorizontal();
		GUILayout.Space(15f);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label("Roomname:", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		});
		this.roomName = GUILayout.TextField(this.roomName, new GUILayoutOption[0]);
		if (GUILayout.Button("Create Room", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			PhotonNetwork.CreateRoom(this.roomName, true, true, 10);
			PlayerPrefs.SetInt("Mode", 5);
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("Join Room", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			PlayerPrefs.SetInt("Mode", 5);
			PhotonNetwork.JoinRoom(this.roomName);
		}
		GUILayout.EndHorizontal();
		GUILayout.Space(15f);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label(string.Concat(new object[]
		{
			PhotonNetwork.countOfPlayers,
			" users are online in ",
			PhotonNetwork.countOfRooms,
			" rooms."
		}), new GUILayoutOption[0]);
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("Join Random", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			PhotonNetwork.JoinRandomRoom();
		}
		GUILayout.EndHorizontal();
		GUILayout.Space(15f);
		if (PhotonNetwork.GetRoomList().Length == 0)
		{
			GUILayout.Label("Currently no games are available.", new GUILayoutOption[0]);
			GUILayout.Label("Rooms will be listed here, when they become available.", new GUILayoutOption[0]);
		}
		else
		{
			GUILayout.Label(PhotonNetwork.GetRoomList() + " currently available. Join either:", new GUILayoutOption[0]);
			this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, new GUILayoutOption[0]);
			foreach (RoomInfo roomInfo in PhotonNetwork.GetRoomList())
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label(string.Concat(new object[]
				{
					roomInfo.name,
					" ",
					roomInfo.playerCount,
					"/",
					roomInfo.maxPlayers
				}), new GUILayoutOption[0]);
				if (GUILayout.Button("Join", new GUILayoutOption[0]))
				{
					PlayerPrefs.SetInt("Mode", 5);
					PhotonNetwork.JoinRoom(roomInfo.name);
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
		}
		GUILayout.EndArea();
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x0004289F File Offset: 0x00040C9F
	private void OnJoinedRoom()
	{
		base.StartCoroutine(this.MoveToGameScene());
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x000428AE File Offset: 0x00040CAE
	private void OnCreatedRoom()
	{
		Debug.Log("OnCreatedRoom");
		base.StartCoroutine(this.MoveToGameScene());
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x000428C7 File Offset: 0x00040CC7
	private void OnDisconnectedFromPhoton()
	{
		Debug.Log("Disconnected from Photon.");
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x000428D3 File Offset: 0x00040CD3
	private void OnFailedToConnectToPhoton(object parameters)
	{
		this.connectFailed = true;
		Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters);
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x000428EC File Offset: 0x00040CEC
	private IEnumerator MoveToGameScene()
	{
		Debug.Log("MoveToGameScene");
		while (PhotonNetwork.room == null)
		{
			yield return 0;
		}
		PhotonNetwork.isMessageQueueRunning = false;
		this.CodeGame.gameObject.SetActive(true);
		PhotonNetwork.isMessageQueueRunning = true;
		yield break;
	}

	// Token: 0x04000903 RID: 2307
	public Transform CodeGame;

	// Token: 0x04000904 RID: 2308
	private string roomName = "myRoom";

	// Token: 0x04000905 RID: 2309
	private Vector2 scrollPos = Vector2.zero;

	// Token: 0x04000906 RID: 2310
	private bool connectFailed;
}
