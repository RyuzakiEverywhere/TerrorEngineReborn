using System;
using UnityEngine;

// Token: 0x020000C2 RID: 194
public class LoadNewLevel : MonoBehaviour
{
	// Token: 0x06000399 RID: 921 RVA: 0x00021627 File Offset: 0x0001FA27
	private void Awake()
	{
	}

	// Token: 0x0600039A RID: 922 RVA: 0x0002162C File Offset: 0x0001FA2C
	private void Start()
	{
		Application.LoadLevel("MainMenu");
		CryptoPlayerPrefs.SetString("STORYNAME", CryptoPlayerPrefs.GetString("curstory", string.Empty));
		UniSave.Load(CryptoPlayerPrefs.GetString("curstory", string.Empty));
		UnityEngine.Object.Destroy(GameObject.Find("Menu"));
	}

	// Token: 0x0600039B RID: 923 RVA: 0x0002167F File Offset: 0x0001FA7F
	private void Update()
	{
	}
}
