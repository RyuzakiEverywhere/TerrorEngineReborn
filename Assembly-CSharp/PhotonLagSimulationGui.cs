using System;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x02000141 RID: 321
public class PhotonLagSimulationGui : MonoBehaviour
{
	// Token: 0x17000047 RID: 71
	// (get) Token: 0x06000777 RID: 1911 RVA: 0x00048700 File Offset: 0x00046B00
	// (set) Token: 0x06000778 RID: 1912 RVA: 0x00048708 File Offset: 0x00046B08
	public PhotonPeer Peer { get; set; }

	// Token: 0x06000779 RID: 1913 RVA: 0x00048711 File Offset: 0x00046B11
	public void Start()
	{
		this.Peer = PhotonNetwork.networkingPeer;
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x00048720 File Offset: 0x00046B20
	public void OnGUI()
	{
		if (!this.Visible)
		{
			return;
		}
		if (this.Peer == null)
		{
			this.WindowRect = GUILayout.Window(this.WindowId, this.WindowRect, new GUI.WindowFunction(this.NetSimHasNoPeerWindow), "Netw. Sim.", new GUILayoutOption[0]);
		}
		else
		{
			this.WindowRect = GUILayout.Window(this.WindowId, this.WindowRect, new GUI.WindowFunction(this.NetSimWindow), "Netw. Sim.", new GUILayoutOption[0]);
		}
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x000487A5 File Offset: 0x00046BA5
	private void NetSimHasNoPeerWindow(int windowId)
	{
		GUILayout.Label("No peer to communicate with. ", new GUILayoutOption[0]);
	}

	// Token: 0x0600077C RID: 1916 RVA: 0x000487B8 File Offset: 0x00046BB8
	private void NetSimWindow(int windowId)
	{
		GUILayout.Label(string.Format("Rtt:{0,4} +/-{1,3}", this.Peer.RoundTripTime, this.Peer.RoundTripTimeVariance), new GUILayoutOption[0]);
		bool isSimulationEnabled = this.Peer.IsSimulationEnabled;
		bool flag = GUILayout.Toggle(isSimulationEnabled, "Simulate", new GUILayoutOption[0]);
		if (flag != isSimulationEnabled)
		{
			this.Peer.IsSimulationEnabled = flag;
		}
		float num = (float)this.Peer.NetworkSimulationSettings.IncomingLag;
		GUILayout.Label("Lag " + num, new GUILayoutOption[0]);
		num = GUILayout.HorizontalSlider(num, 0f, 500f, new GUILayoutOption[0]);
		this.Peer.NetworkSimulationSettings.IncomingLag = (int)num;
		this.Peer.NetworkSimulationSettings.OutgoingLag = (int)num;
		float num2 = (float)this.Peer.NetworkSimulationSettings.IncomingJitter;
		GUILayout.Label("Jit " + num2, new GUILayoutOption[0]);
		num2 = GUILayout.HorizontalSlider(num2, 0f, 100f, new GUILayoutOption[0]);
		this.Peer.NetworkSimulationSettings.IncomingJitter = (int)num2;
		this.Peer.NetworkSimulationSettings.OutgoingJitter = (int)num2;
		float num3 = (float)this.Peer.NetworkSimulationSettings.IncomingLossPercentage;
		GUILayout.Label("Loss " + num3, new GUILayoutOption[0]);
		num3 = GUILayout.HorizontalSlider(num3, 0f, 10f, new GUILayoutOption[0]);
		this.Peer.NetworkSimulationSettings.IncomingLossPercentage = (int)num3;
		this.Peer.NetworkSimulationSettings.OutgoingLossPercentage = (int)num3;
		if (GUI.changed)
		{
			this.WindowRect.height = 100f;
		}
		GUI.DragWindow();
	}

	// Token: 0x040009E5 RID: 2533
	public Rect WindowRect = new Rect(0f, 100f, 120f, 100f);

	// Token: 0x040009E6 RID: 2534
	public int WindowId = 101;

	// Token: 0x040009E7 RID: 2535
	public bool Visible = true;
}
