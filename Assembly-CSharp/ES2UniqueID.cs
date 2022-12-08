using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000096 RID: 150
public class ES2UniqueID : MonoBehaviour
{
	// Token: 0x0600029D RID: 669 RVA: 0x0001B083 File Offset: 0x00019483
	public void Awake()
	{
		this.id = ES2UniqueID.GenerateUniqueID();
		ES2UniqueID.uniqueIDList.Add(this);
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0001B09B File Offset: 0x0001949B
	public void OnDestroy()
	{
		ES2UniqueID.uniqueIDList.Remove(this);
	}

	// Token: 0x0600029F RID: 671 RVA: 0x0001B0A9 File Offset: 0x000194A9
	private static int GenerateUniqueID()
	{
		if (ES2UniqueID.uniqueIDList.Count == 0)
		{
			return 0;
		}
		return ES2UniqueID.uniqueIDList[ES2UniqueID.uniqueIDList.Count - 1].id + 1;
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x0001B0DC File Offset: 0x000194DC
	public static ES2UniqueID FindUniqueID(Transform t)
	{
		foreach (ES2UniqueID es2UniqueID in ES2UniqueID.uniqueIDList)
		{
			if (es2UniqueID.transform == t)
			{
				return es2UniqueID;
			}
		}
		return null;
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x0001B14C File Offset: 0x0001954C
	public static Transform FindTransform(int id)
	{
		foreach (ES2UniqueID es2UniqueID in ES2UniqueID.uniqueIDList)
		{
			if (es2UniqueID.id == id)
			{
				return es2UniqueID.transform;
			}
		}
		return null;
	}

	// Token: 0x04000328 RID: 808
	[HideInInspector]
	public int id;

	// Token: 0x04000329 RID: 809
	public string prefabName = string.Empty;

	// Token: 0x0400032A RID: 810
	private static List<ES2UniqueID> uniqueIDList = new List<ES2UniqueID>();
}
