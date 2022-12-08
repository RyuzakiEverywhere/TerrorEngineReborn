using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class SpawnPlayers : Photon.MonoBehaviour
{
	// Token: 0x06000117 RID: 279 RVA: 0x0000FF48 File Offset: 0x0000E348
	private void Awake()
	{
		this.GM = GameObject.Find("GameManager");
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1)
		{
			base.StartCoroutine(this.SpawnNow(1f));
			this.spawn = true;
			this.totalplayers = 1;
			this.text = string.Empty;
		}
		else
		{
			this.totalplayers = CryptoPlayerPrefs.GetInt("TotalPlayers", 0);
			this.text = "Waiting For Players To Join...";
			this.showtext = true;
		}
	}

	// Token: 0x06000118 RID: 280 RVA: 0x0000FFC9 File Offset: 0x0000E3C9
	private void Start()
	{
	}

	// Token: 0x06000119 RID: 281 RVA: 0x0000FFCC File Offset: 0x0000E3CC
	private void Update()
	{
		this.gos = GameObject.FindGameObjectsWithTag("newplayer");
		if (GameObject.Find("StartGame") != null && !this.spawn)
		{
			base.StartCoroutine(this.SpawnNow(1f));
			this.spawn = true;
		}
	}

	// Token: 0x0600011A RID: 282 RVA: 0x00010024 File Offset: 0x0000E424
	private IEnumerator SpawnNow(float waitTime)
	{
		this.spawn = true;
		yield return new WaitForSeconds(waitTime);
		if (this.player == null && base.photonView.isMine)
		{
			if (PhotonNetwork.isMasterClient && GameObject.Find("Settings").GetComponent<SettingsProperties>().versus)
			{
				this.player = PhotonNetwork.Instantiate("NPCPlayer", new Vector3(GameObject.Find("Events/Monster Start Point").transform.position.x, GameObject.Find("Events/Monster Start Point").transform.position.y + 1.5f, GameObject.Find("Events/Monster Start Point").transform.position.z), GameObject.Find("Events/Monster Start Point").transform.rotation, 0, null);
			}
			else
			{
				this.player = PhotonNetwork.Instantiate("Player", base.transform.position, base.transform.rotation, 0, null);
			}
			if (!PhotonNetwork.isMasterClient && this.player == null)
			{
				this.player = PhotonNetwork.Instantiate("Player", base.transform.position, base.transform.rotation, 0, null);
			}
		}
		yield break;
	}

	// Token: 0x0600011B RID: 283 RVA: 0x00010048 File Offset: 0x0000E448
	private void OnGUI()
	{
		if (!this.spawn && this.showtext && base.photonView.isMine)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 100), (float)(Screen.height / 2 - 10), 1000f, 100f), string.Concat(new string[]
			{
				"  <b>",
				this.text,
				"</b>\n\n | Current Amount Of Players: ",
				this.gos.Length.ToString(),
				" |"
			}));
			if (PhotonNetwork.isMasterClient)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				GUI.skin = this.guiSkin;
				GUI.Label(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 + 80), 600f, 30f), "NOTICE: When you start the game it will be hidden from the Lobby.");
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), (float)(Screen.height / 2 + 50), 200f, 30f), "Start Game"))
				{
					PhotonNetwork.InstantiateSceneObject("StartGame", base.transform.position, base.transform.rotation, 0, null);
					Cursor.visible = false;
					Cursor.lockState = CursorLockMode.Locked;
				}
			}
		}
	}

	// Token: 0x0600011C RID: 284 RVA: 0x000101A0 File Offset: 0x0000E5A0
	[RPC]
	private void BeginSpawn()
	{
		base.StartCoroutine(this.SpawnNow(1f));
	}

	// Token: 0x040001A8 RID: 424
	public GameObject[] gos;

	// Token: 0x040001A9 RID: 425
	public int totalplayers;

	// Token: 0x040001AA RID: 426
	public GameObject GM;

	// Token: 0x040001AB RID: 427
	public bool spawn;

	// Token: 0x040001AC RID: 428
	public GameObject player;

	// Token: 0x040001AD RID: 429
	public string text;

	// Token: 0x040001AE RID: 430
	public bool showtext;

	// Token: 0x040001AF RID: 431
	public GUISkin guiSkin;
}
