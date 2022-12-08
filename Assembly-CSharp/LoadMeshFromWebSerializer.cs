using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001DA RID: 474
[ProtoContract]
public sealed class LoadMeshFromWebSerializer
{
	// Token: 0x06000B9F RID: 2975 RVA: 0x0005F26C File Offset: 0x0005D66C
	public LoadMeshFromWebSerializer(GameObject gameObject)
	{
		LoadMeshFromWeb component = gameObject.GetComponent<LoadMeshFromWeb>();
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x0005F288 File Offset: 0x0005D688
	public LoadMeshFromWebSerializer(GameObject gameObject, LoadMeshFromWebSerializer component)
	{
		LoadMeshFromWeb x = gameObject.GetComponent<LoadMeshFromWeb>();
		if (x == null)
		{
			x = gameObject.AddComponent<LoadMeshFromWeb>();
		}
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x0005F2B5 File Offset: 0x0005D6B5
	public LoadMeshFromWebSerializer()
	{
	}
}
