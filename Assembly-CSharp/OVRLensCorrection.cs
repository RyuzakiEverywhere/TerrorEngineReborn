using System;
using UnityEngine;

// Token: 0x02000100 RID: 256
[AddComponentMenu("Image Effects/OVRLensCorrection")]
public class OVRLensCorrection : OVRImageEffectBase
{
	// Token: 0x06000519 RID: 1305 RVA: 0x0003A65C File Offset: 0x00038A5C
	public Material GetMaterial(bool portrait)
	{
		this.SetPortraitProperties(portrait, ref this.material);
		this.material.SetVector("_HmdWarpParam", this._HmdWarpParam);
		return this.material;
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x0003A688 File Offset: 0x00038A88
	public Material GetMaterial_CA(bool portrait)
	{
		this.SetPortraitProperties(portrait, ref this.material_CA);
		this.material_CA.SetVector("_HmdWarpParam", this._HmdWarpParam);
		Vector4 chromaticAberration = this._ChromaticAberration;
		float value = chromaticAberration[1] - chromaticAberration[0];
		float value2 = chromaticAberration[3] - chromaticAberration[2];
		chromaticAberration[1] = value;
		chromaticAberration[3] = value2;
		this.material_CA.SetVector("_ChromaticAberration", chromaticAberration);
		return this.material_CA;
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x0003A70C File Offset: 0x00038B0C
	private void SetPortraitProperties(bool portrait, ref Material m)
	{
		if (portrait)
		{
			Vector2 zero = Vector2.zero;
			zero.x = this._Center.y;
			zero.y = this._Center.x;
			m.SetVector("_Center", zero);
			zero.x = this._Scale.y;
			zero.y = this._Scale.x;
			m.SetVector("_Scale", zero);
			zero.x = this._ScaleIn.y;
			zero.y = this._ScaleIn.x;
			m.SetVector("_ScaleIn", zero);
		}
		else
		{
			m.SetVector("_Center", this._Center);
			m.SetVector("_Scale", this._Scale);
			m.SetVector("_ScaleIn", this._ScaleIn);
		}
	}

	// Token: 0x040007F1 RID: 2033
	[HideInInspector]
	public Vector2 _Center = new Vector2(0.5f, 0.5f);

	// Token: 0x040007F2 RID: 2034
	[HideInInspector]
	public Vector2 _ScaleIn = new Vector2(1f, 1f);

	// Token: 0x040007F3 RID: 2035
	[HideInInspector]
	public Vector2 _Scale = new Vector2(1f, 1f);

	// Token: 0x040007F4 RID: 2036
	[HideInInspector]
	public Vector4 _HmdWarpParam = new Vector4(1f, 0f, 0f, 0f);

	// Token: 0x040007F5 RID: 2037
	public Material material_CA;

	// Token: 0x040007F6 RID: 2038
	[HideInInspector]
	public Vector4 _ChromaticAberration = new Vector4(0.996f, 0.992f, 1.014f, 1.014f);
}
