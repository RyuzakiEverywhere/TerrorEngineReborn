using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class Death : Photon.MonoBehaviour
{
	// Token: 0x0600005B RID: 91 RVA: 0x00007E60 File Offset: 0x00006260
	private void Awake()
	{
		if (base.photonView.isMine)
		{
			if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "OVR")
			{
				this.cam = base.gameObject.GetComponent<checkcamsettings>().PlayerOVR;
				this.orgpos = this.cam.position;
			}
			else
			{
				this.cam = base.gameObject.GetComponent<checkcamsettings>().PlayerCam;
				this.orgpos = this.cam.position;
			}
		}
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00007EF0 File Offset: 0x000062F0
	private void Update()
	{
		if (base.photonView.isMine)
		{
			if (this.isdead)
			{
				base.gameObject.transform.tag = "Untagged";
				base.gameObject.GetComponent<PickUp>().enabled = false;
				base.gameObject.GetComponent<SwitchEquipment>().enabled = false;
				if (this.movecam)
				{
					base.StartCoroutine(this.MoveCamera(1.5f));
				}
			}
			else
			{
				base.gameObject.tag = "Player";
				this.cam.position = GameObject.Find("MoveCam").transform.position;
				this.fadeSpeed = 0.2f;
				this.drawDepth = -1000f;
				this.alpha = 1f;
				this.fadeDir = -1f;
				base.gameObject.GetComponent<PickUp>().enabled = true;
				base.gameObject.GetComponent<SwitchEquipment>().enabled = true;
				base.gameObject.GetComponent<PlayerHealth>().health = base.gameObject.GetComponent<PlayerHealth>().maxhealth;
				base.gameObject.GetComponent<PlayerHealth>().enabled = true;
				this.movecam = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00008030 File Offset: 0x00006430
	private IEnumerator MoveCamera(float waitTime)
	{
		this.cam.Translate(Vector3.down * Time.deltaTime);
		this.players = GameObject.FindGameObjectWithTag("Player");
		this.alpha += this.fadeDir * this.fadeSpeed * Time.deltaTime;
		this.alpha = Mathf.Clamp01(this.alpha);
		yield return new WaitForSeconds(waitTime);
		if (GameObject.Find("Settings").GetComponent<SettingsProperties>().canrespawn)
		{
			if (this.players == null)
			{
				PhotonNetwork.LeaveRoom();
				PhotonNetwork.Disconnect();
				Application.LoadLevel(3);
			}
			else
			{
				base.gameObject.transform.position = this.players.transform.position;
				this.movecam = false;
				this.isdead = false;
				if (GameObject.Find("Settings").GetComponent<SettingsProperties>().camtype == 3)
				{
					base.gameObject.GetComponent<NearestCinematicCam>().target = null;
					base.gameObject.GetComponent<NearestCinematicCam>().enabled = true;
					GameObject normalcam = GameObject.Find("PlayerCamera");
					while (base.gameObject.GetComponent<NearestCinematicCam>().target == null)
					{
						yield return new WaitForEndOfFrame();
					}
					normalcam.transform.parent = null;
					Transform ct = base.gameObject.GetComponent<NearestCinematicCam>().target.transform;
					normalcam.transform.parent = ct.GetComponent<CinematicTrigger>().thecam.transform;
					normalcam.transform.localPosition = new Vector3(0f, 0f, 0f);
					normalcam.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					ct.GetComponent<CinematicTrigger>().thecam.GetComponent<CinematicCam>().enabled = true;
				}
			}
		}
		else
		{
			if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1)
			{
				PhotonNetwork.LeaveRoom();
				PhotonNetwork.Disconnect();
				Application.LoadLevel(3);
			}
			if (base.photonView.isMine)
			{
				GameObject.Find("Dead").GetComponent<ShowDead>().enabled = true;
			}
			PhotonNetwork.Destroy(base.gameObject);
		}
		yield break;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00008054 File Offset: 0x00006454
	private void OnGUI()
	{
		Color color = GUI.color;
		color.a = this.alpha;
		GUI.color = color;
		GUI.depth = Mathf.RoundToInt(this.drawDepth);
		GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.fadeTexture);
	}

	// Token: 0x04000091 RID: 145
	public Transform cam;

	// Token: 0x04000092 RID: 146
	public bool isdead;

	// Token: 0x04000093 RID: 147
	public Vector3 orgpos;

	// Token: 0x04000094 RID: 148
	public bool movecam;

	// Token: 0x04000095 RID: 149
	public GameObject players;

	// Token: 0x04000096 RID: 150
	public Texture2D fadeTexture;

	// Token: 0x04000097 RID: 151
	public float fadeSpeed = 0.6f;

	// Token: 0x04000098 RID: 152
	public float drawDepth = -1000f;

	// Token: 0x04000099 RID: 153
	private float alpha = 1f;

	// Token: 0x0400009A RID: 154
	private float fadeDir = -1f;
}
