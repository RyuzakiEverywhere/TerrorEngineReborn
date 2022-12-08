using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001CA RID: 458
[ProtoContract]
public sealed class AudioReverbZoneSerializer
{
	// Token: 0x06000B1F RID: 2847 RVA: 0x0005E0C0 File Offset: 0x0005C4C0
	public AudioReverbZoneSerializer(GameObject gameObject, AudioReverbZoneSerializer component)
	{
		AudioReverbZone audioReverbZone = gameObject.GetComponent<AudioReverbZone>();
		if (audioReverbZone == null)
		{
			audioReverbZone = gameObject.AddComponent<AudioReverbZone>();
		}
		audioReverbZone.minDistance = component.MinDistance;
		audioReverbZone.maxDistance = component.MaxDistance;
		audioReverbZone.reverbPreset = (AudioReverbPreset)component.ReverbPreset;
		audioReverbZone.room = component.Room;
		audioReverbZone.roomHF = component.RoomHF;
		audioReverbZone.roomLF = component.RoomLF;
		audioReverbZone.decayTime = component.DecayTime;
		audioReverbZone.decayHFRatio = component.DecayHFRatio;
		audioReverbZone.reflections = component.Reflections;
		audioReverbZone.reflectionsDelay = component.ReflectionsDelay;
		audioReverbZone.reverb = component.Reverb;
		audioReverbZone.reverbDelay = component.ReverbDelay;
		audioReverbZone.HFReference = component.HFReference;
		audioReverbZone.LFReference = component.LFReference;
		audioReverbZone.roomRolloffFactor = component.RoomRolloffFactor;
		audioReverbZone.diffusion = component.Diffusion;
		audioReverbZone.density = component.Density;
		audioReverbZone.enabled = component.Enabled;
	}

