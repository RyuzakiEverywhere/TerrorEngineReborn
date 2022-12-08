using System;
using System.Collections;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x02000149 RID: 329
public class Room : RoomInfo
{
	// Token: 0x060007FE RID: 2046 RVA: 0x0004AB38 File Offset: 0x00048F38
	internal Room(string roomName, Hashtable properties) : base(roomName, properties)
	{
		this.propertiesListedInLobby = new string[0];
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x0004AB50 File Offset: 0x00048F50
	internal Room(string roomName, Hashtable properties, bool isVisible, bool isOpen, int maxPlayers, bool autoCleanUp, string[] propsListedInLobby) : base(roomName, properties)
	{
		this.visibleField = isVisible;
		this.openField = isOpen;
		this.autoCleanUpField = autoCleanUp;
		if (maxPlayers > 255)
		{
			Debug.LogError("Error: Room() called with " + maxPlayers + " maxplayers. This has been reverted to the max of 255 players, because internally a 'byte' is used.");
			maxPlayers = 255;
		}
		this.maxPlayersField = (byte)maxPlayers;
		if (propsListedInLobby != null)
		{
			this.propertiesListedInLobby = propsListedInLobby;
		}
		else
		{
			this.propertiesListedInLobby = new string[0];
		}
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x06000800 RID: 2048 RVA: 0x0004ABD3 File Offset: 0x00048FD3
	public new int playerCount
	{
		get
		{
			if (PhotonNetwork.playerList != null)
			{
				return PhotonNetwork.playerList.Length;
			}
			return 0;
		}
	}

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x06000801 RID: 2049 RVA: 0x0004ABE8 File Offset: 0x00048FE8
	// (set) Token: 0x06000802 RID: 2050 RVA: 0x0004ABF0 File Offset: 0x00048FF0
	public new string name
	{
		get
		{
			return this.nameField;
		}
		internal set
		{
			this.nameField = value;
		}
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x06000803 RID: 2051 RVA: 0x0004ABF9 File Offset: 0x00048FF9
	// (set) Token: 0x06000804 RID: 2052 RVA: 0x0004AC04 File Offset: 0x00049004
	public new int maxPlayers
	{
		get
		{
			return (int)this.maxPlayersField;
		}
		set
		{
			if (!this.Equals(PhotonNetwork.room))
			{
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value > 255)
			{
				Debug.LogError("Error: room.maxPlayers called with value " + value + ". This has been reverted to the max of 255 players, because internally a 'byte' is used.");
				value = 255;
			}
			if (value != (int)this.maxPlayersField && !PhotonNetwork.offlineMode)
			{
				PhotonNetwork.networkingPeer.OpSetPropertiesOfRoom(new Hashtable
				{
					{
						byte.MaxValue,
						(byte)value
					}
				}, true, 0);
			}
			this.maxPlayersField = (byte)value;
		}
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x06000805 RID: 2053 RVA: 0x0004ACA6 File Offset: 0x000490A6
	// (set) Token: 0x06000806 RID: 2054 RVA: 0x0004ACB0 File Offset: 0x000490B0
	public new bool open
	{
		get
		{
			return this.openField;
		}
		set
		{
			if (!this.Equals(PhotonNetwork.room))
			{
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value != this.openField && !PhotonNetwork.offlineMode)
			{
				PhotonNetwork.networkingPeer.OpSetPropertiesOfRoom(new Hashtable
				{
					{
						253,
						value
					}
				}, true, 0);
			}
			this.openField = value;
		}
	}

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x06000807 RID: 2055 RVA: 0x0004AD24 File Offset: 0x00049124
	// (set) Token: 0x06000808 RID: 2056 RVA: 0x0004AD2C File Offset: 0x0004912C
	public new bool visible
	{
		get
		{
			return this.visibleField;
		}
		set
		{
			if (!this.Equals(PhotonNetwork.room))
			{
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value != this.visibleField && !PhotonNetwork.offlineMode)
			{
				PhotonNetwork.networkingPeer.OpSetPropertiesOfRoom(new Hashtable
				{
					{
						254,
						value
					}
				}, true, 0);
			}
			this.visibleField = value;
		}
	}

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x06000809 RID: 2057 RVA: 0x0004ADA0 File Offset: 0x000491A0
	// (set) Token: 0x0600080A RID: 2058 RVA: 0x0004ADA8 File Offset: 0x000491A8
	public string[] propertiesListedInLobby { get; private set; }

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x0600080B RID: 2059 RVA: 0x0004ADB1 File Offset: 0x000491B1
	public bool autoCleanUp
	{
		get
		{
			return this.autoCleanUpField;
		}
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x0004ADBC File Offset: 0x000491BC
	public void SetCustomProperties(Hashtable propertiesToSet)
	{
		if (propertiesToSet == null)
		{
			return;
		}
		base.customProperties.MergeStringKeys(propertiesToSet);
		base.customProperties.StripKeysWithNullValues();
		Hashtable gameProperties = propertiesToSet.StripToStringKeys();
		PhotonNetwork.networkingPeer.OpSetCustomPropertiesOfRoom(gameProperties, true, 0);
		NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonCustomRoomPropertiesChanged, new object[0]);
	}
}
