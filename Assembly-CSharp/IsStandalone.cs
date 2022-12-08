using System;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class IsStandalone : MonoBehaviour
{
	// Token: 0x0600038A RID: 906 RVA: 0x00020B40 File Offset: 0x0001EF40
	private void Awake()
	{
		if (this.isStandalone)
		{
			CryptoPlayerPrefs.SetInt("Standalone", 1);
			base.gameObject.name = "3.5";
			GameObject.Find("intro").GetComponent<GUITexture>().texture = this.createdwith;
			GameObject.Find("intro").GetComponent<AudioSource>().enabled = false;
		}
		else
		{
			CryptoPlayerPrefs.SetInt("Standalone", 0);
			GameObject.Find("intro").GetComponent<AudioSource>().GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x0600038B RID: 907 RVA: 0x00020BCB File Offset: 0x0001EFCB
	private void Start()
	{
		if (this.isStandalone)
		{
			this.createdwith.Play();
		}
		else
		{
			this.teintro.Play();
		}
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00020BF4 File Offset: 0x0001EFF4
	private void OnGUI()
	{
		if (this.isStandalone)
		{
			if (this.createdwith.isPlaying)
			{
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.createdwith);
			}
		}
		else if (this.teintro.isPlaying)
		{
			GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.teintro);
		}
	}

	// Token: 0x040003E2 RID: 994
	public MovieTexture createdwith;

	// Token: 0x040003E3 RID: 995
	public MovieTexture teintro;

	// Token: 0x040003E4 RID: 996
	public bool isStandalone;
}
