using System;
using UnityEngine;

// Token: 0x02000261 RID: 609
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class VLight : MonoBehaviour
{
	// Token: 0x17000312 RID: 786
	// (get) Token: 0x06001128 RID: 4392 RVA: 0x0006F20B File Offset: 0x0006D60B
	// (set) Token: 0x06001129 RID: 4393 RVA: 0x0006F213 File Offset: 0x0006D613
	public int MaxSlices
	{
		get
		{
			return this._maxSlices;
		}
		set
		{
			this._maxSlices = value;
		}
	}

	// Token: 0x0600112A RID: 4394 RVA: 0x0006F21C File Offset: 0x0006D61C
	public void OnEnable()
	{
		this._maxSlices = this.slices;
		int num = LayerMask.NameToLayer("vlight");
		if (num != -1)
		{
			base.gameObject.layer = num;
		}
		base.GetComponent<Camera>().enabled = false;
		base.GetComponent<Camera>().cullingMask &= ~(1 << base.gameObject.layer);
		this.CreateMaterials();
	}

	// Token: 0x0600112B RID: 4395 RVA: 0x0006F288 File Offset: 0x0006D688
	private void OnApplicationQuit()
	{
	}

	// Token: 0x0600112C RID: 4396 RVA: 0x0006F28A File Offset: 0x0006D68A
	private void OnDestroy()
	{
		this.CleanMaterials();
		this.SafeDestroy(this._depthTexture);
		this.SafeDestroy(this.meshContainer);
	}

	// Token: 0x0600112D RID: 4397 RVA: 0x0006F2AA File Offset: 0x0006D6AA
	private void Start()
	{
		this.CreateMaterials();
		this.spotNear = base.GetComponent<Camera>().near;
		this.spotRange = base.GetComponent<Camera>().far;
		this.spotAngle = base.GetComponent<Camera>().fov;
	}

	// Token: 0x0600112E RID: 4398 RVA: 0x0006F2E5 File Offset: 0x0006D6E5
	public void Reset()
	{
		this.CleanMaterials();
		this.SafeDestroy(this._depthTexture);
		this.SafeDestroy(this.meshContainer);
	}

	// Token: 0x0600112F RID: 4399 RVA: 0x0006F308 File Offset: 0x0006D708
	public bool GenerateNewMaterial(Material originalMaterial, ref Material instancedMaterial)
	{
		string text = base.GetInstanceID().ToString();
		if (originalMaterial != null && (instancedMaterial == null || instancedMaterial.name.IndexOf(text, StringComparison.OrdinalIgnoreCase) < 0 || instancedMaterial.name.IndexOf(originalMaterial.name, StringComparison.OrdinalIgnoreCase) < 0))
		{
			if (!originalMaterial.shader.isSupported)
			{
				Debug.LogError("Volumetric light shader not supported");
				base.enabled = false;
				return false;
			}
			Material source = originalMaterial;
			if (instancedMaterial != null && instancedMaterial.name.IndexOf(originalMaterial.name, StringComparison.OrdinalIgnoreCase) > 0)
			{
				source = instancedMaterial;
			}
			instancedMaterial = new Material(source);
			instancedMaterial.name = text + " " + originalMaterial.name;
		}
		return true;
	}

	// Token: 0x06001130 RID: 4400 RVA: 0x0006F3E4 File Offset: 0x0006D7E4
	public void CreateMaterials()
	{
		this._propertyBlock = new MaterialPropertyBlock();
		this._idColorTint = Shader.PropertyToID("_Color");
		this._idLightMultiplier = Shader.PropertyToID("_Strength");
		this._idSpotExponent = Shader.PropertyToID("_SpotExp");
		this._idConstantAttenuation = Shader.PropertyToID("_ConstantAttn");
		this._idLinearAttenuation = Shader.PropertyToID("_LinearAttn");
		this._idQuadraticAttenuation = Shader.PropertyToID("_QuadAttn");
		this._idLightParams = Shader.PropertyToID("_LightParams");
		this._idMinBounds = Shader.PropertyToID("_minBounds");
		this._idMaxBounds = Shader.PropertyToID("_maxBounds");
		this._idViewWorldLight = Shader.PropertyToID("_ViewWorldLight");
		this._idLocalRotation = Shader.PropertyToID("_LocalRotation");
		this._idRotation = Shader.PropertyToID("_Rotation");
		this._idProjection = Shader.PropertyToID("_Projection");
		Material x = (this.lightType != VLight.LightTypes.Spot) ? this._instancedPointMaterial : this._instancedSpotMaterial;
		if (x == null)
		{
			Material material = (this.lightType != VLight.LightTypes.Spot) ? this.pointMaterial : this.spotMaterial;
		}
		if (this._instancedSpotMaterial != null)
		{
			this.spotEmission = this._instancedSpotMaterial.GetTexture("_LightColorEmission");
			this.spotNoise = this._instancedSpotMaterial.GetTexture("_NoiseTex");
			this.spotShadow = this._instancedSpotMaterial.GetTexture("_ShadowTexture");
		}
		if (this._instancedPointMaterial != null)
		{
			this.pointEmission = (this._instancedPointMaterial.GetTexture("_LightColorEmission") as Cubemap);
			this.pointNoise = (this._instancedPointMaterial.GetTexture("_NoiseTex") as Cubemap);
			this.pointShadow = (this._instancedPointMaterial.GetTexture("_ShadowTexture") as Cubemap);
		}
		bool flag = false;
		flag |= this.GenerateNewMaterial(this.pointMaterial, ref this._instancedPointMaterial);
		flag |= this.GenerateNewMaterial(this.spotMaterial, ref this._instancedSpotMaterial);
		if (flag)
		{
			VLight.LightTypes lightTypes = this.lightType;
			if (lightTypes != VLight.LightTypes.Point)
			{
				if (lightTypes == VLight.LightTypes.Spot)
				{
					base.GetComponent<Renderer>().sharedMaterial = this._instancedSpotMaterial;
					if (this.spotEmission != null)
					{
						base.GetComponent<Renderer>().sharedMaterial.SetTexture("_LightColorEmission", this.spotEmission);
					}
					if (this.spotNoise != null)
					{
						base.GetComponent<Renderer>().sharedMaterial.SetTexture("_NoiseTex", this.spotNoise);
					}
					if (this.spotShadow != null)
					{
						base.GetComponent<Renderer>().sharedMaterial.SetTexture("_ShadowTexture", this.spotShadow);
					}
				}
			}
			else
			{
				base.GetComponent<Renderer>().sharedMaterial = this._instancedPointMaterial;
				if (this.pointEmission != null)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetTexture("_LightColorEmission", this.pointEmission);
				}
				if (this.pointNoise != null)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetTexture("_NoiseTex", this.pointNoise);
				}
				if (this.pointShadow != null)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetTexture("_ShadowTexture", this.pointShadow);
				}
			}
		}
	}

	// Token: 0x06001131 RID: 4401 RVA: 0x0006F748 File Offset: 0x0006DB48
	private void CleanMaterials()
	{
		this.SafeDestroy(this._instancedSpotMaterial);
		this.SafeDestroy(this._instancedPointMaterial);
		this.SafeDestroy(base.GetComponent<Renderer>().sharedMaterial);
		this.SafeDestroy(this.meshContainer);
		this._prevMaterialPoint = null;
		this._prevMaterialSpot = null;
		this._instancedSpotMaterial = null;
		this._instancedPointMaterial = null;
		this.meshContainer = null;
	}

	// Token: 0x06001132 RID: 4402 RVA: 0x0006F7B0 File Offset: 0x0006DBB0
	private void OnDrawGizmosSelected()
	{
		if (this._frustrumPoints == null)
		{
			return;
		}
		Gizmos.color = new Color(0f, 1f, 0f, 0.2f);
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[0]), base.transform.TransformPoint(this._frustrumPoints[1]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[2]), base.transform.TransformPoint(this._frustrumPoints[3]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[4]), base.transform.TransformPoint(this._frustrumPoints[5]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[6]), base.transform.TransformPoint(this._frustrumPoints[7]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[1]), base.transform.TransformPoint(this._frustrumPoints[3]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[3]), base.transform.TransformPoint(this._frustrumPoints[7]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[7]), base.transform.TransformPoint(this._frustrumPoints[5]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[5]), base.transform.TransformPoint(this._frustrumPoints[1]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[0]), base.transform.TransformPoint(this._frustrumPoints[2]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[2]), base.transform.TransformPoint(this._frustrumPoints[6]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[6]), base.transform.TransformPoint(this._frustrumPoints[4]));
		Gizmos.DrawLine(base.transform.TransformPoint(this._frustrumPoints[4]), base.transform.TransformPoint(this._frustrumPoints[0]));
	}

	// Token: 0x06001133 RID: 4403 RVA: 0x0006FAC4 File Offset: 0x0006DEC4
	private void CalculateMinMax(out Vector3 min, out Vector3 max, bool forceFrustrumUpdate)
	{
		if (this._frustrumPoints == null || forceFrustrumUpdate)
		{
			VLightGeometryUtil.RecalculateFrustrumPoints(base.GetComponent<Camera>(), 1f, out this._frustrumPoints);
		}
		Vector3[] array = new Vector3[8];
		Vector3 vector = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
		Vector3 vector2 = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		Matrix4x4 matrix4x = this._viewWorldToCameraMatrixCached * this._localToWorldMatrix;
		for (int i = 0; i < this._frustrumPoints.Length; i++)
		{
			array[i] = matrix4x.MultiplyPoint(this._frustrumPoints[i]);
			vector.x = ((vector.x <= array[i].x) ? array[i].x : vector.x);
			vector.y = ((vector.y <= array[i].y) ? array[i].y : vector.y);
			vector.z = ((vector.z <= array[i].z) ? array[i].z : vector.z);
			vector2.x = ((vector2.x > array[i].x) ? array[i].x : vector2.x);
			vector2.y = ((vector2.y > array[i].y) ? array[i].y : vector2.y);
			vector2.z = ((vector2.z > array[i].z) ? array[i].z : vector2.z);
		}
		min = vector;
		max = vector2;
	}

	// Token: 0x06001134 RID: 4404 RVA: 0x0006FCE4 File Offset: 0x0006E0E4
	private Matrix4x4 CalculateProjectionMatrix()
	{
		float fov = base.GetComponent<Camera>().fov;
		float near = base.GetComponent<Camera>().near;
		float far = base.GetComponent<Camera>().far;
		Matrix4x4 result;
		if (!base.GetComponent<Camera>().orthographic)
		{
			result = Matrix4x4.Perspective(fov, 1f, near, far);
		}
		else
		{
			float num = base.GetComponent<Camera>().orthographicSize * 0.5f;
			result = Matrix4x4.Ortho(-num, num, -num, num, far, near);
		}
		return result;
	}

	// Token: 0x06001135 RID: 4405 RVA: 0x0006FD60 File Offset: 0x0006E160
	private void BuildMesh(bool manualPositioning, int planeCount, Vector3 minBounds, Vector3 maxBounds)
	{
		if (this.meshContainer == null || this.meshContainer.name.IndexOf(base.GetInstanceID().ToString(), StringComparison.OrdinalIgnoreCase) != 0)
		{
			this.meshContainer = new Mesh();
			this.meshContainer.hideFlags = HideFlags.HideAndDontSave;
			this.meshContainer.name = base.GetInstanceID().ToString();
		}
		if (this._meshFilter == null)
		{
			this._meshFilter = base.GetComponent<MeshFilter>();
		}
		Vector3[] array = new Vector3[65000];
		int[] array2 = new int[195000];
		int num = 0;
		int num2 = 0;
		float num3 = 1f / (float)(planeCount - 1);
		float num4 = (!manualPositioning) ? 0f : 1f;
		float x = 0f;
		float x2 = 1f;
		float y = 0f;
		float y2 = 1f;
		int num5 = 0;
		for (int i = 0; i < planeCount; i++)
		{
			Vector3[] array3 = new Vector3[4];
			Vector3[] array5;
			if (manualPositioning)
			{
				Plane[] array4 = GeometryUtility.CalculateFrustumPlanes(this._projectionMatrixCached * base.GetComponent<Camera>().worldToCameraMatrix);
				for (int j = 0; j < array4.Length; j++)
				{
					Vector3 v = array4[j].normal * -array4[j].distance;
					array4[j] = new Plane(this._viewWorldToCameraMatrixCached.MultiplyVector(array4[j].normal), this._viewWorldToCameraMatrixCached.MultiplyPoint3x4(v));
				}
				array3[0] = this.CalculateTriLerp(new Vector3(x, y, num4), minBounds, maxBounds);
				array3[1] = this.CalculateTriLerp(new Vector3(x, y2, num4), minBounds, maxBounds);
				array3[2] = this.CalculateTriLerp(new Vector3(x2, y2, num4), minBounds, maxBounds);
				array3[3] = this.CalculateTriLerp(new Vector3(x2, y, num4), minBounds, maxBounds);
				array5 = VLightGeometryUtil.ClipPolygonAgainstPlane(array3, array4);
			}
			else
			{
				array3[0] = new Vector3(x, y, num4);
				array3[1] = new Vector3(x, y2, num4);
				array3[2] = new Vector3(x2, y2, num4);
				array3[3] = new Vector3(x2, y, num4);
				array5 = array3;
			}
			num4 += ((!manualPositioning) ? num3 : (-num3));
			if (array5.Length > 2)
			{
				Array.Copy(array5, 0, array, num, array5.Length);
				num += array5.Length;
				int[] array6 = new int[(array5.Length - 2) * 3];
				int num6 = 0;
				for (int k = 0; k < array6.Length; k += 3)
				{
					array6[k] = num5;
					array6[k + 1] = num5 + (num6 + 1);
					array6[k + 2] = num5 + (num6 + 2);
					num6++;
				}
				num5 += array5.Length;
				Array.Copy(array6, 0, array2, num2, array6.Length);
				num2 += array6.Length;
			}
		}
		this.meshContainer.Clear();
		Vector3[] array7 = new Vector3[num];
		Array.Copy(array, array7, num);
		this.meshContainer.vertices = array7;
		int[] array8 = new int[num2];
		Array.Copy(array2, array8, num2);
		this.meshContainer.triangles = array8;
		this.meshContainer.normals = new Vector3[num];
		this.meshContainer.uv = new Vector2[num];
		Vector3 vector = Vector3.zero;
		foreach (Vector3 b in this._frustrumPoints)
		{
			vector += b;
		}
		vector /= (float)this._frustrumPoints.Length;
		Bounds bounds = new Bounds(vector, Vector3.zero);
		foreach (Vector3 point in this._frustrumPoints)
		{
			bounds.Encapsulate(point);
		}
		this._meshFilter.sharedMesh = this.meshContainer;
		this._meshFilter.sharedMesh.bounds = bounds;
	}

	// Token: 0x06001136 RID: 4406 RVA: 0x000701E4 File Offset: 0x0006E5E4
	private Vector3 CalculateTriLerp(Vector3 vertex, Vector3 minBounds, Vector3 maxBounds)
	{
		Vector3 vector = new Vector3(1f, 1f, 1f) - vertex;
		return new Vector3(minBounds.x * vertex.x, minBounds.y * vertex.y, maxBounds.z * vertex.z) + new Vector3(maxBounds.x * vector.x, maxBounds.y * vector.y, minBounds.z * vector.z);
	}

	// Token: 0x06001137 RID: 4407 RVA: 0x00070278 File Offset: 0x0006E678
	public void RenderShadowMap()
	{
		float far = base.GetComponent<Camera>().far;
		VLight.ShadowMode shadowMode = this.shadowMode;
		if (shadowMode != VLight.ShadowMode.None)
		{
			if (shadowMode != VLight.ShadowMode.Baked)
			{
				if (shadowMode == VLight.ShadowMode.Realtime)
				{
					if (SystemInfo.supportsImageEffects)
					{
						int num = LayerMask.NameToLayer("vlight");
						if (num != -1)
						{
							base.gameObject.layer = num;
							base.GetComponent<Camera>().backgroundColor = Color.red;
							base.GetComponent<Camera>().clearFlags = CameraClearFlags.Color;
							base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.None;
							base.GetComponent<Camera>().renderingPath = RenderingPath.VertexLit;
							this.CreateDepthTexture(this.lightType);
							if (this.renderDepthShader == null)
							{
								this.renderDepthShader = Shader.Find("V-Light/Volumetric Light Depth");
							}
							VLight.LightTypes lightTypes = this.lightType;
							if (lightTypes != VLight.LightTypes.Spot)
							{
								if (lightTypes == VLight.LightTypes.Point)
								{
									base.GetComponent<Camera>().projectionMatrix = Matrix4x4.Perspective(90f, 1f, 0.1f, far);
									base.GetComponent<Camera>().SetReplacementShader(this.renderDepthShader, "RenderType");
									base.GetComponent<Camera>().RenderToCubemap(this._depthTexture, 63);
									base.GetComponent<Camera>().ResetReplacementShader();
								}
							}
							else
							{
								base.GetComponent<Camera>().targetTexture = this._depthTexture;
								base.GetComponent<Camera>().projectionMatrix = this.CalculateProjectionMatrix();
								base.GetComponent<Camera>().RenderWithShader(this.renderDepthShader, "RenderType");
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06001138 RID: 4408 RVA: 0x000703F9 File Offset: 0x0006E7F9
	private RenderTexture GenerateShadowMap(int resX, int resY)
	{
		return new RenderTexture(256, 256, 1, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
	}

	// Token: 0x06001139 RID: 4409 RVA: 0x00070410 File Offset: 0x0006E810
	private void CreateDepthTexture(VLight.LightTypes type)
	{
		if (this._depthTexture == null)
		{
			this._depthTexture = this.GenerateShadowMap(256, 256);
			this._depthTexture.hideFlags = HideFlags.HideAndDontSave;
			this._depthTexture.isPowerOfTwo = true;
			if (type == VLight.LightTypes.Point)
			{
				this._depthTexture.isCubemap = true;
			}
		}
		else if (type == VLight.LightTypes.Point && !this._depthTexture.isCubemap && this._depthTexture.IsCreated())
		{
			this.SafeDestroy(this._depthTexture);
			this._depthTexture = this.GenerateShadowMap(256, 256);
			this._depthTexture.hideFlags = HideFlags.HideAndDontSave;
			this._depthTexture.isPowerOfTwo = true;
			this._depthTexture.isCubemap = true;
		}
		else if (type == VLight.LightTypes.Spot && this._depthTexture.isCubemap && this._depthTexture.IsCreated())
		{
			this.SafeDestroy(this._depthTexture);
			this._depthTexture = this.GenerateShadowMap(512, 512);
			this._depthTexture.hideFlags = HideFlags.HideAndDontSave;
			this._depthTexture.isPowerOfTwo = true;
			this._depthTexture.isCubemap = false;
		}
	}

	// Token: 0x0600113A RID: 4410 RVA: 0x00070560 File Offset: 0x0006E960
	private void OnWillRenderObject()
	{
		if (!this.lockTransforms)
		{
			this.UpdateSettings();
			this.UpdateLightMatrices();
		}
		this.UpdateViewMatrices(Camera.current);
		this.CalculateMinMax(out this._minBounds, out this._maxBounds, this._cameraHasBeenUpdated);
		this.SetShaderPropertiesBlock(this._propertyBlock);
		base.GetComponent<Renderer>().SetPropertyBlock(this._propertyBlock);
	}

	// Token: 0x0600113B RID: 4411 RVA: 0x000705C4 File Offset: 0x0006E9C4
	private void OnBecameVisible()
	{
		this._isVisible = true;
	}

	// Token: 0x0600113C RID: 4412 RVA: 0x000705CD File Offset: 0x0006E9CD
	private void OnBecameInvisible()
	{
		this._isVisible = false;
	}

	// Token: 0x0600113D RID: 4413 RVA: 0x000705D6 File Offset: 0x0006E9D6
	private void Update()
	{
		this.UpdateSettings();
		this.UpdateLightMatrices();
		if (this._isVisible)
		{
			this.RenderShadowMap();
		}
	}

	// Token: 0x0600113E RID: 4414 RVA: 0x000705F8 File Offset: 0x0006E9F8
	private bool CameraHasBeenUpdated()
	{
		bool flag = false;
		flag |= (this._meshFilter == null || this._meshFilter.sharedMesh == null);
		flag |= (this.spotRange != this._prevFar);
		flag |= (this.spotNear != this._prevNear);
		flag |= (this.spotAngle != this._prevFov);
		flag |= (base.GetComponent<Camera>().orthographicSize != this._prevOrthoSize);
		flag |= (base.GetComponent<Camera>().orthographic != this._prevIsOrtho);
		flag |= (this.pointLightRadius != this._prevPointLightRadius);
		flag |= (this.spotMaterial != this._prevMaterialSpot);
		flag |= (this.pointMaterial != this._prevMaterialPoint);
		flag |= (this._prevSlices != this.slices);
		flag |= (this._prevShadowMode != this.shadowMode);
		return flag | this._prevLightType != this.lightType;
	}

	// Token: 0x0600113F RID: 4415 RVA: 0x00070718 File Offset: 0x0006EB18
	public void UpdateSettings()
	{
		this._cameraHasBeenUpdated = this.CameraHasBeenUpdated();
		if (this._cameraHasBeenUpdated)
		{
			VLight.LightTypes lightTypes = this.lightType;
			if (lightTypes != VLight.LightTypes.Point)
			{
				if (lightTypes == VLight.LightTypes.Spot)
				{
					base.GetComponent<Renderer>().sharedMaterial = this._instancedSpotMaterial;
					base.GetComponent<Camera>().far = this.spotRange;
					base.GetComponent<Camera>().near = this.spotNear;
					base.GetComponent<Camera>().fov = this.spotAngle;
					base.GetComponent<Camera>().orthographic = false;
				}
			}
			else
			{
				base.GetComponent<Renderer>().sharedMaterial = this._instancedPointMaterial;
				base.GetComponent<Camera>().orthographic = true;
				base.GetComponent<Camera>().near = -this.pointLightRadius;
				base.GetComponent<Camera>().far = this.pointLightRadius;
				base.GetComponent<Camera>().orthographicSize = this.pointLightRadius * 2f;
			}
			if ((this.shadowMode == VLight.ShadowMode.None || this.shadowMode == VLight.ShadowMode.Baked) && this._depthTexture != null)
			{
				this.SafeDestroy(this._depthTexture);
			}
		}
		this._prevSlices = this.slices;
		this._prevFov = base.GetComponent<Camera>().fov;
		this._prevNear = base.GetComponent<Camera>().near;
		this._prevFar = base.GetComponent<Camera>().far;
		this._prevIsOrtho = base.GetComponent<Camera>().orthographic;
		this._prevOrthoSize = base.GetComponent<Camera>().orthographicSize;
		this._prevMaterialSpot = this.spotMaterial;
		this._prevMaterialPoint = this.pointMaterial;
		this._prevShadowMode = this.shadowMode;
		this._prevLightType = this.lightType;
		this._prevPointLightRadius = this.pointLightRadius;
	}

	// Token: 0x06001140 RID: 4416 RVA: 0x000708D8 File Offset: 0x0006ECD8
	public void UpdateLightMatrices()
	{
		this._localToWorldMatrix = base.transform.localToWorldMatrix;
		this._worldToCamera = base.GetComponent<Camera>().worldToCameraMatrix;
		this._rotation = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(this._angle.x, this._angle.y, this._angle.z), Vector3.one);
		this._angle += this.noiseSpeed * Time.deltaTime;
		this.RebuildMesh();
	}

	// Token: 0x06001141 RID: 4417 RVA: 0x0007096C File Offset: 0x0006ED6C
	public void UpdateViewMatrices(Camera targetCamera)
	{
		this._viewWorldToCameraMatrixCached = targetCamera.worldToCameraMatrix;
		this._viewCameraToWorldMatrixCached = targetCamera.cameraToWorldMatrix;
		VLight.LightTypes lightTypes = this.lightType;
		if (lightTypes != VLight.LightTypes.Spot)
		{
			if (lightTypes == VLight.LightTypes.Point)
			{
				Matrix4x4 lhs = Matrix4x4.TRS(-base.transform.position, Quaternion.identity, Vector3.one);
				this._localRotation = Matrix4x4.TRS(Vector3.zero, base.transform.rotation, Vector3.one);
				this._viewWorldLight = lhs * this._viewCameraToWorldMatrixCached;
			}
		}
		else
		{
			this._viewWorldLight = this._worldToCamera * this._viewCameraToWorldMatrixCached;
		}
	}

	// Token: 0x06001142 RID: 4418 RVA: 0x00070A20 File Offset: 0x0006EE20
	public void RebuildMesh()
	{
		this.CalculateMinMax(out this._minBounds, out this._maxBounds, this._cameraHasBeenUpdated);
		if (this._cameraHasBeenUpdated)
		{
			this._projectionMatrixCached = this.CalculateProjectionMatrix();
			this.CreateMaterials();
			if (Application.isPlaying)
			{
				if (!this._builtMesh)
				{
					this._builtMesh = true;
					this.BuildMesh(false, this.slices, this._minBounds, this._maxBounds);
				}
			}
			else
			{
				this.BuildMesh(false, this.slices, this._minBounds, this._maxBounds);
			}
		}
	}

	// Token: 0x06001143 RID: 4419 RVA: 0x00070AB8 File Offset: 0x0006EEB8
	public MaterialPropertyBlock CreatePropertiesBlock()
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetVector(this._idMinBounds, this._minBounds);
		materialPropertyBlock.SetVector(this._idMaxBounds, this._maxBounds);
		materialPropertyBlock.SetMatrix(this._idProjection, this._projectionMatrixCached);
		materialPropertyBlock.SetMatrix(this._idViewWorldLight, this._viewWorldLight);
		materialPropertyBlock.SetMatrix(this._idLocalRotation, this._localRotation);
		materialPropertyBlock.SetMatrix(this._idRotation, this._rotation);
		materialPropertyBlock.SetColor(this._idColorTint, this.colorTint);
		materialPropertyBlock.SetFloat(this._idSpotExponent, this.spotExponent);
		materialPropertyBlock.SetFloat(this._idConstantAttenuation, this.constantAttenuation);
		materialPropertyBlock.SetFloat(this._idLinearAttenuation, this.linearAttenuation);
		materialPropertyBlock.SetFloat(this._idQuadraticAttenuation, this.quadraticAttenuation);
		materialPropertyBlock.SetFloat(this._idLightMultiplier, this.lightMultiplier);
		VLight.ShadowMode shadowMode = this.shadowMode;
		if (shadowMode != VLight.ShadowMode.Realtime)
		{
			if (shadowMode != VLight.ShadowMode.Baked)
			{
				if (shadowMode == VLight.ShadowMode.None)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetTexture("_ShadowTexture", null);
				}
			}
		}
		else
		{
			base.GetComponent<Renderer>().sharedMaterial.SetTexture("_ShadowTexture", this._depthTexture);
		}
		float far = base.GetComponent<Camera>().far;
		float near = base.GetComponent<Camera>().near;
		float fov = base.GetComponent<Camera>().fov;
		materialPropertyBlock.SetVector(this._idLightParams, new Vector4(near, far, far - near, (!base.GetComponent<Camera>().orthographic) ? (fov * 0.5f * 0.017453292f) : 3.1415927f));
		return materialPropertyBlock;
	}

	// Token: 0x06001144 RID: 4420 RVA: 0x00070C74 File Offset: 0x0006F074
	public void SetShaderPropertiesBlock(MaterialPropertyBlock propertyBlock)
	{
		propertyBlock.Clear();
		propertyBlock.SetVector(this._idMinBounds, this._minBounds);
		propertyBlock.SetVector(this._idMaxBounds, this._maxBounds);
		propertyBlock.SetMatrix(this._idProjection, this._projectionMatrixCached);
		propertyBlock.SetMatrix(this._idViewWorldLight, this._viewWorldLight);
		propertyBlock.SetMatrix(this._idLocalRotation, this._localRotation);
		propertyBlock.SetMatrix(this._idRotation, this._rotation);
		propertyBlock.SetColor(this._idColorTint, this.colorTint);
		propertyBlock.SetFloat(this._idSpotExponent, this.spotExponent);
		propertyBlock.SetFloat(this._idConstantAttenuation, this.constantAttenuation);
		propertyBlock.SetFloat(this._idLinearAttenuation, this.linearAttenuation);
		propertyBlock.SetFloat(this._idQuadraticAttenuation, this.quadraticAttenuation);
		propertyBlock.SetFloat(this._idLightMultiplier, this.lightMultiplier);
		VLight.ShadowMode shadowMode = this.shadowMode;
		if (shadowMode != VLight.ShadowMode.Realtime)
		{
			if (shadowMode != VLight.ShadowMode.Baked)
			{
				if (shadowMode == VLight.ShadowMode.None)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetTexture("_ShadowTexture", null);
				}
			}
		}
		else
		{
			base.GetComponent<Renderer>().sharedMaterial.SetTexture("_ShadowTexture", this._depthTexture);
		}
		float far = base.GetComponent<Camera>().far;
		float near = base.GetComponent<Camera>().near;
		float fov = base.GetComponent<Camera>().fov;
		propertyBlock.SetVector(this._idLightParams, new Vector4(near, far, far - near, (!base.GetComponent<Camera>().orthographic) ? (fov * 0.5f * 0.017453292f) : 3.1415927f));
	}

	// Token: 0x06001145 RID: 4421 RVA: 0x00070E2C File Offset: 0x0006F22C
	public void SetShaderPropertiesMaterials()
	{
		Material sharedMaterial = base.GetComponent<Renderer>().sharedMaterial;
		sharedMaterial.SetVector("_minBounds", this._minBounds);
		sharedMaterial.SetVector("_maxBounds", this._maxBounds);
		sharedMaterial.SetMatrix("_Projection", this._projectionMatrixCached);
		sharedMaterial.SetMatrix("_ViewWorldLight", this._viewWorldLight);
		sharedMaterial.SetMatrix("_LocalRotation", this._localRotation);
		sharedMaterial.SetMatrix("_Rotation", this._rotation);
		Plane[] array = GeometryUtility.CalculateFrustumPlanes(this._projectionMatrixCached);
		VLight.LightTypes lightTypes = this.lightType;
		if (lightTypes != VLight.LightTypes.Point)
		{
			if (lightTypes == VLight.LightTypes.Spot)
			{
				for (int i = 0; i < array.Length; i++)
				{
					Vector3 normal = array[i].normal;
					float distance = array[i].distance;
					sharedMaterial.SetVector("_FrustrumPlane" + i, new Vector4(normal.x, normal.y, normal.z, distance));
				}
			}
		}
		else
		{
			for (int j = 0; j < array.Length; j++)
			{
				Vector3 vector = base.transform.TransformDirection(array[j].normal);
				float distance2 = array[j].distance;
				sharedMaterial.SetVector("_FrustrumPlane" + j, new Vector4(vector.x, vector.y, vector.z, distance2));
			}
		}
		VLight.ShadowMode shadowMode = this.shadowMode;
		if (shadowMode != VLight.ShadowMode.Realtime)
		{
			if (shadowMode != VLight.ShadowMode.Baked)
			{
				if (shadowMode == VLight.ShadowMode.None)
				{
					sharedMaterial.SetTexture("_ShadowTexture", null);
				}
			}
		}
		else
		{
			sharedMaterial.SetTexture("_ShadowTexture", this._depthTexture);
		}
		float far = base.GetComponent<Camera>().far;
		float near = base.GetComponent<Camera>().near;
		float fov = base.GetComponent<Camera>().fov;
		sharedMaterial.SetVector("_LightParams", new Vector4(near, far, far - near, (!base.GetComponent<Camera>().orthographic) ? (fov * 0.5f * 0.017453292f) : 3.1415927f));
	}

	// Token: 0x06001146 RID: 4422 RVA: 0x00071072 File Offset: 0x0006F472
	private void SafeDestroy(UnityEngine.Object obj)
	{
		if (obj != null)
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(obj);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(obj, true);
			}
		}
		obj = null;
	}

	// Token: 0x040011D0 RID: 4560
	[SerializeField]
	[HideInInspector]
	private Material spotMaterial;

	// Token: 0x040011D1 RID: 4561
	[SerializeField]
	[HideInInspector]
	private Material pointMaterial;

	// Token: 0x040011D2 RID: 4562
	[SerializeField]
	[HideInInspector]
	private Shader renderDepthShader;

	// Token: 0x040011D3 RID: 4563
	[HideInInspector]
	public bool lockTransforms;

	// Token: 0x040011D4 RID: 4564
	[HideInInspector]
	public bool renderWireFrame = true;

	// Token: 0x040011D5 RID: 4565
	public VLight.LightTypes lightType;

	// Token: 0x040011D6 RID: 4566
	public float pointLightRadius = 1f;

	// Token: 0x040011D7 RID: 4567
	public float spotRange = 1f;

	// Token: 0x040011D8 RID: 4568
	public float spotNear = 1f;

	// Token: 0x040011D9 RID: 4569
	public float spotAngle = 45f;

	// Token: 0x040011DA RID: 4570
	public VLight.ShadowMode shadowMode;

	// Token: 0x040011DB RID: 4571
	public int slices = 30;

	// Token: 0x040011DC RID: 4572
	public Color colorTint = Color.white;

	// Token: 0x040011DD RID: 4573
	public float lightMultiplier = 1f;

	// Token: 0x040011DE RID: 4574
	public float spotExponent = 1f;

	// Token: 0x040011DF RID: 4575
	public float constantAttenuation = 1f;

	// Token: 0x040011E0 RID: 4576
	public float linearAttenuation = 10f;

	// Token: 0x040011E1 RID: 4577
	public float quadraticAttenuation = 100f;

	// Token: 0x040011E2 RID: 4578
	public Vector3 noiseSpeed;

	// Token: 0x040011E3 RID: 4579
	[SerializeField]
	[HideInInspector]
	private Texture spotEmission;

	// Token: 0x040011E4 RID: 4580
	[SerializeField]
	[HideInInspector]
	private Texture spotNoise;

	// Token: 0x040011E5 RID: 4581
	[SerializeField]
	[HideInInspector]
	private Texture spotShadow;

	// Token: 0x040011E6 RID: 4582
	[SerializeField]
	[HideInInspector]
	private Cubemap pointEmission;

	// Token: 0x040011E7 RID: 4583
	[SerializeField]
	[HideInInspector]
	private Cubemap pointNoise;

	// Token: 0x040011E8 RID: 4584
	[SerializeField]
	[HideInInspector]
	private Cubemap pointShadow;

	// Token: 0x040011E9 RID: 4585
	[HideInInspector]
	[SerializeField]
	private Mesh meshContainer;

	// Token: 0x040011EA RID: 4586
	[HideInInspector]
	[SerializeField]
	private Material _prevMaterialSpot;

	// Token: 0x040011EB RID: 4587
	[HideInInspector]
	[SerializeField]
	private Material _prevMaterialPoint;

	// Token: 0x040011EC RID: 4588
	[HideInInspector]
	[SerializeField]
	public Material _instancedSpotMaterial;

	// Token: 0x040011ED RID: 4589
	[HideInInspector]
	[SerializeField]
	public Material _instancedPointMaterial;

	// Token: 0x040011EE RID: 4590
	private MaterialPropertyBlock _propertyBlock;

	// Token: 0x040011EF RID: 4591
	private int _idColorTint;

	// Token: 0x040011F0 RID: 4592
	private int _idLightMultiplier;

	// Token: 0x040011F1 RID: 4593
	private int _idSpotExponent;

	// Token: 0x040011F2 RID: 4594
	private int _idConstantAttenuation;

	// Token: 0x040011F3 RID: 4595
	private int _idLinearAttenuation;

	// Token: 0x040011F4 RID: 4596
	private int _idQuadraticAttenuation;

	// Token: 0x040011F5 RID: 4597
	private int _idLightParams;

	// Token: 0x040011F6 RID: 4598
	private int _idMinBounds;

	// Token: 0x040011F7 RID: 4599
	private int _idMaxBounds;

	// Token: 0x040011F8 RID: 4600
	private int _idViewWorldLight;

	// Token: 0x040011F9 RID: 4601
	private int _idRotation;

	// Token: 0x040011FA RID: 4602
	private int _idLocalRotation;

	// Token: 0x040011FB RID: 4603
	private int _idProjection;

	// Token: 0x040011FC RID: 4604
	private VLight.LightTypes _prevLightType;

	// Token: 0x040011FD RID: 4605
	private VLight.ShadowMode _prevShadowMode;

	// Token: 0x040011FE RID: 4606
	private int _prevSlices;

	// Token: 0x040011FF RID: 4607
	private bool _frustrumSwitch;

	// Token: 0x04001200 RID: 4608
	private bool _prevIsOrtho;

	// Token: 0x04001201 RID: 4609
	private float _prevNear;

	// Token: 0x04001202 RID: 4610
	private float _prevFar;

	// Token: 0x04001203 RID: 4611
	private float _prevFov;

	// Token: 0x04001204 RID: 4612
	private float _prevOrthoSize;

	// Token: 0x04001205 RID: 4613
	private float _prevPointLightRadius;

	// Token: 0x04001206 RID: 4614
	private Matrix4x4 _worldToCamera;

	// Token: 0x04001207 RID: 4615
	private Matrix4x4 _projectionMatrixCached;

	// Token: 0x04001208 RID: 4616
	private Matrix4x4 _viewWorldToCameraMatrixCached;

	// Token: 0x04001209 RID: 4617
	private Matrix4x4 _viewCameraToWorldMatrixCached;

	// Token: 0x0400120A RID: 4618
	private Matrix4x4 _localToWorldMatrix;

	// Token: 0x0400120B RID: 4619
	private Matrix4x4 _rotation;

	// Token: 0x0400120C RID: 4620
	private Matrix4x4 _localRotation;

	// Token: 0x0400120D RID: 4621
	private Matrix4x4 _viewWorldLight;

	// Token: 0x0400120E RID: 4622
	private Vector3[] _frustrumPoints;

	// Token: 0x0400120F RID: 4623
	private Vector3 _angle = Vector3.zero;

	// Token: 0x04001210 RID: 4624
	private Vector3 _minBounds;

	// Token: 0x04001211 RID: 4625
	private Vector3 _maxBounds;

	// Token: 0x04001212 RID: 4626
	private bool _cameraHasBeenUpdated;

	// Token: 0x04001213 RID: 4627
	private MeshFilter _meshFilter;

	// Token: 0x04001214 RID: 4628
	private RenderTexture _depthTexture;

	// Token: 0x04001215 RID: 4629
	private const int VERT_COUNT = 65000;

	// Token: 0x04001216 RID: 4630
	private const int TRI_COUNT = 195000;

	// Token: 0x04001217 RID: 4631
	private const StringComparison STR_CMP_TYPE = StringComparison.OrdinalIgnoreCase;

	// Token: 0x04001218 RID: 4632
	private bool _builtMesh;

	// Token: 0x04001219 RID: 4633
	private int _maxSlices;

	// Token: 0x0400121A RID: 4634
	private bool _isVisible;

	// Token: 0x02000262 RID: 610
	public enum ShadowMode
	{
		// Token: 0x0400121C RID: 4636
		None,
		// Token: 0x0400121D RID: 4637
		Realtime,
		// Token: 0x0400121E RID: 4638
		Baked
	}

	// Token: 0x02000263 RID: 611
	public enum LightTypes
	{
		// Token: 0x04001220 RID: 4640
		Spot,
		// Token: 0x04001221 RID: 4641
		Point
	}
}
