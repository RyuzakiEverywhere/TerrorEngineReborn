using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200020B RID: 523
[ProtoContract]
public sealed class WheelColliderSerializer
{
	// Token: 0x06000E82 RID: 3714 RVA: 0x00065174 File Offset: 0x00063574
	public WheelColliderSerializer(GameObject gameObject, WheelColliderSerializer component)
	{
		WheelCollider wheelCollider = gameObject.GetComponent<WheelCollider>();
		if (wheelCollider == null)
		{
			wheelCollider = gameObject.AddComponent<WheelCollider>();
		}
		wheelCollider.enabled = component.Enabled;
		wheelCollider.isTrigger = component.IsTrigger;
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			wheelCollider.material = (PhysicMaterial)UniSave.TryLoadResource(component.MaterialName);
		}
		wheelCollider.center = (Vector3)component.Center;
		wheelCollider.radius = component.Radius;
		wheelCollider.suspensionDistance = component.SuspensionDistance;
		wheelCollider.suspensionSpring = (JointSpring)component.SuspensionSpring;
		wheelCollider.mass = component.Mass;
		wheelCollider.forwardFriction = (WheelFrictionCurve)component.ForwardFriction;
		wheelCollider.sidewaysFriction = (WheelFrictionCurve)component.SidewaysFriction;
		wheelCollider.motorTorque = component.MotorTorque;
		wheelCollider.brakeTorque = component.BrakeTorque;
		wheelCollider.steerAngle = component.SteerAngle;
	}

	// Token: 0x06000E83 RID: 3715 RVA: 0x0006526C File Offset: 0x0006366C
	public WheelColliderSerializer(GameObject gameObject)
	{
		WheelCollider component = gameObject.GetComponent<WheelCollider>();
		this.Enabled = component.enabled;
		this.IsTrigger = component.isTrigger;
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
		this.Center = (Vector3Serializer)component.center;
		this.Radius = component.radius;
		this.SuspensionDistance = component.suspensionDistance;
		this.SuspensionSpring = (JointSpringSerializer)component.suspensionSpring;
		this.Mass = component.mass;
		this.ForwardFriction = (WheelFrictionCurveSerializer)component.forwardFriction;
		this.SidewaysFriction = (WheelFrictionCurveSerializer)component.sidewaysFriction;
		this.MotorTorque = component.motorTorque;
		this.BrakeTorque = component.brakeTorque;
		this.SteerAngle = component.steerAngle;
	}

	// Token: 0x06000E84 RID: 3716 RVA: 0x0006534C File Offset: 0x0006374C
	private WheelColliderSerializer()
	{
	}

	// Token: 0x17000247 RID: 583
	// (get) Token: 0x06000E85 RID: 3717 RVA: 0x00065354 File Offset: 0x00063754
	// (set) Token: 0x06000E86 RID: 3718 RVA: 0x0006535C File Offset: 0x0006375C
	[ProtoMember(1)]
	public bool Enabled { get; set; }

	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06000E87 RID: 3719 RVA: 0x00065365 File Offset: 0x00063765
	// (set) Token: 0x06000E88 RID: 3720 RVA: 0x0006536D File Offset: 0x0006376D
	[ProtoMember(2)]
	public bool IsTrigger { get; set; }

	// Token: 0x17000249 RID: 585
	// (get) Token: 0x06000E89 RID: 3721 RVA: 0x00065376 File Offset: 0x00063776
	// (set) Token: 0x06000E8A RID: 3722 RVA: 0x0006537E File Offset: 0x0006377E
	[ProtoMember(3)]
	public string MaterialName { get; set; }

	// Token: 0x1700024A RID: 586
	// (get) Token: 0x06000E8B RID: 3723 RVA: 0x00065387 File Offset: 0x00063787
	// (set) Token: 0x06000E8C RID: 3724 RVA: 0x0006538F File Offset: 0x0006378F
	[ProtoMember(4)]
	public Vector3Serializer Center { get; set; }

	// Token: 0x1700024B RID: 587
	// (get) Token: 0x06000E8D RID: 3725 RVA: 0x00065398 File Offset: 0x00063798
	// (set) Token: 0x06000E8E RID: 3726 RVA: 0x000653A0 File Offset: 0x000637A0
	[ProtoMember(5)]
	public float Radius { get; set; }

	// Token: 0x1700024C RID: 588
	// (get) Token: 0x06000E8F RID: 3727 RVA: 0x000653A9 File Offset: 0x000637A9
	// (set) Token: 0x06000E90 RID: 3728 RVA: 0x000653B1 File Offset: 0x000637B1
	[ProtoMember(6)]
	public float SuspensionDistance { get; set; }

	// Token: 0x1700024D RID: 589
	// (get) Token: 0x06000E91 RID: 3729 RVA: 0x000653BA File Offset: 0x000637BA
	// (set) Token: 0x06000E92 RID: 3730 RVA: 0x000653C2 File Offset: 0x000637C2
	[ProtoMember(7)]
	public JointSpringSerializer SuspensionSpring { get; set; }

	// Token: 0x1700024E RID: 590
	// (get) Token: 0x06000E93 RID: 3731 RVA: 0x000653CB File Offset: 0x000637CB
	// (set) Token: 0x06000E94 RID: 3732 RVA: 0x000653D3 File Offset: 0x000637D3
	[ProtoMember(8)]
	public float Mass { get; set; }

	// Token: 0x1700024F RID: 591
	// (get) Token: 0x06000E95 RID: 3733 RVA: 0x000653DC File Offset: 0x000637DC
	// (set) Token: 0x06000E96 RID: 3734 RVA: 0x000653E4 File Offset: 0x000637E4
	[ProtoMember(9)]
	public WheelFrictionCurveSerializer ForwardFriction { get; set; }

	// Token: 0x17000250 RID: 592
	// (get) Token: 0x06000E97 RID: 3735 RVA: 0x000653ED File Offset: 0x000637ED
	// (set) Token: 0x06000E98 RID: 3736 RVA: 0x000653F5 File Offset: 0x000637F5
	[ProtoMember(10)]
	public WheelFrictionCurveSerializer SidewaysFriction { get; set; }

	// Token: 0x17000251 RID: 593
	// (get) Token: 0x06000E99 RID: 3737 RVA: 0x000653FE File Offset: 0x000637FE
	// (set) Token: 0x06000E9A RID: 3738 RVA: 0x00065406 File Offset: 0x00063806
	[ProtoMember(11)]
	public float MotorTorque { get; set; }

	// Token: 0x17000252 RID: 594
	// (get) Token: 0x06000E9B RID: 3739 RVA: 0x0006540F File Offset: 0x0006380F
	// (set) Token: 0x06000E9C RID: 3740 RVA: 0x00065417 File Offset: 0x00063817
	[ProtoMember(12)]
	public float BrakeTorque { get; set; }

	// Token: 0x17000253 RID: 595
	// (get) Token: 0x06000E9D RID: 3741 RVA: 0x00065420 File Offset: 0x00063820
	// (set) Token: 0x06000E9E RID: 3742 RVA: 0x00065428 File Offset: 0x00063828
	[ProtoMember(13)]
	public float SteerAngle { get; set; }
}
