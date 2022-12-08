using System;
using UnityEngine;

// Token: 0x020000F6 RID: 246
public class NPCMovement : MonoBehaviour
{
	// Token: 0x060004A0 RID: 1184 RVA: 0x00038BA2 File Offset: 0x00036FA2
	private void Start()
	{
		Cursor.visible = false;
		Screen.lockCursor = true;
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x00038BB0 File Offset: 0x00036FB0
	private void Update()
	{
		CharacterController component = base.GetComponent<CharacterController>();
		if (component.isGrounded)
		{
			this.moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			this.moveDirection = base.transform.TransformDirection(this.moveDirection);
			this.moveDirection *= this.speed;
			if (Input.GetButton("Jump"))
			{
				this.moveDirection.y = this.jumpSpeed;
			}
		}
		this.moveDirection.y = this.moveDirection.y - this.gravity * Time.deltaTime;
		component.Move(this.moveDirection * Time.deltaTime);
	}

	// Token: 0x0400079E RID: 1950
	public float speed = 6f;

	// Token: 0x0400079F RID: 1951
	public float jumpSpeed = 8f;

	// Token: 0x040007A0 RID: 1952
	public float gravity = 20f;

	// Token: 0x040007A1 RID: 1953
	private Vector3 moveDirection = Vector3.zero;
}
