using System;

// Token: 0x02000275 RID: 629
public class csMersenneTwister
{
	// Token: 0x06001217 RID: 4631 RVA: 0x00074F38 File Offset: 0x00073338
	public void Constructor()
	{
		this.init_genrand((uint)DateTime.Now.Millisecond);
	}

	// Token: 0x06001218 RID: 4632 RVA: 0x00074F58 File Offset: 0x00073358
	public void Constructor(int seed)
	{
		this.init_genrand((uint)seed);
	}

	// Token: 0x06001219 RID: 4633 RVA: 0x00074F64 File Offset: 0x00073364
	public void Constructor(int[] init)
	{
		uint[] array = new uint[init.Length];
		for (int i = 0; i < init.Length; i++)
		{
			array[i] = (uint)init[i];
		}
		this.init_by_array(array, (uint)array.Length);
	}

	// Token: 0x17000336 RID: 822
	// (get) Token: 0x0600121A RID: 4634 RVA: 0x00074F9E File Offset: 0x0007339E
	public static int MaxRandomInt
	{
		get
		{
			return int.MaxValue;
		}
	}

	// Token: 0x0600121B RID: 4635 RVA: 0x00074FA5 File Offset: 0x000733A5
	public int Next()
	{
		return this.genrand_int31();
	}

	// Token: 0x0600121C RID: 4636 RVA: 0x00074FAD File Offset: 0x000733AD
	public int Next(int maxValue)
	{
		return this.Next(0, maxValue);
	}

	// Token: 0x0600121D RID: 4637 RVA: 0x00074FB8 File Offset: 0x000733B8
	public int Next(int minValue, int maxValue)
	{
		if (minValue > maxValue)
		{
			int num = maxValue;
			maxValue = minValue;
			minValue = num;
		}
		return (int)Math.Floor((double)(maxValue - minValue + 1) * this.genrand_real1() + (double)minValue);
	}

	// Token: 0x0600121E RID: 4638 RVA: 0x00074FEA File Offset: 0x000733EA
	public float NextFloat()
	{
		return (float)this.genrand_real2();
	}

	// Token: 0x0600121F RID: 4639 RVA: 0x00074FF3 File Offset: 0x000733F3
	public float NextFloat(bool includeOne)
	{
		if (includeOne)
		{
			return (float)this.genrand_real1();
		}
		return (float)this.genrand_real2();
	}

	// Token: 0x06001220 RID: 4640 RVA: 0x0007500A File Offset: 0x0007340A
	public float NextFloatPositive()
	{
		return (float)this.genrand_real3();
	}

	// Token: 0x06001221 RID: 4641 RVA: 0x00075013 File Offset: 0x00073413
	public double NextDouble()
	{
		return this.genrand_real2();
	}

	// Token: 0x06001222 RID: 4642 RVA: 0x0007501B File Offset: 0x0007341B
	public double NextDouble(bool includeOne)
	{
		if (includeOne)
		{
			return this.genrand_real1();
		}
		return this.genrand_real2();
	}

	// Token: 0x06001223 RID: 4643 RVA: 0x00075030 File Offset: 0x00073430
	public double NextDoublePositive()
	{
		return this.genrand_real3();
	}

	// Token: 0x06001224 RID: 4644 RVA: 0x00075038 File Offset: 0x00073438
	public double Next53BitRes()
	{
		return this.genrand_res53();
	}

	// Token: 0x06001225 RID: 4645 RVA: 0x00075040 File Offset: 0x00073440
	public void Initialize()
	{
		this.init_genrand((uint)DateTime.Now.Millisecond);
	}

	// Token: 0x06001226 RID: 4646 RVA: 0x00075060 File Offset: 0x00073460
	public void Initialize(int seed)
	{
		this.init_genrand((uint)seed);
	}

	// Token: 0x06001227 RID: 4647 RVA: 0x0007506C File Offset: 0x0007346C
	public void Initialize(int[] init)
	{
		uint[] array = new uint[init.Length];
		for (int i = 0; i < init.Length; i++)
		{
			array[i] = (uint)init[i];
		}
		this.init_by_array(array, (uint)array.Length);
	}

	// Token: 0x06001228 RID: 4648 RVA: 0x000750A8 File Offset: 0x000734A8
	private void init_genrand(uint s)
	{
		this.mt[0] = (s & uint.MaxValue);
		this.mti = 1;
		while (this.mti < 624)
		{
			this.mt[this.mti] = (uint)((ulong)(1812433253U * (this.mt[this.mti - 1] ^ this.mt[this.mti - 1] >> 30)) + (ulong)((long)this.mti));
			this.mt[this.mti] &= uint.MaxValue;
			this.mti++;
		}
	}

