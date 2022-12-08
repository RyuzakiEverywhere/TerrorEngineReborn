using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D7 RID: 471
[ProtoContract]
public sealed class GridObjSerializer
{
	// Token: 0x06000B96 RID: 2966 RVA: 0x0005F0F8 File Offset: 0x0005D4F8
	public GridObjSerializer(GameObject gameObject)
	{
		GridCreateObject component = gameObject.GetComponent<GridCreateObject>();
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x0005F114 File Offset: 0x0005D514
	public GridObjSerializer(GameObject gameObject, GridObjSerializer component)
	{
		GridCreateObject x = gameObject.GetComponent<GridCreateObject>();
		if (x == null)
		{
			x = gameObject.AddComponent<GridCreateObject>();
		}
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x0005F141 File Offset: 0x0005D541
	public GridObjSerializer()
	{
	}
}
