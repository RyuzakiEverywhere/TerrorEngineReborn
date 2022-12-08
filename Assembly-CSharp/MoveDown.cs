using System;
using UnityEngine;

// Token: 0x0200002E RID: 46
public class MoveDown : MonoBehaviour
{
	// Token: 0x060000BF RID: 191 RVA: 0x0000C37C File Offset: 0x0000A77C
	private void OnEnable()
	{
		this.wp = base.gameObject.GetComponent<ModelProperties>();
		this.movespeed = float.Parse(this.wp.movementspeed);
		this.backandforth = this.wp.backandforth;
		this.up = this.wp.moveup;
		this.down = this.wp.movedown;
		this.forward = this.wp.moveforward;
		this.backward = this.wp.movebackward;
		if (this.wp.deathoncollide)
		{
			this.deathoncollide = true;
			base.gameObject.AddComponent<SphereCollider>();
			base.gameObject.GetComponent<SphereCollider>().isTrigger = true;
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x0000C43C File Offset: 0x0000A83C
	private void Update()
	{
		if (base.GetComponent<Rigidbody>() != null)
		{
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			base.GetComponent<Rigidbody>().freezeRotation = true;
		}
		else
		{
			base.gameObject.AddComponent<Rigidbody>();
		}
		if (this.up)
		{
			base.transform.Translate(new Vector3(0f, this.movespeed, 0f) * Time.deltaTime);
		}
		if (this.down)
		{
			base.transform.Translate(new Vector3(0f, -this.movespeed, 0f) * Time.deltaTime);
		}
		if (this.forward)
		{
			base.transform.Translate(new Vector3(0f, 0f, this.movespeed) * Time.deltaTime);
		}
		if (this.backward)
		{
			base.transform.Translate(new Vector3(0f, 0f, -this.movespeed) * Time.deltaTime);
		}
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x0000C55C File Offset: 0x0000A95C
	private void OnCollisioStay(Collision other)
	{
		if (base.GetComponent<Rigidbody>() != null)
		{
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		}
		if (this.backandforth && this.up)
		{
			this.up = false;
			this.down = true;
		}
		if (this.backandforth && this.down)
		{
			this.up = true;
			this.down = false;
		}
		if (this.backandforth && this.forward)
		{
			this.backward = true;
			this.forward = false;
		}
		if (this.backandforth && this.backward)
		{
			this.forward = true;
			this.backward = false;
		}
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x0000C618 File Offset: 0x0000AA18
	private void OnTriggerEnter(Collider other)
	{
		if (this.deathoncollide && other.transform.tag == "Player" && other.gameObject.GetComponent<PhotonView>().isMine)
		{
			other.gameObject.GetComponent<PlayerHealth>().health = -1f;
		}
	}

	// Token: 0x04000114 RID: 276
	public ModelProperties wp;

	// Token: 0x04000115 RID: 277
	public float movespeed;

	// Token: 0x04000116 RID: 278
	public bool backandforth;

	// Token: 0x04000117 RID: 279
	public bool up;

	// Token: 0x04000118 RID: 280
	public bool down;

	// Token: 0x04000119 RID: 281
	public bool forward;

	// Token: 0x0400011A RID: 282
	public bool backward;

	// Token: 0x0400011B RID: 283
	public bool deathoncollide;
}
