using System;
using Photon;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class CameraShootShake : Photon.MonoBehaviour
{
	// Token: 0x06000019 RID: 25 RVA: 0x000040D7 File Offset: 0x000024D7
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = (base.GetComponent(typeof(Transform)) as Transform);
		}
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00004105 File Offset: 0x00002505
	private void OnEnable()
	{
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00004118 File Offset: 0x00002518
	private void Update()
	{
		if (this.shakecam)
		{
			this.shake = 0.1f;
			this.shakecam = false;
		}
		if (this.shake > 0f)
		{
			this.camTransform.localPosition = this.originalPos + UnityEngine.Random.insideUnitSphere * this.shakeAmount;
			this.shake -= Time.deltaTime * this.decreaseFactor;
		}
		else
		{
			this.shake = 0f;
			this.camTransform.localPosition = this.originalPos;
		}
	}

	// Token: 0x0400001F RID: 31
	public Transform camTransform;

	// Token: 0x04000020 RID: 32
	public float shake;

	// Token: 0x04000021 RID: 33
	public float shakeAmount = 0.7f;

	// Token: 0x04000022 RID: 34
	public float decreaseFactor = 1f;

	// Token: 0x04000023 RID: 35
	private Vector3 originalPos;

	// Token: 0x04000024 RID: 36
	public bool shakecam;
}
