using System;
using UnityEngine;

// Token: 0x020000BF RID: 191
public class KeepCameraUp : MonoBehaviour
{
	// Token: 0x0600038E RID: 910 RVA: 0x00020C85 File Offset: 0x0001F085
	private void Start()
	{
	}

	// Token: 0x0600038F RID: 911 RVA: 0x00020C87 File Offset: 0x0001F087
	private void Update()
	{
		base.transform.localPosition = new Vector3(0f, 0.65f, 0f);
	}
}
