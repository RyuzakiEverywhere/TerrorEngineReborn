using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000212 RID: 530
[ProtoContract]
public sealed class LightProbeGroupSerializer
{
	// Token: 0x06000F03 RID: 3843 RVA: 0x00065DDC File Offset: 0x000641DC
	public LightProbeGroupSerializer(GameObject gameObject, LightProbeGroupSerializer component)
	{
		LightProbeGroup lightProbeGroup = gameObject.GetComponent<LightProbeGroup>();
		if (lightProbeGroup == null)
		{
			lightProbeGroup = gameObject.AddComponent<LightProbeGroup>();
		}
		if (component.ProbePositions != null)
		{
			lightProbeGroup.probePositions = Array.ConvertAll<Vector3Serializer, Vector3>(component.ProbePositions, (Vector3Serializer element) => (Vector3)element);
		}
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x00065E44 File Offset: 0x00064244
	public LightProbeGroupSerializer(GameObject gameObject)
	{
		LightProbeGroup component = gameObject.GetComponent<LightProbeGroup>();
		if (component.probePositions != null)
		{
			this.ProbePositions = Array.ConvertAll<Vector3, Vector3Serializer>(component.probePositions, (Vector3 element) => (Vector3Serializer)element);
		}
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x00065E97 File Offset: 0x00064297
	private LightProbeGroupSerializer()
	{
	}

	// Token: 0x1700027D RID: 637
	// (get) Token: 0x06000F06 RID: 3846 RVA: 0x00065E9F File Offset: 0x0006429F
	// (set) Token: 0x06000F07 RID: 3847 RVA: 0x00065EA7 File Offset: 0x000642A7
	[ProtoMember(1)]
	public Vector3Serializer[] ProbePositions { get; set; }
}