	// Token: 0x06000B20 RID: 2848 RVA: 0x0005E1C8 File Offset: 0x0005C5C8
	public AudioReverbZoneSerializer(GameObject gameObject)
	{
		AudioReverbZone component = gameObject.GetComponent<AudioReverbZone>();
		this.MinDistance = component.minDistance;
		this.MaxDistance = component.maxDistance;
		this.ReverbPreset = (AudioReverbPresetSerializer)component.reverbPreset;
		this.Room = component.room;
		this.RoomHF = component.roomHF;
		this.RoomLF = component.roomLF;
		this.DecayTime = component.decayTime;
		this.DecayHFRatio = component.decayHFRatio;
		this.Reflections = component.reflections;
		this.ReflectionsDelay = component.reflectionsDelay;
		this.Reverb = component.reverb;
		this.ReverbDelay = component.reverbDelay;
		this.HFReference = component.HFReference;
		this.LFReference = component.LFReference;
		this.RoomRolloffFactor = component.roomRolloffFactor;
		this.Diffusion = component.diffusion;
		this.Density = component.density;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000B21 RID: 2849 RVA: 0x0005E2BA File Offset: 0x0005C6BA
	private AudioReverbZoneSerializer()
	{
	}

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x06000B22 RID: 2850 RVA: 0x0005E2C2 File Offset: 0x0005C6C2
	// (set) Token: 0x06000B23 RID: 2851 RVA: 0x0005E2CA File Offset: 0x0005C6CA
	[ProtoMember(1)]
	public float MinDistance { get; set; }

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x06000B24 RID: 2852 RVA: 0x0005E2D3 File Offset: 0x0005C6D3
	// (set) Token: 0x06000B25 RID: 2853 RVA: 0x0005E2DB File Offset: 0x0005C6DB
	[ProtoMember(2)]
	public float MaxDistance { get; set; }

	// Token: 0x170000FF RID: 255
	// (get) Token: 0x06000B26 RID: 2854 RVA: 0x0005E2E4 File Offset: 0x0005C6E4
	// (set) Token: 0x06000B27 RID: 2855 RVA: 0x0005E2EC File Offset: 0x0005C6EC
	[ProtoMember(3)]
	public AudioReverbPresetSerializer ReverbPreset { get; set; }

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x06000B28 RID: 2856 RVA: 0x0005E2F5 File Offset: 0x0005C6F5
	// (set) Token: 0x06000B29 RID: 2857 RVA: 0x0005E2FD File Offset: 0x0005C6FD
	[ProtoMember(4)]
	public int Room { get; set; }

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x06000B2A RID: 2858 RVA: 0x0005E306 File Offset: 0x0005C706
	// (set) Token: 0x06000B2B RID: 2859 RVA: 0x0005E30E File Offset: 0x0005C70E
	[ProtoMember(5)]
	public int RoomHF { get; set; }

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x06000B2C RID: 2860 RVA: 0x0005E317 File Offset: 0x0005C717
	// (set) Token: 0x06000B2D RID: 2861 RVA: 0x0005E31F File Offset: 0x0005C71F
	[ProtoMember(6)]
	public int RoomLF { get; set; }

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x06000B2E RID: 2862 RVA: 0x0005E328 File Offset: 0x0005C728
	// (set) Token: 0x06000B2F RID: 2863 RVA: 0x0005E330 File Offset: 0x0005C730
	[ProtoMember(7)]
	public float DecayTime { get; set; }

	// Token: 0x17000104 RID: 260
	// (get) Token: 0x06000B30 RID: 2864 RVA: 0x0005E339 File Offset: 0x0005C739
	// (set) Token: 0x06000B31 RID: 2865 RVA: 0x0005E341 File Offset: 0x0005C741
	[ProtoMember(8)]
	public float DecayHFRatio { get; set; }

	// Token: 0x17000105 RID: 261
	// (get) Token: 0x06000B32 RID: 2866 RVA: 0x0005E34A File Offset: 0x0005C74A
	// (set) Token: 0x06000B33 RID: 2867 RVA: 0x0005E352 File Offset: 0x0005C752
	[ProtoMember(9)]
	public int Reflections { get; set; }

	// Token: 0x17000106 RID: 262
	// (get) Token: 0x06000B34 RID: 2868 RVA: 0x0005E35B File Offset: 0x0005C75B
	// (set) Token: 0x06000B35 RID: 2869 RVA: 0x0005E363 File Offset: 0x0005C763
	[ProtoMember(10)]
	public float ReflectionsDelay { get; set; }

	// Token: 0x17000107 RID: 263
	// (get) Token: 0x06000B36 RID: 2870 RVA: 0x0005E36C File Offset: 0x0005C76C
	// (set) Token: 0x06000B37 RID: 2871 RVA: 0x0005E374 File Offset: 0x0005C774
	[ProtoMember(11)]
	public int Reverb { get; set; }

	// Token: 0x17000108 RID: 264
	// (get) Token: 0x06000B38 RID: 2872 RVA: 0x0005E37D File Offset: 0x0005C77D
	// (set) Token: 0x06000B39 RID: 2873 RVA: 0x0005E385 File Offset: 0x0005C785
	[ProtoMember(12)]
	public float ReverbDelay { get; set; }

	// Token: 0x17000109 RID: 265
	// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0005E38E File Offset: 0x0005C78E
	// (set) Token: 0x06000B3B RID: 2875 RVA: 0x0005E396 File Offset: 0x0005C796
	[ProtoMember(13)]
	public float HFReference { get; set; }

	// Token: 0x1700010A RID: 266
	// (get) Token: 0x06000B3C RID: 2876 RVA: 0x0005E39F File Offset: 0x0005C79F
	// (set) Token: 0x06000B3D RID: 2877 RVA: 0x0005E3A7 File Offset: 0x0005C7A7
	[ProtoMember(14)]
	public float LFReference { get; set; }

	// Token: 0x1700010B RID: 267
	// (get) Token: 0x06000B3E RID: 2878 RVA: 0x0005E3B0 File Offset: 0x0005C7B0
	// (set) Token: 0x06000B3F RID: 2879 RVA: 0x0005E3B8 File Offset: 0x0005C7B8
	[ProtoMember(15)]
	public float RoomRolloffFactor { get; set; }

	// Token: 0x1700010C RID: 268
	// (get) Token: 0x06000B40 RID: 2880 RVA: 0x0005E3C1 File Offset: 0x0005C7C1
	// (set) Token: 0x06000B41 RID: 2881 RVA: 0x0005E3C9 File Offset: 0x0005C7C9
	[ProtoMember(16)]
	public float Diffusion { get; set; }

	// Token: 0x1700010D RID: 269
	// (get) Token: 0x06000B42 RID: 2882 RVA: 0x0005E3D2 File Offset: 0x0005C7D2
	// (set) Token: 0x06000B43 RID: 2883 RVA: 0x0005E3DA File Offset: 0x0005C7DA
	[ProtoMember(17)]
	public float Density { get; set; }

	// Token: 0x1700010E RID: 270
	// (get) Token: 0x06000B44 RID: 2884 RVA: 0x0005E3E3 File Offset: 0x0005C7E3
	// (set) Token: 0x06000B45 RID: 2885 RVA: 0x0005E3EB File Offset: 0x0005C7EB
	[ProtoMember(18)]
	public bool Enabled { get; set; }
}
