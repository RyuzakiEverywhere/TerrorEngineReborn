using System;
using System.Collections;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F8 RID: 504
[ProtoContract]
public sealed class AnimationSerializer
{
	// Token: 0x06000CBD RID: 3261 RVA: 0x0006278C File Offset: 0x00060B8C
	public AnimationSerializer(GameObject gameObject, AnimationSerializer component)
	{
		Animation animation = gameObject.GetComponent<Animation>();
		if (animation == null)
		{
			animation = gameObject.AddComponent<Animation>();
		}
		if (!string.IsNullOrEmpty(component.ClipName))
		{
			animation.clip = (AnimationClip)UniSave.TryLoadResource(component.ClipName);
		}
		animation.playAutomatically = component.PlayAutomatically;
		animation.wrapMode = (WrapMode)component.WrapMode;
		animation.animatePhysics = component.AnimatePhysics;
		animation.cullingType = (AnimationCullingType)component.CullingType;
		animation.localBounds = (Bounds)component.LocalBounds;
		foreach (AnimationStateSerializer animationStateSerializer in component.Animations)
		{
			animation.AddClip((AnimationClip)UniSave.TryLoadResource(animationStateSerializer.ClipName), animationStateSerializer.Name);
			animation[animationStateSerializer.Name].enabled = animationStateSerializer.Enabled;
			animation[animationStateSerializer.Name].weight = animationStateSerializer.Weight;
			animation[animationStateSerializer.Name].wrapMode = (WrapMode)animationStateSerializer.WrapMode;
			animation[animationStateSerializer.Name].time = animationStateSerializer.Time;
			animation[animationStateSerializer.Name].normalizedTime = animationStateSerializer.NormalizedTime;
			animation[animationStateSerializer.Name].speed = animationStateSerializer.Speed;
			animation[animationStateSerializer.Name].normalizedSpeed = animationStateSerializer.NormalizedSpeed;
			animation[animationStateSerializer.Name].layer = animationStateSerializer.Layer;
			animation[animationStateSerializer.Name].name = animationStateSerializer.Name;
			animation[animationStateSerializer.Name].blendMode = (AnimationBlendMode)animationStateSerializer.BlendMode;
		}
		animation.enabled = component.Enabled;
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x00062950 File Offset: 0x00060D50
	public AnimationSerializer(GameObject gameObject)
	{
		Animation component = gameObject.GetComponent<Animation>();
		if (component.clip != null)
		{
			this.ClipName = component.clip.name;
		}
		this.PlayAutomatically = component.playAutomatically;
		this.WrapMode = (WrapModeSerializer)component.wrapMode;
		this.AnimatePhysics = component.animatePhysics;
		this.CullingType = (AnimationCullingTypeSerializer)component.cullingType;
		this.LocalBounds = (BoundsSerializer)component.localBounds;
		this.Animations = new AnimationStateSerializer[component.GetClipCount()];
		int num = 0;
		IEnumerator enumerator = component.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				AnimationState data = (AnimationState)obj;
				this.Animations[num] = (AnimationStateSerializer)data;
				num++;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		this.Enabled = component.enabled;
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x00062A4C File Offset: 0x00060E4C
	private AnimationSerializer()
	{
	}

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x00062A54 File Offset: 0x00060E54
	// (set) Token: 0x06000CC1 RID: 3265 RVA: 0x00062A5C File Offset: 0x00060E5C
	[ProtoMember(1)]
	public string ClipName { get; set; }

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x00062A65 File Offset: 0x00060E65
	// (set) Token: 0x06000CC3 RID: 3267 RVA: 0x00062A6D File Offset: 0x00060E6D
	[ProtoMember(2)]
	public bool PlayAutomatically { get; set; }

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x06000CC4 RID: 3268 RVA: 0x00062A76 File Offset: 0x00060E76
	// (set) Token: 0x06000CC5 RID: 3269 RVA: 0x00062A7E File Offset: 0x00060E7E
	[ProtoMember(3)]
	public WrapModeSerializer WrapMode { get; set; }

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x06000CC6 RID: 3270 RVA: 0x00062A87 File Offset: 0x00060E87
	// (set) Token: 0x06000CC7 RID: 3271 RVA: 0x00062A8F File Offset: 0x00060E8F
	[ProtoMember(4)]
	public bool AnimatePhysics { get; set; }

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x00062A98 File Offset: 0x00060E98
	// (set) Token: 0x06000CC9 RID: 3273 RVA: 0x00062AA0 File Offset: 0x00060EA0
	[ProtoMember(5)]
	public AnimationCullingTypeSerializer CullingType { get; set; }

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x06000CCA RID: 3274 RVA: 0x00062AA9 File Offset: 0x00060EA9
	// (set) Token: 0x06000CCB RID: 3275 RVA: 0x00062AB1 File Offset: 0x00060EB1
	[ProtoMember(6)]
	public BoundsSerializer LocalBounds { get; set; }

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x06000CCC RID: 3276 RVA: 0x00062ABA File Offset: 0x00060EBA
	// (set) Token: 0x06000CCD RID: 3277 RVA: 0x00062AC2 File Offset: 0x00060EC2
	[ProtoMember(7)]
	public AnimationStateSerializer[] Animations { get; set; }

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x06000CCE RID: 3278 RVA: 0x00062ACB File Offset: 0x00060ECB
	// (set) Token: 0x06000CCF RID: 3279 RVA: 0x00062AD3 File Offset: 0x00060ED3
	[ProtoMember(8)]
	public bool Enabled { get; set; }
}
