using System;
using UnityEngine;

// Token: 0x020001BA RID: 442
[RequireComponent(typeof(Renderer))]
public class SunshineRenderer : MonoBehaviour
{
	// Token: 0x06000A91 RID: 2705 RVA: 0x0005CA5D File Offset: 0x0005AE5D
	private void OnEnable()
	{
		this.attachedRenderer = base.GetComponent<Renderer>();
	}

	// Token: 0x06000A92 RID: 2706 RVA: 0x0005CA6C File Offset: 0x0005AE6C
	private void Update()
	{
		bool receiveShadows = this.attachedRenderer.receiveShadows;
		if (this._receiveShadows != receiveShadows)
		{
			this._receiveShadows = receiveShadows;
			this.isDirty = true;
		}
		if (this.isDirty)
		{
			if (receiveShadows)
			{
				if (this.originalSharedMaterials != null)
				{
					this.attachedRenderer.materials = this.originalSharedMaterials;
				}
			}
			else
			{
				this.originalSharedMaterials = this.attachedRenderer.sharedMaterials;
				foreach (Material material in this.attachedRenderer.materials)
				{
					material.shaderKeywords = SunshineRenderer.disabledKeywords;
				}
			}
			this.isDirty = false;
		}
	}

	// Token: 0x04000C79 RID: 3193
	private bool _receiveShadows = true;

	// Token: 0x04000C7A RID: 3194
	private bool isDirty = true;

	// Token: 0x04000C7B RID: 3195
	private static readonly string[] disabledKeywords = new string[]
	{
		"SUNSHINE_DISABLED"
	};

	// Token: 0x04000C7C RID: 3196
	private Material[] originalSharedMaterials;

	// Token: 0x04000C7D RID: 3197
	private Renderer attachedRenderer;
}
