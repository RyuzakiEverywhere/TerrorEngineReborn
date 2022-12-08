using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200002F RID: 47
[RequireComponent(typeof(AudioSource))]
public class MovieStream : MonoBehaviour
{
	// Token: 0x060000C4 RID: 196 RVA: 0x0000C67C File Offset: 0x0000AA7C
	public void Start()
	{
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x0000C680 File Offset: 0x0000AA80
	public IEnumerator GetVideo()
	{
		WWW www = new WWW("file:///" + Application.dataPath + "/Video/" + this.path);
		yield return www;
		this.movieTexture = www.GetMovieTexture();
		base.GetComponent<GUITexture>().texture = this.movieTexture;
		base.GetComponent<AudioSource>().clip = this.movieTexture.audioClip;
		this.Send();
		yield break;
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x0000C69C File Offset: 0x0000AA9C
	private void Send()
	{
		if (this.movieTexture.isReadyToPlay && !this.movieTexture.isPlaying)
		{
			this.movieTexture.Play();
			base.GetComponent<AudioSource>().Play();
			base.gameObject.GetComponent<GUITexture>().enabled = true;
		}
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x0000C6F0 File Offset: 0x0000AAF0
	private void Update()
	{
		if (base.gameObject.GetComponent<GUITexture>().enabled && !this.movieTexture.isPlaying)
		{
			base.gameObject.GetComponent<GUITexture>().enabled = false;
		}
	}

	// Token: 0x0400011C RID: 284
	public MovieTexture movieTexture;

	// Token: 0x0400011D RID: 285
	public string path;
}
