using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;

// Token: 0x02000130 RID: 304
internal class LoadbalancingPeer : PhotonPeer
{
	// Token: 0x060006CE RID: 1742 RVA: 0x0004307D File Offset: 0x0004147D
	public LoadbalancingPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType) : base(listener, protocolType)
	{
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x00043087 File Offset: 0x00041487
	public virtual bool OpJoinLobby()
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinLobby()");
		}
		return this.OpCustom(229, null, true);
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x000430B3 File Offset: 0x000414B3
	public virtual bool OpLeaveLobby()
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpLeaveLobby()");
		}
		return this.OpCustom(228, null, true);
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x000430E0 File Offset: 0x000414E0
	public virtual bool OpCreateRoom(string gameID, bool isVisible, bool isOpen, byte maxPlayers, bool autoCleanUp, Hashtable customGameProperties, Hashtable customPlayerProperties, string[] customRoomPropertiesForLobby)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpCreateRoom()");
		}
		Hashtable hashtable = new Hashtable();
		hashtable[253] = isOpen;
		hashtable[254] = isVisible;
		hashtable[250] = customRoomPropertiesForLobby;
		hashtable.MergeStringKeys(customGameProperties);
		if (maxPlayers > 0)
		{
			hashtable[byte.MaxValue] = maxPlayers;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[248] = hashtable;
		dictionary[249] = customPlayerProperties;
		dictionary[250] = true;
		if (!string.IsNullOrEmpty(gameID))
		{
			dictionary[byte.MaxValue] = gameID;
		}
		if (autoCleanUp)
		{
			dictionary[241] = autoCleanUp;
			hashtable[249] = autoCleanUp;
		}
		return this.OpCustom(227, dictionary, true);
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x000431FC File Offset: 0x000415FC
	public virtual bool OpJoinRoom(string roomName, Hashtable playerProperties)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRoom()");
		}
		if (string.IsNullOrEmpty(roomName))
		{
			base.Listener.DebugReturn(DebugLevel.ERROR, "OpJoinRoom() failed. Please specify a roomname.");
			return false;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[byte.MaxValue] = roomName;
		dictionary[250] = true;
		if (playerProperties != null)
		{
			dictionary[249] = playerProperties;
		}
		return this.OpCustom(226, dictionary, true);
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x00043288 File Offset: 0x00041688
	public virtual bool OpJoinRandomRoom(Hashtable expectedCustomRoomProperties, byte expectedMaxPlayers, Hashtable playerProperties, MatchmakingMode matchingType)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRandomRoom()");
		}
		Hashtable hashtable = new Hashtable();
		hashtable.MergeStringKeys(expectedCustomRoomProperties);
		if (expectedMaxPlayers > 0)
		{
			hashtable[byte.MaxValue] = expectedMaxPlayers;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (hashtable.Count > 0)
		{
			dictionary[248] = hashtable;
		}
		if (playerProperties != null && playerProperties.Count > 0)
		{
			dictionary[249] = playerProperties;
		}
		if (matchingType != MatchmakingMode.FillRoom)
		{
			dictionary[223] = (byte)matchingType;
		}
		return this.OpCustom(225, dictionary, true);
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0004333E File Offset: 0x0004173E
	public bool OpSetCustomPropertiesOfActor(int actorNr, Hashtable actorProperties, bool broadcast, byte channelId)
	{
		return this.OpSetPropertiesOfActor(actorNr, actorProperties.StripToStringKeys(), broadcast, channelId);
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x00043350 File Offset: 0x00041750
	protected bool OpSetPropertiesOfActor(int actorNr, Hashtable actorProperties, bool broadcast, byte channelId)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfActor()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, actorProperties);
		dictionary.Add(254, actorNr);
		if (broadcast)
		{
			dictionary.Add(250, broadcast);
		}
		return this.OpCustom(252, dictionary, broadcast, channelId);
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x000433C4 File Offset: 0x000417C4
	protected void OpSetPropertyOfRoom(byte propCode, object value)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[propCode] = value;
		this.OpSetPropertiesOfRoom(hashtable, true, 0);
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x000433EE File Offset: 0x000417EE
	public bool OpSetCustomPropertiesOfRoom(Hashtable gameProperties, bool broadcast, byte channelId)
	{
		return this.OpSetPropertiesOfRoom(gameProperties.StripToStringKeys(), broadcast, channelId);
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x00043400 File Offset: 0x00041800
	public bool OpSetPropertiesOfRoom(Hashtable gameProperties, bool broadcast, byte channelId)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfRoom()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, gameProperties);
		if (broadcast)
		{
			dictionary.Add(250, broadcast);
		}
		return this.OpCustom(252, dictionary, broadcast, channelId);
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x00043464 File Offset: 0x00041864
	public virtual bool OpAuthenticate(string appId, string appVersion)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[220] = appVersion;
		dictionary[224] = appId;
		return this.OpCustom(230, dictionary, true, 0, base.IsEncryptionAvailable);
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x000434C0 File Offset: 0x000418C0
	public virtual bool OpChangeGroups(byte[] groupsToRemove, byte[] groupsToAdd)
	{
		if (base.DebugOut >= DebugLevel.ALL)
		{
			base.Listener.DebugReturn(DebugLevel.ALL, "OpChangeGroups()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (groupsToRemove != null)
		{
			dictionary[239] = groupsToRemove;
		}
		if (groupsToAdd != null)
		{
			dictionary[238] = groupsToAdd;
		}
		return this.OpCustom(248, dictionary, true, 0);
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x00043524 File Offset: 0x00041924
	public virtual bool OpRaiseEvent(byte eventCode, byte interestGroup, Hashtable customEventContent, bool sendReliable, byte channelId)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = customEventContent;
		dictionary[244] = eventCode;
		if (interestGroup != 0)
		{
			dictionary[240] = interestGroup;
		}
		return this.OpCustom(253, dictionary, sendReliable, channelId);
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x0004357B File Offset: 0x0004197B
	public virtual bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId)
	{
		return this.OpRaiseEvent(eventCode, evData, sendReliable, channelId, EventCaching.DoNotCache, ReceiverGroup.Others);
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x0004358A File Offset: 0x0004198A
	public virtual bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId, int[] targetActors)
	{
		return this.OpRaiseEvent(eventCode, evData, sendReliable, channelId, targetActors, EventCaching.DoNotCache);
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x0004359C File Offset: 0x0004199C
	public virtual bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId, int[] targetActors, EventCaching cache)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpRaiseEvent()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = evData;
		dictionary[244] = eventCode;
		if (cache != EventCaching.DoNotCache)
		{
			dictionary[247] = (byte)cache;
		}
		if (targetActors != null)
		{
			dictionary[252] = targetActors;
		}
		return this.OpCustom(253, dictionary, sendReliable, channelId);
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x00043628 File Offset: 0x00041A28
	public virtual bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId, EventCaching cache, ReceiverGroup receivers)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpRaiseEvent()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = evData;
		dictionary[244] = eventCode;
		if (receivers != ReceiverGroup.Others)
		{
			dictionary[246] = (byte)receivers;
		}
		if (cache != EventCaching.DoNotCache)
		{
			dictionary[247] = (byte)cache;
		}
		return this.OpCustom(253, dictionary, sendReliable, channelId);
	}
}
