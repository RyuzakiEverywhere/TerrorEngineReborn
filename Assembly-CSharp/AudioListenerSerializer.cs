using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001C7 RID: 455
[ProtoContract]
public sealed class AudioListenerSerializer
{
	// Token: 0x06000AE6 RID: 2790 RVA: 0x0005DBF4 File Offset: 0x0005BFF4
	public AudioListenerSerializer(GameObject gameObject, AudioListenerSerializer component)
	{
		AudioListener audioListener = gameObject.GetComponent<AudioListener>();
		if (audioListener == null)
		{
			audioListener = gameObject.AddComponent<AudioListener>();
		}
		audioListener.enabled = component.Enabled;
		AudioListener.volume = component.Volume;
		AudioListener.pause = component.Pause;
		audioListener.velocityUpdateMode = (AudioVelocityUpdateMode)component.VelocityUpdateMode;
	}

	// Token: 0x06000AE7 RID: 2791 RVA: 0x0005DC50 File Offset: 0x0005C050
	public AudioListenerSerializer(GameObject gameObject)
	{
		AudioListener component = gameObject.GetComponent<AudioListener>();
		this.Enabled = component.enabled;
		this.Volume = AudioListener.volume;
		this.Pause = AudioListener.pause;
		this.VelocityUpdateMode = (AudioVelocityUpdateModeSerializer)component.velocityUpdateMode;
	}

	// Token: 0x06000AE8 RID: 2792 RVA: 0x0005DC98 File Offset: 0x0005C098
	private AudioListenerSerializer()
	{
	}

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x0005DCA0 File Offset: 0x0005C0A0
	// (set) Token: 0x06000AEA RID: 2794 RVA: 0x0005DCA8 File Offset: 0x0005C0A8
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x06000AEB RID: 2795 RVA: 0x0005DCB1 File Offset: 0x0005C0B1
	// (set) Token: 0x06000AEC RID: 2796 RVA: 0x0005DCB9 File Offset: 0x0005C0B9
	[ProtoMember(2)]
	public float Volume { get; set; }

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x06000AED RID: 2797 RVA: 0x0005DCC2 File Offset: 0x0005C0C2
	// (set) Token: 0x06000AEE RID: 2798 RVA: 0x0005DCCA File Offset: 0x0005C0CA
	[ProtoMember(3)]
	public bool Pause { get; set; }

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x06000AEF RID: 2799 RVA: 0x0005DCD3 File Offset: 0x0005C0D3
	// (set) Token: 0x06000AF0 RID: 2800 RVA: 0x0005DCDB File Offset: 0x0005C0DB
	[ProtoMember(4)]
	public AudioVelocityUpdateModeSerializer VelocityUpdateMode { get; set; }
}
