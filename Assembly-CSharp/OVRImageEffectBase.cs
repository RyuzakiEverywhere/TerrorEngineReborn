using System;
using UnityEngine;

// Token: 0x020000FF RID: 255
[RequireComponent(typeof(Camera))]
[AddComponentMenu("")]
public class OVRImageEffectBase : MonoBehaviour
{
	// Token: 0x06000517 RID: 1303 RVA: 0x0003A5B7 File Offset: 0x000389B7
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x040007F0 RID: 2032
	public Material material;
}
