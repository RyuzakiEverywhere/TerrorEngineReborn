using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000037 RID: 55
public class PlayAudio : MonoBehaviour
{
	// Token: 0x060000F8 RID: 248 RVA: 0x0000F090 File Offset: 0x0000D490
	public void SendAudio()
	{
		base.StartCoroutine("LoadAudio");
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0000F0A0 File Offset: 0x0000D4A0
	private IEnumerator LoadAudio()
	{
		if (base.gameObject.GetComponent<AudioSource>() == null)
		{
			base.gameObject.AddComponent<AudioSource>();
		}
		base.gameObject.GetComponent<AudioSource>().spatialBlend = 0f;
		if (base.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().clip == null)
		{
			WWW audio2 = new WWW("file:///" + Application.dataPath + "/Audio/" + this.audiourl);
			yield return audio2;
			this.audioc = audio2.GetAudioClip();
			base.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = this.audioc;
		}
		if (this.soundloop)
		{
			base.GetComponent<AudioSource>().loop = true;
		}
		else
		{
			base.GetComponent<AudioSource>().loop = false;
		}
		base.GetComponent<AudioSource>().spatialBlend = 0f;
		base.GetComponent<AudioSource>().Play();
		yield break;
	}

	// Token: 0x0400016E RID: 366
	public string audiourl;

	// Token: 0x0400016F RID: 367
	public AudioClip audioc;

	// Token: 0x04000170 RID: 368
	public bool soundloop;
}
