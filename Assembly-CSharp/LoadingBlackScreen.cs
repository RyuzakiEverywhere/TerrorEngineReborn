using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200002D RID: 45
public class LoadingBlackScreen : MonoBehaviour
{
	// Token: 0x060000BA RID: 186 RVA: 0x0000C229 File Offset: 0x0000A629
	private void Start()
	{
	}

	// Token: 0x060000BB RID: 187 RVA: 0x0000C22B File Offset: 0x0000A62B
	private void Update()
	{
		if (GameObject.Find("Play(Clone)") && !this.hasstarted)
		{
			base.StartCoroutine(this.ShowBlack(2f));
			this.hasstarted = true;
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x0000C268 File Offset: 0x0000A668
	private IEnumerator ShowBlack(float waitTime)
	{
		this.hasstarted = true;
		this.isloading = true;
		yield return new WaitForSeconds(waitTime);
		this.isloading = false;
		ErrorLog el = GameObject.Find("Log").GetComponent<ErrorLog>();
		el.CheckNow();
		UnityEngine.Object.Destroy(this);
		yield break;
	}

	// Token: 0x060000BD RID: 189 RVA: 0x0000C28A File Offset: 0x0000A68A
	private void OnGUI()
	{
		if (this.isloading)
		{
		}
	}

	// Token: 0x04000111 RID: 273
	public Texture2D black;

	// Token: 0x04000112 RID: 274
	public bool isloading;

	// Token: 0x04000113 RID: 275
	public bool hasstarted;
}
