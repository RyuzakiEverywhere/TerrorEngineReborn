using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000209 RID: 521
[ProtoContract]
public sealed class SpringJointSerializer
{
	// Token: 0x06000E62 RID: 3682 RVA: 0x00064DA0 File Offset: 0x000631A0
	public SpringJointSerializer(GameObject gameObject, SpringJointSerializer component)
	{
		SpringJoint springJoint = gameObject.GetComponent<SpringJoint>();
		if (springJoint == null)
		{
			springJoint = gameObject.AddComponent<SpringJoint>();
		}
		if (!string.IsNullOrEmpty(component.ConnectedBodyName))
		{
			Rigidbody[] array = UnityEngine.Object.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
			if (array != null)
			{
				springJoint.connectedBody = array.FirstOrDefault((Rigidbody rigidBody) => rigidBody.name == component.ConnectedBodyName);
			}
		}
		springJoint.axis = (Vector3)component.Axis;
		springJoint.anchor = (Vector3)component.Anchor;
		springJoint.breakForce = component.BreakForce;
		springJoint.breakTorque = component.BreakTorque;
		springJoint.spring = component.Spring;
		springJoint.damper = component.Damper;
		springJoint.minDistance = component.MinDistance;
		springJoint.maxDistance = component.MaxDistance;
	}

	// Token: 0x06000E63 RID: 3683 RVA: 0x00064EB4 File Offset: 0x000632B4
	public SpringJointSerializer(GameObject gameObject)
	{
		SpringJoint component = gameObject.GetComponent<SpringJoint>();
		if (component.connectedBody != null)
		{
			this.ConnectedBodyName = component.connectedBody.name;
		}
		this.Axis = (Vector3Serializer)component.axis;
		this.Anchor = (Vector3Serializer)component.anchor;
		this.BreakForce = component.breakForce;
		this.BreakTorque = component.breakTorque;
		this.Spring = component.spring;
		this.Damper = component.damper;
		this.MinDistance = component.minDistance;
		this.MaxDistance = component.maxDistance;
	}

	// Token: 0x06000E64 RID: 3684 RVA: 0x00064F5A File Offset: 0x0006335A
	private SpringJointSerializer()
	{
	}

	// Token: 0x1700023A RID: 570
	// (get) Token: 0x06000E65 RID: 3685 RVA: 0x00064F62 File Offset: 0x00063362
	// (set) Token: 0x06000E66 RID: 3686 RVA: 0x00064F6A File Offset: 0x0006336A
	[ProtoMember(1)]
	public string ConnectedBodyName { get; set; }

	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06000E67 RID: 3687 RVA: 0x00064F73 File Offset: 0x00063373
	// (set) Token: 0x06000E68 RID: 3688 RVA: 0x00064F7B File Offset: 0x0006337B
	[ProtoMember(2)]
	public Vector3Serializer Axis { get; set; }

	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06000E69 RID: 3689 RVA: 0x00064F84 File Offset: 0x00063384
	// (set) Token: 0x06000E6A RID: 3690 RVA: 0x00064F8C File Offset: 0x0006338C
	[ProtoMember(3)]
	public Vector3Serializer Anchor { get; set; }

	// Token: 0x1700023D RID: 573
	// (get) Token: 0x06000E6B RID: 3691 RVA: 0x00064F95 File Offset: 0x00063395
	// (set) Token: 0x06000E6C RID: 3692 RVA: 0x00064F9D File Offset: 0x0006339D
	[ProtoMember(4)]
	public float BreakForce { get; set; }

	// Token: 0x1700023E RID: 574
	// (get) Token: 0x06000E6D RID: 3693 RVA: 0x00064FA6 File Offset: 0x000633A6
	// (set) Token: 0x06000E6E RID: 3694 RVA: 0x00064FAE File Offset: 0x000633AE
	[ProtoMember(5)]
	public float BreakTorque { get; set; }

	// Token: 0x1700023F RID: 575
	// (get) Token: 0x06000E6F RID: 3695 RVA: 0x00064FB7 File Offset: 0x000633B7
	// (set) Token: 0x06000E70 RID: 3696 RVA: 0x00064FBF File Offset: 0x000633BF
	[ProtoMember(6)]
	public float Spring { get; set; }

	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06000E71 RID: 3697 RVA: 0x00064FC8 File Offset: 0x000633C8
	// (set) Token: 0x06000E72 RID: 3698 RVA: 0x00064FD0 File Offset: 0x000633D0
	[ProtoMember(7)]
	public float Damper { get; set; }

	// Token: 0x17000241 RID: 577
	// (get) Token: 0x06000E73 RID: 3699 RVA: 0x00064FD9 File Offset: 0x000633D9
	// (set) Token: 0x06000E74 RID: 3700 RVA: 0x00064FE1 File Offset: 0x000633E1
	[ProtoMember(8)]
	public float MinDistance { get; set; }

	// Token: 0x17000242 RID: 578
	// (get) Token: 0x06000E75 RID: 3701 RVA: 0x00064FEA File Offset: 0x000633EA
	// (set) Token: 0x06000E76 RID: 3702 RVA: 0x00064FF2 File Offset: 0x000633F2
	[ProtoMember(9)]
	public float MaxDistance { get; set; }
}
