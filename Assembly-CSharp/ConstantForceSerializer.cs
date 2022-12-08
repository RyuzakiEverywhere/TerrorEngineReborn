using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000201 RID: 513
[ProtoContract]
public sealed class ConstantForceSerializer
{
	// Token: 0x06000DA4 RID: 3492 RVA: 0x00063EA4 File Offset: 0x000622A4
	public ConstantForceSerializer(GameObject gameObject, ConstantForceSerializer component)
	{
		ConstantForce constantForce = gameObject.GetComponent<ConstantForce>();
		if (constantForce == null)
		{
			constantForce = gameObject.AddComponent<ConstantForce>();
		}
		constantForce.enabled = component.Enabled;
		constantForce.force = (Vector3)component.Force;
		constantForce.relativeForce = (Vector3)component.RelativeForce;
		constantForce.torque = (Vector3)component.Torque;
		constantForce.relativeTorque = (Vector3)component.RelativeTorque;
	}

	// Token: 0x06000DA5 RID: 3493 RVA: 0x00063F24 File Offset: 0x00062324
	public ConstantForceSerializer(GameObject gameObject)
	{
		ConstantForce component = gameObject.GetComponent<ConstantForce>();
		this.Enabled = component.enabled;
		this.Force = (Vector3Serializer)component.force;
		this.RelativeForce = (Vector3Serializer)component.relativeForce;
		this.Torque = (Vector3Serializer)component.torque;
		this.RelativeTorque = (Vector3Serializer)component.relativeTorque;
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x00063F8E File Offset: 0x0006238E
	private ConstantForceSerializer()
	{
	}

	// Token: 0x170001E7 RID: 487
	// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x00063F96 File Offset: 0x00062396
	// (set) Token: 0x06000DA8 RID: 3496 RVA: 0x00063F9E File Offset: 0x0006239E
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x170001E8 RID: 488
	// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x00063FA7 File Offset: 0x000623A7
	// (set) Token: 0x06000DAA RID: 3498 RVA: 0x00063FAF File Offset: 0x000623AF
	[ProtoMember(2)]
	public Vector3Serializer Force { get; set; }

	// Token: 0x170001E9 RID: 489
	// (get) Token: 0x06000DAB RID: 3499 RVA: 0x00063FB8 File Offset: 0x000623B8
	// (set) Token: 0x06000DAC RID: 3500 RVA: 0x00063FC0 File Offset: 0x000623C0
	[ProtoMember(3)]
	public Vector3Serializer RelativeForce { get; set; }

	// Token: 0x170001EA RID: 490
	// (get) Token: 0x06000DAD RID: 3501 RVA: 0x00063FC9 File Offset: 0x000623C9
	// (set) Token: 0x06000DAE RID: 3502 RVA: 0x00063FD1 File Offset: 0x000623D1
	[ProtoMember(4)]
	public Vector3Serializer Torque { get; set; }

	// Token: 0x170001EB RID: 491
	// (get) Token: 0x06000DAF RID: 3503 RVA: 0x00063FDA File Offset: 0x000623DA
	// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x00063FE2 File Offset: 0x000623E2
	[ProtoMember(5)]
	public Vector3Serializer RelativeTorque { get; set; }
}
