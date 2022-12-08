using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000097 RID: 151
public class UniqueGameLogic : MonoBehaviour
{
	// Token: 0x060002A4 RID: 676 RVA: 0x0001B1D0 File Offset: 0x000195D0
	public void Start()
	{
		base.StartCoroutine(this.DestroyOrCreateRoutine(3f, 1f));
		base.StartCoroutine(this.ScaleRoutine(3f, 1f));
		base.StartCoroutine(this.MakeChildRoutine(3f, 1f));
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x0001B224 File Offset: 0x00019624
	public IEnumerator DestroyOrCreateRoutine(float delaySeconds, float runEverySeconds)
	{
		yield return new WaitForSeconds(delaySeconds);
		for (;;)
		{
			if (UniqueObjectManager.CreatedObjects.Count > 9)
			{
				UniqueObjectManager.DestroyObject(UniqueObjectManager.CreatedObjects[UnityEngine.Random.Range(0, UniqueObjectManager.CreatedObjects.Count)]);
			}
			else
			{
				UniqueObjectManager.InstantiatePrefab(UniqueObjectManager.Prefabs[UnityEngine.Random.Range(0, UniqueObjectManager.Prefabs.Length)].name, UnityEngine.Random.insideUnitSphere * 10f, UnityEngine.Random.rotation);
			}
			yield return new WaitForSeconds(runEverySeconds);
		}
		yield break;
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x0001B248 File Offset: 0x00019648
	public IEnumerator MakeChildRoutine(float delaySeconds, float runEverySeconds)
	{
		yield return new WaitForSeconds(delaySeconds);
		for (;;)
		{
			if (UniqueObjectManager.CreatedObjects.Count > 4)
			{
				UniqueObjectManager.CreatedObjects[0].transform.parent = UniqueObjectManager.CreatedObjects[UnityEngine.Random.Range(1, UniqueObjectManager.CreatedObjects.Count)].transform;
			}
			yield return new WaitForSeconds(runEverySeconds);
		}
		yield break;
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x0001B26C File Offset: 0x0001966C
	public IEnumerator ScaleRoutine(float delaySeconds, float runEverySeconds)
	{
		yield return new WaitForSeconds(delaySeconds);
		for (;;)
		{
			UniqueObjectManager.SceneObjects[UnityEngine.Random.Range(0, UniqueObjectManager.SceneObjects.Length)].transform.localScale = UnityEngine.Random.insideUnitSphere;
			yield return new WaitForSeconds(runEverySeconds);
		}
		yield break;
	}
}
