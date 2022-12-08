using System;
using UnityEngine;

// Token: 0x02000167 RID: 359
public class moveup : MonoBehaviour
{
	// Token: 0x0600088A RID: 2186 RVA: 0x0004FC14 File Offset: 0x0004E014
	private void Awake()
	{
		this.posy = base.transform.position.y;
		base.transform.position = new Vector3(base.transform.position.x, this.posy + this.move, base.transform.position.z);
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x0004FC83 File Offset: 0x0004E083
	private void Update()
	{
	}

	// Token: 0x04000AA1 RID: 2721
	public float move = 2f;

	// Token: 0x04000AA2 RID: 2722
	private float posy;
}
