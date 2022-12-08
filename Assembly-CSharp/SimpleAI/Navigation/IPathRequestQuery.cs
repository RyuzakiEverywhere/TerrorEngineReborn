using System;
using System.Collections.Generic;
using SimpleAI.Planning;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x0200018A RID: 394
	public interface IPathRequestQuery
	{
		// Token: 0x06000953 RID: 2387
		LinkedList<Node> GetSolutionPath();

		// Token: 0x06000954 RID: 2388
		Vector3[] GetSolutionPath(IPathTerrain world);

		// Token: 0x06000955 RID: 2389
		Vector3 GetStartPos();

		// Token: 0x06000956 RID: 2390
		Vector3 GetGoalPos();

		// Token: 0x06000957 RID: 2391
		IPathAgent GetPathAgent();

		// Token: 0x06000958 RID: 2392
		bool HasCompleted();

		// Token: 0x06000959 RID: 2393
		bool HasSuccessfullyCompleted();

		// Token: 0x0600095A RID: 2394
		bool HasFailed();
	}
}
