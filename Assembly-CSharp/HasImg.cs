using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class HasImg : MonoBehaviour
{
	// Token: 0x06000348 RID: 840 RVA: 0x0001F530 File Offset: 0x0001D930
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) != 4 || CryptoPlayerPrefs.GetInt("Mode", 0) != 5)
		{
			if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) != "OVR")
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06000349 RID: 841 RVA: 0x0001F598 File Offset: 0x0001D998
	private void Update()
	{
		if (this.org == null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (this.isimage)
		{
			if (this.org.GetComponent<ImagePopup>().haveimage)
			{
				base.gameObject.GetComponent<GUITexture>().enabled = true;
			}
			else
			{
				base.gameObject.GetComponent<GUITexture>().enabled = false;
			}
		}
		if (this.isvideo)
		{
			base.gameObject.GetComponent<GUITexture>().enabled = this.org.GetComponent<GUITexture>().enabled;
		}
	}

	// Token: 0x040003A5 RID: 933
	public GameObject org;

	// Token: 0x040003A6 RID: 934
	public bool isimage;

	// Token: 0x040003A7 RID: 935
	public bool isvideo;
}
