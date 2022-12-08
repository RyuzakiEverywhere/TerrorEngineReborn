using System;
using SimpleAI.Navigation;
using UnityEngine;

// Token: 0x02000178 RID: 376
public class PathAgentComponent : MonoBehaviour, IPathAgent
{
	// Token: 0x17000089 RID: 137
	// (get) Token: 0x060008E3 RID: 2275 RVA: 0x00051469 File Offset: 0x0004F869
	public IPathRequestQuery PathRequestQuery
	{
		get
		{
			return this.m_query;
		}
	}

	// Token: 0x1700008A RID: 138
	// (get) Token: 0x060008E4 RID: 2276 RVA: 0x00051471 File Offset: 0x0004F871
	public PathManagerComponent PathManager
	{
		get
		{
			return this.m_pathManager;
		}
	}

	// Token: 0x1700008B RID: 139
	// (get) Token: 0x060008E5 RID: 2277 RVA: 0x00051479 File Offset: 0x0004F879
	// (set) Token: 0x060008E6 RID: 2278 RVA: 0x00051481 File Offset: 0x0004F881
	public bool ShowPath
	{
		get
		{
			return this.m_debugShowPath;
		}
		set
		{
			this.m_debugShowPath = value;
		}
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x0005148A File Offset: 0x0004F88A
	private void Start()
	{
		this.pathobj = GameObject.Find("PathManager");
		this.m_pathManager = this.pathobj.GetComponent<PathManagerComponent>();
	}

	// Token: 0x060008E8 RID: 2280 RVA: 0x000514B0 File Offset: 0x0004F8B0
	private void Awake()
	{
		this.pathobj = GameObject.Find("PathManager");
		this.m_pathManager = this.pathobj.GetComponent<PathManagerComponent>();
		this.m_bInitialized = false;
		this.m_query = null;
		if (this.m_pathManager == null)
		{
			Debug.LogError("PathAgentComponent does not have a PathManagerComponent set. You need to set this up through the Inspector window");
		}
		else
		{
			this.m_bInitialized = true;
		}
	}

	// Token: 0x060008E9 RID: 2281 RVA: 0x00051514 File Offset: 0x0004F914
	private void OnDrawGizmos()
	{
		if (this.m_debugShowPath && this.m_bInitialized && this.HasActiveRequest() && this.PathRequestQuery.HasSuccessfullyCompleted())
		{
			Gizmos.color = this.m_debugPathColor;
			Vector3[] solutionPath = this.PathRequestQuery.GetSolutionPath(this.PathManager.PathTerrain);
			for (int i = 1; i < solutionPath.Length; i++)
			{
				Vector3 from = solutionPath[i - 1];
				Vector3 to = solutionPath[i];
				Gizmos.DrawLine(from, to);
			}
		}
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x000515AC File Offset: 0x0004F9AC
	public bool RequestPath(PathPlanParams pathPlanParams)
	{
		if (!this.m_bInitialized)
		{
			return false;
		}
		this.m_pathManager.RemoveRequest(this.m_query);
		this.m_query = this.m_pathManager.RequestPathPlan(pathPlanParams, this);
		return this.m_query != null;
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x000515F8 File Offset: 0x0004F9F8
	public bool HasActiveRequest()
	{
		return this.m_query != null;
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x00051606 File Offset: 0x0004FA06
	public void CancelActiveRequest()
	{
		if (this.m_query == null)
		{
			return;
		}
		this.m_pathManager.RemoveRequest(this.m_query);
		this.m_query = null;
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x0005162C File Offset: 0x0004FA2C
	public Vector3 GetPathAgentFootPos()
	{
		return this.m_pathManager.PathTerrain.GetValidPathFloorPos(base.transform.position);
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x00051649 File Offset: 0x0004FA49
	public void OnPathAgentRequestSucceeded(IPathRequestQuery request)
	{
		base.SendMessageUpwards("OnPathRequestSucceeded", request, SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x00051658 File Offset: 0x0004FA58
	public void OnPathAgentRequestFailed()
	{
		this.m_query = null;
		base.SendMessageUpwards("OnPathRequestFailed", SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x04000AE3 RID: 2787
	public PathManagerComponent m_pathManager;

	// Token: 0x04000AE4 RID: 2788
	public GameObject pathobj;

	// Token: 0x04000AE5 RID: 2789
	public Color m_debugPathColor = Color.yellow;

	// Token: 0x04000AE6 RID: 2790
	public Color m_debugGoalColor = Color.red;

	// Token: 0x04000AE7 RID: 2791
	public bool m_debugShowPath;

	// Token: 0x04000AE8 RID: 2792
	private IPathRequestQuery m_query;

	// Token: 0x04000AE9 RID: 2793
	private bool m_bInitialized;
}
