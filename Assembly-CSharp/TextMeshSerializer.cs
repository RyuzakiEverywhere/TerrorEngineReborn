using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F7 RID: 503
[ProtoContract]
public sealed class TextMeshSerializer
{
	// Token: 0x06000CA6 RID: 3238 RVA: 0x00062570 File Offset: 0x00060970
	public TextMeshSerializer(GameObject gameObject, TextMeshSerializer component)
	{
		TextMesh textMesh = gameObject.GetComponent<TextMesh>();
		if (textMesh == null)
		{
			textMesh = gameObject.AddComponent<TextMesh>();
		}
		textMesh.text = component.Text;
		if (!string.IsNullOrEmpty(component.FontName))
		{
			textMesh.font = (Font)UniSave.TryLoadResource(component.FontName);
		}
		textMesh.fontSize = component.FontSize;
		textMesh.fontStyle = (FontStyle)component.FontStyle;
		textMesh.offsetZ = component.OffsetZ;
		textMesh.alignment = (TextAlignment)component.Alignment;
		textMesh.anchor = (TextAnchor)component.Anchor;
		textMesh.characterSize = component.CharacterSize;
		textMesh.lineSpacing = component.LineSpacing;
		textMesh.tabSize = component.TabSize;
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x00062630 File Offset: 0x00060A30
	public TextMeshSerializer(GameObject gameObject)
	{
		TextMesh component = gameObject.GetComponent<TextMesh>();
		this.Text = component.text;
		if (component.font != null)
		{
			this.FontName = component.font.name;
		}
		this.FontSize = component.fontSize;
		this.FontStyle = (FontStyleSerializer)component.fontStyle;
		this.OffsetZ = component.offsetZ;
		this.Alignment = (TextAlignmentSerializer)component.alignment;
		this.Anchor = (TextAnchorSerializer)component.anchor;
		this.CharacterSize = component.characterSize;
		this.LineSpacing = component.lineSpacing;
		this.TabSize = component.tabSize;
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x000626D8 File Offset: 0x00060AD8
	private TextMeshSerializer()
	{
	}

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x000626E0 File Offset: 0x00060AE0
	// (set) Token: 0x06000CAA RID: 3242 RVA: 0x000626E8 File Offset: 0x00060AE8
	[ProtoMember(1)]
	public string Text { get; set; }

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x06000CAB RID: 3243 RVA: 0x000626F1 File Offset: 0x00060AF1
	// (set) Token: 0x06000CAC RID: 3244 RVA: 0x000626F9 File Offset: 0x00060AF9
	[ProtoMember(2)]
	public int FontSize { get; set; }

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x06000CAD RID: 3245 RVA: 0x00062702 File Offset: 0x00060B02
	// (set) Token: 0x06000CAE RID: 3246 RVA: 0x0006270A File Offset: 0x00060B0A
	[ProtoMember(3)]
	public FontStyleSerializer FontStyle { get; set; }

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00062713 File Offset: 0x00060B13
	// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x0006271B File Offset: 0x00060B1B
	[ProtoMember(4)]
	public float OffsetZ { get; set; }

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x00062724 File Offset: 0x00060B24
	// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x0006272C File Offset: 0x00060B2C
	[ProtoMember(5)]
	public TextAlignmentSerializer Alignment { get; set; }

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x00062735 File Offset: 0x00060B35
	// (set) Token: 0x06000CB4 RID: 3252 RVA: 0x0006273D File Offset: 0x00060B3D
	[ProtoMember(6)]
	public TextAnchorSerializer Anchor { get; set; }

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x00062746 File Offset: 0x00060B46
	// (set) Token: 0x06000CB6 RID: 3254 RVA: 0x0006274E File Offset: 0x00060B4E
	[ProtoMember(7)]
	public float CharacterSize { get; set; }

	// Token: 0x1700017E RID: 382
	// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x00062757 File Offset: 0x00060B57
	// (set) Token: 0x06000CB8 RID: 3256 RVA: 0x0006275F File Offset: 0x00060B5F
	[ProtoMember(8)]
	public float LineSpacing { get; set; }

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x00062768 File Offset: 0x00060B68
	// (set) Token: 0x06000CBA RID: 3258 RVA: 0x00062770 File Offset: 0x00060B70
	[ProtoMember(9)]
	public float TabSize { get; set; }

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x06000CBB RID: 3259 RVA: 0x00062779 File Offset: 0x00060B79
	// (set) Token: 0x06000CBC RID: 3260 RVA: 0x00062781 File Offset: 0x00060B81
	[ProtoMember(10)]
	public string FontName { get; set; }
}
