using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001C8 RID: 456
[ProtoContract]
public sealed class AudioLowPassFilterSerializer
{
	// Token: 0x06000AF1 RID: 2801 RVA: 0x0005DCE4 File Offset: 0x0005C0E4
	public AudioLowPassFilterSerializer(GameObject gameObject, AudioLowPassFilterSerializer component)
	{
		AudioLowPassFilter audioLowPassFilter = gameObject.GetComponent<AudioLowPassFilter>();
		if (audioLowPassFilter == null)
		{
			audioLowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
		}
		audioLowPassFilter.cutoffFrequency = component.CutoffFrequency;
		audioLowPassFilter.lowpassResonanceQ = component.LowpassResonaceQ;
		audioLowPassFilter.enabled = component.Enabled;
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x0005DD38 File Offset: 0x0005C138
	public AudioLowPassFilterSerializer(GameObject gameObject)
	{
		AudioLowPassFilter component = gameObject.GetComponent<AudioLowPassFilter>();
		this.CutoffFrequency = component.cutoffFrequency;
		this.LowpassResonaceQ = component.lowpassResonanceQ;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x0005DD76 File Offset: 0x0005C176
	private AudioLowPassFilterSerializer()
	{
	}

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0005DD7E File Offset: 0x0005C17E
	// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x0005DD86 File Offset: 0x0005C186
	[ProtoMember(1)]
	public float CutoffFrequency { get; set; }

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0005DD8F File Offset: 0x0005C18F
	// (set) Token: 0x06000AF7 RID: 2807 RVA: 0x0005DD97 File Offset: 0x0005C197
	[ProtoMember(2)]
	public float LowpassResonaceQ { get; set; }

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x0005DDA0 File Offset: 0x0005C1A0
	// (set) Token: 0x06000AF9 RID: 2809 RVA: 0x0005DDA8 File Offset: 0x0005C1A8
	[ProtoMember(3)]
	public bool Enabled { get; set; }
}
