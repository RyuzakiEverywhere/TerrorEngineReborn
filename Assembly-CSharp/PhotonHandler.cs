using System;
using System.Collections;
using System.Threading;
using ExitGames.Client.Photon;
using Photon;
using UnityEngine;

// Token: 0x02000140 RID: 320
internal class PhotonHandler : Photon.MonoBehaviour, IPhotonPeerListener
{
	// Token: 0x06000769 RID: 1897 RVA: 0x00048414 File Offset: 0x00046814
	private void Awake()
	{
		if (PhotonHandler.SP != null && PhotonHandler.SP != this && PhotonHandler.SP.gameObject != null)
		{
			UnityEngine.Object.DestroyImmediate(PhotonHandler.SP.gameObject);
		}
		PhotonHandler.SP = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.updateInterval = 1000 / PhotonNetwork.sendRate;
		this.updateIntervalOnSerialize = 1000 / PhotonNetwork.sendRateOnSerialize;
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x00048498 File Offset: 0x00046898
	private void Update()
	{
		if (PhotonNetwork.networkingPeer == null)
		{
			Debug.LogError("NetworkPeer broke!");
			return;
		}
		if (PhotonNetwork.connectionStateDetailed == PeerState.PeerCreated || PhotonNetwork.connectionStateDetailed == PeerState.Disconnected)
		{
			return;
		}
		if (!PhotonNetwork.isMessageQueueRunning)
		{
			return;
		}
		bool flag = true;
		while (PhotonNetwork.isMessageQueueRunning && flag)
		{
			flag = PhotonNetwork.networkingPeer.DispatchIncomingCommands();
		}
		int num = (int)(Time.realtimeSinceStartup * 1000f);
		if (PhotonNetwork.isMessageQueueRunning && num > this.nextSendTickCountOnSerialize)
		{
			PhotonNetwork.networkingPeer.RunViewUpdate();
			this.nextSendTickCountOnSerialize = num + this.updateIntervalOnSerialize;
			this.nextSendTickCount = 0;
		}
		num = (int)(Time.realtimeSinceStartup * 1000f);
		if (num > this.nextSendTickCount)
		{
			bool flag2 = true;
			while (PhotonNetwork.isMessageQueueRunning && flag2)
			{
				flag2 = PhotonNetwork.networkingPeer.SendOutgoingCommands();
			}
			this.nextSendTickCount = num + this.updateInterval;
		}
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x0004858A File Offset: 0x0004698A
	protected void OnApplicationQuit()
	{
		PhotonNetwork.Disconnect();
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x00048591 File Offset: 0x00046991
	protected void OnLevelWasLoaded(int level)
	{
		PhotonNetwork.networkingPeer.NewSceneLoaded();
		if (PhotonNetwork.automaticallySyncScene)
		{
			this.SetSceneInProps();
		}
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x000485AD File Offset: 0x000469AD
	protected void OnJoinedRoom()
	{
		PhotonNetwork.networkingPeer.AutomaticallySyncScene();
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x000485B9 File Offset: 0x000469B9
	protected void OnCreatedRoom()
	{
		if (PhotonNetwork.automaticallySyncScene)
		{
			this.SetSceneInProps();
		}
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x000485CC File Offset: 0x000469CC
	protected internal void SetSceneInProps()
	{
		if (PhotonNetwork.isMasterClient)
		{
			Hashtable hashtable = new Hashtable();
			hashtable["curScn"] = Application.loadedLevelName;
			PhotonNetwork.room.SetCustomProperties(hashtable);
		}
	}

	// Token: 0x06000770 RID: 1904 RVA: 0x00048604 File Offset: 0x00046A04
	public static void StartThread()
	{
		Thread thread = new Thread(new ThreadStart(PhotonHandler.MyThread));
		thread.Start();
	}

	// Token: 0x06000771 RID: 1905 RVA: 0x00048629 File Offset: 0x00046A29
	public static void MyThread()
	{
		while (PhotonNetwork.networkingPeer != null && PhotonNetwork.networkingPeer.IsSendingOnlyAcks)
		{
			while (PhotonNetwork.networkingPeer.SendAcksOnly())
			{
			}
			Thread.Sleep(50);
		}
	}

	// Token: 0x06000772 RID: 1906 RVA: 0x00048664 File Offset: 0x00046A64
	public void DebugReturn(DebugLevel level, string message)
	{
		if (level != DebugLevel.ERROR)
		{
			if (level == DebugLevel.WARNING)
			{
				Debug.LogWarning(message);
			}
			else if (level == DebugLevel.INFO && PhotonNetwork.logLevel >= PhotonLogLevel.Informational)
			{
				Debug.Log(message);
			}
			else if (level == DebugLevel.ALL && PhotonNetwork.logLevel == PhotonLogLevel.Full)
			{
				Debug.Log(message);
			}
		}
	}

	// Token: 0x06000773 RID: 1907 RVA: 0x000486C4 File Offset: 0x00046AC4
	public void OnOperationResponse(OperationResponse operationResponse)
	{
	}

	// Token: 0x06000774 RID: 1908 RVA: 0x000486C6 File Offset: 0x00046AC6
	public void OnStatusChanged(StatusCode statusCode)
	{
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x000486C8 File Offset: 0x00046AC8
	public void OnEvent(EventData photonEvent)
	{
	}

	// Token: 0x040009E0 RID: 2528
	public static PhotonHandler SP;

	// Token: 0x040009E1 RID: 2529
	public int updateInterval;

	// Token: 0x040009E2 RID: 2530
	public int updateIntervalOnSerialize;

	// Token: 0x040009E3 RID: 2531
	private int nextSendTickCount;

	// Token: 0x040009E4 RID: 2532
	private int nextSendTickCountOnSerialize;
}
