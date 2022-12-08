using System;
using System.IO;
using UnityEngine;

// Token: 0x020000C3 RID: 195
public class LobbyMenu : MonoBehaviour
{
	// Token: 0x1700000C RID: 12
	// (get) Token: 0x0600039D RID: 925 RVA: 0x000216B5 File Offset: 0x0001FAB5
	// (set) Token: 0x0600039E RID: 926 RVA: 0x000216BD File Offset: 0x0001FABD
	public string ErrorDialog
	{
		get
		{
			return this.errorDialog;
		}
		private set
		{
			this.errorDialog = value;
			if (!string.IsNullOrEmpty(value))
			{
				this.timeToClearDialog = (double)(Time.time + 4f);
			}
		}
	}

	// Token: 0x0600039F RID: 927 RVA: 0x000216E4 File Offset: 0x0001FAE4
	public void Awake()
	{
		PhotonNetwork.automaticallySyncScene = true;
		if (PhotonNetwork.connectionStateDetailed == PeerState.PeerCreated)
		{
			PhotonNetwork.ConnectUsingSettings("0.9");
		}
		if (CryptoPlayerPrefs.GetString("E410675", string.Empty) == "E2193590")
		{
			PhotonNetwork.playerName = CryptoPlayerPrefs.GetString("E602397", string.Empty);
		}
		else
		{
			PhotonNetwork.playerName = "Guest" + UnityEngine.Random.Range(1, 9999);
		}
		if (CryptoPlayerPrefs.GetInt("Standalone", 0) == 1)
		{
			this.selecta = "Select A Level";
		}
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x00021780 File Offset: 0x0001FB80
	public void OnGUI()
	{
		GUI.skin = this.guiSkin;
		if (GUI.Button(new Rect(0f, 0f, 100f, 22f), "Menu"))
		{
			Application.LoadLevel("MainMenu");
		}
		if (!PhotonNetwork.connected)
		{
			if (this.connectFailed)
			{
				GUILayout.Label("Connection failed.", new GUILayoutOption[0]);
				if (GUILayout.Button("Try Again", new GUILayoutOption[]
				{
					GUILayout.Width(100f)
				}))
				{
					this.connectFailed = false;
					PhotonNetwork.ConnectUsingSettings("0.9");
				}
				if (GUILayout.Button("Return To Menu", new GUILayoutOption[]
				{
					GUILayout.Width(200f)
				}))
				{
					Application.LoadLevel("MainMenu");
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
		GUILayout.Label(PhotonNetwork.playerName, new GUILayoutOption[0]);
		GUILayout.Space(105f);
		if (GUI.changed)
		{
			PlayerPrefs.SetString("playerName", PhotonNetwork.playerName);
		}
		GUILayout.EndHorizontal();
		GUILayout.Space(15f);
		if (!string.IsNullOrEmpty(this.ErrorDialog))
		{
			GUILayout.Label(this.ErrorDialog, new GUILayoutOption[0]);
			if (this.timeToClearDialog < (double)Time.time)
			{
				this.timeToClearDialog = 0.0;
				this.ErrorDialog = string.Empty;
			}
		}
		if (this.createroom)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("Join A Room", new GUILayoutOption[]
			{
				GUILayout.Width(120f)
			}))
			{
				this.createroom = false;
				CryptoPlayerPrefs.SetInt("Mode", 3);
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Roomname:", new GUILayoutOption[]
			{
				GUILayout.Width(100f)
			});
			this.roomName = GUILayout.TextField(this.roomName, new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.Space(15f);
			GUILayout.Label(this.selecta, new GUILayoutOption[0]);
			DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
			this.fileName = string.Concat(new object[]
			{
				directoryInfo.Parent.ToString(),
				Path.DirectorySeparatorChar,
				"Levels",
				Path.DirectorySeparatorChar
			});
			this.listoffiles = Directory.GetFiles(this.fileName, "*.story");
			this.listofstories = this.listoffiles;
			for (int i = 0; i < this.listofstories.Length; i++)
			{
				string text = this.fileName;
				string oldValue = ".story";
				if (this.listofstories[i].Contains(text))
				{
					this.listofstories[i] = this.listofstories[i].Replace(text, string.Empty);
					this.listofstories[i] = this.listofstories[i].Replace(oldValue, string.Empty);
				}
			}
			this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, new GUILayoutOption[0]);
			foreach (string text2 in this.listofstories)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(text2, new GUILayoutOption[0]))
				{
					CryptoPlayerPrefs.SetString("ROOMNAME", this.roomName);
					CryptoPlayerPrefs.SetString("STORYNAME", text2);
					CryptoPlayerPrefs.SetInt("Mode", 2);
					UniSave.Load(text2);
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
		}
		else
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			DirectoryInfo directoryInfo2 = new DirectoryInfo(Application.dataPath);
			this.fileName = string.Concat(new object[]
			{
				directoryInfo2.Parent.ToString(),
				Path.DirectorySeparatorChar,
				"Levels",
				Path.DirectorySeparatorChar
			});
			if (GUILayout.Button("Create A Room", new GUILayoutOption[]
			{
				GUILayout.Width(120f)
			}))
			{
				this.createroom = true;
				CryptoPlayerPrefs.SetInt("Mode", 2);
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
			GUILayout.EndHorizontal();
			GUILayout.Space(15f);
			if (PhotonNetwork.GetRoomList().Length == 0)
			{
				GUILayout.Label("Currently no games are available.", new GUILayoutOption[0]);
				GUILayout.Label("Rooms will be listed here, when they become available.", new GUILayoutOption[0]);
			}
			else
			{
				GUILayout.Label("Rooms are currently available. Join either:", new GUILayoutOption[0]);
				this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, new GUILayoutOption[0]);
				foreach (RoomInfo roomInfo in PhotonNetwork.GetRoomList())
				{
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					GUILayout.Label(string.Concat(new object[]
					{
						"<b>",
						roomInfo.name,
						"</b> | ",
						roomInfo.customProperties["MapName"],
						" | ",
						roomInfo.playerCount,
						"/",
						roomInfo.maxPlayers
					}), new GUILayoutOption[0]);
					if (GUILayout.Button("Join", new GUILayoutOption[0]) && File.Exists(this.fileName + roomInfo.customProperties["MapName"].ToString() + ".story"))
					{
						CryptoPlayerPrefs.SetString("ROOMNAME", roomInfo.name);
						CryptoPlayerPrefs.SetInt("Mode", 3);
						UniSave.Load(roomInfo.customProperties["MapName"].ToString());
					}
					GUILayout.EndHorizontal();
				}
				GUILayout.EndScrollView();
			}
		}
		GUILayout.EndArea();
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00021E2A File Offset: 0x0002022A
	public void OnJoinedRoom()
	{
		Debug.Log("OnJoinedRoom");
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x00021E36 File Offset: 0x00020236
	public void OnPhotonCreateRoomFailed()
	{
		this.ErrorDialog = "Error: Can't create room (room name maybe already used).";
		Debug.Log("OnPhotonCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x00021E4D File Offset: 0x0002024D
	public void OnPhotonJoinRoomFailed()
	{
		this.ErrorDialog = "Error: Can't join room (full or unknown room name).";
		Debug.Log("OnPhotonJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00021E64 File Offset: 0x00020264
	public void OnPhotonRandomJoinFailed()
	{
		this.ErrorDialog = "Error: Can't join random room (none found).";
		Debug.Log("OnPhotonRandomJoinFailed got called. Happens if no room is available (or all full or invisible or closed). JoinrRandom filter-options can limit available rooms.");
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00021E7B File Offset: 0x0002027B
	public void OnCreatedRoom()
	{
		Debug.Log("OnCreatedRoom");
		PhotonNetwork.LoadLevel(LobbyMenu.SceneNameGame);
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00021E91 File Offset: 0x00020291
	public void OnDisconnectedFromPhoton()
	{
		Debug.Log("Disconnected from Photon.");
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00021E9D File Offset: 0x0002029D
	public void OnFailedToConnectToPhoton(object parameters)
	{
		this.connectFailed = true;
		Debug.Log(string.Concat(new object[]
		{
			"OnFailedToConnectToPhoton. StatusCode: ",
			parameters,
			" ServerAddress: ",
			PhotonNetwork.networkingPeer.ServerAddress
		}));
	}

	// Token: 0x04000415 RID: 1045
	public GUISkin guiSkin;

	// Token: 0x04000416 RID: 1046
	public bool createroom;

	// Token: 0x04000417 RID: 1047
	public string[] listoffiles;

	// Token: 0x04000418 RID: 1048
	public string[] listofstories;

	// Token: 0x04000419 RID: 1049
	private string roomName = "myRoom";

	// Token: 0x0400041A RID: 1050
	public string fileName;

	// Token: 0x0400041B RID: 1051
	private string selecta = "Select A Story";

	// Token: 0x0400041C RID: 1052
	private Vector2 scrollPos = Vector2.zero;

	// Token: 0x0400041D RID: 1053
	private Vector2 scrollPos2 = Vector2.zero;

	// Token: 0x0400041E RID: 1054
	private bool connectFailed;

	// Token: 0x0400041F RID: 1055
	public static readonly string SceneNameMenu = "Lobby";

	// Token: 0x04000420 RID: 1056
	public static readonly string SceneNameGame = "loadnewstory";

	// Token: 0x04000421 RID: 1057
	private string errorDialog;

	// Token: 0x04000422 RID: 1058
	private double timeToClearDialog;
}
