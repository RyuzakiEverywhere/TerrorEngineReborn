using System;
using UnityEngine;

// Token: 0x020000D5 RID: 213
public class ModeSelecter : MonoBehaviour
{
	// Token: 0x060003FF RID: 1023 RVA: 0x00024A8C File Offset: 0x00022E8C
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1)
		{
			this.singleplayer.gameObject.SetActive(true);
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 2)
		{
			this.multiplayerhost.gameObject.SetActive(true);
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			this.multiplayerjoin.gameObject.SetActive(true);
		}
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			this.mapmakermp.gameObject.SetActive(true);
		}
		if (CryptoPlayerPrefs.GetString("E410675", string.Empty) != "E2193590")
		{
		}
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x00024B3F File Offset: 0x00022F3F
	private void Start()
	{
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x00024B41 File Offset: 0x00022F41
	private void Update()
	{
	}

	// Token: 0x0400047F RID: 1151
	public Transform singleplayer;

	// Token: 0x04000480 RID: 1152
	public Transform multiplayerhost;

	// Token: 0x04000481 RID: 1153
	public Transform multiplayerjoin;

	// Token: 0x04000482 RID: 1154
	public Transform mapmakermp;
}
