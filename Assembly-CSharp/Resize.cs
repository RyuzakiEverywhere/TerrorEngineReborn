using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000E0 RID: 224
public class Resize : MonoBehaviour
{
	// Token: 0x06000439 RID: 1081 RVA: 0x00027EF0 File Offset: 0x000262F0
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(0.5f);
		base.gameObject.transform.localScale = new Vector3(float.Parse(base.gameObject.GetComponent<PositionAndScale>().scalex), float.Parse(base.gameObject.GetComponent<PositionAndScale>().scaley), float.Parse(base.gameObject.GetComponent<PositionAndScale>().scalez));
		UnityEngine.Object.Destroy(this);
		yield break;
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x00027F0B File Offset: 0x0002630B
	private void Update()
	{
	}
}
