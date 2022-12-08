using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E4 RID: 484
[ProtoContract]
public sealed class PhotonSerializer
{
	// Token: 0x06000BBD RID: 3005 RVA: 0x0005FBFC File Offset: 0x0005DFFC
	public PhotonSerializer(GameObject gameObject)
	{
		PhotonView component = gameObject.GetComponent<PhotonView>();
		this.viewID = component.viewID;
		this.observed = component.observed;
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x0005FC30 File Offset: 0x0005E030
	public PhotonSerializer(GameObject gameObject, PhotonSerializer component)
	{
		PhotonView photonView = gameObject.GetComponent<PhotonView>();
		if (photonView == null)
		{
			photonView = gameObject.AddComponent<PhotonView>();
		}
		photonView.viewID = component.viewID;
		photonView.observed = component.observed;
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0005FC75 File Offset: 0x0005E075
	public PhotonSerializer()
	{
	}

	// Token: 0x04000D65 RID: 3429
	[ProtoMember(1)]
	public int viewID;

	// Token: 0x04000D66 RID: 3430
	[ProtoMember(2)]
	public Component observed;
}
