using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
public class PlayerFootstepsSound : MonoBehaviour
{
	// Token: 0x060000FE RID: 254 RVA: 0x0000F284 File Offset: 0x0000D684
	private void Start()
	{
		if (GameObject.Find("Settings").GetComponent<SettingsProperties>().footsteps == string.Empty)
		{
			base.enabled = false;
		}
		if (base.gameObject.GetComponent<AudioSource>() == null)
		{
			base.gameObject.AddComponent<AudioSource>();
		}
		this.url = GameObject.Find("Settings").GetComponent<SettingsProperties>().footsteps;
		WWW www = new WWW("file:///" + Application.dataPath + "/Audio/" + this.url);
		base.GetComponent<AudioSource>().clip = www.GetAudioClip();
	}

	// Token: 0x060000FF RID: 255 RVA: 0x0000F328 File Offset: 0x0000D728
	private void Update()
	{
		if (!base.GetComponent<AudioSource>().isPlaying && base.GetComponent<AudioSource>().clip.isReadyToPlay)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0400018B RID: 395
	public string url;
}
