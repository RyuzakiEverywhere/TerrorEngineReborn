using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000127 RID: 295
public class MainMenuSP : MonoBehaviour
{
	// Token: 0x060006A6 RID: 1702 RVA: 0x00041F48 File Offset: 0x00040348
	private void Awake()
	{
		if (!PhotonNetwork.connected)
		{
			PhotonNetwork.ConnectUsingSettings("1.0");
		}
		if (string.IsNullOrEmpty(PhotonNetwork.playerName))
		{
			PhotonNetwork.playerName = "Guest" + UnityEngine.Random.Range(1, 9999);
		}
		PhotonNetwork.offlineMode = true;
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x00041F9D File Offset: 0x0004039D
	private void Start()
	{
		base.StartCoroutine(this.BeginNow(3f));
	}

	// Token: 0x060006A8 RID: 1704 RVA: 0x00041FB4 File Offset: 0x000403B4
	private IEnumerator BeginNow(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		PhotonNetwork.CreateRoom(this.roomName, true, true, 10);
		PlayerPrefs.SetInt("Mode", 1);
		yield break;
	}

	// Token: 0x060006A9 RID: 1705 RVA: 0x00041FD8 File Offset: 0x000403D8
	private void OnGUI()
	{
		if (!PhotonNetwork.connected)
		{
			if (PhotonNetwork.connectionState == ConnectionState.Connecting)
			{
				GUILayout.Label("Connecting " + PhotonNetwork.networkingPeer.ServerAddress, new GUILayoutOption[0]);
				GUILayout.Label(Time.time.ToString(), new GUILayoutOption[0]);
			}
			else
			{
				GUILayout.Label("Not connected. Check console output.", new GUILayoutOption[0]);
			}
			if (this.connectFailed)
			{
				GUILayout.Label("Connection failed. Check setup and use Setup Wizard to fix configuration.", new GUILayoutOption[0]);
				GUILayout.Label(string.Format("Server: {0}:{1}", new object[]
				{
					PhotonNetwork.PhotonServerSettings.ServerAddress,
					PhotonNetwork.PhotonServerSettings.ServerPort
				}), new GUILayoutOption[0]);
				GUILayout.Label("AppId: " + PhotonNetwork.PhotonServerSettings.AppID, new GUILayoutOption[0]);
				if (GUILayout.Button("Try Again", new GUILayoutOption[]
				{
					GUILayout.Width(100f)
				}))
				{
					this.connectFailed = false;
					PhotonNetwork.ConnectUsingSettings("1.0");
				}
			}
			return;
		}
		if (this.showgui)
		{
			GUI.skin.box.fontStyle = FontStyle.Bold;
			GUI.Box(new Rect((float)((Screen.width - 400) / 2), (float)((Screen.height - 350) / 2), 400f, 330f), "NOTICE");
			if (GUI.Button(new Rect((float)((Screen.width - 390) / 2), (float)((Screen.height - 278) / 2), 390f, 20f), "Play Test-Mode"))
			{
				PhotonNetwork.CreateRoom(this.roomName, true, true, 10);
				PlayerPrefs.SetInt("Mode", 1);
			}
			GUI.Label(new Rect((float)((Screen.width - 390) / 2), (float)((Screen.height - 230) / 2), 390f, 300f), "NOTICE:  This is only the DEVELOPER EDITION V3 and not the final Terror Engine product! \nThis Developer Edition will have many limits compared to the official release of 'Terror Engine'.  \n\nThese Limits include:\n-You can not build standalones\n-There will be less effects, models and walls\n\nWhat ever you create in this Developer Edition you will be able to use in the official release of 'Terror Engine'.  \nHappy gaming!\n~Sean");
		}
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x000421CD File Offset: 0x000405CD
	private void OnJoinedRoom()
	{
		base.StartCoroutine(this.MoveToGameScene());
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x000421DC File Offset: 0x000405DC
	private void OnCreatedRoom()
	{
		Debug.Log("OnCreatedRoom");
		base.StartCoroutine(this.MoveToGameScene());
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x000421F5 File Offset: 0x000405F5
	private void OnDisconnectedFromPhoton()
	{
		Debug.Log("Disconnected from Photon.");
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x00042201 File Offset: 0x00040601
	private void OnFailedToConnectToPhoton(object parameters)
	{
		this.connectFailed = true;
		Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters);
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x0004221C File Offset: 0x0004061C
	private IEnumerator MoveToGameScene()
	{
		Debug.Log("MoveToGameScene");
		while (PhotonNetwork.room == null)
		{
			yield return 0;
		}
		PhotonNetwork.isMessageQueueRunning = false;
		this.CodeGame.gameObject.SetActive(true);
		PhotonNetwork.isMessageQueueRunning = true;
		base.GetComponent<Camera>().enabled = false;
		yield break;
	}

	// Token: 0x040008FD RID: 2301
	public Transform CodeGame;

	// Token: 0x040008FE RID: 2302
	private string roomName = "myRoom";

	// Token: 0x040008FF RID: 2303
	private Vector2 scrollPos = Vector2.zero;

	// Token: 0x04000900 RID: 2304
	private bool connectFailed;

	// Token: 0x04000901 RID: 2305
	public bool showgui;

	// Token: 0x04000902 RID: 2306
	public bool begin;
}
