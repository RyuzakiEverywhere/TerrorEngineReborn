using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000206 RID: 518
[ProtoContract]
public sealed class RigidbodySerializer
{
	// Token: 0x06000E0B RID: 3595 RVA: 0x000647B0 File Offset: 0x00062BB0
	public RigidbodySerializer(GameObject gameObject, RigidbodySerializer component)
	{
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = gameObject.AddComponent<Rigidbody>();
		}
		rigidbody.velocity = (Vector3)component.Velocity;
		rigidbody.angularVelocity = (Vector3)component.AngularVelocity;
		rigidbody.drag = component.Drag;
		rigidbody.angularDrag = component.AngularDrag;
		rigidbody.mass = component.Mass;
		rigidbody.useGravity = component.UseGravity;
		rigidbody.isKinematic = component.IsKinematic;
		rigidbody.freezeRotation = component.FreezeRotation;
		rigidbody.constraints = (RigidbodyConstraints)component.Constraints;
		rigidbody.collisionDetectionMode = (CollisionDetectionMode)component.CollisionDetectionMode;
		rigidbody.centerOfMass = (Vector3)component.CenterOfMass;
		rigidbody.inertiaTensorRotation = (Quaternion)component.InertiaTensorRotation;
		rigidbody.detectCollisions = component.DetectCollisions;
		rigidbody.position = (Vector3)component.Position;
		rigidbody.rotation = (Quaternion)component.Rotation;
		rigidbody.interpolation = (RigidbodyInterpolation)component.Interpolation;
		rigidbody.solverIterations = component.SolverIterationCount;
		rigidbody.maxAngularVelocity = component.MaxAngularVelocity;
	}

	// Token: 0x06000E0C RID: 3596 RVA: 0x000648D4 File Offset: 0x00062CD4
	public RigidbodySerializer(GameObject gameObject)
	{
		Rigidbody component = gameObject.GetComponent<Rigidbody>();
		this.Velocity = (Vector3Serializer)component.velocity;
		this.AngularVelocity = (Vector3Serializer)component.angularVelocity;
		this.Drag = component.drag;
		this.AngularDrag = component.angularDrag;
		this.Mass = component.mass;
		this.UseGravity = component.useGravity;
		this.IsKinematic = component.isKinematic;
		this.FreezeRotation = component.freezeRotation;
		this.Constraints = (RigidbodyConstraintsSerializer)component.constraints;
		this.CollisionDetectionMode = (CollisionDetectionModeSerializer)component.collisionDetectionMode;
		this.CenterOfMass = (Vector3Serializer)component.centerOfMass;
		this.InertiaTensorRotation = (QuaternionSerializer)component.inertiaTensorRotation;
		this.DetectCollisions = component.detectCollisions;
		this.Position = (Vector3Serializer)component.position;
		this.Rotation = (QuaternionSerializer)component.rotation;
		this.Interpolation = (RigidbodyInterpolationSerializer)component.interpolation;
		this.SolverIterationCount = component.solverIterations;
		this.MaxAngularVelocity = component.maxAngularVelocity;
	}

	// Token: 0x06000E0D RID: 3597 RVA: 0x000649E4 File Offset: 0x00062DE4
	private RigidbodySerializer()
	{
	}

	// Token: 0x17000213 RID: 531
	// (get) Token: 0x06000E0E RID: 3598 RVA: 0x000649EC File Offset: 0x00062DEC
	// (set) Token: 0x06000E0F RID: 3599 RVA: 0x000649F4 File Offset: 0x00062DF4
	[ProtoMember(1)]
	public Vector3Serializer Velocity { get; set; }

	// Token: 0x17000214 RID: 532
	// (get) Token: 0x06000E10 RID: 3600 RVA: 0x000649FD File Offset: 0x00062DFD
	// (set) Token: 0x06000E11 RID: 3601 RVA: 0x00064A05 File Offset: 0x00062E05
	[ProtoMember(2)]
	public Vector3Serializer AngularVelocity { get; set; }

	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06000E12 RID: 3602 RVA: 0x00064A0E File Offset: 0x00062E0E
	// (set) Token: 0x06000E13 RID: 3603 RVA: 0x00064A16 File Offset: 0x00062E16
	[ProtoMember(3)]
	public float Drag { get; set; }

	// Token: 0x17000216 RID: 534
	// (get) Token: 0x06000E14 RID: 3604 RVA: 0x00064A1F File Offset: 0x00062E1F
	// (set) Token: 0x06000E15 RID: 3605 RVA: 0x00064A27 File Offset: 0x00062E27
	[ProtoMember(4)]
	public float AngularDrag { get; set; }

	// Token: 0x17000217 RID: 535
	// (get) Token: 0x06000E16 RID: 3606 RVA: 0x00064A30 File Offset: 0x00062E30
	// (set) Token: 0x06000E17 RID: 3607 RVA: 0x00064A38 File Offset: 0x00062E38
	[ProtoMember(5)]
	public float Mass { get; set; }

	// Token: 0x17000218 RID: 536
	// (get) Token: 0x06000E18 RID: 3608 RVA: 0x00064A41 File Offset: 0x00062E41
	// (set) Token: 0x06000E19 RID: 3609 RVA: 0x00064A49 File Offset: 0x00062E49
	[ProtoMember(6)]
	public bool UseGravity { get; set; }

	// Token: 0x17000219 RID: 537
	// (get) Token: 0x06000E1A RID: 3610 RVA: 0x00064A52 File Offset: 0x00062E52
	// (set) Token: 0x06000E1B RID: 3611 RVA: 0x00064A5A File Offset: 0x00062E5A
	[ProtoMember(7)]
	public bool IsKinematic { get; set; }

	// Token: 0x1700021A RID: 538
	// (get) Token: 0x06000E1C RID: 3612 RVA: 0x00064A63 File Offset: 0x00062E63
	// (set) Token: 0x06000E1D RID: 3613 RVA: 0x00064A6B File Offset: 0x00062E6B
	[ProtoMember(8)]
	public bool FreezeRotation { get; set; }

	// Token: 0x1700021B RID: 539
	// (get) Token: 0x06000E1E RID: 3614 RVA: 0x00064A74 File Offset: 0x00062E74
	// (set) Token: 0x06000E1F RID: 3615 RVA: 0x00064A7C File Offset: 0x00062E7C
	[ProtoMember(9)]
	public RigidbodyConstraintsSerializer Constraints { get; set; }

	// Token: 0x1700021C RID: 540
	// (get) Token: 0x06000E20 RID: 3616 RVA: 0x00064A85 File Offset: 0x00062E85
	// (set) Token: 0x06000E21 RID: 3617 RVA: 0x00064A8D File Offset: 0x00062E8D
	[ProtoMember(10)]
	public CollisionDetectionModeSerializer CollisionDetectionMode { get; set; }

	// Token: 0x1700021D RID: 541
	// (get) Token: 0x06000E22 RID: 3618 RVA: 0x00064A96 File Offset: 0x00062E96
	// (set) Token: 0x06000E23 RID: 3619 RVA: 0x00064A9E File Offset: 0x00062E9E
	[ProtoMember(11)]
	public Vector3Serializer CenterOfMass { get; set; }

	// Token: 0x1700021E RID: 542
	// (get) Token: 0x06000E24 RID: 3620 RVA: 0x00064AA7 File Offset: 0x00062EA7
	// (set) Token: 0x06000E25 RID: 3621 RVA: 0x00064AAF File Offset: 0x00062EAF
	[ProtoMember(12)]
	public QuaternionSerializer InertiaTensorRotation { get; set; }

	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06000E26 RID: 3622 RVA: 0x00064AB8 File Offset: 0x00062EB8
	// (set) Token: 0x06000E27 RID: 3623 RVA: 0x00064AC0 File Offset: 0x00062EC0
	[ProtoMember(13)]
	public Vector3Serializer InertiaTensor { get; set; }

	// Token: 0x17000220 RID: 544
	// (get) Token: 0x06000E28 RID: 3624 RVA: 0x00064AC9 File Offset: 0x00062EC9
	// (set) Token: 0x06000E29 RID: 3625 RVA: 0x00064AD1 File Offset: 0x00062ED1
	[ProtoMember(14)]
	public bool DetectCollisions { get; set; }

	// Token: 0x17000221 RID: 545
	// (get) Token: 0x06000E2A RID: 3626 RVA: 0x00064ADA File Offset: 0x00062EDA
	// (set) Token: 0x06000E2B RID: 3627 RVA: 0x00064AE2 File Offset: 0x00062EE2
	[ProtoMember(15)]
	public bool UseConeFriction { get; set; }

	// Token: 0x17000222 RID: 546
	// (get) Token: 0x06000E2C RID: 3628 RVA: 0x00064AEB File Offset: 0x00062EEB
	// (set) Token: 0x06000E2D RID: 3629 RVA: 0x00064AF3 File Offset: 0x00062EF3
	[ProtoMember(16)]
	public Vector3Serializer Position { get; set; }

	// Token: 0x17000223 RID: 547
	// (get) Token: 0x06000E2E RID: 3630 RVA: 0x00064AFC File Offset: 0x00062EFC
	// (set) Token: 0x06000E2F RID: 3631 RVA: 0x00064B04 File Offset: 0x00062F04
	[ProtoMember(17)]
	public QuaternionSerializer Rotation { get; set; }

	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06000E30 RID: 3632 RVA: 0x00064B0D File Offset: 0x00062F0D
	// (set) Token: 0x06000E31 RID: 3633 RVA: 0x00064B15 File Offset: 0x00062F15
	[ProtoMember(18)]
	public RigidbodyInterpolationSerializer Interpolation { get; set; }

	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06000E32 RID: 3634 RVA: 0x00064B1E File Offset: 0x00062F1E
	// (set) Token: 0x06000E33 RID: 3635 RVA: 0x00064B26 File Offset: 0x00062F26
	[ProtoMember(19)]
	public int SolverIterationCount { get; set; }

	// Token: 0x17000226 RID: 550
	// (get) Token: 0x06000E34 RID: 3636 RVA: 0x00064B2F File Offset: 0x00062F2F
	// (set) Token: 0x06000E35 RID: 3637 RVA: 0x00064B37 File Offset: 0x00062F37
	[ProtoMember(20)]
	public float SleepVelocity { get; set; }

	// Token: 0x17000227 RID: 551
	// (get) Token: 0x06000E36 RID: 3638 RVA: 0x00064B40 File Offset: 0x00062F40
	// (set) Token: 0x06000E37 RID: 3639 RVA: 0x00064B48 File Offset: 0x00062F48
	[ProtoMember(21)]
	public float SleepAngularVelocity { get; set; }

	// Token: 0x17000228 RID: 552
	// (get) Token: 0x06000E38 RID: 3640 RVA: 0x00064B51 File Offset: 0x00062F51
	// (set) Token: 0x06000E39 RID: 3641 RVA: 0x00064B59 File Offset: 0x00062F59
	[ProtoMember(22)]
	public float MaxAngularVelocity { get; set; }
}
