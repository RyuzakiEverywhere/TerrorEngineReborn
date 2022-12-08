using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000200 RID: 512
[ProtoContract]
public sealed class ConfigurableJointSerializer
{
	// Token: 0x06000D61 RID: 3425 RVA: 0x00063764 File Offset: 0x00061B64
	public ConfigurableJointSerializer(GameObject gameObject, ConfigurableJointSerializer component)
	{
		ConfigurableJoint configurableJoint = gameObject.GetComponent<ConfigurableJoint>();
		if (configurableJoint == null)
		{
			configurableJoint = gameObject.AddComponent<ConfigurableJoint>();
		}
		if (!string.IsNullOrEmpty(component.ConnectedBodyName))
		{
			Rigidbody[] array = UnityEngine.Object.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
			if (array != null)
			{
				configurableJoint.connectedBody = array.FirstOrDefault((Rigidbody rigidBody) => rigidBody.name == component.ConnectedBodyName);
			}
		}
		configurableJoint.axis = (Vector3)component.Axis;
		configurableJoint.anchor = (Vector3)component.Anchor;
		configurableJoint.breakForce = component.BreakForce;
		configurableJoint.breakTorque = component.BreakTorque;
		configurableJoint.secondaryAxis = (Vector3)component.SecondaryAxis;
		configurableJoint.xMotion = (ConfigurableJointMotion)component.XMotion;
		configurableJoint.yMotion = (ConfigurableJointMotion)component.YMotion;
		configurableJoint.zMotion = (ConfigurableJointMotion)component.ZMotion;
		configurableJoint.angularXMotion = (ConfigurableJointMotion)component.AngularXMotion;
		configurableJoint.angularYMotion = (ConfigurableJointMotion)component.AngularYMotion;
		configurableJoint.angularZMotion = (ConfigurableJointMotion)component.AngularZMotion;
		configurableJoint.linearLimit = (SoftJointLimit)component.LinearLimit;
		configurableJoint.lowAngularXLimit = (SoftJointLimit)component.LowAngularXLimit;
		configurableJoint.highAngularXLimit = (SoftJointLimit)component.HighAngularXLimit;
		configurableJoint.angularYLimit = (SoftJointLimit)component.AngularYLimit;
		configurableJoint.angularZLimit = (SoftJointLimit)component.AngularZLimit;
		configurableJoint.targetPosition = (Vector3)component.TargetPosition;
		configurableJoint.targetVelocity = (Vector3)component.TargetVelocity;
		configurableJoint.xDrive = (JointDrive)component.XDrive;
		configurableJoint.yDrive = (JointDrive)component.YDrive;
		configurableJoint.zDrive = (JointDrive)component.ZDrive;
		configurableJoint.targetRotation = (Quaternion)component.TargetRotation;
		configurableJoint.targetAngularVelocity = (Vector3)component.TargetAngularVelocity;
		configurableJoint.rotationDriveMode = (RotationDriveMode)component.RotationDriveMode;
		configurableJoint.angularXDrive = (JointDrive)component.AngularXDrive;
		configurableJoint.angularYZDrive = (JointDrive)component.AngularYZDrive;
		configurableJoint.slerpDrive = (JointDrive)component.SlerpDrive;
		configurableJoint.projectionMode = (JointProjectionMode)component.ProjectionMode;
		configurableJoint.projectionDistance = component.ProjectionDistance;
		configurableJoint.projectionAngle = component.ProjectionAngle;
		configurableJoint.configuredInWorldSpace = component.ConfiguredInWorldSpace;
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x00063A50 File Offset: 0x00061E50
	public ConfigurableJointSerializer(GameObject gameObject)
	{
		ConfigurableJoint component = gameObject.GetComponent<ConfigurableJoint>();
		if (component.connectedBody != null)
		{
			this.ConnectedBodyName = component.connectedBody.name;
		}
		this.Axis = (Vector3Serializer)component.axis;
		this.Anchor = (Vector3Serializer)component.anchor;
		this.BreakForce = component.breakForce;
		this.BreakTorque = component.breakTorque;
		this.SecondaryAxis = (Vector3Serializer)component.secondaryAxis;
		this.XMotion = (ConfigurableJointMotionSerializer)component.xMotion;
		this.YMotion = (ConfigurableJointMotionSerializer)component.yMotion;
		this.ZMotion = (ConfigurableJointMotionSerializer)component.zMotion;
		this.AngularXMotion = (ConfigurableJointMotionSerializer)component.angularXMotion;
		this.AngularYMotion = (ConfigurableJointMotionSerializer)component.angularYMotion;
		this.AngularZMotion = (ConfigurableJointMotionSerializer)component.angularZMotion;
		this.LinearLimit = (SoftJointLimitSerializer)component.linearLimit;
		this.LowAngularXLimit = (SoftJointLimitSerializer)component.lowAngularXLimit;
		this.HighAngularXLimit = (SoftJointLimitSerializer)component.highAngularXLimit;
		this.AngularYLimit = (SoftJointLimitSerializer)component.angularYLimit;
		this.AngularZLimit = (SoftJointLimitSerializer)component.angularZLimit;
		this.TargetPosition = (Vector3Serializer)component.targetPosition;
		this.TargetVelocity = (Vector3Serializer)component.targetVelocity;
		this.XDrive = (JointDriveSerializer)component.xDrive;
		this.YDrive = (JointDriveSerializer)component.yDrive;
		this.ZDrive = (JointDriveSerializer)component.zDrive;
		this.TargetRotation = (QuaternionSerializer)component.targetRotation;
		this.TargetAngularVelocity = (Vector3Serializer)component.targetAngularVelocity;
		this.RotationDriveMode = (RotationDriveModeSerializer)component.rotationDriveMode;
		this.AngularXDrive = (JointDriveSerializer)component.angularXDrive;
		this.AngularYZDrive = (JointDriveSerializer)component.angularYZDrive;
		this.SlerpDrive = (JointDriveSerializer)component.slerpDrive;
		this.ProjectionMode = (JointProjectionModeSerializer)component.projectionMode;
		this.ProjectionDistance = component.projectionDistance;
		this.ProjectionAngle = component.projectionAngle;
		this.ConfiguredInWorldSpace = component.configuredInWorldSpace;
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x00063C5A File Offset: 0x0006205A
	private ConfigurableJointSerializer()
	{
	}

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x06000D64 RID: 3428 RVA: 0x00063C62 File Offset: 0x00062062
	// (set) Token: 0x06000D65 RID: 3429 RVA: 0x00063C6A File Offset: 0x0006206A
	[ProtoMember(1)]
	public string ConnectedBodyName { get; set; }

	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x06000D66 RID: 3430 RVA: 0x00063C73 File Offset: 0x00062073
	// (set) Token: 0x06000D67 RID: 3431 RVA: 0x00063C7B File Offset: 0x0006207B
	[ProtoMember(2)]
	public Vector3Serializer Axis { get; set; }

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x06000D68 RID: 3432 RVA: 0x00063C84 File Offset: 0x00062084
	// (set) Token: 0x06000D69 RID: 3433 RVA: 0x00063C8C File Offset: 0x0006208C
	[ProtoMember(3)]
	public Vector3Serializer Anchor { get; set; }

	// Token: 0x170001CA RID: 458
	// (get) Token: 0x06000D6A RID: 3434 RVA: 0x00063C95 File Offset: 0x00062095
	// (set) Token: 0x06000D6B RID: 3435 RVA: 0x00063C9D File Offset: 0x0006209D
	[ProtoMember(4)]
	public float BreakForce { get; set; }

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x06000D6C RID: 3436 RVA: 0x00063CA6 File Offset: 0x000620A6
	// (set) Token: 0x06000D6D RID: 3437 RVA: 0x00063CAE File Offset: 0x000620AE
	[ProtoMember(5)]
	public float BreakTorque { get; set; }

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x06000D6E RID: 3438 RVA: 0x00063CB7 File Offset: 0x000620B7
	// (set) Token: 0x06000D6F RID: 3439 RVA: 0x00063CBF File Offset: 0x000620BF
	[ProtoMember(6)]
	public Vector3Serializer SecondaryAxis { get; set; }

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x06000D70 RID: 3440 RVA: 0x00063CC8 File Offset: 0x000620C8
	// (set) Token: 0x06000D71 RID: 3441 RVA: 0x00063CD0 File Offset: 0x000620D0
	[ProtoMember(7)]
	public ConfigurableJointMotionSerializer XMotion { get; set; }

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x06000D72 RID: 3442 RVA: 0x00063CD9 File Offset: 0x000620D9
	// (set) Token: 0x06000D73 RID: 3443 RVA: 0x00063CE1 File Offset: 0x000620E1
	[ProtoMember(8)]
	public ConfigurableJointMotionSerializer YMotion { get; set; }

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x06000D74 RID: 3444 RVA: 0x00063CEA File Offset: 0x000620EA
	// (set) Token: 0x06000D75 RID: 3445 RVA: 0x00063CF2 File Offset: 0x000620F2
	[ProtoMember(9)]
	public ConfigurableJointMotionSerializer ZMotion { get; set; }

	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x06000D76 RID: 3446 RVA: 0x00063CFB File Offset: 0x000620FB
	// (set) Token: 0x06000D77 RID: 3447 RVA: 0x00063D03 File Offset: 0x00062103
	[ProtoMember(10)]
	public ConfigurableJointMotionSerializer AngularXMotion { get; set; }

	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x06000D78 RID: 3448 RVA: 0x00063D0C File Offset: 0x0006210C
	// (set) Token: 0x06000D79 RID: 3449 RVA: 0x00063D14 File Offset: 0x00062114
	[ProtoMember(11)]
	public ConfigurableJointMotionSerializer AngularYMotion { get; set; }

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x06000D7A RID: 3450 RVA: 0x00063D1D File Offset: 0x0006211D
	// (set) Token: 0x06000D7B RID: 3451 RVA: 0x00063D25 File Offset: 0x00062125
	[ProtoMember(12)]
	public ConfigurableJointMotionSerializer AngularZMotion { get; set; }

	// Token: 0x170001D3 RID: 467
	// (get) Token: 0x06000D7C RID: 3452 RVA: 0x00063D2E File Offset: 0x0006212E
	// (set) Token: 0x06000D7D RID: 3453 RVA: 0x00063D36 File Offset: 0x00062136
	[ProtoMember(13)]
	public SoftJointLimitSerializer LinearLimit { get; set; }

	// Token: 0x170001D4 RID: 468
	// (get) Token: 0x06000D7E RID: 3454 RVA: 0x00063D3F File Offset: 0x0006213F
	// (set) Token: 0x06000D7F RID: 3455 RVA: 0x00063D47 File Offset: 0x00062147
	[ProtoMember(14)]
	public SoftJointLimitSerializer LowAngularXLimit { get; set; }

	// Token: 0x170001D5 RID: 469
	// (get) Token: 0x06000D80 RID: 3456 RVA: 0x00063D50 File Offset: 0x00062150
	// (set) Token: 0x06000D81 RID: 3457 RVA: 0x00063D58 File Offset: 0x00062158
	[ProtoMember(15)]
	public SoftJointLimitSerializer HighAngularXLimit { get; set; }

	// Token: 0x170001D6 RID: 470
	// (get) Token: 0x06000D82 RID: 3458 RVA: 0x00063D61 File Offset: 0x00062161
	// (set) Token: 0x06000D83 RID: 3459 RVA: 0x00063D69 File Offset: 0x00062169
	[ProtoMember(16)]
	public SoftJointLimitSerializer AngularYLimit { get; set; }

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x06000D84 RID: 3460 RVA: 0x00063D72 File Offset: 0x00062172
	// (set) Token: 0x06000D85 RID: 3461 RVA: 0x00063D7A File Offset: 0x0006217A
	[ProtoMember(17)]
	public SoftJointLimitSerializer AngularZLimit { get; set; }

	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x06000D86 RID: 3462 RVA: 0x00063D83 File Offset: 0x00062183
	// (set) Token: 0x06000D87 RID: 3463 RVA: 0x00063D8B File Offset: 0x0006218B
	[ProtoMember(18)]
	public Vector3Serializer TargetPosition { get; set; }

	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x06000D88 RID: 3464 RVA: 0x00063D94 File Offset: 0x00062194
	// (set) Token: 0x06000D89 RID: 3465 RVA: 0x00063D9C File Offset: 0x0006219C
	[ProtoMember(19)]
	public Vector3Serializer TargetVelocity { get; set; }

	// Token: 0x170001DA RID: 474
	// (get) Token: 0x06000D8A RID: 3466 RVA: 0x00063DA5 File Offset: 0x000621A5
	// (set) Token: 0x06000D8B RID: 3467 RVA: 0x00063DAD File Offset: 0x000621AD
	[ProtoMember(20)]
	public JointDriveSerializer XDrive { get; set; }

	// Token: 0x170001DB RID: 475
	// (get) Token: 0x06000D8C RID: 3468 RVA: 0x00063DB6 File Offset: 0x000621B6
	// (set) Token: 0x06000D8D RID: 3469 RVA: 0x00063DBE File Offset: 0x000621BE
	[ProtoMember(21)]
	public JointDriveSerializer YDrive { get; set; }

	// Token: 0x170001DC RID: 476
	// (get) Token: 0x06000D8E RID: 3470 RVA: 0x00063DC7 File Offset: 0x000621C7
	// (set) Token: 0x06000D8F RID: 3471 RVA: 0x00063DCF File Offset: 0x000621CF
	[ProtoMember(22)]
	public JointDriveSerializer ZDrive { get; set; }

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x06000D90 RID: 3472 RVA: 0x00063DD8 File Offset: 0x000621D8
	// (set) Token: 0x06000D91 RID: 3473 RVA: 0x00063DE0 File Offset: 0x000621E0
	[ProtoMember(23)]
	public QuaternionSerializer TargetRotation { get; set; }

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x06000D92 RID: 3474 RVA: 0x00063DE9 File Offset: 0x000621E9
	// (set) Token: 0x06000D93 RID: 3475 RVA: 0x00063DF1 File Offset: 0x000621F1
	[ProtoMember(24)]
	public Vector3Serializer TargetAngularVelocity { get; set; }

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x06000D94 RID: 3476 RVA: 0x00063DFA File Offset: 0x000621FA
	// (set) Token: 0x06000D95 RID: 3477 RVA: 0x00063E02 File Offset: 0x00062202
	[ProtoMember(25)]
	public RotationDriveModeSerializer RotationDriveMode { get; set; }

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x06000D96 RID: 3478 RVA: 0x00063E0B File Offset: 0x0006220B
	// (set) Token: 0x06000D97 RID: 3479 RVA: 0x00063E13 File Offset: 0x00062213
	[ProtoMember(26)]
	public JointDriveSerializer AngularXDrive { get; set; }

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x06000D98 RID: 3480 RVA: 0x00063E1C File Offset: 0x0006221C
	// (set) Token: 0x06000D99 RID: 3481 RVA: 0x00063E24 File Offset: 0x00062224
	[ProtoMember(27)]
	public JointDriveSerializer AngularYZDrive { get; set; }

	// Token: 0x170001E2 RID: 482
	// (get) Token: 0x06000D9A RID: 3482 RVA: 0x00063E2D File Offset: 0x0006222D
	// (set) Token: 0x06000D9B RID: 3483 RVA: 0x00063E35 File Offset: 0x00062235
	[ProtoMember(28)]
	public JointDriveSerializer SlerpDrive { get; set; }

	// Token: 0x170001E3 RID: 483
	// (get) Token: 0x06000D9C RID: 3484 RVA: 0x00063E3E File Offset: 0x0006223E
	// (set) Token: 0x06000D9D RID: 3485 RVA: 0x00063E46 File Offset: 0x00062246
	[ProtoMember(29)]
	public JointProjectionModeSerializer ProjectionMode { get; set; }

	// Token: 0x170001E4 RID: 484
	// (get) Token: 0x06000D9E RID: 3486 RVA: 0x00063E4F File Offset: 0x0006224F
	// (set) Token: 0x06000D9F RID: 3487 RVA: 0x00063E57 File Offset: 0x00062257
	[ProtoMember(30)]
	public float ProjectionDistance { get; set; }

	// Token: 0x170001E5 RID: 485
	// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x00063E60 File Offset: 0x00062260
	// (set) Token: 0x06000DA1 RID: 3489 RVA: 0x00063E68 File Offset: 0x00062268
	[ProtoMember(31)]
	public float ProjectionAngle { get; set; }

	// Token: 0x170001E6 RID: 486
	// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x00063E71 File Offset: 0x00062271
	// (set) Token: 0x06000DA3 RID: 3491 RVA: 0x00063E79 File Offset: 0x00062279
	[ProtoMember(32)]
	public bool ConfiguredInWorldSpace { get; set; }
}
