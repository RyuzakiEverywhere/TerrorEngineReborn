using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001C5 RID: 453
[ProtoContract]
public sealed class AudioEchoFilterSerializer
{
	// Token: 0x06000AD0 RID: 2768 RVA: 0x0005DA04 File Offset: 0x0005BE04
	public AudioEchoFilterSerializer(GameObject gameObject, AudioEchoFilterSerializer component)
	{
		AudioEchoFilter audioEchoFilter = gameObject.GetComponent<AudioEchoFilter>();
		if (audioEchoFilter == null)
		{
			audioEchoFilter = gameObject.AddComponent<AudioEchoFilter>();
		}
		audioEchoFilter.delay = component.Delay;
		audioEchoFilter.decayRatio = component.DecayRatio;
		audioEchoFilter.dryMix = component.DryMix;
		audioEchoFilter.wetMix = component.WetMix;
		audioEchoFilter.enabled = component.Enabled;
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x0005DA70 File Offset: 0x0005BE70
	public AudioEchoFilterSerializer(GameObject gameObject)
	{
		AudioEchoFilter component = gameObject.GetComponent<AudioEchoFilter>();
		this.Delay = component.delay;
		this.DecayRatio = component.decayRatio;
		this.DryMix = component.dryMix;
		this.WetMix = component.wetMix;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000AD2 RID: 2770 RVA: 0x0005DAC6 File Offset: 0x0005BEC6
	private AudioEchoFilterSerializer()
	{
	}

	// Token: 0x170000DD RID: 221
	// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x0005DACE File Offset: 0x0005BECE
	// (set) Token: 0x06000AD4 RID: 2772 RVA: 0x0005DAD6 File Offset: 0x0005BED6
	[ProtoMember(1)]
	public float Delay { get; set; }

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x0005DADF File Offset: 0x0005BEDF
	// (set) Token: 0x06000AD6 RID: 2774 RVA: 0x0005DAE7 File Offset: 0x0005BEE7
	[ProtoMember(2)]
	public float DecayRatio { get; set; }

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x0005DAF0 File Offset: 0x0005BEF0
	// (set) Token: 0x06000AD8 RID: 2776 RVA: 0x0005DAF8 File Offset: 0x0005BEF8
	[ProtoMember(3)]
	public float DryMix { get; set; }

	// Token: 0x170000E0 RID: 224
	// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x0005DB01 File Offset: 0x0005BF01
	// (set) Token: 0x06000ADA RID: 2778 RVA: 0x0005DB09 File Offset: 0x0005BF09
	[ProtoMember(4)]
	public float WetMix { get; set; }

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x06000ADB RID: 2779 RVA: 0x0005DB12 File Offset: 0x0005BF12
	// (set) Token: 0x06000ADC RID: 2780 RVA: 0x0005DB1A File Offset: 0x0005BF1A
	[ProtoMember(5)]
	public bool Enabled { get; set; }
}
