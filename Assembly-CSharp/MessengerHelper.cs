using System;
using UnityEngine;

// Token: 0x02000119 RID: 281
public sealed class MessengerHelper : MonoBehaviour
{
	// Token: 0x06000633 RID: 1587 RVA: 0x0003F21F File Offset: 0x0003D61F
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x0003F22C File Offset: 0x0003D62C
	public void OnDisable()
	{
		OVRMessenger.Cleanup();
	}
}
