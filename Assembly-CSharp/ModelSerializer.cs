using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001DF RID: 479
[ProtoContract]
public sealed class ModelSerializer
{
	// Token: 0x06000BAE RID: 2990 RVA: 0x0005F608 File Offset: 0x0005DA08
	public ModelSerializer(GameObject gameObject)
	{
		ModelMesh component = gameObject.GetComponent<ModelMesh>();
		this.hasmesh = component.hasmesh;
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x0005F630 File Offset: 0x0005DA30
	public ModelSerializer(GameObject gameObject, ModelSerializer component)
	{
		ModelMesh modelMesh = gameObject.GetComponent<ModelMesh>();
		if (modelMesh == null)
		{
			modelMesh = gameObject.AddComponent<ModelMesh>();
		}
		modelMesh.hasmesh = component.hasmesh;
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x0005F669 File Offset: 0x0005DA69
	public ModelSerializer()
	{
	}

	// Token: 0x04000D38 RID: 3384
	[ProtoMember(1)]
	public bool hasmesh;
}
