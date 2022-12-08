using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D0 RID: 464
[ProtoContract]
public sealed class CinematicSerializer
{
	// Token: 0x06000B7D RID: 2941 RVA: 0x0005EB34 File Offset: 0x0005CF34
	public CinematicSerializer(GameObject gameObject)
	{
		CinematicProperties component = gameObject.GetComponent<CinematicProperties>();
		this.xpos = component.xpos;
		this.ypos = component.ypos;
		this.zpos = component.zpos;
		this.type = component.type;
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x0005EB80 File Offset: 0x0005CF80
	public CinematicSerializer(GameObject gameObject, CinematicSerializer component)
	{
		CinematicProperties cinematicProperties = gameObject.GetComponent<CinematicProperties>();
		if (cinematicProperties == null)
		{
			cinematicProperties = gameObject.AddComponent<CinematicProperties>();
		}
		cinematicProperties.xpos = component.xpos;
		cinematicProperties.ypos = component.ypos;
		cinematicProperties.zpos = component.zpos;
		cinematicProperties.type = component.type;
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x0005EBDD File Offset: 0x0005CFDD
	public CinematicSerializer()
	{
	}

	// Token: 0x04000CF9 RID: 3321
	[ProtoMember(1)]
	public string xpos;

	// Token: 0x04000CFA RID: 3322
	[ProtoMember(2)]
	public string ypos;

	// Token: 0x04000CFB RID: 3323
	[ProtoMember(3)]
	public string zpos;

	// Token: 0x04000CFC RID: 3324
	[ProtoMember(4)]
	public int type;
}
