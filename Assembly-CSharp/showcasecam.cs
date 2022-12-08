using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public class showcasecam : MonoBehaviour
{
	// Token: 0x06000345 RID: 837 RVA: 0x0001F4FC File Offset: 0x0001D8FC
	private void Start()
	{
	}

	// Token: 0x06000346 RID: 838 RVA: 0x0001F4FE File Offset: 0x0001D8FE
	private void Update()
	{
		base.transform.RotateAround(this.rotationPoint.position, Vector3.up, 20f * Time.deltaTime);
	}

	// Token: 0x040003A4 RID: 932
	public Transform rotationPoint;
}
