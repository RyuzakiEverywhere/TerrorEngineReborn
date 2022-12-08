using System;

namespace SimpleAI.Planning
{
	// Token: 0x02000192 RID: 402
	public abstract class SuccessCondition
	{
		// Token: 0x060009A2 RID: 2466
		public abstract bool Evaluate(Node currentNode);
	}
}
