using System;
using UnityEngine;

// Token: 0x020001BF RID: 447
public class RenderSkybox : MonoBehaviour
{
	// Token: 0x06000A9C RID: 2716 RVA: 0x0005CE39 File Offset: 0x0005B239
	private void Start()
	{
	}

	// Token: 0x06000A9D RID: 2717 RVA: 0x0005CE3B File Offset: 0x0005B23B
	private void Update()
	{
		if (RenderSettings.skybox != this.skybox)
		{
			RenderSettings.skybox = this.skybox;
		}
		else
		{
			base.enabled = false;
		}
	}

	// Token: 0x04000C85 RID: 3205
	public Material skybox;
}
