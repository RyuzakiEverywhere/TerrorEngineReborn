using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x02000183 RID: 387
	public interface IPathTerrain : IPlanningWorld
	{
		// Token: 0x06000933 RID: 2355
		int GetPathNodeIndex(Vector3 pos);

		// Token: 0x06000934 RID: 2356
		Vector3 GetPathNodePos(int index);

		// Token: 0x06000935 RID: 2357
		void ComputePortalsForPathSmoothing(Vector3[] roughPath, out Vector3[] aPortalLeftEndPts, out Vector3[] aPortalRightEndPts);

		// Token: 0x06000936 RID: 2358
		bool IsInBounds(Vector3 position);

		// Token: 0x06000937 RID: 2359
		Vector3 GetValidPathFloorPos(Vector3 position);

		// Token: 0x06000938 RID: 2360
		float GetTerrainHeight(Vector3 position);
	}
}
