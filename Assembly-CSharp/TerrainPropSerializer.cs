using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001EA RID: 490
[ProtoContract]
public sealed class TerrainPropSerializer
{
	// Token: 0x06000BCF RID: 3023 RVA: 0x00060AB4 File Offset: 0x0005EEB4
	public TerrainPropSerializer(GameObject gameObject)
	{
		TerrainProperties component = gameObject.GetComponent<TerrainProperties>();
		this.grassland1 = component.grassland1;
		this.grassland2 = component.grassland2;
		this.grassland3 = component.grassland3;
		this.snowland1 = component.snowland1;
		this.snowland2 = component.snowland2;
		this.snowland3 = component.snowland3;
		this.canyonland1 = component.canyonland1;
		this.canyonland2 = component.canyonland2;
		this.canyonland3 = component.canyonland3;
		this.waterwater = component.waterwater;
	}

	// Token: 0x06000BD0 RID: 3024 RVA: 0x00060B48 File Offset: 0x0005EF48
	public TerrainPropSerializer(GameObject gameObject, TerrainPropSerializer component)
	{
		TerrainProperties terrainProperties = gameObject.GetComponent<TerrainProperties>();
		if (terrainProperties == null)
		{
			terrainProperties = gameObject.AddComponent<TerrainProperties>();
		}
		terrainProperties.grassland1 = component.grassland1;
		terrainProperties.grassland2 = component.grassland2;
		terrainProperties.grassland3 = component.grassland3;
		terrainProperties.snowland1 = component.snowland1;
		terrainProperties.snowland2 = component.snowland2;
		terrainProperties.snowland3 = component.snowland3;
		terrainProperties.canyonland1 = component.canyonland1;
		terrainProperties.canyonland2 = component.canyonland2;
		terrainProperties.canyonland3 = component.canyonland3;
		terrainProperties.waterwater = component.waterwater;
	}

	// Token: 0x06000BD1 RID: 3025 RVA: 0x00060BED File Offset: 0x0005EFED
	public TerrainPropSerializer()
	{
	}

	// Token: 0x04000DEA RID: 3562
	[ProtoMember(1)]
	public bool grassland1;

	// Token: 0x04000DEB RID: 3563
	[ProtoMember(2)]
	public bool grassland2;

	// Token: 0x04000DEC RID: 3564
	[ProtoMember(3)]
	public bool grassland3;

	// Token: 0x04000DED RID: 3565
	[ProtoMember(4)]
	public bool snowland1;

	// Token: 0x04000DEE RID: 3566
	[ProtoMember(5)]
	public bool snowland2;

	// Token: 0x04000DEF RID: 3567
	[ProtoMember(6)]
	public bool snowland3;

	// Token: 0x04000DF0 RID: 3568
	[ProtoMember(7)]
	public bool canyonland1;

	// Token: 0x04000DF1 RID: 3569
	[ProtoMember(8)]
	public bool canyonland2;

	// Token: 0x04000DF2 RID: 3570
	[ProtoMember(9)]
	public bool canyonland3;

	// Token: 0x04000DF3 RID: 3571
	[ProtoMember(10)]
	public bool waterwater;
}
