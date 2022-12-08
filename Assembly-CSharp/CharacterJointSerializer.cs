using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001FE RID: 510
[ProtoContract]
public sealed class CharacterJointSerializer
{
	// Token: 0x06000D31 RID: 3377 RVA: 0x000633B4 File Offset: 0x000617B4
	public CharacterJointSerializer(GameObject gameObject, CharacterJointSerializer component)
	{
		CharacterJoint characterJoint = gameObject.GetComponent<CharacterJoint>();
		if (characterJoint == null)
		{
			characterJoint = gameObject.AddComponent<CharacterJoint>();
		}
		if (!string.IsNullOrEmpty(component.ConnectedBodyName))
		{
			Rigidbody[] array = UnityEngine.Object.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
			if (array != null)
			{
				characterJoint.connectedBody = array.FirstOrDefault((Rigidbody rigidBody) => rigidBody.name == component.ConnectedBodyName);
			}
		}
		characterJoint.axis = (Vector3)component.Axis;
		characterJoint.anchor = (Vector3)component.Anchor;
		characterJoint.breakForce = component.BreakForce;
		characterJoint.breakTorque = component.BreakTorque;
		characterJoint.swingAxis = (Vector3)component.SwingAxis;
		characterJoint.lowTwistLimit = (SoftJointLimit)component.LowTwistLimit;
		characterJoint.highTwistLimit = (SoftJointLimit)component.HighTwistLimit;
		characterJoint.swing1Limit = (SoftJointLimit)component.Swing1Limit;
		characterJoint.swing2Limit = (SoftJointLimit)component.Swing2Limit;
	}

	// Token: 0x06000D32 RID: 3378 RVA: 0x000634F4 File Offset: 0x000618F4
	public CharacterJointSerializer(GameObject gameObject)
	{
		CharacterJoint component = gameObject.GetComponent<CharacterJoint>();
		if (component.connectedBody != null)
		{
			this.ConnectedBodyName = component.connectedBody.name;
		}
		this.Axis = (Vector3Serializer)component.axis;
		this.Anchor = (Vector3Serializer)component.anchor;
		this.BreakForce = component.breakForce;
		this.BreakTorque = component.breakTorque;
		this.SwingAxis = (Vector3Serializer)component.swingAxis;
		this.LowTwistLimit = (SoftJointLimitSerializer)component.lowTwistLimit;
		this.HighTwistLimit = (SoftJointLimitSerializer)component.highTwistLimit;
		this.Swing1Limit = (SoftJointLimitSerializer)component.swing1Limit;
		this.Swing2Limit = (SoftJointLimitSerializer)component.swing2Limit;
	}

	// Token: 0x06000D33 RID: 3379 RVA: 0x000635BF File Offset: 0x000619BF
	private CharacterJointSerializer()
	{
	}

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x06000D34 RID: 3380 RVA: 0x000635C7 File Offset: 0x000619C7
	// (set) Token: 0x06000D35 RID: 3381 RVA: 0x000635CF File Offset: 0x000619CF
	[ProtoMember(1)]
	public string ConnectedBodyName { get; set; }

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06000D36 RID: 3382 RVA: 0x000635D8 File Offset: 0x000619D8
	// (set) Token: 0x06000D37 RID: 3383 RVA: 0x000635E0 File Offset: 0x000619E0
	[ProtoMember(2)]
	public Vector3Serializer Axis { get; set; }

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06000D38 RID: 3384 RVA: 0x000635E9 File Offset: 0x000619E9
	// (set) Token: 0x06000D39 RID: 3385 RVA: 0x000635F1 File Offset: 0x000619F1
	[ProtoMember(3)]
	public Vector3Serializer Anchor { get; set; }

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x06000D3A RID: 3386 RVA: 0x000635FA File Offset: 0x000619FA
	// (set) Token: 0x06000D3B RID: 3387 RVA: 0x00063602 File Offset: 0x00061A02
	[ProtoMember(4)]
	public float BreakForce { get; set; }

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x06000D3C RID: 3388 RVA: 0x0006360B File Offset: 0x00061A0B
	// (set) Token: 0x06000D3D RID: 3389 RVA: 0x00063613 File Offset: 0x00061A13
	[ProtoMember(5)]
	public float BreakTorque { get; set; }

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x06000D3E RID: 3390 RVA: 0x0006361C File Offset: 0x00061A1C
	// (set) Token: 0x06000D3F RID: 3391 RVA: 0x00063624 File Offset: 0x00061A24
	[ProtoMember(6)]
	public Vector3Serializer SwingAxis { get; set; }

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x06000D40 RID: 3392 RVA: 0x0006362D File Offset: 0x00061A2D
	// (set) Token: 0x06000D41 RID: 3393 RVA: 0x00063635 File Offset: 0x00061A35
	[ProtoMember(7)]
	public SoftJointLimitSerializer LowTwistLimit { get; set; }

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x06000D42 RID: 3394 RVA: 0x0006363E File Offset: 0x00061A3E
	// (set) Token: 0x06000D43 RID: 3395 RVA: 0x00063646 File Offset: 0x00061A46
	[ProtoMember(8)]
	public SoftJointLimitSerializer HighTwistLimit { get; set; }

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x06000D44 RID: 3396 RVA: 0x0006364F File Offset: 0x00061A4F
	// (set) Token: 0x06000D45 RID: 3397 RVA: 0x00063657 File Offset: 0x00061A57
	[ProtoMember(9)]
	public SoftJointLimitSerializer Swing1Limit { get; set; }

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x06000D46 RID: 3398 RVA: 0x00063660 File Offset: 0x00061A60
	// (set) Token: 0x06000D47 RID: 3399 RVA: 0x00063668 File Offset: 0x00061A68
	[ProtoMember(10)]
	public SoftJointLimitSerializer Swing2Limit { get; set; }

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06000D48 RID: 3400 RVA: 0x00063671 File Offset: 0x00061A71
	// (set) Token: 0x06000D49 RID: 3401 RVA: 0x00063679 File Offset: 0x00061A79
	[ProtoMember(11)]
	public QuaternionSerializer TargetRotation { get; set; }

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06000D4A RID: 3402 RVA: 0x00063682 File Offset: 0x00061A82
	// (set) Token: 0x06000D4B RID: 3403 RVA: 0x0006368A File Offset: 0x00061A8A
	[ProtoMember(12)]
	public Vector3Serializer TargetAngularVelocity { get; set; }

	// Token: 0x170001BE RID: 446
	// (get) Token: 0x06000D4C RID: 3404 RVA: 0x00063693 File Offset: 0x00061A93
	// (set) Token: 0x06000D4D RID: 3405 RVA: 0x0006369B File Offset: 0x00061A9B
	[ProtoMember(13)]
	public JointDriveSerializer RotationDrive { get; set; }
}
