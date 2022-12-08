using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000215 RID: 533
[ProtoContract]
public sealed class OcclusionPortalSerializer
{
	// Token: 0x06000F34 RID: 3892 RVA: 0x000662F0 File Offset: 0x000646F0
	public OcclusionPortalSerializer(GameObject gameObject, OcclusionPortalSerializer component)
	{
		OcclusionPortal occlusionPortal = gameObject.GetComponent<OcclusionPortal>();
		if (occlusionPortal == null)
		{
			occlusionPortal = gameObject.AddComponent<OcclusionPortal>();
		}
		occlusionPortal.open = component.Open;
	}

	// Token: 0x06000F35 RID: 3893 RVA: 0x0006632C File Offset: 0x0006472C
	public OcclusionPortalSerializer(GameObject gameObject)
	{
		OcclusionPortal component = gameObject.GetComponent<OcclusionPortal>();
		this.Open = component.open;
	}

	// Token: 0x06000F36 RID: 3894 RVA: 0x00066352 File Offset: 0x00064752
	private OcclusionPortalSerializer()
	{
	}

	// Token: 0x17000290 RID: 656
	// (get) Token: 0x06000F37 RID: 3895 RVA: 0x0006635A File Offset: 0x0006475A
	// (set) Token: 0x06000F38 RID: 3896 RVA: 0x00066362 File Offset: 0x00064762
	[ProtoMember(1)]
	public bool Open { get; set; }
}
