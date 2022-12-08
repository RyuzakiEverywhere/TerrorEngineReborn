using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;
using UnityEngine;

// Token: 0x02000138 RID: 312
internal class NetworkingPeer : LoadbalancingPeer, IPhotonPeerListener
{
	// Token: 0x060006E6 RID: 1766 RVA: 0x000436E8 File Offset: 0x00041AE8
	public NetworkingPeer(IPhotonPeerListener listener, string playername, ConnectionProtocol connectionProtocol) : base(listener, connectionProtocol)
	{
		base.Listener = this;
		this.externalListener = listener;
		this.PlayerName = playername;
		this.mLocalActor = new PhotonPlayer(true, -1, this.playername);
		this.AddNewPlayer(this.mLocalActor.ID, this.mLocalActor);
		this.rpcShortcuts = new Dictionary<string, int>(PhotonNetwork.PhotonServerSettings.RpcList.Count);
		for (int i = 0; i < PhotonNetwork.PhotonServerSettings.RpcList.Count; i++)
		{
			string key = PhotonNetwork.PhotonServerSettings.RpcList[i];
			this.rpcShortcuts[key] = i;
		}
		this.State = global::PeerState.PeerCreated;
	}

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x060006E7 RID: 1767 RVA: 0x00043834 File Offset: 0x00041C34
	// (set) Token: 0x060006E8 RID: 1768 RVA: 0x0004383C File Offset: 0x00041C3C
	public string PlayerName
	{
		get
		{
			return this.playername;
		}
		set
		{
			if (string.IsNullOrEmpty(value) || value.Equals(this.playername))
			{
				return;
			}
			if (this.mLocalActor != null)
			{
				this.mLocalActor.name = value;
			}
			this.playername = value;
			if (this.mCurrentGame != null)
			{
				this.SendPlayerName();
			}
		}
	}

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x060006E9 RID: 1769 RVA: 0x00043895 File Offset: 0x00041C95
	// (set) Token: 0x060006EA RID: 1770 RVA: 0x0004389D File Offset: 0x00041C9D
	public PeerState State { get; internal set; }

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x060006EB RID: 1771 RVA: 0x000438A6 File Offset: 0x00041CA6
	public Room mCurrentGame
	{
		get
		{
			if (this.mRoomToGetInto != null && this.mRoomToGetInto.isLocalClientInside)
			{
				return this.mRoomToGetInto;
			}
			return null;
		}
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x060006EC RID: 1772 RVA: 0x000438CB File Offset: 0x00041CCB
	// (set) Token: 0x060006ED RID: 1773 RVA: 0x000438D3 File Offset: 0x00041CD3
	internal Room mRoomToGetInto { get; set; }

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x060006EE RID: 1774 RVA: 0x000438DC File Offset: 0x00041CDC
	// (set) Token: 0x060006EF RID: 1775 RVA: 0x000438E4 File Offset: 0x00041CE4
	public PhotonPlayer mLocalActor { get; internal set; }

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x060006F0 RID: 1776 RVA: 0x000438ED File Offset: 0x00041CED
	// (set) Token: 0x060006F1 RID: 1777 RVA: 0x000438F5 File Offset: 0x00041CF5
	public string mGameserver { get; internal set; }

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x060006F2 RID: 1778 RVA: 0x000438FE File Offset: 0x00041CFE
	// (set) Token: 0x060006F3 RID: 1779 RVA: 0x00043906 File Offset: 0x00041D06
	public int mQueuePosition { get; internal set; }

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x060006F4 RID: 1780 RVA: 0x0004390F File Offset: 0x00041D0F
	// (set) Token: 0x060006F5 RID: 1781 RVA: 0x00043917 File Offset: 0x00041D17
	public int mPlayersOnMasterCount { get; internal set; }

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x060006F6 RID: 1782 RVA: 0x00043920 File Offset: 0x00041D20
	// (set) Token: 0x060006F7 RID: 1783 RVA: 0x00043928 File Offset: 0x00041D28
	public int mGameCount { get; internal set; }

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x060006F8 RID: 1784 RVA: 0x00043931 File Offset: 0x00041D31
	// (set) Token: 0x060006F9 RID: 1785 RVA: 0x00043939 File Offset: 0x00041D39
	public int mPlayersInRoomsCount { get; internal set; }

	// Token: 0x060006FA RID: 1786 RVA: 0x00043944 File Offset: 0x00041D44
	public override bool Connect(string serverAddress, string appID)
	{
		if (PhotonNetwork.connectionStateDetailed == global::PeerState.Disconnecting)
		{
			Debug.LogError("ERROR: Cannot connect to Photon while Disconnecting. Connection failed.");
			return false;
		}
		if (string.IsNullOrEmpty(this.masterServerAddress))
		{
			this.masterServerAddress = serverAddress;
		}
		this.mAppId = appID.Trim();
		bool flag = base.Connect(serverAddress, string.Empty);
		this.State = ((!flag) ? global::PeerState.Disconnected : global::PeerState.Connecting);
		return flag;
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x000439B0 File Offset: 0x00041DB0
	public override void Disconnect()
	{
		if (base.PeerState == PeerStateValue.Disconnected)
		{
			if (base.DebugOut >= DebugLevel.WARNING)
			{
				this.DebugReturn(DebugLevel.WARNING, string.Format("Can't execute Disconnect() while not connected. Nothing changed. State: {0}", this.State));
			}
			return;
		}
		base.Disconnect();
		this.State = global::PeerState.Disconnecting;
		this.LeftRoomCleanup();
		this.LeftLobbyCleanup();
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x00043A0B File Offset: 0x00041E0B
	private void DisconnectFromMaster()
	{
		base.Disconnect();
		this.State = global::PeerState.DisconnectingFromMasterserver;
		this.LeftLobbyCleanup();
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x00043A20 File Offset: 0x00041E20
	private void DisconnectFromGameServer()
	{
		base.Disconnect();
		this.State = global::PeerState.DisconnectingFromGameserver;
		this.LeftRoomCleanup();
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x00043A36 File Offset: 0x00041E36
	private void LeftLobbyCleanup()
	{
		if (!this.insideLobby)
		{
			return;
		}
		NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnLeftLobby, new object[0]);
		this.insideLobby = false;
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x00043A58 File Offset: 0x00041E58
	private void LeftRoomCleanup()
	{
		bool flag = this.mRoomToGetInto != null;
		bool flag2 = (this.mRoomToGetInto == null) ? PhotonNetwork.autoCleanUpPlayerObjects : this.mRoomToGetInto.autoCleanUp;
		this.mRoomToGetInto = null;
		this.mActors = new Dictionary<int, PhotonPlayer>();
		this.mPlayerListCopy = new PhotonPlayer[0];
		this.mOtherPlayerListCopy = new PhotonPlayer[0];
		this.mMasterClient = null;
		this.allowedReceivingGroups = new HashSet<int>();
		this.blockSendingGroups = new HashSet<int>();
		this.mGameList = new Dictionary<string, RoomInfo>();
		this.mGameListCopy = new RoomInfo[0];
		this.ChangeLocalID(-1);
		if (flag2)
		{
			List<GameObject> list = new List<GameObject>(this.instantiatedObjects.Values);
			foreach (PhotonView photonView in this.photonViewList.Values)
			{
				if (photonView != null && !photonView.isSceneView && photonView.gameObject != null)
				{
					list.Add(photonView.gameObject);
				}
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				GameObject gameObject = list[i];
				if (gameObject != null)
				{
					if (base.DebugOut >= DebugLevel.ALL)
					{
						this.DebugReturn(DebugLevel.ALL, "Network destroy Instantiated GO: " + gameObject.name);
					}
					this.DestroyGO(gameObject);
				}
			}
			this.instantiatedObjects = new Dictionary<int, GameObject>();
			PhotonNetwork.manuallyAllocatedViewIds = new List<int>();
			PhotonNetwork.lastUsedViewSubId = 0;
			PhotonNetwork.lastUsedViewSubIdStatic = 0;
		}
		if (flag)
		{
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnLeftRoom, new object[0]);
		}
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x00043C24 File Offset: 0x00042024
	private void DestroyGO(GameObject go)
	{
		PhotonView[] componentsInChildren = go.GetComponentsInChildren<PhotonView>();
		foreach (PhotonView photonView in componentsInChildren)
		{
			if (photonView != null)
			{
				photonView.destroyedByPhotonNetworkOrQuit = true;
				this.RemovePhotonView(photonView);
			}
		}
		UnityEngine.Object.Destroy(go);
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x00043C74 File Offset: 0x00042074
	private void readoutStandardProperties(Hashtable gameProperties, Hashtable pActorProperties, int targetActorNr)
	{
		if (this.mCurrentGame != null && gameProperties != null)
		{
			this.mCurrentGame.CacheProperties(gameProperties);
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonCustomRoomPropertiesChanged, new object[0]);
			if (PhotonNetwork.automaticallySyncScene)
			{
				this.AutomaticallySyncScene();
			}
		}
		if (pActorProperties != null && pActorProperties.Count > 0)
		{
			if (targetActorNr > 0)
			{
				PhotonPlayer playerWithID = this.GetPlayerWithID(targetActorNr);
				if (playerWithID != null)
				{
					playerWithID.InternalCacheProperties(this.GetActorPropertiesForActorNr(pActorProperties, targetActorNr));
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonPlayerPropertiesChanged, new object[]
					{
						playerWithID
					});
				}
			}
			else
			{
				IEnumerator enumerator = pActorProperties.Keys.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						int num = (int)obj;
						Hashtable hashtable = (Hashtable)pActorProperties[obj];
						string name = (string)hashtable[byte.MaxValue];
						PhotonPlayer photonPlayer = this.GetPlayerWithID(num);
						if (photonPlayer == null)
						{
							photonPlayer = new PhotonPlayer(false, num, name);
							this.AddNewPlayer(num, photonPlayer);
						}
						photonPlayer.InternalCacheProperties(hashtable);
						NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonPlayerPropertiesChanged, new object[]
						{
							photonPlayer
						});
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
		}
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x00043DC4 File Offset: 0x000421C4
	private void AddNewPlayer(int ID, PhotonPlayer player)
	{
		if (!this.mActors.ContainsKey(ID))
		{
			this.mActors[ID] = player;
			this.RebuildPlayerListCopies();
		}
		else
		{
			Debug.LogError("Adding player twice: " + ID);
		}
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x00043E04 File Offset: 0x00042204
	private void RemovePlayer(int ID, PhotonPlayer player)
	{
		this.mActors.Remove(ID);
		if (!player.isLocal)
		{
			this.RebuildPlayerListCopies();
		}
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x00043E24 File Offset: 0x00042224
	private void RebuildPlayerListCopies()
	{
		this.mPlayerListCopy = new PhotonPlayer[this.mActors.Count];
		this.mActors.Values.CopyTo(this.mPlayerListCopy, 0);
		List<PhotonPlayer> list = new List<PhotonPlayer>();
		foreach (PhotonPlayer photonPlayer in this.mPlayerListCopy)
		{
			if (!photonPlayer.isLocal)
			{
				list.Add(photonPlayer);
			}
		}
		this.mOtherPlayerListCopy = list.ToArray();
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x00043EA4 File Offset: 0x000422A4
	private void ResetPhotonViewsOnSerialize()
	{
		foreach (PhotonView photonView in this.photonViewList.Values)
		{
			photonView.lastOnSerializeDataSent = null;
		}
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x00043F08 File Offset: 0x00042308
	private void HandleEventLeave(int actorID)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, "HandleEventLeave actorNr: " + actorID);
		}
		if (actorID < 0 || !this.mActors.ContainsKey(actorID))
		{
			if (base.DebugOut >= DebugLevel.ERROR)
			{
				this.DebugReturn(DebugLevel.ERROR, string.Format("Received event Leave for unknown actorNumber: {0}", actorID));
			}
			return;
		}
		PhotonPlayer playerWithID = this.GetPlayerWithID(actorID);
		if (playerWithID == null)
		{
			Debug.LogError("Error: HandleEventLeave for actorID=" + actorID + " has no PhotonPlayer!");
		}
		if (this.mMasterClient != null && this.mMasterClient.ID == actorID)
		{
			this.mMasterClient = null;
		}
		this.CheckMasterClient(actorID);
		if (this.mCurrentGame != null && this.mCurrentGame.autoCleanUp)
		{
			this.DestroyPlayerObjects(playerWithID, true);
		}
		this.RemovePlayer(actorID, playerWithID);
		NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonPlayerDisconnected, new object[]
		{
			playerWithID
		});
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x00044004 File Offset: 0x00042404
	private void CheckMasterClient(int ignoreActorID)
	{
		int num = int.MaxValue;
		if (this.mMasterClient != null && this.mActors.ContainsKey(this.mMasterClient.ID))
		{
			return;
		}
		foreach (int num2 in this.mActors.Keys)
		{
			if (ignoreActorID == -1 || ignoreActorID != num2)
			{
				if (num2 < num)
				{
					num = num2;
				}
			}
		}
		if (this.mMasterClient == null || this.mMasterClient.ID != num)
		{
			this.mMasterClient = this.mActors[num];
			bool flag = ignoreActorID > 0;
			if (flag)
			{
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnMasterClientSwitched, new object[]
				{
					this.mMasterClient
				});
			}
		}
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x000440F8 File Offset: 0x000424F8
	private Hashtable GetActorPropertiesForActorNr(Hashtable actorProperties, int actorNr)
	{
		if (actorProperties.ContainsKey(actorNr))
		{
			return (Hashtable)actorProperties[actorNr];
		}
		return actorProperties;
	}

	// Token: 0x06000709 RID: 1801 RVA: 0x0004411E File Offset: 0x0004251E
	private PhotonPlayer GetPlayerWithID(int number)
	{
		if (this.mActors != null && this.mActors.ContainsKey(number))
		{
			return this.mActors[number];
		}
		return null;
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x0004414C File Offset: 0x0004254C
	private void SendPlayerName()
	{
		if (this.State == global::PeerState.Joining)
		{
			this.mPlayernameHasToBeUpdated = true;
			return;
		}
		if (this.mLocalActor != null)
		{
			this.mLocalActor.name = this.PlayerName;
			Hashtable hashtable = new Hashtable();
			hashtable[byte.MaxValue] = this.PlayerName;
			base.OpSetPropertiesOfActor(this.mLocalActor.ID, hashtable, true, 0);
			this.mPlayernameHasToBeUpdated = false;
		}
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x000441C4 File Offset: 0x000425C4
	private void GameEnteredOnGameServer(OperationResponse operationResponse)
	{
		if (operationResponse.ReturnCode != 0)
		{
			byte operationCode = operationResponse.OperationCode;
			if (operationCode != 227)
			{
				if (operationCode != 226)
				{
					if (operationCode == 225)
					{
						this.DebugReturn(DebugLevel.WARNING, "Join failed on GameServer. Changing back to MasterServer. Msg: " + operationResponse.DebugMessage);
						if (operationResponse.ReturnCode == 32758)
						{
							Debug.Log("Most likely the game became empty during the switch to GameServer.");
						}
						NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonRandomJoinFailed, new object[0]);
					}
				}
				else
				{
					this.DebugReturn(DebugLevel.WARNING, "Join failed on GameServer. Changing back to MasterServer. Msg: " + operationResponse.DebugMessage);
					if (operationResponse.ReturnCode == 32758)
					{
						Debug.Log("Most likely the game became empty during the switch to GameServer.");
					}
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonJoinRoomFailed, new object[0]);
				}
			}
			else
			{
				this.DebugReturn(DebugLevel.ERROR, "Create failed on GameServer. Changing back to MasterServer. Msg: " + operationResponse.DebugMessage);
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonCreateRoomFailed, new object[0]);
			}
			this.DisconnectFromGameServer();
			return;
		}
		this.State = global::PeerState.Joined;
		this.mRoomToGetInto.isLocalClientInside = true;
		Hashtable pActorProperties = (Hashtable)operationResponse[249];
		Hashtable gameProperties = (Hashtable)operationResponse[248];
		this.readoutStandardProperties(gameProperties, pActorProperties, 0);
		int newID = (int)operationResponse[254];
		this.ChangeLocalID(newID);
		this.CheckMasterClient(-1);
		if (this.mPlayernameHasToBeUpdated)
		{
			this.SendPlayerName();
		}
		byte operationCode2 = operationResponse.OperationCode;
		if (operationCode2 != 227)
		{
			if (operationCode2 != 226 && operationCode2 != 225)
			{
			}
		}
		else
		{
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnCreatedRoom, new object[0]);
		}
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x00044374 File Offset: 0x00042774
	private Hashtable GetLocalActorProperties()
	{
		if (PhotonNetwork.player != null)
		{
			return PhotonNetwork.player.allProperties;
		}
		Hashtable hashtable = new Hashtable();
		hashtable[byte.MaxValue] = this.PlayerName;
		return hashtable;
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x000443B4 File Offset: 0x000427B4
	public void ChangeLocalID(int newID)
	{
		if (this.mLocalActor == null)
		{
			Debug.LogWarning(string.Format("Local actor is null or not in mActors! mLocalActor: {0} mActors==null: {1} newID: {2}", this.mLocalActor, this.mActors == null, newID));
		}
		if (this.mActors.ContainsKey(this.mLocalActor.ID))
		{
			this.mActors.Remove(this.mLocalActor.ID);
		}
		this.mLocalActor.InternalChangeLocalID(newID);
		this.mActors[this.mLocalActor.ID] = this.mLocalActor;
		this.RebuildPlayerListCopies();
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x00044458 File Offset: 0x00042858
	public bool OpCreateGame(string gameID, bool isVisible, bool isOpen, byte maxPlayers, bool autoCleanUp, Hashtable customGameProperties, string[] propsListedInLobby)
	{
		this.mRoomToGetInto = new Room(gameID, customGameProperties, isVisible, isOpen, (int)maxPlayers, autoCleanUp, propsListedInLobby);
		return base.OpCreateRoom(gameID, isVisible, isOpen, maxPlayers, autoCleanUp, customGameProperties, this.GetLocalActorProperties(), propsListedInLobby);
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x00044492 File Offset: 0x00042892
	public bool OpJoin(string gameID)
	{
		this.mRoomToGetInto = new Room(gameID, null);
		return this.OpJoinRoom(gameID, this.GetLocalActorProperties());
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x000444AE File Offset: 0x000428AE
	public override bool OpJoinRandomRoom(Hashtable expectedCustomRoomProperties, byte expectedMaxPlayers, Hashtable playerProperties, MatchmakingMode matchingType)
	{
		this.mRoomToGetInto = new Room(null, null);
		return base.OpJoinRandomRoom(expectedCustomRoomProperties, expectedMaxPlayers, playerProperties, matchingType);
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x000444C8 File Offset: 0x000428C8
	public virtual bool OpLeave()
	{
		if (this.State != global::PeerState.Joined)
		{
			this.DebugReturn(DebugLevel.ERROR, "NetworkingPeer::leaveGame() - ERROR: no game is currently joined");
			return false;
		}
		return this.OpCustom(254, null, true, 0);
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x000444F3 File Offset: 0x000428F3
	public override bool OpRaiseEvent(byte eventCode, byte interestGroup, Hashtable evData, bool sendReliable, byte channelId)
	{
		return !PhotonNetwork.offlineMode && base.OpRaiseEvent(eventCode, interestGroup, evData, sendReliable, channelId);
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x0004450E File Offset: 0x0004290E
	public override bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId, int[] targetActors, EventCaching cache)
	{
		return !PhotonNetwork.offlineMode && base.OpRaiseEvent(eventCode, evData, sendReliable, channelId, targetActors, cache);
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x0004452B File Offset: 0x0004292B
	public override bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId, EventCaching cache, ReceiverGroup receivers)
	{
		return !PhotonNetwork.offlineMode && base.OpRaiseEvent(eventCode, evData, sendReliable, channelId, cache, receivers);
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x00044548 File Offset: 0x00042948
	public void DebugReturn(DebugLevel level, string message)
	{
		this.externalListener.DebugReturn(level, message);
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x00044558 File Offset: 0x00042958
	public void OnOperationResponse(OperationResponse operationResponse)
	{
		if (PhotonNetwork.networkingPeer.State == global::PeerState.Disconnecting)
		{
			if (base.DebugOut >= DebugLevel.INFO)
			{
				this.DebugReturn(DebugLevel.INFO, "OperationResponse ignored while disconnecting: " + operationResponse.OperationCode);
			}
			return;
		}
		if (operationResponse.ReturnCode == 0)
		{
			if (base.DebugOut >= DebugLevel.INFO)
			{
				this.DebugReturn(DebugLevel.INFO, operationResponse.ToString());
			}
		}
		else if (base.DebugOut >= DebugLevel.WARNING)
		{
			if (operationResponse.ReturnCode == -3)
			{
				this.DebugReturn(DebugLevel.WARNING, "Operation could not be executed yet. Wait for state JoinedLobby or ConnectedToMaster and their respective callbacks before calling OPs. Client must be authorized.");
			}
			this.DebugReturn(DebugLevel.WARNING, operationResponse.ToStringFull());
		}
		byte operationCode = operationResponse.OperationCode;
		switch (operationCode)
		{
		case 225:
			if (operationResponse.ReturnCode != 0)
			{
				if (operationResponse.ReturnCode == 32760)
				{
					this.DebugReturn(DebugLevel.WARNING, "JoinRandom failed: No open game. Client stays in lobby.");
				}
				else if (base.DebugOut >= DebugLevel.ERROR)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("JoinRandom failed: {0}.", operationResponse.ToStringFull()));
				}
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonRandomJoinFailed, new object[0]);
			}
			else
			{
				string name = (string)operationResponse[byte.MaxValue];
				this.mRoomToGetInto.name = name;
				this.mGameserver = (string)operationResponse[230];
				this.DisconnectFromMaster();
				this.mLastJoinType = JoinType.JoinRandomGame;
			}
			break;
		case 226:
			if (this.State != global::PeerState.Joining)
			{
				if (operationResponse.ReturnCode != 0)
				{
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonJoinRoomFailed, new object[0]);
					if (base.DebugOut >= DebugLevel.WARNING)
					{
						this.DebugReturn(DebugLevel.WARNING, string.Format("JoinRoom failed (room maybe closed by now). Client stays on masterserver: {0}. State: {1}", operationResponse.ToStringFull(), this.State));
					}
				}
				else
				{
					this.mGameserver = (string)operationResponse[230];
					this.DisconnectFromMaster();
					this.mLastJoinType = JoinType.JoinGame;
				}
			}
			else
			{
				this.GameEnteredOnGameServer(operationResponse);
			}
			break;
		case 227:
			if (this.State != global::PeerState.Joining)
			{
				if (operationResponse.ReturnCode != 0)
				{
					if (base.DebugOut >= DebugLevel.ERROR)
					{
						this.DebugReturn(DebugLevel.ERROR, string.Format("createGame failed, client stays on masterserver: {0}.", operationResponse.ToStringFull()));
					}
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonCreateRoomFailed, new object[0]);
				}
				else
				{
					string text = (string)operationResponse[byte.MaxValue];
					if (!string.IsNullOrEmpty(text))
					{
						this.mRoomToGetInto.name = text;
					}
					this.mGameserver = (string)operationResponse[230];
					this.DisconnectFromMaster();
					this.mLastJoinType = JoinType.CreateGame;
				}
			}
			else
			{
				this.GameEnteredOnGameServer(operationResponse);
			}
			break;
		case 228:
			this.State = global::PeerState.Authenticated;
			this.LeftLobbyCleanup();
			break;
		case 229:
			this.State = global::PeerState.JoinedLobby;
			this.insideLobby = true;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedLobby, new object[0]);
			break;
		case 230:
			if (operationResponse.ReturnCode != 0)
			{
				if (base.DebugOut >= DebugLevel.ERROR)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("Authentication failed: '{0}' Code: {1}", operationResponse.DebugMessage, operationResponse.ReturnCode));
				}
				if (operationResponse.ReturnCode == -2)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("If you host Photon yourself, make sure to start the 'Instance LoadBalancing'", new object[0]));
				}
				if (operationResponse.ReturnCode == 32767)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("The appId this client sent is unknown on the server (Cloud). Check settings. If using the Cloud, check account.", new object[0]));
				}
				this.Disconnect();
				this.State = global::PeerState.Disconnecting;
				if (operationResponse.ReturnCode == 32757)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("Currently, the limit of users is reached for this title. Try again later. Disconnecting", new object[0]));
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonMaxCccuReached, new object[0]);
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectionFail, new object[]
					{
						DisconnectCause.MaxCcuReached
					});
				}
				else if (operationResponse.ReturnCode == 32756)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("The used master server address is not available with the subscription currently used. Got to Photon Cloud Dashboard or change URL. Disconnecting", new object[0]));
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectionFail, new object[]
					{
						DisconnectCause.InvalidRegion
					});
				}
			}
			else if (this.State == global::PeerState.Connected || this.State == global::PeerState.ConnectedComingFromGameserver)
			{
				if (operationResponse.Parameters.ContainsKey(223))
				{
					this.mQueuePosition = (int)operationResponse[223];
					if (this.mQueuePosition > 0)
					{
						if (this.State == global::PeerState.ConnectedComingFromGameserver)
						{
							this.State = global::PeerState.QueuedComingFromGameserver;
						}
						else
						{
							this.State = global::PeerState.Queued;
						}
						break;
					}
				}
				if (PhotonNetwork.autoJoinLobby)
				{
					this.OpJoinLobby();
					this.State = global::PeerState.Authenticated;
				}
				else
				{
					this.State = global::PeerState.ConnectedToMaster;
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToMaster, new object[0]);
				}
			}
			else if (this.State == global::PeerState.ConnectedToGameserver)
			{
				this.State = global::PeerState.Joining;
				if (this.mLastJoinType == JoinType.JoinGame || this.mLastJoinType == JoinType.JoinRandomGame)
				{
					this.OpJoin(this.mRoomToGetInto.name);
				}
				else if (this.mLastJoinType == JoinType.CreateGame)
				{
					this.OpCreateGame(this.mRoomToGetInto.name, this.mRoomToGetInto.visible, this.mRoomToGetInto.open, (byte)this.mRoomToGetInto.maxPlayers, this.mRoomToGetInto.autoCleanUp, this.mRoomToGetInto.customProperties, this.mRoomToGetInto.propertiesListedInLobby);
				}
			}
			break;
		default:
			switch (operationCode)
			{
			case 251:
			{
				Hashtable pActorProperties = (Hashtable)operationResponse[249];
				Hashtable gameProperties = (Hashtable)operationResponse[248];
				this.readoutStandardProperties(gameProperties, pActorProperties, 0);
				break;
			}
			case 252:
				break;
			case 253:
				break;
			case 254:
				this.DisconnectFromGameServer();
				break;
			default:
				if (base.DebugOut >= DebugLevel.ERROR)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("operationResponse unhandled: {0}", operationResponse.ToString()));
				}
				break;
			}
			break;
		}
		this.externalListener.OnOperationResponse(operationResponse);
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x00044B54 File Offset: 0x00042F54
	public void OnStatusChanged(StatusCode statusCode)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, string.Format("OnStatusChanged: {0}", statusCode.ToString()));
		}
		switch (statusCode)
		{
		case StatusCode.SecurityExceptionOnConnect:
		case StatusCode.ExceptionOnConnect:
		{
			this.State = global::PeerState.PeerCreated;
			DisconnectCause disconnectCause = (DisconnectCause)statusCode;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnFailedToConnectToPhoton, new object[]
			{
				disconnectCause
			});
			goto IL_3F9;
		}
		case StatusCode.Connect:
			if (this.State == global::PeerState.ConnectingToGameserver)
			{
				if (base.DebugOut >= DebugLevel.ALL)
				{
					this.DebugReturn(DebugLevel.ALL, "Connected to gameserver.");
				}
				this.State = global::PeerState.ConnectedToGameserver;
			}
			else
			{
				if (base.DebugOut >= DebugLevel.ALL)
				{
					this.DebugReturn(DebugLevel.ALL, "Connected to masterserver.");
				}
				if (this.State == global::PeerState.Connecting)
				{
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToPhoton, new object[0]);
					this.State = global::PeerState.Connected;
				}
				else
				{
					this.State = global::PeerState.ConnectedComingFromGameserver;
				}
			}
			if (this.requestSecurity)
			{
				base.EstablishEncryption();
			}
			else if (!this.OpAuthenticate(this.mAppId, this.mAppVersion))
			{
				this.externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
			}
			goto IL_3F9;
		case StatusCode.Disconnect:
			if (this.State == global::PeerState.DisconnectingFromMasterserver)
			{
				if (this.Connect(this.mGameserver, this.mAppId))
				{
					this.State = global::PeerState.ConnectingToGameserver;
				}
			}
			else if (this.State == global::PeerState.DisconnectingFromGameserver)
			{
				if (this.Connect(this.masterServerAddress, this.mAppId))
				{
					this.State = global::PeerState.ConnectingToMasterserver;
				}
			}
			else
			{
				this.LeftRoomCleanup();
				this.State = global::PeerState.PeerCreated;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnDisconnectedFromPhoton, new object[0]);
			}
			goto IL_3F9;
		case StatusCode.Exception:
			if (this.State == global::PeerState.Connecting)
			{
				this.DebugReturn(DebugLevel.WARNING, "Exception while connecting to: " + base.ServerAddress + ". Check if the server is available.");
				if (base.ServerAddress == null || base.ServerAddress.StartsWith("127.0.0.1"))
				{
					this.DebugReturn(DebugLevel.WARNING, "The server address is 127.0.0.1 (localhost): Make sure the server is running on this machine. Android and iOS emulators have their own localhost.");
					if (base.ServerAddress == this.mGameserver)
					{
						this.DebugReturn(DebugLevel.WARNING, "This might be a misconfiguration in the game server config. You need to edit it to a (public) address.");
					}
				}
				this.State = global::PeerState.PeerCreated;
				DisconnectCause disconnectCause = (DisconnectCause)statusCode;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnFailedToConnectToPhoton, new object[]
				{
					disconnectCause
				});
			}
			else
			{
				this.State = global::PeerState.PeerCreated;
				DisconnectCause disconnectCause = (DisconnectCause)statusCode;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectionFail, new object[]
				{
					disconnectCause
				});
			}
			this.Disconnect();
			goto IL_3F9;
		case StatusCode.QueueOutgoingReliableWarning:
		case StatusCode.QueueOutgoingUnreliableWarning:
		case StatusCode.QueueOutgoingAcksWarning:
		case StatusCode.QueueSentWarning:
			goto IL_3F9;
		case StatusCode.SendError:
			goto IL_3F9;
		case StatusCode.InternalReceiveException:
		case StatusCode.TimeoutDisconnect:
		case StatusCode.DisconnectByServer:
		case StatusCode.DisconnectByServerUserLimit:
		case StatusCode.DisconnectByServerLogic:
			if (this.State == global::PeerState.Connecting)
			{
				this.DebugReturn(DebugLevel.WARNING, string.Concat(new object[]
				{
					statusCode,
					" while connecting to: ",
					base.ServerAddress,
					". Check if the server is available."
				}));
				this.State = global::PeerState.PeerCreated;
				DisconnectCause disconnectCause = (DisconnectCause)statusCode;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnFailedToConnectToPhoton, new object[]
				{
					disconnectCause
				});
			}
			else
			{
				this.State = global::PeerState.PeerCreated;
				DisconnectCause disconnectCause = (DisconnectCause)statusCode;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectionFail, new object[]
				{
					disconnectCause
				});
			}
			this.Disconnect();
			goto IL_3F9;
		case StatusCode.EncryptionEstablished:
			if (!this.OpAuthenticate(this.mAppId, this.mAppVersion))
			{
				this.externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
			}
			goto IL_3F9;
		case StatusCode.EncryptionFailedToEstablish:
			this.externalListener.DebugReturn(DebugLevel.ERROR, "Encryption wasn't established: " + statusCode + ". Going to authenticate anyways.");
			if (!this.OpAuthenticate(this.mAppId, this.mAppVersion))
			{
				this.externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
			}
			goto IL_3F9;
		}
		this.DebugReturn(DebugLevel.ERROR, "Received unknown status code: " + statusCode);
		IL_3F9:
		this.externalListener.OnStatusChanged(statusCode);
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x00044F68 File Offset: 0x00043368
	public void OnEvent(EventData photonEvent)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, string.Format("OnEvent: {0}", photonEvent.ToString()));
		}
		int num = -1;
		PhotonPlayer photonPlayer = null;
		if (photonEvent.Parameters.ContainsKey(254))
		{
			num = (int)photonEvent[254];
			if (this.mActors.ContainsKey(num))
			{
				photonPlayer = this.mActors[num];
			}
		}
		byte code = photonEvent.Code;
		switch (code)
		{
		case 200:
			this.ExecuteRPC(photonEvent[245] as Hashtable, photonPlayer);
			break;
		case 201:
		case 206:
		{
			Hashtable hashtable = (Hashtable)photonEvent[245];
			int networkTime = (int)hashtable[0];
			short correctPrefix = -1;
			short num2 = 1;
			if (hashtable.ContainsKey(1))
			{
				correctPrefix = (short)hashtable[1];
				num2 = 2;
			}
			short num3 = num2;
			while ((int)num3 < hashtable.Count)
			{
				this.OnSerializeRead(hashtable[num3] as Hashtable, photonPlayer, networkTime, correctPrefix);
				num3 += 1;
			}
			break;
		}
		case 202:
			this.DoInstantiate((Hashtable)photonEvent[245], photonPlayer, null);
			break;
		case 203:
			if (photonPlayer == null || !photonPlayer.isMasterClient)
			{
				Debug.LogError("Error: Someone else(" + photonPlayer + ") then the masterserver requests a disconnect!");
			}
			else
			{
				PhotonNetwork.LeaveRoom();
			}
			break;
		case 204:
		{
			Hashtable hashtable2 = (Hashtable)photonEvent[245];
			int num4 = (int)hashtable2[0];
			PhotonView photonView = this.GetPhotonView(num4);
			if (photonView == null || photonPlayer == null)
			{
				Debug.LogError(string.Concat(new object[]
				{
					"ERROR: Illegal destroy request on view ID=",
					num4,
					" from player/actorNr: ",
					num,
					" view=",
					photonView,
					"  orgPlayer=",
					photonPlayer
				}));
			}
			else
			{
				this.DestroyPhotonView(photonView, true);
			}
			break;
		}
		default:
			switch (code)
			{
			case 226:
				this.mPlayersInRoomsCount = (int)photonEvent[229];
				this.mPlayersOnMasterCount = (int)photonEvent[227];
				this.mGameCount = (int)photonEvent[228];
				break;
			default:
				switch (code)
				{
				case 253:
				{
					int num5 = (int)photonEvent[253];
					Hashtable gameProperties = null;
					Hashtable pActorProperties = null;
					if (num5 == 0)
					{
						gameProperties = (Hashtable)photonEvent[251];
					}
					else
					{
						pActorProperties = (Hashtable)photonEvent[251];
					}
					this.readoutStandardProperties(gameProperties, pActorProperties, num5);
					break;
				}
				case 254:
					this.HandleEventLeave(num);
					break;
				case 255:
				{
					Hashtable properties = (Hashtable)photonEvent[249];
					if (photonPlayer == null)
					{
						bool isLocal = this.mLocalActor.ID == num;
						this.AddNewPlayer(num, new PhotonPlayer(isLocal, num, properties));
						this.ResetPhotonViewsOnSerialize();
					}
					if (this.mActors[num] == this.mLocalActor)
					{
						int[] array = (int[])photonEvent[252];
						foreach (int num6 in array)
						{
							if (this.mLocalActor.ID != num6 && !this.mActors.ContainsKey(num6))
							{
								Debug.Log("creating player");
								this.AddNewPlayer(num6, new PhotonPlayer(false, num6, string.Empty));
							}
						}
						NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
					}
					else
					{
						NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonPlayerConnected, new object[]
						{
							this.mActors[num]
						});
					}
					break;
				}
				default:
					Debug.LogError("Error. Unhandled event: " + photonEvent);
					break;
				}
				break;
			case 228:
				if (photonEvent.Parameters.ContainsKey(223))
				{
					this.mQueuePosition = (int)photonEvent[223];
				}
				else
				{
					this.DebugReturn(DebugLevel.ERROR, "Event QueueState must contain position!");
				}
				if (this.mQueuePosition == 0)
				{
					if (PhotonNetwork.autoJoinLobby)
					{
						this.OpJoinLobby();
						this.State = global::PeerState.Authenticated;
					}
					else
					{
						this.State = global::PeerState.ConnectedToMaster;
						NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToMaster, new object[0]);
					}
				}
				break;
			case 229:
			{
				Hashtable hashtable3 = (Hashtable)photonEvent[222];
				IDictionaryEnumerator enumerator = hashtable3.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						string text = (string)dictionaryEntry.Key;
						Room room = new Room(text, (Hashtable)dictionaryEntry.Value);
						if (room.removedFromList)
						{
							this.mGameList.Remove(text);
						}
						else
						{
							this.mGameList[text] = room;
						}
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
				this.mGameListCopy = new RoomInfo[this.mGameList.Count];
				this.mGameList.Values.CopyTo(this.mGameListCopy, 0);
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnReceivedRoomListUpdate, new object[0]);
				break;
			}
			case 230:
			{
				this.mGameList = new Dictionary<string, RoomInfo>();
				Hashtable hashtable4 = (Hashtable)photonEvent[222];
				IDictionaryEnumerator enumerator2 = hashtable4.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
						string text2 = (string)dictionaryEntry2.Key;
						this.mGameList[text2] = new RoomInfo(text2, (Hashtable)dictionaryEntry2.Value);
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				this.mGameListCopy = new RoomInfo[this.mGameList.Count];
				this.mGameList.Values.CopyTo(this.mGameListCopy, 0);
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnReceivedRoomListUpdate, new object[0]);
				break;
			}
			}
			break;
		}
		this.externalListener.OnEvent(photonEvent);
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x00045610 File Offset: 0x00043A10
	public static void SendMonoMessage(PhotonNetworkingMessage methodString, params object[] parameters)
	{
		HashSet<GameObject> hashSet = new HashSet<GameObject>();
		foreach (MonoBehaviour monoBehaviour in (MonoBehaviour[])UnityEngine.Object.FindObjectsOfType(typeof(MonoBehaviour)))
		{
			if (!hashSet.Contains(monoBehaviour.gameObject))
			{
				hashSet.Add(monoBehaviour.gameObject);
				if (parameters != null && parameters.Length == 1)
				{
					monoBehaviour.SendMessage(methodString.ToString(), parameters[0], SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					monoBehaviour.SendMessage(methodString.ToString(), parameters, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x000456B0 File Offset: 0x00043AB0
	public void ExecuteRPC(Hashtable rpcData, PhotonPlayer sender)
	{
		if (rpcData == null || !rpcData.ContainsKey(0))
		{
			this.DebugReturn(DebugLevel.ERROR, "Malformed RPC; this should never occur.");
			return;
		}
		int num = (int)rpcData[0];
		int num2 = 0;
		if (rpcData.ContainsKey(1))
		{
			num2 = (int)((short)rpcData[1]);
		}
		string text;
		if (rpcData.ContainsKey(5))
		{
			int num3 = (int)((byte)rpcData[5]);
			if (num3 > PhotonNetwork.PhotonServerSettings.RpcList.Count - 1)
			{
				Debug.LogError("Could not find RPC with index: " + num3 + ". Going to ignore! Check PhotonServerSettings.RpcList");
				return;
			}
			text = PhotonNetwork.PhotonServerSettings.RpcList[num3];
		}
		else
		{
			text = (string)rpcData[3];
		}
		object[] array = null;
		if (rpcData.ContainsKey(4))
		{
			array = (object[])rpcData[4];
		}
		if (array == null)
		{
			array = new object[0];
		}
		PhotonView photonView = this.GetPhotonView(num);
		if (photonView == null)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Received RPC \"",
				text,
				"\" for viewID ",
				num,
				" but this PhotonView does not exist!"
			}));
			return;
		}
		if (photonView.prefix != num2)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Received RPC \"",
				text,
				"\" on viewID ",
				num,
				" with a prefix of ",
				num2,
				", our prefix is ",
				photonView.prefix,
				". The RPC has been ignored."
			}));
			return;
		}
		if (text == string.Empty)
		{
			this.DebugReturn(DebugLevel.ERROR, "Malformed RPC; this should never occur.");
			return;
		}
		if (base.DebugOut >= DebugLevel.ALL)
		{
			this.DebugReturn(DebugLevel.ALL, "Received RPC; " + text);
		}
		if (photonView.group != 0 && !this.allowedReceivingGroups.Contains(photonView.group))
		{
			return;
		}
		Type[] array2 = Type.EmptyTypes;
		if (array.Length > 0)
		{
			array2 = new Type[array.Length];
			int num4 = 0;
			foreach (object obj in array)
			{
				if (obj == null)
				{
					array2[num4] = null;
				}
				else
				{
					array2[num4] = obj.GetType();
				}
				num4++;
			}
		}
		int num5 = 0;
		int num6 = 0;
		foreach (MonoBehaviour monoBehaviour in photonView.GetComponents<MonoBehaviour>())
		{
			if (monoBehaviour == null)
			{
				Debug.LogError("ERROR You have missing MonoBehaviours on your gameobjects!");
			}
			else
			{
				Type type = monoBehaviour.GetType();
				List<MethodInfo> list = null;
				if (this.monoRPCMethodsCache.ContainsKey(type))
				{
					list = this.monoRPCMethodsCache[type];
				}
				if (list == null)
				{
					List<MethodInfo> list2 = new List<MethodInfo>();
					MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					for (int k = 0; k < methods.Length; k++)
					{
						if (methods[k].IsDefined(typeof(RPC), false))
						{
							list2.Add(methods[k]);
						}
					}
					this.monoRPCMethodsCache[type] = list2;
					list = list2;
				}
				if (list != null)
				{
					for (int l = 0; l < list.Count; l++)
					{
						MethodInfo methodInfo = list[l];
						if (methodInfo.Name == text)
						{
							num6++;
							ParameterInfo[] parameters = methodInfo.GetParameters();
							if (parameters.Length == array2.Length)
							{
								if (this.CheckTypeMatch(parameters, array2))
								{
									num5++;
									object obj2 = methodInfo.Invoke(monoBehaviour, array);
									if (methodInfo.ReturnType == typeof(IEnumerator))
									{
										monoBehaviour.StartCoroutine((IEnumerator)obj2);
									}
								}
							}
							else if (parameters.Length - 1 == array2.Length)
							{
								if (this.CheckTypeMatch(parameters, array2) && parameters[parameters.Length - 1].ParameterType == typeof(PhotonMessageInfo))
								{
									num5++;
									int timestamp = (int)rpcData[2];
									object[] array3 = new object[array.Length + 1];
									array.CopyTo(array3, 0);
									array3[array3.Length - 1] = new PhotonMessageInfo(sender, timestamp, photonView);
									object obj3 = methodInfo.Invoke(monoBehaviour, array3);
									if (methodInfo.ReturnType == typeof(IEnumerator))
									{
										monoBehaviour.StartCoroutine((IEnumerator)obj3);
									}
								}
							}
							else if (parameters.Length == 1 && parameters[0].ParameterType.IsArray)
							{
								num5++;
								object obj4 = methodInfo.Invoke(monoBehaviour, new object[]
								{
									array
								});
								if (methodInfo.ReturnType == typeof(IEnumerator))
								{
									monoBehaviour.StartCoroutine((IEnumerator)obj4);
								}
							}
						}
					}
				}
			}
		}
		if (num5 != 1)
		{
			string text2 = string.Empty;
			foreach (Type type2 in array2)
			{
				if (text2 != string.Empty)
				{
					text2 += ", ";
				}
				if (type2 == null)
				{
					text2 += "null";
				}
				else
				{
					text2 += type2.Name;
				}
			}
			if (num5 == 0)
			{
				if (num6 == 0)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Concat(new object[]
					{
						"PhotonView with ID ",
						num,
						" has no method \"",
						text,
						"\" marked with the [RPC](C#) or @RPC(JS) property! Args: ",
						text2
					}));
				}
				else
				{
					this.DebugReturn(DebugLevel.ERROR, string.Concat(new object[]
					{
						"PhotonView with ID ",
						num,
						" has no method \"",
						text,
						"\" that takes ",
						array2.Length,
						" argument(s): ",
						text2
					}));
				}
			}
			else
			{
				this.DebugReturn(DebugLevel.ERROR, string.Concat(new object[]
				{
					"PhotonView with ID ",
					num,
					" has ",
					num5,
					" methods \"",
					text,
					"\" that takes ",
					array2.Length,
					" argument(s): ",
					text2,
					". Should be just one?"
				}));
			}
		}
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x00045D74 File Offset: 0x00044174
	private bool CheckTypeMatch(ParameterInfo[] parameters, Type[] types)
	{
		if (parameters.Length < types.Length)
		{
			return false;
		}
		int num = 0;
		foreach (Type type in types)
		{
			if (type != null && parameters[num].ParameterType != type)
			{
				return false;
			}
			num++;
		}
		return true;
	}

	// Token: 0x0600071C RID: 1820 RVA: 0x00045DC4 File Offset: 0x000441C4
	internal Hashtable SendInstantiate(string prefabName, Vector3 position, Quaternion rotation, int group, int[] viewIDs, object[] data, bool isGlobalObject)
	{
		int num = viewIDs[0];
		Hashtable hashtable = new Hashtable();
		hashtable[0] = prefabName;
		if (position != Vector3.zero)
		{
			hashtable[1] = position;
		}
		if (rotation != Quaternion.identity)
		{
			hashtable[2] = rotation;
		}
		if (group != 0)
		{
			hashtable[3] = group;
		}
		if (viewIDs.Length > 1)
		{
			hashtable[4] = viewIDs;
		}
		if (data != null)
		{
			hashtable[5] = data;
		}
		if (this.currentLevelPrefix > 0)
		{
			hashtable[8] = this.currentLevelPrefix;
		}
		hashtable[6] = base.ServerTimeInMilliSeconds;
		hashtable[7] = num;
		EventCaching cache = (!isGlobalObject) ? EventCaching.AddToRoomCache : EventCaching.AddToRoomCacheGlobal;
		this.OpRaiseEvent(202, hashtable, true, 0, cache, ReceiverGroup.Others);
		return hashtable;
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x00045EE4 File Offset: 0x000442E4
	internal GameObject DoInstantiate(Hashtable evData, PhotonPlayer photonPlayer, GameObject resourceGameObject)
	{
		string text = (string)evData[0];
		int timestamp = (int)evData[6];
		int num = (int)evData[7];
		Vector3 position;
		if (evData.ContainsKey(1))
		{
			position = (Vector3)evData[1];
		}
		else
		{
			position = Vector3.zero;
		}
		Quaternion rotation = Quaternion.identity;
		if (evData.ContainsKey(2))
		{
			rotation = (Quaternion)evData[2];
		}
		int num2 = 0;
		if (evData.ContainsKey(3))
		{
			num2 = (int)evData[3];
		}
		short prefix = 0;
		if (evData.ContainsKey(8))
		{
			prefix = (short)evData[8];
		}
		int[] array;
		if (evData.ContainsKey(4))
		{
			array = (int[])evData[4];
		}
		else
		{
			array = new int[]
			{
				num
			};
		}
		object[] instantiationData;
		if (evData.ContainsKey(5))
		{
			instantiationData = (object[])evData[5];
		}
		else
		{
			instantiationData = null;
		}
		if (num2 != 0 && !this.allowedReceivingGroups.Contains(num2))
		{
			return null;
		}
		if (resourceGameObject == null)
		{
			if (!NetworkingPeer.UsePrefabCache || !NetworkingPeer.PrefabCache.TryGetValue(text, out resourceGameObject))
			{
				resourceGameObject = (GameObject)Resources.Load(text, typeof(GameObject));
				if (NetworkingPeer.UsePrefabCache)
				{
					NetworkingPeer.PrefabCache.Add(text, resourceGameObject);
				}
			}
			if (resourceGameObject == null)
			{
				Debug.LogError("PhotonNetwork error: Could not Instantiate the prefab [" + text + "]. Please verify you have this gameobject in a Resources folder.");
				return null;
			}
		}
		PhotonView[] photonViewsInChildren = resourceGameObject.GetPhotonViewsInChildren();
		if (photonViewsInChildren.Length != array.Length)
		{
			throw new Exception("Error in Instantiation! The resource's PhotonView count is not the same as in incoming data.");
		}
		for (int i = 0; i < array.Length; i++)
		{
			photonViewsInChildren[i].viewID = array[i];
			photonViewsInChildren[i].prefix = (int)prefix;
			photonViewsInChildren[i].instantiationId = num;
		}
		this.StoreInstantiationData(num, instantiationData);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(resourceGameObject, position, rotation);
		for (int j = 0; j < array.Length; j++)
		{
			photonViewsInChildren[j].viewID = 0;
			photonViewsInChildren[j].prefix = -1;
			photonViewsInChildren[j].prefixBackup = -1;
			photonViewsInChildren[j].instantiationId = -1;
		}
		this.RemoveInstantiationData(num);
		if (this.instantiatedObjects.ContainsKey(num))
		{
			GameObject gameObject2 = this.instantiatedObjects[num];
			string text2 = string.Empty;
			if (gameObject2 != null)
			{
				PhotonView[] photonViewsInChildren2 = gameObject2.GetPhotonViewsInChildren();
				foreach (PhotonView photonView in photonViewsInChildren2)
				{
					if (!(photonView == null))
					{
						text2 = text2 + photonView.ToString() + ", ";
					}
				}
			}
			Debug.LogError(string.Format("Adding GO \"{0}\" (instantiationID: {1}) to instantiatedObjects failed. instantiatedObjects.Count: {2}. Object taking the same place: {3}. Views on it: {4}. PhotonNetwork.lastUsedViewSubId: {5} PhotonNetwork.lastUsedViewSubIdStatic: {6} this.photonViewList.Count {7}.)", new object[]
			{
				gameObject,
				num,
				this.instantiatedObjects.Count,
				gameObject2,
				text2,
				PhotonNetwork.lastUsedViewSubId,
				PhotonNetwork.lastUsedViewSubIdStatic,
				this.photonViewList.Count
			}));
		}
		this.instantiatedObjects.Add(num, gameObject);
		object[] parameters = new object[]
		{
			new PhotonMessageInfo(photonPlayer, timestamp, null)
		};
		foreach (MonoBehaviour monoBehaviour in gameObject.GetComponentsInChildren<MonoBehaviour>())
		{
			MethodInfo cachedMethod = this.GetCachedMethod(monoBehaviour, PhotonNetworkingMessage.OnPhotonInstantiate);
			if (cachedMethod != null)
			{
				object obj = cachedMethod.Invoke(monoBehaviour, parameters);
				if (cachedMethod.ReturnType == typeof(IEnumerator))
				{
					monoBehaviour.StartCoroutine((IEnumerator)obj);
				}
			}
		}
		return gameObject;
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x00046307 File Offset: 0x00044707
	private void StoreInstantiationData(int instantiationId, object[] instantiationData)
	{
		this.tempInstantiationData[instantiationId] = instantiationData;
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x00046318 File Offset: 0x00044718
	public object[] FetchInstantiationData(int instantiationId)
	{
		object[] result = null;
		if (instantiationId == 0)
		{
			return null;
		}
		this.tempInstantiationData.TryGetValue(instantiationId, out result);
		return result;
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x0004633F File Offset: 0x0004473F
	private void RemoveInstantiationData(int instantiationId)
	{
		this.tempInstantiationData.Remove(instantiationId);
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x00046350 File Offset: 0x00044750
	public void RemoveAllInstantiatedObjects()
	{
		GameObject[] array = new GameObject[this.instantiatedObjects.Count];
		this.instantiatedObjects.Values.CopyTo(array, 0);
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject == null))
			{
				this.RemoveInstantiatedGO(gameObject, false);
			}
		}
		if (this.instantiatedObjects.Count > 0)
		{
			Debug.LogError("RemoveAllInstantiatedObjects() this.instantiatedObjects.Count should be 0 by now.");
		}
		this.instantiatedObjects = new Dictionary<int, GameObject>();
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x000463D8 File Offset: 0x000447D8
	public void RemoveAllInstantiatedObjectsByPlayer(PhotonPlayer player, bool localOnly)
	{
		GameObject[] array = new GameObject[this.instantiatedObjects.Count];
		this.instantiatedObjects.Values.CopyTo(array, 0);
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject == null))
			{
				PhotonView[] componentsInChildren = gameObject.GetComponentsInChildren<PhotonView>();
				for (int j = componentsInChildren.Length - 1; j >= 0; j--)
				{
					PhotonView photonView = componentsInChildren[j];
					if (photonView.OwnerActorNr == player.ID)
					{
						this.RemoveInstantiatedGO(gameObject, localOnly);
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000723 RID: 1827 RVA: 0x00046478 File Offset: 0x00044878
	public void RemoveInstantiatedGO(GameObject go, bool localOnly)
	{
		if (go == null)
		{
			if (base.DebugOut == DebugLevel.ERROR)
			{
				this.DebugReturn(DebugLevel.ERROR, "Can't remove instantiated GO if it's null.");
			}
			return;
		}
		int instantiatedObjectsId = this.GetInstantiatedObjectsId(go);
		if (instantiatedObjectsId == -1)
		{
			if (base.DebugOut == DebugLevel.ERROR)
			{
				this.DebugReturn(DebugLevel.ERROR, "Can't find GO in instantiation list. Object: " + go);
			}
			return;
		}
		this.instantiatedObjects.Remove(instantiatedObjectsId);
		PhotonView[] componentsInChildren = go.GetComponentsInChildren<PhotonView>();
		bool flag = false;
		for (int i = componentsInChildren.Length - 1; i >= 0; i--)
		{
			PhotonView photonView = componentsInChildren[i];
			if (!(photonView == null))
			{
				if (!flag)
				{
					int ownerActorNr = photonView.OwnerActorNr;
					this.RemoveFromServerInstantiationCache(instantiatedObjectsId, ownerActorNr);
					flag = true;
				}
				this.DestroyPhotonView(photonView, localOnly);
			}
		}
		if (base.DebugOut >= DebugLevel.ALL)
		{
			this.DebugReturn(DebugLevel.ALL, "Network destroy Instantiated GO: " + go.name);
		}
		this.DestroyGO(go);
	}

	// Token: 0x06000724 RID: 1828 RVA: 0x00046568 File Offset: 0x00044968
	public int GetInstantiatedObjectsId(GameObject go)
	{
		int result = -1;
		if (go == null)
		{
			this.DebugReturn(DebugLevel.ERROR, "GetInstantiatedObjectsId() for GO == null.");
			return result;
		}
		PhotonView[] photonViewsInChildren = go.GetPhotonViewsInChildren();
		if (photonViewsInChildren != null && photonViewsInChildren.Length > 0 && photonViewsInChildren[0] != null)
		{
			return photonViewsInChildren[0].instantiationId;
		}
		if (base.DebugOut == DebugLevel.ALL)
		{
			this.DebugReturn(DebugLevel.ALL, "GetInstantiatedObjectsId failed for GO: " + go);
		}
		return result;
	}

	// Token: 0x06000725 RID: 1829 RVA: 0x000465E0 File Offset: 0x000449E0
	private void RemoveFromServerInstantiationCache(int instantiateId, int actorNr)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[7] = instantiateId;
		this.OpRaiseEvent(202, hashtable, true, 0, new int[]
		{
			actorNr
		}, EventCaching.RemoveFromRoomCache);
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x00046620 File Offset: 0x00044A20
	private void RemoveFromServerInstantiationsOfPlayer(int actorNr)
	{
		this.OpRaiseEvent(202, null, true, 0, new int[]
		{
			actorNr
		}, EventCaching.RemoveFromRoomCache);
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x00046648 File Offset: 0x00044A48
	public void DestroyPlayerObjects(PhotonPlayer player, bool localOnly)
	{
		this.RemoveAllInstantiatedObjectsByPlayer(player, localOnly);
		PhotonView[] array = (PhotonView[])UnityEngine.Object.FindObjectsOfType(typeof(PhotonView));
		for (int i = array.Length - 1; i >= 0; i--)
		{
			PhotonView photonView = array[i];
			if (photonView.owner == player)
			{
				this.DestroyPhotonView(photonView, localOnly);
			}
		}
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x000466A0 File Offset: 0x00044AA0
	public void DestroyPhotonView(PhotonView view, bool localOnly)
	{
		if (!localOnly && (view.isMine || this.mMasterClient == this.mLocalActor))
		{
			Hashtable hashtable = new Hashtable();
			hashtable[0] = view.viewID;
			this.OpRaiseEvent(204, hashtable, true, 0, EventCaching.DoNotCache, ReceiverGroup.Others);
		}
		if (view.isMine || this.mMasterClient == this.mLocalActor)
		{
			this.RemoveRPCs(view);
		}
		int instantiationId = view.instantiationId;
		if (instantiationId != -1)
		{
			this.instantiatedObjects.Remove(instantiationId);
		}
		if (base.DebugOut >= DebugLevel.ALL)
		{
			this.DebugReturn(DebugLevel.ALL, "Network destroy PhotonView GO: " + view.gameObject.name);
		}
		this.DestroyGO(view.gameObject);
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x00046770 File Offset: 0x00044B70
	public PhotonView GetPhotonView(int viewID)
	{
		PhotonView photonView = null;
		this.photonViewList.TryGetValue(viewID, out photonView);
		if (photonView == null)
		{
			PhotonView[] array = UnityEngine.Object.FindObjectsOfType(typeof(PhotonView)) as PhotonView[];
			foreach (PhotonView photonView2 in array)
			{
				if (photonView2.viewID == viewID)
				{
					Debug.LogWarning("Had to lookup view that wasn't in dict: " + photonView2);
					return photonView2;
				}
			}
		}
		return photonView;
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x000467F0 File Offset: 0x00044BF0
	public void RegisterPhotonView(PhotonView netView)
	{
		if (!Application.isPlaying)
		{
			this.photonViewList = new Dictionary<int, PhotonView>();
			return;
		}
		if (netView.subId == 0)
		{
			return;
		}
		if (!this.photonViewList.ContainsKey(netView.viewID))
		{
			this.photonViewList.Add(netView.viewID, netView);
			if (base.DebugOut >= DebugLevel.ALL)
			{
				this.DebugReturn(DebugLevel.ALL, "Registered PhotonView: " + netView.viewID);
			}
		}
		else if (netView != this.photonViewList[netView.viewID])
		{
			Debug.LogError(string.Format("PhotonView ID duplicate found: {0}. On objects: {1} and {2}. Maybe one wasn't destroyed on scene load?! Check for 'DontDestroyOnLoad'.", netView.viewID, netView, this.photonViewList[netView.viewID]));
		}
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x000468BC File Offset: 0x00044CBC
	public void RemovePhotonView(PhotonView netView)
	{
		if (!Application.isPlaying)
		{
			this.photonViewList = new Dictionary<int, PhotonView>();
			return;
		}
		this.photonViewList.Remove(netView.viewID);
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x000468E8 File Offset: 0x00044CE8
	public void RemoveRPCs(int actorNumber)
	{
		this.OpRaiseEvent(200, null, true, 0, new int[]
		{
			actorNumber
		}, EventCaching.RemoveFromRoomCache);
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x00046910 File Offset: 0x00044D10
	public void RemoveCompleteCacheOfPlayer(int actorNumber)
	{
		this.OpRaiseEvent(0, null, true, 0, new int[]
		{
			actorNumber
		}, EventCaching.RemoveFromRoomCache);
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x00046934 File Offset: 0x00044D34
	private void RemoveCacheOfLeftPlayers()
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[244] = 0;
		dictionary[247] = 7;
		this.OpCustom(253, dictionary, true, 0);
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x00046978 File Offset: 0x00044D78
	public void RemoveRPCs(PhotonView view)
	{
		if (!this.mLocalActor.isMasterClient && view.owner != this.mLocalActor)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Error, cannot remove cached RPCs on a PhotonView thats not ours! ",
				view.owner,
				" scene: ",
				view.isSceneView
			}));
			return;
		}
		Hashtable hashtable = new Hashtable();
		hashtable[0] = view.viewID;
		this.OpRaiseEvent(200, hashtable, true, 0, EventCaching.RemoveFromRoomCache, ReceiverGroup.Others);
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x00046A0C File Offset: 0x00044E0C
	public void RemoveRPCsInGroup(int group)
	{
		foreach (KeyValuePair<int, PhotonView> keyValuePair in this.photonViewList)
		{
			PhotonView value = keyValuePair.Value;
			if (value.group == group)
			{
				this.RemoveRPCs(value);
			}
		}
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x00046A7C File Offset: 0x00044E7C
	public void SetLevelPrefix(short prefix)
	{
		this.currentLevelPrefix = prefix;
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x00046A88 File Offset: 0x00044E88
	public void RPC(PhotonView view, string methodName, PhotonPlayer player, params object[] parameters)
	{
		if (this.blockSendingGroups.Contains(view.group))
		{
			return;
		}
		if (view.viewID < 1)
		{
		}
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, string.Concat(new object[]
			{
				"Sending RPC \"",
				methodName,
				"\" to player[",
				player,
				"]"
			}));
		}
		Hashtable hashtable = new Hashtable();
		hashtable[0] = view.viewID;
		if (view.prefix > 0)
		{
			hashtable[1] = (short)view.prefix;
		}
		hashtable[2] = base.ServerTimeInMilliSeconds;
		int num = 0;
		if (this.rpcShortcuts.TryGetValue(methodName, out num))
		{
			hashtable[5] = (byte)num;
		}
		else
		{
			hashtable[3] = methodName;
		}
		if (parameters != null || parameters.Length == 0)
		{
			hashtable[4] = parameters;
		}
		if (this.mLocalActor == player)
		{
			this.ExecuteRPC(hashtable, player);
		}
		else
		{
			int[] targetActors = new int[]
			{
				player.ID
			};
			this.OpRaiseEvent(200, hashtable, true, 0, targetActors);
		}
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x00046BE0 File Offset: 0x00044FE0
	public void RPC(PhotonView view, string methodName, PhotonTargets target, params object[] parameters)
	{
		if (this.blockSendingGroups.Contains(view.group))
		{
			return;
		}
		if (view.viewID < 1)
		{
		}
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, string.Concat(new object[]
			{
				"Sending RPC \"",
				methodName,
				"\" to ",
				target
			}));
		}
		Hashtable hashtable = new Hashtable();
		hashtable[0] = view.viewID;
		if (view.prefix > 0)
		{
			hashtable[1] = (short)view.prefix;
		}
		hashtable[2] = base.ServerTimeInMilliSeconds;
		int num = 0;
		if (this.rpcShortcuts.TryGetValue(methodName, out num))
		{
			hashtable[5] = (byte)num;
		}
		else
		{
			hashtable[3] = methodName;
		}
		if (parameters != null || parameters.Length == 0)
		{
			hashtable[4] = parameters;
		}
		if (target == PhotonTargets.All)
		{
			this.OpRaiseEvent(200, (byte)view.group, hashtable, true, 0);
			this.ExecuteRPC(hashtable, this.mLocalActor);
		}
		else if (target == PhotonTargets.Others)
		{
			this.OpRaiseEvent(200, (byte)view.group, hashtable, true, 0);
		}
		else if (target == PhotonTargets.AllBuffered)
		{
			this.OpRaiseEvent(200, hashtable, true, 0, EventCaching.AddToRoomCache, ReceiverGroup.Others);
			this.ExecuteRPC(hashtable, this.mLocalActor);
		}
		else if (target == PhotonTargets.OthersBuffered)
		{
			this.OpRaiseEvent(200, hashtable, true, 0, EventCaching.AddToRoomCache, ReceiverGroup.Others);
		}
		else if (target == PhotonTargets.MasterClient)
		{
			if (this.mMasterClient == this.mLocalActor)
			{
				this.ExecuteRPC(hashtable, this.mLocalActor);
			}
			else
			{
				this.OpRaiseEvent(200, hashtable, true, 0, EventCaching.DoNotCache, ReceiverGroup.MasterClient);
			}
		}
		else
		{
			Debug.LogError("Unsupported target enum: " + target);
		}
	}

	// Token: 0x06000734 RID: 1844 RVA: 0x00046DE8 File Offset: 0x000451E8
	public void SetReceivingEnabled(int group, bool enabled)
	{
		if (group <= 0)
		{
			Debug.LogError("Error: PhotonNetwork.SetReceivingEnabled was called with an illegal group number: " + group + ". The group number should be at least 1.");
			return;
		}
		if (enabled)
		{
			if (!this.allowedReceivingGroups.Contains(group))
			{
				this.allowedReceivingGroups.Add(group);
				byte[] groupsToAdd = new byte[]
				{
					(byte)group
				};
				this.OpChangeGroups(null, groupsToAdd);
			}
		}
		else if (this.allowedReceivingGroups.Contains(group))
		{
			this.allowedReceivingGroups.Remove(group);
			byte[] groupsToRemove = new byte[]
			{
				(byte)group
			};
			this.OpChangeGroups(groupsToRemove, null);
		}
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x00046E88 File Offset: 0x00045288
	public void SetSendingEnabled(int group, bool enabled)
	{
		if (!enabled)
		{
			this.blockSendingGroups.Add(group);
		}
		else
		{
			this.blockSendingGroups.Remove(group);
		}
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x00046EB0 File Offset: 0x000452B0
	public void NewSceneLoaded()
	{
		if (this.loadingLevelAndPausedNetwork && !PhotonNetwork.isMessageQueueRunning)
		{
			this.loadingLevelAndPausedNetwork = false;
			PhotonNetwork.isMessageQueueRunning = true;
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, PhotonView> keyValuePair in this.photonViewList)
		{
			PhotonView value = keyValuePair.Value;
			if (value == null)
			{
				list.Add(keyValuePair.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			int key = list[i];
			this.photonViewList.Remove(key);
		}
		if (list.Count > 0 && base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, "Removed " + list.Count + " scene view IDs from last scene.");
		}
	}

	// Token: 0x06000737 RID: 1847 RVA: 0x00046FBC File Offset: 0x000453BC
	public void RunViewUpdate()
	{
		if (!PhotonNetwork.connected || PhotonNetwork.offlineMode)
		{
			return;
		}
		if (this.mActors == null || this.mActors.Count <= 1)
		{
			return;
		}
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		Dictionary<int, Hashtable> dictionary2 = new Dictionary<int, Hashtable>();
		foreach (KeyValuePair<int, PhotonView> keyValuePair in this.photonViewList)
		{
			PhotonView value = keyValuePair.Value;
			if (value.observed != null && value.synchronization != ViewSynchronization.Off)
			{
				if (value.owner == this.mLocalActor || (value.isSceneView && this.mMasterClient == this.mLocalActor))
				{
					if (value.gameObject.activeInHierarchy)
					{
						if (!this.blockSendingGroups.Contains(value.group))
						{
							Hashtable hashtable = this.OnSerializeWrite(value);
							if (hashtable != null)
							{
								if (value.synchronization == ViewSynchronization.ReliableDeltaCompressed)
								{
									if (hashtable.ContainsKey(1) || hashtable.ContainsKey(2))
									{
										if (!dictionary.ContainsKey(value.group))
										{
											dictionary[value.group] = new Hashtable();
											dictionary[value.group][0] = base.ServerTimeInMilliSeconds;
											if (this.currentLevelPrefix >= 0)
											{
												dictionary[value.group][1] = this.currentLevelPrefix;
											}
										}
										Hashtable hashtable2 = dictionary[value.group];
										hashtable2.Add((short)hashtable2.Count, hashtable);
									}
								}
								else
								{
									if (!dictionary2.ContainsKey(value.group))
									{
										dictionary2[value.group] = new Hashtable();
										dictionary2[value.group][0] = base.ServerTimeInMilliSeconds;
										if (this.currentLevelPrefix >= 0)
										{
											dictionary2[value.group][1] = this.currentLevelPrefix;
										}
									}
									Hashtable hashtable3 = dictionary2[value.group];
									hashtable3.Add((short)hashtable3.Count, hashtable);
								}
							}
						}
					}
				}
			}
		}
		foreach (KeyValuePair<int, Hashtable> keyValuePair2 in dictionary)
		{
			this.OpRaiseEvent(206, (byte)keyValuePair2.Key, keyValuePair2.Value, true, 0);
		}
		foreach (KeyValuePair<int, Hashtable> keyValuePair3 in dictionary2)
		{
			this.OpRaiseEvent(201, (byte)keyValuePair3.Key, keyValuePair3.Value, false, 0);
		}
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x00047348 File Offset: 0x00045748
	private void ExecuteOnSerialize(MonoBehaviour monob, PhotonStream pStream, PhotonMessageInfo info)
	{
		object[] parameters = new object[]
		{
			pStream,
			info
		};
		MethodInfo cachedMethod = this.GetCachedMethod(monob, PhotonNetworkingMessage.OnPhotonSerializeView);
		if (cachedMethod != null)
		{
			object obj = cachedMethod.Invoke(monob, parameters);
			if (cachedMethod.ReturnType == typeof(IEnumerator))
			{
				monob.StartCoroutine((IEnumerator)obj);
			}
		}
	}

	// Token: 0x06000739 RID: 1849 RVA: 0x000473A4 File Offset: 0x000457A4
	private Hashtable OnSerializeWrite(PhotonView view)
	{
		List<object> list = new List<object>();
		if (view.observed is MonoBehaviour)
		{
			MonoBehaviour monob = (MonoBehaviour)view.observed;
			PhotonStream photonStream = new PhotonStream(true, null);
			PhotonMessageInfo info = new PhotonMessageInfo(this.mLocalActor, base.ServerTimeInMilliSeconds, view);
			this.ExecuteOnSerialize(monob, photonStream, info);
			if (photonStream.Count == 0)
			{
				return null;
			}
			list = photonStream.data;
		}
		else if (view.observed is Transform)
		{
			Transform transform = (Transform)view.observed;
			if (view.onSerializeTransformOption == OnSerializeTransform.OnlyPosition || view.onSerializeTransformOption == OnSerializeTransform.PositionAndRotation || view.onSerializeTransformOption == OnSerializeTransform.All)
			{
				list.Add(transform.localPosition);
			}
			else
			{
				list.Add(null);
			}
			if (view.onSerializeTransformOption == OnSerializeTransform.OnlyRotation || view.onSerializeTransformOption == OnSerializeTransform.PositionAndRotation || view.onSerializeTransformOption == OnSerializeTransform.All)
			{
				list.Add(transform.localRotation);
			}
			else
			{
				list.Add(null);
			}
			if (view.onSerializeTransformOption == OnSerializeTransform.OnlyScale || view.onSerializeTransformOption == OnSerializeTransform.All)
			{
				list.Add(transform.localScale);
			}
		}
		else
		{
			if (!(view.observed is Rigidbody))
			{
				Debug.LogError("Observed type is not serializable: " + view.observed.GetType());
				return null;
			}
			Rigidbody rigidbody = (Rigidbody)view.observed;
			if (view.onSerializeRigidBodyOption != OnSerializeRigidBody.OnlyAngularVelocity)
			{
				list.Add(rigidbody.velocity);
			}
			else
			{
				list.Add(null);
			}
			if (view.onSerializeRigidBodyOption != OnSerializeRigidBody.OnlyVelocity)
			{
				list.Add(rigidbody.angularVelocity);
			}
		}
		object[] array = list.ToArray();
		Hashtable hashtable = new Hashtable();
		hashtable[0] = view.viewID;
		hashtable[1] = array;
		if (view.synchronization == ViewSynchronization.ReliableDeltaCompressed)
		{
			bool flag = this.DeltaCompressionWrite(view, hashtable);
			view.lastOnSerializeDataSent = array;
			if (!flag)
			{
				return null;
			}
		}
		return hashtable;
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x000475C4 File Offset: 0x000459C4
	private void OnSerializeRead(Hashtable data, PhotonPlayer sender, int networkTime, short correctPrefix)
	{
		int num = (int)data[0];
		PhotonView photonView = this.GetPhotonView(num);
		if (photonView == null)
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"Received OnSerialization for view ID ",
				num,
				". We have no such PhotonView! Ignored this if you're leaving a room. State: ",
				this.State
			}));
			return;
		}
		if (photonView.prefix > 0 && (int)correctPrefix != photonView.prefix)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Received OnSerialization for view ID ",
				num,
				" with prefix ",
				correctPrefix,
				". Our prefix is ",
				photonView.prefix
			}));
			return;
		}
		if (photonView.group != 0 && !this.allowedReceivingGroups.Contains(photonView.group))
		{
			return;
		}
		if (photonView.synchronization == ViewSynchronization.ReliableDeltaCompressed)
		{
			if (!this.DeltaCompressionRead(photonView, data))
			{
				this.DebugReturn(DebugLevel.INFO, string.Concat(new object[]
				{
					"Skipping packet for ",
					photonView.name,
					" [",
					photonView.viewID,
					"] as we haven't received a full packet for delta compression yet. This is OK if it happens for the first few frames after joining a game."
				}));
				return;
			}
			photonView.lastOnSerializeDataReceived = (data[1] as object[]);
		}
		if (photonView.observed is MonoBehaviour)
		{
			object[] incomingData = data[1] as object[];
			MonoBehaviour monob = (MonoBehaviour)photonView.observed;
			PhotonStream pStream = new PhotonStream(false, incomingData);
			PhotonMessageInfo info = new PhotonMessageInfo(sender, networkTime, photonView);
			this.ExecuteOnSerialize(monob, pStream, info);
		}
		else if (photonView.observed is Transform)
		{
			object[] array = data[1] as object[];
			Transform transform = (Transform)photonView.observed;
			if (array.Length >= 1 && array[0] != null)
			{
				transform.localPosition = (Vector3)array[0];
			}
			if (array.Length >= 2 && array[1] != null)
			{
				transform.localRotation = (Quaternion)array[1];
			}
			if (array.Length >= 3 && array[2] != null)
			{
				transform.localScale = (Vector3)array[2];
			}
		}
		else if (photonView.observed is Rigidbody)
		{
			object[] array2 = data[1] as object[];
			Rigidbody rigidbody = (Rigidbody)photonView.observed;
			if (array2.Length >= 1 && array2[0] != null)
			{
				rigidbody.velocity = (Vector3)array2[0];
			}
			if (array2.Length >= 2 && array2[1] != null)
			{
				rigidbody.angularVelocity = (Vector3)array2[1];
			}
		}
		else
		{
			Debug.LogError("Type of observed is unknown when receiving.");
		}
	}

	// Token: 0x0600073B RID: 1851 RVA: 0x0004789C File Offset: 0x00045C9C
	private bool DeltaCompressionWrite(PhotonView view, Hashtable data)
	{
		if (view.lastOnSerializeDataSent == null)
		{
			return true;
		}
		object[] lastOnSerializeDataSent = view.lastOnSerializeDataSent;
		object[] array = data[1] as object[];
		if (array == null)
		{
			return false;
		}
		if (lastOnSerializeDataSent.Length != array.Length)
		{
			return true;
		}
		object[] array2 = new object[array.Length];
		int num = 0;
		List<int> list = new List<int>();
		for (int i = 0; i < array2.Length; i++)
		{
			object obj = array[i];
			object two = lastOnSerializeDataSent[i];
			if (this.ObjectIsSameWithInprecision(obj, two))
			{
				num++;
			}
			else
			{
				array2[i] = array[i];
				if (obj == null)
				{
					list.Add(i);
				}
			}
		}
		if (num > 0)
		{
			data.Remove(1);
			if (num == array.Length)
			{
				return false;
			}
			data[2] = array2;
			if (list.Count > 0)
			{
				data[3] = list.ToArray();
			}
		}
		return true;
	}

	// Token: 0x0600073C RID: 1852 RVA: 0x00047998 File Offset: 0x00045D98
	private bool DeltaCompressionRead(PhotonView view, Hashtable data)
	{
		if (data.ContainsKey(1))
		{
			return true;
		}
		if (view.lastOnSerializeDataReceived == null)
		{
			return false;
		}
		object[] array = data[2] as object[];
		if (array == null)
		{
			return false;
		}
		int[] array2 = data[3] as int[];
		if (array2 == null)
		{
			array2 = new int[0];
		}
		object[] lastOnSerializeDataReceived = view.lastOnSerializeDataReceived;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == null && !array2.Contains(i))
			{
				object obj = lastOnSerializeDataReceived[i];
				array[i] = obj;
			}
		}
		data[1] = array;
		return true;
	}

	// Token: 0x0600073D RID: 1853 RVA: 0x00047A48 File Offset: 0x00045E48
	private bool ObjectIsSameWithInprecision(object one, object two)
	{
		if (one == null || two == null)
		{
			return one == null && two == null;
		}
		if (!one.Equals(two))
		{
			if (one is Vector3)
			{
				Vector3 target = (Vector3)one;
				Vector3 second = (Vector3)two;
				if (target.AlmostEquals(second, PhotonNetwork.precisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (one is Vector2)
			{
				Vector2 target2 = (Vector2)one;
				Vector2 second2 = (Vector2)two;
				if (target2.AlmostEquals(second2, PhotonNetwork.precisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (one is Quaternion)
			{
				Quaternion target3 = (Quaternion)one;
				Quaternion second3 = (Quaternion)two;
				if (target3.AlmostEquals(second3, PhotonNetwork.precisionForQuaternionSynchronization))
				{
					return true;
				}
			}
			else if (one is float)
			{
				float target4 = (float)one;
				float second4 = (float)two;
				if (target4.AlmostEquals(second4, PhotonNetwork.precisionForFloatSynchronization))
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	// Token: 0x0600073E RID: 1854 RVA: 0x00047B48 File Offset: 0x00045F48
	private MethodInfo GetCachedMethod(MonoBehaviour monob, PhotonNetworkingMessage methodType)
	{
		Type type = monob.GetType();
		if (!this.cachedMethods.ContainsKey(type))
		{
			Dictionary<PhotonNetworkingMessage, MethodInfo> value = new Dictionary<PhotonNetworkingMessage, MethodInfo>();
			this.cachedMethods.Add(type, value);
		}
		Dictionary<PhotonNetworkingMessage, MethodInfo> dictionary = this.cachedMethods[type];
		if (!dictionary.ContainsKey(methodType))
		{
			Type[] types;
			if (methodType == PhotonNetworkingMessage.OnPhotonSerializeView)
			{
				types = new Type[]
				{
					typeof(PhotonStream),
					typeof(PhotonMessageInfo)
				};
			}
			else
			{
				if (methodType != PhotonNetworkingMessage.OnPhotonInstantiate)
				{
					Debug.LogError("Invalid PhotonNetworkingMessage!");
					return null;
				}
				types = new Type[]
				{
					typeof(PhotonMessageInfo)
				};
			}
			MethodInfo method = monob.GetType().GetMethod(methodType + string.Empty, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);
			if (method != null)
			{
				dictionary.Add(methodType, method);
			}
		}
		if (dictionary.ContainsKey(methodType))
		{
			return dictionary[methodType];
		}
		return null;
	}

	// Token: 0x0600073F RID: 1855 RVA: 0x00047C3C File Offset: 0x0004603C
	protected internal void AutomaticallySyncScene()
	{
		if (PhotonNetwork.room != null && PhotonNetwork.automaticallySyncScene && !PhotonNetwork.isMasterClient)
		{
			string text = (string)PhotonNetwork.room.customProperties["curScn"];
			if (!string.IsNullOrEmpty(text) && text != Application.loadedLevelName)
			{
				PhotonNetwork.LoadLevel(text);
			}
		}
	}

	// Token: 0x040009A1 RID: 2465
	public string mAppVersion;

	// Token: 0x040009A2 RID: 2466
	private string mAppId;

	// Token: 0x040009A3 RID: 2467
	private string masterServerAddress;

	// Token: 0x040009A4 RID: 2468
	private string playername = string.Empty;

	// Token: 0x040009A5 RID: 2469
	private IPhotonPeerListener externalListener;

	// Token: 0x040009A6 RID: 2470
	private JoinType mLastJoinType;

	// Token: 0x040009A7 RID: 2471
	private bool mPlayernameHasToBeUpdated;

	// Token: 0x040009AA RID: 2474
	public Dictionary<int, PhotonPlayer> mActors = new Dictionary<int, PhotonPlayer>();

	// Token: 0x040009AB RID: 2475
	public PhotonPlayer[] mOtherPlayerListCopy = new PhotonPlayer[0];

	// Token: 0x040009AC RID: 2476
	public PhotonPlayer[] mPlayerListCopy = new PhotonPlayer[0];

	// Token: 0x040009AE RID: 2478
	public PhotonPlayer mMasterClient;

	// Token: 0x040009B0 RID: 2480
	public bool requestSecurity = true;

	// Token: 0x040009B1 RID: 2481
	private Dictionary<Type, List<MethodInfo>> monoRPCMethodsCache = new Dictionary<Type, List<MethodInfo>>();

	// Token: 0x040009B2 RID: 2482
	public static bool UsePrefabCache = true;

	// Token: 0x040009B3 RID: 2483
	public static Dictionary<string, GameObject> PrefabCache = new Dictionary<string, GameObject>();

	// Token: 0x040009B4 RID: 2484
	public Dictionary<string, RoomInfo> mGameList = new Dictionary<string, RoomInfo>();

	// Token: 0x040009B5 RID: 2485
	public RoomInfo[] mGameListCopy = new RoomInfo[0];

	// Token: 0x040009B7 RID: 2487
	public bool insideLobby;

	// Token: 0x040009BB RID: 2491
	public Dictionary<int, GameObject> instantiatedObjects = new Dictionary<int, GameObject>();

	// Token: 0x040009BC RID: 2492
	private HashSet<int> allowedReceivingGroups = new HashSet<int>();

	// Token: 0x040009BD RID: 2493
	private HashSet<int> blockSendingGroups = new HashSet<int>();

	// Token: 0x040009BE RID: 2494
	protected internal Dictionary<int, PhotonView> photonViewList = new Dictionary<int, PhotonView>();

	// Token: 0x040009BF RID: 2495
	protected internal short currentLevelPrefix;

	// Token: 0x040009C0 RID: 2496
	private readonly Dictionary<Type, Dictionary<PhotonNetworkingMessage, MethodInfo>> cachedMethods = new Dictionary<Type, Dictionary<PhotonNetworkingMessage, MethodInfo>>();

	// Token: 0x040009C1 RID: 2497
	private readonly Dictionary<string, int> rpcShortcuts;

	// Token: 0x040009C2 RID: 2498
	private Dictionary<int, object[]> tempInstantiationData = new Dictionary<int, object[]>();

	// Token: 0x040009C3 RID: 2499
	protected internal bool loadingLevelAndPausedNetwork;

	// Token: 0x040009C4 RID: 2500
	protected internal const string CurrentSceneProperty = "curScn";
}