	// Token: 0x06001229 RID: 4649 RVA: 0x00075140 File Offset: 0x00073540
	private void init_by_array(uint[] init_key, uint key_length)
	{
		this.init_genrand(19650218U);
		int num = 1;
		int num2 = 0;
		for (int i = (int)((624U <= key_length) ? key_length : 624U); i > 0; i--)
		{
			this.mt[num] = (uint)((ulong)((this.mt[num] ^ (this.mt[num - 1] ^ this.mt[num - 1] >> 30) * 1664525U) + init_key[num2]) + (ulong)((long)num2));
			this.mt[num] &= uint.MaxValue;
			num++;
			num2++;
			if (num >= 624)
			{
				this.mt[0] = this.mt[623];
				num = 1;
			}
			if ((long)num2 >= (long)((ulong)key_length))
			{
				num2 = 0;
			}
		}
		for (int i = 623; i > 0; i--)
		{
			this.mt[num] = (uint)((ulong)(this.mt[num] ^ (this.mt[num - 1] ^ this.mt[num - 1] >> 30) * 1566083941U) - (ulong)((long)num));
			this.mt[num] &= uint.MaxValue;
			num++;
			if (num >= 624)
			{
				this.mt[0] = this.mt[623];
				num = 1;
			}
		}
		this.mt[0] = 2147483648U;
	}

	// Token: 0x0600122A RID: 4650 RVA: 0x00075290 File Offset: 0x00073690
	private uint genrand_int32()
	{
		uint num;
		if (this.mti >= 624)
		{
			if (this.mti == 625)
			{
				this.init_genrand(5489U);
			}
			int i;
			for (i = 0; i < 227; i++)
			{
				num = ((this.mt[i] & 2147483648U) | (this.mt[i + 1] & 2147483647U));
				this.mt[i] = (this.mt[i + 397] ^ num >> 1 ^ this.mag01[(int)((UIntPtr)(num & 1U))]);
			}
			while (i < 623)
			{
				num = ((this.mt[i] & 2147483648U) | (this.mt[i + 1] & 2147483647U));
				this.mt[i] = (this.mt[i + -227] ^ num >> 1 ^ this.mag01[(int)((UIntPtr)(num & 1U))]);
				i++;
			}
			num = ((this.mt[623] & 2147483648U) | (this.mt[0] & 2147483647U));
			this.mt[623] = (this.mt[396] ^ num >> 1 ^ this.mag01[(int)((UIntPtr)(num & 1U))]);
			this.mti = 0;
		}
		num = this.mt[this.mti++];
		num ^= num >> 11;
		num ^= (num << 7 & 2636928640U);
		num ^= (num << 15 & 4022730752U);
		return num ^ num >> 18;
	}

	// Token: 0x0600122B RID: 4651 RVA: 0x00075410 File Offset: 0x00073810
	private int genrand_int31()
	{
		return (int)(this.genrand_int32() >> 1);
	}

	// Token: 0x0600122C RID: 4652 RVA: 0x0007541A File Offset: 0x0007381A
	private double genrand_real1()
	{
		return this.genrand_int32() * 2.3283064370807974E-10;
	}

	// Token: 0x0600122D RID: 4653 RVA: 0x0007542E File Offset: 0x0007382E
	private double genrand_real2()
	{
		return this.genrand_int32() * 2.3283064365386963E-10;
	}

	// Token: 0x0600122E RID: 4654 RVA: 0x00075442 File Offset: 0x00073842
	private double genrand_real3()
	{
		return (this.genrand_int32() + 0.5) * 2.3283064365386963E-10;
	}

	// Token: 0x0600122F RID: 4655 RVA: 0x00075460 File Offset: 0x00073860
	private double genrand_res53()
	{
		uint num = this.genrand_int32() >> 5;
		uint num2 = this.genrand_int32() >> 6;
		return (num * 67108864.0 + num2) * 1.1102230246251565E-16;
	}

	// Token: 0x04001279 RID: 4729
	private const int N = 624;

	// Token: 0x0400127A RID: 4730
	private const int M = 397;

	// Token: 0x0400127B RID: 4731
	private const uint MATRIX_A = 2567483615U;

	// Token: 0x0400127C RID: 4732
	private const uint UPPER_MASK = 2147483648U;

	// Token: 0x0400127D RID: 4733
	private const uint LOWER_MASK = 2147483647U;

	// Token: 0x0400127E RID: 4734
	private const int MAX_RAND_INT = 2147483647;

	// Token: 0x0400127F RID: 4735
	private uint[] mag01 = new uint[]
	{
		0U,
		2567483615U
	};

	// Token: 0x04001280 RID: 4736
	private uint[] mt = new uint[624];

	// Token: 0x04001281 RID: 4737
	private int mti = 625;
}
