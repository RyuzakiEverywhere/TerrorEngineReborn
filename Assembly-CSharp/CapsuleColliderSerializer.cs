using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001FC RID: 508
[ProtoContract]
public sealed class CapsuleColliderSerializer
{
	// Token: 0x06000D0B RID: 3339 RVA: 0x00063028 File Offset: 0x00061428
	public CapsuleColliderSerializer(GameObject gameObject, CapsuleColliderSerializer component)
	{
		CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
		if (capsuleCollider == null)
		{
			capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
		}
		capsuleCollider.enabled = component.Enabled;
		capsuleCollider.isTrigger = component.IsTrigger;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			capsuleCollider.material = (PhysicMaterial)UniSave.TryLoadResource(component.MaterialName);
		}
		capsuleCollider.center = (Vector3)component.Center;
		capsuleCollider.radius = component.Radius;
		capsuleCollider.direction = component.Direction;
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x000630BC File Offset: 0x000614BC
	public CapsuleColliderSerializer(GameObject gameObject)
	{
		CapsuleCollider component = gameObject.GetComponent<CapsuleCollider>();
		this.Enabled = component.enabled;
		this.IsTrigger = component.isTrigger;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		this.Center = (Vector3Serializer)component.center;
		this.Radius = component.radius;
		this.Direction = component.direction;
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x00063139 File Offset: 0x00061539
	private CapsuleColliderSerializer()
	{
	}

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x06000D0E RID: 3342 RVA: 0x00063141 File Offset: 0x00061541
	// (set) Token: 0x06000D0F RID: 3343 RVA: 0x00063149 File Offset: 0x00061549
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x06000D10 RID: 3344 RVA: 0x00063152 File Offset: 0x00061552
	// (set) Token: 0x06000D11 RID: 3345 RVA: 0x0006315A File Offset: 0x0006155A
	[ProtoMember(2)]
	public bool IsTrigger { get; set; }

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x06000D12 RID: 3346 RVA: 0x00063163 File Offset: 0x00061563
	// (set) Token: 0x06000D13 RID: 3347 RVA: 0x0006316B File Offset: 0x0006156B
	[ProtoMember(3)]
	public string MaterialName { get; set; }

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x06000D14 RID: 3348 RVA: 0x00063174 File Offset: 0x00061574
	// (set) Token: 0x06000D15 RID: 3349 RVA: 0x0006317C File Offset: 0x0006157C
	[ProtoMember(4)]
	public Vector3Serializer Center { get; set; }

	// Token: 0x170001A6 RID: 422
	// (get) Token: 0x06000D16 RID: 3350 RVA: 0x00063185 File Offset: 0x00061585
	// (set) Token: 0x06000D17 RID: 3351 RVA: 0x0006318D File Offset: 0x0006158D
	[ProtoMember(5)]
	public float Radius { get; set; }

	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x06000D18 RID: 3352 RVA: 0x00063196 File Offset: 0x00061596
	// (set) Token: 0x06000D19 RID: 3353 RVA: 0x0006319E File Offset: 0x0006159E
	[ProtoMember(6)]
	public float Height { get; set; }

	// Token: 0x170001A8 RID: 424
	// (get) Token: 0x06000D1A RID: 3354 RVA: 0x000631A7 File Offset: 0x000615A7
	// (set) Token: 0x06000D1B RID: 3355 RVA: 0x000631AF File Offset: 0x000615AF
	[ProtoMember(7)]
	public int Direction { get; set; }
}
