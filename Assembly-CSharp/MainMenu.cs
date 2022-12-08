using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000125 RID: 293
public class MainMenu : Photon.MonoBehaviour
{
	// Token: 0x06000690 RID: 1680 RVA: 0x000411E8 File Offset: 0x0003F5E8
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
		PhotonNetwork.playerName = CryptoPlayerPrefs.GetString("E602397", string.Empty);
		this.roomName = CryptoPlayerPrefs.GetString("E602397", string.Empty);
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x00041260 File Offset: 0x0003F660
	private void Update()
	{
		PhotonNetwork.playerName = CryptoPlayerPrefs.GetString("E602397", string.Empty);
		this.roomName = CryptoPlayerPrefs.GetString("ROOMNAME", string.Empty);
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (PhotonNetwork.room != null)
			{
				PhotonNetwork.LeaveRoom();
			}
			Application.LoadLevel("MainMenu");
		}
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x000412BB File Offset: 0x0003F6BB
	private void Start()
	{
		base.StartCoroutine(this.BeginNow(3f));
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x000412D0 File Offset: 0x0003F6D0
	private IEnumerator BeginNow(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		if (PhotonNetwork.room == null)
		{
			Hashtable hashtable = new Hashtable();
			hashtable["MapName"] = CryptoPlayerPrefs.GetString("STORYNAME", string.Empty);
			string[] propsToListInLobby = new string[]
			{
				"MapName"
			};
			PhotonNetwork.CreateRoom(this.roomName, true, true, 6, hashtable, propsToListInLobby);
		}
		yield break;
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x000412F4 File Offset: 0x0003F6F4
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
				GUILayout.Label("Not connected.", new GUILayoutOption[0]);
				if (GUILayout.Button("Return To Lobby", new GUILayoutOption[]
				{
					GUILayout.Width(200f)
				}))
				{
					Application.LoadLevel("Lobby");
				}
				this.connectFailed = false;
			}
			if (this.connectFailed)
			{
				GUILayout.Label("Connection failed.", new GUILayoutOption[0]);
				if (GUILayout.Button("Try Again", new GUILayoutOption[]
				{
					GUILayout.Width(100f)
				}))
				{
					this.connectFailed = false;
					PhotonNetwork.ConnectUsingSettings("1.0");
				}
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
			return;
		}
		if (this.showgui)
		{
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
				PlayerPrefs.SetInt("Mode", 1);
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Join Room", new GUILayoutOption[]
			{
				GUILayout.Width(100f)
			}))
			{
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
						PhotonNetwork.JoinRoom(roomInfo.name);
					}
					GUILayout.EndHorizontal();
				}
				GUILayout.EndScrollView();
			}
			GUILayout.EndArea();
		}
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x0004174B File Offset: 0x0003FB4B
	private void OnJoinedRoom()
	{
		base.GetComponent<Camera>().enabled = false;
		base.StartCoroutine(this.MoveToGameScene());
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x00041766 File Offset: 0x0003FB66
	private void OnCreatedRoom()
	{
		Debug.Log("OnCreatedRoom");
		base.StartCoroutine(this.MoveToGameScene());
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x0004177F File Offset: 0x0003FB7F
	private void OnDisconnectedFromPhoton()
	{
		Debug.Log("Disconnected from Photon.");
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x0004178B File Offset: 0x0003FB8B
	private void OnFailedToConnectToPhoton(object parameters)
	{
		this.connectFailed = true;
		Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters);
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x000417A4 File Offset: 0x0003FBA4
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

	// Token: 0x040008F2 RID: 2290
	public Transform CodeGame;

	// Token: 0x040008F3 RID: 2291
	private string roomName = "myRoom";

	// Token: 0x040008F4 RID: 2292
	private Vector2 scrollPos = Vector2.zero;

	// Token: 0x040008F5 RID: 2293
	private bool connectFailed;

	// Token: 0x040008F6 RID: 2294
	public bool showgui;
}
