using System;
using UnityEngine;

// Token: 0x020000E3 RID: 227
public class DestroyAfterPlayer : MonoBehaviour
{
	// Token: 0x06000444 RID: 1092 RVA: 0x0002F278 File Offset: 0x0002D678
	private void Update()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			UnityEngine.Object.Destroy(base.gameObject, (float)this.time);
		}
		if (GameObject.Find("Play(Clone)") != null)
		{
			UnityEngine.Object.Destroy(base.gameObject, (float)this.time);
		}
	}

	// Token: 0x0400066F RID: 1647
	public int time = 1;
}
