using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001C6 RID: 454
[ProtoContract]
public sealed class AudioHighPassFilterSerializer
{
	// Token: 0x06000ADD RID: 2781 RVA: 0x0005DB24 File Offset: 0x0005BF24
	public AudioHighPassFilterSerializer(GameObject gameObject, AudioHighPassFilterSerializer component)
	{
		AudioHighPassFilter audioHighPassFilter = gameObject.GetComponent<AudioHighPassFilter>();
		if (audioHighPassFilter == null)
		{
			audioHighPassFilter = gameObject.AddComponent<AudioHighPassFilter>();
		}
		audioHighPassFilter.cutoffFrequency = component.CutoffFrequency;
		audioHighPassFilter.highpassResonanceQ = component.HighpassResonaceQ;
		audioHighPassFilter.enabled = component.Enabled;
	}

	// Token: 0x06000ADE RID: 2782 RVA: 0x0005DB78 File Offset: 0x0005BF78
	public AudioHighPassFilterSerializer(GameObject gameObject)
	{
		AudioHighPassFilter component = gameObject.GetComponent<AudioHighPassFilter>();
		this.CutoffFrequency = component.cutoffFrequency;
		this.HighpassResonaceQ = component.highpassResonanceQ;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000ADF RID: 2783 RVA: 0x0005DBB6 File Offset: 0x0005BFB6
	private AudioHighPassFilterSerializer()
	{
	}

	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x0005DBBE File Offset: 0x0005BFBE
	// (set) Token: 0x06000AE1 RID: 2785 RVA: 0x0005DBC6 File Offset: 0x0005BFC6
	[ProtoMember(1)]
	public float CutoffFrequency { get; set; }

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x0005DBCF File Offset: 0x0005BFCF
	// (set) Token: 0x06000AE3 RID: 2787 RVA: 0x0005DBD7 File Offset: 0x0005BFD7
	[ProtoMember(2)]
	public float HighpassResonaceQ { get; set; }

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x0005DBE0 File Offset: 0x0005BFE0
	// (set) Token: 0x06000AE5 RID: 2789 RVA: 0x0005DBE8 File Offset: 0x0005BFE8
	[ProtoMember(3)]
	public bool Enabled { get; set; }
}
