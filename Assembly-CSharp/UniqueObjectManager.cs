using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000098 RID: 152
public class UniqueObjectManager : MonoBehaviour
{
	// Token: 0x060002A9 RID: 681 RVA: 0x0001B598 File Offset: 0x00019998
	public static GameObject InstantiatePrefab(string prefabName, Vector3 position, Quaternion rotation)
	{
		GameObject gameObject = UniqueObjectManager.FindPrefabWithName(prefabName);
		if (gameObject == null)
		{
			throw new Exception("Cannot instantiate prefab: No such prefab exists.");
		}
		if (gameObject.GetComponent<ES2UniqueID>() == null)
		{
			throw new Exception("Can't instantiate a prefab which has no UniqueID attached.");
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject, position, rotation);
		UniqueObjectManager.CreatedObjects.Add(gameObject2);
		return gameObject2;
	}

	// Token: 0x060002AA RID: 682 RVA: 0x0001B5F4 File Offset: 0x000199F4
	public static GameObject InstantiatePrefab(string prefabName)
	{
		return UniqueObjectManager.InstantiatePrefab(prefabName, Vector3.zero, Quaternion.identity);
	}

	// Token: 0x060002AB RID: 683 RVA: 0x0001B608 File Offset: 0x00019A08
	public static void DestroyObject(GameObject obj)
	{
		if (!UniqueObjectManager.CreatedObjects.Remove(obj))
		{
			throw new Exception("Cannot destroy prefab: No such prefab exists.");
		}
		IEnumerator enumerator = obj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				Transform transform = (Transform)obj2;
				UniqueObjectManager.DestroyObject(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		UnityEngine.Object.Destroy(obj);
	}

	// Token: 0x060002AC RID: 684 RVA: 0x0001B694 File Offset: 0x00019A94
	public static GameObject FindPrefabWithName(string prefabName)
	{
		GameObject result = null;
		for (int i = 0; i < UniqueObjectManager.Prefabs.Length; i++)
		{
			if (UniqueObjectManager.Prefabs[i].name == prefabName)
			{
				result = UniqueObjectManager.Prefabs[i];
			}
		}
		return result;
	}

	// Token: 0x060002AD RID: 685 RVA: 0x0001B6DB File Offset: 0x00019ADB
	public void Awake()
	{
		UniqueObjectManager.mgr = this;
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x060002AE RID: 686 RVA: 0x0001B6E3 File Offset: 0x00019AE3
	public static GameObject[] SceneObjects
	{
		get
		{
			return UniqueObjectManager.mgr.sceneObjects;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x060002AF RID: 687 RVA: 0x0001B6EF File Offset: 0x00019AEF
	public static GameObject[] Prefabs
	{
		get
		{
			return UniqueObjectManager.mgr.prefabs;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x060002B0 RID: 688 RVA: 0x0001B6FB File Offset: 0x00019AFB
	public static List<GameObject> CreatedObjects
	{
		get
		{
			return UniqueObjectManager.createdObjects;
		}
	}

	// Token: 0x0400032B RID: 811
	public GameObject[] sceneObjects;

	// Token: 0x0400032C RID: 812
	public GameObject[] prefabs;

	// Token: 0x0400032D RID: 813
	public static List<GameObject> createdObjects = new List<GameObject>();

	// Token: 0x0400032E RID: 814
	public static UniqueObjectManager mgr;
}
