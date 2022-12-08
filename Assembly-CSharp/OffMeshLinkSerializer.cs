using System;
using ProtoBuf;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020001FA RID: 506
[ProtoContract]
public sealed class OffMeshLinkSerializer
{
	// Token: 0x06000CF5 RID: 3317 RVA: 0x00062DEC File Offset: 0x000611EC
	public OffMeshLinkSerializer(GameObject gameObject, OffMeshLinkSerializer component)
	{
		OffMeshLink offMeshLink = gameObject.GetComponent<OffMeshLink>();
		if (offMeshLink == null)
		{
			offMeshLink = gameObject.AddComponent<OffMeshLink>();
		}
		offMeshLink.activated = component.Activated;
		offMeshLink.costOverride = component.CostOverride;
	}

	// Token: 0x06000CF6 RID: 3318 RVA: 0x00062E34 File Offset: 0x00061234
	public OffMeshLinkSerializer(GameObject gameObject)
	{
		OffMeshLink component = gameObject.GetComponent<OffMeshLink>();
		this.Activated = component.activated;
		this.CostOverride = component.costOverride;
	}

	// Token: 0x06000CF7 RID: 3319 RVA: 0x00062E66 File Offset: 0x00061266
	private OffMeshLinkSerializer()
	{
	}

	// Token: 0x1700019A RID: 410
	// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x00062E6E File Offset: 0x0006126E
	// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x00062E76 File Offset: 0x00061276
	[ProtoMember(1)]
	public bool Activated { get; set; }

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x06000CFA RID: 3322 RVA: 0x00062E7F File Offset: 0x0006127F
	// (set) Token: 0x06000CFB RID: 3323 RVA: 0x00062E87 File Offset: 0x00061287
	[ProtoMember(2)]
	public float CostOverride { get; set; }
}
