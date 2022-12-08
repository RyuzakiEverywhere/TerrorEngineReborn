using System;
using UnityEngine;

// Token: 0x02000092 RID: 146
public class CheckType : MonoBehaviour
{
	// Token: 0x0600028D RID: 653 RVA: 0x00018490 File Offset: 0x00016890
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Standalone", 0) == 1)
		{
			this.sa.active = true;
			UnityEngine.Object.Destroy(this.te);
			UnityEngine.Object.Destroy(this.menu);
		}
		else
		{
			this.te.active = true;
			this.menu.active = true;
			UnityEngine.Object.Destroy(this.sa);
		}
	}

	// Token: 0x04000312 RID: 786
	public GameObject te;

	// Token: 0x04000313 RID: 787
	public GameObject sa;

	// Token: 0x04000314 RID: 788
	public GameObject menu;
}
