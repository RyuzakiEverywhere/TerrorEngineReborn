using System;
using UnityEngine;

// Token: 0x02000020 RID: 32
[RequireComponent(typeof(Light))]
public class FlashingLight : MonoBehaviour
{
	// Token: 0x06000085 RID: 133 RVA: 0x0000981F File Offset: 0x00007C1F
	private void Start()
	{
		this.FlashLightOB = base.GetComponent<Light>();
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00009830 File Offset: 0x00007C30
	private void Update()
	{
		if (Time.timeScale != 0f)
		{
			float value = UnityEngine.Random.value;
			if (value <= this.frec)
			{
				this.FlashLightOB.enabled = true;
			}
			else
			{
				this.FlashLightOB.enabled = false;
			}
		}
	}

	// Token: 0x040000BF RID: 191
	private Light FlashLightOB;

	// Token: 0x040000C0 RID: 192
	public float frec = 0.2f;
}
