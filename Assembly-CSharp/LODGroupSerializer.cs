using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000211 RID: 529
[ProtoContract]
public sealed class LODGroupSerializer
{
	// Token: 0x06000EFC RID: 3836 RVA: 0x00065D2C File Offset: 0x0006412C
	public LODGroupSerializer(GameObject gameObject, LODGroupSerializer component)
	{
		LODGroup lodgroup = gameObject.GetComponent<LODGroup>();
		if (lodgroup == null)
		{
			lodgroup = gameObject.AddComponent<LODGroup>();
		}
		lodgroup.localReferencePoint = (Vector3)component.LocalReferencePoint;
		lodgroup.size = component.Size;
	}

	// Token: 0x06000EFD RID: 3837 RVA: 0x00065D78 File Offset: 0x00064178
	public LODGroupSerializer(GameObject gameObject)
	{
		LODGroup component = gameObject.GetComponent<LODGroup>();
		this.LocalReferencePoint = (Vector3Serializer)component.localReferencePoint;
		this.Size = component.size;
	}

	// Token: 0x06000EFE RID: 3838 RVA: 0x00065DAF File Offset: 0x000641AF
	private LODGroupSerializer()
	{
	}

	// Token: 0x1700027B RID: 635
	// (get) Token: 0x06000EFF RID: 3839 RVA: 0x00065DB7 File Offset: 0x000641B7
	// (set) Token: 0x06000F00 RID: 3840 RVA: 0x00065DBF File Offset: 0x000641BF
	[ProtoMember(1)]
	public Vector3Serializer LocalReferencePoint { get; set; }

	// Token: 0x1700027C RID: 636
	// (get) Token: 0x06000F01 RID: 3841 RVA: 0x00065DC8 File Offset: 0x000641C8
	// (set) Token: 0x06000F02 RID: 3842 RVA: 0x00065DD0 File Offset: 0x000641D0
	[ProtoMember(2)]
	public float Size { get; set; }
}
