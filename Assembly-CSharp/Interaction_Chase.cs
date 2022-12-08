using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200016C RID: 364
public class Interaction_Chase : MonoBehaviour
{
	// Token: 0x0600089B RID: 2203 RVA: 0x0004FF33 File Offset: 0x0004E333
	private void OnEnable()
	{
		this.m_navigationAgent = base.GetComponent<NavMeshAgent>();
		this.m_navigationAgent.ResetPath();
	}

	// Token: 0x0600089C RID: 2204 RVA: 0x0004FF4C File Offset: 0x0004E34C
	private void Update()
	{
		this.m_chaseObject = base.GetComponent<FindPlayers>().target;
		Vector3 destination = this.m_chaseObject.transform.position + Vector3.up;
		this.m_navigationAgent.SetDestination(destination);
	}

	// Token: 0x04000AAD RID: 2733
	public GameObject m_chaseObject;

	// Token: 0x04000AAE RID: 2734
	public float m_replanInterval = 0.5f;

	// Token: 0x04000AAF RID: 2735
	public bool hasmod;

	// Token: 0x04000AB0 RID: 2736
	public GameObject model;

	// Token: 0x04000AB1 RID: 2737
	private NavMeshAgent m_navigationAgent;
}
