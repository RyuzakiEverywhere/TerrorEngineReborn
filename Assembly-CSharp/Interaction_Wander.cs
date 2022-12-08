using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200016E RID: 366
public class Interaction_Wander : MonoBehaviour
{
	// Token: 0x060008A3 RID: 2211 RVA: 0x00050129 File Offset: 0x0004E529
	private void OnEnable()
	{
		this.m_navigationAgent = base.GetComponent<NavMeshAgent>();
		this.m_navigationAgent.ResetPath();
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x00050144 File Offset: 0x0004E544
	private void Update()
	{
		this.m_navigationAgent = base.GetComponent<NavMeshAgent>();
		if (this.m_navigationAgent.remainingDistance <= this.m_navigationAgent.stoppingDistance)
		{
			this.destPos = this.ChooseRandomDestination();
		}
		this.m_navigationAgent.SetDestination(this.destPos);
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x00050198 File Offset: 0x0004E598
	private Vector3 ChooseRandomDestination()
	{
		float num = 10f;
		Vector3 vector = UnityEngine.Random.insideUnitSphere * num;
		vector += base.transform.position;
		NavMeshHit navMeshHit;
		NavMesh.SamplePosition(vector, out navMeshHit, num, -1);
		return navMeshHit.position;
	}

	// Token: 0x04000AB8 RID: 2744
	public float m_replanInterval = 0.5f;

	// Token: 0x04000AB9 RID: 2745
	private NavMeshAgent m_navigationAgent;

	// Token: 0x04000ABA RID: 2746
	private bool m_bNavRequestCompleted;

	// Token: 0x04000ABB RID: 2747
	private Vector3 destPos;
}
