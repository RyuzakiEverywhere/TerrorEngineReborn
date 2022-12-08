using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.AI
{
	// Token: 0x020000F7 RID: 247
	[ExecuteInEditMode]
	[DefaultExecutionOrder(-101)]
	[AddComponentMenu("Navigation/NavMeshLink", 33)]
	[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
	public class NavMeshLink : MonoBehaviour
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00038CEB File Offset: 0x000370EB
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x00038CF3 File Offset: 0x000370F3
		public int agentTypeID
		{
			get
			{
				return this.m_AgentTypeID;
			}
			set
			{
				this.m_AgentTypeID = value;
				this.UpdateLink();
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00038D02 File Offset: 0x00037102
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x00038D0A File Offset: 0x0003710A
		public Vector3 startPoint
		{
			get
			{
				return this.m_StartPoint;
			}
			set
			{
				this.m_StartPoint = value;
				this.UpdateLink();
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x00038D19 File Offset: 0x00037119
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x00038D21 File Offset: 0x00037121
		public Vector3 endPoint
		{
			get
			{
				return this.m_EndPoint;
			}
			set
			{
				this.m_EndPoint = value;
				this.UpdateLink();
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x00038D30 File Offset: 0x00037130
		// (set) Token: 0x060004AA RID: 1194 RVA: 0x00038D38 File Offset: 0x00037138
		public float width
		{
			get
			{
				return this.m_Width;
			}
			set
			{
				this.m_Width = value;
				this.UpdateLink();
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x00038D47 File Offset: 0x00037147
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x00038D4F File Offset: 0x0003714F
		public bool bidirectional
		{
			get
			{
				return this.m_Bidirectional;
			}
			set
			{
				this.m_Bidirectional = value;
				this.UpdateLink();
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00038D5E File Offset: 0x0003715E
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x00038D66 File Offset: 0x00037166
		public bool autoUpdate
		{
			get
			{
				return this.m_AutoUpdatePosition;
			}
			set
			{
				this.SetAutoUpdate(value);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x00038D6F File Offset: 0x0003716F
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x00038D77 File Offset: 0x00037177
		public int area
		{
			get
			{
				return this.m_Area;
			}
			set
			{
				this.m_Area = value;
				this.UpdateLink();
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00038D86 File Offset: 0x00037186
		private void OnEnable()
		{
			this.AddLink();
			if (this.m_AutoUpdatePosition && this.m_LinkInstance.valid)
			{
				NavMeshLink.AddTracking(this);
			}
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00038DAF File Offset: 0x000371AF
		private void OnDisable()
		{
			NavMeshLink.RemoveTracking(this);
			this.m_LinkInstance.Remove();
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00038DC2 File Offset: 0x000371C2
		public void UpdateLink()
		{
			this.m_LinkInstance.Remove();
			this.AddLink();
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00038DD8 File Offset: 0x000371D8
		private static void AddTracking(NavMeshLink link)
		{
			if (NavMeshLink.s_Tracked.Count == 0)
			{
				Delegate onPreUpdate = NavMesh.onPreUpdate;
				if (NavMeshLink.<>f__mg$cache0 == null)
				{
					NavMeshLink.<>f__mg$cache0 = new NavMesh.OnNavMeshPreUpdate(NavMeshLink.UpdateTrackedInstances);
				}
				NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Combine(onPreUpdate, NavMeshLink.<>f__mg$cache0);
			}
			NavMeshLink.s_Tracked.Add(link);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00038E30 File Offset: 0x00037230
		private static void RemoveTracking(NavMeshLink link)
		{
			NavMeshLink.s_Tracked.Remove(link);
			if (NavMeshLink.s_Tracked.Count == 0)
			{
				Delegate onPreUpdate = NavMesh.onPreUpdate;
				if (NavMeshLink.<>f__mg$cache1 == null)
				{
					NavMeshLink.<>f__mg$cache1 = new NavMesh.OnNavMeshPreUpdate(NavMeshLink.UpdateTrackedInstances);
				}
				NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Remove(onPreUpdate, NavMeshLink.<>f__mg$cache1);
			}
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00038E89 File Offset: 0x00037289
		private void SetAutoUpdate(bool value)
		{
			if (this.m_AutoUpdatePosition == value)
			{
				return;
			}
			this.m_AutoUpdatePosition = value;
			if (value)
			{
				NavMeshLink.AddTracking(this);
			}
			else
			{
				NavMeshLink.RemoveTracking(this);
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00038EB8 File Offset: 0x000372B8
		private void AddLink()
		{
			this.m_LinkInstance = NavMesh.AddLink(new NavMeshLinkData
			{
				startPosition = this.m_StartPoint,
				endPosition = this.m_EndPoint,
				width = this.m_Width,
				costModifier = -1f,
				bidirectional = this.m_Bidirectional,
				area = this.m_Area,
				agentTypeID = this.m_AgentTypeID
			}, base.transform.position, base.transform.rotation);
			if (this.m_LinkInstance.valid)
			{
				this.m_LinkInstance.owner = this;
			}
			this.m_LastPosition = base.transform.position;
			this.m_LastRotation = base.transform.rotation;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00038F87 File Offset: 0x00037387
		private bool HasTransformChanged()
		{
			return this.m_LastPosition != base.transform.position || this.m_LastRotation != base.transform.rotation;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00038FC4 File Offset: 0x000373C4
		private void OnDidApplyAnimationProperties()
		{
			this.UpdateLink();
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00038FCC File Offset: 0x000373CC
		private static void UpdateTrackedInstances()
		{
			foreach (NavMeshLink navMeshLink in NavMeshLink.s_Tracked)
			{
				if (navMeshLink.HasTransformChanged())
				{
					navMeshLink.UpdateLink();
				}
			}
		}

		// Token: 0x040007A2 RID: 1954
		[SerializeField]
		private int m_AgentTypeID;

		// Token: 0x040007A3 RID: 1955
		[SerializeField]
		private Vector3 m_StartPoint = new Vector3(0f, 0f, -2.5f);

		// Token: 0x040007A4 RID: 1956
		[SerializeField]
		private Vector3 m_EndPoint = new Vector3(0f, 0f, 2.5f);

		// Token: 0x040007A5 RID: 1957
		[SerializeField]
		private float m_Width;

		// Token: 0x040007A6 RID: 1958
		[SerializeField]
		private bool m_Bidirectional = true;

		// Token: 0x040007A7 RID: 1959
		[SerializeField]
		private bool m_AutoUpdatePosition;

		// Token: 0x040007A8 RID: 1960
		[SerializeField]
		private int m_Area;

		// Token: 0x040007A9 RID: 1961
		private NavMeshLinkInstance m_LinkInstance = default(NavMeshLinkInstance);

		// Token: 0x040007AA RID: 1962
		private Vector3 m_LastPosition = Vector3.zero;

		// Token: 0x040007AB RID: 1963
		private Quaternion m_LastRotation = Quaternion.identity;

		// Token: 0x040007AC RID: 1964
		private static readonly List<NavMeshLink> s_Tracked = new List<NavMeshLink>();

		// Token: 0x040007AD RID: 1965
		[CompilerGenerated]
		private static NavMesh.OnNavMeshPreUpdate <>f__mg$cache0;

		// Token: 0x040007AE RID: 1966
		[CompilerGenerated]
		private static NavMesh.OnNavMeshPreUpdate <>f__mg$cache1;
	}
}
