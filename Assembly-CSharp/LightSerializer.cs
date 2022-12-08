using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000213 RID: 531
[ProtoContract]
public sealed class LightSerializer
{
	// Token: 0x06000F0A RID: 3850 RVA: 0x00065EC0 File Offset: 0x000642C0
	public LightSerializer(GameObject gameObject, LightSerializer component)
	{
		Light light = gameObject.GetComponent<Light>();
		if (gameObject.GetComponent<Light>() == null)
		{
			light = gameObject.AddComponent<Light>();
		}
		light.enabled = component.Enabled;
		light.type = (LightType)component.Type;
		light.color = (Color)component.Color;
		light.intensity = component.Intensity;
		light.shadows = (LightShadows)component.Shadows;
		light.shadowStrength = component.ShadowStrength;
		light.shadowBias = component.ShadowBias;
		light.shadowSoftness = component.ShadowSoftness;
		light.shadowSoftnessFade = component.ShadowSoftnessFade;
		light.range = component.Range;
		light.spotAngle = component.SpotAngle;
		if (!string.IsNullOrEmpty(component.CookieName))
		{
			gameObject.GetComponent<Light>().cookie = (Texture)Resources.Load(component.CookieName);
		}
		if (!string.IsNullOrEmpty(component.FlareName))
		{
			light.flare = (Flare)UniSave.TryLoadResource(component.FlareName);
		}
		light.renderMode = (LightRenderMode)component.RenderMode;
		light.cullingMask = component.CullingMask;
	}

	// Token: 0x06000F0B RID: 3851 RVA: 0x00065FE4 File Offset: 0x000643E4
	public LightSerializer(GameObject gameObject)
	{
		this.Enabled = gameObject.GetComponent<Light>().enabled;
		this.Type = (LightTypeSerializer)gameObject.GetComponent<Light>().type;
		this.Color = (ColorSerializer)gameObject.GetComponent<Light>().color;
		this.Intensity = gameObject.GetComponent<Light>().intensity;
		this.Shadows = (LightShadowsSerializer)gameObject.GetComponent<Light>().shadows;
		this.ShadowStrength = gameObject.GetComponent<Light>().shadowStrength;
		this.ShadowBias = gameObject.GetComponent<Light>().shadowBias;
		this.ShadowSoftness = gameObject.GetComponent<Light>().shadowSoftness;
		this.ShadowSoftnessFade = gameObject.GetComponent<Light>().shadowSoftnessFade;
		this.Range = gameObject.GetComponent<Light>().range;
		this.SpotAngle = gameObject.GetComponent<Light>().spotAngle;
		if (gameObject.GetComponent<Light>().cookie != null)
		{
			this.CookieName = gameObject.GetComponent<Light>().cookie.name;
		}
		if (gameObject.GetComponent<Light>().flare != null)
		{
			this.FlareName = gameObject.GetComponent<Light>().flare.name;
		}
		this.CullingMask = gameObject.GetComponent<Light>().cullingMask;
	}

	// Token: 0x06000F0C RID: 3852 RVA: 0x00066120 File Offset: 0x00064520
	private LightSerializer()
	{
	}

	// Token: 0x1700027E RID: 638
	// (get) Token: 0x06000F0D RID: 3853 RVA: 0x00066128 File Offset: 0x00064528
	// (set) Token: 0x06000F0E RID: 3854 RVA: 0x00066130 File Offset: 0x00064530
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x1700027F RID: 639
	// (get) Token: 0x06000F0F RID: 3855 RVA: 0x00066139 File Offset: 0x00064539
	// (set) Token: 0x06000F10 RID: 3856 RVA: 0x00066141 File Offset: 0x00064541
	[ProtoMember(2)]
	public LightTypeSerializer Type { get; set; }

	// Token: 0x17000280 RID: 640
	// (get) Token: 0x06000F11 RID: 3857 RVA: 0x0006614A File Offset: 0x0006454A
	// (set) Token: 0x06000F12 RID: 3858 RVA: 0x00066152 File Offset: 0x00064552
	[ProtoMember(3)]
	public ColorSerializer Color { get; set; }

	// Token: 0x17000281 RID: 641
	// (get) Token: 0x06000F13 RID: 3859 RVA: 0x0006615B File Offset: 0x0006455B
	// (set) Token: 0x06000F14 RID: 3860 RVA: 0x00066163 File Offset: 0x00064563
	[ProtoMember(4)]
	public float Intensity { get; set; }

