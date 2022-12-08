using System;
using System.Collections.Generic;
using SimpleAI.Planning;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x0200018B RID: 395
	public class PathRequest : IComparable<PathRequest>, IPathRequestQuery
	{
		// Token: 0x0600095B RID: 2395 RVA: 0x00053AE1 File Offset: 0x00051EE1
		public PathRequest()
		{
			this.m_priority = 0;
			this.m_replanTimeRemaining = 0f;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x00053AFB File Offset: 0x00051EFB
		public int Priority
		{
			get
			{
				return this.m_priority;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600095D RID: 2397 RVA: 0x00053B03 File Offset: 0x00051F03
		public Pool<PathPlanner>.Node PathPlanner
		{
			get
			{
				return this.m_pathPlanner;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x00053B0B File Offset: 0x00051F0B
		public PathPlanParams PlanParams
		{
			get
			{
				return this.m_pathPlanParams;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600095F RID: 2399 RVA: 0x00053B13 File Offset: 0x00051F13
		public IPathAgent Agent
		{
			get
			{
				return this.m_agent;
			}
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00053B1B File Offset: 0x00051F1B
		public void Set(PathPlanParams planParams, Pool<PathPlanner>.Node pathPlanner, IPathAgent agent)
		{
			this.m_pathPlanParams = planParams;
			this.m_pathPlanner = pathPlanner;
			this.m_replanTimeRemaining = planParams.ReplanInterval;
			this.m_agent = agent;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00053B3E File Offset: 0x00051F3E
		public void Update(float deltaTimeInSeconds)
		{
			this.m_replanTimeRemaining -= Convert.ToSingle(deltaTimeInSeconds);
			this.m_replanTimeRemaining = Math.Max(this.m_replanTimeRemaining, 0f);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00053B69 File Offset: 0x00051F69
		public bool IsReadyToReplan()
		{
			return this.m_replanTimeRemaining <= 0f;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x00053B7B File Offset: 0x00051F7B
		public void RestartReplanTimer()
		{
			this.m_replanTimeRemaining = this.m_pathPlanParams.ReplanInterval;
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x00053B8E File Offset: 0x00051F8E
		public int CompareTo(PathRequest other)
		{
			if (this.m_priority > other.Priority)
			{
				return -1;
			}
			if (this.m_priority < other.Priority)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x00053BB7 File Offset: 0x00051FB7
		public LinkedList<Node> GetSolutionPath()
		{
			return this.m_pathPlanner.Item.Solution;
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x00053BCC File Offset: 0x00051FCC
		public Vector3[] GetSolutionPath(IPathTerrain terrain)
		{
			if (!this.HasSuccessfullyCompleted())
			{
				return null;
			}
			LinkedList<Node> solutionPath = this.GetSolutionPath();
			if (solutionPath == null || solutionPath.Count == 0)
			{
				return null;
			}
			Vector3[] array = new Vector3[solutionPath.Count];
			int num = 0;
			foreach (Node node in solutionPath)
			{
				Vector3 pathNodePos = terrain.GetPathNodePos(node.Index);
				array[num] = pathNodePos;
				num++;
			}
			array[0] = this.GetStartPos();
			int num2 = Mathf.Clamp(num, 0, solutionPath.Count - 1);
			array[num2] = this.GetGoalPos();
			return array;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00053CAC File Offset: 0x000520AC
		public Vector3 GetStartPos()
		{
			return this.m_pathPlanParams.StartPos;
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x00053CB9 File Offset: 0x000520B9
		public Vector3 GetGoalPos()
		{
			return this.m_pathPlanParams.GoalPos;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00053CC6 File Offset: 0x000520C6
		public IPathAgent GetPathAgent()
		{
			return this.Agent;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00053CCE File Offset: 0x000520CE
		public bool HasCompleted()
		{
			return this.m_pathPlanner.Item.HasPlanCompleted();
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x00053CE0 File Offset: 0x000520E0
		public bool HasSuccessfullyCompleted()
		{
			return this.m_pathPlanner.Item.HasPlanSucceeded();
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00053CF2 File Offset: 0x000520F2
		public bool HasFailed()
		{
			return this.m_pathPlanner.Item.HasPlanFailed();
		}

		// Token: 0x04000B27 RID: 2855
		private int m_priority;

		// Token: 0x04000B28 RID: 2856
		private PathPlanParams m_pathPlanParams;

		// Token: 0x04000B29 RID: 2857
		private Pool<PathPlanner>.Node m_pathPlanner;

		// Token: 0x04000B2A RID: 2858
		private float m_replanTimeRemaining;

		// Token: 0x04000B2B RID: 2859
		private IPathAgent m_agent;
	}
}
