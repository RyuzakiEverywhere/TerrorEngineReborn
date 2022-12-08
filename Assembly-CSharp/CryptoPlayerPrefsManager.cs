using System;
using UnityEngine;

// Token: 0x02000266 RID: 614
public class CryptoPlayerPrefsManager : MonoBehaviour
{
	// Token: 0x06001171 RID: 4465 RVA: 0x00071F48 File Offset: 0x00070348
	private void Awake()
	{
		CryptoPlayerPrefs.setSalt(this.salt);
		CryptoPlayerPrefs.useRijndael(this.useRijndael);
		CryptoPlayerPrefs.useXor(this.useXor);
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x04001230 RID: 4656
	public int salt = int.MaxValue;

	// Token: 0x04001231 RID: 4657
	public bool useRijndael = true;

	// Token: 0x04001232 RID: 4658
	public bool useXor = true;
}
