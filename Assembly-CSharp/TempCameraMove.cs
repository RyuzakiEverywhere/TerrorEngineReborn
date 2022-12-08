using System;
using UnityEngine;

// Token: 0x020000FE RID: 254
public class TempCameraMove : MonoBehaviour
{
	// Token: 0x06000514 RID: 1300 RVA: 0x0003A4A8 File Offset: 0x000388A8
	private void Start()
	{
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x0003A4AC File Offset: 0x000388AC
	private void Update()
	{
		base.transform.Translate(Vector3.forward * this.speed * Time.deltaTime, Space.Self);
		if (Input.GetKey("w"))
		{
			base.transform.Rotate(Vector3.left * 30f * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey("s"))
		{
			base.transform.Rotate(Vector3.right * 30f * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey("a"))
		{
			base.transform.Rotate(Vector3.down * 30f * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d"))
		{
			base.transform.Rotate(Vector3.up * 30f * Time.deltaTime, Space.World);
		}
	}

	// Token: 0x040007EF RID: 2031
	public float speed = 200f;
}
