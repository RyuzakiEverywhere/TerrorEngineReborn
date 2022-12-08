using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001F5 RID: 501
[ProtoContract]
public sealed class MeshFilterSerializer
{
	// Token: 0x06000C8E RID: 3214 RVA: 0x00062284 File Offset: 0x00060684
	public MeshFilterSerializer(GameObject gameObject, MeshFilterSerializer component)
	{
		MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
		if (meshFilter == null)
		{
			meshFilter = gameObject.AddComponent<MeshFilter>();
		}
		if (component.Mesh != null)
		{
			meshFilter.mesh = (Mesh)component.Mesh;
			meshFilter.mesh.name = component.Mesh.MeshName;
		}
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x000622E4 File Offset: 0x000606E4
	public MeshFilterSerializer(GameObject gameObject)
	{
		MeshFilter component = gameObject.GetComponent<MeshFilter>();
		if (component.mesh != null)
		{
			this.Mesh = (global::MeshSerializer)component.mesh;
			this.Mesh.MeshName = component.mesh.name;
		}
	}

	// Token: 0x06000C90 RID: 3216 RVA: 0x00062336 File Offset: 0x00060736
	private MeshFilterSerializer()
	{
	}

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x06000C91 RID: 3217 RVA: 0x0006233E File Offset: 0x0006073E
	// (set) Token: 0x06000C92 RID: 3218 RVA: 0x00062346 File Offset: 0x00060746
	[ProtoMember(1)]
	public global::MeshSerializer Mesh { get; set; }
}
