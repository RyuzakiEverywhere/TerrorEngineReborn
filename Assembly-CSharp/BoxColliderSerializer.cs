using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001FB RID: 507
[ProtoContract]
public sealed class BoxColliderSerializer
{
	// Token: 0x06000CFC RID: 3324 RVA: 0x00062E90 File Offset: 0x00061290
	public BoxColliderSerializer(GameObject gameObject, BoxColliderSerializer component)
	{
		BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
		if (boxCollider == null)
		{
			boxCollider = gameObject.AddComponent<BoxCollider>();
		}
		boxCollider.enabled = component.Enabled;
		boxCollider.isTrigger = component.IsTrigger;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			boxCollider.material = (PhysicMaterial)UniSave.TryLoadResource(component.MaterialName);
		}
		boxCollider.center = (Vector3)component.Center;
		boxCollider.size = (Vector3)component.Size;
		boxCollider.extents = (Vector3)component.Extents;
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x00062F30 File Offset: 0x00061330
	public BoxColliderSerializer(GameObject gameObject)
	{
		BoxCollider component = gameObject.GetComponent<BoxCollider>();
		this.Enabled = component.enabled;
		this.IsTrigger = component.isTrigger;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		this.Center = (Vector3Serializer)component.center;
		this.Size = (Vector3Serializer)component.size;
		this.Extents = (Vector3Serializer)component.extents;
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x00062FB7 File Offset: 0x000613B7
	private BoxColliderSerializer()
	{
	}

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x06000CFF RID: 3327 RVA: 0x00062FBF File Offset: 0x000613BF
	// (set) Token: 0x06000D00 RID: 3328 RVA: 0x00062FC7 File Offset: 0x000613C7
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x1700019D RID: 413
	// (get) Token: 0x06000D01 RID: 3329 RVA: 0x00062FD0 File Offset: 0x000613D0
	// (set) Token: 0x06000D02 RID: 3330 RVA: 0x00062FD8 File Offset: 0x000613D8
	[ProtoMember(2)]
	public bool IsTrigger { get; set; }

	// Token: 0x1700019E RID: 414
	// (get) Token: 0x06000D03 RID: 3331 RVA: 0x00062FE1 File Offset: 0x000613E1
	// (set) Token: 0x06000D04 RID: 3332 RVA: 0x00062FE9 File Offset: 0x000613E9
	[ProtoMember(3)]
	public string MaterialName { get; set; }

	// Token: 0x1700019F RID: 415
	// (get) Token: 0x06000D05 RID: 3333 RVA: 0x00062FF2 File Offset: 0x000613F2
	// (set) Token: 0x06000D06 RID: 3334 RVA: 0x00062FFA File Offset: 0x000613FA
	[ProtoMember(4)]
	public Vector3Serializer Center { get; set; }

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x06000D07 RID: 3335 RVA: 0x00063003 File Offset: 0x00061403
	// (set) Token: 0x06000D08 RID: 3336 RVA: 0x0006300B File Offset: 0x0006140B
	[ProtoMember(5)]
	public Vector3Serializer Size { get; set; }

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x06000D09 RID: 3337 RVA: 0x00063014 File Offset: 0x00061414
	// (set) Token: 0x06000D0A RID: 3338 RVA: 0x0006301C File Offset: 0x0006141C
	[ProtoMember(6)]
	public Vector3Serializer Extents { get; set; }
}
