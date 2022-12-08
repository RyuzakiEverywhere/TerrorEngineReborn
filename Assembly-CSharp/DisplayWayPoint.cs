using System;
using UnityEngine;

// Token: 0x02000019 RID: 25
[RequireComponent(typeof(GUIText))]
public class DisplayWayPoint : MonoBehaviour
{
	// Token: 0x06000067 RID: 103 RVA: 0x00008544 File Offset: 0x00006944
	private void Awake()
	{
		this.thisTransform = base.transform;
		if (this.useMainCamera)
		{
			if (PlayerPrefs.GetString("CamMode") == "OVR")
			{
				this.cam = GameObject.Find("CameraLeft").GetComponent<Camera>();
			}
			else
			{
				this.cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
			}
		}
		else
		{
			this.cam = this.cameraToUse;
		}
		this.camTransform = this.cam.transform;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x000085D4 File Offset: 0x000069D4
	private void Update()
	{
		if (this.clampToScreen)
		{
			Vector3 a = this.camTransform.InverseTransformPoint(this.target.position);
			a.z = Mathf.Max(a.z, 1f);
			this.thisTransform.position = this.cam.WorldToViewportPoint(this.camTransform.TransformPoint(a + this.offset));
			this.thisTransform.position = new Vector3(Mathf.Clamp(this.thisTransform.position.x, this.clampBorderSize, 1f - this.clampBorderSize), Mathf.Clamp(this.thisTransform.position.y, this.clampBorderSize, 1f - this.clampBorderSize), this.thisTransform.position.z);
		}
		else
		{
			this.thisTransform.position = this.cam.WorldToViewportPoint(this.target.position + this.offset);
		}
	}

	// Token: 0x0400009C RID: 156
	public Transform target;

	// Token: 0x0400009D RID: 157
	public Vector3 offset = Vector3.up;

	// Token: 0x0400009E RID: 158
	public bool clampToScreen = true;

	// Token: 0x0400009F RID: 159
	public float clampBorderSize = 0.05f;

	// Token: 0x040000A0 RID: 160
	public bool useMainCamera = true;

	// Token: 0x040000A1 RID: 161
	public Camera cameraToUse;

	// Token: 0x040000A2 RID: 162
	public Camera cam;

	// Token: 0x040000A3 RID: 163
	public Transform thisTransform;

	// Token: 0x040000A4 RID: 164
	public Transform camTransform;
}
