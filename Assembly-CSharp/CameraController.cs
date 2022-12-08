using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class CameraController : MonoBehaviour
{
	// Token: 0x06000012 RID: 18 RVA: 0x00003C60 File Offset: 0x00002060
	private void Start()
	{
		this.player = base.transform.parent.gameObject;
		base.transform.parent = null;
		this.distance = this.minZoom + this.zoomSpeed;
		this.height = this.distance * Mathf.Tan(this.zoomAngle * 3.1415927f / 180f);
		base.transform.position = new Vector3(0f, this.height, -this.distance);
		base.transform.LookAt(this.player.transform);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00003CFE File Offset: 0x000020FE
	private void Update()
	{
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00003D00 File Offset: 0x00002100
	private void LateUpdate()
	{
		this.ZoomCamera();
		this.OrbitCamera();
		this.CollideCamera();
		base.transform.LookAt(this.player.transform);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00003D2C File Offset: 0x0000212C
	private void ZoomCamera()
	{
		float num;
		if (this.zoomInverse)
		{
			num = Input.GetAxis("Mouse ScrollWheel") * -1f;
		}
		else
		{
			num = Input.GetAxis("Mouse ScrollWheel");
		}
		if (num < 0f && this.distance < this.maxZoom - 5f)
		{
			this.distance += this.zoomSpeed;
			this.height = this.distance * Mathf.Tan(this.zoomAngle * 3.1415927f / 180f);
			base.transform.localPosition = new Vector3(0f, this.height, -this.distance);
		}
		if (num > 0f && this.distance > this.minZoom + 5f)
		{
			this.distance -= this.zoomSpeed;
			this.height = this.distance * Mathf.Tan(this.zoomAngle * 3.1415927f / 180f);
			base.transform.localPosition = new Vector3(0f, this.height, -this.distance);
		}
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00003E5C File Offset: 0x0000225C
	private void OrbitCamera()
	{
		if (Input.GetMouseButton(1))
		{
			Vector3 eulerAngles = base.transform.eulerAngles;
			float y = Input.GetAxis("Mouse X") * this.mouseSpeedY;
			float num = Input.GetAxis("Mouse Y") * this.mouseSpeedX;
			if (eulerAngles.x + num >= this.tiltUp && eulerAngles.x + num <= this.tiltDown)
			{
				num = 0f;
			}
			Quaternion rhs = Quaternion.Euler(num, y, 0f);
			base.transform.rotation *= rhs;
			base.transform.position = base.transform.rotation * new Vector3(0f, 0f, -this.distance) + this.player.transform.position;
		}
		else
		{
			Quaternion b = Quaternion.Euler(this.zoomAngle, this.player.transform.eulerAngles.y, 0f);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.dumpingSpeed);
			base.transform.position = base.transform.rotation * new Vector3(0f, 0f, -this.distance) + this.player.transform.position;
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00003FE8 File Offset: 0x000023E8
	private void CollideCamera()
	{
		Vector3 direction = (base.transform.position - this.player.transform.position) * 0.9f;
		Ray ray = new Ray(this.player.transform.position, direction);
		RaycastHit raycastHit = default(RaycastHit);
		if (Physics.Raycast(ray, out raycastHit, Vector3.Distance(base.transform.position, this.player.transform.position) * 0.95f))
		{
			base.transform.position = (raycastHit.point - this.player.transform.position) * 0.9f + this.player.transform.position;
		}
	}

	// Token: 0x04000012 RID: 18
	public float zoomAngle = 30f;

	// Token: 0x04000013 RID: 19
	public float zoomSpeed = 5f;

	// Token: 0x04000014 RID: 20
	public float minZoom = 2f;

	// Token: 0x04000015 RID: 21
	public float maxZoom = 100f;

	// Token: 0x04000016 RID: 22
	public bool zoomInverse;

	// Token: 0x04000017 RID: 23
	public float mouseSpeedX = 10f;

	// Token: 0x04000018 RID: 24
	public float mouseSpeedY = 10f;

	// Token: 0x04000019 RID: 25
	public float dumpingSpeed = 5f;

	// Token: 0x0400001A RID: 26
	public float tiltDown = 340f;

	// Token: 0x0400001B RID: 27
	public float tiltUp = 80f;

	// Token: 0x0400001C RID: 28
	private GameObject player;

	// Token: 0x0400001D RID: 29
	private float distance;

	// Token: 0x0400001E RID: 30
	private float height;
}
