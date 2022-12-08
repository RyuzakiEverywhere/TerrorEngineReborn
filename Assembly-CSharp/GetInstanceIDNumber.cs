using System;
using UnityEngine;

// Token: 0x020000AF RID: 175
public class GetInstanceIDNumber : MonoBehaviour
{
	// Token: 0x0600033E RID: 830 RVA: 0x0001F408 File Offset: 0x0001D808
	private void Awake()
	{
		this.test = GameObject.FindGameObjectsWithTag("OnlineEvent");
		base.gameObject.name = "Event" + (this.test.Length - 1).ToString();
	}

	// Token: 0x0600033F RID: 831 RVA: 0x0001F452 File Offset: 0x0001D852
	private void Update()
	{
	}

	// Token: 0x040003A3 RID: 931
	private GameObject[] test;
}
