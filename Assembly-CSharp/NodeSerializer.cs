using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E3 RID: 483
[ProtoContract]
public sealed class NodeSerializer
{
	// Token: 0x06000BBA RID: 3002 RVA: 0x0005FB48 File Offset: 0x0005DF48
	public NodeSerializer(GameObject gameObject)
	{
		NodeProperties component = gameObject.GetComponent<NodeProperties>();
		this.togglevisible = component.togglevisible;
		this.nodename = component.nodename;
		this.showwaypoint = component.showwaypoint;
		this.waypointname = component.waypointname;
	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x0005FB94 File Offset: 0x0005DF94
	public NodeSerializer(GameObject gameObject, NodeSerializer component)
	{
		NodeProperties nodeProperties = gameObject.GetComponent<NodeProperties>();
		if (nodeProperties == null)
		{
			nodeProperties = gameObject.AddComponent<NodeProperties>();
		}
		nodeProperties.togglevisible = component.togglevisible;
		nodeProperties.nodename = component.nodename;
		nodeProperties.showwaypoint = component.showwaypoint;
		nodeProperties.waypointname = component.waypointname;
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x0005FBF1 File Offset: 0x0005DFF1
	public NodeSerializer()
	{
	}

	// Token: 0x04000D61 RID: 3425
	[ProtoMember(1)]
	public bool togglevisible;

	// Token: 0x04000D62 RID: 3426
	[ProtoMember(2)]
	public string nodename;

	// Token: 0x04000D63 RID: 3427
	[ProtoMember(3)]
	public bool showwaypoint;

	// Token: 0x04000D64 RID: 3428
	[ProtoMember(4)]
	public string waypointname;
}
