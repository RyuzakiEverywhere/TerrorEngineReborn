using System;
using UnityEngine;

// Token: 0x020001A3 RID: 419
public class SunshineSampleTurnLight : MonoBehaviour
{
	// Token: 0x060009F4 RID: 2548 RVA: 0x00059098 File Offset: 0x00057498
	private void Start()
	{
		this.baseRotation = base.transform.rotation;
	}

	// Token: 0x060009F5 RID: 2549 RVA: 0x000590AB File Offset: 0x000574AB
	private void Update()
	{
		base.transform.rotation = this.baseRotation * Quaternion.Euler(0f, Mathf.Sin(Time.timeSinceLevelLoad) * this.AngleRange, 0f);
	}

	// Token: 0x04000BC5 RID: 3013
	public float AngleRange = 45f;

	// Token: 0x04000BC6 RID: 3014
	private Quaternion baseRotation = Quaternion.identity;
}
