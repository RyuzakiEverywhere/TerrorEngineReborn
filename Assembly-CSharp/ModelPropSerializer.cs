using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001DE RID: 478
[ProtoContract]
public sealed class ModelPropSerializer
{
	// Token: 0x06000BAB RID: 2987 RVA: 0x0005F41C File Offset: 0x0005D81C
	public ModelPropSerializer(GameObject gameObject)
	{
		ModelProperties component = gameObject.GetComponent<ModelProperties>();
		this.togglevisible = component.togglevisible;
		this.rigidbody = component.rigidbody;
		this.canpickup = component.canpickup;
		this.collect = component.collect;
		this.none = component.none;
		this.moveforward = component.moveforward;
		this.movebackward = component.movebackward;
		this.moveup = component.moveup;
		this.movedown = component.movedown;
		this.backandforth = component.backandforth;
		this.movementspeed = component.movementspeed;
		this.deathoncollide = component.deathoncollide;
		this.triggerdeactivate = component.triggerdeactivate;
		this.triggerid = component.triggerid;
		this.examine = component.examine;
		this.examinetext = component.examinetext;
		this.notmodel = component.notmodel;
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x0005F504 File Offset: 0x0005D904
	public ModelPropSerializer(GameObject gameObject, ModelPropSerializer component)
	{
		ModelProperties modelProperties = gameObject.GetComponent<ModelProperties>();
		if (modelProperties == null)
		{
			modelProperties = gameObject.AddComponent<ModelProperties>();
		}
		modelProperties.togglevisible = component.togglevisible;
		modelProperties.rigidbody = component.rigidbody;
		modelProperties.canpickup = component.canpickup;
		modelProperties.collect = component.collect;
		modelProperties.none = component.none;
		modelProperties.moveforward = component.moveforward;
		modelProperties.movebackward = component.movebackward;
		modelProperties.moveup = component.moveup;
		modelProperties.movedown = component.movedown;
		modelProperties.backandforth = component.backandforth;
		modelProperties.movementspeed = component.movementspeed;
		modelProperties.deathoncollide = component.deathoncollide;
		modelProperties.triggerdeactivate = component.triggerdeactivate;
		modelProperties.triggerid = component.triggerid;
		modelProperties.examine = component.examine;
		modelProperties.examinetext = component.examinetext;
		modelProperties.notmodel = component.notmodel;
	}

	// Token: 0x06000BAD RID: 2989 RVA: 0x0005F5FD File Offset: 0x0005D9FD
	public ModelPropSerializer()
	{
	}

	// Token: 0x04000D27 RID: 3367
	[ProtoMember(1)]
	public bool togglevisible;

	// Token: 0x04000D28 RID: 3368
	[ProtoMember(2)]
	public bool rigidbody;

	// Token: 0x04000D29 RID: 3369
	[ProtoMember(3)]
	public bool canpickup;

	// Token: 0x04000D2A RID: 3370
	[ProtoMember(4)]
	public bool collect;

	// Token: 0x04000D2B RID: 3371
	[ProtoMember(5)]
	public bool none;

	// Token: 0x04000D2C RID: 3372
	[ProtoMember(6)]
	public bool moveforward;

	// Token: 0x04000D2D RID: 3373
	[ProtoMember(7)]
	public bool movebackward;

	// Token: 0x04000D2E RID: 3374
	[ProtoMember(8)]
	public bool moveup;

	// Token: 0x04000D2F RID: 3375
	[ProtoMember(9)]
	public bool movedown;

	// Token: 0x04000D30 RID: 3376
	[ProtoMember(10)]
	public bool backandforth;

	// Token: 0x04000D31 RID: 3377
	[ProtoMember(11)]
	public string movementspeed;

	// Token: 0x04000D32 RID: 3378
	[ProtoMember(12)]
	public bool deathoncollide;

	// Token: 0x04000D33 RID: 3379
	[ProtoMember(13)]
	public bool triggerdeactivate;

	// Token: 0x04000D34 RID: 3380
	[ProtoMember(14)]
	public string triggerid;

	// Token: 0x04000D35 RID: 3381
	[ProtoMember(15)]
	public bool examine;

	// Token: 0x04000D36 RID: 3382
	[ProtoMember(16)]
	public string examinetext;

	// Token: 0x04000D37 RID: 3383
	[ProtoMember(17)]
	public bool notmodel;
}
