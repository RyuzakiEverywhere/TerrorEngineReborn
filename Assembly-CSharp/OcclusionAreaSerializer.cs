using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000214 RID: 532
[ProtoContract]
public sealed class OcclusionAreaSerializer
{
	// Token: 0x06000F2D RID: 3885 RVA: 0x00066238 File Offset: 0x00064638
	public OcclusionAreaSerializer(GameObject gameObject, OcclusionAreaSerializer component)
	{
		OcclusionArea occlusionArea = gameObject.GetComponent<OcclusionArea>();
		if (occlusionArea == null)
		{
			occlusionArea = gameObject.AddComponent<OcclusionArea>();
		}
		occlusionArea.center = (Vector3)component.Center;
		occlusionArea.size = (Vector3)component.Size;
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x00066288 File Offset: 0x00064688
	public OcclusionAreaSerializer(GameObject gameObject)
	{
		OcclusionArea component = gameObject.GetComponent<OcclusionArea>();
		this.Center = (Vector3Serializer)component.center;
		this.Size = (Vector3Serializer)component.size;
	}

	// Token: 0x06000F2F RID: 3887 RVA: 0x000662C4 File Offset: 0x000646C4
	private OcclusionAreaSerializer()
	{
	}

	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06000F30 RID: 3888 RVA: 0x000662CC File Offset: 0x000646CC
	// (set) Token: 0x06000F31 RID: 3889 RVA: 0x000662D4 File Offset: 0x000646D4
	[ProtoMember(1)]
	public Vector3Serializer Center { get; set; }

	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06000F32 RID: 3890 RVA: 0x000662DD File Offset: 0x000646DD
	// (set) Token: 0x06000F33 RID: 3891 RVA: 0x000662E5 File Offset: 0x000646E5
	[ProtoMember(2)]
	public Vector3Serializer Size { get; set; }
}
