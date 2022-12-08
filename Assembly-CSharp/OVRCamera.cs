using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02000101 RID: 257
[RequireComponent(typeof(Camera))]
public class OVRCamera : OVRComponent
{
	// Token: 0x0600051D RID: 1309 RVA: 0x0003A89D File Offset: 0x00038C9D
	private new void Awake()
	{
		base.Awake();
		if (this.ColorOnlyMaterial == null)
		{
			this.ColorOnlyMaterial = new Material("Shader \"Solid Color\" {\nProperties {\n_Color (\"Color\", Color) = (1,1,1)\n}\nSubShader {\nColor [_Color]\nPass {}\n}\n}");
		}
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x0003A8C8 File Offset: 0x00038CC8
	private new void Start()
	{
		base.Start();
		this.CameraController = base.gameObject.transform.parent.GetComponent<OVRCameraController>();
		if (this.CameraController == null)
		{
			Debug.LogWarning("WARNING: OVRCameraController not found!");
		}
		if (this.CameraTexture == null && this.CameraTextureScale != 1f)
		{
			int width = (int)((float)Screen.width / 2f * this.CameraTextureScale);
			int height = (int)((float)Screen.height * this.CameraTextureScale);
			this.CameraTexture = new RenderTexture(width, height, 24);
			this.CameraTexture.antiAliasing = QualitySettings.antiAliasing;
		}
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x0003A975 File Offset: 0x00038D75
	private new void Update()
	{
		base.Update();
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x0003A97D File Offset: 0x00038D7D
	private void OnPreCull()
	{
		if (!this.CameraController.CallInPreRender)
		{
			this.SetCameraOrientation();
		}
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x0003A998 File Offset: 0x00038D98
	private void OnPreRender()
	{
		if (this.CameraController.CallInPreRender)
		{
			this.SetCameraOrientation();
		}
		if (this.CameraController.WireMode)
		{
			GL.wireframe = true;
		}
		if (this.CameraTexture != null)
		{
			Graphics.SetRenderTarget(this.CameraTexture);
			GL.Clear(true, true, base.gameObject.GetComponent<Camera>().backgroundColor);
		}
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x0003AA04 File Offset: 0x00038E04
	private void OnPostRender()
	{
		if (this.CameraController.WireMode)
		{
			GL.wireframe = false;
		}
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x0003AA1C File Offset: 0x00038E1C
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture source2 = source;
		if (this.CameraTexture != null)
		{
			source2 = this.CameraTexture;
		}
		Material material = null;
		if (this.CameraController.LensCorrection)
		{
			if (this.CameraController.Chromatic)
			{
				material = base.GetComponent<OVRLensCorrection>().GetMaterial_CA(this.CameraController.PortraitMode);
			}
			else
			{
				material = base.GetComponent<OVRLensCorrection>().GetMaterial(this.CameraController.PortraitMode);
			}
		}
		if (material != null)
		{
			Graphics.Blit(source2, destination, material);
		}
		else
		{
			Graphics.Blit(source2, destination);
		}
		this.LatencyTest(destination);
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x0003AAC0 File Offset: 0x00038EC0
	private void SetCameraOrientation()
	{
		Quaternion quaternion = Quaternion.identity;
		Vector3 view = Vector3.forward;
		if (base.gameObject.GetComponent<Camera>().depth == 0f)
		{
			if (this.CameraController.TrackerRotatesY)
			{
				Vector3 eulerAngles = base.gameObject.GetComponent<Camera>().transform.rotation.eulerAngles;
				eulerAngles.x = 0f;
				eulerAngles.z = 0f;
				base.gameObject.transform.parent.transform.eulerAngles = eulerAngles;
			}
			if (this.CameraController != null)
			{
				if (!this.CameraController.PredictionOn)
				{
					OVRDevice.GetOrientation(0, ref OVRCamera.CameraOrientation);
				}
				else
				{
					OVRDevice.GetPredictedOrientation(0, ref OVRCamera.CameraOrientation);
				}
			}
			OVRDevice.ProcessLatencyInputs();
		}
		float y = 0f;
		this.CameraController.GetYRotation(ref y);
		quaternion = Quaternion.Euler(0f, y, 0f);
		view = quaternion * Vector3.forward;
		quaternion.SetLookRotation(view, Vector3.up);
		Quaternion identity = Quaternion.identity;
		this.CameraController.GetOrientationOffset(ref identity);
		quaternion = identity * quaternion;
		if (this.CameraController != null)
		{
			quaternion *= OVRCamera.CameraOrientation;
		}
		base.gameObject.GetComponent<Camera>().transform.rotation = quaternion;
		base.gameObject.GetComponent<Camera>().transform.position = base.gameObject.GetComponent<Camera>().transform.parent.transform.position + this.NeckPosition;
		base.gameObject.GetComponent<Camera>().transform.position += quaternion * this.EyePosition;
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x0003AC94 File Offset: 0x00039094
	private void LatencyTest(RenderTexture dest)
	{
		byte b = 0;
		byte b2 = 0;
		byte b3 = 0;
		string text = Marshal.PtrToStringAnsi(OVRDevice.GetLatencyResultsString());
		if (text != null)
		{
			string text2 = "\n\n---------------------\nLATENCY TEST RESULTS:\n---------------------\n";
			text2 += text;
			text2 += "\n\n\n";
			MonoBehaviour.print(text2);
		}
		if (!OVRDevice.DisplayLatencyScreenColor(ref b, ref b2, ref b3))
		{
			return;
		}
		RenderTexture.active = dest;
		Material colorOnlyMaterial = this.ColorOnlyMaterial;
		this.QuadColor.r = (float)b / 255f;
		this.QuadColor.g = (float)b2 / 255f;
		this.QuadColor.b = (float)b3 / 255f;
		colorOnlyMaterial.SetColor("_Color", this.QuadColor);
		GL.PushMatrix();
		colorOnlyMaterial.SetPass(0);
		GL.LoadOrtho();
		GL.Begin(7);
		GL.Vertex3(0.3f, 0.3f, 0f);
		GL.Vertex3(0.3f, 0.7f, 0f);
		GL.Vertex3(0.7f, 0.7f, 0f);
		GL.Vertex3(0.7f, 0.3f, 0f);
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x0003ADBC File Offset: 0x000391BC
	public void SetPerspectiveOffset(ref Vector3 offset)
	{
		base.gameObject.GetComponent<Camera>().ResetProjectionMatrix();
		Matrix4x4 identity = Matrix4x4.identity;
		identity.SetColumn(3, new Vector4(offset.x, offset.y, 0f, 1f));
		if (this.CameraController != null && this.CameraController.PortraitMode)
		{
			Vector3 zero = Vector3.zero;
			Quaternion q = Quaternion.Euler(0f, 0f, -90f);
			Vector3 one = Vector3.one;
			Matrix4x4 lhs = Matrix4x4.TRS(zero, q, one);
			base.gameObject.GetComponent<Camera>().projectionMatrix = lhs * identity * base.gameObject.GetComponent<Camera>().projectionMatrix;
		}
		else
		{
			base.gameObject.GetComponent<Camera>().projectionMatrix = identity * base.gameObject.GetComponent<Camera>().projectionMatrix;
		}
	}

	// Token: 0x040007F7 RID: 2039
	private RenderTexture CameraTexture;

	// Token: 0x040007F8 RID: 2040
	private Material ColorOnlyMaterial;

	// Token: 0x040007F9 RID: 2041
	private Color QuadColor = Color.red;

	// Token: 0x040007FA RID: 2042
	private float CameraTextureScale = 1f;

	// Token: 0x040007FB RID: 2043
	private OVRCameraController CameraController;

	// Token: 0x040007FC RID: 2044
	[HideInInspector]
	public Vector3 NeckPosition = new Vector3(0f, 0f, 0f);

	// Token: 0x040007FD RID: 2045
	[HideInInspector]
	public Vector3 EyePosition = new Vector3(0f, 0.09f, 0.16f);

	// Token: 0x040007FE RID: 2046
	private static Quaternion CameraOrientation = Quaternion.identity;
}
