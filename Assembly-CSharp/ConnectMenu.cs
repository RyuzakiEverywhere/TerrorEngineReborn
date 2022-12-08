using System;
using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;

// Token: 0x02000011 RID: 17
public class ConnectMenu : Photon.MonoBehaviour
{
	// Token: 0x0600003A RID: 58 RVA: 0x00005BA0 File Offset: 0x00003FA0
	private void Start()
	{
		PhotonNetwork.isMessageQueueRunning = true;
		Screen.lockCursor = false;
		this.allRooms = PhotonNetwork.GetRoomList();
		this.newRoomName = "Room Name " + UnityEngine.Random.Range(111, 999);
		this.playerName = "Player " + UnityEngine.Random.Range(111, 999);
		this.maxPlayersOptions.Add(2);
		this.maxPlayersOptions.Add(3);
		this.maxPlayersOptions.Add(4);
		this.maxPlayersOptions.Add(5);
		this.maxPlayersOptions.Add(6);
		this.maxPlayers = this.maxPlayersOptions[2];
		this.selectedMap = 0;
		if (this.roundDuration == 0)
		{
			this.roundDuration = 600;
		}
		this.gameMode = "TDM";
		if (PlayerPrefs.HasKey("PlayerName"))
		{
			this.playerName = PlayerPrefs.GetString("PlayerName");
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00005C9C File Offset: 0x0000409C
	private void Update()
	{
		float num = 3f;
		float num2 = 0f;
		if (!PhotonNetwork.connected)
		{
			if (Time.time - num > num2)
			{
				num2 = Time.time - Time.deltaTime;
			}
			while (num2 < Time.time)
			{
				num2 += num;
				if (PhotonNetwork.connectionState != ConnectionState.Connecting && PhotonNetwork.connectionState != ConnectionState.InitializingApplication && PhotonNetwork.connectionState != ConnectionState.Disconnecting)
				{
					PhotonNetwork.ConnectUsingSettings("v0.0.1");
				}
			}
		}
		if (PhotonNetwork.connected && this.allRooms.Length != PhotonNetwork.GetRoomList().Length)
		{
			this.allRooms = PhotonNetwork.GetRoomList();
		}
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00005D40 File Offset: 0x00004140
	private void OnGUI()
	{
		GUI.skin = this.guiSKin;
		GUI.color = Color.white;
		GUI.depth = -2;
		if (!PhotonNetwork.connected)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		GUI.color = new Color(1f, 1f, 1f, 0.9f);
		GUI.DrawTexture(new Rect(0f, 0f, (float)this.top.width, (float)this.top.height), this.top, ScaleMode.ScaleToFit);
		GUI.DrawTexture(new Rect((float)(Screen.width - this.bottom.width), (float)(Screen.height - this.bottom.height), (float)this.bottom.width, (float)this.bottom.height), this.bottom, ScaleMode.ScaleToFit);
		GUI.color = Color.white;
		GUILayout.BeginArea(new Rect((float)(Screen.width / 2 - 250), (float)(Screen.height / 2 - 150), 500f, 330f), "ASDFGame | Project Alpha", GUI.skin.GetStyle("window"));
		this.ShowConnectMenu();
		GUILayout.EndArea();
		if (!PhotonNetwork.connected)
		{
			GUI.color = Color.white;
			GUI.Box(new Rect((float)(Screen.width / 2 - 75), (float)(Screen.height / 2 - 15), 150f, 30f), "Connecting...");
		}
		this.FadeScreen();
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00005EC4 File Offset: 0x000042C4
	private void ShowConnectMenu()
	{
		GUILayout.Space(10f);
		if (!this.createRoom)
		{
			this.scroll = GUILayout.BeginScrollView(this.scroll, new GUILayoutOption[]
			{
				GUILayout.Width(480f),
				GUILayout.Height(225f)
			});
			if (this.allRooms != null && this.allRooms.Length > 0)
			{
				foreach (RoomInfo roomInfo in this.allRooms)
				{
					if (this.allRooms.Length > 0)
					{
						GUILayout.BeginHorizontal("box", new GUILayoutOption[0]);
						GUILayout.Label(roomInfo.name, new GUILayoutOption[]
						{
							GUILayout.Width(150f)
						});
						GUILayout.Label((string)roomInfo.customProperties["MapName"], new GUILayoutOption[]
						{
							GUILayout.Width(135f)
						});
						GUILayout.Label(roomInfo.playerCount + "/" + roomInfo.maxPlayers, new GUILayoutOption[]
						{
							GUILayout.Width(60f)
						});
						GUILayout.FlexibleSpace();
						if (GUILayout.Button("Join Room", new GUILayoutOption[]
						{
							GUILayout.Width(100f)
						}))
						{
							PhotonNetwork.JoinRoom(roomInfo.name);
							PhotonNetwork.playerName = this.playerName;
							this.connectingToRoom = true;
							this.CheckPlayerNameAndRoom();
							PlayerPrefs.SetString("PlayerName", this.playerName);
						}
						GUILayout.EndHorizontal();
					}
				}
			}
			else
			{
				GUILayout.Label("No rooms created...", new GUILayoutOption[0]);
			}
			GUILayout.EndScrollView();
			GUILayout.Space(5f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Player Name: ", new GUILayoutOption[0]);
			this.playerName = GUILayout.TextField(this.playerName, 15, new GUILayoutOption[]
			{
				GUILayout.Height(25f)
			});
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Create Room", new GUILayoutOption[]
			{
				GUILayout.Width(130f),
				GUILayout.Height(25f)
			}))
			{
				this.createRoom = true;
				this.CheckPlayerNameAndRoom();
				PlayerPrefs.SetString("PlayerName", this.playerName);
			}
			GUILayout.EndHorizontal();
		}
		else
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Room Name: ", new GUILayoutOption[]
			{
				GUILayout.Width(130f)
			});
			this.newRoomName = GUILayout.TextField(this.newRoomName, 15, new GUILayoutOption[]
			{
				GUILayout.Height(25f)
			});
			GUILayout.EndHorizontal();
			GUILayout.Space(5f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Max Players: ", new GUILayoutOption[]
			{
				GUILayout.Width(130f)
			});
			for (int j = 0; j < this.maxPlayersOptions.Count; j++)
			{
				if (this.maxPlayers == this.maxPlayersOptions[j])
				{
					GUI.color = Color.green;
				}
				else
				{
					GUI.color = Color.white;
				}
				if (GUILayout.Button(this.maxPlayersOptions[j].ToString(), new GUILayoutOption[]
				{
					GUILayout.Width(27f),
					GUILayout.Height(25f)
				}))
				{
					this.maxPlayers = this.maxPlayersOptions[j];
				}
			}
			GUI.color = Color.white;
			GUILayout.EndHorizontal();
			GUILayout.Space(5f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Game Mode: ", new GUILayoutOption[]
			{
				GUILayout.Width(130f)
			});
			if (this.gameMode == "TDM")
			{
				GUI.color = Color.green;
			}
			if (GUILayout.Button(this.teamdeathmatch, new GUILayoutOption[]
			{
				GUILayout.Width(140f),
				GUILayout.Height(25f)
			}))
			{
				this.gameMode = "TDM";
			}
			GUI.color = Color.white;
			if (this.gameMode == "DM")
			{
				GUI.color = Color.green;
			}
			if (!this.hidedeathmatch && GUILayout.Button(this.deathmatch, new GUILayoutOption[]
			{
				GUILayout.Width(140f),
				GUILayout.Height(25f)
			}))
			{
				this.gameMode = "DM";
			}
			GUILayout.EndHorizontal();
			GUI.color = Color.white;
			GUILayout.Space(5f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			this.mapScroll = GUILayout.BeginScrollView(this.mapScroll, false, true, new GUILayoutOption[]
			{
				GUILayout.Width(240f),
				GUILayout.Height(160f)
			});
			for (int k = 0; k < this.allMaps.Count; k++)
			{
				if (this.selectedMap == k)
				{
					GUI.color = Color.green;
					if (this.allMaps[k].mapName.Contains("(Assault)"))
					{
						this.teamdeathmatch = "Assault";
						this.hidedeathmatch = true;
						this.gameMode = "TDM";
					}
					else
					{
						this.teamdeathmatch = "Team-DeathMatch";
						this.hidedeathmatch = false;
					}
				}
				else
				{
					GUI.color = Color.white;
				}
				if (GUILayout.Button(this.allMaps[k].mapName, new GUILayoutOption[]
				{
					GUILayout.Height(25f)
				}))
				{
					this.selectedMap = k;
				}
			}
			GUI.color = Color.white;
			GUILayout.EndScrollView();
			GUILayout.Space(10f);
			if (this.allMaps[this.selectedMap].mapPreview != null)
			{
				GUILayout.Label(this.allMaps[this.selectedMap].mapPreview, new GUILayoutOption[]
				{
					GUILayout.Width(230f),
					GUILayout.Height(160f)
				});
			}
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("Main Menu", new GUILayoutOption[]
			{
				GUILayout.Width(130f),
				GUILayout.Height(25f)
			}))
			{
				this.createRoom = false;
			}
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Continue", new GUILayoutOption[]
			{
				GUILayout.Width(130f),
				GUILayout.Height(25f)
			}))
			{
				this.CheckPlayerNameAndRoom();
				PhotonNetwork.player.name = this.playerName;
				Hashtable hashtable = new Hashtable();
				hashtable["MapName"] = this.allMaps[this.selectedMap].mapName;
				hashtable["RoundDuration"] = this.roundDuration;
				hashtable["GameMode"] = this.gameMode;
				string[] propsToListInLobby = new string[]
				{
					"MapName",
					"RoundDuration",
					"GameMode"
				};
				PhotonNetwork.CreateRoom(this.newRoomName, true, true, this.maxPlayers, hashtable, propsToListInLobby);
			}
			GUILayout.EndHorizontal();
		}
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00006620 File Offset: 0x00004A20
	private void FadeScreen()
	{
		if (this.connectingToRoom)
		{
			this.fadeDir = 1;
			this.fadeValue += (float)(this.fadeDir * 15) * Time.deltaTime;
			this.fadeValue = Mathf.Clamp01(this.fadeValue);
			GUI.color = new Color(1f, 1f, 1f, this.fadeValue);
			GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.blackScreen);
			GUI.color = Color.white;
			GUI.Label(new Rect((float)(Screen.width / 2 - 75), (float)(Screen.height / 2 - 15), 150f, 30f), "Loading...");
		}
	}

	// Token: 0x0600003F RID: 63 RVA: 0x000066EC File Offset: 0x00004AEC
	private IEnumerator LoadMap(string sceneName)
	{
		this.connectingToRoom = true;
		PhotonNetwork.isMessageQueueRunning = false;
		this.fadeDir = 1;
		yield return new WaitForSeconds(1f);
		Application.backgroundLoadingPriority = ThreadPriority.High;
		AsyncOperation async = Application.LoadLevelAsync(sceneName);
		yield return async;
		Debug.Log("Loading complete");
		yield break;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00006710 File Offset: 0x00004B10
	private void CheckPlayerNameAndRoom()
	{
		string a = this.playerName.Replace(" ", string.Empty);
		if (a == string.Empty)
		{
			this.playerName = "Player " + UnityEngine.Random.Range(111, 999);
		}
		string a2 = this.newRoomName.Replace(" ", string.Empty);
		if (a2 == string.Empty)
		{
			this.newRoomName = "Room Name " + UnityEngine.Random.Range(111, 999);
		}
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000067AC File Offset: 0x00004BAC
	private void OnJoinedRoom()
	{
		UnityEngine.MonoBehaviour.print("Joined room: " + this.newRoomName);
		this.connectingToRoom = true;
		if (!PhotonNetwork.offlineMode)
		{
			base.StartCoroutine(this.LoadMap((string)PhotonNetwork.room.customProperties["MapName"]));
		}
		else
		{
			base.StartCoroutine(this.LoadMap("storm the base"));
		}
	}

	// Token: 0x06000042 RID: 66 RVA: 0x0000681C File Offset: 0x00004C1C
	private void OnJoinedLobby()
	{
		UnityEngine.MonoBehaviour.print("Joined master server");
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00006828 File Offset: 0x00004C28
	private void OnLeftRoom()
	{
		this.connectingToRoom = false;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00006831 File Offset: 0x00004C31
	private void OnPhotonJoinRoomFailed()
	{
		UnityEngine.MonoBehaviour.print("Failed on connecting to room");
		this.connectingToRoom = false;
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00006844 File Offset: 0x00004C44
	private void OnPhotonCreateRoomFailed()
	{
		UnityEngine.MonoBehaviour.print("Failed on creating room");
		this.connectingToRoom = false;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00006857 File Offset: 0x00004C57
	private void OnPhotonPlayerConnected()
	{
		UnityEngine.MonoBehaviour.print("Player connected");
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00006863 File Offset: 0x00004C63
	private void OnConnectedToPhoton()
	{
		UnityEngine.MonoBehaviour.print("We connected to Photon Cloud");
		if (PhotonNetwork.room != null)
		{
			PhotonNetwork.LeaveRoom();
		}
		this.connectingToRoom = false;
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00006885 File Offset: 0x00004C85
	private void OnDisconnectedFromPhoton()
	{
		UnityEngine.MonoBehaviour.print("We disconencted from Photon Cloud");
	}

	// Token: 0x0400004E RID: 78
	public GUISkin guiSKin;

	// Token: 0x0400004F RID: 79
	public Texture blackScreen;

	// Token: 0x04000050 RID: 80
	public Texture top;

	// Token: 0x04000051 RID: 81
	public Texture bottom;

	// Token: 0x04000052 RID: 82
	public int roundDuration = 600;

	// Token: 0x04000053 RID: 83
	private List<int> maxPlayersOptions = new List<int>();

	// Token: 0x04000054 RID: 84
	public List<ConnectMenu.AllMaps> allMaps;

	// Token: 0x04000055 RID: 85
	private string newRoomName;

	// Token: 0x04000056 RID: 86
	private string playerName;

	// Token: 0x04000057 RID: 87
	private int maxPlayers;

	// Token: 0x04000058 RID: 88
	private int selectedMap;

	// Token: 0x04000059 RID: 89
	private string gameMode;

	// Token: 0x0400005A RID: 90
	private string deathmatch = "Free For All";

	// Token: 0x0400005B RID: 91
	private string teamdeathmatch = "Team-DeathMatch";

	// Token: 0x0400005C RID: 92
	private bool hidedeathmatch;

	// Token: 0x0400005D RID: 93
	private Vector2 scroll;

	// Token: 0x0400005E RID: 94
	private Vector2 mapScroll;

	// Token: 0x0400005F RID: 95
	private float fadeValue;

	// Token: 0x04000060 RID: 96
	private int fadeDir;

	// Token: 0x04000061 RID: 97
	private RoomInfo[] allRooms;

	// Token: 0x04000062 RID: 98
	private bool createRoom;

	// Token: 0x04000063 RID: 99
	private bool connectingToRoom;

	// Token: 0x02000012 RID: 18
	[Serializable]
	public class AllMaps
	{
		// Token: 0x04000064 RID: 100
		public string mapName;

		// Token: 0x04000065 RID: 101
		public Texture2D mapPreview;
	}
}
