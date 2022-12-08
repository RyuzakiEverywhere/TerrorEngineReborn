using System;
using UnityEngine;

// Token: 0x0200025E RID: 606
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("V-Lights/VLight Image Effects")]
public class VLightInterleavedSampling : MonoBehaviour
{
	// Token: 0x17000311 RID: 785
	// (get) Token: 0x06001117 RID: 4375 RVA: 0x0006E2D3 File Offset: 0x0006C6D3
	private Material PostMaterial
	{
		get
		{
			if (this._postMaterial == null)
			{
				this._postMaterial = new Material(this.postEffectShader);
				this._postMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this._postMaterial;
		}
	}

	// Token: 0x06001118 RID: 4376 RVA: 0x0006E30A File Offset: 0x0006C70A
	private void OnEnable()
	{
		this._vLights = null;
		this.Init();
	}

	// Token: 0x06001119 RID: 4377 RVA: 0x0006E31C File Offset: 0x0006C71C
	private void OnDisable()
	{
		if (this._vLights != null)
		{
			foreach (VLight vlight in this._vLights)
			{
				if (!(vlight == null))
				{
					vlight.lockTransforms = false;
				}
			}
		}
		this._vLights = null;
		this.CleanUp();
	}

	// Token: 0x0600111A RID: 4378 RVA: 0x0006E378 File Offset: 0x0006C778
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this._vLights == null)
		{
			this._vLights = (UnityEngine.Object.FindObjectsOfType(typeof(VLight)) as VLight[]);
		}
		int num = Mathf.Clamp(this.downSample, 1, 20);
		this.blurIterations = Mathf.Clamp(this.blurIterations, 0, 20);
		int pixelWidth = base.GetComponent<Camera>().pixelWidth;
		int pixelHeight = base.GetComponent<Camera>().pixelHeight;
		int width = base.GetComponent<Camera>().pixelWidth / num;
		int height = base.GetComponent<Camera>().pixelHeight / num;
		RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
		RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0);
		RenderTexture temporary3 = RenderTexture.GetTemporary(width, height, 0);
		RenderTexture temporary4 = RenderTexture.GetTemporary(width, height, 0);
		if (this.interleavedBuffer != null && (this.interleavedBuffer.width != pixelWidth || this.interleavedBuffer.height != pixelHeight))
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(this.interleavedBuffer);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(this.interleavedBuffer);
			}
			this.interleavedBuffer = null;
		}
		if (this.interleavedBuffer == null)
		{
			this.interleavedBuffer = new RenderTexture(pixelWidth, pixelHeight, 1);
		}
		Camera ppcamera = this.GetPPCamera();
		ppcamera.CopyFrom(base.GetComponent<Camera>());
		ppcamera.enabled = false;
		ppcamera.depthTextureMode = DepthTextureMode.None;
		ppcamera.clearFlags = CameraClearFlags.Color;
		ppcamera.cullingMask = this._volumeLightLayer;
		ppcamera.backgroundColor = Color.clear;
		ppcamera.renderingPath = RenderingPath.VertexLit;
		foreach (VLight vlight in this._vLights)
		{
			if (!(vlight == null))
			{
				vlight.lockTransforms = true;
			}
		}
		if (this.useInterleavedSampling)
		{
			ppcamera.projectionMatrix = base.GetComponent<Camera>().projectionMatrix;
			ppcamera.pixelRect = new Rect(0f, 0f, (float)base.GetComponent<Camera>().pixelWidth / base.GetComponent<Camera>().rect.width + (float)Screen.width / base.GetComponent<Camera>().rect.width, (float)base.GetComponent<Camera>().pixelHeight / base.GetComponent<Camera>().rect.height + (float)Screen.height / base.GetComponent<Camera>().rect.height);
			float num2 = 0f;
			this.RenderSample(num2, ppcamera, temporary);
			num2 += this.ditherOffset;
			this.RenderSample(num2, ppcamera, temporary2);
			num2 += this.ditherOffset;
			this.RenderSample(num2, ppcamera, temporary3);
			num2 += this.ditherOffset;
			this.RenderSample(num2, ppcamera, temporary4);
			this.PostMaterial.SetTexture("_MainTexA", temporary);
			this.PostMaterial.SetTexture("_MainTexB", temporary2);
			this.PostMaterial.SetTexture("_MainTexC", temporary3);
			this.PostMaterial.SetTexture("_MainTexD", temporary4);
			Graphics.Blit(null, this.interleavedBuffer, this.PostMaterial, 0);
		}
		else
		{
			ppcamera.projectionMatrix = base.GetComponent<Camera>().projectionMatrix;
			ppcamera.pixelRect = new Rect(0f, 0f, (float)base.GetComponent<Camera>().pixelWidth / base.GetComponent<Camera>().rect.width + (float)Screen.width / base.GetComponent<Camera>().rect.width, (float)base.GetComponent<Camera>().pixelHeight / base.GetComponent<Camera>().rect.height + (float)Screen.height / base.GetComponent<Camera>().rect.height);
			this.RenderSample(0f, ppcamera, temporary);
			Graphics.Blit(temporary, this.interleavedBuffer);
		}
		foreach (VLight vlight2 in this._vLights)
		{
			if (!(vlight2 == null))
			{
				vlight2.lockTransforms = false;
			}
		}
		RenderTexture temporary5 = RenderTexture.GetTemporary(pixelWidth, pixelHeight, 0);
		this.PostMaterial.SetFloat("_BlurSize", this.blurRadius);
		for (int k = 0; k < this.blurIterations; k++)
		{
			Graphics.Blit(this.interleavedBuffer, temporary5, this.PostMaterial, 1);
			Graphics.Blit(temporary5, this.interleavedBuffer, this.PostMaterial, 2);
		}
		RenderTexture.ReleaseTemporary(temporary5);
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
		RenderTexture.ReleaseTemporary(temporary3);
		RenderTexture.ReleaseTemporary(temporary4);
		this.PostMaterial.SetTexture("_MainTexBlurred", this.interleavedBuffer);
		Graphics.Blit(source, destination, this.PostMaterial, 3);
	}

	// Token: 0x0600111B RID: 4379 RVA: 0x0006E850 File Offset: 0x0006CC50
	private void RenderSample(float offset, Camera ppCamera, RenderTexture buffer)
	{
		Shader.SetGlobalFloat("_InterleavedOffset", offset);
		ppCamera.targetTexture = buffer;
		ppCamera.RenderWithShader(this.volumeLightShader, "RenderType");
	}

	// Token: 0x0600111C RID: 4380 RVA: 0x0006E878 File Offset: 0x0006CC78
	private void Init()
	{
		if (LayerMask.NameToLayer("vlight") == -1)
		{
			Debug.LogWarning("vlight layer does not exist! Cannot use interleaved sampling please add this layer.");
			return;
		}
		if (!SystemInfo.supportsImageEffects)
		{
			Debug.LogWarning("Cannot use interleaved sampling. Image effects not supported");
			return;
		}
		this._volumeLightLayer = 1 << LayerMask.NameToLayer("vlight");
		base.GetComponent<Camera>().cullingMask &= ~this._volumeLightLayer;
		base.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
		if (this.postEffectShader == null)
		{
			this.postEffectShader = Shader.Find("Hidden/V-Light/Post");
		}
		if (this.volumeLightShader == null)
		{
			this.volumeLightShader = Shader.Find("V-Light/Volumetric Light Depth");
		}
	}

	// Token: 0x0600111D RID: 4381 RVA: 0x0006E944 File Offset: 0x0006CD44
	private void CleanUp()
	{
		base.GetComponent<Camera>().cullingMask |= this._volumeLightLayer;
		if (Application.isEditor)
		{
			UnityEngine.Object.DestroyImmediate(this._postMaterial);
			if (this.interleavedBuffer != null)
			{
				UnityEngine.Object.DestroyImmediate(this.interleavedBuffer);
			}
		}
		else
		{
			UnityEngine.Object.Destroy(this._postMaterial);
			if (this.interleavedBuffer != null)
			{
				UnityEngine.Object.Destroy(this.interleavedBuffer);
			}
		}
	}

	// Token: 0x0600111E RID: 4382 RVA: 0x0006E9CC File Offset: 0x0006CDCC
	private Camera GetPPCamera()
	{
		if (this._ppCameraGO == null)
		{
			GameObject gameObject = GameObject.Find("Post Processing Camera");
			if (gameObject != null && gameObject.GetComponent<Camera>() != null)
			{
				this._ppCameraGO = gameObject;
			}
			else
			{
				this._ppCameraGO = new GameObject("Post Processing Camera", new Type[]
				{
					typeof(Camera)
				});
				this._ppCameraGO.GetComponent<Camera>().enabled = false;
				this._ppCameraGO.hideFlags = HideFlags.HideAndDontSave;
			}
		}
		return this._ppCameraGO.GetComponent<Camera>();
	}

	// Token: 0x040011BF RID: 4543
	[SerializeField]
	private bool useInterleavedSampling = true;

	// Token: 0x040011C0 RID: 4544
	[SerializeField]
	private float ditherOffset = 0.02f;

	// Token: 0x040011C1 RID: 4545
	[SerializeField]
	private float blurRadius = 1.5f;

	// Token: 0x040011C2 RID: 4546
	[SerializeField]
	private int blurIterations = 1;

	// Token: 0x040011C3 RID: 4547
	[SerializeField]
	private int downSample = 4;

	// Token: 0x040011C4 RID: 4548
	[SerializeField]
	private Shader postEffectShader;

	// Token: 0x040011C5 RID: 4549
	[SerializeField]
	private Shader volumeLightShader;

	// Token: 0x040011C6 RID: 4550
	private GameObject _ppCameraGO;

	// Token: 0x040011C7 RID: 4551
	private LayerMask _volumeLightLayer;

	// Token: 0x040011C8 RID: 4552
	private VLight[] _vLights;

	// Token: 0x040011C9 RID: 4553
	private Material _postMaterial;

	// Token: 0x040011CA RID: 4554
	private RenderTexture interleavedBuffer;
}
