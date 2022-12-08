using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020000A1 RID: 161
[RequireComponent(typeof(Camera))]
[AddComponentMenu("")]
public class EasyflowCamera : MonoBehaviour
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x060002F3 RID: 755 RVA: 0x0001D4A0 File Offset: 0x0001B8A0
	// (remove) Token: 0x060002F4 RID: 756 RVA: 0x0001D4D8 File Offset: 0x0001B8D8
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal event EasyflowCamera.OnCameraPostRenderDelegate OnCameraPostRender;

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x060002F5 RID: 757 RVA: 0x0001D510 File Offset: 0x0001B910
	// (remove) Token: 0x060002F6 RID: 758 RVA: 0x0001D548 File Offset: 0x0001B948
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal event EasyflowCamera.OnUpdateTransformDelegate OnUpdateTransform;

	// Token: 0x060002F7 RID: 759 RVA: 0x0001D57E File Offset: 0x0001B97E
	private void LateUpdate()
	{
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x0001D580 File Offset: 0x0001B980
	private void OnDestroy()
	{
		this.Instance.ReleaseCamera(this.Reference);
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0001D593 File Offset: 0x0001B993
	private void OnDisable()
	{
		Easyflow.UnregisterCamera(this);
	}

	// Token: 0x060002FA RID: 762 RVA: 0x0001D59C File Offset: 0x0001B99C
	private void OnEnable()
	{
		Easyflow.RegisterCamera(this);
		if (this.Instance == null)
		{
			this.Instance = Easyflow.CurrentInstance;
		}
		if (this.Reference == null)
		{
			this.Reference = Easyflow.CurrentReference;
		}
		this.m_material = new Material(Shader.Find("Hidden/Easyflow/BackgroundVectors"));
		this.m_material.hideFlags = HideFlags.DontSave;
		int[] triangles = new int[]
		{
			0,
			1,
			2,
			2,
			1,
			3,
			4,
			0,
			6,
			6,
			0,
			2,
			7,
			5,
			6,
			6,
			5,
			4,
			3,
			1,
			7,
			7,
			1,
			5,
			4,
			5,
			0,
			0,
			5,
			1,
			3,
			7,
			2,
			2,
			7,
			6
		};
		Vector3[] vertices = new Vector3[]
		{
			new Vector3(-1f, 1f, -1f),
			new Vector3(1f, 1f, -1f),
			new Vector3(-1f, -1f, -1f),
			new Vector3(1f, -1f, -1f),
			new Vector3(-1f, 1f, 1f),
			new Vector3(1f, 1f, 1f),
			new Vector3(-1f, -1f, 1f),
			new Vector3(1f, -1f, 1f)
		};
		this.m_cube = new Mesh();
		this.m_cube.vertices = vertices;
		this.m_cube.triangles = triangles;
		this.UpdateProperties();
		this.m_step = false;
	}

	// Token: 0x060002FB RID: 763 RVA: 0x0001D753 File Offset: 0x0001BB53
	internal void OnPostRender()
	{
		if (this.Instance != null && this.OnCameraPostRender != null)
		{
			this.OnCameraPostRender(base.GetComponent<Camera>());
		}
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0001D784 File Offset: 0x0001BB84
	private void OnPreCull()
	{
		if (Time.frameCount > this.m_prevFrameCount && (this.m_autoStep || this.m_step))
		{
			bool flag = false;
			if (this.m_starting || base.transform.position != this.m_lastPosition || base.transform.rotation != this.m_lastRotation || base.transform.localScale != this.m_lastScale)
			{
				this.m_lastPosition = base.transform.position;
				this.m_lastRotation = base.transform.rotation;
				this.m_lastScale = base.transform.localScale;
				flag = true;
			}
			if (!this.m_starting)
			{
				this.PrevViewProjMatrix = this.ViewProjMatrix;
			}
			if (this.m_starting || flag)
			{
				Matrix4x4 worldToLocalMatrix = base.GetComponent<Camera>().transform.worldToLocalMatrix;
				Matrix4x4 gpuprojectionMatrix = GL.GetGPUProjectionMatrix(base.GetComponent<Camera>().projectionMatrix, true);
				gpuprojectionMatrix[2, 2] = -gpuprojectionMatrix[2, 2];
				gpuprojectionMatrix[3, 2] = -gpuprojectionMatrix[3, 2];
				this.ViewProjMatrix = gpuprojectionMatrix * worldToLocalMatrix;
			}
			if (this.m_starting)
			{
				this.PrevViewProjMatrix = this.ViewProjMatrix;
			}
			this.UpdateTransform(this.m_starting);
			if (this.OnUpdateTransform != null)
			{
				this.OnUpdateTransform(this, this.m_starting);
			}
			this.m_starting = false;
			this.m_step = false;
			this.m_prevFrameCount = Time.frameCount;
		}
	}

	// Token: 0x060002FD RID: 765 RVA: 0x0001D924 File Offset: 0x0001BD24
	internal void OnPreRender()
	{
		if (this.Instance != null && this.Reference == this.Instance.GetComponent<Camera>())
		{
			Shader.SetGlobalMatrix("_EFLOW_PREV_MATRIX_MVP", this.m_prevBackgroundTransform);
			Shader.SetGlobalMatrix("_EFLOW_CURR_MATRIX_MVP", this.m_currBackgroundTransform);
			Shader.SetGlobalFloat("_EFLOW_SKINNED", 0f);
			Shader.SetGlobalFloat("_EFLOW_OBJID", 0f);
			RenderTexture.active = base.GetComponent<Camera>().targetTexture;
			float num = base.GetComponent<Camera>().near * 2f;
			if (this.m_material.SetPass(0))
			{
				Graphics.DrawMeshNow(this.m_cube, Matrix4x4.TRS(base.GetComponent<Camera>().transform.position, Quaternion.identity, new Vector3(num, num, num)));
			}
			if (Terrain.activeTerrain != null && (this.Instance.CullingMask & 1 << Terrain.activeTerrain.gameObject.layer) != 0)
			{
				Shader.SetGlobalMatrix("_EFLOW_PREV_MATRIX_MVP", this.m_prevTerrainTransform);
				Shader.SetGlobalMatrix("_EFLOW_CURR_MATRIX_MVP", this.m_currTerrainTransform);
			}
			else
			{
				Shader.SetGlobalMatrix("_EFLOW_PREV_MATRIX_MVP", Matrix4x4.identity);
				Shader.SetGlobalMatrix("_EFLOW_CURR_MATRIX_MVP", Matrix4x4.identity);
			}
		}
	}

	// Token: 0x060002FE RID: 766 RVA: 0x0001DA78 File Offset: 0x0001BE78
	private void Start()
	{
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0001DA7A File Offset: 0x0001BE7A
	internal void StartAutoStep()
	{
		this.m_autoStep = true;
	}

	// Token: 0x06000300 RID: 768 RVA: 0x0001DA83 File Offset: 0x0001BE83
	internal void Step()
	{
		this.m_step = true;
	}

	// Token: 0x06000301 RID: 769 RVA: 0x0001DA8C File Offset: 0x0001BE8C
	internal void StopAutoStep()
	{
		if (this.m_autoStep)
		{
			this.m_autoStep = false;
			this.m_step = true;
		}
	}

	// Token: 0x06000302 RID: 770 RVA: 0x0001DAA8 File Offset: 0x0001BEA8
	internal void UpdateProperties()
	{
		base.GetComponent<Camera>().cullingMask = this.Reference.cullingMask;
		base.GetComponent<Camera>().pixelRect = this.Reference.pixelRect;
		base.GetComponent<Camera>().rect = this.Reference.rect;
		base.GetComponent<Camera>().orthographic = this.Reference.orthographic;
		base.GetComponent<Camera>().orthographicSize = this.Reference.orthographicSize;
		base.GetComponent<Camera>().aspect = this.Reference.aspect;
		base.GetComponent<Camera>().fov = this.Reference.fov;
		base.GetComponent<Camera>().near = this.Reference.near;
		base.GetComponent<Camera>().far = this.Reference.far;
		base.GetComponent<Camera>().depth = this.Reference.depth - 1f;
	}

	// Token: 0x06000303 RID: 771 RVA: 0x0001DB98 File Offset: 0x0001BF98
	private void UpdateTransform(bool starting)
	{
		if (!starting)
		{
			this.m_prevBackgroundTransform = this.m_currBackgroundTransform;
			this.m_prevTerrainTransform = this.m_currTerrainTransform;
		}
		this.m_currBackgroundTransform = this.ViewProjMatrix * Matrix4x4.TRS(base.GetComponent<Camera>().transform.position, Quaternion.identity, Vector3.one);
		if (Terrain.activeTerrain != null)
		{
			this.m_currTerrainTransform = this.ViewProjMatrix * Matrix4x4.TRS(Terrain.activeTerrain.GetPosition(), Quaternion.identity, Vector3.one);
		}
		else
		{
			this.m_currTerrainTransform = this.ViewProjMatrix;
		}
		if (starting)
		{
			this.m_prevBackgroundTransform = this.m_currBackgroundTransform;
			this.m_prevTerrainTransform = this.m_currTerrainTransform;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000304 RID: 772 RVA: 0x0001DC5C File Offset: 0x0001C05C
	public bool AutoStep
	{
		get
		{
			return this.m_autoStep;
		}
	}

	// Token: 0x0400035E RID: 862
	internal Easyflow Instance;

	// Token: 0x0400035F RID: 863
	private bool m_autoStep = true;

	// Token: 0x04000360 RID: 864
	private Mesh m_cube;

	// Token: 0x04000361 RID: 865
	private Matrix4x4 m_currBackgroundTransform;

	// Token: 0x04000362 RID: 866
	private Matrix4x4 m_currTerrainTransform;

	// Token: 0x04000363 RID: 867
	private Vector3 m_lastPosition;

	// Token: 0x04000364 RID: 868
	private Quaternion m_lastRotation;

	// Token: 0x04000365 RID: 869
	private Vector3 m_lastScale;

	// Token: 0x04000366 RID: 870
	private Material m_material;

	// Token: 0x04000367 RID: 871
	private Matrix4x4 m_prevBackgroundTransform;

	// Token: 0x04000368 RID: 872
	private int m_prevFrameCount;

	// Token: 0x04000369 RID: 873
	private Matrix4x4 m_prevTerrainTransform;

	// Token: 0x0400036A RID: 874
	private bool m_starting = true;

	// Token: 0x0400036B RID: 875
	private bool m_step;

	// Token: 0x0400036C RID: 876
	internal Matrix4x4 PrevViewProjMatrix;

	// Token: 0x0400036D RID: 877
	internal Camera Reference;

	// Token: 0x0400036E RID: 878
	internal Matrix4x4 ViewProjMatrix;

	// Token: 0x020000A2 RID: 162
	// (Invoke) Token: 0x06000306 RID: 774
	internal delegate void OnCameraPostRenderDelegate(Camera camera);

	// Token: 0x020000A3 RID: 163
	// (Invoke) Token: 0x0600030A RID: 778
	internal delegate void OnUpdateTransformDelegate(EasyflowCamera owner, bool starting);
}
