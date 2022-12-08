using System;

// Token: 0x020001B7 RID: 439
public struct int2
{
	// Token: 0x06000A74 RID: 2676 RVA: 0x0005C768 File Offset: 0x0005AB68
	public int2(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x0005C778 File Offset: 0x0005AB78
	public static int2 operator +(int2 a, int2 b)
	{
		return new int2(a.x + b.x, a.y + b.y);
	}

	// Token: 0x06000A76 RID: 2678 RVA: 0x0005C79D File Offset: 0x0005AB9D
	public static int2 operator -(int2 a, int2 b)
	{
		return new int2(a.x - b.x, a.y - b.y);
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x0005C7C2 File Offset: 0x0005ABC2
	public static int2 operator *(int2 a, int2 b)
	{
		return new int2(a.x * b.x, a.y * b.y);
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x0005C7E7 File Offset: 0x0005ABE7
	public static int2 operator /(int2 a, int2 b)
	{
		return new int2(a.x / b.x, a.y / b.y);
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x0005C80C File Offset: 0x0005AC0C
	public static int2 operator +(int2 a, int b)
	{
		return new int2(a.x + b, a.y + b);
	}

	// Token: 0x06000A7A RID: 2682 RVA: 0x0005C825 File Offset: 0x0005AC25
	public static int2 operator -(int2 a, int b)
	{
		return new int2(a.x - b, a.y - b);
	}

	// Token: 0x06000A7B RID: 2683 RVA: 0x0005C83E File Offset: 0x0005AC3E
	public static int2 operator *(int2 a, int b)
	{
		return new int2(a.x * b, a.y * b);
	}

	// Token: 0x06000A7C RID: 2684 RVA: 0x0005C857 File Offset: 0x0005AC57
	public static int2 operator /(int2 a, int b)
	{
		return new int2(a.x / b, a.y / b);
	}

	// Token: 0x04000C6E RID: 3182
	public int x;

	// Token: 0x04000C6F RID: 3183
	public int y;
}
