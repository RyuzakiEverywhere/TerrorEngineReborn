using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000205 RID: 517
[ProtoContract]
public sealed class MeshColliderSerializer
{
	// Token: 0x06000DFC RID: 3580 RVA: 0x000645E4 File Offset: 0x000629E4
	public MeshColliderSerializer(GameObject gameObject, MeshColliderSerializer component)
	{
		MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
		if (meshCollider == null)
		{
			meshCollider = gameObject.AddComponent<MeshCollider>();
		}
		meshCollider.enabled = component.Enabled;
		meshCollider.isTrigger = component.IsTrigger;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			meshCollider.material = (PhysicMaterial)UniSave.TryLoadResource(component.MaterialName);
		}
		if (component.SharedMesh != null)
		{
			meshCollider.sharedMesh = (Mesh)component.SharedMesh;
			meshCollider.sharedMesh.name = component.SharedMesh.MeshName;
		}
		meshCollider.convex = component.Convex;
		this.SmoothSphereCollisions = meshCollider.smoothSphereCollisions;
	}

	// Token: 0x06000DFD RID: 3581 RVA: 0x0006469C File Offset: 0x00062A9C
	public MeshColliderSerializer(GameObject gameObject)
	{
		MeshCollider component = gameObject.GetComponent<MeshCollider>();
		this.Enabled = component.enabled;
		this.IsTrigger = component.isTrigger;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		if (component.sharedMesh != null)
		{
			this.SharedMesh = (global::MeshSerializer)component.sharedMesh;
			this.SharedMesh.MeshName = component.sharedMesh.name;
		}
		this.Convex = component.convex;
		this.SmoothSphereCollisions = component.smoothSphereCollisions;
	}

	// Token: 0x06000DFE RID: 3582 RVA: 0x00064740 File Offset: 0x00062B40
	private MeshColliderSerializer()
	{
	}

	// Token: 0x1700020D RID: 525
	// (get) Token: 0x06000DFF RID: 3583 RVA: 0x00064748 File Offset: 0x00062B48
	// (set) Token: 0x06000E00 RID: 3584 RVA: 0x00064750 File Offset: 0x00062B50
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x1700020E RID: 526
	// (get) Token: 0x06000E01 RID: 3585 RVA: 0x00064759 File Offset: 0x00062B59
	// (set) Token: 0x06000E02 RID: 3586 RVA: 0x00064761 File Offset: 0x00062B61
	[ProtoMember(2)]
	public bool IsTrigger { get; set; }

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x06000E03 RID: 3587 RVA: 0x0006476A File Offset: 0x00062B6A
	// (set) Token: 0x06000E04 RID: 3588 RVA: 0x00064772 File Offset: 0x00062B72
	[ProtoMember(3)]
	public string MaterialName { get; set; }

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x06000E05 RID: 3589 RVA: 0x0006477B File Offset: 0x00062B7B
	// (set) Token: 0x06000E06 RID: 3590 RVA: 0x00064783 File Offset: 0x00062B83
	[ProtoMember(4)]
	public global::MeshSerializer SharedMesh { get; set; }

	// Token: 0x17000211 RID: 529
	// (get) Token: 0x06000E07 RID: 3591 RVA: 0x0006478C File Offset: 0x00062B8C
	// (set) Token: 0x06000E08 RID: 3592 RVA: 0x00064794 File Offset: 0x00062B94
	[ProtoMember(5)]
	public bool Convex { get; set; }

	// Token: 0x17000212 RID: 530
	// (get) Token: 0x06000E09 RID: 3593 RVA: 0x0006479D File Offset: 0x00062B9D
	// (set) Token: 0x06000E0A RID: 3594 RVA: 0x000647A5 File Offset: 0x00062BA5
	[ProtoMember(6)]
	public bool SmoothSphereCollisions { get; set; }
}
