using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
public class camAnimation : MonoBehaviour
{
	// Token: 0x06000176 RID: 374 RVA: 0x000148D0 File Offset: 0x00012CD0
	private void CameraAnimations()
	{
		if (this.playerController.isGrounded && this.isMoving)
		{
			if (this.left && !this.anim.isPlaying)
			{
				this.anim.Play("camera_walk");
				this.left = false;
				this.right = true;
			}
			if (this.right && !this.anim.isPlaying)
			{
				this.anim.Play("camera_walk");
				this.right = false;
				this.left = true;
			}
		}
	}

	// Token: 0x06000177 RID: 375 RVA: 0x0001496C File Offset: 0x00012D6C
	private void Start()
	{
		this.left = true;
		this.right = false;
	}

	// Token: 0x06000178 RID: 376 RVA: 0x0001497C File Offset: 0x00012D7C
	private void Update()
	{
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		if (axis != 0f || axis2 != 0f)
		{
			this.isMoving = true;
		}
		else if (axis == 0f && axis2 == 0f)
		{
			this.isMoving = false;
			base.GetComponent<Animation>().Stop();
		}
		this.CameraAnimations();
		if (Input.GetKey(KeyCode.LeftShift))
		{
			this.anim["camera_walk"].speed = 1.75f;
		}
		else
		{
			this.anim["camera_walk"].speed = 1f;
		}
	}

	// Token: 0x04000262 RID: 610
	public CharacterController playerController;

	// Token: 0x04000263 RID: 611
	public Animation anim;

	// Token: 0x04000264 RID: 612
	private bool isMoving;

	// Token: 0x04000265 RID: 613
	private bool left;

	// Token: 0x04000266 RID: 614
	private bool right;
}
