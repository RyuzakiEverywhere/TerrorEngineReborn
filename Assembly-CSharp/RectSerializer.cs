using System;
using System.Runtime.InteropServices;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000245 RID: 581
[ProtoContract]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct RectSerializer
{
	// Token: 0x06001038 RID: 4152 RVA: 0x00067C7C File Offset: 0x0006607C
	public RectSerializer(Rect data)
	{
		this = default(RectSerializer);
		this.X = data.x;
		this.Y = data.y;
		this.Center = (Vector2Serializer)data.center;
		this.Width = data.width;
		this.Height = data.height;
		this.XMin = data.xMin;
		this.YMin = data.yMin;
		this.XMax = data.xMax;
		this.YMax = data.yMax;
	}

	// Token: 0x170002F0 RID: 752
	// (get) Token: 0x06001039 RID: 4153 RVA: 0x00067D0A File Offset: 0x0006610A
	// (set) Token: 0x0600103A RID: 4154 RVA: 0x00067D12 File Offset: 0x00066112
	[ProtoMember(1)]
	public float X { get; set; }

	// Token: 0x170002F1 RID: 753
	// (get) Token: 0x0600103B RID: 4155 RVA: 0x00067D1B File Offset: 0x0006611B
	// (set) Token: 0x0600103C RID: 4156 RVA: 0x00067D23 File Offset: 0x00066123
	[ProtoMember(2)]
	public float Y { get; set; }

	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x0600103D RID: 4157 RVA: 0x00067D2C File Offset: 0x0006612C
	// (set) Token: 0x0600103E RID: 4158 RVA: 0x00067D34 File Offset: 0x00066134
	[ProtoMember(3)]
	public Vector2Serializer Center { get; set; }

	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x0600103F RID: 4159 RVA: 0x00067D3D File Offset: 0x0006613D
	// (set) Token: 0x06001040 RID: 4160 RVA: 0x00067D45 File Offset: 0x00066145
	[ProtoMember(4)]
	public float Width { get; set; }

	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x06001041 RID: 4161 RVA: 0x00067D4E File Offset: 0x0006614E
	// (set) Token: 0x06001042 RID: 4162 RVA: 0x00067D56 File Offset: 0x00066156
	[ProtoMember(5)]
	public float Height { get; set; }

	// Token: 0x170002F5 RID: 757
	// (get) Token: 0x06001043 RID: 4163 RVA: 0x00067D5F File Offset: 0x0006615F
	// (set) Token: 0x06001044 RID: 4164 RVA: 0x00067D67 File Offset: 0x00066167
	[ProtoMember(6)]
	public float XMin { get; set; }

	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x06001045 RID: 4165 RVA: 0x00067D70 File Offset: 0x00066170
	// (set) Token: 0x06001046 RID: 4166 RVA: 0x00067D78 File Offset: 0x00066178
	[ProtoMember(7)]
	public float YMin { get; set; }

	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x06001047 RID: 4167 RVA: 0x00067D81 File Offset: 0x00066181
	// (set) Token: 0x06001048 RID: 4168 RVA: 0x00067D89 File Offset: 0x00066189
	[ProtoMember(8)]
	public float XMax { get; set; }

	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x06001049 RID: 4169 RVA: 0x00067D92 File Offset: 0x00066192
	// (set) Token: 0x0600104A RID: 4170 RVA: 0x00067D9A File Offset: 0x0006619A
	[ProtoMember(9)]
	public float YMax { get; set; }

	// Token: 0x0600104B RID: 4171 RVA: 0x00067DA4 File Offset: 0x000661A4
	public static explicit operator Rect(RectSerializer data)
	{
		return new Rect
		{
			x = data.X,
			y = data.Y,
			center = (Vector2)data.Center,
			width = data.Width,
			height = data.Height,
			xMin = data.XMin,
			yMin = data.YMin,
			xMax = data.XMax,
			yMax = data.YMax
		};
	}

	// Token: 0x0600104C RID: 4172 RVA: 0x00067E3F File Offset: 0x0006623F
	public static explicit operator RectSerializer(Rect data)
	{
		return new RectSerializer(data);
	}
}
