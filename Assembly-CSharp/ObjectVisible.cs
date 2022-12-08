using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class ObjectVisible : MonoBehaviour
{
	// Token: 0x060000E7 RID: 231 RVA: 0x0000E601 File Offset: 0x0000CA01
	public void SendNow()
	{
		base.StartCoroutine(this.EnableAndDisable());
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x0000E610 File Offset: 0x0000CA10
	private IEnumerator EnableAndDisable()
	{
		this.gameobj = (Resources.FindObjectsOfTypeAll(typeof(CheckVisible)) as CheckVisible[]);
		while (this.gameobj == null)
		{
			yield return null;
		}
		yield return new WaitForEndOfFrame();
		foreach (CheckVisible checkVisible in this.gameobj)
		{
			if (checkVisible.id == this.toggleobjnames)
			{
				checkVisible.gameObject.SetActive(!checkVisible.gameObject.activeSelf);
			}
		}
		yield break;
	}

	// Token: 0x04000157 RID: 343
	public CheckVisible[] gameobj;

	// Token: 0x04000158 RID: 344
	public string toggleobjnames;
}
