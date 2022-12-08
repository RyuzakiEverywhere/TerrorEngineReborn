using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class CheckStorySettings : MonoBehaviour
{
	// Token: 0x0600002A RID: 42 RVA: 0x00004CD4 File Offset: 0x000030D4
	private void Test()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			UnityEngine.Object.Instantiate<Transform>(this.npcgridgo);
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00004D20 File Offset: 0x00003120
	private void Update()
	{
		if (!this.disableCheck && ((CryptoPlayerPrefs.GetInt("Mode", 0) == 1 && GameObject.Find("Play(Clone)") != null) || (CryptoPlayerPrefs.GetInt("Mode", 0) == 2 && GameObject.Find("Play(Clone)") != null) || (CryptoPlayerPrefs.GetInt("Mode", 0) == 3 && GameObject.Find("Play(Clone)") != null)))
		{
			this.settings = GameObject.Find("Settings");
			this.settingsobj = this.settings.GetComponent<SettingsProperties>();
			this.dust = GameObject.Find("Dust");
			this.hail = GameObject.Find("Hail");
			this.rain = GameObject.Find("Rain");
			this.snow = GameObject.Find("Snow");
			this.flurries = GameObject.Find("Flurries");
			this.dust.SetActive(false);
			this.hail.SetActive(false);
			this.rain.SetActive(false);
			this.snow.SetActive(false);
			this.flurries.SetActive(false);
			RenderSettings.ambientLight = new Color(this.settingsobj.rlight, this.settingsobj.glight, this.settingsobj.blight);
			if (this.settingsobj.skybox1)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Sunny2 Skybox") as Material);
			}
			if (this.settingsobj.skybox2)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Sunny3 Skybox") as Material);
			}
			if (this.settingsobj.skybox3)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Overcast2 Skybox") as Material);
			}
			if (this.settingsobj.skybox4)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Eerie Skybox") as Material);
			}
			if (this.settingsobj.skybox5)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/DawnDusk Skybox") as Material);
			}
			if (this.settingsobj.skybox6)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/MoonShine Skybox") as Material);
			}
			if (this.settingsobj.skybox7)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/StarryNight Skybox") as Material);
			}
			if (this.settingsobj.skybox8)
			{
				RenderSettings.skybox = (Resources.Load("Skyboxes/Black Skybox") as Material);
			}
			if (this.settingsobj.dust)
			{
				this.dust.active = true;
			}
			if (this.settingsobj.hail)
			{
				this.hail.active = true;
			}
			if (this.settingsobj.snow)
			{
				this.snow.active = true;
			}
			if (this.settingsobj.rain)
			{
				this.rain.active = true;
			}
			if (this.settingsobj.flurries)
			{
				this.flurries.active = true;
			}
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color(this.settingsobj.rfog, this.settingsobj.gfog, this.settingsobj.bfog);
			RenderSettings.fogDensity = this.settingsobj.fogdens;
			this.escape = this.settingsobj.escape;
			this.collect = this.settingsobj.collect;
			this.escapeandcollect = this.settingsobj.collectandescape;
			this.killnpc = this.settingsobj.killnpc;
			this.disableCheck = true;
		}
		if (GameObject.Find("Dust") != null && GameObject.Find("Hail") != null && GameObject.Find("Rain") != null && GameObject.Find("Snow") != null && GameObject.Find("Flurries") != null)
		{
			this.dust = GameObject.Find("Dust");
			this.hail = GameObject.Find("Hail");
			this.rain = GameObject.Find("Rain");
			this.snow = GameObject.Find("Snow");
			this.flurries = GameObject.Find("Flurries");
			this.dust.SetActive(false);
			this.hail.SetActive(false);
			this.rain.SetActive(false);
			this.snow.SetActive(false);
			this.flurries.SetActive(false);
		}
	}

	// Token: 0x04000037 RID: 55
	public GameObject settings;

	// Token: 0x04000038 RID: 56
	public SettingsProperties settingsobj;

	// Token: 0x04000039 RID: 57
	public bool versus;

	// Token: 0x0400003A RID: 58
	public bool escape;

	// Token: 0x0400003B RID: 59
	public bool collect;

	// Token: 0x0400003C RID: 60
	public bool escapeandcollect;

	// Token: 0x0400003D RID: 61
	public bool killnpc;

	// Token: 0x0400003E RID: 62
	public GameObject dust;

	// Token: 0x0400003F RID: 63
	public GameObject rain;

	// Token: 0x04000040 RID: 64
	public GameObject hail;

	// Token: 0x04000041 RID: 65
	public GameObject snow;

	// Token: 0x04000042 RID: 66
	public GameObject flurries;

	// Token: 0x04000043 RID: 67
	public Transform npcgridgo;

	// Token: 0x04000044 RID: 68
	public bool disableCheck;
}
