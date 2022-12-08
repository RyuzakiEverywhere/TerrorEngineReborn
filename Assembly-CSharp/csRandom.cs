using System;

// Token: 0x02000276 RID: 630
public sealed class csRandom
{
	// Token: 0x06001230 RID: 4656 RVA: 0x0007549A File Offset: 0x0007389A
	private csRandom()
	{
	}

	// Token: 0x17000337 RID: 823
	// (get) Token: 0x06001231 RID: 4657 RVA: 0x000754AD File Offset: 0x000738AD
	public static csRandom Instance
	{
		get
		{
			return csRandom.Nested.instance;
		}
	}

	// Token: 0x06001232 RID: 4658 RVA: 0x000754B4 File Offset: 0x000738B4
	public int Next(int maxValue)
	{
		return this.mersenneTwister.Next(maxValue);
	}

	// Token: 0x06001233 RID: 4659 RVA: 0x000754C2 File Offset: 0x000738C2
	public int Next(int minValue, int maxValue)
	{
		return this.mersenneTwister.Next(minValue, maxValue);
	}

	// Token: 0x04001282 RID: 4738
	private readonly csMersenneTwister mersenneTwister = new csMersenneTwister();

	// Token: 0x02000277 RID: 631
	private class Nested
	{
		// Token: 0x04001283 RID: 4739
		internal static readonly csRandom instance = new csRandom();
	}
}
