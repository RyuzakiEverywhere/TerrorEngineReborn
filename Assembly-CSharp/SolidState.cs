using System;
using UnityEngine;

// Token: 0x020000A9 RID: 169
[Serializable]
internal class SolidState : MotionState
{
	// Token: 0x06000323 RID: 803 RVA: 0x0001E6E7 File Offset: 0x0001CAE7
	public SolidState(EasyflowCamera owner, EasyflowObject obj) : base(owner, obj)
	{
	}

	// Token: 0x06000324 RID: 804 RVA: 0x0001E6F4 File Offset: 0x0001CAF4
	internal override void OnInitialize()
	{
		base.OnInitialize();
		Material[] array = (!this.m_obj.IsPartOfStaticBatch) ? this.m_obj.GetComponent<Renderer>().materials : this.m_obj.GetComponent<Renderer>().sharedMaterials;
		foreach (Material material in array)
		{
			material.SetFloat("_EFLOW_SKINNED", 0f);
			material.SetFloat("_EFLOW_OBJID", (float)this.m_obj.ObjectId / 255f);
			material.SetMatrix("_EFLOW_PREV_MATRIX_MVP", Matrix4x4.identity);
			material.SetMatrix("_EFLOW_CURR_MATRIX_MVP", Matrix4x4.identity);
		}
		this.OnUpdateTransform(true);
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0001E7AC File Offset: 0x0001CBAC
	internal override void OnUpdateTransform(bool starting)
	{
		if (!this.m_initialized)
		{
			this.OnInitialize();
		}
		else
		{
			if (!starting)
			{
				this.m_prevWorld = this.m_currWorld;
				this.m_prevModelViewProj = this.m_currModelViewProj;
			}
			if (this.m_obj.IsPartOfStaticBatch)
			{
				this.m_currModelViewProj = this.m_owner.ViewProjMatrix;
			}
			else
			{
				Transform transform = this.m_obj.transform;
				bool flag = false;
				if (starting || transform.position != this.m_lastPosition || transform.rotation != this.m_lastRotation || transform.localScale != this.m_lastScale)
				{
					this.m_lastPosition = transform.position;
					this.m_lastRotation = transform.rotation;
					this.m_lastScale = transform.localScale;
					flag = true;
				}
				if (starting || flag)
				{
					float num = Mathf.Abs(transform.localScale.x - transform.localScale.y);
					float num2 = Mathf.Abs(transform.localScale.y - transform.localScale.z);
					if (num > 1E-45f || num2 > 1E-45f)
					{
						this.m_currWorld = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
					}
					else
					{
						this.m_currWorld = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
					}
				}
				this.m_prevModelViewProj = this.m_owner.PrevViewProjMatrix * this.m_prevWorld;
				this.m_currModelViewProj = this.m_owner.ViewProjMatrix * this.m_currWorld;
			}
			if (starting)
			{
				this.m_prevWorld = this.m_currWorld;
				this.m_prevModelViewProj = this.m_currModelViewProj;
			}
		}
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0001E994 File Offset: 0x0001CD94
	internal override void OnWillRenderObject()
	{
		if ((this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0)
		{
			Material[] array = (!this.m_obj.IsPartOfStaticBatch) ? this.m_obj.GetComponent<Renderer>().materials : this.m_obj.GetComponent<Renderer>().sharedMaterials;
			foreach (Material material in array)
			{
				material.SetMatrix("_EFLOW_PREV_MATRIX_MVP", this.m_prevModelViewProj);
				material.SetMatrix("_EFLOW_CURR_MATRIX_MVP", this.m_currModelViewProj);
			}
		}
		else
		{
			Material[] array3 = (!this.m_obj.IsPartOfStaticBatch) ? this.m_obj.GetComponent<Renderer>().materials : this.m_obj.GetComponent<Renderer>().sharedMaterials;
			foreach (Material material2 in array3)
			{
				material2.SetMatrix("_EFLOW_PREV_MATRIX_MVP", Matrix4x4.identity);
				material2.SetMatrix("_EFLOW_CURR_MATRIX_MVP", Matrix4x4.identity);
			}
		}
	}

	// Token: 0x04000389 RID: 905
	public Matrix4x4 m_currModelViewProj;

	// Token: 0x0400038A RID: 906
	public Matrix4x4 m_currWorld;

	// Token: 0x0400038B RID: 907
	public Vector3 m_lastPosition;

	// Token: 0x0400038C RID: 908
	public Quaternion m_lastRotation;

	// Token: 0x0400038D RID: 909
	public Vector3 m_lastScale;

	// Token: 0x0400038E RID: 910
	public Matrix4x4 m_prevModelViewProj;

	// Token: 0x0400038F RID: 911
	public Matrix4x4 m_prevWorld;
}
