using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200024F RID: 591
[ExecuteInEditMode]
[AddComponentMenu("UniSave/State")]
public class State : MonoBehaviour
{
	// Token: 0x17000307 RID: 775
	// (get) Token: 0x06001084 RID: 4228 RVA: 0x00068584 File Offset: 0x00066984
	// (set) Token: 0x06001085 RID: 4229 RVA: 0x0006858C File Offset: 0x0006698C
	public bool IsSpawnedAtRuntime
	{
		get
		{
			return this._isSpawnedAtRuntime;
		}
		set
		{
			this._isSpawnedAtRuntime = value;
		}
	}

	// Token: 0x17000308 RID: 776
	// (get) Token: 0x06001086 RID: 4230 RVA: 0x00068595 File Offset: 0x00066995
	// (set) Token: 0x06001087 RID: 4231 RVA: 0x0006859D File Offset: 0x0006699D
	public string UniqueName { get; set; }

	// Token: 0x06001088 RID: 4232 RVA: 0x000685A6 File Offset: 0x000669A6
	public void Awake()
	{
		if (!Application.isPlaying)
		{
			this.CheckComponents();
		}
		else if (!this.IsSpawnedAtRuntime)
		{
			this.UniqueName = UniSave.GenerateUniqueGameObjectName(base.gameObject);
		}
	}

	// Token: 0x06001089 RID: 4233 RVA: 0x000685DC File Offset: 0x000669DC
	public void CheckComponents()
	{
		int num = 0;
		if (this.List.Count < 1)
		{
			this.List.Add(this.SelectionIndex);
		}
		this.ComponentList = new List<Component>();
		this._retrieveComponents = base.GetComponents(typeof(Component));
		foreach (Component component in this._retrieveComponents)
		{
			if (UniSave.IsComponentSupported(component) && component.GetType() != typeof(State))
			{
				this.ComponentList.Add(component);
			}
		}
		this.PopupList = new string[this.ComponentList.Count];
		foreach (Component component2 in this.ComponentList)
		{
			this.PopupList[num] = component2.GetType().Name;
			num++;
		}
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x000686F8 File Offset: 0x00066AF8
	public void OnApplicationQuit()
	{
		this._isQuitting = true;
	}

	// Token: 0x0600108B RID: 4235 RVA: 0x00068701 File Offset: 0x00066B01
	public void OnDestroy()
	{
		if (Application.isPlaying && !Application.isLoadingLevel && !this._isQuitting && !this.IsSpawnedAtRuntime)
		{
			UniSave.AddToDestroyedObjectsList(this.UniqueName);
		}
	}

	// Token: 0x0600108C RID: 4236 RVA: 0x00068738 File Offset: 0x00066B38
	public void Save()
	{
		if (this.IsSpawnedAtRuntime)
		{
			this.ComponentList = new List<Component>();
			this._retrieveComponents = base.GetComponents(typeof(Component));
			foreach (Component component in this._retrieveComponents)
			{
				if (UniSave.IsComponentSupported(component))
				{
					this.ComponentList.Add(component);
				}
			}
		}
		if (this.IsSpawnedAtRuntime && base.transform.parent != null)
		{
			return;
		}
		UniSave.CreateGameObject(this);
	}

	// Token: 0x04001126 RID: 4390
	public List<Component> ComponentList;

	// Token: 0x04001127 RID: 4391
	public string[] PopupList;

	// Token: 0x04001128 RID: 4392
	public int SelectionIndex;

	// Token: 0x04001129 RID: 4393
	public List<int> List = new List<int>();

	// Token: 0x0400112A RID: 4394
	[SerializeField]
	private bool _isSpawnedAtRuntime;

	// Token: 0x0400112B RID: 4395
	private Component[] _retrieveComponents;

	// Token: 0x0400112C RID: 4396
	private bool _isQuitting;
}
