using System;
using UnityEngine;

// Token: 0x02000158 RID: 344
public class ServerTime : MonoBehaviour
{
	// Token: 0x06000849 RID: 2121 RVA: 0x0004B654 File Offset: 0x00049A54
	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect((float)(Screen.width / 2 - 100), 0f, 200f, 30f));
		GUILayout.Label(string.Format("Time Offset: {0}", PhotonNetwork.networkingPeer.ServerTimeInMilliSeconds - Environment.TickCount), new GUILayoutOption[0]);
		if (GUILayout.Button("fetch", new GUILayoutOption[0]))
		{
			PhotonNetwork.networkingPeer.FetchServerTimestamp();
		}
		GUILayout.EndArea();
	}
}
