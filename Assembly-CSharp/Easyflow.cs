using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200009F RID: 159
[AddComponentMenu("Image Effects/Easyflow Motion Blur")]
[RequireComponent(typeof(Camera))]
public class Easyflow : MonoBehaviour
{
	// Token: 0x060002CE RID: 718 RVA: 0x0001C394 File Offset: 0x0001A794
	private EasyflowCamera AddMotionCamera(Camera reference)
	{
		Easyflow.CurrentInstance = this;
		Easyflow.CurrentReference = reference;
		string text = "Easyflow+" + reference.name;
		GameObject gameObject = this.RecursiveFindCamera(base.gameObject, text);
		EasyflowCamera easyflowCamera = null;
		if (gameObject == null)
		{
			gameObject = new GameObject
			{
				name = text,
				hideFlags = HideFlags.HideAndDontSave
			};
		}
		else
		{
			easyflowCamera = gameObject.GetComponent<EasyflowCamera>();
		}
		if (easyflowCamera == null)
		{
			easyflowCamera = gameObject.AddComponent<EasyflowCamera>();
			easyflowCamera.GetComponent<Camera>().CopyFrom(reference);
			easyflowCamera.GetComponent<Camera>().depth = reference.depth - 1f;
			easyflowCamera.GetComponent<Camera>().renderingPath = RenderingPath.VertexLit;
			easyflowCamera.GetComponent<Camera>().hdr = false;
			easyflowCamera.GetComponent<Camera>().cullingMask = reference.cullingMask;
			easyflowCamera.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			easyflowCamera.GetComponent<Camera>().enabled = true;
			easyflowCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
			easyflowCamera.GetComponent<Camera>().SetReplacementShader(this.m_motionMaterial.shader, "RenderType");
		}
		Easyflow.CurrentReference = null;
		Easyflow.CurrentInstance = null;
		return easyflowCamera;
	}

