using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200020A RID: 522
[ProtoContract]
public sealed class TerrainColliderSerializer
{
	// Token: 0x06000E77 RID: 3703 RVA: 0x0006501C File Offset: 0x0006341C
	public TerrainColliderSerializer(GameObject gameObject, TerrainColliderSerializer component)
	{
		TerrainCollider terrainCollider = gameObject.GetComponent<TerrainCollider>();
		if (terrainCollider == null)
		{
			terrainCollider = gameObject.AddComponent<TerrainCollider>();
		}
		terrainCollider.enabled = component.Enabled;
		terrainCollider.isTrigger = component.IsTrigger;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			terrainCollider.material = (PhysicMaterial)UniSave.TryLoadResource(component.MaterialName);
		}
		if (!string.IsNullOrEmpty(component.TerrainDataName))
		{
			terrainCollider.terrainData = (TerrainData)UniSave.TryLoadResource(component.TerrainDataName);
		}
	}

	// Token: 0x06000E78 RID: 3704 RVA: 0x000650B0 File Offset: 0x000634B0
	public TerrainColliderSerializer(GameObject gameObject)
	{
		TerrainCollider component = gameObject.GetComponent<TerrainCollider>();
		this.Enabled = component.enabled;
		this.IsTrigger = component.isTrigger;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		if (component.terrainData != null)
		{
			this.TerrainDataName = component.terrainData.name;
		}
	}

	// Token: 0x06000E79 RID: 3705 RVA: 0x00065126 File Offset: 0x00063526
	private TerrainColliderSerializer()
	{
	}

	// Token: 0x17000243 RID: 579
	// (get) Token: 0x06000E7A RID: 3706 RVA: 0x0006512E File Offset: 0x0006352E
	// (set) Token: 0x06000E7B RID: 3707 RVA: 0x00065136 File Offset: 0x00063536
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x17000244 RID: 580
	// (get) Token: 0x06000E7C RID: 3708 RVA: 0x0006513F File Offset: 0x0006353F
	// (set) Token: 0x06000E7D RID: 3709 RVA: 0x00065147 File Offset: 0x00063547
	[ProtoMember(2)]
	public bool IsTrigger { get; set; }

	// Token: 0x17000245 RID: 581
	// (get) Token: 0x06000E7E RID: 3710 RVA: 0x00065150 File Offset: 0x00063550
	// (set) Token: 0x06000E7F RID: 3711 RVA: 0x00065158 File Offset: 0x00063558
	[ProtoMember(3)]
	public string MaterialName { get; set; }

	// Token: 0x17000246 RID: 582
	// (get) Token: 0x06000E80 RID: 3712 RVA: 0x00065161 File Offset: 0x00063561
	// (set) Token: 0x06000E81 RID: 3713 RVA: 0x00065169 File Offset: 0x00063569
	[ProtoMember(4)]
	public string TerrainDataName { get; set; }
}
