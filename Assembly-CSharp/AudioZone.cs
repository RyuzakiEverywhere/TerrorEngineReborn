using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class AudioZone : MonoBehaviour
{
	// Token: 0x0600000A RID: 10 RVA: 0x00003940 File Offset: 0x00001D40
	private void OnEnable()
	{
		this.ap = this.org.GetComponent<AudioProperties>();
		this.url = this.ap.audioname;
		base.GetComponent<AudioSource>().pitch = this.ap.pitch;
		base.GetComponent<AudioSource>().volume = this.ap.volume;
		if (this.ap.loop)
		{
			base.GetComponent<AudioSource>().loop = true;
		}
		else
		{
			base.GetComponent<AudioSource>().loop = false;
		}
		if (!this.ap.is3d)
		{
			base.GetComponent<AudioSource>().spatialBlend = 0f;
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000039E8 File Offset: 0x00001DE8
	private void Start()
	{
		WWW www = new WWW("file:///" + Application.dataPath + "/Audio/" + this.url);
		base.GetComponent<AudioSource>().clip = www.GetAudioClip();
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00003A28 File Offset: 0x00001E28
	private void Update()
	{
		if (!base.GetComponent<AudioSource>().isPlaying && base.GetComponent<AudioSource>().clip.isReadyToPlay && !this.startedplaying)
		{
			base.GetComponent<AudioSource>().Play();
			this.startedplaying = true;
		}
	}

	// Token: 0x0400000B RID: 11
	public string url;

	// Token: 0x0400000C RID: 12
	public GameObject org;

	// Token: 0x0400000D RID: 13
	public bool startedplaying;

	// Token: 0x0400000E RID: 14
	public AudioProperties ap;
}
