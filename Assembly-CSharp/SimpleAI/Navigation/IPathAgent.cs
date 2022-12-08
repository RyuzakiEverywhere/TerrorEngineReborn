using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x02000181 RID: 385
	public interface IPathAgent
	{
		// Token: 0x0600092B RID: 2347
		Vector3 GetPathAgentFootPos();

		// Token: 0x0600092C RID: 2348
		void OnPathAgentRequestSucceeded(IPathRequestQuery request);

		// Token: 0x0600092D RID: 2349
		void OnPathAgentRequestFailed();
	}
}
