using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001C3 RID: 451
[ProtoContract]
public sealed class AudioChorusFilterSerializer
{
	// Token: 0x06000AB4 RID: 2740 RVA: 0x0005D79C File Offset: 0x0005BB9C
	public AudioChorusFilterSerializer(GameObject gameObject, AudioChorusFilterSerializer component)
	{
		AudioChorusFilter audioChorusFilter = gameObject.GetComponent<AudioChorusFilter>();
		if (audioChorusFilter == null)
		{
			audioChorusFilter = gameObject.AddComponent<AudioChorusFilter>();
		}
		audioChorusFilter.enabled = component.Enabled;
		audioChorusFilter.dryMix = component.DryMix;
		audioChorusFilter.wetMix1 = component.WetMix1;
		audioChorusFilter.wetMix2 = component.WetMix2;
		audioChorusFilter.wetMix3 = component.WetMix3;
		audioChorusFilter.delay = component.Delay;
		audioChorusFilter.rate = component.Rate;
		audioChorusFilter.depth = component.Depth;
		audioChorusFilter.feedback = component.Feedback;
	}

	// Token: 0x06000AB5 RID: 2741 RVA: 0x0005D838 File Offset: 0x0005BC38
	public AudioChorusFilterSerializer(GameObject gameObject)
	{
		AudioChorusFilter component = gameObject.GetComponent<AudioChorusFilter>();
		this.Enabled = component.enabled;
		this.DryMix = component.dryMix;
		this.WetMix1 = component.wetMix1;
		this.WetMix2 = component.wetMix2;
		this.WetMix3 = component.wetMix3;
		this.Delay = component.delay;
		this.Rate = component.rate;
		this.Depth = component.depth;
		this.Feedback = component.feedback;
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x0005D8BE File Offset: 0x0005BCBE
	private AudioChorusFilterSerializer()
	{
	}

	// Token: 0x170000D2 RID: 210
	// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x0005D8C6 File Offset: 0x0005BCC6
	// (set) Token: 0x06000AB8 RID: 2744 RVA: 0x0005D8CE File Offset: 0x0005BCCE
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x0005D8D7 File Offset: 0x0005BCD7
	// (set) Token: 0x06000ABA RID: 2746 RVA: 0x0005D8DF File Offset: 0x0005BCDF
	[ProtoMember(2)]
	public float DryMix { get; set; }

	// Token: 0x170000D4 RID: 212
	// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0005D8E8 File Offset: 0x0005BCE8
	// (set) Token: 0x06000ABC RID: 2748 RVA: 0x0005D8F0 File Offset: 0x0005BCF0
	[ProtoMember(3)]
	public float WetMix1 { get; set; }

	// Token: 0x170000D5 RID: 213
	// (get) Token: 0x06000ABD RID: 2749 RVA: 0x0005D8F9 File Offset: 0x0005BCF9
	// (set) Token: 0x06000ABE RID: 2750 RVA: 0x0005D901 File Offset: 0x0005BD01
	[ProtoMember(4)]
	public float WetMix2 { get; set; }

	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x06000ABF RID: 2751 RVA: 0x0005D90A File Offset: 0x0005BD0A
	// (set) Token: 0x06000AC0 RID: 2752 RVA: 0x0005D912 File Offset: 0x0005BD12
	[ProtoMember(5)]
	public float WetMix3 { get; set; }

	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x0005D91B File Offset: 0x0005BD1B
	// (set) Token: 0x06000AC2 RID: 2754 RVA: 0x0005D923 File Offset: 0x0005BD23
	[ProtoMember(6)]
	public float Delay { get; set; }

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x0005D92C File Offset: 0x0005BD2C
	// (set) Token: 0x06000AC4 RID: 2756 RVA: 0x0005D934 File Offset: 0x0005BD34
	[ProtoMember(7)]
	public float Rate { get; set; }

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x0005D93D File Offset: 0x0005BD3D
	// (set) Token: 0x06000AC6 RID: 2758 RVA: 0x0005D945 File Offset: 0x0005BD45
	[ProtoMember(8)]
	public float Depth { get; set; }

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x0005D94E File Offset: 0x0005BD4E
	// (set) Token: 0x06000AC8 RID: 2760 RVA: 0x0005D956 File Offset: 0x0005BD56
	[ProtoMember(9)]
	public float Feedback { get; set; }
}
