using System;
using UnityEngine;

// Token: 0x02000028 RID: 40
public class LoadCustomItemModel : MonoBehaviour
{
	// Token: 0x060000AA RID: 170 RVA: 0x0000B680 File Offset: 0x00009A80
	private void Awake()
	{
		if (this.ic1)
		{
			this.icname = GameObject.Find("Item_Type1").GetComponent<CustomItemModel>();
		}
		if (this.ic2)
		{
			this.icname = GameObject.Find("Item_Type2").GetComponent<CustomItemModel>();
		}
		if (this.ic3)
		{
			this.icname = GameObject.Find("Item_Type3").GetComponent<CustomItemModel>();
		}
		if (this.ic4)
		{
			this.icname = GameObject.Find("Item_Type4").GetComponent<CustomItemModel>();
		}
		if (this.ic5)
		{
			this.icname = GameObject.Find("Item_Type5").GetComponent<CustomItemModel>();
		}
	}

	// Token: 0x060000AB RID: 171 RVA: 0x0000B730 File Offset: 0x00009B30
	private void Update()
	{
		if (base.gameObject.GetComponent<MeshFilter>() == null)
		{
			base.gameObject.AddComponent<MeshFilter>();
		}
		if (base.gameObject.GetComponent<MeshRenderer>() == null)
		{
			base.gameObject.AddComponent<MeshRenderer>();
		}
		if (this.icname.meshmodel != null && this.icname.tex != null)
		{
			base.GetComponent<Renderer>().material.mainTexture = this.icname.tex;
			base.gameObject.GetComponent<MeshFilter>().mesh = this.icname.meshmodel;
			base.enabled = false;
		}
	}

	// Token: 0x040000F5 RID: 245
	public bool ic1;

	// Token: 0x040000F6 RID: 246
	public bool ic2;

	// Token: 0x040000F7 RID: 247
	public bool ic3;

	// Token: 0x040000F8 RID: 248
	public bool ic4;

	// Token: 0x040000F9 RID: 249
	public bool ic5;

	// Token: 0x040000FA RID: 250
	public CustomItemModel icname;
}
