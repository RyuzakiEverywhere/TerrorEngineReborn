using System;
using UnityEngine;

// Token: 0x0200001F RID: 31
public class FirePos : MonoBehaviour
{
	// Token: 0x06000082 RID: 130 RVA: 0x00009786 File Offset: 0x00007B86
	private void Start()
	{
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00009788 File Offset: 0x00007B88
	private void Update()
	{
		if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "Normal" || CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "Analygraph")
		{
			base.gameObject.transform.localEulerAngles = this.NormalCam.localEulerAngles;
		}
		else
		{
			base.gameObject.transform.localEulerAngles = this.OVRCam.localEulerAngles;
		}
	}

	// Token: 0x040000BD RID: 189
	public Transform NormalCam;

	// Token: 0x040000BE RID: 190
	public Transform OVRCam;
}
