using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000B0 RID: 176
[ExecuteInEditMode]
public class VisualizeJoint : MonoBehaviour
{
	// Token: 0x06000341 RID: 833 RVA: 0x0001F45C File Offset: 0x0001D85C
	private void Start()
	{
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0001F45E File Offset: 0x0001D85E
	private void Update()
	{
	}

	// Token: 0x06000343 RID: 835 RVA: 0x0001F460 File Offset: 0x0001D860
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(base.transform.position, 0.01f);
		IEnumerator enumerator = base.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				Gizmos.DrawLine(base.transform.position, transform.position);
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
	}
}
