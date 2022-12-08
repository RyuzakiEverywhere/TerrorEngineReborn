using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000242 RID: 578
[ProtoContract]
public struct JointSpringSerializer
{
	// Token: 0x0600102F RID: 4143 RVA: 0x000679C6 File Offset: 0x00065DC6
	public JointSpringSerializer(JointSpring data)
	{
		this.Spring = data.spring;
		this.Damper = data.damper;
		this.TargetPosition = data.targetPosition;
	}

	// Token: 0x06001030 RID: 4144 RVA: 0x000679F0 File Offset: 0x00065DF0
	public static explicit operator JointSpring(JointSpringSerializer data)
	{
		return new JointSpring
		{
			spring = data.Spring,
			damper = data.Damper,
			targetPosition = data.TargetPosition
		};
	}

	// Token: 0x06001031 RID: 4145 RVA: 0x00067A32 File Offset: 0x00065E32
	public static explicit operator JointSpringSerializer(JointSpring data)
	{
		return new JointSpringSerializer(data);
	}

	// Token: 0x040010DC RID: 4316
	[ProtoMember(1)]
	public float Spring;

	// Token: 0x040010DD RID: 4317
	[ProtoMember(2)]
	public float Damper;

	// Token: 0x040010DE RID: 4318
	[ProtoMember(3)]
	public float TargetPosition;
}
