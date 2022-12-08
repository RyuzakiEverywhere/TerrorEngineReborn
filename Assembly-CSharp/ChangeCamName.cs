using System;
using UnityEngine;

// Token: 0x02000091 RID: 145
public class ChangeCamName : MonoBehaviour
{
	// Token: 0x0600028A RID: 650 RVA: 0x00018449 File Offset: 0x00016849
	private void Awake()
	{
		if (PlayerPrefs.GetString("CamMode") == "OVR")
		{
			base.transform.Find("PlayerCamera").gameObject.name = "CameraLeft";
		}
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00018483 File Offset: 0x00016883
	private void Update()
	{
	}
}
