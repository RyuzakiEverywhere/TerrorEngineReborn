using System;
using UnityEngine;

// Token: 0x0200026A RID: 618
public class Rotator : MonoBehaviour
{
	// Token: 0x060011B8 RID: 4536 RVA: 0x00072F58 File Offset: 0x00071358
	public void Start()
	{
		this.myTransform = base.transform;
	}

	// Token: 0x060011B9 RID: 4537 RVA: 0x00072F66 File Offset: 0x00071366
	private void Update()
	{
		this.myTransform.Rotate(this.eulersPerSecond * Time.deltaTime);
	}

	// Token: 0x0400124F RID: 4687
	public Vector3 eulersPerSecond = new Vector3(0f, 0f, 1f);

	// Token: 0x04001250 RID: 4688
	private Transform myTransform;
}
