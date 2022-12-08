using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001FD RID: 509
[ProtoContract]
public sealed class CharacterControllerSerializer
{
	// Token: 0x06000D1C RID: 3356 RVA: 0x000631B8 File Offset: 0x000615B8
	public CharacterControllerSerializer(GameObject gameObject, CharacterControllerSerializer component)
	{
		CharacterController characterController = gameObject.GetComponent<CharacterController>();
		if (characterController == null)
		{
			characterController = gameObject.AddComponent<CharacterController>();
		}
		characterController.enabled = component.Enabled;
		characterController.isTrigger = component.IsTrigger;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			characterController.material = (PhysicMaterial)UniSave.TryLoadResource(component.MaterialName);
		}
		characterController.radius = component.Radius;
		characterController.height = component.Height;
		characterController.center = (Vector3)component.Center;
		characterController.slopeLimit = component.SlopeLimit;
		characterController.stepOffset = component.StepOffset;
		characterController.detectCollisions = component.DetectCollisions;
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x00063270 File Offset: 0x00061670
	public CharacterControllerSerializer(GameObject gameObject)
	{
		CharacterController component = gameObject.GetComponent<CharacterController>();
		this.Enabled = component.enabled;
		this.IsTrigger = component.isTrigger;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		this.Radius = component.radius;
		this.Height = component.height;
		this.Center = (Vector3Serializer)component.center;
		this.SlopeLimit = component.slopeLimit;
		this.StepOffset = component.stepOffset;
		this.DetectCollisions = component.detectCollisions;
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x00063311 File Offset: 0x00061711
	private CharacterControllerSerializer()
	{
	}

	// Token: 0x170001A9 RID: 425
	// (get) Token: 0x06000D1F RID: 3359 RVA: 0x00063319 File Offset: 0x00061719
	// (set) Token: 0x06000D20 RID: 3360 RVA: 0x00063321 File Offset: 0x00061721
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x170001AA RID: 426
	// (get) Token: 0x06000D21 RID: 3361 RVA: 0x0006332A File Offset: 0x0006172A
	// (set) Token: 0x06000D22 RID: 3362 RVA: 0x00063332 File Offset: 0x00061732
	[ProtoMember(2)]
	public bool IsTrigger { get; set; }

	// Token: 0x170001AB RID: 427
	// (get) Token: 0x06000D23 RID: 3363 RVA: 0x0006333B File Offset: 0x0006173B
	// (set) Token: 0x06000D24 RID: 3364 RVA: 0x00063343 File Offset: 0x00061743
	[ProtoMember(3)]
	public string MaterialName { get; set; }

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x06000D25 RID: 3365 RVA: 0x0006334C File Offset: 0x0006174C
	// (set) Token: 0x06000D26 RID: 3366 RVA: 0x00063354 File Offset: 0x00061754
	[ProtoMember(4)]
	public float Radius { get; set; }

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x06000D27 RID: 3367 RVA: 0x0006335D File Offset: 0x0006175D
	// (set) Token: 0x06000D28 RID: 3368 RVA: 0x00063365 File Offset: 0x00061765
	[ProtoMember(5)]
	public float Height { get; set; }

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06000D29 RID: 3369 RVA: 0x0006336E File Offset: 0x0006176E
	// (set) Token: 0x06000D2A RID: 3370 RVA: 0x00063376 File Offset: 0x00061776
	[ProtoMember(6)]
	public Vector3Serializer Center { get; set; }

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x06000D2B RID: 3371 RVA: 0x0006337F File Offset: 0x0006177F
	// (set) Token: 0x06000D2C RID: 3372 RVA: 0x00063387 File Offset: 0x00061787
	[ProtoMember(7)]
	public float SlopeLimit { get; set; }

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x06000D2D RID: 3373 RVA: 0x00063390 File Offset: 0x00061790
	// (set) Token: 0x06000D2E RID: 3374 RVA: 0x00063398 File Offset: 0x00061798
	[ProtoMember(8)]
	public float StepOffset { get; set; }

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x06000D2F RID: 3375 RVA: 0x000633A1 File Offset: 0x000617A1
	// (set) Token: 0x06000D30 RID: 3376 RVA: 0x000633A9 File Offset: 0x000617A9
	[ProtoMember(9)]
	public bool DetectCollisions { get; set; }
}
