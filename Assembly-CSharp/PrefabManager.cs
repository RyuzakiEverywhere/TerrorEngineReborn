using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200009A RID: 154
public class PrefabManager : MonoBehaviour
{
	// Token: 0x060002B9 RID: 697 RVA: 0x0001BA59 File Offset: 0x00019E59
	private void Start()
	{
		if (ES2.Exists(this.filename))
		{
			this.LoadAllPrefabs();
		}
	}

	// Token: 0x060002BA RID: 698 RVA: 0x0001BA74 File Offset: 0x00019E74
	private void LoadAllPrefabs()
	{
		int num = ES2.Load<int>(this.filename + "?tag=prefabCount");
		for (int i = 0; i < num; i++)
		{
			this.LoadPrefab(i);
		}
	}

	// Token: 0x060002BB RID: 699 RVA: 0x0001BAB0 File Offset: 0x00019EB0
	private void LoadPrefab(int tag)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefab);
		ES2.Load<Transform>(this.filename + "?tag=" + tag, gameObject.transform);
		this.createdPrefabs.Add(gameObject);
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0001BAF8 File Offset: 0x00019EF8
	private void CreateRandomPrefab()
	{
		GameObject item = UnityEngine.Object.Instantiate<GameObject>(this.prefab, UnityEngine.Random.insideUnitSphere * 5f, UnityEngine.Random.rotation);
		this.createdPrefabs.Add(item);
	}

	// Token: 0x060002BD RID: 701 RVA: 0x0001BB34 File Offset: 0x00019F34
	private void OnApplicationQuit()
	{
		ES2.Save<int>(this.createdPrefabs.Count, this.filename + "?tag=prefabCount");
		for (int i = 0; i < this.createdPrefabs.Count; i++)
		{
			this.SavePrefab(this.createdPrefabs[i], i);
		}
	}

	// Token: 0x060002BE RID: 702 RVA: 0x0001BB90 File Offset: 0x00019F90
	private void OnApplicationPause(bool isPaused)
	{
		if (isPaused)
		{
			this.OnApplicationQuit();
		}
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0001BB9E File Offset: 0x00019F9E
	private void SavePrefab(GameObject prefabToSave, int tag)
	{
		ES2.Save<Transform>(prefabToSave.transform, this.filename + "?tag=" + tag);
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x0001BBC4 File Offset: 0x00019FC4
	private void OnGUI()
	{
		if (GUI.Button(new Rect((float)this.buttonPositionX, 0f, 250f, 100f), "Create Random " + this.prefab.name))
		{
			this.CreateRandomPrefab();
		}
		if (GUI.Button(new Rect((float)this.buttonPositionX, 100f, 250f, 100f), "Delete Saved " + this.prefab.name))
		{
			ES2.Delete(this.filename);
			for (int i = 0; i < this.createdPrefabs.Count; i++)
			{
				UnityEngine.Object.Destroy(this.createdPrefabs[i]);
			}
			this.createdPrefabs.Clear();
		}
	}

	// Token: 0x04000331 RID: 817
	public GameObject prefab;

	// Token: 0x04000332 RID: 818
	public string filename = "SavedPrefabs.txt";

	// Token: 0x04000333 RID: 819
	public int buttonPositionX;

	// Token: 0x04000334 RID: 820
	private List<GameObject> createdPrefabs = new List<GameObject>();
}
