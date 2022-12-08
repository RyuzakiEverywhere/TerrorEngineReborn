using System;
using UnityEngine;

// Token: 0x02000099 RID: 153
public class UniqueSaveManager : MonoBehaviour
{
	// Token: 0x060002B3 RID: 691 RVA: 0x0001B72C File Offset: 0x00019B2C
	public void OnApplicationQuit()
	{
		this.Save();
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x0001B734 File Offset: 0x00019B34
	public void Start()
	{
		if (ES2.Exists(this.sceneObjectFile))
		{
			int num = ES2.Load<int>(this.sceneObjectFile + "?tag=sceneObjectCount");
			for (int i = 0; i < num; i++)
			{
				this.LoadObject(i, this.sceneObjectFile);
			}
		}
		if (ES2.Exists(this.createdObjectFile))
		{
			int num2 = ES2.Load<int>(this.createdObjectFile + "?tag=createdObjectCount");
			for (int j = 0; j < num2; j++)
			{
				this.LoadObject(j, this.createdObjectFile);
			}
		}
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x0001B7CC File Offset: 0x00019BCC
	private void Save()
	{
		ES2.Save<int>(UniqueObjectManager.SceneObjects.Length, this.sceneObjectFile + "?tag=sceneObjectCount");
		for (int i = 0; i < UniqueObjectManager.SceneObjects.Length; i++)
		{
			this.SaveObject(UniqueObjectManager.SceneObjects[i], i, this.sceneObjectFile);
		}
		ES2.Save<int>(UniqueObjectManager.CreatedObjects.Count, this.createdObjectFile + "?tag=createdObjectCount");
		for (int j = 0; j < UniqueObjectManager.CreatedObjects.Count; j++)
		{
			this.SaveObject(UniqueObjectManager.CreatedObjects[j], j, this.createdObjectFile);
		}
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x0001B874 File Offset: 0x00019C74
	private void SaveObject(GameObject obj, int i, string file)
	{
		ES2UniqueID component = obj.GetComponent<ES2UniqueID>();
		ES2.Save<int>(component.id, file + "?tag=uniqueID" + i);
		ES2.Save<string>(component.prefabName, file + "?tag=prefabName" + i);
		ES2.Save<bool>(component.gameObject.activeSelf, file + "?tag=active" + i);
		Transform component2 = obj.GetComponent<Transform>();
		if (component2 != null)
		{
			ES2.Save<Transform>(component2, file + "?tag=transform" + i);
			ES2UniqueID es2UniqueID = ES2UniqueID.FindUniqueID(component2.parent);
			if (es2UniqueID == null)
			{
				ES2.Save<int>(-1, file + "?tag=parentID" + i);
			}
			else
			{
				ES2.Save<int>(es2UniqueID.id, file + "?tag=parentID" + i);
			}
		}
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x0001B95C File Offset: 0x00019D5C
	private void LoadObject(int i, string file)
	{
		int id = ES2.Load<int>(file + "?tag=uniqueID" + i);
		string text = ES2.Load<string>(file + "?tag=prefabName" + i);
		GameObject gameObject;
		if (text == string.Empty)
		{
			gameObject = ES2UniqueID.FindTransform(id).gameObject;
		}
		else
		{
			gameObject = UniqueObjectManager.InstantiatePrefab(text);
		}
		gameObject.SetActive(ES2.Load<bool>(file + "?tag=active" + i));
		Transform component = gameObject.GetComponent<Transform>();
		if (component != null)
		{
			ES2.Load<Transform>(file + "?tag=transform" + i, component);
			int id2 = ES2.Load<int>(file + "?tag=parentID" + i);
			Transform transform = ES2UniqueID.FindTransform(id2);
			if (transform != null)
			{
				component.parent = transform;
			}
		}
	}

	// Token: 0x0400032F RID: 815
	public string sceneObjectFile = "sceneObjectsFile.txt";

	// Token: 0x04000330 RID: 816
	public string createdObjectFile = "createdObjectsFile.txt";
}
