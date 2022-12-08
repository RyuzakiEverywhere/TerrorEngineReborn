using System;
using System.Runtime.InteropServices;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200023F RID: 575
[ProtoContract]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct JointDriveSerializer
{
	// Token: 0x06001010 RID: 4112 RVA: 0x00067798 File Offset: 0x00065B98
	public JointDriveSerializer(JointDrive data)
	{
		this = default(JointDriveSerializer);
		this.Mode = (JointDriveModeSerializer)data.mode;
		this.PositionSpring = data.positionSpring;
		this.PositionDamper = data.positionDamper;
		this.MaximumForce = data.maximumForce;
	}

	// Token: 0x170002E5 RID: 741
	// (get) Token: 0x06001011 RID: 4113 RVA: 0x000677D5 File Offset: 0x00065BD5
	// (set) Token: 0x06001012 RID: 4114 RVA: 0x000677DD File Offset: 0x00065BDD
	[ProtoMember(1)]
	public JointDriveModeSerializer Mode { get; set; }

	// Token: 0x170002E6 RID: 742
	// (get) Token: 0x06001013 RID: 4115 RVA: 0x000677E6 File Offset: 0x00065BE6
	// (set) Token: 0x06001014 RID: 4116 RVA: 0x000677EE File Offset: 0x00065BEE
	[ProtoMember(2)]
	public float PositionSpring { get; set; }

	// Token: 0x170002E7 RID: 743
	// (get) Token: 0x06001015 RID: 4117 RVA: 0x000677F7 File Offset: 0x00065BF7
	// (set) Token: 0x06001016 RID: 4118 RVA: 0x000677FF File Offset: 0x00065BFF
	[ProtoMember(3)]
	public float PositionDamper { get; set; }

	// Token: 0x170002E8 RID: 744
	// (get) Token: 0x06001017 RID: 4119 RVA: 0x00067808 File Offset: 0x00065C08
	// (set) Token: 0x06001018 RID: 4120 RVA: 0x00067810 File Offset: 0x00065C10
	[ProtoMember(4)]
	public float MaximumForce { get; set; }

	// Token: 0x06001019 RID: 4121 RVA: 0x0006781C File Offset: 0x00065C1C
	public static explicit operator JointDrive(JointDriveSerializer data)
	{
		return new JointDrive
		{
			mode = (JointDriveMode)data.Mode,
			positionSpring = data.PositionSpring,
			positionDamper = data.PositionDamper,
			maximumForce = data.MaximumForce
		};
	}

	// Token: 0x0600101A RID: 4122 RVA: 0x0006786C File Offset: 0x00065C6C
	public static explicit operator JointDriveSerializer(JointDrive data)
	{
		return new JointDriveSerializer(data);
	}
}
