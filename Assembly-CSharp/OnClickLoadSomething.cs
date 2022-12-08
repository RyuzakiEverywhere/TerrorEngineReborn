using System;
using UnityEngine;

// Token: 0x02000155 RID: 341
public class OnClickLoadSomething : MonoBehaviour
{
	// Token: 0x06000845 RID: 2117 RVA: 0x0004B518 File Offset: 0x00049918
	public void OnClick()
	{
		OnClickLoadSomething.ResourceTypeOption resourceTypeToLoad = this.ResourceTypeToLoad;
		if (resourceTypeToLoad != OnClickLoadSomething.ResourceTypeOption.Scene)
		{
			if (resourceTypeToLoad == OnClickLoadSomething.ResourceTypeOption.Web)
			{
				Application.OpenURL(this.ResourceToLoad);
			}
		}
		else
		{
			Application.LoadLevel(this.ResourceToLoad);
		}
	}

	// Token: 0x04000A51 RID: 2641
	public OnClickLoadSomething.ResourceTypeOption ResourceTypeToLoad;

	// Token: 0x04000A52 RID: 2642
	public string ResourceToLoad;

	// Token: 0x02000156 RID: 342
	public enum ResourceTypeOption : byte
	{
		// Token: 0x04000A54 RID: 2644
		Scene,
		// Token: 0x04000A55 RID: 2645
		Web
	}
}
