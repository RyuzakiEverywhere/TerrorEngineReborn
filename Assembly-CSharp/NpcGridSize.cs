using System;
using UnityEngine;

// Token: 0x020000DC RID: 220
public class NpcGridSize : MonoBehaviour
{
	// Token: 0x06000424 RID: 1060 RVA: 0x0002650C File Offset: 0x0002490C
	private void Awake()
	{
		this.obj = GameObject.Find("Settings");
		this.settings = this.obj.GetComponent<SettingsProperties>();
		base.transform.localScale = new Vector3((float)this.gridscale, 0.01f, (float)this.gridscale);
		base.GetComponent<Renderer>().material.mainTextureScale = new Vector2((float)this.gridscale, (float)this.gridscale);
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x00026580 File Offset: 0x00024980
	private void Start()
	{
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x00026584 File Offset: 0x00024984
	private void Update()
	{
		this.settings = this.obj.GetComponent<SettingsProperties>();
		this.gridscale = this.settings.gridsize;
		base.transform.localScale = new Vector3((float)this.gridscale, 0.01f, (float)this.gridscale);
		base.GetComponent<Renderer>().material.mainTextureScale = new Vector2((float)(this.gridscale * 2), (float)(this.gridscale * 2));
	}

	// Token: 0x040004C6 RID: 1222
	public int gridscale;

	// Token: 0x040004C7 RID: 1223
	public GameObject obj;

	// Token: 0x040004C8 RID: 1224
	public SettingsProperties settings;
}
