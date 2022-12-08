using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000126 RID: 294
public class MainMenuJoin : Photon.MonoBehaviour
{
	// Token: 0x0600069B RID: 1691 RVA: 0x00041984 File Offset: 0x0003FD84
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
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x000419E7 File Offset: 0x0003FDE7
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (PhotonNetwork.room != null)
			{
				PhotonNetwork.LeaveRoom();
			}
			Application.LoadLevel("MainMenu");
		}
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x00041A0E File Offset: 0x0003FE0E
	private void Start()
	{
		this.roomName = CryptoPlayerPrefs.GetString("ROOMNAME", string.Empty);
		base.StartCoroutine(this.BeginNow(3f));
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x00041A38 File Offset: 0x0003FE38
	private IEnumerator BeginNow(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		if (PhotonNetwork.room == null)
		{
			PhotonNetwork.JoinRoom(this.roomName);
		}
		yield break;
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x00041A5C File Offset: 0x0003FE5C
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
			}
			if (this.connectFailed)
			{
				GUILayout.Label("Connection failed.", new GUILayoutOption[0]);
				GUILayout.Label(string.Format("Server: {0}:{1}", new object[]
				{
					PhotonNetwork.PhotonServerSettings.ServerAddress,
					PhotonNetwork.PhotonServerSettings.ServerPort
				}), new GUILayoutOption[0]);
				if (GUILayout.Button("Try Again", new GUILayoutOption[]
				{
					GUILayout.Width(100f)
				}))
				{
					this.connectFailed = false;
					PhotonNetwork.ConnectUsingSettings("1.0");
				}
				if (GUILayout.Button("Return To Lobby", new GUILayoutOption[]
				{
					GUILayout.Width(200f)
				}))
				{
					Application.LoadLevel("Lobby");
				}
			}
			return;
		}
		if (this.showgui)
		{
			GUI.skin.box.fontStyle = FontStyle.Bold;
			GUI.skin = this.menuskin;
			GUI.Box(new Rect((float)((Screen.width - 400) / 2), (float)((Screen.height - 350) / 2), 400f, 100f), "Enter Hosts Username");
			GUILayout.BeginArea(new Rect((float)((Screen.width - 400) / 2), (float)((Screen.height - 350) / 2), 400f, 100f));
			GUILayout.Space(25f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.Space(15f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Host Username:", new GUILayoutOption[]
			{
				GUILayout.Width(100f)
			});
			this.roomName = GUILayout.TextField(this.roomName, new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Join Game", new GUILayoutOption[]
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
				" Games."
			}), new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x00041D4A File Offset: 0x0004014A
	private void OnJoinedRoom()
	{
		base.GetComponent<Camera>().enabled = false;
		base.StartCoroutine(this.MoveToGameScene());
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x00041D65 File Offset: 0x00040165
	private void OnCreatedRoom()
	{
		Debug.Log("OnCreatedRoom");
		base.StartCoroutine(this.MoveToGameScene());
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x00041D7E File Offset: 0x0004017E
	private void OnDisconnectedFromPhoton()
	{
		Debug.Log("Disconnected from Photon.");
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00041D8A File Offset: 0x0004018A
	private void OnFailedToConnectToPhoton(object parameters)
	{
		this.connectFailed = true;
		Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters);
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x00041DA4 File Offset: 0x000401A4
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

	// Token: 0x040008F7 RID: 2295
	public Transform CodeGame;

	// Token: 0x040008F8 RID: 2296
	private string roomName = "myRoom";

	// Token: 0x040008F9 RID: 2297
	private Vector2 scrollPos = Vector2.zero;

	// Token: 0x040008FA RID: 2298
	private bool connectFailed;

	// Token: 0x040008FB RID: 2299
	public bool showgui = true;

	// Token: 0x040008FC RID: 2300
	public GUISkin menuskin;
}