	// Token: 0x060002CF RID: 719 RVA: 0x0001C4A8 File Offset: 0x0001A8A8
	private void Awake()
	{
		if (Easyflow.m_firstInstance == null)
		{
			Easyflow.m_firstInstance = this;
		}
		this.m_globalObjectId = 1;
		this.m_width = 0;
		this.m_height = 0;
		this.m_rcpWidth = (this.m_rcpHeight = 0f);
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x0001C4F4 File Offset: 0x0001A8F4
	private void CheckMaterialAndShader(Material material, string name)
	{
		if (material == null || material.shader == null)
		{
			Debug.LogError("[Easyflow] Error creating " + name + " material");
		}
		else if (!material.shader.isSupported)
		{
			Debug.LogError("[Easyflow] " + name + " shader not supported on this platform");
		}
		else
		{
			material.hideFlags = HideFlags.DontSave;
		}
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x0001C56A File Offset: 0x0001A96A
	public bool CheckSupport()
	{
		if (SystemInfo.supportsImageEffects && SystemInfo.supportsRenderTextures)
		{
			return true;
		}
		Debug.LogError("[Easyflow] Initialization failed. This plugin requires support for Image Effects and Render Textures.");
		return false;
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x0001C590 File Offset: 0x0001A990
	private void CreateMaterials()
	{
		if (this.QualityLevel == Easyflow.Quality.Mobile)
		{
			this.m_blurMaterial = new Material(Shader.Find("Hidden/Easyflow/MotionBlurMobile"));
			this.m_motionMaterial = new Material(Shader.Find("Hidden/Easyflow/VectorsMobile"));
		}
		else if (this.QualityLevel == Easyflow.Quality.Standard)
		{
			this.m_blurMaterial = new Material(Shader.Find("Hidden/Easyflow/MotionBlur"));
			this.m_motionMaterial = new Material(Shader.Find("Hidden/Easyflow/Vectors"));
			this.m_combineMaterial = new Material(Shader.Find("Hidden/Easyflow/Combine"));
			this.CheckMaterialAndShader(this.m_combineMaterial, "Combine");
		}
		this.CheckMaterialAndShader(this.m_blurMaterial, "Blur");
		this.CheckMaterialAndShader(this.m_motionMaterial, "Vectors");
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0001C658 File Offset: 0x0001AA58
	private bool FindValidTag(Material[] materials)
	{
		for (int i = 0; i < materials.Length; i++)
		{
			if (materials[i] != null)
			{
				string tag = materials[i].GetTag("RenderType", false);
				if (tag != null)
				{
					if (tag == "Opaque" || tag == "TransparentCutout")
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0001C6C4 File Offset: 0x0001AAC4
	public int GenerateObjectId(GameObject obj)
	{
		if (obj.isStatic)
		{
			return 0;
		}
		if (this.m_globalObjectId > 255)
		{
			return 0;
		}
		return this.m_globalObjectId++;
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x0001C704 File Offset: 0x0001AB04
	private void InitializeCameras()
	{
		Camera[] array = new Camera[this.OverlayCameras.Length + 1];
		array[0] = base.GetComponent<Camera>();
		for (int i = 0; i < this.OverlayCameras.Length; i++)
		{
			array[i + 1] = this.OverlayCameras[i];
		}
		this.m_linkedCameras.Clear();
		foreach (Camera camera in array)
		{
			if (!this.m_linkedCameras.ContainsKey(camera))
			{
				EasyflowCamera value = this.AddMotionCamera(camera);
				this.m_linkedCameras.Add(camera, value);
			}
		}
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x0001C79C File Offset: 0x0001AB9C
	internal void InternalRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.UpdateRenderTextures();
		float num = 1f / Mathf.Clamp(this.m_deltaTime, 0.005f, 0.06666667f);
		Vector4 zero = Vector4.zero;
		zero.x = this.MotionScale * this.m_rcpWidth * num * 0.125f;
		zero.y = this.MotionScale * this.m_rcpHeight * num * 0.125f;
		if (this.QualityLevel == Easyflow.Quality.Mobile)
		{
			this.RenderMobile(source, destination, zero);
		}
		else if (this.QualityLevel == Easyflow.Quality.Standard)
		{
			this.RenderStandard(source, destination, zero);
		}
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x0001C838 File Offset: 0x0001AC38
	private void LateUpdate()
	{
		if (this.m_baseCamera.AutoStep)
		{
			this.m_deltaTime = Time.deltaTime;
		}
		this.MotionScale = Mathf.Max(this.MotionScale, 0f);
		foreach (EasyflowCamera easyflowCamera in this.m_linkedCameras.Values)
		{
			easyflowCamera.UpdateProperties();
			if (!easyflowCamera.gameObject.activeInHierarchy)
			{
				easyflowCamera.gameObject.SetActive(true);
			}
		}
		this.UpdatePostProcess();
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0001C8EC File Offset: 0x0001ACEC
	private void LinkCameras()
	{
		foreach (KeyValuePair<Camera, EasyflowCamera> keyValuePair in this.m_linkedCameras)
		{
			keyValuePair.Value.transform.parent = keyValuePair.Key.transform;
			keyValuePair.Value.gameObject.SetActive(true);
		}
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x0001C970 File Offset: 0x0001AD70
	private void OnDestroy()
	{
		foreach (EasyflowCamera easyflowCamera in this.m_linkedCameras.Values)
		{
			UnityEngine.Object.Destroy(easyflowCamera.gameObject);
		}
	}

	// Token: 0x060002DA RID: 730 RVA: 0x0001C9D8 File Offset: 0x0001ADD8
	private void OnDisable()
	{
		if (this.m_currentPostProcess != null)
		{
			this.m_currentPostProcess.enabled = false;
		}
	}

	// Token: 0x060002DB RID: 731 RVA: 0x0001C9F8 File Offset: 0x0001ADF8
	private void OnEnable()
	{
		if (!this.CheckSupport())
		{
			base.enabled = false;
		}
		else
		{
			this.CreateMaterials();
			this.UpdateActiveObjects();
			this.InitializeCameras();
			this.m_linkedCameras.TryGetValue(base.GetComponent<Camera>(), out this.m_baseCamera);
			if (this.m_currentPostProcess != null)
			{
				this.m_currentPostProcess.enabled = true;
			}
		}
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0001CA64 File Offset: 0x0001AE64
	private GameObject RecursiveFindCamera(GameObject obj, string auxCameraName)
	{
		GameObject gameObject = null;
		if (obj.name == auxCameraName)
		{
			return obj;
		}
		IEnumerator enumerator = obj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				Transform transform = (Transform)obj2;
				gameObject = this.RecursiveFindCamera(transform.gameObject, auxCameraName);
				if (gameObject != null)
				{
					return gameObject;
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		return gameObject;
	}

	// Token: 0x060002DD RID: 733 RVA: 0x0001CB00 File Offset: 0x0001AF00
	public void Register(GameObject gameObj)
	{
		if (!Easyflow.m_activeObjects.ContainsKey(gameObj))
		{
			this.TryRegister(gameObj);
		}
	}

	// Token: 0x060002DE RID: 734 RVA: 0x0001CB1C File Offset: 0x0001AF1C
	internal static void RegisterCamera(EasyflowCamera cam)
	{
		Easyflow.m_activeCameras.Add(cam.GetComponent<Camera>(), cam);
		foreach (EasyflowObject easyflowObject in Easyflow.m_activeObjects.Values)
		{
			easyflowObject.RegisterCamera(cam);
		}
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0001CB90 File Offset: 0x0001AF90
	internal static void RegisterObject(EasyflowObject obj)
	{
		Easyflow.m_activeObjects.Add(obj.gameObject, obj);
		foreach (EasyflowCamera camera in Easyflow.m_activeCameras.Values)
		{
			obj.RegisterCamera(camera);
		}
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0001CC04 File Offset: 0x0001B004
	public void RegisterRecursively(GameObject gameObj)
	{
		if (!Easyflow.m_activeObjects.ContainsKey(gameObj))
		{
			this.TryRegister(gameObj);
		}
		IEnumerator enumerator = gameObj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				this.RegisterRecursively(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0001CC88 File Offset: 0x0001B088
	internal void ReleaseCamera(Camera reference)
	{
		this.m_linkedCameras.Remove(reference);
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x0001CC97 File Offset: 0x0001B097
	private void RenderMobile(RenderTexture source, RenderTexture destination, Vector4 blurStep)
	{
		this.m_blurMaterial.SetTexture("_MotionTex", this.m_motionRenderTex);
		this.m_blurMaterial.SetVector("_BlurStep", blurStep);
		Graphics.Blit(source, destination, this.m_blurMaterial);
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0001CCD0 File Offset: 0x0001B0D0
	private void RenderStandard(RenderTexture source, RenderTexture destination, Vector4 blurStep)
	{
		this.m_combineMaterial.SetTexture("_MotionTex", this.m_motionRenderTex);
		this.m_blurMaterial.SetTexture("_MotionTex", this.m_motionRenderTex);
		Graphics.Blit(source, this.m_combinedRenderTex, this.m_combineMaterial);
		if (this.QualitySteps > 1)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, (!this.m_hdr) ? RenderTextureFormat.ARGB32 : RenderTextureFormat.ARGBHalf);
			float num = 1f / (float)this.QualitySteps;
			float num2 = 1f;
			RenderTexture renderTexture = this.m_combinedRenderTex;
			RenderTexture renderTexture2 = temporary;
			for (int i = 0; i < this.QualitySteps; i++)
			{
				this.m_blurMaterial.SetVector("_BlurStep", blurStep * num2);
				Graphics.Blit(renderTexture, renderTexture2, this.m_blurMaterial);
				if (i < this.QualitySteps - 2)
				{
					RenderTexture renderTexture3 = renderTexture2;
					renderTexture2 = renderTexture;
					renderTexture = renderTexture3;
				}
				else
				{
					renderTexture = renderTexture2;
					renderTexture2 = destination;
				}
				num2 -= num;
			}
			RenderTexture.ReleaseTemporary(temporary);
		}
		else
		{
			this.m_blurMaterial.SetVector("_BlurStep", blurStep);
			Graphics.Blit(this.m_combinedRenderTex, destination, this.m_blurMaterial);
		}
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0001CE00 File Offset: 0x0001B200
	private void Start()
	{
		this.UpdatePostProcess();
		this.UpdateRenderTextures();
		this.LinkCameras();
		if (this.MotionScale > 20f && !Easyflow.IgnoreMotionScaleWarning)
		{
			Debug.LogWarning("[Easyflow] MotionScale range has been changed. Default is now 2, and max recommended is 10. Please adjust.\nNOTE: To get rid of this warning, please set 'Easyflow.IgnoreMotionScaleWarning = true' via script, e.g. on Awake(). ");
		}
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x0001CE38 File Offset: 0x0001B238
	public void StartAutoStep()
	{
		foreach (EasyflowCamera easyflowCamera in this.m_linkedCameras.Values)
		{
			easyflowCamera.StartAutoStep();
		}
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x0001CE98 File Offset: 0x0001B298
	public void Step(float delta)
	{
		this.m_deltaTime = delta;
		foreach (EasyflowCamera easyflowCamera in this.m_linkedCameras.Values)
		{
			easyflowCamera.Step();
		}
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0001CF00 File Offset: 0x0001B300
	public void StopAutoStep()
	{
		foreach (EasyflowCamera easyflowCamera in this.m_linkedCameras.Values)
		{
			easyflowCamera.StopAutoStep();
		}
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0001CF60 File Offset: 0x0001B360
	private void TryRegister(GameObject gameObj)
	{
		Renderer component = gameObj.GetComponent<Renderer>();
		if (!(component != null) || component.sharedMaterials == null || !component.enabled || !this.FindValidTag(component.sharedMaterials) || component.GetType() == typeof(MeshRenderer) || component.GetType() == typeof(SkinnedMeshRenderer))
		{
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0001CFD4 File Offset: 0x0001B3D4
	internal static void UnregisterCamera(EasyflowCamera cam)
	{
		foreach (EasyflowObject easyflowObject in Easyflow.m_activeObjects.Values)
		{
			easyflowObject.UnregisterCamera(cam);
		}
		Easyflow.m_activeCameras.Remove(cam.GetComponent<Camera>());
	}

	// Token: 0x060002EA RID: 746 RVA: 0x0001D048 File Offset: 0x0001B448
	internal static void UnregisterObject(EasyflowObject obj)
	{
		foreach (EasyflowCamera camera in Easyflow.m_activeCameras.Values)
		{
			obj.UnregisterCamera(camera);
		}
		Easyflow.m_activeObjects.Remove(obj.gameObject);
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0001D0BC File Offset: 0x0001B4BC
	public void UpdateActiveObjects()
	{
		GameObject[] array = UnityEngine.Object.FindSceneObjectsOfType(typeof(GameObject)) as GameObject[];
		for (int i = 0; i < array.Length; i++)
		{
			if (!Easyflow.m_activeObjects.ContainsKey(array[i]))
			{
				this.TryRegister(array[i]);
			}
		}
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0001D110 File Offset: 0x0001B510
	private void UpdatePostProcess()
	{
		Camera camera = null;
		float num = float.MinValue;
		foreach (Camera camera2 in this.m_linkedCameras.Keys)
		{
			if (camera2.depth > num)
			{
				camera = camera2;
				num = camera2.depth;
			}
		}
		if (this.m_currentPostProcess != null && this.m_currentPostProcess.gameObject != camera.gameObject)
		{
			UnityEngine.Object.Destroy(this.m_currentPostProcess);
			this.m_currentPostProcess = null;
		}
		if (this.m_currentPostProcess == null && camera != null)
		{
			Easyflow.CurrentInstance = this;
			this.m_currentPostProcess = camera.gameObject.AddComponent<EasyflowPostProcess>();
			Easyflow.CurrentInstance = null;
		}
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0001D200 File Offset: 0x0001B600
	private void UpdateRenderTextures()
	{
		if (this.m_width != base.GetComponent<Camera>().pixelWidth || this.m_height != base.GetComponent<Camera>().pixelHeight || this.m_hdr != base.GetComponent<Camera>().hdr)
		{
			this.m_width = base.GetComponent<Camera>().pixelWidth;
			this.m_height = base.GetComponent<Camera>().pixelHeight;
			this.m_rcpWidth = 1f / (float)this.m_width;
			this.m_rcpHeight = 1f / (float)this.m_height;
			this.m_hdr = base.GetComponent<Camera>().hdr;
			if (this.m_motionRenderTex != null)
			{
				UnityEngine.Object.Destroy(this.m_motionRenderTex);
				this.m_motionRenderTex = null;
			}
			if (this.m_combinedRenderTex != null)
			{
				UnityEngine.Object.Destroy(this.m_combinedRenderTex);
				this.m_combinedRenderTex = null;
			}
		}
		if (this.m_motionRenderTex == null)
		{
			this.m_motionRenderTex = new RenderTexture(this.m_width, this.m_height, 16, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			this.m_motionRenderTex.name = "EasyflowMotionRT+" + base.name;
			this.m_motionRenderTex.wrapMode = TextureWrapMode.Clamp;
			this.m_motionRenderTex.hideFlags = HideFlags.DontSave;
			this.m_motionRenderTex.Create();
			foreach (EasyflowCamera easyflowCamera in this.m_linkedCameras.Values)
			{
				easyflowCamera.GetComponent<Camera>().targetTexture = this.m_motionRenderTex;
			}
		}
		if (this.m_combinedRenderTex == null && this.QualityLevel == Easyflow.Quality.Standard)
		{
			this.m_combinedRenderTex = new RenderTexture(this.m_width, this.m_height, 0, (!this.m_hdr) ? RenderTextureFormat.ARGB32 : RenderTextureFormat.ARGBHalf);
			this.m_combinedRenderTex.name = "EasyflowCombinedRT+" + base.name;
			this.m_combinedRenderTex.wrapMode = TextureWrapMode.Clamp;
			this.m_combinedRenderTex.hideFlags = HideFlags.DontSave;
			this.m_combinedRenderTex.Create();
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060002EE RID: 750 RVA: 0x0001D440 File Offset: 0x0001B840
	public EasyflowCamera BaseCamera
	{
		get
		{
			return this.m_baseCamera;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060002EF RID: 751 RVA: 0x0001D448 File Offset: 0x0001B848
	public static Easyflow FirstInstance
	{
		get
		{
			return Easyflow.m_firstInstance;
		}
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x060002F0 RID: 752 RVA: 0x0001D44F File Offset: 0x0001B84F
	public static Easyflow Instance
	{
		get
		{
			return Easyflow.m_firstInstance;
		}
	}

	// Token: 0x04000340 RID: 832
	public LayerMask CullingMask = -1;

	// Token: 0x04000341 RID: 833
	internal static Easyflow CurrentInstance = null;

	// Token: 0x04000342 RID: 834
	internal static EasyflowCamera CurrentOwner = null;

	// Token: 0x04000343 RID: 835
	internal static Camera CurrentReference = null;

	// Token: 0x04000344 RID: 836
	public static bool IgnoreMotionScaleWarning = false;

	// Token: 0x04000345 RID: 837
	public static Dictionary<Camera, EasyflowCamera> m_activeCameras = new Dictionary<Camera, EasyflowCamera>();

	// Token: 0x04000346 RID: 838
	public static Dictionary<GameObject, EasyflowObject> m_activeObjects = new Dictionary<GameObject, EasyflowObject>();

	// Token: 0x04000347 RID: 839
	private EasyflowCamera m_baseCamera;

	// Token: 0x04000348 RID: 840
	private Material m_blurMaterial;

	// Token: 0x04000349 RID: 841
	private RenderTexture m_combinedRenderTex;

	// Token: 0x0400034A RID: 842
	private Material m_combineMaterial;

	// Token: 0x0400034B RID: 843
	private EasyflowPostProcess m_currentPostProcess;

	// Token: 0x0400034C RID: 844
	private float m_deltaTime;

	// Token: 0x0400034D RID: 845
	private static Easyflow m_firstInstance = null;

	// Token: 0x0400034E RID: 846
	private int m_globalObjectId = 1;

	// Token: 0x0400034F RID: 847
	private bool m_hdr;

	// Token: 0x04000350 RID: 848
	private int m_height;

	// Token: 0x04000351 RID: 849
	private Dictionary<Camera, EasyflowCamera> m_linkedCameras = new Dictionary<Camera, EasyflowCamera>();

	// Token: 0x04000352 RID: 850
	private Material m_motionMaterial;

	// Token: 0x04000353 RID: 851
	private RenderTexture m_motionRenderTex;

	// Token: 0x04000354 RID: 852
	private float m_rcpHeight;

	// Token: 0x04000355 RID: 853
	private float m_rcpWidth;

	// Token: 0x04000356 RID: 854
	private int m_width;

	// Token: 0x04000357 RID: 855
	public float MotionScale = 2f;

	// Token: 0x04000358 RID: 856
	public Camera[] OverlayCameras;

	// Token: 0x04000359 RID: 857
	public Easyflow.Quality QualityLevel = Easyflow.Quality.Standard;

	// Token: 0x0400035A RID: 858
	public int QualitySteps = 1;

	// Token: 0x020000A0 RID: 160
	public enum Quality
	{
		// Token: 0x0400035C RID: 860
		Mobile,
		// Token: 0x0400035D RID: 861
		Standard
	}
}
