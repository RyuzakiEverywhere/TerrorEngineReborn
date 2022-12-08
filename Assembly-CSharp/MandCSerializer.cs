using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001DC RID: 476
[ProtoContract]
public sealed class MandCSerializer
{
	// Token: 0x06000BA5 RID: 2981 RVA: 0x0005F314 File Offset: 0x0005D714
	public MandCSerializer(GameObject gameObject)
	{
		DestroyMeshAndCollider component = gameObject.GetComponent<DestroyMeshAndCollider>();
		this.istrigger = component.istrigger;
		this.deletecollider = component.deletecollider;
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0005F348 File Offset: 0x0005D748
	public MandCSerializer(GameObject gameObject, MandCSerializer component)
	{
		DestroyMeshAndCollider destroyMeshAndCollider = gameObject.GetComponent<DestroyMeshAndCollider>();
		if (destroyMeshAndCollider == null)
		{
			destroyMeshAndCollider = gameObject.AddComponent<DestroyMeshAndCollider>();
		}
		destroyMeshAndCollider.istrigger = component.istrigger;
		destroyMeshAndCollider.deletecollider = component.deletecollider;
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0005F38D File Offset: 0x0005D78D
	public MandCSerializer()
	{
	}

	// Token: 0x04000D23 RID: 3363
	[ProtoMember(1)]
	public bool istrigger;

	// Token: 0x04000D24 RID: 3364
	[ProtoMember(2)]
	public bool deletecollider;
}
