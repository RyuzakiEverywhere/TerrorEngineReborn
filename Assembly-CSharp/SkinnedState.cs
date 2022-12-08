using System;
using UnityEngine;

// Token: 0x020000A8 RID: 168
internal class SkinnedState : MotionState
{
	// Token: 0x0600031F RID: 799 RVA: 0x0001DFC4 File Offset: 0x0001C3C4
	public SkinnedState(EasyflowCamera owner, EasyflowObject obj) : base(owner, obj)
	{
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0001DFD0 File Offset: 0x0001C3D0
	internal override void OnInitialize()
	{
		base.OnInitialize();
		this.m_skinnedRenderer = this.m_obj.GetComponent<SkinnedMeshRenderer>();
		this.m_boneCount = this.m_skinnedRenderer.bones.Length;
		this.m_bones = this.m_skinnedRenderer.bones;
		this.m_motions = new Vector2[this.m_boneCount];
		this.m_currCenters = new Vector3[this.m_boneCount];
		this.m_prevCenters = new Vector3[this.m_boneCount];
		Mesh mesh = UnityEngine.Object.Instantiate<Mesh>(this.m_skinnedRenderer.sharedMesh);
		mesh.name = this.GetHashCode().ToString();
		this.m_skinnedRenderer.sharedMesh = mesh;
		this.m_vertexCount = this.m_skinnedRenderer.sharedMesh.vertexCount;
		this.m_vertexMotions = new Vector2[this.m_vertexCount];
		this.m_boneIndices = new int[this.m_vertexCount * 4];
		this.m_boneWeights = new float[this.m_vertexCount * 4];
		BoneWeight[] boneWeights = this.m_skinnedRenderer.sharedMesh.boneWeights;
		for (int i = 0; i < this.m_vertexCount; i++)
		{
			BoneWeight boneWeight = boneWeights[i];
			this.m_boneIndices[i * 4] = boneWeight.boneIndex0;
			this.m_boneWeights[i * 4] = boneWeight.weight0;
			this.m_boneIndices[i * 4 + 1] = boneWeight.boneIndex1;
			this.m_boneWeights[i * 4 + 1] = boneWeight.weight1;
			this.m_boneIndices[i * 4 + 2] = boneWeight.boneIndex2;
			this.m_boneWeights[i * 4 + 2] = boneWeight.weight2;
			this.m_boneIndices[i * 4 + 3] = boneWeight.boneIndex3;
			this.m_boneWeights[i * 4 + 3] = boneWeight.weight3;
		}
		Material[] array = (!this.m_obj.IsPartOfStaticBatch) ? this.m_obj.GetComponent<Renderer>().materials : this.m_obj.GetComponent<Renderer>().sharedMaterials;
		foreach (Material material in array)
		{
			material.SetFloat("_EFLOW_SKINNED", 1f);
			material.SetFloat("_EFLOW_OBJID", (float)this.m_obj.ObjectId / 255f);
		}
		this.OnUpdateTransform(true);
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0001E22C File Offset: 0x0001C62C
	internal override void OnUpdateTransform(bool starting)
	{
		if (!this.m_initialized)
		{
			this.OnInitialize();
		}
		else if ((this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0)
		{
			this.UpdateMesh(starting);
		}
		else
		{
			for (int i = 0; i < this.m_vertexCount; i++)
			{
				this.m_vertexMotions[i] = Vector2.zero;
			}
			this.m_skinnedRenderer.sharedMesh.uv2 = this.m_vertexMotions;
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0001E2D0 File Offset: 0x0001C6D0
	private void UpdateMesh(bool starting)
	{
		bool flag = SystemInfo.graphicsDeviceVersion.IndexOf("Direct3D") > -1;
		Matrix4x4 prevViewProjMatrix = this.m_owner.PrevViewProjMatrix;
		Matrix4x4 viewProjMatrix = this.m_owner.ViewProjMatrix;
		for (int i = 0; i < this.m_boneCount; i++)
		{
			Vector4 v = this.m_prevCenters[i];
			v.w = 1f;
			Vector4 v2 = this.m_bones[i].transform.position;
			v2.w = 1f;
			this.m_prevCenters[i] = this.m_currCenters[i];
			this.m_currCenters[i] = v2;
			Vector4 vector = prevViewProjMatrix * v;
			Vector4 vector2 = viewProjMatrix * v2;
			float num = 1f / vector.w;
			float num2 = 1f / vector2.w;
			vector.x *= num;
			vector2.x *= num2;
			vector.y *= ((!flag) ? num : (-num));
			vector2.y *= ((!flag) ? num2 : (-num2));
			this.m_motions[i].x = vector2.x - vector.x;
			this.m_motions[i].y = vector2.y - vector.y;
		}
		if (starting)
		{
			for (int j = 0; j < this.m_boneCount; j++)
			{
				this.m_prevCenters[j] = this.m_currCenters[j];
			}
			for (int k = 0; k < this.m_vertexCount; k++)
			{
				this.m_vertexMotions[k] = Vector2.zero;
			}
		}
		else
		{
			for (int l = 0; l < this.m_vertexCount; l++)
			{
				int num3 = l * 4;
				int num4 = num3 + 1;
				int num5 = num3 + 2;
				int num6 = num3 + 3;
				Vector2 vector3;
				vector3.x = this.m_motions[this.m_boneIndices[num3]].x * this.m_boneWeights[num3];
				vector3.y = this.m_motions[this.m_boneIndices[num3]].y * this.m_boneWeights[num3];
				Vector2 vector4;
				vector4.x = this.m_motions[this.m_boneIndices[num4]].x * this.m_boneWeights[num4];
				vector4.y = this.m_motions[this.m_boneIndices[num4]].y * this.m_boneWeights[num4];
				Vector2 vector5;
				vector5.x = this.m_motions[this.m_boneIndices[num5]].x * this.m_boneWeights[num5];
				vector5.y = this.m_motions[this.m_boneIndices[num5]].y * this.m_boneWeights[num5];
				Vector2 vector6;
				vector6.x = this.m_motions[this.m_boneIndices[num6]].x * this.m_boneWeights[num6];
				vector6.y = this.m_motions[this.m_boneIndices[num6]].y * this.m_boneWeights[num6];
				this.m_vertexMotions[l].x = vector3.x + vector4.x + vector5.x + vector6.x;
				this.m_vertexMotions[l].y = vector3.y + vector4.y + vector5.y + vector6.y;
			}
		}
		this.m_skinnedRenderer.sharedMesh.uv2 = this.m_vertexMotions;
	}

	// Token: 0x0400037F RID: 895
	private int m_boneCount;

	// Token: 0x04000380 RID: 896
	private int[] m_boneIndices;

	// Token: 0x04000381 RID: 897
	private Transform[] m_bones;

	// Token: 0x04000382 RID: 898
	private float[] m_boneWeights;

	// Token: 0x04000383 RID: 899
	private Vector3[] m_currCenters;

	// Token: 0x04000384 RID: 900
	private Vector2[] m_motions;

	// Token: 0x04000385 RID: 901
	private Vector3[] m_prevCenters;

	// Token: 0x04000386 RID: 902
	private SkinnedMeshRenderer m_skinnedRenderer;

	// Token: 0x04000387 RID: 903
	private int m_vertexCount;

	// Token: 0x04000388 RID: 904
	private Vector2[] m_vertexMotions;
}
