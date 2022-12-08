using System;
using UnityEngine;

// Token: 0x0200014F RID: 335
public class TestDontDestroyOnLoad : MonoBehaviour
{
	// Token: 0x0600082E RID: 2094 RVA: 0x0004B077 File Offset: 0x00049477
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}
}
