using System;
using System.Collections.Generic;
using SimpleAI;
using SimpleAI.Navigation;
using UnityEngine;

// Token: 0x0200017A RID: 378
public class PathManagerComponent : MonoBehaviour
{
	// Token: 0x1700008D RID: 141
	// (get) Token: 0x060008F5 RID: 2293 RVA: 0x00051819 File Offset: 0x0004FC19
	public IPathTerrain PathTerrain
	{
		get
		{
			return this.m_pathTerrainComponent.PathTerrain;
		}
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x00051828 File Offset: 0x0004FC28
	private void Awake()
	{
		this.m_bInitialized = false;
		if (this.m_maxNumberOfNodesPerPlanner == 0)
		{
			Debug.LogError(" 'Max Number Of Nodes Per Planner' must be set to a value greater than 0. Try 100.");
			return;
		}
		if (this.m_maxNumberOfPlanners == 0)
		{
			Debug.LogError(" 'Max Number Of Planners' must be set to a value greater than 0. Try 20.");
			return;
		}
		this.m_pathPlannerPool = new Pool<PathPlanner>(this.m_maxNumberOfPlanners);
		foreach (Pool<PathPlanner>.Node node in this.m_pathPlannerPool.AllNodes)
		{
			node.Item.Awake(this.m_maxNumberOfNodesPerPlanner);
		}
		this.m_requestPool = new Queue<PathRequest>(this.m_maxNumberOfPlanners);
		for (int i = 0; i < this.m_maxNumberOfPlanners; i++)
		{
			this.m_requestPool.Enqueue(new PathRequest());
		}
		this.m_activeRequests = new LinkedList<PathRequest>();
		this.m_completedRequests = new LinkedList<PathRequest>();
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x00051924 File Offset: 0x0004FD24
	private void Start()
	{
		if (this.m_pathTerrainComponent == null)
		{
			Debug.LogError("Must give the PathManagerComponent a reference to the PathTerrainComponent. You can do this through the Unity Editor.");
			return;
		}
		this.m_terrain = this.m_pathTerrainComponent.PathTerrain;
		if (this.m_terrain == null)
		{
			Debug.LogError("PathTerrain is NULL in PathTerrainComponent. Make sure you have instantiated a path terrain inside the Awake functionof your PathTerrainComponent");
			return;
		}
		foreach (Pool<PathPlanner>.Node node in this.m_pathPlannerPool.AllNodes)
		{
			node.Item.Start(this.m_terrain);
		}
		this.m_bInitialized = true;
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x000519D8 File Offset: 0x0004FDD8
	public void Update()
	{
		if (!this.m_bInitialized)
		{
			Debug.LogError("PathManagerComponent failed to initialized. Can't call Update.");
			return;
		}
		this.UpdateActiveRequests(Time.deltaTime);
		this.UpdateCompletedRequests(Time.deltaTime);
		int num = 0;
		LinkedList<PathRequest> linkedList = new LinkedList<PathRequest>();
		foreach (PathRequest pathRequest in this.m_activeRequests)
		{
			PathPlanner item = pathRequest.PathPlanner.Item;
			int num2 = item.Update(this.m_maxNumberOfCyclesPerPlanner);
			num += num2;
			if (item.HasPlanFailed())
			{
				this.OnRequestCompleted(pathRequest, false);
				linkedList.AddFirst(pathRequest);
			}
			else if (item.HasPlanSucceeded())
			{
				this.OnRequestCompleted(pathRequest, true);
				linkedList.AddFirst(pathRequest);
			}
			if (num >= this.m_maxNumberOfCyclesPerFrame)
			{
				break;
			}
		}
		foreach (PathRequest pathRequest2 in linkedList)
		{
			this.m_activeRequests.Remove(pathRequest2);
			if (pathRequest2.HasFailed())
			{
				this.RemoveRequest(pathRequest2);
			}
		}
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x00051B38 File Offset: 0x0004FF38
	public IPathRequestQuery RequestPathPlan(PathPlanParams pathPlanParams, IPathAgent agent)
	{
		if (!this.m_bInitialized)
		{
			Debug.LogError("PathManagerComponent isn't yet fully intialized. Wait until Start() has been called. Can't call RequestPathPlan.");
			return null;
		}
		if (this.m_requestPool.Count == 0)
		{
			Debug.Log("RequestPathPlan failed because it is already servicing the maximum number of requests: " + this.m_maxNumberOfPlanners.ToString());
			return null;
		}
		if (this.m_pathPlannerPool.AvailableCount == 0)
		{
			Debug.Log("RequestPathPlan failed because it is already servicing the maximum number of path requests: " + this.m_maxNumberOfPlanners.ToString());
			return null;
		}
		pathPlanParams.UpdateStartAndGoalPos(this.m_terrain.GetValidPathFloorPos(pathPlanParams.StartPos));
		if (this.m_activeRequests.Count > 0)
		{
			foreach (PathRequest pathRequest in this.m_activeRequests)
			{
				if (pathRequest.Agent.GetHashCode() == agent.GetHashCode())
				{
					return null;
				}
			}
		}
		if (this.m_activeRequests.Count > 0)
		{
			foreach (PathRequest pathRequest2 in this.m_completedRequests)
			{
				if (pathRequest2.Agent.GetHashCode() == agent.GetHashCode())
				{
					return null;
				}
			}
		}
		Pool<PathPlanner>.Node pathPlanner = this.m_pathPlannerPool.Get();
		PathRequest pathRequest3 = this.m_requestPool.Dequeue();
		pathRequest3.Set(pathPlanParams, pathPlanner, agent);
		this.m_activeRequests.AddFirst(pathRequest3);
		int pathNodeIndex = this.m_terrain.GetPathNodeIndex(pathPlanParams.StartPos);
		int pathNodeIndex2 = this.m_terrain.GetPathNodeIndex(pathPlanParams.GoalPos);
		pathPlanner.Item.StartANewPlan(pathNodeIndex, pathNodeIndex2);
		return pathRequest3;
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x00051D30 File Offset: 0x00050130
	public void RemoveRequest(IPathRequestQuery requestQuery)
	{
		if (!this.m_bInitialized)
		{
			Debug.LogError("PathManagerComponent isn't yet fully intialized. Wait until Start() has been called. Can't call ConsumeRequest.");
			return;
		}
		if (requestQuery == null)
		{
			return;
		}
		PathRequest pathRequest = this.GetPathRequest(requestQuery);
		if (pathRequest == null)
		{
			return;
		}
		this.m_completedRequests.Remove(pathRequest);
		this.m_activeRequests.Remove(pathRequest);
		this.m_pathPlannerPool.Return(pathRequest.PathPlanner);
		this.m_requestPool.Enqueue(pathRequest);
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x00051DA0 File Offset: 0x000501A0
	private void OnRequestCompleted(PathRequest request, bool bSucceeded)
	{
		if (bSucceeded)
		{
			this.OnRequestSucceeded(request);
		}
		else
		{
			this.OnRequestFailed(request);
		}
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x00051DBB File Offset: 0x000501BB
	private void OnRequestFailed(PathRequest request)
	{
		request.Agent.OnPathAgentRequestFailed();
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x00051DC8 File Offset: 0x000501C8
	private void OnRequestSucceeded(PathRequest request)
	{
		this.m_completedRequests.AddFirst(request);
		request.Agent.OnPathAgentRequestSucceeded(request);
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x00051DE4 File Offset: 0x000501E4
	private void UpdateActiveRequests(float deltaTimeInSeconds)
	{
		foreach (PathRequest pathRequest in this.m_activeRequests)
		{
			pathRequest.Update(deltaTimeInSeconds);
		}
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x00051E40 File Offset: 0x00050240
	private void UpdateCompletedRequests(float deltaTimeInSeconds)
	{
		LinkedList<PathRequest> linkedList = new LinkedList<PathRequest>();
		foreach (PathRequest pathRequest in this.m_completedRequests)
		{
			pathRequest.Update(deltaTimeInSeconds);
			if (pathRequest.IsReadyToReplan())
			{
				pathRequest.PlanParams.UpdateStartAndGoalPos(pathRequest.Agent.GetPathAgentFootPos());
				pathRequest.RestartReplanTimer();
				linkedList.AddFirst(pathRequest);
				this.m_activeRequests.AddFirst(pathRequest);
				int pathNodeIndex = this.m_terrain.GetPathNodeIndex(pathRequest.PlanParams.StartPos);
				int pathNodeIndex2 = this.m_terrain.GetPathNodeIndex(pathRequest.PlanParams.GoalPos);
				pathRequest.PathPlanner.Item.StartANewPlan(pathNodeIndex, pathNodeIndex2);
			}
		}
		foreach (PathRequest value in linkedList)
		{
			this.m_completedRequests.Remove(value);
		}
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x00051F74 File Offset: 0x00050374
	private PathRequest GetPathRequest(IPathRequestQuery requestQuery)
	{
		PathRequest result = null;
		if (requestQuery is PathRequest)
		{
			result = (requestQuery as PathRequest);
		}
		return result;
	}

	// Token: 0x04000AF1 RID: 2801
	public PathTerrainComponent m_pathTerrainComponent;

	// Token: 0x04000AF2 RID: 2802
	public int m_maxNumberOfNodesPerPlanner = 100;

	// Token: 0x04000AF3 RID: 2803
	public int m_maxNumberOfPlanners = 20;

	// Token: 0x04000AF4 RID: 2804
	public int m_maxNumberOfCyclesPerFrame = 500;

	// Token: 0x04000AF5 RID: 2805
	public int m_maxNumberOfCyclesPerPlanner = 50;

	// Token: 0x04000AF6 RID: 2806
	private Pool<PathPlanner> m_pathPlannerPool;

	// Token: 0x04000AF7 RID: 2807
	private Queue<PathRequest> m_requestPool;

	// Token: 0x04000AF8 RID: 2808
	private LinkedList<PathRequest> m_activeRequests;

	// Token: 0x04000AF9 RID: 2809
	private LinkedList<PathRequest> m_completedRequests;

	// Token: 0x04000AFA RID: 2810
	private IPathTerrain m_terrain;

	// Token: 0x04000AFB RID: 2811
	private bool m_bInitialized;
}
