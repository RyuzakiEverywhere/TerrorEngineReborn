using System;
using System.Reflection;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200020D RID: 525
[ProtoContract]
public class FlareLayerSerializer
{
	// Token: 0x06000ED2 RID: 3794 RVA: 0x00065890 File Offset: 0x00063C90
	public FlareLayerSerializer(GameObject gameObject, FlareLayerSerializer component)
	{
		Component component2 = gameObject.GetComponent("FlareLayer");
		if (component2 == null)
		{
			component2 = gameObject.AddComponent<FlareLayer>();
		}
		PropertyInfo property = component2.GetType().GetProperty("Enabled");
		property.SetValue(component2, component.Enabled, null);
	}

	// Token: 0x06000ED3 RID: 3795 RVA: 0x000658E8 File Offset: 0x00063CE8
	public FlareLayerSerializer(GameObject gameObject)
	{
		Component component = gameObject.GetComponent("FlareLayer");
		PropertyInfo property = component.GetType().GetProperty("Enabled");
		this.Enabled = (bool)property.GetValue(component, null);
	}

	// Token: 0x06000ED4 RID: 3796 RVA: 0x0006592B File Offset: 0x00063D2B
	private FlareLayerSerializer()
	{
	}

	// Token: 0x1700026C RID: 620
	// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x00065933 File Offset: 0x00063D33
	// (set) Token: 0x06000ED6 RID: 3798 RVA: 0x0006593B File Offset: 0x00063D3B
	[ProtoMember(1)]
	public bool Enabled { get; set; }
}
