using System;
using UnityEngine;

// Token: 0x02000173 RID: 371
public class CreateNPCGrid : MonoBehaviour
{
	// Token: 0x060008C8 RID: 2248 RVA: 0x00050B5C File Offset: 0x0004EF5C
	private void Start()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			base.gameObject.AddComponent<PathGridComponent>();
		}
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x00050BA8 File Offset: 0x0004EFA8
	private void Update()
	{
	}
}
