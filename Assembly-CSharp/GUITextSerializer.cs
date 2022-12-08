using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200020F RID: 527
[ProtoContract]
public sealed class GUITextSerializer
{
	// Token: 0x06000EDC RID: 3804 RVA: 0x000659C0 File Offset: 0x00063DC0
	public GUITextSerializer(GameObject gameObject, GUITextSerializer component)
	{
		GUIText guitext = gameObject.GetComponent<GUIText>();
		if (guitext == null)
		{
			guitext = gameObject.AddComponent<GUIText>();
		}
		guitext.text = component.Text;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			guitext.material = (Material)UniSave.TryLoadResource(component.MaterialName);
		}
		guitext.pixelOffset = (Vector2)component.PixelOffset;
		if (!string.IsNullOrEmpty(component.FontName))
		{
			guitext.font = (Font)UniSave.TryLoadResource(component.FontName);
		}
		guitext.alignment = (TextAlignment)component.Alignment;
		guitext.anchor = (TextAnchor)component.Anchor;
		guitext.lineSpacing = component.LineSpacing;
		guitext.tabSize = component.TabSize;
		guitext.fontSize = component.FontSize;
		guitext.fontStyle = (FontStyle)component.FontStyle;
	}

	// Token: 0x06000EDD RID: 3805 RVA: 0x00065AA0 File Offset: 0x00063EA0
	public GUITextSerializer(GameObject gameObject)
	{
		GUIText component = gameObject.GetComponent<GUIText>();
		this.Text = component.text;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		this.PixelOffset = (Vector2Serializer)component.pixelOffset;
		if (component.font != null)
		{
			this.FontName = component.font.name;
		}
		this.Alignment = (TextAlignmentSerializer)component.alignment;
		this.Anchor = (TextAnchorSerializer)component.anchor;
		this.LineSpacing = component.lineSpacing;
		this.TabSize = component.tabSize;
		this.FontSize = component.fontSize;
		this.FontStyle = (FontStyleSerializer)component.fontStyle;
	}

	// Token: 0x06000EDE RID: 3806 RVA: 0x00065B63 File Offset: 0x00063F63
	private GUITextSerializer()
	{
	}

	// Token: 0x1700026E RID: 622
	// (get) Token: 0x06000EDF RID: 3807 RVA: 0x00065B6B File Offset: 0x00063F6B
	// (set) Token: 0x06000EE0 RID: 3808 RVA: 0x00065B73 File Offset: 0x00063F73
	[ProtoMember(1)]
	public string Text { get; set; }

	// Token: 0x1700026F RID: 623
	// (get) Token: 0x06000EE1 RID: 3809 RVA: 0x00065B7C File Offset: 0x00063F7C
	// (set) Token: 0x06000EE2 RID: 3810 RVA: 0x00065B84 File Offset: 0x00063F84
	[ProtoMember(2)]
	public string MaterialName { get; set; }

	// Token: 0x17000270 RID: 624
	// (get) Token: 0x06000EE3 RID: 3811 RVA: 0x00065B8D File Offset: 0x00063F8D
	// (set) Token: 0x06000EE4 RID: 3812 RVA: 0x00065B95 File Offset: 0x00063F95
	[ProtoMember(3)]
	public Vector2Serializer PixelOffset { get; set; }

	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x00065B9E File Offset: 0x00063F9E
	// (set) Token: 0x06000EE6 RID: 3814 RVA: 0x00065BA6 File Offset: 0x00063FA6
	[ProtoMember(4)]
	public string FontName { get; set; }

	// Token: 0x17000272 RID: 626
	// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x00065BAF File Offset: 0x00063FAF
	// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x00065BB7 File Offset: 0x00063FB7
	[ProtoMember(5)]
	public TextAlignmentSerializer Alignment { get; set; }

	// Token: 0x17000273 RID: 627
	// (get) Token: 0x06000EE9 RID: 3817 RVA: 0x00065BC0 File Offset: 0x00063FC0
	// (set) Token: 0x06000EEA RID: 3818 RVA: 0x00065BC8 File Offset: 0x00063FC8
	[ProtoMember(6)]
	public TextAnchorSerializer Anchor { get; set; }

	// Token: 0x17000274 RID: 628
	// (get) Token: 0x06000EEB RID: 3819 RVA: 0x00065BD1 File Offset: 0x00063FD1
	// (set) Token: 0x06000EEC RID: 3820 RVA: 0x00065BD9 File Offset: 0x00063FD9
	[ProtoMember(7)]
	public float LineSpacing { get; set; }

	// Token: 0x17000275 RID: 629
	// (get) Token: 0x06000EED RID: 3821 RVA: 0x00065BE2 File Offset: 0x00063FE2
	// (set) Token: 0x06000EEE RID: 3822 RVA: 0x00065BEA File Offset: 0x00063FEA
	[ProtoMember(8)]
	public float TabSize { get; set; }

	// Token: 0x17000276 RID: 630
	// (get) Token: 0x06000EEF RID: 3823 RVA: 0x00065BF3 File Offset: 0x00063FF3
	// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x00065BFB File Offset: 0x00063FFB
	[ProtoMember(9)]
	public int FontSize { get; set; }

	// Token: 0x17000277 RID: 631
	// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x00065C04 File Offset: 0x00064004
	// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x00065C0C File Offset: 0x0006400C
	[ProtoMember(10)]
	public FontStyleSerializer FontStyle { get; set; }
}
