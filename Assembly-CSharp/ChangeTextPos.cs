using System;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class ChangeTextPos : MonoBehaviour
{
	// Token: 0x0600001D RID: 29 RVA: 0x000041BC File Offset: 0x000025BC
	private void Start()
	{
		if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "OVR")
		{
			base.transform.position = new Vector3(this.num2, this.num, 0f);
			base.GetComponent<GUIText>().fontSize = this.textsize;
		}
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00004219 File Offset: 0x00002619
	private void Update()
	{
	}

	// Token: 0x04000025 RID: 37
	public float num;

	// Token: 0x04000026 RID: 38
	public float num2;

	// Token: 0x04000027 RID: 39
	public int textsize;
}
