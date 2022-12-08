using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000210 RID: 528
[ProtoContract]
public sealed class GUITextureSerializer
{
	// Token: 0x06000EF3 RID: 3827 RVA: 0x00065C18 File Offset: 0x00064018
	public GUITextureSerializer(GameObject gameObject, GUITextureSerializer component)
	{
		GUITexture guitexture = gameObject.GetComponent<GUITexture>();
		if (guitexture == null)
		{
			guitexture = gameObject.AddComponent<GUITexture>();
		}
		guitexture.color = (Color)component.Color;
		if (!string.IsNullOrEmpty(component.TextureName))
		{
			guitexture.texture = (Texture)UniSave.TryLoadResource(component.TextureName);
		}
		guitexture.pixelInset = (Rect)component.PixelInset;
	}

	// Token: 0x06000EF4 RID: 3828 RVA: 0x00065C90 File Offset: 0x00064090
	public GUITextureSerializer(GameObject gameObject)
	{
		GUITexture component = gameObject.GetComponent<GUITexture>();
		this.Color = (ColorSerializer)component.color;
		if (component.texture != null)
		{
			this.TextureName = component.texture.name;
		}
		this.PixelInset = (RectSerializer)component.pixelInset;
	}

	// Token: 0x06000EF5 RID: 3829 RVA: 0x00065CEE File Offset: 0x000640EE
	private GUITextureSerializer()
	{
	}

	// Token: 0x17000278 RID: 632
	// (get) Token: 0x06000EF6 RID: 3830 RVA: 0x00065CF6 File Offset: 0x000640F6
	// (set) Token: 0x06000EF7 RID: 3831 RVA: 0x00065CFE File Offset: 0x000640FE
	[ProtoMember(1)]
	public ColorSerializer Color { get; set; }

	// Token: 0x17000279 RID: 633
	// (get) Token: 0x06000EF8 RID: 3832 RVA: 0x00065D07 File Offset: 0x00064107
	// (set) Token: 0x06000EF9 RID: 3833 RVA: 0x00065D0F File Offset: 0x0006410F
	[ProtoMember(2)]
	public string TextureName { get; set; }

	// Token: 0x1700027A RID: 634
	// (get) Token: 0x06000EFA RID: 3834 RVA: 0x00065D18 File Offset: 0x00064118
	// (set) Token: 0x06000EFB RID: 3835 RVA: 0x00065D20 File Offset: 0x00064120
	[ProtoMember(3)]
	public RectSerializer PixelInset { get; set; }
}
