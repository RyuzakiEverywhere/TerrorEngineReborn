using System;
using UnityEngine;

// Token: 0x020000C5 RID: 197
public class Arrow : MonoBehaviour
{
	// Token: 0x060003B0 RID: 944 RVA: 0x00022278 File Offset: 0x00020678
	private void Start()
	{
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x0002227C File Offset: 0x0002067C
	private void Update()
	{
		if (this.isrotate)
		{
			base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
		}
		else
		{
			base.transform.eulerAngles = new Vector3(0f, 0f, 90f);
		}
	}

	// Token: 0x04000430 RID: 1072
	public bool isrotate;
}
