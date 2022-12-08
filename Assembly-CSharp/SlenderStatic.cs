using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200019C RID: 412
public class SlenderStatic : MonoBehaviour
{
	// Token: 0x060009CE RID: 2510 RVA: 0x00054EA4 File Offset: 0x000532A4
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 4 || CryptoPlayerPrefs.GetInt("Mode", 0) == 5)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x00054ED0 File Offset: 0x000532D0
	private void Update()
	{
		if (GameObject.Find("Play(Clone)") != null && !this.hascameras)
		{
			if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "Normal")
			{
				this.cam = GameObject.Find("PlayerCamera");
				this.cam2 = GameObject.Find("PlayerCamera");
				this.hascameras = true;
			}
			if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "Analygraph")
			{
				this.cam = GameObject.Find("leftEye");
				this.cam2 = GameObject.Find("rightEye");
				this.hascameras = true;
			}
			if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "OVR")
			{
				this.cam = GameObject.Find("CameraLeft");
				this.cam2 = GameObject.Find("CameraRight");
				this.hascameras = true;
			}
		}
		if (this.startstatic && !this.issending)
		{
			base.StartCoroutine("BeginStatic");
			this.startstatic = false;
		}
	}

	// Token: 0x060009D0 RID: 2512 RVA: 0x00054FF8 File Offset: 0x000533F8
	private IEnumerator BeginStatic()
	{
		this.issending = true;
		this.cam.GetComponent<Vignetting>().intensity = (float)UnityEngine.Random.Range(1, 7);
		this.cam.GetComponent<Vignetting>().chromaticAberration = (float)UnityEngine.Random.Range(4, 10);
		this.cam.GetComponent<Vignetting>().enabled = true;
		this.cam.GetComponent<NoiseAndGrain>().intensityMultiplier = (float)UnityEngine.Random.Range(1, 10);
		this.cam.GetComponent<NoiseAndGrain>().enabled = true;
		this.cam2.GetComponent<Vignetting>().intensity = (float)UnityEngine.Random.Range(1, 7);
		this.cam2.GetComponent<Vignetting>().chromaticAberration = (float)UnityEngine.Random.Range(4, 10);
		this.cam2.GetComponent<Vignetting>().enabled = true;
		this.cam2.GetComponent<NoiseAndGrain>().intensityMultiplier = (float)UnityEngine.Random.Range(1, 10);
		this.cam2.GetComponent<NoiseAndGrain>().enabled = true;
		yield return new WaitForSeconds(UnityEngine.Random.Range(0.05f, 3f));
		this.cam.GetComponent<Fisheye>().strengthX = UnityEngine.Random.Range(0f, 1.5f);
		this.cam.GetComponent<Fisheye>().strengthY = UnityEngine.Random.Range(0f, 1.5f);
		this.cam.GetComponent<Fisheye>().enabled = true;
		this.cam2.GetComponent<Fisheye>().strengthX = UnityEngine.Random.Range(0f, 1.5f);
		this.cam2.GetComponent<Fisheye>().strengthY = UnityEngine.Random.Range(0f, 1.5f);
		this.cam2.GetComponent<Fisheye>().enabled = true;
		yield return new WaitForSeconds(0.1f);
		this.cam.GetComponent<Fisheye>().enabled = false;
		this.cam2.GetComponent<Fisheye>().enabled = false;
		yield return new WaitForSeconds(UnityEngine.Random.Range(0.05f, 1f));
		this.cam.GetComponent<TwirlEffect>().angle = (float)UnityEngine.Random.Range(-75, 75);
		this.cam.GetComponent<TwirlEffect>().enabled = true;
		this.cam2.GetComponent<TwirlEffect>().angle = (float)UnityEngine.Random.Range(-75, 75);
		this.cam2.GetComponent<TwirlEffect>().enabled = true;
		yield return new WaitForSeconds(0.2f);
		this.cam.GetComponent<TwirlEffect>().enabled = false;
		this.cam2.GetComponent<TwirlEffect>().enabled = false;
		yield return new WaitForSeconds(0.2f);
		this.cam.GetComponent<Vignetting>().enabled = false;
		this.cam.GetComponent<NoiseAndGrain>().enabled = false;
		this.cam.GetComponent<Fisheye>().enabled = false;
		this.cam.GetComponent<TwirlEffect>().enabled = false;
		this.cam2.GetComponent<Vignetting>().enabled = false;
		this.cam2.GetComponent<NoiseAndGrain>().enabled = false;
		this.cam2.GetComponent<Fisheye>().enabled = false;
		this.cam2.GetComponent<TwirlEffect>().enabled = false;
		this.issending = false;
		yield break;
	}

	// Token: 0x04000B5E RID: 2910
	public bool startstatic;

	// Token: 0x04000B5F RID: 2911
	public GameObject cam;

	// Token: 0x04000B60 RID: 2912
	public GameObject cam2;

	// Token: 0x04000B61 RID: 2913
	public bool issending;

	// Token: 0x04000B62 RID: 2914
	public bool hascameras;
}
