using System;
using UnityEngine;

// Token: 0x02000089 RID: 137
[AddComponentMenu("")]
public class PostProcessBase : MonoBehaviour
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000266 RID: 614 RVA: 0x0001576F File Offset: 0x00013B6F
	protected Material material
	{
		get
		{
			if (this.m_Material == null)
			{
				this.m_Material = new Material(this.shader);
				this.m_Material.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_Material;
		}
	}

	// Token: 0x06000267 RID: 615 RVA: 0x000157A6 File Offset: 0x00013BA6
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (!this.shader || !this.shader.isSupported)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000268 RID: 616 RVA: 0x000157E1 File Offset: 0x00013BE1
	protected void OnDisable()
	{
		if (this.m_Material)
		{
			UnityEngine.Object.DestroyImmediate(this.m_Material);
		}
	}

	// Token: 0x040002E5 RID: 741
	public Shader shader;

	// Token: 0x040002E6 RID: 742
	private Material m_Material;
}
