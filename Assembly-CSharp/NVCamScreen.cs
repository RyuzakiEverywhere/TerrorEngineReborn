using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
public class NVCamScreen : MonoBehaviour
{
	// Token: 0x06001269 RID: 4713 RVA: 0x00076638 File Offset: 0x00074A38
	private void Start()
	{
		this.rendTex = (RenderTexture)base.GetComponent<Renderer>().material.mainTexture;
	}

	// Token: 0x0600126A RID: 4714 RVA: 0x00076655 File Offset: 0x00074A55
	private void Update()
	{
	}

	// Token: 0x040012B3 RID: 4787
	public Camera cam;

	// Token: 0x040012B4 RID: 4788
	public RenderTexture rendTex;
}
