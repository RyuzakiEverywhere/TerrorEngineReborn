using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001CC RID: 460
[ProtoContract]
public sealed class ANpcGridSerializer
{
	// Token: 0x06000B71 RID: 2929 RVA: 0x0005E7D4 File Offset: 0x0005CBD4
	public ANpcGridSerializer(GameObject gameObject)
	{
		PathGridComponent component = gameObject.GetComponent<PathGridComponent>();
		this.m_numberOfRows = component.m_numberOfRows;
		this.m_numberOfColumns = component.m_numberOfColumns;
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x0005E808 File Offset: 0x0005CC08
	public ANpcGridSerializer(GameObject gameObject, ANpcGridSerializer component)
	{
		PathGridComponent pathGridComponent = gameObject.GetComponent<PathGridComponent>();
		if (pathGridComponent == null)
		{
			pathGridComponent = gameObject.AddComponent<PathGridComponent>();
		}
		pathGridComponent.m_numberOfRows = component.m_numberOfRows;
		pathGridComponent.m_numberOfColumns = component.m_numberOfColumns;
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x0005E84D File Offset: 0x0005CC4D
	public ANpcGridSerializer()
	{
	}

	// Token: 0x04000CE3 RID: 3299
	[ProtoMember(1)]
	public int m_numberOfRows;

	// Token: 0x04000CE4 RID: 3300
	[ProtoMember(2)]
	public int m_numberOfColumns;
}
