using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200015D RID: 349
public class checkcamsettings : MonoBehaviour
{
	// Token: 0x06000860 RID: 2144 RVA: 0x0004BCC4 File Offset: 0x0004A0C4
	private IEnumerator Start()
	{
		this.settingsobj = GameObject.Find("Settings").GetComponent<SettingsProperties>();
		if (this.settingsobj.camtype == 3)
		{
			PlayerPrefs.SetString("CamMode", "Normal");
		}
		RenderSettings.fog = true;
		RenderSettings.fogColor = new Color(this.settingsobj.rfog, this.settingsobj.gfog, this.settingsobj.bfog);
		RenderSettings.fogDensity = this.settingsobj.fogdens;
		if (this.settingsobj.camtype == 3)
		{
			GameObject gameObject = new GameObject("isCinematic");
		}
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
				this.normalcam.GetComponent<Crease>().enabled = true;
			}
			if (this.settingsobj.blur)
			{
				this.normalcam.GetComponent<Blur>().enabled = true;
			}
			if (this.settingsobj.greyscale)
			{
				this.normalcam.GetComponent<GrayscaleEffect>().enabled = true;
				this.test = true;
			}
			if (this.settingsobj.sepiatone)
			{
				this.normalcam.GetComponent<SepiaToneEffect>().enabled = true;
			}
			if (this.settingsobj.noise)
			{
				this.normalcam.GetComponent<NoiseEffect>().enabled = true;
			}
			if (this.settingsobj.enhancecontrast)
			{
				this.normalcam.GetComponent<ContrastEnhance>().enabled = true;
			}
			if (this.settingsobj.FakeSSAO)
			{
				this.normalcam.GetComponent<PP_FakeSSAO>().enabled = true;
			}
			if (this.settingsobj.CrossHatch)
			{
				this.normalcam.GetComponent<PP_CrossHatch>().enabled = true;
			}
			if (this.settingsobj.Charcoal)
			{
				this.normalcam.GetComponent<PP_Charcoal>().enabled = true;
			}
			if (this.settingsobj.FourBit)
			{
				this.normalcam.GetComponent<PP_4Bit>().enabled = true;
			}
			if (this.settingsobj.SobelOutlineV2)
			{
				this.normalcam.GetComponent<PP_SobelOutlineV2>().enabled = true;
			}
			if (this.settingsobj.HDR)
			{
				this.normalcam.GetComponent<PP_HDR>().enabled = true;
			}
			if (this.settingsobj.LightWave)
			{
				this.normalcam.GetComponent<PP_LightWave>().enabled = true;
			}
			if (this.settingsobj.SecurityCamera)
			{
				this.normalcam.GetComponent<PP_SecurityCamera>().enabled = true;
			}
			if (this.settingsobj.BlackAndWhite)
			{
				this.normalcam.GetComponent<PP_BlackAndWhite>().enabled = true;
			}
			if (this.settingsobj.Holywood)
			{
				this.normalcam.GetComponent<PP_Holywood>().enabled = true;
			}
			if (this.settingsobj.RadialBlur)
			{
				this.normalcam.GetComponent<PP_RadialBlur>().enabled = true;
			}
			if (this.settingsobj.Goodrays1)
			{
				this.normalcam.GetComponent<PP_Godrays1>().enabled = true;
			}
			if (this.settingsobj.Amnesia)
			{
				this.normalcam.GetComponent<PP_Amnesia>().enabled = true;
			}
			if (this.settingsobj.Noise)
			{
				this.normalcam.GetComponent<PP_Noise>().enabled = true;
			}
			if (this.settingsobj.FoggyScreen)
			{
				this.normalcam.GetComponent<PP_FoggyScreen>().enabled = true;
			}
			if (this.settingsobj.ThermalVision)
			{
				this.normalcam.GetComponent<PP_ThermalVision>().enabled = true;
			}
			if (this.settingsobj.NightVision)
			{
				this.normalcam.GetComponent<PP_NightVision>().enabled = true;
			}
			if (this.settingsobj.Bleach)
			{
				this.normalcam.GetComponent<PP_Bleach>().enabled = true;
			}
			if (this.settingsobj.Scanlines)
			{
				this.normalcam.GetComponent<PP_Scanlines>().enabled = true;
			}
			if (this.settingsobj.Vignette)
			{
				this.normalcam.GetComponent<PP_Vignette>().enabled = true;
			}
			if (this.settingsobj.Wiggle)
			{
				this.normalcam.GetComponent<PP_Wiggle>().enabled = true;
			}
			if (this.settingsobj.SobelEdge)
			{
				this.normalcam.GetComponent<PP_SobelEdge>().enabled = true;
			}
			if (this.settingsobj.SinCity)
			{
				this.normalcam.GetComponent<PP_SinCity>().enabled = true;
			}
			if (this.settingsobj.Pulse)
			{
				this.normalcam.GetComponent<PP_Pulse>().enabled = true;
			}
			if (this.settingsobj.Posterize)
			{
				this.normalcam.GetComponent<PP_Posterize>().enabled = true;
			}
			if (this.settingsobj.Pixelated)
			{
				this.normalcam.GetComponent<PP_Pixelated>().enabled = true;
			}
			if (this.settingsobj.Negative)
			{
				this.normalcam.GetComponent<PP_Negative>().enabled = true;
			}
			if (this.settingsobj.LensCircle)
			{
				this.normalcam.GetComponent<PP_LensCircle>().enabled = true;
			}
			if (this.settingsobj.Frost)
			{
				this.normalcam.GetComponent<PP_Frost>().enabled = true;
			}
			if (this.settingsobj.EdgeDetect)
			{
				this.normalcam.GetComponent<PP_EdgeDetect>().enabled = true;
			}
			if (this.settingsobj.Desaturate)
			{
				this.normalcam.GetComponent<PP_Desaturate>().enabled = true;
			}
			if (this.settingsobj.sa)
			{
				this.normalcam.GetComponent<PP_StereoAnaglyph_AmberBlue>().enabled = true;
			}
			if (PlayerPrefs.GetInt("bloom") == 1)
			{
				this.normalcam.GetComponent<FastBloom>().enabled = true;
			}
			if (PlayerPrefs.GetInt("motionblur") != 1)
			{
				this.normalcam.GetComponent<CameraMotionBlur>().enabled = false;
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
				this.LeftEyeAna.GetComponent<Crease>().enabled = true;
				this.RightEyeAna.GetComponent<Crease>().enabled = true;
			}
			if (this.settingsobj.blur)
			{
				this.LeftEyeAna.GetComponent<Blur>().enabled = true;
				this.RightEyeAna.GetComponent<Blur>().enabled = true;
			}
			if (this.settingsobj.greyscale)
			{
				this.LeftEyeAna.GetComponent<GrayscaleEffect>().enabled = true;
				this.RightEyeAna.GetComponent<GrayscaleEffect>().enabled = true;
			}
			if (this.settingsobj.sepiatone)
			{
				this.LeftEyeAna.GetComponent<SepiaToneEffect>().enabled = true;
				this.RightEyeAna.GetComponent<SepiaToneEffect>().enabled = true;
			}
			if (this.settingsobj.noise)
			{
				this.LeftEyeAna.GetComponent<NoiseEffect>().enabled = true;
				this.RightEyeAna.GetComponent<NoiseEffect>().enabled = true;
			}
			if (this.settingsobj.enhancecontrast)
			{
				this.LeftEyeAna.GetComponent<ContrastEnhance>().enabled = true;
				this.RightEyeAna.GetComponent<ContrastEnhance>().enabled = true;
			}
			if (this.settingsobj.FakeSSAO)
			{
				this.LeftEyeAna.GetComponent<PP_FakeSSAO>().enabled = true;
				this.RightEyeAna.GetComponent<PP_FakeSSAO>().enabled = true;
			}
			if (this.settingsobj.CrossHatch)
			{
				this.LeftEyeAna.GetComponent<PP_CrossHatch>().enabled = true;
				this.RightEyeAna.GetComponent<PP_CrossHatch>().enabled = true;
			}
			if (this.settingsobj.Charcoal)
			{
				this.LeftEyeAna.GetComponent<PP_Charcoal>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Charcoal>().enabled = true;
			}
			if (this.settingsobj.FourBit)
			{
				this.LeftEyeAna.GetComponent<PP_4Bit>().enabled = true;
				this.RightEyeAna.GetComponent<PP_4Bit>().enabled = true;
			}
			if (this.settingsobj.SobelOutlineV2)
			{
				this.LeftEyeAna.GetComponent<PP_SobelOutlineV2>().enabled = true;
				this.RightEyeAna.GetComponent<PP_SobelOutlineV2>().enabled = true;
			}
			if (this.settingsobj.HDR)
			{
				this.LeftEyeAna.GetComponent<PP_HDR>().enabled = true;
				this.RightEyeAna.GetComponent<PP_HDR>().enabled = true;
			}
			if (this.settingsobj.LightWave)
			{
				this.LeftEyeAna.GetComponent<PP_LightWave>().enabled = true;
				this.RightEyeAna.GetComponent<PP_LightWave>().enabled = true;
			}
			if (this.settingsobj.SecurityCamera)
			{
				this.LeftEyeAna.GetComponent<PP_SecurityCamera>().enabled = true;
				this.RightEyeAna.GetComponent<PP_SecurityCamera>().enabled = true;
			}
			if (this.settingsobj.BlackAndWhite)
			{
				this.LeftEyeAna.GetComponent<PP_BlackAndWhite>().enabled = true;
				this.RightEyeAna.GetComponent<PP_BlackAndWhite>().enabled = true;
			}
			if (this.settingsobj.Holywood)
			{
				this.LeftEyeAna.GetComponent<PP_Holywood>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Holywood>().enabled = true;
			}
			if (this.settingsobj.RadialBlur)
			{
				this.LeftEyeAna.GetComponent<PP_RadialBlur>().enabled = true;
				this.RightEyeAna.GetComponent<PP_RadialBlur>().enabled = true;
			}
			if (this.settingsobj.Goodrays1)
			{
				this.LeftEyeAna.GetComponent<PP_Godrays1>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Godrays1>().enabled = true;
			}
			if (this.settingsobj.Amnesia)
			{
				this.LeftEyeAna.GetComponent<PP_Amnesia>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Amnesia>().enabled = true;
			}
			if (this.settingsobj.Noise)
			{
				this.LeftEyeAna.GetComponent<PP_Noise>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Noise>().enabled = true;
			}
			if (this.settingsobj.FoggyScreen)
			{
				this.LeftEyeAna.GetComponent<PP_FoggyScreen>().enabled = true;
				this.RightEyeAna.GetComponent<PP_FoggyScreen>().enabled = true;
			}
			if (this.settingsobj.ThermalVision)
			{
				this.LeftEyeAna.GetComponent<PP_ThermalVision>().enabled = true;
				this.RightEyeAna.GetComponent<PP_ThermalVision>().enabled = true;
			}
			if (this.settingsobj.NightVision)
			{
				this.LeftEyeAna.GetComponent<PP_NightVision>().enabled = true;
				this.RightEyeAna.GetComponent<PP_NightVision>().enabled = true;
			}
			if (this.settingsobj.Bleach)
			{
				this.LeftEyeAna.GetComponent<PP_Bleach>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Bleach>().enabled = true;
			}
			if (this.settingsobj.Scanlines)
			{
				this.LeftEyeAna.GetComponent<PP_Scanlines>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Scanlines>().enabled = true;
			}
			if (this.settingsobj.Vignette)
			{
				this.LeftEyeAna.GetComponent<PP_Vignette>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Vignette>().enabled = true;
			}
			if (this.settingsobj.Wiggle)
			{
				this.LeftEyeAna.GetComponent<PP_Wiggle>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Wiggle>().enabled = true;
			}
			if (this.settingsobj.SobelEdge)
			{
				this.LeftEyeAna.GetComponent<PP_SobelEdge>().enabled = true;
				this.RightEyeAna.GetComponent<PP_SobelEdge>().enabled = true;
			}
			if (this.settingsobj.SinCity)
			{
				this.LeftEyeAna.GetComponent<PP_SinCity>().enabled = true;
				this.RightEyeAna.GetComponent<PP_SinCity>().enabled = true;
			}
			if (this.settingsobj.Pulse)
			{
				this.LeftEyeAna.GetComponent<PP_Pulse>().enabled = true;
				this.normalcam.GetComponent<PP_Pulse>().enabled = true;
			}
			if (this.settingsobj.Posterize)
			{
				this.LeftEyeAna.GetComponent<PP_Posterize>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Posterize>().enabled = true;
			}
			if (this.settingsobj.Pixelated)
			{
				this.LeftEyeAna.GetComponent<PP_Pixelated>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Pixelated>().enabled = true;
			}
			if (this.settingsobj.Negative)
			{
				this.LeftEyeAna.GetComponent<PP_Negative>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Negative>().enabled = true;
			}
			if (this.settingsobj.LensCircle)
			{
				this.LeftEyeAna.GetComponent<PP_LensCircle>().enabled = true;
				this.RightEyeAna.GetComponent<PP_LensCircle>().enabled = true;
			}
			if (this.settingsobj.Frost)
			{
				this.LeftEyeAna.GetComponent<PP_Frost>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Frost>().enabled = true;
			}
			if (this.settingsobj.EdgeDetect)
			{
				this.LeftEyeAna.GetComponent<PP_EdgeDetect>().enabled = true;
				this.RightEyeAna.GetComponent<PP_EdgeDetect>().enabled = true;
			}
			if (this.settingsobj.Desaturate)
			{
				this.LeftEyeAna.GetComponent<PP_Desaturate>().enabled = true;
				this.RightEyeAna.GetComponent<PP_Desaturate>().enabled = true;
			}
			if (this.settingsobj.sa)
			{
				this.LeftEyeAna.GetComponent<PP_StereoAnaglyph_AmberBlue>().enabled = true;
				this.RightEyeAna.GetComponent<PP_StereoAnaglyph_AmberBlue>().enabled = true;
			}
			if (PlayerPrefs.GetInt("bloom") == 1)
			{
				this.LeftEyeAna.GetComponent<FastBloom>().enabled = true;
				this.RightEyeAna.GetComponent<FastBloom>().enabled = true;
			}
			if (PlayerPrefs.GetInt("motionblur") != 1)
			{
				this.LeftEyeAna.GetComponent<CameraMotionBlur>().enabled = false;
				this.RightEyeAna.GetComponent<CameraMotionBlur>().enabled = false;
			}
		}
		if (PlayerPrefs.GetString("CamMode") == "OVR" && this.settingsobj.camtype < 3)
		{
			this.PlayerCam.gameObject.active = false;
			this.PlayerOVR.gameObject.active = true;
			this.LeftEyeOVR = GameObject.Find("CameraLeft");
			this.RightEyeOVR = GameObject.Find("CameraRight");
			this.LeftEyeOVR.GetComponent<Camera>().farClipPlane = this.settingsobj.fov;
			this.RightEyeOVR.GetComponent<Camera>().farClipPlane = this.settingsobj.fov;
			if (this.settingsobj.Crease)
			{
				this.LeftEyeOVR.GetComponent<Crease>().enabled = true;
				this.RightEyeOVR.GetComponent<Crease>().enabled = true;
			}
			if (this.settingsobj.blur)
			{
				this.LeftEyeOVR.GetComponent<Blur>().enabled = true;
				this.RightEyeOVR.GetComponent<Blur>().enabled = true;
			}
			if (this.settingsobj.greyscale)
			{
				this.LeftEyeOVR.GetComponent<GrayscaleEffect>().enabled = true;
				this.RightEyeOVR.GetComponent<GrayscaleEffect>().enabled = true;
			}
			if (this.settingsobj.sepiatone)
			{
				this.LeftEyeOVR.GetComponent<SepiaToneEffect>().enabled = true;
				this.RightEyeOVR.GetComponent<SepiaToneEffect>().enabled = true;
			}
			if (this.settingsobj.noise)
			{
				this.LeftEyeOVR.GetComponent<NoiseEffect>().enabled = true;
				this.RightEyeOVR.GetComponent<NoiseEffect>().enabled = true;
			}
			if (this.settingsobj.enhancecontrast)
			{
				this.LeftEyeOVR.GetComponent<ContrastEnhance>().enabled = true;
				this.RightEyeOVR.GetComponent<ContrastEnhance>().enabled = true;
			}
			if (this.settingsobj.FakeSSAO)
			{
				this.LeftEyeOVR.GetComponent<PP_FakeSSAO>().enabled = true;
				this.RightEyeAna.GetComponent<PP_FakeSSAO>().enabled = true;
			}
			if (this.settingsobj.CrossHatch)
			{
				this.LeftEyeOVR.GetComponent<PP_CrossHatch>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_CrossHatch>().enabled = true;
			}
			if (this.settingsobj.Charcoal)
			{
				this.LeftEyeOVR.GetComponent<PP_Charcoal>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Charcoal>().enabled = true;
			}
			if (this.settingsobj.FourBit)
			{
				this.LeftEyeOVR.GetComponent<PP_4Bit>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_4Bit>().enabled = true;
			}
			if (this.settingsobj.SobelOutlineV2)
			{
				this.LeftEyeOVR.GetComponent<PP_SobelOutlineV2>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_SobelOutlineV2>().enabled = true;
			}
			if (this.settingsobj.HDR)
			{
				this.LeftEyeOVR.GetComponent<PP_HDR>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_HDR>().enabled = true;
			}
			if (this.settingsobj.LightWave)
			{
				this.LeftEyeOVR.GetComponent<PP_LightWave>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_LightWave>().enabled = true;
			}
			if (this.settingsobj.SecurityCamera)
			{
				this.LeftEyeOVR.GetComponent<PP_SecurityCamera>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_SecurityCamera>().enabled = true;
			}
			if (this.settingsobj.BlackAndWhite)
			{
				this.LeftEyeOVR.GetComponent<PP_BlackAndWhite>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_BlackAndWhite>().enabled = true;
			}
			if (this.settingsobj.Holywood)
			{
				this.LeftEyeOVR.GetComponent<PP_Holywood>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Holywood>().enabled = true;
			}
			if (this.settingsobj.RadialBlur)
			{
				this.LeftEyeOVR.GetComponent<PP_RadialBlur>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_RadialBlur>().enabled = true;
			}
			if (this.settingsobj.Goodrays1)
			{
				this.LeftEyeOVR.GetComponent<PP_Godrays1>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Godrays1>().enabled = true;
			}
			if (this.settingsobj.Amnesia)
			{
				this.LeftEyeOVR.GetComponent<PP_Amnesia>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Amnesia>().enabled = true;
			}
			if (this.settingsobj.Noise)
			{
				this.LeftEyeOVR.GetComponent<PP_Noise>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Noise>().enabled = true;
			}
			if (this.settingsobj.FoggyScreen)
			{
				this.LeftEyeOVR.GetComponent<PP_FoggyScreen>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_FoggyScreen>().enabled = true;
			}
			if (this.settingsobj.ThermalVision)
			{
				this.LeftEyeOVR.GetComponent<PP_ThermalVision>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_ThermalVision>().enabled = true;
			}
			if (this.settingsobj.NightVision)
			{
				this.LeftEyeOVR.GetComponent<PP_NightVision>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_NightVision>().enabled = true;
			}
			if (this.settingsobj.Bleach)
			{
				this.LeftEyeOVR.GetComponent<PP_Bleach>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Bleach>().enabled = true;
			}
			if (this.settingsobj.Scanlines)
			{
				this.LeftEyeOVR.GetComponent<PP_Scanlines>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Scanlines>().enabled = true;
			}
			if (this.settingsobj.Vignette)
			{
				this.LeftEyeOVR.GetComponent<PP_Vignette>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Vignette>().enabled = true;
			}
			if (this.settingsobj.Wiggle)
			{
				this.LeftEyeOVR.GetComponent<PP_Wiggle>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Wiggle>().enabled = true;
			}
			if (this.settingsobj.SobelEdge)
			{
				this.LeftEyeOVR.GetComponent<PP_SobelEdge>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_SobelEdge>().enabled = true;
			}
			if (this.settingsobj.SinCity)
			{
				this.LeftEyeOVR.GetComponent<PP_SinCity>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_SinCity>().enabled = true;
			}
			if (this.settingsobj.Pulse)
			{
				this.LeftEyeOVR.GetComponent<PP_Pulse>().enabled = true;
				this.normalcam.GetComponent<PP_Pulse>().enabled = true;
			}
			if (this.settingsobj.Posterize)
			{
				this.LeftEyeOVR.GetComponent<PP_Posterize>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Posterize>().enabled = true;
			}
			if (this.settingsobj.Pixelated)
			{
				this.LeftEyeOVR.GetComponent<PP_Pixelated>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Pixelated>().enabled = true;
			}
			if (this.settingsobj.Negative)
			{
				this.LeftEyeOVR.GetComponent<PP_Negative>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Negative>().enabled = true;
			}
			if (this.settingsobj.LensCircle)
			{
				this.LeftEyeOVR.GetComponent<PP_LensCircle>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_LensCircle>().enabled = true;
			}
			if (this.settingsobj.Frost)
			{
				this.LeftEyeOVR.GetComponent<PP_Frost>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Frost>().enabled = true;
			}
			if (this.settingsobj.EdgeDetect)
			{
				this.LeftEyeOVR.GetComponent<PP_EdgeDetect>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_EdgeDetect>().enabled = true;
			}
			if (this.settingsobj.Desaturate)
			{
				this.LeftEyeOVR.GetComponent<PP_Desaturate>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_Desaturate>().enabled = true;
			}
			if (this.settingsobj.sa)
			{
				this.LeftEyeOVR.GetComponent<PP_StereoAnaglyph_AmberBlue>().enabled = true;
				this.RightEyeOVR.GetComponent<PP_StereoAnaglyph_AmberBlue>().enabled = true;
			}
			if (PlayerPrefs.GetInt("bloom") == 1)
			{
				this.LeftEyeOVR.GetComponent<FastBloom>().enabled = true;
				this.RightEyeOVR.GetComponent<FastBloom>().enabled = true;
			}
			if (PlayerPrefs.GetInt("motionblur") != 1)
			{
				this.LeftEyeOVR.GetComponent<CameraMotionBlur>().enabled = false;
				this.RightEyeOVR.GetComponent<CameraMotionBlur>().enabled = false;
			}
		}
		if (this.settingsobj.camtype == 3)
		{
			this.normalcam = GameObject.Find("PlayerCamera");
			while (base.gameObject.GetComponent<NearestCinematicCam>().target == null)
			{
				yield return new WaitForEndOfFrame();
			}
			this.normalcam.transform.parent = null;
			Transform ct = base.gameObject.GetComponent<NearestCinematicCam>().target.transform;
			this.normalcam.transform.parent = ct.GetComponent<CinematicTrigger>().thecam.transform;
			this.normalcam.transform.localPosition = new Vector3(0f, 0f, 0f);
			this.normalcam.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			ct.GetComponent<CinematicTrigger>().thecam.GetComponent<CinematicCam>().enabled = true;
		}
		Cursor.visible = false;
		Screen.lockCursor = true;
		if (this.settingsobj.usesunshine)
		{
			this.settingsobj.sunshine.gameObject.active = true;
			Light component = this.settingsobj.sunshine.Find("Sunlight").GetComponent<Light>();
			component.transform.localEulerAngles = new Vector3(float.Parse(this.settingsobj.sunrotx), float.Parse(this.settingsobj.sunroty), float.Parse(this.settingsobj.sunrotz));
			component.color = new Color(this.settingsobj.rsunlight, this.settingsobj.gsunlight, this.settingsobj.bsunlight);
			this.settingsobj.sunshine.GetComponent<Sunshine>().ScatterColor = new Color(this.settingsobj.rsun, this.settingsobj.gsun, this.settingsobj.bsun);
		}
		yield break;
	}

	// Token: 0x04000A71 RID: 2673
	public Transform PlayerCam;

	// Token: 0x04000A72 RID: 2674
	public Transform PlayerOVR;

	// Token: 0x04000A73 RID: 2675
	public SettingsProperties settingsobj;

	// Token: 0x04000A74 RID: 2676
	public GameObject LeftEyeAna;

	// Token: 0x04000A75 RID: 2677
	public GameObject RightEyeAna;

	// Token: 0x04000A76 RID: 2678
	public GameObject LeftEyeOVR;

	// Token: 0x04000A77 RID: 2679
	public GameObject RightEyeOVR;

	// Token: 0x04000A78 RID: 2680
	public GameObject normalcam;

	// Token: 0x04000A79 RID: 2681
	public bool test;
}
