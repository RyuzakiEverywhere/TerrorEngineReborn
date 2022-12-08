using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public sealed class EasyflowPostProcess : MonoBehaviour
{
	// Token: 0x06000317 RID: 791 RVA: 0x0001DF54 File Offset: 0x0001C354
	private void OnEnable()
	{
		if (this.Instance == null)
		{
			this.Instance = Easyflow.CurrentInstance;
		}
	}

	// Token: 0x06000318 RID: 792 RVA: 0x0001DF72 File Offset: 0x0001C372
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.Instance != null)
		{
			this.Instance.InternalRenderImage(source, destination);
		}
	}

	// Token: 0x0400037B RID: 891
	private Easyflow Instance;
}
