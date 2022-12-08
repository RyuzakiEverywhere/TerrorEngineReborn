using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001C4 RID: 452
[ProtoContract]
public sealed class AudioDistortionFilterSerializer
{
	// Token: 0x06000AC9 RID: 2761 RVA: 0x0005D960 File Offset: 0x0005BD60
	public AudioDistortionFilterSerializer(GameObject gameObject, AudioDistortionFilterSerializer component)
	{
		AudioDistortionFilter audioDistortionFilter = gameObject.GetComponent<AudioDistortionFilter>();
		if (audioDistortionFilter == null)
		{
			audioDistortionFilter = gameObject.AddComponent<AudioDistortionFilter>();
		}
		audioDistortionFilter.distortionLevel = component.DistortionLevel;
		audioDistortionFilter.enabled = component.Enabled;
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x0005D9A8 File Offset: 0x0005BDA8
	public AudioDistortionFilterSerializer(GameObject gameObject)
	{
		AudioDistortionFilter component = gameObject.GetComponent<AudioDistortionFilter>();
		this.DistortionLevel = component.distortionLevel;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x0005D9DA File Offset: 0x0005BDDA
	private AudioDistortionFilterSerializer()
	{
	}

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x06000ACC RID: 2764 RVA: 0x0005D9E2 File Offset: 0x0005BDE2
	// (set) Token: 0x06000ACD RID: 2765 RVA: 0x0005D9EA File Offset: 0x0005BDEA
	[ProtoMember(1)]
	public float DistortionLevel { get; set; }

	// Token: 0x170000DC RID: 220
	// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0005D9F3 File Offset: 0x0005BDF3
	// (set) Token: 0x06000ACF RID: 2767 RVA: 0x0005D9FB File Offset: 0x0005BDFB
	[ProtoMember(2)]
	public bool Enabled { get; set; }
}
