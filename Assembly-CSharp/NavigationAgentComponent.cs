using System;
using SimpleAI.Navigation;
using UnityEngine;

// Token: 0x02000176 RID: 374
[RequireComponent(typeof(PathAgentComponent))]
[RequireComponent(typeof(SteeringAgentComponent))]
[RequireComponent(typeof(Rigidbody))]
public class NavigationAgentComponent : MonoBehaviour
{
	// Token: 0x17000088 RID: 136
	// (get) Token: 0x060008D4 RID: 2260 RVA: 0x00051036 File Offset: 0x0004F436
	public IPathTerrain PathTerrain
	{
		get
		{
			return this.m_pathAgent.PathManager.PathTerrain;
		}
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x00051048 File Offset: 0x0004F448
	private void Awake()
	{
		this.m_pathAgent = base.GetComponent<PathAgentComponent>();
		this.m_steeringAgent = base.GetComponent<SteeringAgentComponent>();
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x00051064 File Offset: 0x0004F464
	public bool MoveToPosition(Vector3 targetPosition, float replanInterval)
	{
		NavTargetPos target = new NavTargetPos(targetPosition, this.PathTerrain);
		PathPlanParams pathPlanParams = new PathPlanParams(base.transform.position, target, replanInterval);
		return this.m_pathAgent.RequestPath(pathPlanParams);
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x000510A0 File Offset: 0x0004F4A0
	public bool MoveToGameObject(GameObject gameObject, float replanInterval)
	{
		NavTargetGameObject target = new NavTargetGameObject(gameObject, this.PathTerrain);
		PathPlanParams pathPlanParams = new PathPlanParams(base.transform.position, target, replanInterval);
		return this.m_pathAgent.RequestPath(pathPlanParams);
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x000510D9 File Offset: 0x0004F4D9
	public void CancelActiveRequest()
	{
		this.m_steeringAgent.StopSteering();
		this.m_pathAgent.CancelActiveRequest();
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000510F4 File Offset: 0x0004F4F4
	private void OnPathRequestSucceeded(IPathRequestQuery request)
	{
		Vector3[] solutionPath = request.GetSolutionPath(this.m_pathAgent.PathManager.PathTerrain);
		Vector3[] path = solutionPath;
		if (this.m_usePathSmoothing)
		{
			Vector3[] aLeftPortalEndPts;
			Vector3[] aRightPortalEndPts;
			this.m_pathAgent.PathManager.PathTerrain.ComputePortalsForPathSmoothing(solutionPath, out aLeftPortalEndPts, out aRightPortalEndPts);
			path = PathSmoother.Smooth(solutionPath, request.GetStartPos(), request.GetGoalPos(), aLeftPortalEndPts, aRightPortalEndPts);
		}
		this.m_steeringAgent.SteerAlongPath(path, this.m_pathAgent.PathManager.PathTerrain);
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x00051170 File Offset: 0x0004F570
	private void OnPathRequestFailed()
	{
		this.m_steeringAgent.StopSteering();
		base.SendMessageUpwards("OnNavigationRequestFailed", SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x00051189 File Offset: 0x0004F589
	private void OnSteeringRequestSucceeded()
	{
		base.SendMessageUpwards("OnNavigationRequestSucceeded", SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x04000ADA RID: 2778
	public bool m_usePathSmoothing = true;

	// Token: 0x04000ADB RID: 2779
	private PathAgentComponent m_pathAgent;

	// Token: 0x04000ADC RID: 2780
	private SteeringAgentComponent m_steeringAgent;
}
