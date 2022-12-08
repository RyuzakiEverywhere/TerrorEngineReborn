using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001C9 RID: 457
[ProtoContract]
public sealed class AudioReverbFilterSerializer
{
	// Token: 0x06000AFA RID: 2810 RVA: 0x0005DDB4 File Offset: 0x0005C1B4
	public AudioReverbFilterSerializer(GameObject gameObject, AudioReverbFilterSerializer component)
	{
		AudioReverbFilter audioReverbFilter = gameObject.GetComponent<AudioReverbFilter>();
		if (audioReverbFilter == null)
		{
			audioReverbFilter = gameObject.AddComponent<AudioReverbFilter>();
		}
		audioReverbFilter.reverbPreset = (AudioReverbPreset)component.ReverbPreset;
		audioReverbFilter.dryLevel = component.DryLevel;
		audioReverbFilter.room = component.Room;
		audioReverbFilter.roomHF = component.RoomHF;
		audioReverbFilter.roomRolloff = component.RoomRolloff;
		audioReverbFilter.decayTime = component.DecayTime;
		audioReverbFilter.decayHFRatio = component.DecayHFRatio;
		audioReverbFilter.reflectionsLevel = component.ReflectionsLevel;
		audioReverbFilter.reflectionsDelay = component.ReflectionsDelay;
		audioReverbFilter.reverbLevel = component.ReverbLevel;
		audioReverbFilter.reverbDelay = component.ReverbDelay;
		audioReverbFilter.diffusion = component.Diffusion;
		audioReverbFilter.density = component.Density;
		audioReverbFilter.hfReference = component.HFReference;
		audioReverbFilter.roomLF = component.RoomLF;
		audioReverbFilter.lfReference = component.LFReference;
		audioReverbFilter.enabled = component.Enabled;
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x0005DEB0 File Offset: 0x0005C2B0
	public AudioReverbFilterSerializer(GameObject gameObject)
	{
		AudioReverbFilter component = gameObject.GetComponent<AudioReverbFilter>();
		this.ReverbPreset = (AudioReverbPresetSerializer)component.reverbPreset;
		this.DryLevel = component.dryLevel;
		this.Room = component.room;
		this.RoomHF = component.roomHF;
		this.RoomRolloff = component.roomRolloff;
		this.DecayTime = component.decayTime;
		this.DecayHFRatio = component.decayHFRatio;
		this.ReflectionsLevel = component.reflectionsLevel;
		this.ReflectionsDelay = component.reflectionsDelay;
		this.ReverbLevel = component.reverbLevel;
		this.ReverbDelay = component.reverbDelay;
		this.Diffusion = component.diffusion;
		this.Density = component.density;
		this.HFReference = component.hfReference;
		this.RoomLF = component.roomLF;
		this.LFReference = component.lfReference;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x0005DF96 File Offset: 0x0005C396
	private AudioReverbFilterSerializer()
	{
	}

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x06000AFD RID: 2813 RVA: 0x0005DF9E File Offset: 0x0005C39E
	// (set) Token: 0x06000AFE RID: 2814 RVA: 0x0005DFA6 File Offset: 0x0005C3A6
	[ProtoMember(1)]
	public AudioReverbPresetSerializer ReverbPreset { get; set; }

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x06000AFF RID: 2815 RVA: 0x0005DFAF File Offset: 0x0005C3AF
	// (set) Token: 0x06000B00 RID: 2816 RVA: 0x0005DFB7 File Offset: 0x0005C3B7
	[ProtoMember(2)]
	public float DryLevel { get; set; }

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x06000B01 RID: 2817 RVA: 0x0005DFC0 File Offset: 0x0005C3C0
	// (set) Token: 0x06000B02 RID: 2818 RVA: 0x0005DFC8 File Offset: 0x0005C3C8
	[ProtoMember(3)]
	public float Room { get; set; }

	// Token: 0x170000EF RID: 239
	// (get) Token: 0x06000B03 RID: 2819 RVA: 0x0005DFD1 File Offset: 0x0005C3D1
	// (set) Token: 0x06000B04 RID: 2820 RVA: 0x0005DFD9 File Offset: 0x0005C3D9
	[ProtoMember(4)]
	public float RoomHF { get; set; }

	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x06000B05 RID: 2821 RVA: 0x0005DFE2 File Offset: 0x0005C3E2
	// (set) Token: 0x06000B06 RID: 2822 RVA: 0x0005DFEA File Offset: 0x0005C3EA
	[ProtoMember(5)]
	public float RoomRolloff { get; set; }

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x06000B07 RID: 2823 RVA: 0x0005DFF3 File Offset: 0x0005C3F3
	// (set) Token: 0x06000B08 RID: 2824 RVA: 0x0005DFFB File Offset: 0x0005C3FB
	[ProtoMember(6)]
	public float DecayTime { get; set; }

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x06000B09 RID: 2825 RVA: 0x0005E004 File Offset: 0x0005C404
	// (set) Token: 0x06000B0A RID: 2826 RVA: 0x0005E00C File Offset: 0x0005C40C
	[ProtoMember(7)]
	public float DecayHFRatio { get; set; }

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x06000B0B RID: 2827 RVA: 0x0005E015 File Offset: 0x0005C415
	// (set) Token: 0x06000B0C RID: 2828 RVA: 0x0005E01D File Offset: 0x0005C41D
	[ProtoMember(8)]
	public float ReflectionsLevel { get; set; }

	// Token: 0x170000F4 RID: 244
	// (get) Token: 0x06000B0D RID: 2829 RVA: 0x0005E026 File Offset: 0x0005C426
	// (set) Token: 0x06000B0E RID: 2830 RVA: 0x0005E02E File Offset: 0x0005C42E
	[ProtoMember(9)]
	public float ReflectionsDelay { get; set; }

	// Token: 0x170000F5 RID: 245
	// (get) Token: 0x06000B0F RID: 2831 RVA: 0x0005E037 File Offset: 0x0005C437
	// (set) Token: 0x06000B10 RID: 2832 RVA: 0x0005E03F File Offset: 0x0005C43F
	[ProtoMember(10)]
	public float ReverbLevel { get; set; }

	// Token: 0x170000F6 RID: 246
	// (get) Token: 0x06000B11 RID: 2833 RVA: 0x0005E048 File Offset: 0x0005C448
	// (set) Token: 0x06000B12 RID: 2834 RVA: 0x0005E050 File Offset: 0x0005C450
	[ProtoMember(11)]
	public float ReverbDelay { get; set; }

	// Token: 0x170000F7 RID: 247
	// (get) Token: 0x06000B13 RID: 2835 RVA: 0x0005E059 File Offset: 0x0005C459
	// (set) Token: 0x06000B14 RID: 2836 RVA: 0x0005E061 File Offset: 0x0005C461
	[ProtoMember(12)]
	public float Diffusion { get; set; }

	// Token: 0x170000F8 RID: 248
	// (get) Token: 0x06000B15 RID: 2837 RVA: 0x0005E06A File Offset: 0x0005C46A
	// (set) Token: 0x06000B16 RID: 2838 RVA: 0x0005E072 File Offset: 0x0005C472
	[ProtoMember(13)]
	public float Density { get; set; }

	// Token: 0x170000F9 RID: 249
	// (get) Token: 0x06000B17 RID: 2839 RVA: 0x0005E07B File Offset: 0x0005C47B
	// (set) Token: 0x06000B18 RID: 2840 RVA: 0x0005E083 File Offset: 0x0005C483
	[ProtoMember(14)]
	public float HFReference { get; set; }

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x06000B19 RID: 2841 RVA: 0x0005E08C File Offset: 0x0005C48C
	// (set) Token: 0x06000B1A RID: 2842 RVA: 0x0005E094 File Offset: 0x0005C494
	[ProtoMember(15)]
	public float RoomLF { get; set; }

	// Token: 0x170000FB RID: 251
	// (get) Token: 0x06000B1B RID: 2843 RVA: 0x0005E09D File Offset: 0x0005C49D
	// (set) Token: 0x06000B1C RID: 2844 RVA: 0x0005E0A5 File Offset: 0x0005C4A5
	[ProtoMember(16)]
	public float LFReference { get; set; }

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x06000B1D RID: 2845 RVA: 0x0005E0AE File Offset: 0x0005C4AE
	// (set) Token: 0x06000B1E RID: 2846 RVA: 0x0005E0B6 File Offset: 0x0005C4B6
	[ProtoMember(17)]
	public bool Enabled { get; set; }
}
