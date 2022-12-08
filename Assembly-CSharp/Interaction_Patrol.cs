using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200016D RID: 365
public class Interaction_Patrol : MonoBehaviour
{
	// Token: 0x0600089E RID: 2206 RVA: 0x0004FFA5 File Offset: 0x0004E3A5
	private void Awake()
	{
		this.m_currentPatrolNodeGoalIndex = 0;
		this.m_bNavRequestCompleted = true;
		this.m_patrolNodes = GameObject.FindGameObjectsWithTag("PatrolNode");
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x0004FFC5 File Offset: 0x0004E3C5
	private void OnEnable()
	{
		this.m_navigationAgent = base.GetComponent<NavMeshAgent>();
		this.m_navigationAgent.ResetPath();
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x0004FFE0 File Offset: 0x0004E3E0
	private void Update()
	{
		this.m_navigationAgent = base.GetComponent<NavMeshAgent>();
		this.m_patrolNodes = GameObject.FindGameObjectsWithTag("PatrolNode");
		if (this.m_patrolNodes == null || this.m_patrolNodes.Length == 0)
		{
			Debug.LogError("No patrol nodes are set");
			return;
		}
		if (this.m_navigationAgent.remainingDistance <= this.m_navigationAgent.stoppingDistance)
		{
			this.m_currentPatrolNodeGoalIndex = (this.m_currentPatrolNodeGoalIndex + 1) % this.m_patrolNodes.Length;
			this.destPos = this.GetPatrolNodePosition(this.m_currentPatrolNodeGoalIndex);
			this.m_bNavRequestCompleted = false;
		}
		this.destPos = this.GetPatrolNodePosition(this.m_currentPatrolNodeGoalIndex);
		this.m_navigationAgent.SetDestination(this.destPos);
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x0005009C File Offset: 0x0004E49C
	private Vector3 GetPatrolNodePosition(int index)
	{
		if (this.m_patrolNodes == null || this.m_patrolNodes.Length == 0)
		{
			Debug.LogError("No patrol nodes are set");
			return base.transform.position;
		}
		if (index < 0 || index >= this.m_patrolNodes.Length)
		{
			Debug.LogError("PatrolNode index out of bounds");
			return base.transform.position;
		}
		return this.m_patrolNodes[index].transform.position;
	}

	// Token: 0x04000AB2 RID: 2738
	public GameObject[] m_patrolNodes;

	// Token: 0x04000AB3 RID: 2739
	public float m_replanInterval = float.MaxValue;

	// Token: 0x04000AB4 RID: 2740
	private NavMeshAgent m_navigationAgent;

	// Token: 0x04000AB5 RID: 2741
	private bool m_bNavRequestCompleted;

	// Token: 0x04000AB6 RID: 2742
	private int m_currentPatrolNodeGoalIndex;

	// Token: 0x04000AB7 RID: 2743
	private Vector3 destPos;
}
