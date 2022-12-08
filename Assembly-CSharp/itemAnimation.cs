using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x0200004A RID: 74
public class itemAnimation : Photon.MonoBehaviour
{
	// Token: 0x0600017A RID: 378 RVA: 0x00014A40 File Offset: 0x00012E40
	private void CameraAnimations()
	{
		if (this.playerController.isGrounded && this.isMoving)
		{
			if (this.left && !this.anim.isPlaying && (this.animtoplay != string.Empty || this.animtoplay != null))
			{
				this.anim.CrossFade(this.animtoplay);
				this.left = false;
				this.right = true;
			}
			if (this.right && !this.anim.isPlaying)
			{
				this.anim.CrossFade(this.animtoplay);
				this.right = false;
				this.left = true;
			}
		}
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00014AFC File Offset: 0x00012EFC
	private void Awake()
	{
		if (!base.photonView.isMine)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00014B15 File Offset: 0x00012F15
	private void Start()
	{
		this.left = true;
		this.right = false;
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00014B28 File Offset: 0x00012F28
	private void Update()
	{
		if (!this.shoot && !this.melee)
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
		}
		if (Input.GetKey(KeyCode.LeftShift) && !this.shoot && !this.melee)
		{
			this.animtoplay = "Item_walk";
		}
		else
		{
			this.animtoplay = "Item_walk_slow";
		}
		if (this.shoot && !this.melee)
		{
			this.animtoplay = "Item_shoot";
			if (!this.anim.isPlaying)
			{
				this.anim.Play("Item_shoot");
			}
			if (!this.isshooting)
			{
				base.GetComponent<Animation>().Stop();
				base.StartCoroutine(this.WaitAndPrint(0.15f));
			}
		}
		if (this.melee)
		{
			this.animtoplay = "item_melee";
			if (!this.anim.isPlaying)
			{
				this.anim.Play("item_melee");
			}
			if (!this.ismelee)
			{
				base.GetComponent<Animation>().Stop();
				base.StartCoroutine(this.WaitAndPrint2(0.4f));
			}
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00014CBC File Offset: 0x000130BC
	private IEnumerator WaitAndPrint(float waitTime)
	{
		this.isshooting = true;
		yield return new WaitForSeconds(waitTime);
		this.shoot = false;
		this.isshooting = false;
		yield break;
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00014CE0 File Offset: 0x000130E0
	private IEnumerator WaitAndPrint2(float waitTime)
	{
		this.ismelee = true;
		yield return new WaitForSeconds(waitTime);
		this.melee = false;
		this.ismelee = false;
		yield break;
	}

	// Token: 0x04000267 RID: 615
	public CharacterController playerController;

	// Token: 0x04000268 RID: 616
	public Animation anim;

	// Token: 0x04000269 RID: 617
	private bool isMoving;

	// Token: 0x0400026A RID: 618
	private bool left;

	// Token: 0x0400026B RID: 619
	private bool right;

	// Token: 0x0400026C RID: 620
	public string animtoplay;

	// Token: 0x0400026D RID: 621
	public bool shoot;

	// Token: 0x0400026E RID: 622
	public bool isshooting;

	// Token: 0x0400026F RID: 623
	public bool melee;

	// Token: 0x04000270 RID: 624
	public bool ismelee;
}
