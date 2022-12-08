using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200020E RID: 526
[ProtoContract]
public class GUILayerSerializer
{
	// Token: 0x06000ED7 RID: 3799 RVA: 0x00065944 File Offset: 0x00063D44
	public GUILayerSerializer(GameObject gameObject, GUILayerSerializer component)
	{
		GUILayer guilayer = gameObject.GetComponent<GUILayer>();
		if (guilayer == null)
		{
			guilayer = gameObject.AddComponent<GUILayer>();
		}
		guilayer.enabled = component.Enabled;
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x00065980 File Offset: 0x00063D80
	public GUILayerSerializer(GameObject gameObject)
	{
		GUILayer component = gameObject.GetComponent<GUILayer>();
		this.Enabled = component.enabled;
	}

	// Token: 0x06000ED9 RID: 3801 RVA: 0x000659A6 File Offset: 0x00063DA6
	private GUILayerSerializer()
	{
	}

	// Token: 0x1700026D RID: 621
	// (get) Token: 0x06000EDA RID: 3802 RVA: 0x000659AE File Offset: 0x00063DAE
	// (set) Token: 0x06000EDB RID: 3803 RVA: 0x000659B6 File Offset: 0x00063DB6
	[ProtoMember(1)]
	public bool Enabled { get; set; }
}
