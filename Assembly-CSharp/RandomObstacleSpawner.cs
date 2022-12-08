using System;
using UnityEngine;

// Token: 0x02000170 RID: 368
public class RandomObstacleSpawner : MonoBehaviour
{
	// Token: 0x060008A8 RID: 2216 RVA: 0x000501FE File Offset: 0x0004E5FE
	private void Awake()
	{
		this.m_timeBeforeNextSpawn = this.m_spawnInterval;
		this.m_numObstaclesSpawned = 0;
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x00050213 File Offset: 0x0004E613
	private void Start()
	{
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x00050218 File Offset: 0x0004E618
	private void Update()
	{
		if (this.m_numObstaclesSpawned < this.m_spawnCount)
		{
			this.m_timeBeforeNextSpawn -= Time.deltaTime;
			if (this.m_timeBeforeNextSpawn <= 0f)
			{
				Vector3 vector = this.ChooseRandomSpawnPosition();
				if (vector != Vector3.zero)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.m_obstacle, vector, Quaternion.identity);
					this.m_timeBeforeNextSpawn = this.m_spawnInterval;
					this.m_numObstaclesSpawned++;
				}
				else
				{
					this.m_numObstaclesSpawned = this.m_spawnCount;
				}
			}
		}
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x000502AC File Offset: 0x0004E6AC
	private Vector3 ChooseRandomSpawnPosition()
	{
		PatrolNodeComponent[] array = (PatrolNodeComponent[])UnityEngine.Object.FindObjectsOfType(typeof(PatrolNodeComponent));
		PathAgentComponent[] array2 = (PathAgentComponent[])UnityEngine.Object.FindObjectsOfType(typeof(PathAgentComponent));
		Vector3 result = Vector3.zero;
		for (int i = 0; i < 100; i++)
		{
			int num = UnityEngine.Random.Range(0, this.m_pathGridComponent.PathGrid.NumberOfCells - 1);
			if (!this.m_pathGridComponent.PathGrid.IsBlocked(num))
			{
				bool flag = false;
				for (int j = 0; j < array.Length; j++)
				{
					Vector3 position = array[j].transform.position;
					int cellIndex = this.m_pathGridComponent.PathGrid.GetCellIndex(position);
					if (cellIndex == num)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					for (int k = 0; k < array2.Length; k++)
					{
						Vector3 position2 = array2[k].transform.position;
						int cellIndex2 = this.m_pathGridComponent.PathGrid.GetCellIndex(position2);
						if (cellIndex2 == num)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						result = this.m_pathGridComponent.PathGrid.GetCellCenter(num);
						break;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x04000ABC RID: 2748
	public PathGridComponent m_pathGridComponent;

	// Token: 0x04000ABD RID: 2749
	public GameObject m_obstacle;

	// Token: 0x04000ABE RID: 2750
	public float m_spawnInterval = 2f;

	// Token: 0x04000ABF RID: 2751
	public int m_spawnCount = 10;

	// Token: 0x04000AC0 RID: 2752
	private float m_timeBeforeNextSpawn;

	// Token: 0x04000AC1 RID: 2753
	private int m_numObstaclesSpawned;
}
