using System;

namespace SimpleAI
{
	// Token: 0x02000199 RID: 409
	public static class FlagUtils
	{
		// Token: 0x060009C4 RID: 2500 RVA: 0x00054BF0 File Offset: 0x00052FF0
		public static bool TestFlag(int flags, int flag)
		{
			return (flags & flag) != 0;
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x00054BFB File Offset: 0x00052FFB
		public static int SetFlag(int flags, int flag)
		{
			return flags |= flag;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00054C03 File Offset: 0x00053003
		public static int ClearFlag(int flags, int flag)
		{
			return flags & ~flag;
		}
	}
}
