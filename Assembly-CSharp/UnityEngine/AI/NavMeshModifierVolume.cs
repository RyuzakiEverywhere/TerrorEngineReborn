using System;
using System.Collections.Generic;

namespace UnityEngine.AI
{
	// Token: 0x020000F9 RID: 249
	[ExecuteInEditMode]
	[AddComponentMenu("Navigation/NavMeshModifierVolume", 31)]
	[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
	public class NavMeshModifierVolume : MonoBehaviour
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00039164 File Offset: 0x00037564
		// (set) Token: 0x060004CA RID: 1226 RVA: 0x0003916C File Offset: 0x0003756C
		public Vector3 size
		{
			get
			{
				return this.m_Size;
			}
			set
			{
				this.m_Size = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00039175 File Offset: 0x00037575
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x0003917D File Offset: 0x0003757D
		public Vector3 center
		{
			get
			{
				return this.m_Center;
			}
			set
			{
				this.m_Center = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00039186 File Offset: 0x00037586
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x0003918E File Offset: 0x0003758E
		public int area
		{
			get
			{
				return this.m_Area;
			}
			set
			{
				this.m_Area = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00039197 File Offset: 0x00037597
		public static List<NavMeshModifierVolume> activeModifiers
		{
			get
			{
				return NavMeshModifierVolume.s_NavMeshModifiers;
			}
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0003919E File Offset: 0x0003759E
		private void OnEnable()
		{
			if (!NavMeshModifierVolume.s_NavMeshModifiers.Contains(this))
			{
				NavMeshModifierVolume.s_NavMeshModifiers.Add(this);
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000391BB File Offset: 0x000375BB
		private void OnDisable()
		{
			NavMeshModifierVolume.s_NavMeshModifiers.Remove(this);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000391C9 File Offset: 0x000375C9
		public bool AffectsAgentType(int agentTypeID)
		{
			return this.m_AffectedAgents.Count != 0 && (this.m_AffectedAgents[0] == -1 || this.m_AffectedAgents.IndexOf(agentTypeID) != -1);
		}

		// Token: 0x040007B4 RID: 1972
		[SerializeField]
		private Vector3 m_Size = new Vector3(4f, 3f, 4f);

		// Token: 0x040007B5 RID: 1973
		[SerializeField]
		private Vector3 m_Center = new Vector3(0f, 1f, 0f);

		// Token: 0x040007B6 RID: 1974
		[SerializeField]
		private int m_Area;

		// Token: 0x040007B7 RID: 1975
		[SerializeField]
		private List<int> m_AffectedAgents = new List<int>(new int[]
		{
			-1
		});

		// Token: 0x040007B8 RID: 1976
		private static readonly List<NavMeshModifierVolume> s_NavMeshModifiers = new List<NavMeshModifierVolume>();
	}
}
