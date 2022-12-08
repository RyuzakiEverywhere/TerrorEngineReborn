using System;
using UnityEngine;

// Token: 0x020000E2 RID: 226
public class CameraShake : MonoBehaviour
{
	// Token: 0x06000442 RID: 1090 RVA: 0x0002F200 File Offset: 0x0002D600
	private void Update()
	{
		if (this.shake > 0f)
		{
			this.cam.transform.localPosition = UnityEngine.Random.insideUnitSphere * this.shakeAmount;
			this.shake -= Time.deltaTime * this.decreaseFactor;
		}
		else
		{
			this.shake = 0f;
		}
	}

	// Token: 0x0400066B RID: 1643
	public GameObject cam;

	// Token: 0x0400066C RID: 1644
	public float shake;

	// Token: 0x0400066D RID: 1645
	public float shakeAmount = 0.05f;

	// Token: 0x0400066E RID: 1646
	public float decreaseFactor = 1f;
}
