using System;
using System.Collections.Generic;

// Token: 0x0200013E RID: 318
public class PBitStream
{
	// Token: 0x06000749 RID: 1865 RVA: 0x00047D3A File Offset: 0x0004613A
	public PBitStream()
	{
		this.streamBytes = new List<byte>(1);
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x00047D4E File Offset: 0x0004614E
	public PBitStream(int bitCount)
	{
		this.streamBytes = new List<byte>(PBitStream.BytesForBits(bitCount));
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x00047D67 File Offset: 0x00046167
	public PBitStream(IEnumerable<byte> bytes, int bitCount)
	{
		this.streamBytes = new List<byte>(bytes);
		this.BitCount = bitCount;
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x0600074C RID: 1868 RVA: 0x00047D82 File Offset: 0x00046182
	public int ByteCount
	{
		get
		{
			return PBitStream.BytesForBits(this.totalBits);
		}
	}

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x0600074D RID: 1869 RVA: 0x00047D8F File Offset: 0x0004618F
	// (set) Token: 0x0600074E RID: 1870 RVA: 0x00047D97 File Offset: 0x00046197
	public int BitCount
	{
		get
		{
			return this.totalBits;
		}
		private set
		{
			this.totalBits = value;
		}
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00047DA0 File Offset: 0x000461A0
	public static int BytesForBits(int bitCount)
	{
		if (bitCount <= 0)
		{
			return 0;
		}
		return (bitCount - 1) / 8 + 1;
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x00047DB4 File Offset: 0x000461B4
	public void Add(bool val)
	{
		int num = this.totalBits / 8;
		if (num > this.streamBytes.Count - 1 || this.totalBits == 0)
		{
			this.streamBytes.Add(0);
		}
		if (val)
		{
			int num2 = 7 - this.totalBits % 8;
			List<byte> list;
			int index;
			(list = this.streamBytes)[index = num] = (list[index] | (byte)(1 << num2));
		}
		this.totalBits++;
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x00047E33 File Offset: 0x00046233
	public byte[] ToBytes()
	{
		return this.streamBytes.ToArray();
	}

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x06000752 RID: 1874 RVA: 0x00047E40 File Offset: 0x00046240
	// (set) Token: 0x06000753 RID: 1875 RVA: 0x00047E48 File Offset: 0x00046248
	public int Position { get; set; }

	// Token: 0x06000754 RID: 1876 RVA: 0x00047E54 File Offset: 0x00046254
	public bool GetNext()
	{
		if (this.Position > this.totalBits)
		{
			throw new Exception("End of PBitStream reached. Can't read more.");
		}
		return this.Get(this.Position++);
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x00047E94 File Offset: 0x00046294
	public bool Get(int bitIndex)
	{
		int index = bitIndex / 8;
		int num = 7 - bitIndex % 8;
		return (this.streamBytes[index] & (byte)(1 << num)) > 0;
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x00047EC4 File Offset: 0x000462C4
	public void Set(int bitIndex, bool value)
	{
		int num = bitIndex / 8;
		int num2 = 7 - bitIndex % 8;
		List<byte> list;
		int index;
		(list = this.streamBytes)[index = num] = (list[index] | (byte)(1 << num2));
	}

	// Token: 0x040009D9 RID: 2521
	private List<byte> streamBytes;

	// Token: 0x040009DA RID: 2522
	private int currentByte;

	// Token: 0x040009DB RID: 2523
	private int totalBits;
}
