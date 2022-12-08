using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x02000142 RID: 322
public static class PhotonNetwork
{
	// Token: 0x0600077D RID: 1917 RVA: 0x00048988 File Offset: 0x00046D88
	static PhotonNetwork()
	{
		Application.runInBackground = true;
		GameObject gameObject = new GameObject();
		PhotonNetwork.photonMono = gameObject.AddComponent<PhotonHandler>();
		gameObject.name = "PhotonMono";
		gameObject.hideFlags = HideFlags.HideInHierarchy;
		PhotonNetwork.networkingPeer = new NetworkingPeer(PhotonNetwork.photonMono, string.Empty, ConnectionProtocol.Udp);
		PhotonNetwork.networkingPeer.LimitOfUnreliableCommands = 40;
		CustomTypes.Register();
	}

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x0600077E RID: 1918 RVA: 0x00048A88 File Offset: 0x00046E88
	public static bool connected
	{
		get
		{
			return PhotonNetwork.offlineMode || PhotonNetwork.connectionState == ConnectionState.Connected;
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x0600077F RID: 1919 RVA: 0x00048AA0 File Offset: 0x00046EA0
	public static ConnectionState connectionState
	{
		get
		{
			if (PhotonNetwork.offlineMode)
			{
				return ConnectionState.Connected;
			}
			if (PhotonNetwork.networkingPeer == null)
			{
				return ConnectionState.Disconnected;
			}
			PeerStateValue peerState = PhotonNetwork.networkingPeer.PeerState;
			switch (peerState)
			{
			case PeerStateValue.Disconnected:
				return ConnectionState.Disconnected;
			case PeerStateValue.Connecting:
				return ConnectionState.Connecting;
			default:
				if (peerState != PeerStateValue.InitializingApplication)
				{
					return ConnectionState.Disconnected;
				}
				return ConnectionState.InitializingApplication;
			case PeerStateValue.Connected:
				return ConnectionState.Connected;
			case PeerStateValue.Disconnecting:
				return ConnectionState.Disconnecting;
			}
		}
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x06000780 RID: 1920 RVA: 0x00048B02 File Offset: 0x00046F02
	public static PeerState connectionStateDetailed
	{
		get
		{
			if (PhotonNetwork.offlineMode)
			{
				return PeerState.Connected;
			}
			if (PhotonNetwork.networkingPeer == null)
			{
				return PeerState.Disconnected;
			}
			return PhotonNetwork.networkingPeer.State;
		}
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x06000781 RID: 1921 RVA: 0x00048B27 File Offset: 0x00046F27
	public static Room room
	{
		get
		{
			if (!PhotonNetwork.isOfflineMode)
			{
				return PhotonNetwork.networkingPeer.mCurrentGame;
			}
			if (PhotonNetwork.offlineMode_inRoom)
			{
				return new Room("OfflineRoom", new Hashtable());
			}
			return null;
		}
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x06000782 RID: 1922 RVA: 0x00048B59 File Offset: 0x00046F59
	public static PhotonPlayer player
	{
		get
		{
			if (PhotonNetwork.networkingPeer == null)
			{
				return null;
			}
			return PhotonNetwork.networkingPeer.mLocalActor;
		}
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000783 RID: 1923 RVA: 0x00048B71 File Offset: 0x00046F71
	public static PhotonPlayer masterClient
	{
		get
		{
			if (PhotonNetwork.networkingPeer == null)
			{
				return null;
			}
			return PhotonNetwork.networkingPeer.mMasterClient;
		}
	}

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x06000784 RID: 1924 RVA: 0x00048B89 File Offset: 0x00046F89
	// (set) Token: 0x06000785 RID: 1925 RVA: 0x00048B95 File Offset: 0x00046F95
	public static string playerName
	{
		get
		{
			return PhotonNetwork.networkingPeer.PlayerName;
		}
		set
		{
			PhotonNetwork.networkingPeer.PlayerName = value;
		}
	}

	// Token: 0x1700004F RID: 79
	// (get) Token: 0x06000786 RID: 1926 RVA: 0x00048BA2 File Offset: 0x00046FA2
	public static PhotonPlayer[] playerList
	{
		get
		{
			if (PhotonNetwork.networkingPeer == null)
			{
				return new PhotonPlayer[0];
			}
			return PhotonNetwork.networkingPeer.mPlayerListCopy;
		}
	}

	// Token: 0x17000050 RID: 80
	// (get) Token: 0x06000787 RID: 1927 RVA: 0x00048BBF File Offset: 0x00046FBF
	public static PhotonPlayer[] otherPlayers
	{
		get
		{
			if (PhotonNetwork.networkingPeer == null)
			{
				return new PhotonPlayer[0];
			}
			return PhotonNetwork.networkingPeer.mOtherPlayerListCopy;
		}
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x06000788 RID: 1928 RVA: 0x00048BDC File Offset: 0x00046FDC
	// (set) Token: 0x06000789 RID: 1929 RVA: 0x00048BE4 File Offset: 0x00046FE4
	public static bool offlineMode
	{
		get
		{
			return PhotonNetwork.isOfflineMode;
		}
		set
		{
			if (value == PhotonNetwork.isOfflineMode)
			{
				return;
			}
			if (value && PhotonNetwork.connected)
			{
				Debug.LogError("Can't start OFFLINE mode while connected!");
			}
			else
			{
				PhotonNetwork.networkingPeer.Disconnect();
				PhotonNetwork.isOfflineMode = value;
				if (PhotonNetwork.isOfflineMode)
				{
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToPhoton, new object[0]);
					PhotonNetwork.networkingPeer.ChangeLocalID(1);
					PhotonNetwork.networkingPeer.mMasterClient = PhotonNetwork.player;
				}
				else
				{
					PhotonNetwork.networkingPeer.ChangeLocalID(-1);
					PhotonNetwork.networkingPeer.mMasterClient = null;
				}
			}
		}
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x0600078A RID: 1930 RVA: 0x00048C77 File Offset: 0x00047077
	// (set) Token: 0x0600078B RID: 1931 RVA: 0x00048C8F File Offset: 0x0004708F
	[Obsolete("Used for compatibility with Unity networking only.")]
	public static int maxConnections
	{
		get
		{
			if (PhotonNetwork.room == null)
			{
				return 0;
			}
			return PhotonNetwork.room.maxPlayers;
		}
		set
		{
			PhotonNetwork.room.maxPlayers = value;
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x0600078C RID: 1932 RVA: 0x00048C9C File Offset: 0x0004709C
	// (set) Token: 0x0600078D RID: 1933 RVA: 0x00048CA3 File Offset: 0x000470A3
	public static bool automaticallySyncScene
	{
		get
		{
			return PhotonNetwork._mAutomaticallySyncScene;
		}
		set
		{
			PhotonNetwork._mAutomaticallySyncScene = value;
			if (PhotonNetwork._mAutomaticallySyncScene && PhotonNetwork.room != null)
			{
				PhotonNetwork.networkingPeer.AutomaticallySyncScene();
			}
		}
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x0600078E RID: 1934 RVA: 0x00048CC9 File Offset: 0x000470C9
	// (set) Token: 0x0600078F RID: 1935 RVA: 0x00048CD0 File Offset: 0x000470D0
	public static bool autoCleanUpPlayerObjects
	{
		get
		{
			return PhotonNetwork.m_autoCleanUpPlayerObjects;
		}
		set
		{
			if (PhotonNetwork.room != null)
			{
				Debug.LogError("Setting autoCleanUpPlayerObjects while in a room is not supported.");
			}
			PhotonNetwork.m_autoCleanUpPlayerObjects = value;
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x06000790 RID: 1936 RVA: 0x00048CEC File Offset: 0x000470EC
	// (set) Token: 0x06000791 RID: 1937 RVA: 0x00048CF3 File Offset: 0x000470F3
	public static bool autoJoinLobby
	{
		get
		{
			return PhotonNetwork.autoJoinLobbyField;
		}
		set
		{
			PhotonNetwork.autoJoinLobbyField = value;
		}
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x06000792 RID: 1938 RVA: 0x00048CFB File Offset: 0x000470FB
	public static bool insideLobby
	{
		get
		{
			return PhotonNetwork.networkingPeer.insideLobby;
		}
	}

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x06000793 RID: 1939 RVA: 0x00048D07 File Offset: 0x00047107
	// (set) Token: 0x06000794 RID: 1940 RVA: 0x00048D14 File Offset: 0x00047114
	public static int sendRate
	{
		get
		{
			return 1000 / PhotonNetwork.sendInterval;
		}
		set
		{
			PhotonNetwork.sendInterval = 1000 / value;
			if (PhotonNetwork.photonMono != null)
			{
				PhotonNetwork.photonMono.updateInterval = PhotonNetwork.sendInterval;
			}
			if (value < PhotonNetwork.sendRateOnSerialize)
			{
				PhotonNetwork.sendRateOnSerialize = value;
			}
		}
	}

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x06000795 RID: 1941 RVA: 0x00048D52 File Offset: 0x00047152
	// (set) Token: 0x06000796 RID: 1942 RVA: 0x00048D60 File Offset: 0x00047160
	public static int sendRateOnSerialize
	{
		get
		{
			return 1000 / PhotonNetwork.sendIntervalOnSerialize;
		}
		set
		{
			if (value > PhotonNetwork.sendRate)
			{
				Debug.LogError("Error, can not set the OnSerialize SendRate more often then the overall SendRate");
				value = PhotonNetwork.sendRate;
			}
			PhotonNetwork.sendIntervalOnSerialize = 1000 / value;
			if (PhotonNetwork.photonMono != null)
			{
				PhotonNetwork.photonMono.updateIntervalOnSerialize = PhotonNetwork.sendIntervalOnSerialize;
			}
		}
	}

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x06000797 RID: 1943 RVA: 0x00048DB4 File Offset: 0x000471B4
	// (set) Token: 0x06000798 RID: 1944 RVA: 0x00048DBB File Offset: 0x000471BB
	public static bool isMessageQueueRunning
	{
		get
		{
			return PhotonNetwork.m_isMessageQueueRunning;
		}
		set
		{
			if (value == PhotonNetwork.m_isMessageQueueRunning)
			{
				return;
			}
			PhotonNetwork.networkingPeer.IsSendingOnlyAcks = !value;
			PhotonNetwork.m_isMessageQueueRunning = value;
			if (!value)
			{
				PhotonHandler.StartThread();
			}
		}
	}

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x06000799 RID: 1945 RVA: 0x00048DE8 File Offset: 0x000471E8
	// (set) Token: 0x0600079A RID: 1946 RVA: 0x00048DF4 File Offset: 0x000471F4
	public static int unreliableCommandsLimit
	{
		get
		{
			return PhotonNetwork.networkingPeer.LimitOfUnreliableCommands;
		}
		set
		{
			PhotonNetwork.networkingPeer.LimitOfUnreliableCommands = value;
		}
	}

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x0600079B RID: 1947 RVA: 0x00048E01 File Offset: 0x00047201
	public static double time
	{
		get
		{
			if (PhotonNetwork.offlineMode)
			{
				return (double)Time.time;
			}
			return PhotonNetwork.networkingPeer.ServerTimeInMilliSeconds / 1000.0;
		}
	}

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x0600079C RID: 1948 RVA: 0x00048E2A File Offset: 0x0004722A
	public static bool isMasterClient
	{
		get
		{
			return PhotonNetwork.offlineMode || PhotonNetwork.networkingPeer.mMasterClient == PhotonNetwork.networkingPeer.mLocalActor;
		}
	}

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x0600079D RID: 1949 RVA: 0x00048E4E File Offset: 0x0004724E
	public static bool isNonMasterClientInRoom
	{
		get
		{
			return !PhotonNetwork.isMasterClient && PhotonNetwork.room != null;
		}
	}

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x0600079E RID: 1950 RVA: 0x00048E68 File Offset: 0x00047268
	public static int countOfPlayersOnMaster
	{
		get
		{
			return PhotonNetwork.networkingPeer.mPlayersOnMasterCount;
		}
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x0600079F RID: 1951 RVA: 0x00048E74 File Offset: 0x00047274
	public static int countOfPlayersInRooms
	{
		get
		{
			return PhotonNetwork.networkingPeer.mPlayersInRoomsCount;
		}
	}

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x060007A0 RID: 1952 RVA: 0x00048E80 File Offset: 0x00047280
	public static int countOfPlayers
	{
		get
		{
			return PhotonNetwork.networkingPeer.mPlayersInRoomsCount + PhotonNetwork.networkingPeer.mPlayersOnMasterCount;
		}
	}

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x060007A1 RID: 1953 RVA: 0x00048E97 File Offset: 0x00047297
	public static int countOfRooms
	{
		get
		{
			if (PhotonNetwork.insideLobby)
			{
				return PhotonNetwork.GetRoomList().Length;
			}
			return PhotonNetwork.networkingPeer.mGameCount;
		}
	}

	// Token: 0x17000062 RID: 98
	// (get) Token: 0x060007A2 RID: 1954 RVA: 0x00048EB5 File Offset: 0x000472B5
	// (set) Token: 0x060007A3 RID: 1955 RVA: 0x00048EC1 File Offset: 0x000472C1
	public static bool NetworkStatisticsEnabled
	{
		get
		{
			return PhotonNetwork.networkingPeer.TrafficStatsEnabled;
		}
		set
		{
			PhotonNetwork.networkingPeer.TrafficStatsEnabled = value;
		}
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x00048ECE File Offset: 0x000472CE
	public static void NetworkStatisticsReset()
	{
		PhotonNetwork.networkingPeer.TrafficStatsReset();
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x00048EDA File Offset: 0x000472DA
	public static string NetworkStatisticsToString()
	{
		if (PhotonNetwork.networkingPeer == null || PhotonNetwork.offlineMode)
		{
			return "Offline or in OfflineMode. No VitalStats available.";
		}
		return PhotonNetwork.networkingPeer.VitalStatsToString(false);
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x00048F04 File Offset: 0x00047304
	public static void InternalCleanPhotonMonoFromSceneIfStuck()
	{
		PhotonHandler[] array = UnityEngine.Object.FindObjectsOfType(typeof(PhotonHandler)) as PhotonHandler[];
		if (array != null && array.Length > 0)
		{
			Debug.Log("Cleaning up hidden PhotonHandler instances in scene. Please save it. This is not an issue.");
			foreach (PhotonHandler photonHandler in array)
			{
				photonHandler.gameObject.hideFlags = HideFlags.None;
				if (photonHandler.gameObject != null && photonHandler.gameObject.name == "PhotonMono")
				{
					UnityEngine.Object.DestroyImmediate(photonHandler.gameObject);
				}
				UnityEngine.Object.DestroyImmediate(photonHandler);
			}
		}
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x00048FA4 File Offset: 0x000473A4
	public static void ConnectUsingSettings(string gameVersion)
	{
		if (PhotonNetwork.PhotonServerSettings == null)
		{
			Debug.LogError("Can't connect: Loading settings failed. ServerSettings asset must be in any 'Resources' folder as: PhotonServerSettings");
			return;
		}
		if (PhotonNetwork.PhotonServerSettings.HostType == ServerSettings.HostingOption.OfflineMode)
		{
			PhotonNetwork.offlineMode = true;
			return;
		}
		PhotonNetwork.Connect(PhotonNetwork.PhotonServerSettings.ServerAddress, PhotonNetwork.PhotonServerSettings.ServerPort, CryptoPlayerPrefs.GetString("serverid", string.Empty), gameVersion);
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x0004900C File Offset: 0x0004740C
	[Obsolete("This method is obsolete; use ConnectUsingSettings with the gameVersion argument instead")]
	public static void ConnectUsingSettings()
	{
		PhotonNetwork.ConnectUsingSettings("1.0");
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x00049018 File Offset: 0x00047418
	[Obsolete("This method is obsolete; use Connect with the gameVersion argument instead")]
	public static void Connect(string serverAddress, int port, string uniqueGameID)
	{
		PhotonNetwork.Connect(serverAddress, port, uniqueGameID, "1.0");
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x00049028 File Offset: 0x00047428
	public static void Connect(string serverAddress, int port, string appID, string gameVersion)
	{
		if (port <= 0)
		{
			Debug.LogError("Aborted Connect: invalid port: " + port);
			return;
		}
		if (serverAddress.Length <= 2)
		{
			Debug.LogError("Aborted Connect: invalid serverAddress: " + serverAddress);
			return;
		}
		if (PhotonNetwork.networkingPeer.PeerState != PeerStateValue.Disconnected)
		{
			Debug.LogWarning("Connect() only works when disconnected. Current state: " + PhotonNetwork.networkingPeer.PeerState);
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode = false;
			Debug.LogWarning("Shut down offline mode due to a connect attempt");
		}
		if (!PhotonNetwork.isMessageQueueRunning)
		{
			PhotonNetwork.isMessageQueueRunning = true;
			Debug.LogWarning("Forced enabling of isMessageQueueRunning because of a Connect()");
		}
		serverAddress = serverAddress + ":" + port;
		PhotonNetwork.networkingPeer.mAppVersion = gameVersion + "1.19";
		PhotonNetwork.networkingPeer.Connect(serverAddress, CryptoPlayerPrefs.GetString("serverid", string.Empty));
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x00049114 File Offset: 0x00047514
	public static void Disconnect()
	{
		if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode = false;
			PhotonNetwork.networkingPeer.State = PeerState.Disconnecting;
			PhotonNetwork.networkingPeer.OnStatusChanged(StatusCode.Disconnect);
			return;
		}
		if (PhotonNetwork.networkingPeer == null)
		{
			return;
		}
		PhotonNetwork.networkingPeer.Disconnect();
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x00049162 File Offset: 0x00047562
	[Obsolete("Used for compatibility with Unity networking only. Encryption is automatically initialized while connecting.")]
	public static void InitializeSecurity()
	{
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x00049164 File Offset: 0x00047564
	public static void CreateRoom(string roomName)
	{
		Debug.Log("this custom props " + PhotonNetwork.player.customProperties.ToStringFull());
		if (PhotonNetwork.connectionStateDetailed == PeerState.ConnectedToGameserver || PhotonNetwork.connectionStateDetailed == PeerState.Joining || PhotonNetwork.connectionStateDetailed == PeerState.Joined)
		{
			Debug.LogError("CreateRoom aborted: You are already connecting to a room!");
		}
		else if (PhotonNetwork.room != null)
		{
			Debug.LogError("CreateRoom aborted: You are already in a room!");
		}
		else if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode_inRoom = true;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnCreatedRoom, new object[0]);
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
		}
		else
		{
			PhotonNetwork.networkingPeer.OpCreateGame(roomName, true, true, 0, PhotonNetwork.autoCleanUpPlayerObjects, null, null);
		}
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x0004921F File Offset: 0x0004761F
	public static void CreateRoom(string roomName, bool isVisible, bool isOpen, int maxPlayers)
	{
		PhotonNetwork.CreateRoom(roomName, isVisible, isOpen, maxPlayers, null, null);
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x0004922C File Offset: 0x0004762C
	public static void CreateRoom(string roomName, bool isVisible, bool isOpen, int maxPlayers, Hashtable customRoomProperties, string[] propsToListInLobby)
	{
		if (PhotonNetwork.connectionStateDetailed == PeerState.Joining || PhotonNetwork.connectionStateDetailed == PeerState.Joined || PhotonNetwork.connectionStateDetailed == PeerState.ConnectedToGameserver)
		{
			Debug.LogError("CreateRoom aborted: You can only create a room while not currently connected/connecting to a room.");
		}
		else if (PhotonNetwork.room != null)
		{
			Debug.LogError("CreateRoom aborted: You are already in a room!");
		}
		else if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode_inRoom = true;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnCreatedRoom, new object[0]);
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
		}
		else
		{
			if (maxPlayers > 255)
			{
				Debug.LogError("Error: CreateRoom called with " + maxPlayers + " maxplayers. This has been reverted to the max of 255 players because internally a 'byte' is used.");
				maxPlayers = 255;
			}
			PhotonNetwork.networkingPeer.OpCreateGame(roomName, isVisible, isOpen, (byte)maxPlayers, PhotonNetwork.autoCleanUpPlayerObjects, customRoomProperties, propsToListInLobby);
		}
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x000492F8 File Offset: 0x000476F8
	public static void JoinRoom(RoomInfo listedRoom)
	{
		if (listedRoom == null)
		{
			Debug.LogError("JoinRoom aborted: you passed a NULL room");
			return;
		}
		PhotonNetwork.JoinRoom(listedRoom.name);
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x00049318 File Offset: 0x00047718
	public static void JoinRoom(string roomName)
	{
		if (PhotonNetwork.connectionStateDetailed == PeerState.Joining || PhotonNetwork.connectionStateDetailed == PeerState.Joined || PhotonNetwork.connectionStateDetailed == PeerState.ConnectedToGameserver)
		{
			Debug.LogError("JoinRoom aborted: You can only join a room while not currently connected/connecting to a room.");
		}
		else if (PhotonNetwork.room != null)
		{
			Debug.LogError("JoinRoom aborted: You are already in a room!");
		}
		else if (roomName == string.Empty)
		{
			Debug.LogError("JoinRoom aborted: You must specifiy a room name!");
		}
		else if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode_inRoom = true;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
		}
		else
		{
			PhotonNetwork.networkingPeer.OpJoin(roomName);
		}
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x000493BE File Offset: 0x000477BE
	public static void JoinRandomRoom()
	{
		PhotonNetwork.JoinRandomRoom(null, 0);
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x000493C7 File Offset: 0x000477C7
	public static void JoinRandomRoom(Hashtable expectedCustomRoomProperties, byte expectedMaxPlayers)
	{
		PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, expectedMaxPlayers, MatchmakingMode.FillRoom);
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x000493D4 File Offset: 0x000477D4
	public static void JoinRandomRoom(Hashtable expectedCustomRoomProperties, byte expectedMaxPlayers, MatchmakingMode matchingType)
	{
		if (PhotonNetwork.connectionStateDetailed == PeerState.Joining || PhotonNetwork.connectionStateDetailed == PeerState.Joined || PhotonNetwork.connectionStateDetailed == PeerState.ConnectedToGameserver)
		{
			Debug.LogError("JoinRandomRoom aborted: You can only join a room while not currently connected/connecting to a room.");
			return;
		}
		if (PhotonNetwork.room != null)
		{
			Debug.LogError("JoinRandomRoom aborted: You are already in a room!");
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode_inRoom = true;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
		}
		else
		{
			Hashtable hashtable = new Hashtable();
			hashtable.MergeStringKeys(expectedCustomRoomProperties);
			if (expectedMaxPlayers > 0)
			{
				hashtable[byte.MaxValue] = expectedMaxPlayers;
			}
			PhotonNetwork.networkingPeer.OpJoinRandomRoom(hashtable, 0, null, matchingType);
		}
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x00049480 File Offset: 0x00047880
	public static void LeaveRoom()
	{
		if (!PhotonNetwork.offlineMode && PhotonNetwork.connectionStateDetailed != PeerState.Joined)
		{
			Debug.LogError("PhotonNetwork: Error, you cannot leave a room if you're not in a room!(1)");
			return;
		}
		if (PhotonNetwork.room == null)
		{
			Debug.LogError("PhotonNetwork: Error, you cannot leave a room if you're not in a room!(2)");
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode_inRoom = false;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnLeftRoom, new object[0]);
		}
		else
		{
			PhotonNetwork.networkingPeer.OpLeave();
		}
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x000494EF File Offset: 0x000478EF
	public static RoomInfo[] GetRoomList()
	{
		if (PhotonNetwork.offlineMode)
		{
			return new RoomInfo[0];
		}
		if (PhotonNetwork.networkingPeer == null)
		{
			return new RoomInfo[0];
		}
		return PhotonNetwork.networkingPeer.mGameListCopy;
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x00049520 File Offset: 0x00047920
	public static void SetPlayerCustomProperties(Hashtable customProperties)
	{
		if (customProperties == null)
		{
			customProperties = new Hashtable();
			IEnumerator enumerator = PhotonNetwork.player.customProperties.Keys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					customProperties[(string)obj] = null;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		if (PhotonNetwork.room != null && PhotonNetwork.room.isLocalClientInside)
		{
			PhotonNetwork.player.SetCustomProperties(customProperties);
		}
		else
		{
			PhotonNetwork.player.InternalCacheProperties(customProperties);
		}
	}

	// Token: 0x060007B8 RID: 1976 RVA: 0x000495D0 File Offset: 0x000479D0
	public static int AllocateViewID()
	{
		int num = PhotonNetwork.AllocateViewID(PhotonNetwork.player.ID);
		PhotonNetwork.manuallyAllocatedViewIds.Add(num);
		return num;
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x000495FC File Offset: 0x000479FC
	public static void UnAllocateViewID(int viewID)
	{
		PhotonNetwork.manuallyAllocatedViewIds.Remove(viewID);
		if (PhotonNetwork.networkingPeer.photonViewList.ContainsKey(viewID))
		{
			Debug.LogWarning(string.Format("Unallocated manually used viewID: {0} but found it used still in a PhotonView: {1}", viewID, PhotonNetwork.networkingPeer.photonViewList[viewID]));
		}
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x00049650 File Offset: 0x00047A50
	private static int AllocateViewID(int ownerId)
	{
		if (ownerId == 0)
		{
			int num = PhotonNetwork.lastUsedViewSubIdStatic;
			int num2 = ownerId * PhotonNetwork.MAX_VIEW_IDS;
			for (int i = 1; i < PhotonNetwork.MAX_VIEW_IDS; i++)
			{
				num = (num + 1) % PhotonNetwork.MAX_VIEW_IDS;
				if (num != 0)
				{
					int num3 = num + num2;
					if (!PhotonNetwork.networkingPeer.photonViewList.ContainsKey(num3))
					{
						PhotonNetwork.lastUsedViewSubIdStatic = num;
						return num3;
					}
				}
			}
			throw new Exception(string.Format("AllocateViewID() failed. Room (user {0}) is out of subIds, as all room viewIDs are used.", ownerId));
		}
		int num4 = PhotonNetwork.lastUsedViewSubId;
		int num5 = ownerId * PhotonNetwork.MAX_VIEW_IDS;
		for (int j = 1; j < PhotonNetwork.MAX_VIEW_IDS; j++)
		{
			num4 = (num4 + 1) % PhotonNetwork.MAX_VIEW_IDS;
			if (num4 != 0)
			{
				int num6 = num4 + num5;
				if (!PhotonNetwork.networkingPeer.photonViewList.ContainsKey(num6) && !PhotonNetwork.manuallyAllocatedViewIds.Contains(num6))
				{
					PhotonNetwork.lastUsedViewSubId = num4;
					return num6;
				}
			}
		}
		throw new Exception(string.Format("AllocateViewID() failed. User {0} is out of subIds, as all viewIDs are used.", ownerId));
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x00049764 File Offset: 0x00047B64
	private static int[] AllocateSceneViewIDs(int countOfNewViews)
	{
		int[] array = new int[countOfNewViews];
		for (int i = 0; i < countOfNewViews; i++)
		{
			array[i] = PhotonNetwork.AllocateViewID(0);
		}
		return array;
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x00049794 File Offset: 0x00047B94
	public static GameObject Instantiate(string prefabName, Vector3 position, Quaternion rotation, int group)
	{
		return PhotonNetwork.Instantiate(prefabName, position, rotation, group, null);
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x000497A0 File Offset: 0x00047BA0
	public static GameObject Instantiate(string prefabName, Vector3 position, Quaternion rotation, int group, object[] data)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			Debug.LogError("PhotonNetwork error: Could not Instantiate the prefab [" + prefabName + "] as the game is not connected.");
			return null;
		}
		GameObject gameObject;
		if (!PhotonNetwork.UsePrefabCache || !PhotonNetwork.PrefabCache.TryGetValue(prefabName, out gameObject))
		{
			gameObject = (GameObject)Resources.Load(prefabName, typeof(GameObject));
			if (PhotonNetwork.UsePrefabCache)
			{
				PhotonNetwork.PrefabCache.Add(prefabName, gameObject);
			}
		}
		if (gameObject == null)
		{
			Debug.LogError("PhotonNetwork error: Could not Instantiate the prefab [" + prefabName + "]. Please verify you have this gameobject in a Resources folder (and not in a subfolder)");
			return null;
		}
		if (gameObject.GetComponent<PhotonView>() == null)
		{
			Debug.LogError("PhotonNetwork error: Could not Instantiate the prefab [" + prefabName + "] as it has no PhotonView attached to the root.");
			return null;
		}
		Component[] componentsInChildren = gameObject.GetComponentsInChildren<PhotonView>(true);
		int[] array = new int[componentsInChildren.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = PhotonNetwork.AllocateViewID(PhotonNetwork.player.ID);
		}
		Hashtable evData = PhotonNetwork.networkingPeer.SendInstantiate(prefabName, position, rotation, group, array, data, false);
		return PhotonNetwork.networkingPeer.DoInstantiate(evData, PhotonNetwork.networkingPeer.mLocalActor, gameObject);
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x000498C4 File Offset: 0x00047CC4
	public static GameObject InstantiateSceneObject(string prefabName, Vector3 position, Quaternion rotation, int group, object[] data)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return null;
		}
		if (!PhotonNetwork.isMasterClient)
		{
			Debug.LogError("PhotonNetwork error [InstantiateSceneObject]: Only the master client can Instantiate scene objects");
			return null;
		}
		GameObject gameObject;
		if (!PhotonNetwork.UsePrefabCache || !PhotonNetwork.PrefabCache.TryGetValue(prefabName, out gameObject))
		{
			gameObject = (GameObject)Resources.Load(prefabName, typeof(GameObject));
			if (PhotonNetwork.UsePrefabCache)
			{
				PhotonNetwork.PrefabCache.Add(prefabName, gameObject);
			}
		}
		if (gameObject == null)
		{
			Debug.LogError("PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [" + prefabName + "]. Please verify you have this gameobject in a Resources folder (and not in a subfolder)");
			return null;
		}
		if (gameObject.GetComponent<PhotonView>() == null)
		{
			Debug.LogError("PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [" + prefabName + "] as it has no PhotonView attached to the root.");
			return null;
		}
		Component[] photonViewsInChildren = gameObject.GetPhotonViewsInChildren();
		int[] array = PhotonNetwork.AllocateSceneViewIDs(photonViewsInChildren.Length);
		if (array == null)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [",
				prefabName,
				"] as no ViewIDs are free to use. Max is: ",
				PhotonNetwork.MAX_VIEW_IDS
			}));
			return null;
		}
		Hashtable evData = PhotonNetwork.networkingPeer.SendInstantiate(prefabName, position, rotation, group, array, data, true);
		return PhotonNetwork.networkingPeer.DoInstantiate(evData, PhotonNetwork.networkingPeer.mLocalActor, gameObject);
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x000499F8 File Offset: 0x00047DF8
	public static int GetPing()
	{
		return PhotonNetwork.networkingPeer.RoundTripTime;
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x00049A04 File Offset: 0x00047E04
	public static void SendOutgoingCommands()
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		while (PhotonNetwork.networkingPeer.SendOutgoingCommands())
		{
		}
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x00049A28 File Offset: 0x00047E28
	public static void CloseConnection(PhotonPlayer kickPlayer)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (!PhotonNetwork.player.isMasterClient)
		{
			Debug.LogError("CloseConnection: Only the masterclient can kick another player.");
		}
		if (kickPlayer == null)
		{
			Debug.LogError("CloseConnection: No such player connected!");
		}
		else
		{
			int[] targetActors = new int[]
			{
				kickPlayer.ID
			};
			PhotonNetwork.networkingPeer.OpRaiseEvent(203, null, true, 0, targetActors);
		}
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x00049A94 File Offset: 0x00047E94
	public static void Destroy(PhotonView view)
	{
		if (view != null && view.isMine)
		{
			if (view.instantiationId > 0)
			{
				PhotonNetwork.networkingPeer.DestroyPhotonView(view, false);
			}
			else
			{
				Debug.LogError("Use PhotonNetwork.Destroy(view) only on PhotonViews created with PhotonNetwork.Instantiate(). GameObject not destroyed: " + view.gameObject);
			}
		}
		else
		{
			Debug.LogError("Destroy: Could not destroy view ID [" + view + "]. Does not exist, or is not ours!");
		}
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x00049B04 File Offset: 0x00047F04
	public static void Destroy(GameObject go)
	{
		PhotonView component = go.GetComponent<PhotonView>();
		if (component == null)
		{
			Debug.LogError("Cannot call Destroy(GameObject go); on the gameobject \"" + go.name + "\" as it has no PhotonView attached.");
		}
		else if (component.isMine)
		{
			int instantiatedObjectsId = PhotonNetwork.networkingPeer.GetInstantiatedObjectsId(go);
			if (instantiatedObjectsId <= 0)
			{
				Debug.LogError("Use PhotonNetwork.Destroy() only on GameObjects created with PhotonNetwork.Instantiate(). GameObject not destroyed: " + go);
			}
			else
			{
				PhotonNetwork.networkingPeer.RemoveInstantiatedGO(go, false);
			}
		}
		else
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Cannot call Destroy(GameObject go); on the gameobject \"",
				go.name,
				"\" as we don't control it (Owner: ",
				component.owner,
				")."
			}));
		}
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x00049BC4 File Offset: 0x00047FC4
	public static void DestroyPlayerObjects(PhotonPlayer destroyPlayer)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (PhotonNetwork.player.isMasterClient || destroyPlayer == PhotonNetwork.player)
		{
			PhotonNetwork.networkingPeer.DestroyPlayerObjects(destroyPlayer, false);
		}
		else
		{
			Debug.LogError("Couldn't destroy objects for player \"" + destroyPlayer + "\" as we are not the masterclient.");
		}
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x00049C1C File Offset: 0x0004801C
	public static void RemoveAllInstantiatedObjects()
	{
		if (PhotonNetwork.isMasterClient)
		{
			PhotonNetwork.networkingPeer.RemoveAllInstantiatedObjects();
		}
		else
		{
			Debug.LogError("Couldn't call RemoveAllInstantiatedObjects as only the master client is allowed to call this.");
		}
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x00049C44 File Offset: 0x00048044
	public static void RemoveAllInstantiatedObjects(PhotonPlayer targetPlayer)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (PhotonNetwork.player.isMasterClient || targetPlayer == PhotonNetwork.player)
		{
			PhotonNetwork.networkingPeer.RemoveAllInstantiatedObjectsByPlayer(targetPlayer, false);
		}
		else
		{
			Debug.LogError("Couldn't RemoveAllInstantiatedObjects for player \"" + targetPlayer + "\" as only the master client or the player itself is allowed to call this.");
		}
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x00049C9C File Offset: 0x0004809C
	internal static void RPC(PhotonView view, string methodName, PhotonTargets target, params object[] parameters)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (PhotonNetwork.room == null)
		{
			Debug.LogWarning("Cannot send RPCs in Lobby! RPC dropped.");
			return;
		}
		if (PhotonNetwork.networkingPeer != null)
		{
			PhotonNetwork.networkingPeer.RPC(view, methodName, target, parameters);
		}
		else
		{
			Debug.LogWarning("Could not execute RPC " + methodName + ". Possible scene loading in progress?");
		}
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x00049CFC File Offset: 0x000480FC
	internal static void RPC(PhotonView view, string methodName, PhotonPlayer targetPlayer, params object[] parameters)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (PhotonNetwork.room == null)
		{
			Debug.LogWarning("Cannot send RPCs in Lobby, only processed locally");
			return;
		}
		if (PhotonNetwork.player == null)
		{
			Debug.LogError("Error; Sending RPC to player null! Aborted \"" + methodName + "\"");
		}
		if (PhotonNetwork.networkingPeer != null)
		{
			PhotonNetwork.networkingPeer.RPC(view, methodName, targetPlayer, parameters);
		}
		else
		{
			Debug.LogWarning("Could not execute RPC " + methodName + ". Possible scene loading in progress?");
		}
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x00049D7A File Offset: 0x0004817A
	public static void RemoveRPCs()
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.RemoveRPCs(PhotonNetwork.player);
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x00049D91 File Offset: 0x00048191
	public static void RemoveRPCs(PhotonPlayer targetPlayer)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (!targetPlayer.isLocal && !PhotonNetwork.isMasterClient)
		{
			Debug.LogError("Error; Only the MasterClient can call RemoveRPCs for other players.");
			return;
		}
		PhotonNetwork.networkingPeer.RemoveRPCs(targetPlayer.ID);
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x00049DCE File Offset: 0x000481CE
	public static void RemoveAllBufferedMessages()
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.RemoveAllBufferedMessages(PhotonNetwork.player);
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x00049DE5 File Offset: 0x000481E5
	public static void RemoveAllBufferedMessages(PhotonPlayer targetPlayer)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (!targetPlayer.isLocal && !PhotonNetwork.isMasterClient)
		{
			Debug.LogError("Error; Only the MasterClient can call RemoveAllBufferedMessages for other players.");
			return;
		}
		PhotonNetwork.networkingPeer.RemoveCompleteCacheOfPlayer(targetPlayer.ID);
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x00049E22 File Offset: 0x00048222
	public static void RemoveRPCs(PhotonView view)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.RemoveRPCs(view);
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x00049E3A File Offset: 0x0004823A
	public static void RemoveRPCsInGroup(int group)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.RemoveRPCsInGroup(group);
	}

	// Token: 0x060007CF RID: 1999 RVA: 0x00049E52 File Offset: 0x00048252
	public static void SetReceivingEnabled(int group, bool enabled)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.SetReceivingEnabled(group, enabled);
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x00049E6B File Offset: 0x0004826B
	public static void SetSendingEnabled(int group, bool enabled)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.SetSendingEnabled(group, enabled);
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x00049E84 File Offset: 0x00048284
	public static void SetLevelPrefix(short prefix)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.SetLevelPrefix(prefix);
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x00049E9C File Offset: 0x0004829C
	private static bool VerifyCanUseNetwork()
	{
		if (PhotonNetwork.networkingPeer != null && (PhotonNetwork.offlineMode || PhotonNetwork.connected))
		{
			return true;
		}
		Debug.LogError("Cannot send messages when not connected; Either connect to Photon OR use offline mode!");
		return false;
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x00049EC9 File Offset: 0x000482C9
	public static void LoadLevel(int levelNumber)
	{
		PhotonNetwork.isMessageQueueRunning = false;
		PhotonNetwork.networkingPeer.loadingLevelAndPausedNetwork = true;
		Application.LoadLevel(levelNumber);
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x00049EE2 File Offset: 0x000482E2
	public static void LoadLevel(string levelTitle)
	{
		PhotonNetwork.isMessageQueueRunning = false;
		PhotonNetwork.networkingPeer.loadingLevelAndPausedNetwork = true;
		Application.LoadLevel(levelTitle);
	}

	// Token: 0x040009E9 RID: 2537
	public const string versionPUN = "1.19";

	// Token: 0x040009EA RID: 2538
	internal static readonly PhotonHandler photonMono;

	// Token: 0x040009EB RID: 2539
	internal static readonly NetworkingPeer networkingPeer;

	// Token: 0x040009EC RID: 2540
	public static readonly int MAX_VIEW_IDS = 1000;

	// Token: 0x040009ED RID: 2541
	public const string serverSettingsAssetFile = "PhotonServerSettings";

	// Token: 0x040009EE RID: 2542
	public const string serverSettingsAssetPath = "Assets/Photon Unity Networking/Resources/PhotonServerSettings.asset";

	// Token: 0x040009EF RID: 2543
	internal static ServerSettings PhotonServerSettings = (ServerSettings)Resources.Load("PhotonServerSettings", typeof(ServerSettings));

	// Token: 0x040009F0 RID: 2544
	public static float precisionForVectorSynchronization = 9.9E-05f;

	// Token: 0x040009F1 RID: 2545
	public static float precisionForQuaternionSynchronization = 1f;

	// Token: 0x040009F2 RID: 2546
	public static float precisionForFloatSynchronization = 0.01f;

	// Token: 0x040009F3 RID: 2547
	public static PhotonLogLevel logLevel = PhotonLogLevel.ErrorsOnly;

	// Token: 0x040009F4 RID: 2548
	public static bool UsePrefabCache = true;

	// Token: 0x040009F5 RID: 2549
	public static Dictionary<string, GameObject> PrefabCache = new Dictionary<string, GameObject>();

	// Token: 0x040009F6 RID: 2550
	private static bool isOfflineMode = false;

	// Token: 0x040009F7 RID: 2551
	private static bool offlineMode_inRoom = false;

	// Token: 0x040009F8 RID: 2552
	private static bool _mAutomaticallySyncScene = false;

	// Token: 0x040009F9 RID: 2553
	private static bool m_autoCleanUpPlayerObjects = true;

	// Token: 0x040009FA RID: 2554
	private static bool autoJoinLobbyField = true;

	// Token: 0x040009FB RID: 2555
	private static int sendInterval = 50;

	// Token: 0x040009FC RID: 2556
	private static int sendIntervalOnSerialize = 100;

	// Token: 0x040009FD RID: 2557
	private static bool m_isMessageQueueRunning = true;

	// Token: 0x040009FE RID: 2558
	internal static int lastUsedViewSubId = 0;

	// Token: 0x040009FF RID: 2559
	internal static int lastUsedViewSubIdStatic = 0;

	// Token: 0x04000A00 RID: 2560
	internal static List<int> manuallyAllocatedViewIds = new List<int>();
}
