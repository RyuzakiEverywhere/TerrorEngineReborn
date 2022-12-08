using System;
using System.Collections;
using ExitGames.Client.Photon;

// Token: 0x0200014A RID: 330
public class RoomInfo
{
	// Token: 0x0600080D RID: 2061 RVA: 0x0004A89C File Offset: 0x00048C9C
	protected internal RoomInfo(string roomName, Hashtable properties)
	{
		this.CacheProperties(properties);
		this.nameField = roomName;
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x0600080E RID: 2062 RVA: 0x0004A8CB File Offset: 0x00048CCB
	// (set) Token: 0x0600080F RID: 2063 RVA: 0x0004A8D3 File Offset: 0x00048CD3
	public bool removedFromList { get; internal set; }

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x06000810 RID: 2064 RVA: 0x0004A8DC File Offset: 0x00048CDC
	public Hashtable customProperties
	{
		get
		{
			return this.customPropertiesField;
		}
	}

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x06000811 RID: 2065 RVA: 0x0004A8E4 File Offset: 0x00048CE4
	public string name
	{
		get
		{
			return this.nameField;
		}
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x06000812 RID: 2066 RVA: 0x0004A8EC File Offset: 0x00048CEC
	// (set) Token: 0x06000813 RID: 2067 RVA: 0x0004A8F4 File Offset: 0x00048CF4
	public int playerCount { get; private set; }

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000814 RID: 2068 RVA: 0x0004A8FD File Offset: 0x00048CFD
	// (set) Token: 0x06000815 RID: 2069 RVA: 0x0004A905 File Offset: 0x00048D05
	public bool isLocalClientInside { get; set; }

	// Token: 0x1700007B RID: 123
	// (get) Token: 0x06000816 RID: 2070 RVA: 0x0004A90E File Offset: 0x00048D0E
	public byte maxPlayers
	{
		get
		{
			return this.maxPlayersField;
		}
	}

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x06000817 RID: 2071 RVA: 0x0004A916 File Offset: 0x00048D16
	public bool open
	{
		get
		{
			return this.openField;
		}
	}

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06000818 RID: 2072 RVA: 0x0004A91E File Offset: 0x00048D1E
	public bool visible
	{
		get
		{
			return this.visibleField;
		}
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x0004A928 File Offset: 0x00048D28
	public override bool Equals(object p)
	{
		Room room = p as Room;
		return room != null && this.nameField.Equals(room.nameField);
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x0004A956 File Offset: 0x00048D56
	public override int GetHashCode()
	{
		return this.nameField.GetHashCode();
	}

	// Token: 0x0600081B RID: 2075 RVA: 0x0004A964 File Offset: 0x00048D64
	public override string ToString()
	{
		return string.Format("Room: '{0}' visible: {1} open: {2} max: {3} count: {4}\ncustomProps: {5}", new object[]
		{
			this.nameField,
			this.visibleField,
			this.openField,
			this.maxPlayersField,
			this.playerCount,
			SupportClass.DictionaryToString(this.customPropertiesField)
		});
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x0004A9D0 File Offset: 0x00048DD0
	protected internal void CacheProperties(Hashtable propertiesToCache)
	{
		if (propertiesToCache == null || propertiesToCache.Count == 0 || this.customPropertiesField.Equals(propertiesToCache))
		{
			return;
		}
		if (propertiesToCache.ContainsKey(251))
		{
			this.removedFromList = (bool)propertiesToCache[251];
			if (this.removedFromList)
			{
				return;
			}
		}
		if (propertiesToCache.ContainsKey(255))
		{
			this.maxPlayersField = (byte)propertiesToCache[byte.MaxValue];
		}
		if (propertiesToCache.ContainsKey(253))
		{
			this.openField = (bool)propertiesToCache[253];
		}
		if (propertiesToCache.ContainsKey(254))
		{
			this.visibleField = (bool)propertiesToCache[254];
		}
		if (propertiesToCache.ContainsKey(252))
		{
			this.playerCount = (int)((byte)propertiesToCache[252]);
		}
		if (propertiesToCache.ContainsKey(249))
		{
			this.autoCleanUpField = (bool)propertiesToCache[249];
		}
		this.customPropertiesField.MergeStringKeys(propertiesToCache);
	}

	// Token: 0x04000A2A RID: 2602
	private Hashtable customPropertiesField = new Hashtable();

	// Token: 0x04000A2B RID: 2603
	protected byte maxPlayersField;

	// Token: 0x04000A2C RID: 2604
	protected bool openField = true;

	// Token: 0x04000A2D RID: 2605
	protected bool visibleField = true;

	// Token: 0x04000A2E RID: 2606
	protected bool autoCleanUpField;

	// Token: 0x04000A2F RID: 2607
	protected string nameField;
}
