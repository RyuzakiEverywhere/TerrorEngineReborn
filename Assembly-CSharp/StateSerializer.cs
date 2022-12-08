using System;
using System.Collections.Generic;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E9 RID: 489
[ProtoContract]
public sealed class StateSerializer
{
	// Token: 0x06000BCC RID: 3020 RVA: 0x000609D0 File Offset: 0x0005EDD0
	public StateSerializer(GameObject gameObject, StateSerializer component)
	{
		State component2 = gameObject.GetComponent<State>();
		if (component2 != null)
		{
			component2.IsSpawnedAtRuntime = component.IsSpawnedAtRuntime;
			component2.List = component.List;
			component2.UniqueName = component.UniqueName;
		}
		else
		{
			State state = gameObject.AddComponent<State>();
			state.IsSpawnedAtRuntime = component.IsSpawnedAtRuntime;
			state.List = component.List;
			state.UniqueName = component.UniqueName;
		}
	}

	// Token: 0x06000BCD RID: 3021 RVA: 0x00060A58 File Offset: 0x0005EE58
	public StateSerializer(GameObject gameObject)
	{
		State component = gameObject.GetComponent<State>();
		this.IsSpawnedAtRuntime = component.IsSpawnedAtRuntime;
		this.List = component.List;
		this.UniqueName = component.UniqueName;
	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x00060AA1 File Offset: 0x0005EEA1
	private StateSerializer()
	{
	}

	// Token: 0x04000DE7 RID: 3559
	[ProtoMember(1)]
	public bool IsSpawnedAtRuntime;

	// Token: 0x04000DE8 RID: 3560
	[ProtoMember(2)]
	public List<int> List = new List<int>();

	// Token: 0x04000DE9 RID: 3561
	[ProtoMember(3)]
	public string UniqueName;
}
