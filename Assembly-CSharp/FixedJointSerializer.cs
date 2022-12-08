using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000202 RID: 514
[ProtoContract]
public sealed class FixedJointSerializer
{
	// Token: 0x06000DB1 RID: 3505 RVA: 0x00063FEC File Offset: 0x000623EC
	public FixedJointSerializer(GameObject gameObject, FixedJointSerializer component)
	{
		FixedJoint fixedJoint = gameObject.GetComponent<FixedJoint>();
		if (fixedJoint == null)
		{
			fixedJoint = gameObject.AddComponent<FixedJoint>();
		}
		if (!string.IsNullOrEmpty(component.ConnectedBodyName))
		{
			Rigidbody[] array = UnityEngine.Object.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
			if (array != null)
			{
				fixedJoint.connectedBody = array.FirstOrDefault((Rigidbody rigidBody) => rigidBody.name == component.ConnectedBodyName);
			}
		}
		fixedJoint.axis = (Vector3)component.Axis;
		fixedJoint.anchor = (Vector3)component.Anchor;
		fixedJoint.breakForce = component.BreakForce;
		fixedJoint.breakTorque = component.BreakTorque;
	}

	// Token: 0x06000DB2 RID: 3506 RVA: 0x000640BC File Offset: 0x000624BC
	public FixedJointSerializer(GameObject gameObject)
	{
		FixedJoint component = gameObject.GetComponent<FixedJoint>();
		if (component.connectedBody != null)
		{
			this.ConnectedBodyName = component.connectedBody.name;
		}
		this.Axis = (Vector3Serializer)component.axis;
		this.Anchor = (Vector3Serializer)component.anchor;
		this.BreakForce = component.breakForce;
		this.BreakTorque = component.breakTorque;
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x00064132 File Offset: 0x00062532
	private FixedJointSerializer()
	{
	}

	// Token: 0x170001EC RID: 492
	// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x0006413A File Offset: 0x0006253A
	// (set) Token: 0x06000DB5 RID: 3509 RVA: 0x00064142 File Offset: 0x00062542
	[ProtoMember(1)]
	public string ConnectedBodyName { get; set; }

	// Token: 0x170001ED RID: 493
	// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x0006414B File Offset: 0x0006254B
	// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x00064153 File Offset: 0x00062553
	[ProtoMember(2)]
	public Vector3Serializer Axis { get; set; }

	// Token: 0x170001EE RID: 494
	// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x0006415C File Offset: 0x0006255C
	// (set) Token: 0x06000DB9 RID: 3513 RVA: 0x00064164 File Offset: 0x00062564
	[ProtoMember(3)]
	public Vector3Serializer Anchor { get; set; }

	// Token: 0x170001EF RID: 495
	// (get) Token: 0x06000DBA RID: 3514 RVA: 0x0006416D File Offset: 0x0006256D
	// (set) Token: 0x06000DBB RID: 3515 RVA: 0x00064175 File Offset: 0x00062575
	[ProtoMember(4)]
	public float BreakForce { get; set; }

	// Token: 0x170001F0 RID: 496
	// (get) Token: 0x06000DBC RID: 3516 RVA: 0x0006417E File Offset: 0x0006257E
	// (set) Token: 0x06000DBD RID: 3517 RVA: 0x00064186 File Offset: 0x00062586
	[ProtoMember(5)]
	public float BreakTorque { get; set; }
}
