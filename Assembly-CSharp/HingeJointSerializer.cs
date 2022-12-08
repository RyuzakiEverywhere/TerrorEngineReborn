using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000203 RID: 515
[ProtoContract]
public sealed class HingeJointSerializer
{
	// Token: 0x06000DBE RID: 3518 RVA: 0x000641B0 File Offset: 0x000625B0
	public HingeJointSerializer(GameObject gameObject, HingeJointSerializer component)
	{
		HingeJoint hingeJoint = gameObject.GetComponent<HingeJoint>();
		if (hingeJoint == null)
		{
			hingeJoint = gameObject.AddComponent<HingeJoint>();
		}
		if (!string.IsNullOrEmpty(component.ConnectedBodyName))
		{
			Rigidbody[] array = UnityEngine.Object.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
			if (array != null)
			{
				hingeJoint.connectedBody = array.FirstOrDefault((Rigidbody rigidBody) => rigidBody.name == component.ConnectedBodyName);
			}
		}
		hingeJoint.axis = (Vector3)component.Axis;
		hingeJoint.anchor = (Vector3)component.Anchor;
		hingeJoint.breakForce = component.BreakForce;
		hingeJoint.breakTorque = component.BreakTorque;
		hingeJoint.motor = (JointMotor)component.Motor;
		hingeJoint.limits = (JointLimits)component.Limits;
		hingeJoint.spring = (JointSpring)component.Spring;
		hingeJoint.useMotor = component.UseMotor;
		hingeJoint.useLimits = component.UseLimits;
		hingeJoint.useSpring = component.UseSpring;
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x000642F8 File Offset: 0x000626F8
	public HingeJointSerializer(GameObject gameObject)
	{
		HingeJoint component = gameObject.GetComponent<HingeJoint>();
		if (component.connectedBody != null)
		{
			this.ConnectedBodyName = component.connectedBody.name;
		}
		this.Axis = (Vector3Serializer)component.axis;
		this.Anchor = (Vector3Serializer)component.anchor;
		this.BreakForce = component.breakForce;
		this.BreakTorque = component.breakTorque;
		this.Motor = (JointMotorSerializer)component.motor;
		this.Limits = (JointLimitsSerializer)component.limits;
		this.Spring = (JointSpringSerializer)component.spring;
		this.UseMotor = component.useMotor;
		this.UseLimits = component.useLimits;
		this.UseSpring = component.useSpring;
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x000643C5 File Offset: 0x000627C5
	private HingeJointSerializer()
	{
	}

	// Token: 0x170001F1 RID: 497
	// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x000643CD File Offset: 0x000627CD
	// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x000643D5 File Offset: 0x000627D5
	[ProtoMember(1)]
	public string ConnectedBodyName { get; set; }

	// Token: 0x170001F2 RID: 498
	// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x000643DE File Offset: 0x000627DE
	// (set) Token: 0x06000DC4 RID: 3524 RVA: 0x000643E6 File Offset: 0x000627E6
	[ProtoMember(2)]
	public Vector3Serializer Axis { get; set; }

	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x000643EF File Offset: 0x000627EF
	// (set) Token: 0x06000DC6 RID: 3526 RVA: 0x000643F7 File Offset: 0x000627F7
	[ProtoMember(3)]
	public Vector3Serializer Anchor { get; set; }

	// Token: 0x170001F4 RID: 500
	// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00064400 File Offset: 0x00062800
	// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x00064408 File Offset: 0x00062808
	[ProtoMember(4)]
	public float BreakForce { get; set; }

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x00064411 File Offset: 0x00062811
	// (set) Token: 0x06000DCA RID: 3530 RVA: 0x00064419 File Offset: 0x00062819
	[ProtoMember(5)]
	public float BreakTorque { get; set; }

	// Token: 0x170001F6 RID: 502
	// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00064422 File Offset: 0x00062822
	// (set) Token: 0x06000DCC RID: 3532 RVA: 0x0006442A File Offset: 0x0006282A
	[ProtoMember(6)]
	public JointMotorSerializer Motor { get; set; }

	// Token: 0x170001F7 RID: 503
	// (get) Token: 0x06000DCD RID: 3533 RVA: 0x00064433 File Offset: 0x00062833
	// (set) Token: 0x06000DCE RID: 3534 RVA: 0x0006443B File Offset: 0x0006283B
	[ProtoMember(7)]
	public JointLimitsSerializer Limits { get; set; }

	// Token: 0x170001F8 RID: 504
	// (get) Token: 0x06000DCF RID: 3535 RVA: 0x00064444 File Offset: 0x00062844
	// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x0006444C File Offset: 0x0006284C
	[ProtoMember(8)]
	public JointSpringSerializer Spring { get; set; }

	// Token: 0x170001F9 RID: 505
	// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00064455 File Offset: 0x00062855
	// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x0006445D File Offset: 0x0006285D
	[ProtoMember(9)]
	public bool UseMotor { get; set; }

	// Token: 0x170001FA RID: 506
	// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x00064466 File Offset: 0x00062866
	// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x0006446E File Offset: 0x0006286E
	[ProtoMember(10)]
	public bool UseLimits { get; set; }

	// Token: 0x170001FB RID: 507
	// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00064477 File Offset: 0x00062877
	// (set) Token: 0x06000DD6 RID: 3542 RVA: 0x0006447F File Offset: 0x0006287F
	[ProtoMember(11)]
	public bool UseSpring { get; set; }
}
