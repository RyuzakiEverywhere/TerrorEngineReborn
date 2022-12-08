using System;
using UnityEngine;

// Token: 0x020000A7 RID: 167
[Serializable]
internal abstract class MotionState
{
	// Token: 0x06000319 RID: 793 RVA: 0x0001DF92 File Offset: 0x0001C392
	public MotionState(EasyflowCamera owner, EasyflowObject obj)
	{
		this.m_owner = owner;
		this.m_obj = obj;
		this.m_initialized = false;
	}

	// Token: 0x0600031A RID: 794 RVA: 0x0001DFAF File Offset: 0x0001C3AF
	internal virtual void OnCameraPostRender(Camera camera)
	{
	}

	// Token: 0x0600031B RID: 795 RVA: 0x0001DFB1 File Offset: 0x0001C3B1
	internal virtual void OnInitialize()
	{
		this.m_initialized = true;
	}

	// Token: 0x0600031C RID: 796
	internal abstract void OnUpdateTransform(bool starting);

	// Token: 0x0600031D RID: 797 RVA: 0x0001DFBA File Offset: 0x0001C3BA
	internal virtual void OnWillRenderObject()
	{
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x0600031E RID: 798 RVA: 0x0001DFBC File Offset: 0x0001C3BC
	public EasyflowCamera Owner
	{
		get
		{
			return this.m_owner;
		}
	}

	// Token: 0x0400037C RID: 892
	protected bool m_initialized;

	// Token: 0x0400037D RID: 893
	protected EasyflowObject m_obj;

	// Token: 0x0400037E RID: 894
	protected EasyflowCamera m_owner;
}
