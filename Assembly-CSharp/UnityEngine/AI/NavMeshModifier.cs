using System;
using System.Collections.Generic;

namespace UnityEngine.AI
{
	// Token: 0x020000F8 RID: 248
	[ExecuteInEditMode]
	[AddComponentMenu("Navigation/NavMeshModifier", 32)]
	[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
	public class NavMeshModifier : MonoBehaviour
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0003905D File Offset: 0x0003745D
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x00039065 File Offset: 0x00037465
		public bool overrideArea
		{
			get
			{
				return this.m_OverrideArea;
			}
			set
			{
				this.m_OverrideArea = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x0003906E File Offset: 0x0003746E
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x00039076 File Offset: 0x00037476
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

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0003907F File Offset: 0x0003747F
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x00039087 File Offset: 0x00037487
		public bool ignoreFromBuild
		{
			get
			{
				return this.m_IgnoreFromBuild;
			}
			set
			{
				this.m_IgnoreFromBuild = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x00039090 File Offset: 0x00037490
		public static List<NavMeshModifier> activeModifiers
		{
			get
			{
				return NavMeshModifier.s_NavMeshModifiers;
			}
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00039097 File Offset: 0x00037497
		private void OnEnable()
		{
			if (!NavMeshModifier.s_NavMeshModifiers.Contains(this))
			{
				NavMeshModifier.s_NavMeshModifiers.Add(this);
			}
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x000390B4 File Offset: 0x000374B4
		private void OnDisable()
		{
			NavMeshModifier.s_NavMeshModifiers.Remove(this);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000390C2 File Offset: 0x000374C2
		public bool AffectsAgentType(int agentTypeID)
		{
			return this.m_AffectedAgents.Count != 0 && (this.m_AffectedAgents[0] == -1 || this.m_AffectedAgents.IndexOf(agentTypeID) != -1);
		}

		// Token: 0x040007AF RID: 1967
		[SerializeField]
		private bool m_OverrideArea;

		// Token: 0x040007B0 RID: 1968
		[SerializeField]
		private int m_Area;

		// Token: 0x040007B1 RID: 1969
		[SerializeField]
		private bool m_IgnoreFromBuild;

		// Token: 0x040007B2 RID: 1970
		[SerializeField]
		private List<int> m_AffectedAgents = new List<int>(new int[]
		{
			-1
		});

		// Token: 0x040007B3 RID: 1971
		private static readonly List<NavMeshModifier> s_NavMeshModifiers = new List<NavMeshModifier>();
	}
}
