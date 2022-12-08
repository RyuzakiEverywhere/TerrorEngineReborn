using System;
using UnityEngine;

// Token: 0x020000EF RID: 239
public class TerrainProperties : MonoBehaviour
{
	// Token: 0x0600047E RID: 1150 RVA: 0x0003674C File Offset: 0x00034B4C
	private void Awake()
	{
		if (this.grassland1)
		{
			this.grass1.gameObject.active = true;
		}
		if (this.grassland2)
		{
			this.grass2.gameObject.active = true;
		}
		if (this.grassland3)
		{
			this.grass3.gameObject.active = true;
		}
		if (this.snowland1)
		{
			this.snow1.gameObject.active = true;
		}
		if (this.snowland2)
		{
			this.snow2.gameObject.active = true;
		}
		if (this.snowland3)
		{
			this.snow3.gameObject.active = true;
		}
		if (this.canyonland1)
		{
			this.dirt1.gameObject.active = true;
		}
		if (this.canyonland2)
		{
			this.dirt2.gameObject.active = true;
		}
		if (this.canyonland3)
		{
			this.dirt3.gameObject.active = true;
		}
		if (this.waterwater)
		{
			this.water.gameObject.active = true;
		}
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x00036874 File Offset: 0x00034C74
	private void Update()
	{
		if (this.grassland1)
		{
			this.grass1.gameObject.active = true;
		}
		else
		{
			this.grass1.gameObject.active = false;
		}
		if (this.grassland2)
		{
			this.grass2.gameObject.active = true;
		}
		else
		{
			this.grass2.gameObject.active = false;
		}
		if (this.grassland3)
		{
			this.grass3.gameObject.active = true;
		}
		else
		{
			this.grass3.gameObject.active = false;
		}
		if (this.snowland1)
		{
			this.snow1.gameObject.active = true;
		}
		else
		{
			this.snow1.gameObject.active = false;
		}
		if (this.snowland2)
		{
			this.snow2.gameObject.active = true;
		}
		else
		{
			this.snow2.gameObject.active = false;
		}
		if (this.snowland3)
		{
			this.snow3.gameObject.active = true;
		}
		else
		{
			this.snow3.gameObject.active = false;
		}
		if (this.canyonland1)
		{
			this.dirt1.gameObject.active = true;
		}
		else
		{
			this.dirt1.gameObject.active = false;
		}
		if (this.canyonland2)
		{
			this.dirt2.gameObject.active = true;
		}
		else
		{
			this.dirt2.gameObject.active = false;
		}
		if (this.canyonland3)
		{
			this.dirt3.gameObject.active = true;
		}
		else
		{
			this.dirt3.gameObject.active = false;
		}
		if (this.waterwater)
		{
			this.water.gameObject.active = true;
		}
		else
		{
			this.water.gameObject.active = false;
		}
	}

	// Token: 0x0400072E RID: 1838
	public Transform grass1;

	// Token: 0x0400072F RID: 1839
	public Transform grass2;

	// Token: 0x04000730 RID: 1840
	public Transform grass3;

	// Token: 0x04000731 RID: 1841
	public Transform snow1;

	// Token: 0x04000732 RID: 1842
	public Transform snow2;

	// Token: 0x04000733 RID: 1843
	public Transform snow3;

	// Token: 0x04000734 RID: 1844
	public Transform dirt1;

	// Token: 0x04000735 RID: 1845
	public Transform dirt2;

	// Token: 0x04000736 RID: 1846
	public Transform dirt3;

	// Token: 0x04000737 RID: 1847
	public Transform water;

	// Token: 0x04000738 RID: 1848
	public bool grassland1;

	// Token: 0x04000739 RID: 1849
	public bool grassland2;

	// Token: 0x0400073A RID: 1850
	public bool grassland3;

	// Token: 0x0400073B RID: 1851
	public bool snowland1;

	// Token: 0x0400073C RID: 1852
	public bool snowland2;

	// Token: 0x0400073D RID: 1853
	public bool snowland3;

	// Token: 0x0400073E RID: 1854
	public bool canyonland1;

	// Token: 0x0400073F RID: 1855
	public bool canyonland2;

	// Token: 0x04000740 RID: 1856
	public bool canyonland3;

	// Token: 0x04000741 RID: 1857
	public bool waterwater;
}
