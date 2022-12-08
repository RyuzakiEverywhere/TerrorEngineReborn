using System;

namespace SimpleAI.Navigation
{
	// Token: 0x02000182 RID: 386
	public interface IPlanningWorld
	{
		// Token: 0x0600092E RID: 2350
		int GetNeighbors(int index, ref int[] neighbors);

		// Token: 0x0600092F RID: 2351
		int GetNumNodes();

		// Token: 0x06000930 RID: 2352
		float GetHCost(int startNodeIndex, int destNodeIndex);

		// Token: 0x06000931 RID: 2353
		float GetGCost(int startNodeIndex, int destNodeIndex);

		// Token: 0x06000932 RID: 2354
		bool IsNodeBlocked(int index);
	}
}
