using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001ED RID: 493
[ProtoContract]
public sealed class WallSerializer
{
	// Token: 0x06000BD8 RID: 3032 RVA: 0x000611B0 File Offset: 0x0005F5B0
	public WallSerializer(GameObject gameObject)
	{
		WallProperties component = gameObject.GetComponent<WallProperties>();
		this.iswall = component.iswall;
		this.isdoor = component.isdoor;
		this.iswindow = component.iswindow;
		this.hasct = component.hasct;
		this.ctpath = component.ctpath;
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x00061208 File Offset: 0x0005F608
	public WallSerializer(GameObject gameObject, WallSerializer component)
	{
		WallProperties wallProperties = gameObject.GetComponent<WallProperties>();
		if (wallProperties == null)
		{
			wallProperties = gameObject.AddComponent<WallProperties>();
		}
		wallProperties.iswall = component.iswall;
		wallProperties.isdoor = component.isdoor;
		wallProperties.iswindow = component.iswindow;
		wallProperties.hasct = component.hasct;
		wallProperties.ctpath = component.ctpath;
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x00061271 File Offset: 0x0005F671
	public WallSerializer()
	{
	}

	// Token: 0x04000E2A RID: 3626
	[ProtoMember(1)]
	public bool iswall;

	// Token: 0x04000E2B RID: 3627
	[ProtoMember(2)]
	public bool isdoor;

	// Token: 0x04000E2C RID: 3628
	[ProtoMember(3)]
	public bool iswindow;

	// Token: 0x04000E2D RID: 3629
	[ProtoMember(4)]
	public bool hasct;

	// Token: 0x04000E2E RID: 3630
	[ProtoMember(5)]
	public string ctpath;
}
