using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001CE RID: 462
[ProtoContract]
public sealed class AudioSerializer
{
	// Token: 0x06000B77 RID: 2935 RVA: 0x0005E9CC File Offset: 0x0005CDCC
	public AudioSerializer(GameObject gameObject)
	{
		AudioProperties component = gameObject.GetComponent<AudioProperties>();
		this.is3d = component.is3d;
		this.audioname = component.audioname;
		this.togglevisible = component.togglevisible;
		this.triggerid = component.triggerid;
		this.volume = component.volume;
		this.pitch = component.pitch;
		this.loop = component.loop;
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x0005EA3C File Offset: 0x0005CE3C
	public AudioSerializer(GameObject gameObject, AudioSerializer component)
	{
		AudioProperties audioProperties = gameObject.GetComponent<AudioProperties>();
		if (audioProperties == null)
		{
			audioProperties = gameObject.AddComponent<AudioProperties>();
		}
		audioProperties.is3d = component.is3d;
		audioProperties.audioname = component.audioname;
		audioProperties.togglevisible = component.togglevisible;
		audioProperties.triggerid = component.triggerid;
		audioProperties.volume = component.volume;
		audioProperties.pitch = component.pitch;
		audioProperties.loop = component.loop;
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x0005EABD File Offset: 0x0005CEBD
	public AudioSerializer()
	{
	}

	// Token: 0x04000CF1 RID: 3313
	[ProtoMember(1)]
	public bool is3d;

	// Token: 0x04000CF2 RID: 3314
	[ProtoMember(2)]
	public string audioname;

	// Token: 0x04000CF3 RID: 3315
	[ProtoMember(3)]
	public bool togglevisible;

	// Token: 0x04000CF4 RID: 3316
	[ProtoMember(4)]
	public string triggerid;

	// Token: 0x04000CF5 RID: 3317
	[ProtoMember(5)]
	public float volume;

	// Token: 0x04000CF6 RID: 3318
	[ProtoMember(6)]
	public float pitch;

	// Token: 0x04000CF7 RID: 3319
	[ProtoMember(7)]
	public bool loop;
}
