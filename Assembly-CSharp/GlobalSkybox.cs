using System;
using UnityEngine;

// Token: 0x0200025A RID: 602
[ExecuteInEditMode]
public class GlobalSkybox : MonoBehaviour
{
	// Token: 0x060010EF RID: 4335 RVA: 0x0006B55D File Offset: 0x0006995D
	private void Update()
	{
		this.Skybox = RenderSettings.skybox;
		this.AmbientLight = RenderSettings.ambientLight;
	}

	// Token: 0x0400117D RID: 4477
	[HideInInspector]
	public Material Skybox;

	// Token: 0x0400117E RID: 4478
	[HideInInspector]
	public Color AmbientLight;
}
