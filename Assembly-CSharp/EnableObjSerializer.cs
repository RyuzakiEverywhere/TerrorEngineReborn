using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D4 RID: 468
[ProtoContract]
public sealed class EnableObjSerializer
{
	// Token: 0x06000B89 RID: 2953 RVA: 0x0005EF24 File Offset: 0x0005D324
	public EnableObjSerializer(GameObject gameObject)
	{
		EditObjEnable component = gameObject.GetComponent<EditObjEnable>();
	}

	// Token: 0x06000B8A RID: 2954 RVA: 0x0005EF40 File Offset: 0x0005D340
	public EnableObjSerializer(GameObject gameObject, EnableObjSerializer component)
	{
		EditObjEnable x = gameObject.GetComponent<EditObjEnable>();
		if (x == null)
		{
			x = gameObject.AddComponent<EditObjEnable>();
		}
	}

	// Token: 0x06000B8B RID: 2955 RVA: 0x0005EF6D File Offset: 0x0005D36D
	public EnableObjSerializer()
	{
	}
}
