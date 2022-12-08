using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
public class ForcePosRotAndScale : MonoBehaviour
{
	// Token: 0x06000336 RID: 822 RVA: 0x0001F2FF File Offset: 0x0001D6FF
	private void Start()
	{
	}

	// Token: 0x06000337 RID: 823 RVA: 0x0001F301 File Offset: 0x0001D701
	private void Update()
	{
		base.transform.localEulerAngles = new Vector3(this.xco, this.yco, this.zco);
		UnityEngine.Object.Destroy(this, 1f);
	}

	// Token: 0x0400039F RID: 927
	public float xco;

	// Token: 0x040003A0 RID: 928
	public float yco;

	// Token: 0x040003A1 RID: 929
	public float zco;
}
