using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x02000184 RID: 388
	public interface IHeightmap
	{
		// Token: 0x06000939 RID: 2361
		float SampleHeight(Vector3 position);
	}
}