	// Token: 0x17000282 RID: 642
	// (get) Token: 0x06000F15 RID: 3861 RVA: 0x0006616C File Offset: 0x0006456C
	// (set) Token: 0x06000F16 RID: 3862 RVA: 0x00066174 File Offset: 0x00064574
	[ProtoMember(5)]
	public LightShadowsSerializer Shadows { get; set; }

	// Token: 0x17000283 RID: 643
	// (get) Token: 0x06000F17 RID: 3863 RVA: 0x0006617D File Offset: 0x0006457D
	// (set) Token: 0x06000F18 RID: 3864 RVA: 0x00066185 File Offset: 0x00064585
	[ProtoMember(6)]
	public float ShadowStrength { get; set; }

	// Token: 0x17000284 RID: 644
	// (get) Token: 0x06000F19 RID: 3865 RVA: 0x0006618E File Offset: 0x0006458E
	// (set) Token: 0x06000F1A RID: 3866 RVA: 0x00066196 File Offset: 0x00064596
	[ProtoMember(7)]
	public float ShadowBias { get; set; }

	// Token: 0x17000285 RID: 645
	// (get) Token: 0x06000F1B RID: 3867 RVA: 0x0006619F File Offset: 0x0006459F
	// (set) Token: 0x06000F1C RID: 3868 RVA: 0x000661A7 File Offset: 0x000645A7
	[ProtoMember(8)]
	public float ShadowSoftness { get; set; }

	// Token: 0x17000286 RID: 646
	// (get) Token: 0x06000F1D RID: 3869 RVA: 0x000661B0 File Offset: 0x000645B0
	// (set) Token: 0x06000F1E RID: 3870 RVA: 0x000661B8 File Offset: 0x000645B8
	[ProtoMember(9)]
	public float ShadowSoftnessFade { get; set; }

	// Token: 0x17000287 RID: 647
	// (get) Token: 0x06000F1F RID: 3871 RVA: 0x000661C1 File Offset: 0x000645C1
	// (set) Token: 0x06000F20 RID: 3872 RVA: 0x000661C9 File Offset: 0x000645C9
	[ProtoMember(10)]
	public float Range { get; set; }

	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06000F21 RID: 3873 RVA: 0x000661D2 File Offset: 0x000645D2
	// (set) Token: 0x06000F22 RID: 3874 RVA: 0x000661DA File Offset: 0x000645DA
	[ProtoMember(11)]
	public float SpotAngle { get; set; }

	// Token: 0x17000289 RID: 649
	// (get) Token: 0x06000F23 RID: 3875 RVA: 0x000661E3 File Offset: 0x000645E3
	// (set) Token: 0x06000F24 RID: 3876 RVA: 0x000661EB File Offset: 0x000645EB
	[ProtoMember(12)]
	public string CookieName { get; set; }

	// Token: 0x1700028A RID: 650
	// (get) Token: 0x06000F25 RID: 3877 RVA: 0x000661F4 File Offset: 0x000645F4
	// (set) Token: 0x06000F26 RID: 3878 RVA: 0x000661FC File Offset: 0x000645FC
	[ProtoMember(13)]
	public string FlareName { get; set; }

	// Token: 0x1700028B RID: 651
	// (get) Token: 0x06000F27 RID: 3879 RVA: 0x00066205 File Offset: 0x00064605
	// (set) Token: 0x06000F28 RID: 3880 RVA: 0x0006620D File Offset: 0x0006460D
	[ProtoMember(14)]
	public LightRenderModeSerializer RenderMode { get; set; }

	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06000F29 RID: 3881 RVA: 0x00066216 File Offset: 0x00064616
	// (set) Token: 0x06000F2A RID: 3882 RVA: 0x0006621E File Offset: 0x0006461E
	[ProtoMember(15)]
	public int CullingMask { get; set; }

	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06000F2B RID: 3883 RVA: 0x00066227 File Offset: 0x00064627
	// (set) Token: 0x06000F2C RID: 3884 RVA: 0x0006622F File Offset: 0x0006462F
	[ProtoMember(16)]
	public Vector2Serializer AreaSize { get; set; }
}
