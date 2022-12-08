using System;
using UnityEngine;

// Token: 0x0200008A RID: 138
public class RotateIt : MonoBehaviour
{
	// Token: 0x0600026A RID: 618 RVA: 0x00017901 File Offset: 0x00015D01
	private void Update()
	{
		base.transform.Rotate(Vector3.forward * Time.deltaTime * 10f);
	}
}
