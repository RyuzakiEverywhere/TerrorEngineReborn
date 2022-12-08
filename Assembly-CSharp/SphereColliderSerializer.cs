using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000208 RID: 520
[ProtoContract]
public sealed class SphereColliderSerializer
{
	// Token: 0x06000E55 RID: 3669 RVA: 0x00064C48 File Offset: 0x00063048
	public SphereColliderSerializer(GameObject gameObject, SphereColliderSerializer component)
	{
		SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
		if (sphereCollider == null)
		{
			sphereCollider = gameObject.AddComponent<SphereCollider>();
		}
		sphereCollider.enabled = component.Enabled;
		sphereCollider.isTrigger = component.IsTrigger;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			sphereCollider.material = (PhysicMaterial)UniSave.TryLoadResource(component.MaterialName);
		}
		sphereCollider.center = (Vector3)component.Center;
		sphereCollider.radius = component.Radius;
	}

	// Token: 0x06000E56 RID: 3670 RVA: 0x00064CD0 File Offset: 0x000630D0
	public SphereColliderSerializer(GameObject gameObject)
	{
		SphereCollider component = gameObject.GetComponent<SphereCollider>();
		this.Enabled = component.enabled;
		this.IsTrigger = component.isTrigger;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		this.Center = (Vector3Serializer)component.center;
		this.Radius = component.radius;
	}

	// Token: 0x06000E57 RID: 3671 RVA: 0x00064D41 File Offset: 0x00063141
	private SphereColliderSerializer()
	{
	}

	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06000E58 RID: 3672 RVA: 0x00064D49 File Offset: 0x00063149
	// (set) Token: 0x06000E59 RID: 3673 RVA: 0x00064D51 File Offset: 0x00063151
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06000E5A RID: 3674 RVA: 0x00064D5A File Offset: 0x0006315A
	// (set) Token: 0x06000E5B RID: 3675 RVA: 0x00064D62 File Offset: 0x00063162
	[ProtoMember(2)]
	public bool IsTrigger { get; set; }

	// Token: 0x17000237 RID: 567
	// (get) Token: 0x06000E5C RID: 3676 RVA: 0x00064D6B File Offset: 0x0006316B
	// (set) Token: 0x06000E5D RID: 3677 RVA: 0x00064D73 File Offset: 0x00063173
	[ProtoMember(3)]
	public string MaterialName { get; set; }

	// Token: 0x17000238 RID: 568
	// (get) Token: 0x06000E5E RID: 3678 RVA: 0x00064D7C File Offset: 0x0006317C
	// (set) Token: 0x06000E5F RID: 3679 RVA: 0x00064D84 File Offset: 0x00063184
	[ProtoMember(4)]
	public Vector3Serializer Center { get; set; }

	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06000E60 RID: 3680 RVA: 0x00064D8D File Offset: 0x0006318D
	// (set) Token: 0x06000E61 RID: 3681 RVA: 0x00064D95 File Offset: 0x00063195
	[ProtoMember(5)]
	public float Radius { get; set; }
}
