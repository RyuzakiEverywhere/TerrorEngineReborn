using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public class ObjectPool
{
	// Token: 0x0600035A RID: 858 RVA: 0x0001FD74 File Offset: 0x0001E174
	public ObjectPool(int Size, GameObject[] Obj)
	{
		this.OBJ = Obj;
		for (int i = 0; i < this.OBJ.Length; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.OBJ[i], Vector3.zero, Quaternion.identity);
				gameObject.name = this.OBJ[i].name + "_" + this.Number;
				gameObject.AddComponent(typeof(MapCreatorDecentralized));
				this.Number++;
				gameObject.SetActiveRecursively(false);
				this.Pool.Add(gameObject);
			}
		}
	}

	// Token: 0x0600035B RID: 859 RVA: 0x0001FE38 File Offset: 0x0001E238
	public GameObject GetObjectFromPool()
	{
		if (this.Pool.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, this.Pool.Count);
			GameObject gameObject = this.Pool[index];
			this.Pool.RemoveAt(index);
			gameObject.SetActiveRecursively(true);
			return gameObject;
		}
		int num = UnityEngine.Random.Range(0, this.OBJ.Length);
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.OBJ[num], Vector3.zero, Quaternion.identity);
		gameObject2.name = this.OBJ[num].name + "_" + this.Number;
		gameObject2.AddComponent(typeof(MapCreatorDecentralized));
		this.Number++;
		return gameObject2;
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0001FEF9 File Offset: 0x0001E2F9
	public void PutObjectInPool(GameObject obj)
	{
		obj.SetActiveRecursively(false);
		this.Pool.Add(obj);
	}

	// Token: 0x040003C1 RID: 961
	private List<GameObject> Pool = new List<GameObject>();

	// Token: 0x040003C2 RID: 962
	private GameObject[] OBJ;

	// Token: 0x040003C3 RID: 963
	private int Number;
}
