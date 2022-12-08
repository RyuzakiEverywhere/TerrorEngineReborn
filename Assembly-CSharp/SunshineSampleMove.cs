using System;
using UnityEngine;

// Token: 0x020001A2 RID: 418
public class SunshineSampleMove : MonoBehaviour
{
	// Token: 0x060009F1 RID: 2545 RVA: 0x00058FE5 File Offset: 0x000573E5
	private void Start()
	{
		this.startPosition = base.transform.position;
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x00058FF8 File Offset: 0x000573F8
	private void Update()
	{
		if (this.Move)
		{
			base.transform.position = this.startPosition + this.MoveVector * (this.MoveRange * Mathf.Sin(Time.timeSinceLevelLoad * this.MoveSpeed));
		}
		if (this.Spin)
		{
			base.transform.eulerAngles = new Vector3(0f, Time.timeSinceLevelLoad * this.SpinSpeed, 0f);
		}
	}

	// Token: 0x04000BBE RID: 3006
	public bool Move = true;

	// Token: 0x04000BBF RID: 3007
	public Vector3 MoveVector = Vector3.up;

	// Token: 0x04000BC0 RID: 3008
	public float MoveRange = 4f;

	// Token: 0x04000BC1 RID: 3009
	public float MoveSpeed = 1f;

	// Token: 0x04000BC2 RID: 3010
	public bool Spin;

	// Token: 0x04000BC3 RID: 3011
	public float SpinSpeed = 20f;

	// Token: 0x04000BC4 RID: 3012
	private Vector3 startPosition;
}
