using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000044 RID: 68
public class TimerZone : MonoBehaviour
{
	// Token: 0x0600014B RID: 331 RVA: 0x000124FC File Offset: 0x000108FC
	private void Start()
	{
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
		this.imessage = this.tp.imessage;
		this.text = this.tp.text;
		this.pa = base.gameObject.AddComponent<PlayAudio>();
		this.ov = base.gameObject.AddComponent<ObjectVisible>();
		this.manualimage = this.tp.imgmanually;
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0001263A File Offset: 0x00010A3A
	private void Update()
	{
		if (!this.hassent)
		{
			base.StartCoroutine(this.SendTimer(this.maintimer));
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0001265C File Offset: 0x00010A5C
	private IEnumerator SendTimer(float waitTime)
	{
		this.hassent = true;
		yield return new WaitForSeconds(waitTime);
		this.Send();
		if (this.looptimer)
		{
			this.hassent = false;
		}
		yield break;
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00012680 File Offset: 0x00010A80
	private void Send()
	{
		if (this.tp.playvideo)
		{
			this.videoobj.GetComponent<MovieStream>().path = this.videourl;
			this.videoobj.GetComponent<MovieStream>().StartCoroutine("GetVideo");
		}
		if (this.tp.displayimg && this.imageobj.haveimage)
		{
			this.imageobj.manual = this.manualimage;
			this.imageobj.imageurl = this.imageurl;
			this.imageobj.imagetime = this.imagetimer;
			this.imageobj.SendNow();
		}
		if (this.tp.playsound)
		{
			this.pa.audiourl = this.tp.soundpath;
			this.pa.soundloop = this.tp.soundloop;
			this.pa.SendAudio();
		}
		if (this.tp.enablecam)
		{
			base.StartCoroutine("SendCamera");
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
			this.ov.SendNow();
		}
		if (this.tp.door)
		{
			GameObject.Find(this.tp.doorname).GetComponent<Door>().islocked = !GameObject.Find(this.tp.doorname).GetComponent<Door>().islocked;
		}
		if (this.tp.displaytext)
		{
			base.StartCoroutine("SendText");
		}
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00012874 File Offset: 0x00010C74
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

	// Token: 0x06000150 RID: 336 RVA: 0x00012890 File Offset: 0x00010C90
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

	// Token: 0x06000151 RID: 337 RVA: 0x000128AB File Offset: 0x00010CAB
	private void BeginSend()
	{
		this.Send();
	}

	// Token: 0x040001FA RID: 506
	public float maintimer;

	// Token: 0x040001FB RID: 507
	public float maintimermax;

	// Token: 0x040001FC RID: 508
	public TimerProperties tp;

	// Token: 0x040001FD RID: 509
	public bool looptimer;

	// Token: 0x040001FE RID: 510
	public string imessage;

	// Token: 0x040001FF RID: 511
	public string text;

	// Token: 0x04000200 RID: 512
	public GameObject imessageobj;

	// Token: 0x04000201 RID: 513
	public GameObject textobj;

	// Token: 0x04000202 RID: 514
	public GameObject videoobj;

	// Token: 0x04000203 RID: 515
	public ImagePopup imageobj;

	// Token: 0x04000204 RID: 516
	public PlayAudio pa;

	// Token: 0x04000205 RID: 517
	public ObjectVisible ov;

	// Token: 0x04000206 RID: 518
	public string camstring;

	// Token: 0x04000207 RID: 519
	public GameObject camobj;

	// Token: 0x04000208 RID: 520
	public float imagetimer;

	// Token: 0x04000209 RID: 521
	public float texttimer;

	// Token: 0x0400020A RID: 522
	public float camdur;

	// Token: 0x0400020B RID: 523
	public string videourl;

	// Token: 0x0400020C RID: 524
	public string audiourl;

	// Token: 0x0400020D RID: 525
	public string imageurl;

	// Token: 0x0400020E RID: 526
	public WWW video;

	// Token: 0x0400020F RID: 527
	public WWW image;

	// Token: 0x04000210 RID: 528
	public WWW audio2;

	// Token: 0x04000211 RID: 529
	public Texture imagetex;

	// Token: 0x04000212 RID: 530
	public AudioClip audioc;

	// Token: 0x04000213 RID: 531
	public bool starttextimer;

	// Token: 0x04000214 RID: 532
	public bool startimagetimer;

	// Token: 0x04000215 RID: 533
	public bool startcamera;

	// Token: 0x04000216 RID: 534
	public bool manualimage;

	// Token: 0x04000217 RID: 535
	public string toggleobjnames;

	// Token: 0x04000218 RID: 536
	public bool hassent;
}
