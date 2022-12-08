using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class Crouch : MonoBehaviour
{
	// Token: 0x0600004B RID: 75 RVA: 0x00006994 File Offset: 0x00004D94
	private void Start()
	{
		if (!GameObject.Find("Events/Player Start Point").GetComponent<PlayerProperties>().cancrouch)
		{
			base.enabled = false;
		}
		this.camara = GameObject.FindGameObjectWithTag("MainCamera");
		this.controller = base.GetComponent<CharacterController>();
		this.standarHeight = this.controller.height;
		this.crouchHeight = this.standarHeight / 2.5f;
		this.cameraPos = this.camara.transform.localPosition;
		this.cameraCpos = new Vector3(this.cameraPos.x, -0.5f, this.cameraPos.z);
		if (GameObject.Find("Settings").GetComponent<SettingsProperties>().camtype == 3)
		{
			this.isCinematic = true;
		}
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00006A60 File Offset: 0x00004E60
	private void Crouching()
	{
		if (this.controller.isGrounded)
		{
			this.controller.height = this.crouchHeight;
			this.controller.center = new Vector3(0f, -0.5f, 0f);
			if (!this.isCinematic)
			{
				this.camara.transform.localPosition = this.cameraCpos;
			}
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00006AD0 File Offset: 0x00004ED0
	private void GetUp()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.3f, base.transform.position.z);
		this.controller.center = new Vector3(0f, 0f, 0f);
		this.controller.height = this.standarHeight;
		if (!this.isCinematic)
		{
			this.camara.transform.localPosition = this.cameraPos;
		}
		this.iscrouching = false;
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00006B84 File Offset: 0x00004F84
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftControl))
		{
			this.crouch = true;
			this.iscrouching = true;
		}
		if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.LeftControl))
		{
			this.crouch = false;
		}
		if (this.crouch)
		{
			this.Crouching();
			base.GetComponent<AudioSource>().enabled = false;
		}
		else
		{
			base.GetComponent<AudioSource>().enabled = true;
		}
		if (this.iscrouching && !this.crouch)
		{
			Vector3 direction = base.transform.TransformDirection(Vector3.up);
			if (!Physics.Raycast(base.transform.position, direction, 1f))
			{
				this.GetUp();
			}
		}
	}

	// Token: 0x04000066 RID: 102
	private float crouchHeight;

	// Token: 0x04000067 RID: 103
	private float standarHeight;

	// Token: 0x04000068 RID: 104
	private Vector3 cameraPos;

	// Token: 0x04000069 RID: 105
	public GameObject camara;

	// Token: 0x0400006A RID: 106
	private Vector3 cameraCpos;

	// Token: 0x0400006B RID: 107
	private CharacterController controller;

	// Token: 0x0400006C RID: 108
	public bool crouch;

	// Token: 0x0400006D RID: 109
	public bool iscrouching;

	// Token: 0x0400006E RID: 110
	public bool isCinematic;
}
