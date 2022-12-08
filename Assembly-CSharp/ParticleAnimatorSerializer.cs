using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001EE RID: 494
[ProtoContract]
public class ParticleAnimatorSerializer
{
	// Token: 0x06000BDB RID: 3035 RVA: 0x0006127C File Offset: 0x0005F67C
	public ParticleAnimatorSerializer(GameObject gameObject, ParticleAnimatorSerializer component)
	{
		ParticleAnimator particleAnimator = gameObject.GetComponent<ParticleAnimator>();
		if (particleAnimator == null)
		{
			particleAnimator = gameObject.AddComponent<ParticleAnimator>();
		}
		particleAnimator.doesAnimateColor = component.DoesAnimateColor;
		particleAnimator.worldRotationAxis = (Vector3)component.WorldRotationAxis;
		particleAnimator.localRotationAxis = (Vector3)component.LocalRotationAxis;
		particleAnimator.sizeGrow = component.SizeGrow;
		particleAnimator.rndForce = (Vector3)component.RndForce;
		particleAnimator.force = (Vector3)component.Force;
		particleAnimator.damping = component.Damping;
		particleAnimator.autodestruct = component.Autodestruct;
		particleAnimator.colorAnimation = Array.ConvertAll<ColorSerializer, Color>(component.ColorAnimation, (ColorSerializer element) => (Color)element);
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x0006134C File Offset: 0x0005F74C
	public ParticleAnimatorSerializer(GameObject gameObject)
	{
		ParticleAnimator component = gameObject.GetComponent<ParticleAnimator>();
		this.DoesAnimateColor = component.doesAnimateColor;
		this.WorldRotationAxis = (Vector3Serializer)component.worldRotationAxis;
		this.LocalRotationAxis = (Vector3Serializer)component.localRotationAxis;
		this.SizeGrow = component.sizeGrow;
		this.RndForce = (Vector3Serializer)component.rndForce;
		this.Force = (Vector3Serializer)component.force;
		this.Damping = component.damping;
		this.Autodestruct = component.autodestruct;
		this.ColorAnimation = Array.ConvertAll<Color, ColorSerializer>(component.colorAnimation, (Color element) => (ColorSerializer)element);
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x00061408 File Offset: 0x0005F808
	private ParticleAnimatorSerializer()
	{
	}

	// Token: 0x17000125 RID: 293
	// (get) Token: 0x06000BDE RID: 3038 RVA: 0x00061410 File Offset: 0x0005F810
	// (set) Token: 0x06000BDF RID: 3039 RVA: 0x00061418 File Offset: 0x0005F818
	[ProtoMember(1)]
	public bool DoesAnimateColor { get; set; }

	// Token: 0x17000126 RID: 294
	// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x00061421 File Offset: 0x0005F821
	// (set) Token: 0x06000BE1 RID: 3041 RVA: 0x00061429 File Offset: 0x0005F829
	[ProtoMember(2)]
	public Vector3Serializer WorldRotationAxis { get; set; }

	// Token: 0x17000127 RID: 295
	// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x00061432 File Offset: 0x0005F832
	// (set) Token: 0x06000BE3 RID: 3043 RVA: 0x0006143A File Offset: 0x0005F83A
	[ProtoMember(3)]
	public Vector3Serializer LocalRotationAxis { get; set; }

	// Token: 0x17000128 RID: 296
	// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x00061443 File Offset: 0x0005F843
	// (set) Token: 0x06000BE5 RID: 3045 RVA: 0x0006144B File Offset: 0x0005F84B
	[ProtoMember(4)]
	public float SizeGrow { get; set; }

	// Token: 0x17000129 RID: 297
	// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x00061454 File Offset: 0x0005F854
	// (set) Token: 0x06000BE7 RID: 3047 RVA: 0x0006145C File Offset: 0x0005F85C
	[ProtoMember(5)]
	public Vector3Serializer RndForce { get; set; }

	// Token: 0x1700012A RID: 298
	// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x00061465 File Offset: 0x0005F865
	// (set) Token: 0x06000BE9 RID: 3049 RVA: 0x0006146D File Offset: 0x0005F86D
	[ProtoMember(6)]
	public Vector3Serializer Force { get; set; }

	// Token: 0x1700012B RID: 299
	// (get) Token: 0x06000BEA RID: 3050 RVA: 0x00061476 File Offset: 0x0005F876
	// (set) Token: 0x06000BEB RID: 3051 RVA: 0x0006147E File Offset: 0x0005F87E
	[ProtoMember(7)]
	public float Damping { get; set; }

	// Token: 0x1700012C RID: 300
	// (get) Token: 0x06000BEC RID: 3052 RVA: 0x00061487 File Offset: 0x0005F887
	// (set) Token: 0x06000BED RID: 3053 RVA: 0x0006148F File Offset: 0x0005F88F
	[ProtoMember(8)]
	public bool Autodestruct { get; set; }

	// Token: 0x1700012D RID: 301
	// (get) Token: 0x06000BEE RID: 3054 RVA: 0x00061498 File Offset: 0x0005F898
	// (set) Token: 0x06000BEF RID: 3055 RVA: 0x000614A0 File Offset: 0x0005F8A0
	[ProtoMember(9)]
	public ColorSerializer[] ColorAnimation { get; set; }
}
