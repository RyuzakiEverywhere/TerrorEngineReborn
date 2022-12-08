using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A4 RID: 164
[AddComponentMenu("")]
public class EasyflowObject : MonoBehaviour
{
	// Token: 0x0600030E RID: 782 RVA: 0x0001DC84 File Offset: 0x0001C084
	private void OnCameraPostRender(Camera camera)
	{
		MotionState motionState = null;
		if (this.m_states.TryGetValue(Camera.current, out motionState))
		{
			motionState.OnCameraPostRender(camera);
		}
	}

	// Token: 0x0600030F RID: 783 RVA: 0x0001DCB1 File Offset: 0x0001C0B1
	private void OnDisable()
	{
		Easyflow.UnregisterObject(this);
	}

	// Token: 0x06000310 RID: 784 RVA: 0x0001DCBC File Offset: 0x0001C0BC
	private void OnEnable()
	{
		if (base.GetComponent<Renderer>().GetType() == typeof(MeshRenderer))
		{
			this.m_type = EasyflowObjectType.Solid;
		}
		else if (base.GetComponent<Renderer>().GetType() == typeof(SkinnedMeshRenderer))
		{
			this.m_type = EasyflowObjectType.Skinned;
		}
		Easyflow.RegisterObject(this);
	}

	// Token: 0x06000311 RID: 785 RVA: 0x0001DD18 File Offset: 0x0001C118
	private void OnUpdateTransform(EasyflowCamera owner, bool starting)
	{
		MotionState motionState;
		if (this.m_states.TryGetValue(owner.GetComponent<Camera>(), out motionState))
		{
			motionState.OnUpdateTransform(starting);
		}
	}

	// Token: 0x06000312 RID: 786 RVA: 0x0001DD44 File Offset: 0x0001C144
	private void OnWillRenderObject()
	{
		MotionState motionState = null;
		if (this.m_states.TryGetValue(Camera.current, out motionState))
		{
			motionState.OnWillRenderObject();
		}
	}

	// Token: 0x06000313 RID: 787 RVA: 0x0001DD70 File Offset: 0x0001C170
	internal void RegisterCamera(EasyflowCamera camera)
	{
		if ((camera.GetComponent<Camera>().cullingMask & 1 << base.gameObject.layer) != 0 && !this.m_states.ContainsKey(camera.GetComponent<Camera>()))
		{
			MotionState motionState = null;
			switch (this.m_type)
			{
			case EasyflowObjectType.Solid:
				motionState = new SolidState(camera, this);
				break;
			case EasyflowObjectType.Skinned:
				motionState = new SkinnedState(camera, this);
				break;
			case EasyflowObjectType.Cloth:
				break;
			default:
				throw new Exception("[Easyflow] Invalid object type.");
			}
			camera.OnUpdateTransform += this.OnUpdateTransform;
			if (this.m_type == EasyflowObjectType.Cloth)
			{
				camera.OnCameraPostRender += this.OnCameraPostRender;
			}
			this.m_states.Add(camera.GetComponent<Camera>(), motionState);
			this.m_debugStates.Add(motionState);
		}
	}

	// Token: 0x06000314 RID: 788 RVA: 0x0001DE50 File Offset: 0x0001C250
	private void Start()
	{
		this.IsPartOfStaticBatch = base.GetComponent<Renderer>().isPartOfStaticBatch;
		this.ObjectId = Easyflow.Instance.GenerateObjectId(base.gameObject);
		foreach (MotionState motionState in this.m_states.Values)
		{
			motionState.OnInitialize();
		}
	}

	// Token: 0x06000315 RID: 789 RVA: 0x0001DED8 File Offset: 0x0001C2D8
	internal void UnregisterCamera(EasyflowCamera camera)
	{
		MotionState item;
		if (this.m_states.TryGetValue(camera.GetComponent<Camera>(), out item))
		{
			this.m_debugStates.Remove(item);
			camera.OnUpdateTransform -= this.OnUpdateTransform;
			if (this.m_type == EasyflowObjectType.Cloth)
			{
				camera.OnCameraPostRender -= this.OnCameraPostRender;
			}
			this.m_states.Remove(camera.GetComponent<Camera>());
		}
	}

	// Token: 0x04000371 RID: 881
	internal bool IsPartOfStaticBatch;

	// Token: 0x04000372 RID: 882
	internal List<MotionState> m_debugStates = new List<MotionState>();

	// Token: 0x04000373 RID: 883
	private Dictionary<Camera, MotionState> m_states = new Dictionary<Camera, MotionState>();

	// Token: 0x04000374 RID: 884
	private EasyflowObjectType m_type;

	// Token: 0x04000375 RID: 885
	internal int ObjectId;
}
