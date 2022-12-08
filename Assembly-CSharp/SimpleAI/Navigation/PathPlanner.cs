using System;
using SimpleAI.Planning;

namespace SimpleAI.Navigation
{
	// Token: 0x02000189 RID: 393
	public class PathPlanner : AStarPlanner
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x00053AC4 File Offset: 0x00051EC4
		public IPathTerrain PathTerrain
		{
			get
			{
				return this.m_pathTerrain;
			}
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00053ACC File Offset: 0x00051ECC
		public override void Start(IPlanningWorld world)
		{
			base.Start(world);
			this.m_pathTerrain = (world as IPathTerrain);
		}

		// Token: 0x04000B26 RID: 2854
		private IPathTerrain m_pathTerrain;
	}
}
