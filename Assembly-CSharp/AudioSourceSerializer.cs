using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001CB RID: 459
[ProtoContract]
public sealed class AudioSourceSerializer
{
	// Token: 0x06000B46 RID: 2886 RVA: 0x0005E3F4 File Offset: 0x0005C7F4
	public AudioSourceSerializer(GameObject gameObject, AudioSourceSerializer component)
	{
		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		if (audioSource == null)
		{
			audioSource = gameObject.AddComponent<AudioSource>();
		}
		audioSource.volume = component.Volume;
		audioSource.pitch = component.Pitch;
		audioSource.time = component.Time;
		audioSource.timeSamples = component.TimeSamples;
		if (!string.IsNullOrEmpty(component.ClipName))
		{
			audioSource.clip = (AudioClip)Resources.Load(component.ClipName);
			if (audioSource.clip == null)
			{
				Debug.LogWarning("Asset \"" + component.ClipName + "\" could not be found. Are you sure that the Asset has been added to the Resources folder?");
			}
		}
		audioSource.loop = component.Loop;
		audioSource.ignoreListenerVolume = component.IgnoreListenerVolume;
		audioSource.playOnAwake = component.PlayOnAwake;
		audioSource.velocityUpdateMode = (AudioVelocityUpdateMode)component.VelocityUpdateMode;
		audioSource.spatialBlend = component.PanLevel;
		audioSource.bypassEffects = component.BypassEffects;
		audioSource.dopplerLevel = component.DopplerLevel;
		audioSource.spread = component.Spread;
		audioSource.priority = component.Priority;
		audioSource.mute = component.Mute;
		audioSource.minDistance = component.MinDistance;
		audioSource.maxDistance = component.MaxDistance;
		audioSource.panStereo = component.Pan;
		audioSource.rolloffMode = (AudioRolloffMode)component.RolloffMode;
		audioSource.enabled = component.Enabled;
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x0005E558 File Offset: 0x0005C958
	public AudioSourceSerializer(GameObject gameObject)
	{
		AudioSource component = gameObject.GetComponent<AudioSource>();
		this.Volume = component.volume;
		this.Pitch = component.pitch;
		this.Time = component.time;
		this.TimeSamples = component.timeSamples;
		if (component.clip != null)
		{
			this.ClipName = component.clip.name;
		}
		this.Loop = component.loop;
		this.IgnoreListenerVolume = component.ignoreListenerVolume;
		this.PlayOnAwake = component.playOnAwake;
		this.VelocityUpdateMode = (AudioVelocityUpdateModeSerializer)component.velocityUpdateMode;
		this.PanLevel = component.spatialBlend;
		this.BypassEffects = component.bypassEffects;
		this.DopplerLevel = component.dopplerLevel;
		this.Spread = component.spread;
		this.Priority = component.priority;
		this.Mute = component.mute;
		this.MinDistance = component.minDistance;
		this.MaxDistance = component.maxDistance;
		this.Pan = component.panStereo;
		this.RolloffMode = (AudioRolloffModeSerializer)component.rolloffMode;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x0005E678 File Offset: 0x0005CA78
	private AudioSourceSerializer()
	{
	}

	// Token: 0x1700010F RID: 271
	// (get) Token: 0x06000B49 RID: 2889 RVA: 0x0005E680 File Offset: 0x0005CA80
	// (set) Token: 0x06000B4A RID: 2890 RVA: 0x0005E688 File Offset: 0x0005CA88
	[ProtoMember(1)]
	public float Volume { get; set; }

	// Token: 0x17000110 RID: 272
	// (get) Token: 0x06000B4B RID: 2891 RVA: 0x0005E691 File Offset: 0x0005CA91
	// (set) Token: 0x06000B4C RID: 2892 RVA: 0x0005E699 File Offset: 0x0005CA99
	[ProtoMember(2)]
	public float Pitch { get; set; }

	// Token: 0x17000111 RID: 273
	// (get) Token: 0x06000B4D RID: 2893 RVA: 0x0005E6A2 File Offset: 0x0005CAA2
	// (set) Token: 0x06000B4E RID: 2894 RVA: 0x0005E6AA File Offset: 0x0005CAAA
	[ProtoMember(3)]
	public float Time { get; set; }

	// Token: 0x17000112 RID: 274
	// (get) Token: 0x06000B4F RID: 2895 RVA: 0x0005E6B3 File Offset: 0x0005CAB3
	// (set) Token: 0x06000B50 RID: 2896 RVA: 0x0005E6BB File Offset: 0x0005CABB
	[ProtoMember(4)]
	public int TimeSamples { get; set; }

	// Token: 0x17000113 RID: 275
	// (get) Token: 0x06000B51 RID: 2897 RVA: 0x0005E6C4 File Offset: 0x0005CAC4
	// (set) Token: 0x06000B52 RID: 2898 RVA: 0x0005E6CC File Offset: 0x0005CACC
	[ProtoMember(5)]
	public string ClipName { get; set; }

	// Token: 0x17000114 RID: 276
	// (get) Token: 0x06000B53 RID: 2899 RVA: 0x0005E6D5 File Offset: 0x0005CAD5
	// (set) Token: 0x06000B54 RID: 2900 RVA: 0x0005E6DD File Offset: 0x0005CADD
	[ProtoMember(6)]
	public bool Loop { get; set; }

	// Token: 0x17000115 RID: 277
	// (get) Token: 0x06000B55 RID: 2901 RVA: 0x0005E6E6 File Offset: 0x0005CAE6
	// (set) Token: 0x06000B56 RID: 2902 RVA: 0x0005E6EE File Offset: 0x0005CAEE
	[ProtoMember(7)]
	public bool IgnoreListenerVolume { get; set; }

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x06000B57 RID: 2903 RVA: 0x0005E6F7 File Offset: 0x0005CAF7
	// (set) Token: 0x06000B58 RID: 2904 RVA: 0x0005E6FF File Offset: 0x0005CAFF
	[ProtoMember(8)]
	public bool PlayOnAwake { get; set; }

	// Token: 0x17000117 RID: 279
	// (get) Token: 0x06000B59 RID: 2905 RVA: 0x0005E708 File Offset: 0x0005CB08
	// (set) Token: 0x06000B5A RID: 2906 RVA: 0x0005E710 File Offset: 0x0005CB10
	[ProtoMember(9)]
	public AudioVelocityUpdateModeSerializer VelocityUpdateMode { get; set; }

	// Token: 0x17000118 RID: 280
	// (get) Token: 0x06000B5B RID: 2907 RVA: 0x0005E719 File Offset: 0x0005CB19
	// (set) Token: 0x06000B5C RID: 2908 RVA: 0x0005E721 File Offset: 0x0005CB21
	[ProtoMember(10)]
	public float PanLevel { get; set; }

	// Token: 0x17000119 RID: 281
	// (get) Token: 0x06000B5D RID: 2909 RVA: 0x0005E72A File Offset: 0x0005CB2A
	// (set) Token: 0x06000B5E RID: 2910 RVA: 0x0005E732 File Offset: 0x0005CB32
	[ProtoMember(11)]
	public bool BypassEffects { get; set; }

	// Token: 0x1700011A RID: 282
	// (get) Token: 0x06000B5F RID: 2911 RVA: 0x0005E73B File Offset: 0x0005CB3B
	// (set) Token: 0x06000B60 RID: 2912 RVA: 0x0005E743 File Offset: 0x0005CB43
	[ProtoMember(12)]
	public float DopplerLevel { get; set; }

	// Token: 0x1700011B RID: 283
	// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0005E74C File Offset: 0x0005CB4C
	// (set) Token: 0x06000B62 RID: 2914 RVA: 0x0005E754 File Offset: 0x0005CB54
	[ProtoMember(13)]
	public float Spread { get; set; }

	// Token: 0x1700011C RID: 284
	// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0005E75D File Offset: 0x0005CB5D
	// (set) Token: 0x06000B64 RID: 2916 RVA: 0x0005E765 File Offset: 0x0005CB65
	[ProtoMember(14)]
	public int Priority { get; set; }

	// Token: 0x1700011D RID: 285
	// (get) Token: 0x06000B65 RID: 2917 RVA: 0x0005E76E File Offset: 0x0005CB6E
	// (set) Token: 0x06000B66 RID: 2918 RVA: 0x0005E776 File Offset: 0x0005CB76
	[ProtoMember(15)]
	public bool Mute { get; set; }

	// Token: 0x1700011E RID: 286
	// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0005E77F File Offset: 0x0005CB7F
	// (set) Token: 0x06000B68 RID: 2920 RVA: 0x0005E787 File Offset: 0x0005CB87
	[ProtoMember(16)]
	public float MinDistance { get; set; }

	// Token: 0x1700011F RID: 287
	// (get) Token: 0x06000B69 RID: 2921 RVA: 0x0005E790 File Offset: 0x0005CB90
	// (set) Token: 0x06000B6A RID: 2922 RVA: 0x0005E798 File Offset: 0x0005CB98
	[ProtoMember(17)]
	public float MaxDistance { get; set; }

	// Token: 0x17000120 RID: 288
	// (get) Token: 0x06000B6B RID: 2923 RVA: 0x0005E7A1 File Offset: 0x0005CBA1
	// (set) Token: 0x06000B6C RID: 2924 RVA: 0x0005E7A9 File Offset: 0x0005CBA9
	[ProtoMember(18)]
	public float Pan { get; set; }

	// Token: 0x17000121 RID: 289
	// (get) Token: 0x06000B6D RID: 2925 RVA: 0x0005E7B2 File Offset: 0x0005CBB2
	// (set) Token: 0x06000B6E RID: 2926 RVA: 0x0005E7BA File Offset: 0x0005CBBA
	[ProtoMember(19)]
	public AudioRolloffModeSerializer RolloffMode { get; set; }

	// Token: 0x17000122 RID: 290
	// (get) Token: 0x06000B6F RID: 2927 RVA: 0x0005E7C3 File Offset: 0x0005CBC3
	// (set) Token: 0x06000B70 RID: 2928 RVA: 0x0005E7CB File Offset: 0x0005CBCB
	[ProtoMember(20)]
	public bool Enabled { get; set; }
}
