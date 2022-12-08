using System;
using UnityEngine;

// Token: 0x020001A4 RID: 420
[ExecuteInEditMode]
public class Sunshine : MonoBehaviour
{
	// Token: 0x060009F7 RID: 2551 RVA: 0x0005927F File Offset: 0x0005767F
	public static string FormatMessage(string message)
	{
		return string.Format("Sunshine {0}: {1}", "1.7.8", message);
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x00059291 File Offset: 0x00057691
	public static void LogMessage(string message, bool showInEditor = false)
	{
		if (showInEditor || Application.isPlaying)
		{
			Debug.Log(Sunshine.FormatMessage(message));
		}
	}

	// Token: 0x170000AF RID: 175
	// (get) Token: 0x060009F9 RID: 2553 RVA: 0x000592AE File Offset: 0x000576AE
	public bool RequiresPostprocessing
	{
		get
		{
			return (this.ScatterActive || this.DebugView == SunshineDebugViews.Cascades) && this.PostProcessSupported;
		}
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x000592D0 File Offset: 0x000576D0
	public LayerMask GetCascadeOccluders(int cascade)
	{
		switch (cascade)
		{
		case 0:
			return this.Occluders;
		case 1:
			return (!this.UsePerCascadeOccluders) ? this.Occluders : this.Occluders1;
		case 2:
			return (!this.UsePerCascadeOccluders) ? this.Occluders : this.Occluders2;
		case 3:
			return (!this.UsePerCascadeOccluders) ? this.Occluders : this.Occluders3;
		default:
			return this.Occluders;
		}
	}

	// Token: 0x170000B0 RID: 176
	// (get) Token: 0x060009FB RID: 2555 RVA: 0x00059375 File Offset: 0x00057775
	public float ShadowFilterKernelRadiusDiagonal
	{
		get
		{
			return Mathf.Sqrt(this.ShadowFilterKernelRadius * 2f);
		}
	}

	// Token: 0x170000B1 RID: 177
	// (get) Token: 0x060009FC RID: 2556 RVA: 0x00059388 File Offset: 0x00057788
	public float ShadowFilterKernelRadius
	{
		get
		{
			SunshineShadowFilters shadowFilter = this.ShadowFilter;
			if (shadowFilter == SunshineShadowFilters.PCF2x2)
			{
				return 1f;
			}
			if (shadowFilter == SunshineShadowFilters.PCF3x3)
			{
				return 1.5f;
			}
			if (shadowFilter != SunshineShadowFilters.PCF4x4)
			{
				return 0.5f;
			}
			return 2f;
		}
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x000593CD File Offset: 0x000577CD
	public float LightmapTexelPhysicalSize(int cascadeID)
	{
		return this.SunLightCameras[cascadeID].orthographicSize * 2f / (float)this.CascadeMapResolution;
	}

	// Token: 0x060009FE RID: 2558 RVA: 0x000593EA File Offset: 0x000577EA
	public float ShadowBias(int cID)
	{
		return this.SunLight.shadowBias * (1f + this.LightmapTexelPhysicalSize(cID) * 2f);
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x0005940B File Offset: 0x0005780B
	public float ShadowSlopeBias(int cID)
	{
		return this.SunLight.shadowNormalBias * this.LightmapTexelPhysicalSize(cID) * 10f;
	}

	// Token: 0x170000B2 RID: 178
	// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00059426 File Offset: 0x00057826
	public bool UsingCustomBounds
	{
		get
		{
			return this.CustomLightBoundsOrigin != null;
		}
	}

	// Token: 0x170000B3 RID: 179
	// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00059434 File Offset: 0x00057834
	public SunshineMath.BoundingSphere CustomBounds
	{
		get
		{
			return new SunshineMath.BoundingSphere
			{
				origin = this.CustomLightBoundsOrigin.position,
				radius = this.CustomLightBoundsRadius
			};
		}
	}

	// Token: 0x170000B4 RID: 180
	// (get) Token: 0x06000A02 RID: 2562 RVA: 0x0005946C File Offset: 0x0005786C
	public bool IsMobile
	{
		get
		{
			SunshineShaderSets shaderSet = this.ShaderSet;
			return shaderSet != SunshineShaderSets.DesktopShaders && shaderSet == SunshineShaderSets.MobileShaders;
		}
	}

	// Token: 0x170000B5 RID: 181
	// (get) Token: 0x06000A03 RID: 2563 RVA: 0x00059498 File Offset: 0x00057898
	public int IdealLightmapResolution
	{
		get
		{
			if (this.LightmapResolution == SunshineLightResolutions.Custom)
			{
				return Mathf.Clamp(this.CustomLightmapResolution, 1, 4096);
			}
			return Mathf.Max(SunshineMath.UnityStyleLightmapResolution(this.LightmapResolution), 1);
		}
	}

	// Token: 0x170000B6 RID: 182
	// (get) Token: 0x06000A04 RID: 2564 RVA: 0x000594C9 File Offset: 0x000578C9
	public int IdealLightmapWidth
	{
		get
		{
			if (this.CascadeCount == 2)
			{
				return this.IdealLightmapResolution / 2;
			}
			return this.IdealLightmapResolution;
		}
	}

	// Token: 0x170000B7 RID: 183
	// (get) Token: 0x06000A05 RID: 2565 RVA: 0x000594E6 File Offset: 0x000578E6
	public int IdealLightmapHeight
	{
		get
		{
			return this.IdealLightmapResolution;
		}
	}

	// Token: 0x170000B8 RID: 184
	// (get) Token: 0x06000A06 RID: 2566 RVA: 0x000594EE File Offset: 0x000578EE
	public int CascadeResolutionInverseRatio
	{
		get
		{
			return (this.CascadeCount <= 1) ? 1 : 2;
		}
	}

	// Token: 0x170000B9 RID: 185
	// (get) Token: 0x06000A07 RID: 2567 RVA: 0x00059503 File Offset: 0x00057903
	public int CascadeMapResolution
	{
		get
		{
			return this.IdealLightmapResolution / this.CascadeResolutionInverseRatio;
		}
	}

	// Token: 0x170000BA RID: 186
	// (get) Token: 0x06000A08 RID: 2568 RVA: 0x00059512 File Offset: 0x00057912
	public SunshineShadowFormats ShadowFormat
	{
		get
		{
			return SunshineShadowFormats.Linear;
		}
	}

	// Token: 0x170000BB RID: 187
	// (get) Token: 0x06000A09 RID: 2569 RVA: 0x00059515 File Offset: 0x00057915
	public RenderTextureFormat LightmapFormat
	{
		get
		{
			return RenderTextureFormat.ARGB32;
		}
	}

	// Token: 0x170000BC RID: 188
	// (get) Token: 0x06000A0A RID: 2570 RVA: 0x00059518 File Offset: 0x00057918
	public FilterMode LightmapFilterMode
	{
		get
		{
			return FilterMode.Point;
		}
	}

	// Token: 0x170000BD RID: 189
	// (get) Token: 0x06000A0B RID: 2571 RVA: 0x0005951C File Offset: 0x0005791C
	public bool PostProcessSupported
	{
		get
		{
			return SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth) && SystemInfo.supportsImageEffects && this.PostScatterShader.isSupported && (this.PostScatterMaterial && this.PostScatterMaterial.passCount == 2) && this.ScatterDitherTexture != null;
		}
	}

	// Token: 0x170000BE RID: 190
	// (get) Token: 0x06000A0C RID: 2572 RVA: 0x00059581 File Offset: 0x00057981
	public bool PostBlurSupported
	{
		get
		{
			return this.PostBlurShader.isSupported && this.PostBlurMaterial.passCount == 1;
		}
	}

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x06000A0D RID: 2573 RVA: 0x000595A4 File Offset: 0x000579A4
	public bool ScatterActive
	{
		get
		{
			return this.ScatterEnabled && this.ScatterIntensity > 0f && this.PostProcessSupported;
		}
	}

	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x06000A0E RID: 2574 RVA: 0x000595CA File Offset: 0x000579CA
	public Camera SunLightCamera
	{
		get
		{
			return this.SunLightCameras[0];
		}
	}

	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x06000A0F RID: 2575 RVA: 0x000595D4 File Offset: 0x000579D4
	public int CascadeCount
	{
		get
		{
			if (this.UsingCustomBounds || this.IsMobile || !SunshineProjectPreferences.Instance.UseCustomShadows)
			{
				return 1;
			}
			if (this.IdealLightmapResolution < 32)
			{
				return 1;
			}
			return this.CustomCascadeCount;
		}
	}

	// Token: 0x170000C2 RID: 194
	// (get) Token: 0x06000A10 RID: 2576 RVA: 0x00059612 File Offset: 0x00057A12
	public float LightDistance
	{
		get
		{
			if (this.UsingCustomBounds)
			{
				return 9999f;
			}
			return this.CustomLightDistance;
		}
	}

	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x06000A11 RID: 2577 RVA: 0x0005962B File Offset: 0x00057A2B
	public Rect[] CascadeRects
	{
		get
		{
			return SunshineMath.CascadeViewportArrangements[Mathf.Clamp(this.CascadeCount - 1, 0, 3)];
		}
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x00059642 File Offset: 0x00057A42
	public Rect CascadeRect(int cID)
	{
		return this.CascadeRects[cID];
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x00059658 File Offset: 0x00057A58
	public Rect CascadePixelRect(int cID)
	{
		Rect result = this.CascadeRects[cID];
		float num = (float)((!(this.Lightmap != null)) ? 1 : this.Lightmap.width);
		float num2 = (float)((!(this.Lightmap != null)) ? 1 : this.Lightmap.height);
		result.x *= num;
		result.y *= num2;
		result.width *= num;
		result.height *= num2;
		return result;
	}

	// Token: 0x06000A14 RID: 2580 RVA: 0x000596FC File Offset: 0x00057AFC
	public float CascadeNearClip(int cID)
	{
		return this.CascadeNearClipScale(cID) * this.LightDistance;
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x0005970C File Offset: 0x00057B0C
	public float CascadeFarClip(int cID)
	{
		return this.CascadeFarClipScale(cID) * this.LightDistance;
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x0005971C File Offset: 0x00057B1C
	public float CascadeNearClipScale(int cID)
	{
		int num = cID - 1;
		return (num >= 0) ? this.CascadeFarClipScale(num) : 0f;
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x00059748 File Offset: 0x00057B48
	public float CascadeFarClipScale(int cID)
	{
		if (cID >= this.CascadeCount - 1)
		{
			return 1f;
		}
		float num = 1f;
		if (this.UseManualCascadeSplits)
		{
			num = 0f;
			for (int i = 0; i <= cID; i++)
			{
				if (i != 0)
				{
					if (i != 1)
					{
						if (i == 2)
						{
							num += (1f - num) * this.ManualCascadeSplit2;
						}
					}
					else
					{
						num += (1f - num) * this.ManualCascadeSplit1;
					}
				}
				else
				{
					num += (1f - num) * this.ManualCascadeSplit0;
				}
			}
		}
		else
		{
			for (int j = this.CascadeCount - 1; j > cID; j--)
			{
				num *= this.CascadeSpacing;
			}
		}
		return num;
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x00059818 File Offset: 0x00057C18
	public Light FindAppropriateSunLight()
	{
		Light[] lights = Light.GetLights(LightType.Directional, -1);
		if (lights.Length > 0)
		{
			return lights[0];
		}
		return null;
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x0005983C File Offset: 0x00057C3C
	public bool Setup()
	{
		this.SetupSingleton();
		if (Application.isPlaying)
		{
			this.Supported = (this.Supported && SystemInfo.supportsRenderTextures);
		}
		else
		{
			this.Supported = SystemInfo.supportsRenderTextures;
		}
		if (!this.Supported)
		{
			this.DestroyLightmap();
			this.DisableShadows();
			return false;
		}
		this.SetupLightmap();
		if (this.Ready)
		{
			return true;
		}
		if (!this.Lightmap)
		{
			this.Supported = false;
			Sunshine.LogMessage("Unable to create Lightmap", false);
		}
		if (!this.SunLight && Application.isPlaying)
		{
			this.SunLight = this.FindAppropriateSunLight();
		}
		if (!this.SunLight)
		{
			Sunshine.LogMessage("Sun Light was not configured, and couldn't find appropriate Direction Light...", false);
			if (Application.isPlaying)
			{
				base.enabled = false;
			}
			return false;
		}
		if (!this.OccluderShader)
		{
			Sunshine.LogMessage("Occluder Shader Missing...", false);
			if (Application.isPlaying)
			{
				base.enabled = false;
			}
			return false;
		}
		if (!this.OccluderShader.isSupported)
		{
			Sunshine.LogMessage("Occluder Shader Not Supported...", false);
			if (Application.isPlaying)
			{
				base.enabled = false;
			}
			return false;
		}
		if (!this.PostScatterShader)
		{
			Sunshine.LogMessage("Post Process Scatter Shader Missing...", false);
			if (Application.isPlaying)
			{
				base.enabled = false;
			}
			return false;
		}
		if (!this.PostBlurShader)
		{
			Sunshine.LogMessage("Post Process Blur Shader Missing...", false);
			if (Application.isPlaying)
			{
				base.enabled = false;
			}
			return false;
		}
		if (!this.PostDebugShader)
		{
			Sunshine.LogMessage("Post Process Debug Shader Missing...", false);
			if (Application.isPlaying)
			{
				base.enabled = false;
			}
			return false;
		}
		if (!this.BlankOvercastTexture)
		{
			Sunshine.LogMessage("Blank Overcast Texture Missing...", false);
			if (Application.isPlaying)
			{
				base.enabled = false;
			}
			return false;
		}
		this.RecreateMaterials();
		this.RecreateRenderCameras();
		this.RecreateTextures();
		this.Ready = true;
		return true;
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x00059A52 File Offset: 0x00057E52
	private void OnDrawGizmos()
	{
		if (this.UsingCustomBounds)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(this.CustomLightBoundsOrigin.position, this.CustomLightBoundsRadius);
		}
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x00059A80 File Offset: 0x00057E80
	private void RecreateMaterials()
	{
		this.DestroyMaterials();
		if (!this.PostScatterMaterial)
		{
			this.PostScatterMaterial = new Material(this.PostScatterShader);
			this.PostScatterMaterial.hideFlags = HideFlags.HideAndDontSave;
		}
		if (!this.PostBlurMaterial)
		{
			this.PostBlurMaterial = new Material(this.PostBlurShader);
			this.PostBlurMaterial.hideFlags = HideFlags.HideAndDontSave;
		}
		if (!this.PostDebugMaterial)
		{
			this.PostDebugMaterial = new Material(this.PostDebugShader);
			this.PostDebugMaterial.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x00059B20 File Offset: 0x00057F20
	private void DestroyMaterials()
	{
		if (this.PostScatterMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.PostScatterMaterial);
			this.PostScatterMaterial = null;
		}
		if (this.PostBlurMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.PostBlurMaterial);
			this.PostBlurMaterial = null;
		}
		if (this.PostDebugMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.PostDebugMaterial);
			this.PostDebugMaterial = null;
		}
	}

	// Token: 0x06000A1D RID: 2589 RVA: 0x00059B94 File Offset: 0x00057F94
	public bool IsCascadeCamera(Camera camera)
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.SunLightCameras[i] == camera)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000A1E RID: 2590 RVA: 0x00059BCC File Offset: 0x00057FCC
	private void RecreateRenderCameras()
	{
		this.DestroyRenderCameras();
		for (int i = 0; i < 4; i++)
		{
			if (!this.SunLightCameras[i])
			{
				this.SunLightCameras[i] = Sunshine.CreateRenderCamera(string.Format("Sunshine Cascade Camera {0}", i));
			}
		}
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x00059C28 File Offset: 0x00058028
	private void DestroyRenderCameras()
	{
		for (int i = 0; i < 4; i++)
		{
			if (!(this.SunLightCameras[i] == null))
			{
				UnityEngine.Object.DestroyImmediate(this.SunLightCameras[i].gameObject);
				this.SunLightCameras[i] = null;
			}
		}
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x00059C7C File Offset: 0x0005807C
	private void RecreateTextures()
	{
		this.DestroyTextures();
		int num = 16;
		this.ScatterDitherTexture = new Texture2D(4, 4, TextureFormat.ARGB32, false, false);
		this.ScatterDitherTexture.filterMode = FilterMode.Point;
		int[] array = new int[]
		{
			0,
			8,
			2,
			10,
			12,
			4,
			14,
			6,
			3,
			11,
			1,
			9,
			15,
			7,
			13,
			5
		};
		Color[] array2 = new Color[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = new Color(0f, 0f, 0f, (float)array[i] / (float)num);
		}
		this.ScatterDitherTexture.SetPixels(array2);
		this.ScatterDitherTexture.Apply();
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x00059D18 File Offset: 0x00058118
	private void DestroyTextures()
	{
		if (this.ScatterDitherTexture != null)
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(this.ScatterDitherTexture);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(this.ScatterDitherTexture);
			}
			this.ScatterDitherTexture = null;
		}
	}

	// Token: 0x06000A22 RID: 2594 RVA: 0x00059D58 File Offset: 0x00058158
	private void SetupSingleton()
	{
		if (Sunshine.Instance == null)
		{
			Sunshine.Instance = this;
		}
		else if (Sunshine.Instance != this && Application.isPlaying)
		{
			Sunshine.LogMessage("Multiple Sunshine Instances detected!", true);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06000A23 RID: 2595 RVA: 0x00059DB0 File Offset: 0x000581B0
	private void Awake()
	{
		this.SetupSingleton();
		this.Setup();
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x00059DBF File Offset: 0x000581BF
	private void OnEnable()
	{
		this.SetupSingleton();
		this.Setup();
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x00059DCE File Offset: 0x000581CE
	private void Start()
	{
		this.Setup();
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x00059DD7 File Offset: 0x000581D7
	private void OnDisable()
	{
		this.DisableShadows();
		this.DestroyResources();
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x00059DE5 File Offset: 0x000581E5
	private void OnDestroy()
	{
		this.OnDisable();
		if (Sunshine.Instance == this)
		{
			Sunshine.Instance = null;
		}
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x00059E03 File Offset: 0x00058203
	private void Update()
	{
		if (!this.Setup())
		{
			return;
		}
	}

	// Token: 0x06000A29 RID: 2601 RVA: 0x00059E11 File Offset: 0x00058211
	private void DestroyResources()
	{
		this.DestroyLightmap();
		this.DestroyRenderCameras();
		this.DestroyMaterials();
		this.DestroyTextures();
		this.Ready = false;
		this.Supported = true;
	}

	// Token: 0x06000A2A RID: 2602 RVA: 0x00059E3C File Offset: 0x0005823C
	private void RecreateLightmap()
	{
		this.DestroyLightmap();
		this.Lightmap = new RenderTexture(this.IdealLightmapWidth, this.IdealLightmapHeight, 16, this.LightmapFormat, RenderTextureReadWrite.Linear);
		if (this.Lightmap)
		{
			this.Lightmap.name = "Sunshine Lightmap";
			this.Lightmap.hideFlags = HideFlags.HideAndDontSave;
			this.Lightmap.useMipMap = false;
			this.Lightmap.filterMode = this.LightmapFilterMode;
			this.Lightmap.wrapMode = TextureWrapMode.Clamp;
			this.Lightmap.Create();
			Shader.SetGlobalTexture("sunshine_Lightmap", this.Lightmap);
		}
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x00059EE4 File Offset: 0x000582E4
	private void SetupLightmap()
	{
		if (!this.Lightmap || this.Lightmap.width != this.IdealLightmapWidth || this.Lightmap.height != this.IdealLightmapHeight || this.Lightmap.format != this.LightmapFormat)
		{
			this.RecreateLightmap();
		}
	}

	// Token: 0x06000A2C RID: 2604 RVA: 0x00059F49 File Offset: 0x00058349
	private void DestroyLightmap()
	{
		if (this.Lightmap)
		{
			UnityEngine.Object.DestroyImmediate(this.Lightmap);
			this.Lightmap = null;
		}
	}

	// Token: 0x06000A2D RID: 2605 RVA: 0x00059F6D File Offset: 0x0005836D
	public void DisableShadows()
	{
		SunshineKeywords.DisableShadows();
	}

	// Token: 0x06000A2E RID: 2606 RVA: 0x00059F74 File Offset: 0x00058374
	private static Camera CreateRenderCamera(string name)
	{
		GameObject gameObject = GameObject.Find(name);
		if (!gameObject)
		{
			gameObject = new GameObject(name);
		}
		Camera camera = gameObject.GetComponent<Camera>();
		if (!camera)
		{
			camera = gameObject.AddComponent<Camera>();
		}
		gameObject.hideFlags = HideFlags.HideAndDontSave;
		camera.enabled = false;
		camera.renderingPath = RenderingPath.Forward;
		camera.nearClipPlane = 0.1f;
		camera.farClipPlane = 100f;
		camera.depthTextureMode = DepthTextureMode.None;
		camera.clearFlags = CameraClearFlags.Color;
		camera.backgroundColor = Color.white;
		camera.orthographic = true;
		camera.hideFlags = HideFlags.HideAndDontSave;
		gameObject.SetActive(false);
		return camera;
	}

	// Token: 0x04000BC7 RID: 3015
	public const string Version = "1.7.8";

	// Token: 0x04000BC8 RID: 3016
	public const string OccluderShaderName = "Hidden/Sunshine/Occluder";

	// Token: 0x04000BC9 RID: 3017
	public const string PostScatterShaderName = "Hidden/Sunshine/PostProcess/Scatter";

	// Token: 0x04000BCA RID: 3018
	public const string PostBlurShaderName = "Hidden/Sunshine/PostProcess/Blur";

	// Token: 0x04000BCB RID: 3019
	public const string PostDebugShaderName = "Hidden/Sunshine/PostProcess/Debug";

	// Token: 0x04000BCC RID: 3020
	public const int MAX_CASCADES = 4;

	// Token: 0x04000BCD RID: 3021
	public static Sunshine Instance;

	// Token: 0x04000BCE RID: 3022
	[NonSerialized]
	public bool Ready;

	// Token: 0x04000BCF RID: 3023
	[NonSerialized]
	public bool Supported = true;

	// Token: 0x04000BD0 RID: 3024
	public Light SunLight;

	// Token: 0x04000BD1 RID: 3025
	public int Occluders = -1;

	// Token: 0x04000BD2 RID: 3026
	public bool UsePerCascadeOccluders;

	// Token: 0x04000BD3 RID: 3027
	public int Occluders1 = -1;

	// Token: 0x04000BD4 RID: 3028
	public int Occluders2 = -1;

	// Token: 0x04000BD5 RID: 3029
	public int Occluders3 = -1;

	// Token: 0x04000BD6 RID: 3030
	public SunshineShaderSets ShaderSet;

	// Token: 0x04000BD7 RID: 3031
	public SunshineUpdateInterval UpdateInterval;

	// Token: 0x04000BD8 RID: 3032
	public int UpdateIntervalFrames = 2;

	// Token: 0x04000BD9 RID: 3033
	public float UpdateIntervalPadding;

	// Token: 0x04000BDA RID: 3034
	public float UpdateIntervalMovement = 1f;

	// Token: 0x04000BDB RID: 3035
	public Transform CustomLightBoundsOrigin;

	// Token: 0x04000BDC RID: 3036
	public float CustomLightBoundsRadius = 1f;

	// Token: 0x04000BDD RID: 3037
	public SunshineLightResolutions LightmapResolution = SunshineLightResolutions.MediumResolution;

	// Token: 0x04000BDE RID: 3038
	public int CustomLightmapResolution = 512;

	// Token: 0x04000BDF RID: 3039
	public bool UseLODFix;

	// Token: 0x04000BE0 RID: 3040
	public bool UseOcclusionCulling;

	// Token: 0x04000BE1 RID: 3041
	public float LightPaddingZ = 100f;

	// Token: 0x04000BE2 RID: 3042
	public float LightFadeRatio = 0.1f;

	// Token: 0x04000BE3 RID: 3043
	public float CascadeSpacing = 0.425f;

	// Token: 0x04000BE4 RID: 3044
	public bool UseManualCascadeSplits;

	// Token: 0x04000BE5 RID: 3045
	public float ManualCascadeSplit0 = 0.425f;

	// Token: 0x04000BE6 RID: 3046
	public float ManualCascadeSplit1 = 0.425f;

	// Token: 0x04000BE7 RID: 3047
	public float ManualCascadeSplit2 = 0.425f;

	// Token: 0x04000BE8 RID: 3048
	public float CascadeFade = 0.1f;

	// Token: 0x04000BE9 RID: 3049
	public float TerrainLODTweak;

	// Token: 0x04000BEA RID: 3050
	public SunshineShadowFilters ShadowFilter = SunshineShadowFilters.PCF3x3;

	// Token: 0x04000BEB RID: 3051
	[NonSerialized]
	public RenderTexture Lightmap;

	// Token: 0x04000BEC RID: 3052
	public SunshineRelativeResolutions ScatterResolution = SunshineRelativeResolutions.Half;

	// Token: 0x04000BED RID: 3053
	public SunshineScatterSamplingQualities ScatterSamplingQuality = SunshineScatterSamplingQualities.Medium;

	// Token: 0x04000BEE RID: 3054
	[NonSerialized]
	public Texture2D ScatterDitherTexture;

	// Token: 0x04000BEF RID: 3055
	public bool ScatterBlur = true;

	// Token: 0x04000BF0 RID: 3056
	public float ScatterBlurDepthTollerance = 0.1f;

	// Token: 0x04000BF1 RID: 3057
	public bool ScatterAnimateNoise = true;

	// Token: 0x04000BF2 RID: 3058
	public float ScatterAnimateNoiseSpeed = 0.1f;

	// Token: 0x04000BF3 RID: 3059
	public Color ScatterColor = new Color(0.6f, 0.6f, 0.6f, 1f);

	// Token: 0x04000BF4 RID: 3060
	public bool ScatterEnabled = true;

	// Token: 0x04000BF5 RID: 3061
	public float ScatterIntensity = 0.5f;

	// Token: 0x04000BF6 RID: 3062
	public float ScatterExaggeration = 0.5f;

	// Token: 0x04000BF7 RID: 3063
	public float ScatterSky;

	// Token: 0x04000BF8 RID: 3064
	public Texture2D ScatterRamp;

	// Token: 0x04000BF9 RID: 3065
	public Texture2D OvercastTexture;

	// Token: 0x04000BFA RID: 3066
	public float OvercastScale = 10f;

	// Token: 0x04000BFB RID: 3067
	public Vector2 OvercastMovement = new Vector2(1f, 0.5f);

	// Token: 0x04000BFC RID: 3068
	public float OvercastPlaneHeight = 100f;

	// Token: 0x04000BFD RID: 3069
	public bool OvercastAffectsScatter;

	// Token: 0x04000BFE RID: 3070
	public bool CustomScatterOvercast;

	// Token: 0x04000BFF RID: 3071
	public Texture2D ScatterOvercastTexture;

	// Token: 0x04000C00 RID: 3072
	public float ScatterOvercastScale = 10f;

	// Token: 0x04000C01 RID: 3073
	public Vector2 ScatterOvercastMovement = new Vector2(1f, 0.5f);

	// Token: 0x04000C02 RID: 3074
	public float ScatterOvercastPlaneHeight = 100f;

	// Token: 0x04000C03 RID: 3075
	public Texture2D BlankOvercastTexture;

	// Token: 0x04000C04 RID: 3076
	public Shader OccluderShader;

	// Token: 0x04000C05 RID: 3077
	public Shader PostScatterShader;

	// Token: 0x04000C06 RID: 3078
	[NonSerialized]
	public Material PostScatterMaterial;

	// Token: 0x04000C07 RID: 3079
	public Shader PostBlurShader;

	// Token: 0x04000C08 RID: 3080
	[NonSerialized]
	public Material PostBlurMaterial;

	// Token: 0x04000C09 RID: 3081
	public Shader PostDebugShader;

	// Token: 0x04000C0A RID: 3082
	[NonSerialized]
	public Material PostDebugMaterial;

	// Token: 0x04000C0B RID: 3083
	public SunshineDebugViews DebugView;

	// Token: 0x04000C0C RID: 3084
	[NonSerialized]
	public Camera[] SunLightCameras = new Camera[4];

	// Token: 0x04000C0D RID: 3085
	public int CustomCascadeCount = 1;

	// Token: 0x04000C0E RID: 3086
	public float CustomLightDistance = 40f;
}
