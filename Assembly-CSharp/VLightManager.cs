using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000264 RID: 612
[ExecuteInEditMode]
public class VLightManager : MonoBehaviour
{
	// Token: 0x17000313 RID: 787
	// (get) Token: 0x06001148 RID: 4424 RVA: 0x000710C0 File Offset: 0x0006F4C0
	public static VLightManager Instance
	{
		get
		{
			if (VLightManager._instance == null)
			{
				VLightManager._instance = (UnityEngine.Object.FindObjectOfType(typeof(VLightManager)) as VLightManager);
				if (VLightManager._instance == null)
				{
					GameObject gameObject = new GameObject("Volume Light Manager");
					VLightManager._instance = gameObject.AddComponent<VLightManager>();
				}
			}
			return VLightManager._instance;
		}
	}

	// Token: 0x17000314 RID: 788
	// (get) Token: 0x06001149 RID: 4425 RVA: 0x00071121 File Offset: 0x0006F521
	public Matrix4x4 ViewProjection
	{
		get
		{
			return this._projection;
		}
	}

	// Token: 0x17000315 RID: 789
	// (get) Token: 0x0600114A RID: 4426 RVA: 0x00071129 File Offset: 0x0006F529
	public Matrix4x4 ViewCameraToWorldMatrix
	{
		get
		{
			return this._cameraToWorld;
		}
	}

	// Token: 0x17000316 RID: 790
	// (get) Token: 0x0600114B RID: 4427 RVA: 0x00071131 File Offset: 0x0006F531
	public Matrix4x4 ViewWorldToCameraMatrix
	{
		get
		{
			return this._worldToCamera;
		}
	}

	// Token: 0x17000317 RID: 791
	// (get) Token: 0x0600114C RID: 4428 RVA: 0x00071139 File Offset: 0x0006F539
	// (set) Token: 0x0600114D RID: 4429 RVA: 0x00071141 File Offset: 0x0006F541
	public List<VLight> VLights
	{
		get
		{
			return this._vLights;
		}
		set
		{
			this._vLights = value;
		}
	}

	// Token: 0x0600114E RID: 4430 RVA: 0x0007114A File Offset: 0x0006F54A
	public void UpdateViewCamera(Camera viewCam)
	{
		if (viewCam == null)
		{
			return;
		}
		this._cameraToWorld = viewCam.cameraToWorldMatrix;
		this._worldToCamera = viewCam.worldToCameraMatrix;
		this._projection = viewCam.projectionMatrix;
	}

	// Token: 0x0600114F RID: 4431 RVA: 0x00071180 File Offset: 0x0006F580
	private void Update()
	{
		if (Application.isPlaying)
		{
			Camera x;
			if (Camera.current != null)
			{
				x = Camera.current;
			}
			else if (this.targetCamera != null)
			{
				x = this.targetCamera;
			}
			else
			{
				x = Camera.main;
			}
			if (x == null)
			{
				return;
			}
		}
	}

	// Token: 0x06001150 RID: 4432 RVA: 0x000711E4 File Offset: 0x0006F5E4
	private void Start()
	{
		this._vLights.Clear();
		VLight[] collection = UnityEngine.Object.FindObjectsOfType(typeof(VLight)) as VLight[];
		this._vLights.AddRange(collection);
	}

	// Token: 0x06001151 RID: 4433 RVA: 0x00071220 File Offset: 0x0006F620
	private void Enabled()
	{
		this._vLights.Clear();
		VLight[] collection = UnityEngine.Object.FindObjectsOfType(typeof(VLight)) as VLight[];
		this._vLights.AddRange(collection);
	}

	// Token: 0x04001222 RID: 4642
	public const string VOLUMETRIC_LIGHT_LAYER_NAME = "vlight";

	// Token: 0x04001223 RID: 4643
	public Camera targetCamera;

	// Token: 0x04001224 RID: 4644
	public float maxDistance = 50f;

	// Token: 0x04001225 RID: 4645
	private static VLightManager _instance;

	// Token: 0x04001226 RID: 4646
	private Matrix4x4 _projection;

	// Token: 0x04001227 RID: 4647
	private Matrix4x4 _cameraToWorld;

	// Token: 0x04001228 RID: 4648
	private Matrix4x4 _worldToCamera;

	// Token: 0x04001229 RID: 4649
	private List<VLight> _vLights = new List<VLight>();
}
