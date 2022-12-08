using System;
using UnityEngine;

// Token: 0x020000C1 RID: 193
[AddComponentMenu("Camera-Control/Smooth Mouse Orbit - Unluck Software")]
public class SmoothCameraOrbit : MonoBehaviour
{
	// Token: 0x06000393 RID: 915 RVA: 0x00021177 File Offset: 0x0001F577
	private void Start()
	{
		this.Init();
	}

	// Token: 0x06000394 RID: 916 RVA: 0x0002117F File Offset: 0x0001F57F
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06000395 RID: 917 RVA: 0x00021188 File Offset: 0x0001F588
	public void Init()
	{
		if (!this.target)
		{
			this.target = new GameObject("Cam Target")
			{
				transform = 
				{
					position = base.transform.position + base.transform.forward * this.distance
				}
			}.transform;
		}
		this.currentDistance = this.distance;
		this.desiredDistance = this.distance;
		this.position = base.transform.position;
		this.rotation = base.transform.rotation;
		this.currentRotation = base.transform.rotation;
		this.desiredRotation = base.transform.rotation;
		this.xDeg = Vector3.Angle(Vector3.right, base.transform.right);
		this.yDeg = Vector3.Angle(Vector3.up, base.transform.up);
		this.position = this.target.position - (this.rotation * Vector3.forward * this.currentDistance + this.targetOffset);
	}

	// Token: 0x06000396 RID: 918 RVA: 0x000212BC File Offset: 0x0001F6BC
	private void LateUpdate()
	{
		if (Input.GetMouseButton(2) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl))
		{
			this.desiredDistance -= Input.GetAxis("Mouse Y") * 0.02f * (float)this.zoomRate * 0.125f * Mathf.Abs(this.desiredDistance);
		}
		else if (Input.GetMouseButton(0))
		{
			this.xDeg += Input.GetAxis("Mouse X") * this.xSpeed * 0.02f;
			this.yDeg -= Input.GetAxis("Mouse Y") * this.ySpeed * 0.02f;
			this.yDeg = SmoothCameraOrbit.ClampAngle(this.yDeg, (float)this.yMinLimit, (float)this.yMaxLimit);
			this.desiredRotation = Quaternion.Euler(this.yDeg, this.xDeg, 0f);
			this.currentRotation = base.transform.rotation;
			this.rotation = Quaternion.Lerp(this.currentRotation, this.desiredRotation, 0.02f * this.zoomDampening);
			base.transform.rotation = this.rotation;
			this.idleTimer = 0f;
			this.idleSmooth = 0f;
		}
		else
		{
			this.idleTimer += 0.02f;
			if (this.idleTimer > this.autoRotate && this.autoRotate > 0f)
			{
				this.idleSmooth += (0.02f + this.idleSmooth) * 0.005f;
				this.idleSmooth = Mathf.Clamp(this.idleSmooth, 0f, 1f);
				this.xDeg += this.xSpeed * 0.001f * this.idleSmooth;
			}
			this.yDeg = SmoothCameraOrbit.ClampAngle(this.yDeg, (float)this.yMinLimit, (float)this.yMaxLimit);
			this.desiredRotation = Quaternion.Euler(this.yDeg, this.xDeg, 0f);
			this.currentRotation = base.transform.rotation;
			this.rotation = Quaternion.Lerp(this.currentRotation, this.desiredRotation, 0.02f * this.zoomDampening * 2f);
			base.transform.rotation = this.rotation;
		}
		this.desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * 0.02f * (float)this.zoomRate * Mathf.Abs(this.desiredDistance);
		this.desiredDistance = Mathf.Clamp(this.desiredDistance, this.minDistance, this.maxDistance);
		this.currentDistance = Mathf.Lerp(this.currentDistance, this.desiredDistance, 0.02f * this.zoomDampening);
		this.position = this.target.position - (this.rotation * Vector3.forward * this.currentDistance + this.targetOffset);
		base.transform.position = this.position;
	}

	// Token: 0x06000397 RID: 919 RVA: 0x000215ED File Offset: 0x0001F9ED
	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x040003FE RID: 1022
	public Transform target;

	// Token: 0x040003FF RID: 1023
	public Vector3 targetOffset;

	// Token: 0x04000400 RID: 1024
	public float distance = 5f;

	// Token: 0x04000401 RID: 1025
	public float maxDistance = 20f;

	// Token: 0x04000402 RID: 1026
	public float minDistance = 0.6f;

	// Token: 0x04000403 RID: 1027
	public float xSpeed = 200f;

	// Token: 0x04000404 RID: 1028
	public float ySpeed = 200f;

	// Token: 0x04000405 RID: 1029
	public int yMinLimit = -80;

	// Token: 0x04000406 RID: 1030
	public int yMaxLimit = 80;

	// Token: 0x04000407 RID: 1031
	public int zoomRate = 40;

	// Token: 0x04000408 RID: 1032
	public float panSpeed = 0.3f;

	// Token: 0x04000409 RID: 1033
	public float zoomDampening = 5f;

	// Token: 0x0400040A RID: 1034
	public float autoRotate = 1f;

	// Token: 0x0400040B RID: 1035
	private float xDeg;

	// Token: 0x0400040C RID: 1036
	private float yDeg;

	// Token: 0x0400040D RID: 1037
	private float currentDistance;

	// Token: 0x0400040E RID: 1038
	private float desiredDistance;

	// Token: 0x0400040F RID: 1039
	private Quaternion currentRotation;

	// Token: 0x04000410 RID: 1040
	private Quaternion desiredRotation;

	// Token: 0x04000411 RID: 1041
	private Quaternion rotation;

	// Token: 0x04000412 RID: 1042
	private Vector3 position;

	// Token: 0x04000413 RID: 1043
	private float idleTimer;

	// Token: 0x04000414 RID: 1044
	private float idleSmooth;
}
