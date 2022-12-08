using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001DB RID: 475
[ProtoContract]
public sealed class LoadOBJCSSerializer
{
	// Token: 0x06000BA2 RID: 2978 RVA: 0x0005F2C0 File Offset: 0x0005D6C0
	public LoadOBJCSSerializer(GameObject gameObject)
	{
		LoadOBJCS component = gameObject.GetComponent<LoadOBJCS>();
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x0005F2DC File Offset: 0x0005D6DC
	public LoadOBJCSSerializer(GameObject gameObject, LoadOBJCSSerializer component)
	{
		LoadOBJCS x = gameObject.GetComponent<LoadOBJCS>();
		if (x == null)
		{
			x = gameObject.AddComponent<LoadOBJCS>();
		}
	}

	// Token: 0x06000BA4 RID: 2980 RVA: 0x0005F309 File Offset: 0x0005D709
	public LoadOBJCSSerializer()
	{
	}
}
