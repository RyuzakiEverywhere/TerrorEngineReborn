using System;
using UnityEngine;

namespace SimpleAI.Steering
{
	// Token: 0x0200018D RID: 397
	public class Pathway
	{
		// Token: 0x06000972 RID: 2418 RVA: 0x00054031 File Offset: 0x00052431
		public virtual Vector3 MapPathDistanceToPoint(float pathDistance)
		{
			return Vector3.zero;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00054038 File Offset: 0x00052438
		public virtual float MapPointToPathDistance(Vector3 point)
		{
			return 0f;
		}
	}
}
