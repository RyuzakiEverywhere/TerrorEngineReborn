using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000143 RID: 323
public class PhotonPlayer
{
	// Token: 0x060007D5 RID: 2005 RVA: 0x00049EFB File Offset: 0x000482FB
	public PhotonPlayer(bool isLocal, int actorID, string name)
	{
		this.customProperties = new Hashtable();
		this.isLocal = isLocal;
		this.actorID = actorID;
		this.nameField = name;
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x00049F35 File Offset: 0x00048335
	protected internal PhotonPlayer(bool isLocal, int actorID, Hashtable properties)
	{
		this.customProperties = new Hashtable();
		this.isLocal = isLocal;
		this.actorID = actorID;
		this.InternalCacheProperties(properties);
	}

	// Token: 0x17000063 RID: 99
	// (get) Token: 0x060007D7 RID: 2007 RVA: 0x00049F6F File Offset: 0x0004836F
	public int ID
	{
		get
		{
			return this.actorID;
		}
	}

	// Token: 0x17000064 RID: 100
	// (get) Token: 0x060007D8 RID: 2008 RVA: 0x00049F77 File Offset: 0x00048377
	// (set) Token: 0x060007D9 RID: 2009 RVA: 0x00049F7F File Offset: 0x0004837F
	public string name
	{
		get
		{
			return this.nameField;
		}
		set
		{
			if (!this.isLocal)
			{
				Debug.LogError("Error: Cannot change the name of a remote player!");
				return;
			}
			this.nameField = value;
		}
	}

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060007DA RID: 2010 RVA: 0x00049F9E File Offset: 0x0004839E
	public bool isMasterClient
	{
		get
		{
			return PhotonNetwork.networkingPeer.mMasterClient == this;
		}
	}

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x060007DB RID: 2011 RVA: 0x00049FAD File Offset: 0x000483AD
	// (set) Token: 0x060007DC RID: 2012 RVA: 0x00049FB5 File Offset: 0x000483B5
	public Hashtable customProperties { get; private set; }

	// Token: 0x17000067 RID: 103
	// (get) Token: 0x060007DD RID: 2013 RVA: 0x00049FC0 File Offset: 0x000483C0
	public Hashtable allProperties
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Merge(this.customProperties);
			hashtable[byte.MaxValue] = this.name;
			return hashtable;
		}
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x00049FF8 File Offset: 0x000483F8
	internal void InternalCacheProperties(Hashtable properties)
	{
		if (properties == null || properties.Count == 0 || this.customProperties.Equals(properties))
		{
			return;
		}
		if (properties.ContainsKey(255))
		{
			this.nameField = (string)properties[byte.MaxValue];
		}
		this.customProperties.MergeStringKeys(properties);
		this.customProperties.StripKeysWithNullValues();
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x0004A06F File Offset: 0x0004846F
	public override string ToString()
	{
		return (this.name != null) ? this.name : string.Empty;
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x0004A08C File Offset: 0x0004848C
	public override bool Equals(object p)
	{
		PhotonPlayer photonPlayer = p as PhotonPlayer;
		return photonPlayer != null && this.GetHashCode() == photonPlayer.GetHashCode();
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x0004A0B7 File Offset: 0x000484B7
	public override int GetHashCode()
	{
		return this.ID;
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x0004A0BF File Offset: 0x000484BF
	internal void InternalChangeLocalID(int newID)
	{
		if (!this.isLocal)
		{
			Debug.LogError("ERROR You should never change PhotonPlayer IDs!");
			return;
		}
		this.actorID = newID;
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x0004A0E0 File Offset: 0x000484E0
	public void SetCustomProperties(Hashtable propertiesToSet)
	{
		if (propertiesToSet == null)
		{
			return;
		}
		this.customProperties.MergeStringKeys(propertiesToSet);
		this.customProperties.StripKeysWithNullValues();
		Hashtable actorProperties = propertiesToSet.StripToStringKeys();
		PhotonNetwork.networkingPeer.OpSetCustomPropertiesOfActor(this.actorID, actorProperties, true, 0);
		NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonPlayerPropertiesChanged, new object[]
		{
			this
		});
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x0004A138 File Offset: 0x00048538
	public static PhotonPlayer Find(int ID)
	{
		foreach (PhotonPlayer photonPlayer in PhotonNetwork.playerList)
		{
			if (photonPlayer.ID == ID)
			{
				return photonPlayer;
			}
		}
		return null;
	}

	// Token: 0x04000A01 RID: 2561
	private int actorID = -1;

	// Token: 0x04000A02 RID: 2562
	private string nameField = string.Empty;

	// Token: 0x04000A03 RID: 2563
	public readonly bool isLocal;
}
