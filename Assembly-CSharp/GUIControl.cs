using System;
using UnityEngine;

// Token: 0x020000FC RID: 252
public class GUIControl : MonoBehaviour
{
	// Token: 0x0600050B RID: 1291 RVA: 0x00039DB2 File Offset: 0x000381B2
	private void Awake()
	{
		this.nightVissionEffect = (UnityEngine.Object.FindObjectOfType(typeof(NightVisionEffect)) as NightVisionEffect);
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00039DCE File Offset: 0x000381CE
	private void Update()
	{
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x00039DD0 File Offset: 0x000381D0
	private void OnGUI()
	{
		if (this.nightVissionEffect == null)
		{
			return;
		}
		if (GUILayout.Button("Switch", new GUILayoutOption[]
		{
			GUILayout.Width(100f),
			GUILayout.Height(30f)
		}))
		{
			this.isEnable = !this.isEnable;
			this.nightVissionEffect.enabled = this.isEnable;
		}
		GUILayout.Label("press w,s,a,d to rotate camera", new GUILayoutOption[0]);
		if (this.isEnable)
		{
			this.nightVissionEffect.hasVignetteTexture = GUILayout.Toggle(this.nightVissionEffect.hasVignetteTexture, "Vignette", new GUILayoutOption[0]);
			this.nightVissionEffect.hasScanLineTexture = GUILayout.Toggle(this.nightVissionEffect.hasScanLineTexture, "Scan Line", new GUILayoutOption[0]);
			this.nightVissionEffect.hasNightVisionNoise = GUILayout.Toggle(this.nightVissionEffect.hasNightVisionNoise, "Screen Noise", new GUILayoutOption[0]);
			GUILayout.Label("contrast", new GUILayoutOption[0]);
			this.nightVissionEffect.contrast = GUILayout.HorizontalScrollbar(this.nightVissionEffect.contrast, this.barSize, this.nightVissionEffect.contrastRange.x, this.nightVissionEffect.contrastRange.y + this.barSize, new GUILayoutOption[]
			{
				GUILayout.Width(300f)
			});
			GUILayout.Label("brightness", new GUILayoutOption[0]);
			this.nightVissionEffect.brightness = GUILayout.HorizontalScrollbar(this.nightVissionEffect.brightness, this.barSize, this.nightVissionEffect.brightnessRange.x, this.nightVissionEffect.brightnessRange.y + this.barSize, new GUILayoutOption[]
			{
				GUILayout.Width(300f)
			});
			GUILayout.Label("distortion", new GUILayoutOption[0]);
			this.nightVissionEffect.distortion = GUILayout.HorizontalScrollbar(this.nightVissionEffect.distortion, this.barSize, this.nightVissionEffect.distortionRange.x, this.nightVissionEffect.distortionRange.y + this.barSize, new GUILayoutOption[]
			{
				GUILayout.Width(300f)
			});
			GUILayout.Label("scale", new GUILayoutOption[0]);
			this.nightVissionEffect.scale = GUILayout.HorizontalScrollbar(this.nightVissionEffect.scale, this.barSize, this.nightVissionEffect.scaleRange.x, this.nightVissionEffect.scaleRange.y + this.barSize, new GUILayoutOption[]
			{
				GUILayout.Width(300f)
			});
		}
	}

	// Token: 0x040007D6 RID: 2006
	private NightVisionEffect nightVissionEffect;

	// Token: 0x040007D7 RID: 2007
	private GUIStyle style;

	// Token: 0x040007D8 RID: 2008
	private bool isEnable = true;

	// Token: 0x040007D9 RID: 2009
	private float barSize = 1f;
}
