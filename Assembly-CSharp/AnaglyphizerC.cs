using System;
using UnityEngine;

// Token: 0x0200004B RID: 75
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Anaglyphizer/Anaglyph-izer Cs Version")]
public class AnaglyphizerC : MonoBehaviour
{
	// Token: 0x06000181 RID: 385 RVA: 0x00014E94 File Offset: 0x00013294
	private void Start()
	{
		if (this.anaglyphMat == null)
		{
			Debug.LogError("No Material Found Please Drag The material in the appropriate Field");
			base.enabled = false;
			return;
		}
		this.leftEye = GameObject.Find("leftEye");
		this.rightEye = GameObject.Find("rightEye");
		this.leftEye.GetComponent<Camera>().enabled = true;
		this.rightEye.GetComponent<Camera>().enabled = true;
		this.leftEye.GetComponent<Camera>().CopyFrom(base.GetComponent<Camera>());
		this.rightEye.GetComponent<Camera>().CopyFrom(base.GetComponent<Camera>());
		this.leftEye.AddComponent<GUILayer>();
		this.rightEye.AddComponent<GUILayer>();
		this.leftEyeRT = new RenderTexture(Screen.width, Screen.height, 24);
		this.rightEyeRT = new RenderTexture(Screen.width, Screen.height, 24);
		this.leftEye.GetComponent<Camera>().targetTexture = this.leftEyeRT;
		this.rightEye.GetComponent<Camera>().targetTexture = this.rightEyeRT;
		this.anaglyphMat.SetTexture("_LeftTex", this.leftEyeRT);
		this.anaglyphMat.SetTexture("_RightTex", this.rightEyeRT);
		this.leftEye.GetComponent<Camera>().depth = base.GetComponent<Camera>().depth - 2f;
		this.rightEye.GetComponent<Camera>().depth = base.GetComponent<Camera>().depth - 1f;
		this.leftEye.transform.position = base.transform.position + base.transform.TransformDirection(-AnaglyphizerC.S3DV.eyeDistance, 0f, 0f);
		this.rightEye.transform.position = base.transform.position + base.transform.TransformDirection(AnaglyphizerC.S3DV.eyeDistance, 0f, 0f);
		if (!this.useProjectionMatrix)
		{
			this.leftEye.transform.LookAt(base.transform.position + base.transform.TransformDirection(Vector3.forward) * AnaglyphizerC.S3DV.focalDistance);
			this.rightEye.transform.LookAt(base.transform.position + base.transform.TransformDirection(Vector3.forward) * AnaglyphizerC.S3DV.focalDistance);
		}
		else
		{
			this.leftEye.transform.rotation = base.transform.rotation;
			this.rightEye.transform.rotation = base.transform.rotation;
			this.leftEye.GetComponent<Camera>().projectionMatrix = this.projectionMatrix(true);
			this.rightEye.GetComponent<Camera>().projectionMatrix = this.projectionMatrix(false);
		}
		this.leftEye.transform.parent = base.transform;
		this.rightEye.transform.parent = base.transform;
		base.GetComponent<Camera>().cullingMask = 0;
		base.GetComponent<Camera>().backgroundColor = new Color(0f, 0f, 0f, 0f);
		base.GetComponent<Camera>().clearFlags = CameraClearFlags.Nothing;
	}

	// Token: 0x06000182 RID: 386 RVA: 0x000151D7 File Offset: 0x000135D7
	private void Stop()
	{
	}

	// Token: 0x06000183 RID: 387 RVA: 0x000151DC File Offset: 0x000135DC
	private void UpdateView()
	{
		this.leftEye.GetComponent<Camera>().depth = base.GetComponent<Camera>().depth - 2f;
		this.rightEye.GetComponent<Camera>().depth = base.GetComponent<Camera>().depth - 1f;
		this.leftEye.transform.position = base.transform.position + base.transform.TransformDirection(-AnaglyphizerC.S3DV.eyeDistance, 0f, 0f);
		this.rightEye.transform.position = base.transform.position + base.transform.TransformDirection(AnaglyphizerC.S3DV.eyeDistance, 0f, 0f);
		if (!this.useProjectionMatrix)
		{
			this.leftEye.transform.LookAt(base.transform.position + base.transform.TransformDirection(Vector3.forward) * AnaglyphizerC.S3DV.focalDistance);
			this.rightEye.transform.LookAt(base.transform.position + base.transform.TransformDirection(Vector3.forward) * AnaglyphizerC.S3DV.focalDistance);
		}
		else
		{
			this.leftEye.transform.rotation = base.transform.rotation;
			this.rightEye.transform.rotation = base.transform.rotation;
			this.leftEye.GetComponent<Camera>().projectionMatrix = this.projectionMatrix(true);
			this.rightEye.GetComponent<Camera>().projectionMatrix = this.projectionMatrix(false);
		}
		this.leftEye.transform.parent = base.transform;
		this.rightEye.transform.parent = base.transform;
	}

