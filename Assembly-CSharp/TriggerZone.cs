using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class TriggerZone : Photon.MonoBehaviour
{
	// Token: 0x0600015C RID: 348 RVA: 0x00012DF4 File Offset: 0x000111F4
	private void Awake()
	{
		this.org = GameObject.Find("Org " + base.gameObject.name);
		base.gameObject.transform.localScale = this.org.transform.localScale;
		this.tp = this.org.GetComponent<TriggerProperties>();
		if (this.org.GetComponent<TriggerProperties>().onenter)
		{
			this.ontriggerenter = true;
		}
		if (this.org.GetComponent<TriggerProperties>().interactive)
		{
			this.onstay = true;
			this.imessage = this.org.GetComponent<TriggerProperties>().imessage;
		}
		if (this.org.GetComponent<TriggerProperties>().destroyonexit)
		{
			this.onexit = true;
		}
		this.imessageobj = GameObject.Find("GUIimessage");
		this.textobj = GameObject.Find("GUIText");
		this.videoobj = GameObject.Find("GUIVideo");
		this.imageobj = GameObject.Find("GUIImage");
		this.videourl = this.tp.videopath;
		this.imageurl = this.tp.imgpath;
		this.audiourl = this.tp.soundpath;
		this.camstring = this.tp.camname;
		this.camdur = float.Parse(this.tp.camduration);
		this.texttimer = float.Parse(this.tp.textduration);
		this.imagetimer = float.Parse(this.tp.imgduration);
		this.toggleobjnames = this.tp.toggleid;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x00012F93 File Offset: 0x00011393
	private void Start()
	{
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00012F98 File Offset: 0x00011398
	private void Update()
	{
		if (this.starttextimer)
		{
			if (this.texttimer > 0f)
			{
				this.texttimer -= Time.deltaTime;
			}
			if (this.texttimer <= 0f)
			{
				this.textobj.GetComponent<GUIText>().text = null;
				this.textobj.GetComponent<GUIText>().enabled = false;
				this.starttextimer = false;
			}
		}
		if (this.startimagetimer)
		{
			if (this.imagetimer > 0f)
			{
				this.imagetimer -= Time.deltaTime;
			}
			if (this.imagetimer <= 0f)
			{
				this.imageobj.GetComponent<GUITexture>().texture = null;
				this.imageobj.GetComponent<GUITexture>().enabled = true;
				this.startimagetimer = false;
			}
		}
		if (this.startcamera)
		{
			if (this.camdur > 0f)
			{
				this.camdur -= Time.deltaTime;
			}
			if (this.camdur <= 0f)
			{
				if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "OVR")
				{
					Transform transform = this.camobj.transform.Find("OVRCamera");
					Transform transform2 = transform.transform.Find("CameraLeft");
					Transform transform3 = transform.transform.Find("CameraRight");
					transform2.GetComponent<Camera>().enabled = false;
					transform3.GetComponent<Camera>().enabled = false;
				}
				else
				{
					this.camobj.GetComponent<Camera>().enabled = false;
				}
				this.startcamera = false;
			}
		}
	}

	// Token: 0x0600015F RID: 351 RVA: 0x0001313C File Offset: 0x0001153C
	private void OnTriggerEnter(Collider other)
	{
		if (this.ontriggerenter && other.gameObject.tag == "Player" && base.photonView.isMine)
		{
			base.photonView.RPC("BeginSend", PhotonTargets.AllBuffered, new object[0]);
		}
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00013198 File Offset: 0x00011598
	private void OnTriggerStay(Collider other)
	{
		if (this.onstay && other.gameObject.tag == "Player" && other.GetComponent<PhotonView>().isMine)
		{
			this.imessage = this.tp.imessage;
			this.imessageobj.GetComponent<GUIText>().text = "Press E " + this.imessage;
			this.imessageobj.GetComponent<GUIText>().enabled = true;
			if (Input.GetKey(KeyCode.E))
			{
				base.photonView.RPC("BeginSend", PhotonTargets.AllBuffered, new object[0]);
				base.photonView.RPC("BeginDestroy", PhotonTargets.AllBuffered, new object[0]);
			}
		}
	}

	// Token: 0x06000161 RID: 353 RVA: 0x00013258 File Offset: 0x00011658
	private void OnTriggerExit(Collider other)
	{
		if (this.onexit && other.gameObject.tag == "Player")
		{
			base.photonView.RPC("BeginDestroy", PhotonTargets.AllBuffered, new object[0]);
		}
		if (this.onstay)
		{
			this.imessageobj.GetComponent<GUIText>().enabled = false;
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x000132C0 File Offset: 0x000116C0
	private void Send()
	{
		if (this.tp.displaytext)
		{
			this.text = this.tp.text;
			this.textobj.GetComponent<GUIText>().text = this.text;
			this.textobj.GetComponent<GUIText>().enabled = true;
			this.texttimer = float.Parse(this.tp.textduration);
			this.starttextimer = true;
		}
		if (this.tp.playvideo)
		{
			this.videoobj.GetComponent<MovieStream>().path = this.videourl;
			this.videoobj.GetComponent<MovieStream>().StartCoroutine("GetVideo");
		}
		if (this.tp.displayimg)
		{
			this.imageurl = this.tp.imgpath;
			this.imagetimer = float.Parse(this.tp.imgduration);
			this.startimagetimer = true;
			base.StartCoroutine("LoadImage");
		}
		if (this.tp.playsound)
		{
			this.audiourl = this.tp.soundpath;
			if (this.tp.soundloop)
			{
				base.gameObject.GetComponent<AudioSource>().loop = true;
			}
			base.StartCoroutine("LoadAudio");
		}
		if (this.tp.enablecam)
		{
			this.camobj = GameObject.Find(this.camstring);
			if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "OVR")
			{
				if (Camera.main.gameObject.name != "NPCCam")
				{
					Transform transform = this.camobj.transform.Find("OVRCamera");
					transform.gameObject.SetActive(true);
					Transform transform2 = transform.transform.Find("CameraLeft");
					Transform transform3 = transform.transform.Find("CameraRight");
					transform2.GetComponent<Camera>().enabled = true;
					transform3.GetComponent<Camera>().enabled = true;
				}
			}
			else if (Camera.main.gameObject.name != "NPCCam")
			{
				this.camobj.GetComponent<Camera>().enabled = true;
			}
			if (Camera.main.gameObject.name != "NPCCam")
			{
				this.startcamera = true;
			}
		}
		if (this.tp.teleport)
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject gameObject in array)
			{
				gameObject.transform.position = GameObject.Find(this.tp.nodename).transform.position;
			}
		}
		if (this.tp.toggleobj)
		{
			this.gameobj = (Resources.FindObjectsOfTypeAll(typeof(CheckVisible)) as CheckVisible[]);
			foreach (CheckVisible checkVisible in this.gameobj)
			{
				if (checkVisible.id == this.toggleobjnames)
				{
					checkVisible.gameObject.active = !checkVisible.gameObject.active;
				}
			}
		}
		if (this.tp.door)
		{
			GameObject.Find(this.tp.doorname).GetComponent<Door>().islocked = !GameObject.Find(this.tp.doorname).GetComponent<Door>().islocked;
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00013648 File Offset: 0x00011A48
	private IEnumerator LoadImage()
	{
		WWW image = new WWW("file:///" + Application.dataPath + "/Images/" + this.imageurl);
		yield return image;
		this.imagetex = image.texture;
		this.imageobj.GetComponent<GUITexture>().texture = this.imagetex;
		this.imageobj.GetComponent<GUITexture>().enabled = true;
		yield break;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00013664 File Offset: 0x00011A64
	private IEnumerator LoadAudio()
	{
		if (base.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().clip == null)
		{
			WWW audio2 = new WWW("file:///" + Application.dataPath + "/Audio/" + this.audiourl);
			yield return audio2;
			this.audioc = audio2.GetAudioClip();
			base.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = this.audioc;
		}
		base.GetComponent<AudioSource>().spatialBlend = 0f;
		base.GetComponent<AudioSource>().Play();
		yield break;
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0001367F File Offset: 0x00011A7F
	[RPC]
	private void BeginSend()
	{
		this.Send();
	}

	// Token: 0x06000166 RID: 358 RVA: 0x00013687 File Offset: 0x00011A87
	[RPC]
	private void BeginDestroy()
	{
		this.imessageobj.GetComponent<GUIText>().enabled = false;
		base.gameObject.GetComponent<Collider>().enabled = false;
	}

	// Token: 0x0400021E RID: 542
	public GameObject org;

	// Token: 0x0400021F RID: 543
	public TriggerProperties tp;

	// Token: 0x04000220 RID: 544
	public bool ontriggerenter;

	// Token: 0x04000221 RID: 545
	public bool onstay;

	// Token: 0x04000222 RID: 546
	public bool onexit;

	// Token: 0x04000223 RID: 547
	public string imessage;

	// Token: 0x04000224 RID: 548
	public string text;

	// Token: 0x04000225 RID: 549
	public GameObject imessageobj;

	// Token: 0x04000226 RID: 550
	public GameObject textobj;

	// Token: 0x04000227 RID: 551
	public GameObject videoobj;

	// Token: 0x04000228 RID: 552
	public GameObject imageobj;

	// Token: 0x04000229 RID: 553
	public string camstring;

	// Token: 0x0400022A RID: 554
	public GameObject camobj;

	// Token: 0x0400022B RID: 555
	public float imagetimer;

	// Token: 0x0400022C RID: 556
	public float texttimer;

	// Token: 0x0400022D RID: 557
	public float camdur;

	// Token: 0x0400022E RID: 558
	public string videourl;

	// Token: 0x0400022F RID: 559
	public string audiourl;

	// Token: 0x04000230 RID: 560
	public string imageurl;

	// Token: 0x04000231 RID: 561
	public WWW video;

	// Token: 0x04000232 RID: 562
	public WWW image;

	// Token: 0x04000233 RID: 563
	public WWW audio2;

	// Token: 0x04000234 RID: 564
	public Texture imagetex;

	// Token: 0x04000235 RID: 565
	public AudioClip audioc;

	// Token: 0x04000236 RID: 566
	public bool starttextimer;

	// Token: 0x04000237 RID: 567
	public bool startimagetimer;

	// Token: 0x04000238 RID: 568
	public bool startcamera;

	// Token: 0x04000239 RID: 569
	public CheckVisible[] gameobj;

	// Token: 0x0400023A RID: 570
	public string toggleobjnames;
}
