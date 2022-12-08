using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000047 RID: 71
public class TriggerZoneOffline : MonoBehaviour
{
	// Token: 0x06000168 RID: 360 RVA: 0x000138EC File Offset: 0x00011CEC
	private IEnumerator Start()
	{
		this.tp = base.gameObject.GetComponent<TriggerProperties>();
		yield return new WaitForEndOfFrame();
		if (this.tp.onenter)
		{
			this.ontriggerenter = true;
		}
		if (this.tp.interactive)
		{
			this.onstay = true;
			this.imessage = this.tp.imessage;
		}
		if (this.tp.destroyonexit)
		{
			this.onexit = true;
		}
		this.imessageobj = GameObject.Find("GUIimessage");
		this.textobj = GameObject.Find("GUIText");
		this.videoobj = GameObject.Find("GUIVideo");
		this.imageobj = GameObject.Find("GUIImage").GetComponent<ImagePopup>();
		this.videourl = this.tp.videopath;
		this.imageurl = this.tp.imgpath;
		this.audiourl = this.tp.soundpath;
		this.camstring = this.tp.camname;
		this.camdur = float.Parse(this.tp.camduration);
		this.texttimer = float.Parse(this.tp.textduration);
		this.imagetimer = float.Parse(this.tp.imgduration);
		this.toggleobjnames = this.tp.toggleid;
		this.text = this.tp.text;
		this.imessage = this.tp.imessage;
		this.pa = base.gameObject.AddComponent<PlayAudio>();
		this.ov = base.gameObject.AddComponent<ObjectVisible>();
		this.manualimage = this.tp.imgmanually;
		yield break;
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00013907 File Offset: 0x00011D07
	private void LateUpdate()
	{
		if (this.startSend)
		{
			base.StartCoroutine(this.Send());
			this.startSend = false;
		}
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00013928 File Offset: 0x00011D28
	private void OnTriggerEnter(Collider other)
	{
		if (!this.onstay && other.transform.tag == "Player" && !this.destroyNow)
		{
			if (!this.hasentered)
			{
				this.startSend = true;
			}
			if (this.onexit)
			{
				this.hasentered = true;
			}
		}
	}

	// Token: 0x0600016B RID: 363 RVA: 0x0001398C File Offset: 0x00011D8C
	private void OnTriggerStay(Collider other)
	{
		if (this.onstay && other.gameObject.tag == "Player" && other.GetComponent<PhotonView>().isMine)
		{
			this.imessage = this.tp.imessage;
			this.imessageobj.GetComponent<GUIText>().text = "Press E " + this.imessage;
			this.imessageobj.GetComponent<GUIText>().enabled = true;
			if (Input.GetKey(KeyCode.E))
			{
				this.startSend = true;
				base.StartCoroutine(this.BeginDestroy());
			}
		}
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00013A30 File Offset: 0x00011E30
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (this.onexit)
			{
				base.StartCoroutine(this.BeginDestroy());
			}
			if (this.onstay)
			{
				this.imessageobj.GetComponent<GUIText>().enabled = false;
			}
		}
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00013A8C File Offset: 0x00011E8C
	private IEnumerator Send()
	{
		if (this.tp.playvideo)
		{
			this.videoobj.GetComponent<MovieStream>().path = this.videourl;
			this.videoobj.GetComponent<MovieStream>().StartCoroutine("GetVideo");
		}
		if (this.tp.displayimg && !this.imageobj.haveimage)
		{
			this.imageobj.manual = this.manualimage;
			this.imageobj.imageurl = this.imageurl;
			this.imageobj.imagetime = this.imagetimer;
			yield return new WaitForEndOfFrame();
			this.imageobj.SendNow();
		}
		if (this.tp.playsound)
		{
			this.pa.audiourl = this.tp.soundpath;
			this.pa.soundloop = this.tp.soundloop;
			yield return new WaitForEndOfFrame();
			this.pa.SendAudio();
		}
		if (this.tp.enablecam)
		{
			base.StartCoroutine(this.SendCamera());
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
			this.ov.toggleobjnames = this.toggleobjnames;
			yield return new WaitForEndOfFrame();
			this.ov.SendNow();
		}
		if (this.tp.door)
		{
			GameObject.Find(this.tp.doorname).GetComponent<Door>().islocked = !GameObject.Find(this.tp.doorname).GetComponent<Door>().islocked;
		}
		if (this.tp.displaytext)
		{
			base.StartCoroutine(this.SendText());
		}
		if (this.onexit && !this.onstay)
		{
			this.hasentered = true;
		}
		yield break;
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00013AA8 File Offset: 0x00011EA8
	private IEnumerator SendText()
	{
		this.textobj.GetComponent<GUIText>().text = this.text;
		this.textobj.GetComponent<GUIText>().enabled = true;
		yield return new WaitForSeconds(this.texttimer);
		this.textobj.GetComponent<GUIText>().text = null;
		this.textobj.GetComponent<GUIText>().enabled = false;
		this.starttextimer = false;
		yield break;
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00013AC4 File Offset: 0x00011EC4
	private IEnumerator SendCamera()
	{
		this.camobj = GameObject.Find(this.camstring);
		if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "OVR")
		{
			Transform transform = this.camobj.transform.Find("OVRCamera");
			transform.gameObject.SetActive(true);
			Transform transform2 = transform.transform.Find("CameraLeft");
			Transform transform3 = transform.transform.Find("CameraRight");
			transform2.GetComponent<Camera>().enabled = true;
			transform3.GetComponent<Camera>().enabled = true;
		}
		else
		{
			this.camobj.GetComponent<Camera>().enabled = true;
		}
		yield return new WaitForSeconds(this.camdur);
		if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "OVR")
		{
			Transform transform4 = this.camobj.transform.Find("OVRCamera");
			Transform transform5 = transform4.transform.Find("CameraLeft");
			Transform transform6 = transform4.transform.Find("CameraRight");
			transform5.GetComponent<Camera>().enabled = false;
			transform6.GetComponent<Camera>().enabled = false;
		}
		else
		{
			this.camobj.GetComponent<Camera>().enabled = false;
		}
		yield break;
	}

	// Token: 0x06000170 RID: 368 RVA: 0x00013ADF File Offset: 0x00011EDF
	private void BeginSend()
	{
		base.StartCoroutine(this.Send());
	}

	// Token: 0x06000171 RID: 369 RVA: 0x00013AF0 File Offset: 0x00011EF0
	private IEnumerator BeginDestroy()
	{
		this.destroyNow = true;
		this.imessageobj.GetComponent<GUIText>().enabled = false;
		if (base.gameObject.GetComponent<Collider>() != null)
		{
			base.gameObject.GetComponent<Collider>().enabled = false;
		}
		yield return new WaitForEndOfFrame();
		yield break;
	}

	// Token: 0x0400023B RID: 571
	public TriggerProperties tp;

	// Token: 0x0400023C RID: 572
	public bool ontriggerenter;

	// Token: 0x0400023D RID: 573
	public bool onstay;

	// Token: 0x0400023E RID: 574
	public bool onexit;

	// Token: 0x0400023F RID: 575
	public bool manualimage;

	// Token: 0x04000240 RID: 576
	public string imessage;

	// Token: 0x04000241 RID: 577
	public string text;

	// Token: 0x04000242 RID: 578
	public GameObject imessageobj;

	// Token: 0x04000243 RID: 579
	public GameObject textobj;

	// Token: 0x04000244 RID: 580
	public GameObject videoobj;

	// Token: 0x04000245 RID: 581
	public ImagePopup imageobj;

	// Token: 0x04000246 RID: 582
	public PlayAudio pa;

	// Token: 0x04000247 RID: 583
	public ObjectVisible ov;

	// Token: 0x04000248 RID: 584
	public string camstring;

	// Token: 0x04000249 RID: 585
	public GameObject camobj;

	// Token: 0x0400024A RID: 586
	public float imagetimer;

	// Token: 0x0400024B RID: 587
	public float texttimer;

	// Token: 0x0400024C RID: 588
	public float camdur;

	// Token: 0x0400024D RID: 589
	public string videourl;

	// Token: 0x0400024E RID: 590
	public string audiourl;

	// Token: 0x0400024F RID: 591
	public string imageurl;

	// Token: 0x04000250 RID: 592
	public WWW video;

	// Token: 0x04000251 RID: 593
	public WWW image;

	// Token: 0x04000252 RID: 594
	public WWW audio2;

	// Token: 0x04000253 RID: 595
	public Texture imagetex;

	// Token: 0x04000254 RID: 596
	public AudioClip audioc;

	// Token: 0x04000255 RID: 597
	public bool starttextimer;

	// Token: 0x04000256 RID: 598
	public bool startimagetimer;

	// Token: 0x04000257 RID: 599
	public bool startcamera;

	// Token: 0x04000258 RID: 600
	public string toggleobjnames;

	// Token: 0x04000259 RID: 601
	public bool hasentered;

	// Token: 0x0400025A RID: 602
	public bool destroyNow;

	// Token: 0x0400025B RID: 603
	public bool startSend;
}