	// Token: 0x06000184 RID: 388 RVA: 0x000153B4 File Offset: 0x000137B4
	private void LateUpdate()
	{
		this.UpdateView();
		if (this.enableKeys)
		{
			float num = 0.01f;
			if (Input.GetKeyDown(this.upEyeDistance))
			{
				AnaglyphizerC.S3DV.eyeDistance += num;
			}
			else if (Input.GetKeyDown(this.downEyeDistance))
			{
				AnaglyphizerC.S3DV.eyeDistance -= num;
			}
			float num2 = 0.5f;
			if (Input.GetKeyDown(this.upFocalDistance))
			{
				AnaglyphizerC.S3DV.focalDistance += num2;
			}
			else if (Input.GetKeyDown(this.downFocalDistance))
			{
				AnaglyphizerC.S3DV.focalDistance -= num2;
			}
		}
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00015458 File Offset: 0x00013858
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture.active = destination;
		GL.PushMatrix();
		GL.LoadOrtho();
		for (int i = 0; i < this.anaglyphMat.passCount; i++)
		{
			this.anaglyphMat.SetPass(i);
			this.DrawQuad();
		}
		GL.PopMatrix();
	}

	// Token: 0x06000186 RID: 390 RVA: 0x000154AC File Offset: 0x000138AC
	private void DrawQuad()
	{
		GL.Begin(7);
		GL.TexCoord2(0f, 0f);
		GL.Vertex3(0f, 0f, this.zvalue);
		GL.TexCoord2(1f, 0f);
		GL.Vertex3(1f, 0f, this.zvalue);
		GL.TexCoord2(1f, 1f);
		GL.Vertex3(1f, 1f, this.zvalue);
		GL.TexCoord2(0f, 1f);
		GL.Vertex3(0f, 1f, this.zvalue);
		GL.End();
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00015554 File Offset: 0x00013954
	private Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
	{
		float value = 2f * near / (right - left);
		float value2 = 2f * near / (top - bottom);
		float value3 = (right + left) / (right - left);
		float value4 = (top + bottom) / (top - bottom);
		float value5 = -(far + near) / (far - near);
		float value6 = -(2f * far * near) / (far - near);
		float value7 = -1f;
		Matrix4x4 result = default(Matrix4x4);
		result[0, 0] = value;
		result[0, 1] = 0f;
		result[0, 2] = value3;
		result[0, 3] = 0f;
		result[1, 0] = 0f;
		result[1, 1] = value2;
		result[1, 2] = value4;
		result[1, 3] = 0f;
		result[2, 0] = 0f;
		result[2, 1] = 0f;
		result[2, 2] = value5;
		result[2, 3] = value6;
		result[3, 0] = 0f;
		result[3, 1] = 0f;
		result[3, 2] = value7;
		result[3, 3] = 0f;
		return result;
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00015688 File Offset: 0x00013A88
	private Matrix4x4 projectionMatrix(bool isLeftEye)
	{
		float num = base.GetComponent<Camera>().fieldOfView / 180f * 3.1415927f;
		float aspect = base.GetComponent<Camera>().aspect;
		float num2 = base.GetComponent<Camera>().nearClipPlane * Mathf.Tan(num * 0.5f);
		float num3 = base.GetComponent<Camera>().nearClipPlane / AnaglyphizerC.S3DV.focalDistance;
		float left;
		float right;
		if (isLeftEye)
		{
			left = -aspect * num2 + AnaglyphizerC.S3DV.eyeDistance * num3;
			right = aspect * num2 + AnaglyphizerC.S3DV.eyeDistance * num3;
		}
		else
		{
			left = -aspect * num2 - AnaglyphizerC.S3DV.eyeDistance * num3;
			right = aspect * num2 - AnaglyphizerC.S3DV.eyeDistance * num3;
		}
		return this.PerspectiveOffCenter(left, right, -num2, num2, base.GetComponent<Camera>().nearClipPlane, base.GetComponent<Camera>().farClipPlane);
	}

	// Token: 0x04000271 RID: 625
	private RenderTexture leftEyeRT;

	// Token: 0x04000272 RID: 626
	private RenderTexture rightEyeRT;

	// Token: 0x04000273 RID: 627
	private GameObject leftEye;

	// Token: 0x04000274 RID: 628
	private GameObject rightEye;

	// Token: 0x04000275 RID: 629
	public Material anaglyphMat;

	// Token: 0x04000276 RID: 630
	internal float zvalue;

	// Token: 0x04000277 RID: 631
	public bool enableKeys = true;

	// Token: 0x04000278 RID: 632
	public KeyCode downEyeDistance = KeyCode.O;

	// Token: 0x04000279 RID: 633
	public KeyCode upEyeDistance = KeyCode.P;

	// Token: 0x0400027A RID: 634
	public KeyCode downFocalDistance = KeyCode.K;

	// Token: 0x0400027B RID: 635
	public KeyCode upFocalDistance = KeyCode.L;

	// Token: 0x0400027C RID: 636
	public bool useProjectionMatrix;

	// Token: 0x0200004C RID: 76
	public class S3DV
	{
		// Token: 0x0400027D RID: 637
		internal static float eyeDistance = 0.02f;

		// Token: 0x0400027E RID: 638
		internal static float focalDistance = 10f;
	}
}
