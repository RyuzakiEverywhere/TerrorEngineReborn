using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200014C RID: 332
[Serializable]
public class ServerSettings : ScriptableObject
{
	// Token: 0x06000821 RID: 2081 RVA: 0x0004AE88 File Offset: 0x00049288
	public static int FindRegionForServerAddress(string server)
	{
		int result = 0;
		for (int i = 0; i < ServerSettings.CloudServerRegionPrefixes.Length; i++)
		{
			if (server.StartsWith(ServerSettings.CloudServerRegionPrefixes[i]))
			{
				return i;
			}
		}
		return result;
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x0004AEC4 File Offset: 0x000492C4
	public static string FindServerAddressForRegion(int regionIndex)
	{
		return ServerSettings.DefaultCloudServerUrl.Replace("app-eu", ServerSettings.CloudServerRegionPrefixes[regionIndex]);
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x0004AEDC File Offset: 0x000492DC
	public void UseCloud(string cloudAppid, int regionIndex)
	{
		this.HostType = ServerSettings.HostingOption.PhotonCloud;
		this.AppID = cloudAppid;
		this.ServerAddress = ServerSettings.FindServerAddressForRegion(regionIndex);
		this.ServerPort = ServerSettings.DefaultMasterPort;
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x0004AF03 File Offset: 0x00049303
	public void UseMyServer(string serverAddress, int serverPort, string application)
	{
		this.HostType = ServerSettings.HostingOption.SelfHosted;
		this.AppID = ((application == null) ? ServerSettings.DefaultAppID : application);
		this.ServerAddress = serverAddress;
		this.ServerPort = serverPort;
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x0004AF31 File Offset: 0x00049331
	public override string ToString()
	{
		return string.Concat(new object[]
		{
			"ServerSettings: ",
			this.HostType,
			" ",
			this.ServerAddress
		});
	}

	// Token: 0x04000A33 RID: 2611
	public static string DefaultCloudServerUrl = "app-eu.exitgamescloud.com";

	// Token: 0x04000A34 RID: 2612
	public static string[] CloudServerRegionNames = new string[]
	{
		"EU",
		"US",
		"Asia",
		"Japan"
	};

	// Token: 0x04000A35 RID: 2613
	public static string[] CloudServerRegionPrefixes = new string[]
	{
		"app-eu",
		"app-us",
		"app-asia",
		"app-jp"
	};

	// Token: 0x04000A36 RID: 2614
	public static string DefaultServerAddress = "127.0.0.1";

	// Token: 0x04000A37 RID: 2615
	public static int DefaultMasterPort = 5055;

	// Token: 0x04000A38 RID: 2616
	public static string DefaultAppID = "Master";

	// Token: 0x04000A39 RID: 2617
	public ServerSettings.HostingOption HostType;

	// Token: 0x04000A3A RID: 2618
	public string ServerAddress = ServerSettings.DefaultServerAddress;

	// Token: 0x04000A3B RID: 2619
	public int ServerPort = 5055;

	// Token: 0x04000A3C RID: 2620
	public string AppID = string.Empty;

	// Token: 0x04000A3D RID: 2621
	public List<string> RpcList;

	// Token: 0x04000A3E RID: 2622
	[HideInInspector]
	public bool DisableAutoOpenWizard;

	// Token: 0x0200014D RID: 333
	public enum HostingOption
	{
		// Token: 0x04000A40 RID: 2624
		NotSet,
		// Token: 0x04000A41 RID: 2625
		PhotonCloud,
		// Token: 0x04000A42 RID: 2626
		SelfHosted,
		// Token: 0x04000A43 RID: 2627
		OfflineMode
	}
}
