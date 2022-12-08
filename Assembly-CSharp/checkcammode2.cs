using System;
using UnityEngine;

// Token: 0x02000283 RID: 643
public class checkcammode2 : MonoBehaviour
{
	// Token: 0x0600127C RID: 4732 RVA: 0x00076890 File Offset: 0x00074C90
	private void Awake()
	{
		this.settingsobj = GameObject.Find("Settings").GetComponent<SettingsProperties>();
		this.PlayerCam = base.transform.Find("PlayerCamera");
		this.PlayerOVR = base.transform.Find("OVRCameraController");
		if (PlayerPrefs.GetString("CamMode") == "Normal")
		{
			this.normalcam = GameObject.Find("PlayerCamera");
			this.LeftEyeAna = GameObject.Find("leftEye");
			this.RightEyeAna = GameObject.Find("rightEye");
			this.LeftEyeAna.gameObject.active = false;
			this.RightEyeAna.gameObject.active = false;
			this.normalcam.GetComponent<Camera>().farClipPlane = this.settingsobj.fov;
			if (this.settingsobj.Crease)
			{
				this.normalcam.AddComponent<Crease>();
			}
			if (this.settingsobj.blur)
			{
				this.normalcam.AddComponent<Blur>();
			}
			if (this.settingsobj.greyscale)
			{
				this.normalcam.AddComponent<GrayscaleEffect>();
			}
			if (this.settingsobj.sepiatone)
			{
				this.normalcam.AddComponent<SepiaToneEffect>();
			}
			if (this.settingsobj.noise)
			{
				this.normalcam.AddComponent<NoiseEffect>();
			}
			if (this.settingsobj.enhancecontrast)
			{
				this.normalcam.AddComponent<ContrastEnhance>();
			}
		}
		if (PlayerPrefs.GetString("CamMode") == "Analygraph")
		{
			this.PlayerCam.gameObject.GetComponent<AnaglyphizerC>().enabled = true;
			this.LeftEyeAna = GameObject.Find("leftEye");
			this.RightEyeAna = GameObject.Find("rightEye");
			this.PlayerCam.GetComponent<Camera>().farClipPlane = this.settingsobj.fov;
			this.LeftEyeAna.GetComponent<Camera>().farClipPlane = this.settingsobj.fov;
			this.RightEyeAna.GetComponent<Camera>().farClipPlane = this.settingsobj.fov;
			if (this.settingsobj.Crease)
			{
				this.LeftEyeAna.AddComponent<Crease>();
				this.RightEyeAna.AddComponent<Crease>();
			}
			if (this.settingsobj.blur)
			{
				this.LeftEyeAna.AddComponent<Blur>();
				this.RightEyeAna.AddComponent<Blur>();
			}
			if (this.settingsobj.greyscale)
			{
				this.LeftEyeAna.AddComponent<GrayscaleEffect>();
				this.RightEyeAna.AddComponent<GrayscaleEffect>();
			}
			if (this.settingsobj.sepiatone)
			{
				this.LeftEyeAna.AddComponent<SepiaToneEffect>();
				this.RightEyeAna.AddComponent<SepiaToneEffect>();
			}
			if (this.settingsobj.noise)
			{
				this.LeftEyeAna.AddComponent<NoiseEffect>();
				this.RightEyeAna.AddComponent<NoiseEffect>();
			}
			if (this.settingsobj.enhancecontrast)
			{
				this.LeftEyeAna.AddComponent<ContrastEnhance>();
				this.RightEyeAna.AddComponent<ContrastEnhance>();
			}
		}
		if (PlayerPrefs.GetString("CamMode") == "OVR")
		{
			this.PlayerCam.gameObject.active = false;
			this.PlayerOVR.gameObject.active = true;
			this.LeftEyeOVR = GameObject.Find("CameraLeft");
			this.RightEyeOVR = GameObject.Find("CameraRight");
			this.LeftEyeOVR.GetComponent<Camera>().farClipPlane = this.settingsobj.fov;
			this.RightEyeOVR.GetComponent<Camera>().farClipPlane = this.settingsobj.fov;
			if (this.settingsobj.Crease)
			{
				this.LeftEyeOVR.AddComponent<Crease>();
				this.RightEyeOVR.AddComponent<Crease>();
			}
			if (this.settingsobj.blur)
			{
				this.LeftEyeOVR.AddComponent<Blur>();
				this.RightEyeOVR.AddComponent<Blur>();
			}
			if (this.settingsobj.greyscale)
			{
				this.LeftEyeOVR.AddComponent<GrayscaleEffect>();
				this.RightEyeOVR.AddComponent<GrayscaleEffect>();
			}
			if (this.settingsobj.sepiatone)
			{
				this.LeftEyeOVR.AddComponent<SepiaToneEffect>();
				this.RightEyeOVR.AddComponent<SepiaToneEffect>();
			}
			if (this.settingsobj.noise)
			{
				this.LeftEyeOVR.AddComponent<NoiseEffect>();
				this.RightEyeOVR.AddComponent<NoiseEffect>();
			}
			if (this.settingsobj.enhancecontrast)
			{
				this.LeftEyeOVR.AddComponent<ContrastEnhance>();
				this.RightEyeOVR.AddComponent<ContrastEnhance>();
			}
		}
	}

	// Token: 0x040012BC RID: 4796
	public Transform PlayerCam;

	// Token: 0x040012BD RID: 4797
	public Transform PlayerOVR;

	// Token: 0x040012BE RID: 4798
	public SettingsProperties settingsobj;

	// Token: 0x040012BF RID: 4799
	public GameObject LeftEyeAna;

	// Token: 0x040012C0 RID: 4800
	public GameObject RightEyeAna;

	// Token: 0x040012C1 RID: 4801
	public GameObject LeftEyeOVR;

	// Token: 0x040012C2 RID: 4802
	public GameObject RightEyeOVR;

	// Token: 0x040012C3 RID: 4803
	public GameObject normalcam;
}
