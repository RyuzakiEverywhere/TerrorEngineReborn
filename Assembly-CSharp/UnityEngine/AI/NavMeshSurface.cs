using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.AI
{
	// Token: 0x020000FB RID: 251
	[ExecuteInEditMode]
	[DefaultExecutionOrder(-102)]
	[AddComponentMenu("Navigation/NavMeshSurface", 30)]
	[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
	public class NavMeshSurface : MonoBehaviour
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00039292 File Offset: 0x00037692
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x0003929A File Offset: 0x0003769A
		public int agentTypeID
		{
			get
			{
				return this.m_AgentTypeID;
			}
			set
			{
				this.m_AgentTypeID = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x000392A3 File Offset: 0x000376A3
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x000392AB File Offset: 0x000376AB
		public CollectObjects collectObjects
		{
			get
			{
				return this.m_CollectObjects;
			}
			set
			{
				this.m_CollectObjects = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x000392B4 File Offset: 0x000376B4
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x000392BC File Offset: 0x000376BC
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

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x000392C5 File Offset: 0x000376C5
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x000392CD File Offset: 0x000376CD
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

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x000392D6 File Offset: 0x000376D6
		// (set) Token: 0x060004DE RID: 1246 RVA: 0x000392DE File Offset: 0x000376DE
		public LayerMask layerMask
		{
			get
			{
				return this.m_LayerMask;
			}
			set
			{
				this.m_LayerMask = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060004DF RID: 1247 RVA: 0x000392E7 File Offset: 0x000376E7
		// (set) Token: 0x060004E0 RID: 1248 RVA: 0x000392EF File Offset: 0x000376EF
		public NavMeshCollectGeometry useGeometry
		{
			get
			{
				return this.m_UseGeometry;
			}
			set
			{
				this.m_UseGeometry = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x000392F8 File Offset: 0x000376F8
		// (set) Token: 0x060004E2 RID: 1250 RVA: 0x00039300 File Offset: 0x00037700
		public int defaultArea
		{
			get
			{
				return this.m_DefaultArea;
			}
			set
			{
				this.m_DefaultArea = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060004E3 RID: 1251 RVA: 0x00039309 File Offset: 0x00037709
		// (set) Token: 0x060004E4 RID: 1252 RVA: 0x00039311 File Offset: 0x00037711
		public bool ignoreNavMeshAgent
		{
			get
			{
				return this.m_IgnoreNavMeshAgent;
			}
			set
			{
				this.m_IgnoreNavMeshAgent = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x0003931A File Offset: 0x0003771A
		// (set) Token: 0x060004E6 RID: 1254 RVA: 0x00039322 File Offset: 0x00037722
		public bool ignoreNavMeshObstacle
		{
			get
			{
				return this.m_IgnoreNavMeshObstacle;
			}
			set
			{
				this.m_IgnoreNavMeshObstacle = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0003932B File Offset: 0x0003772B
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x00039333 File Offset: 0x00037733
		public bool overrideTileSize
		{
			get
			{
				return this.m_OverrideTileSize;
			}
			set
			{
				this.m_OverrideTileSize = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x0003933C File Offset: 0x0003773C
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x00039344 File Offset: 0x00037744
		public int tileSize
		{
			get
			{
				return this.m_TileSize;
			}
			set
			{
				this.m_TileSize = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0003934D File Offset: 0x0003774D
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x00039355 File Offset: 0x00037755
		public bool overrideVoxelSize
		{
			get
			{
				return this.m_OverrideVoxelSize;
			}
			set
			{
				this.m_OverrideVoxelSize = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0003935E File Offset: 0x0003775E
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x00039366 File Offset: 0x00037766
		public float voxelSize
		{
			get
			{
				return this.m_VoxelSize;
			}
			set
			{
				this.m_VoxelSize = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0003936F File Offset: 0x0003776F
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x00039377 File Offset: 0x00037777
		public bool buildHeightMesh
		{
			get
			{
				return this.m_BuildHeightMesh;
			}
			set
			{
				this.m_OverrideTileSize = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x00039380 File Offset: 0x00037780
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x00039388 File Offset: 0x00037788
		public NavMeshData bakedNavMeshData
		{
			get
			{
				return this.m_BakedNavMeshData;
			}
			set
			{
				this.m_BakedNavMeshData = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x00039391 File Offset: 0x00037791
		public static List<NavMeshSurface> activeSurfaces
		{
			get
			{
				return NavMeshSurface.s_NavMeshSurfaces;
			}
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00039398 File Offset: 0x00037798
		private void OnEnable()
		{
			NavMeshSurface.Register(this);
			this.AddData();
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000393A6 File Offset: 0x000377A6
		private void OnDisable()
		{
			this.RemoveData();
			NavMeshSurface.Unregister(this);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x000393B4 File Offset: 0x000377B4
		public void AddData()
		{
			if (this.m_NavMeshDataInstance.valid)
			{
				return;
			}
			if (this.m_BakedNavMeshData != null)
			{
				this.m_NavMeshDataInstance = NavMesh.AddNavMeshData(this.m_BakedNavMeshData, base.transform.position, base.transform.rotation);
				this.m_NavMeshDataInstance.owner = this;
			}
			this.m_LastPosition = base.transform.position;
			this.m_LastRotation = base.transform.rotation;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00039438 File Offset: 0x00037838
		public void AddNewData(NavMeshData nmd)
		{
			this.m_NavMeshDataInstance = NavMesh.AddNavMeshData(nmd, base.transform.position, base.transform.rotation);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0003945C File Offset: 0x0003785C
		public void RemoveData()
		{
			this.m_NavMeshDataInstance.Remove();
			this.m_NavMeshDataInstance = default(NavMeshDataInstance);
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00039484 File Offset: 0x00037884
		public NavMeshBuildSettings GetBuildSettings()
		{
			NavMeshBuildSettings settingsByID = NavMesh.GetSettingsByID(this.m_AgentTypeID);
			if (this.overrideTileSize)
			{
				settingsByID.overrideTileSize = true;
				settingsByID.tileSize = this.tileSize;
			}
			if (this.overrideVoxelSize)
			{
				settingsByID.overrideVoxelSize = true;
				settingsByID.voxelSize = this.voxelSize;
			}
			return settingsByID;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x000394E0 File Offset: 0x000378E0
		public void Bake()
		{
			List<NavMeshBuildSource> sources = this.CollectSources();
			Bounds localBounds = new Bounds(this.m_Center, NavMeshSurface.Abs(this.m_Size));
			if (this.m_CollectObjects == CollectObjects.All || this.m_CollectObjects == CollectObjects.Children)
			{
				localBounds = this.CalculateWorldBounds(sources);
			}
			NavMeshData navMeshData = NavMeshBuilder.BuildNavMeshData(this.GetBuildSettings(), sources, localBounds, base.transform.position, base.transform.rotation);
			if (navMeshData != null)
			{
				navMeshData.name = base.gameObject.name;
				this.RemoveData();
				this.m_BakedNavMeshData = navMeshData;
				if (base.isActiveAndEnabled)
				{
					this.AddData();
				}
			}
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0003958C File Offset: 0x0003798C
		private static void Register(NavMeshSurface surface)
		{
			if (NavMeshSurface.s_NavMeshSurfaces.Count == 0)
			{
				Delegate onPreUpdate = NavMesh.onPreUpdate;
				if (NavMeshSurface.<>f__mg$cache0 == null)
				{
					NavMeshSurface.<>f__mg$cache0 = new NavMesh.OnNavMeshPreUpdate(NavMeshSurface.UpdateActive);
				}
				NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Combine(onPreUpdate, NavMeshSurface.<>f__mg$cache0);
			}
			if (!NavMeshSurface.s_NavMeshSurfaces.Contains(surface))
			{
				NavMeshSurface.s_NavMeshSurfaces.Add(surface);
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x000395F4 File Offset: 0x000379F4
		private static void Unregister(NavMeshSurface surface)
		{
			NavMeshSurface.s_NavMeshSurfaces.Remove(surface);
			if (NavMeshSurface.s_NavMeshSurfaces.Count == 0)
			{
				Delegate onPreUpdate = NavMesh.onPreUpdate;
				if (NavMeshSurface.<>f__mg$cache1 == null)
				{
					NavMeshSurface.<>f__mg$cache1 = new NavMesh.OnNavMeshPreUpdate(NavMeshSurface.UpdateActive);
				}
				NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Remove(onPreUpdate, NavMeshSurface.<>f__mg$cache1);
			}
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00039650 File Offset: 0x00037A50
		private static void UpdateActive()
		{
			for (int i = 0; i < NavMeshSurface.s_NavMeshSurfaces.Count; i++)
			{
				NavMeshSurface.s_NavMeshSurfaces[i].UpdateDataIfTransformChanged();
			}
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00039688 File Offset: 0x00037A88
		private void AppendModifierVolumes(ref List<NavMeshBuildSource> sources)
		{
			List<NavMeshModifierVolume> list;
			if (this.m_CollectObjects == CollectObjects.Children)
			{
				list = new List<NavMeshModifierVolume>(base.GetComponentsInChildren<NavMeshModifierVolume>());
				list.RemoveAll((NavMeshModifierVolume x) => !x.isActiveAndEnabled);
			}
			else
			{
				list = NavMeshModifierVolume.activeModifiers;
			}
			foreach (NavMeshModifierVolume navMeshModifierVolume in list)
			{
				if ((this.m_LayerMask & 1 << navMeshModifierVolume.gameObject.layer) != 0)
				{
					if (navMeshModifierVolume.AffectsAgentType(this.m_AgentTypeID))
					{
						Vector3 pos = navMeshModifierVolume.transform.TransformPoint(navMeshModifierVolume.center);
						Vector3 lossyScale = navMeshModifierVolume.transform.lossyScale;
						Vector3 size = new Vector3(navMeshModifierVolume.size.x * Mathf.Abs(lossyScale.x), navMeshModifierVolume.size.y * Mathf.Abs(lossyScale.y), navMeshModifierVolume.size.z * Mathf.Abs(lossyScale.z));
						NavMeshBuildSource item = default(NavMeshBuildSource);
						item.shape = NavMeshBuildSourceShape.ModifierBox;
						item.transform = Matrix4x4.TRS(pos, navMeshModifierVolume.transform.rotation, Vector3.one);
						item.size = size;
						item.area = navMeshModifierVolume.area;
						sources.Add(item);
					}
				}
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00039830 File Offset: 0x00037C30
		private List<NavMeshBuildSource> CollectSources()
		{
			List<NavMeshBuildSource> list = new List<NavMeshBuildSource>();
			List<NavMeshBuildMarkup> list2 = new List<NavMeshBuildMarkup>();
			List<NavMeshModifier> list3;
			if (this.m_CollectObjects == CollectObjects.Children)
			{
				list3 = new List<NavMeshModifier>(base.GetComponentsInChildren<NavMeshModifier>());
				list3.RemoveAll((NavMeshModifier x) => !x.isActiveAndEnabled);
			}
			else
			{
				list3 = NavMeshModifier.activeModifiers;
			}
			foreach (NavMeshModifier navMeshModifier in list3)
			{
				if ((this.m_LayerMask & 1 << navMeshModifier.gameObject.layer) != 0)
				{
					if (navMeshModifier.AffectsAgentType(this.m_AgentTypeID))
					{
						list2.Add(new NavMeshBuildMarkup
						{
							root = navMeshModifier.transform,
							overrideArea = navMeshModifier.overrideArea,
							area = navMeshModifier.area,
							ignoreFromBuild = navMeshModifier.ignoreFromBuild
						});
					}
				}
			}
			if (this.m_CollectObjects == CollectObjects.All)
			{
				NavMeshBuilder.CollectSources(null, this.m_LayerMask, this.m_UseGeometry, this.m_DefaultArea, list2, list);
			}
			else if (this.m_CollectObjects == CollectObjects.Children)
			{
				NavMeshBuilder.CollectSources(base.transform, this.m_LayerMask, this.m_UseGeometry, this.m_DefaultArea, list2, list);
			}
			else if (this.m_CollectObjects == CollectObjects.Volume)
			{
				Matrix4x4 mat = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one);
				Bounds worldBounds = NavMeshSurface.GetWorldBounds(mat, new Bounds(this.m_Center, this.m_Size));
				NavMeshBuilder.CollectSources(worldBounds, this.m_LayerMask, this.m_UseGeometry, this.m_DefaultArea, list2, list);
			}
			if (this.m_IgnoreNavMeshAgent)
			{
				list.RemoveAll((NavMeshBuildSource x) => x.component != null && x.component.gameObject.GetComponent<NavMeshAgent>() != null);
			}
			if (this.m_IgnoreNavMeshObstacle)
			{
				list.RemoveAll((NavMeshBuildSource x) => x.component != null && x.component.gameObject.GetComponent<NavMeshObstacle>() != null);
			}
			this.AppendModifierVolumes(ref list);
			return list;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00039A88 File Offset: 0x00037E88
		private static Vector3 Abs(Vector3 v)
		{
			return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00039AB4 File Offset: 0x00037EB4
		private static Bounds GetWorldBounds(Matrix4x4 mat, Bounds bounds)
		{
			Vector3 a = NavMeshSurface.Abs(mat.MultiplyVector(Vector3.right));
			Vector3 a2 = NavMeshSurface.Abs(mat.MultiplyVector(Vector3.up));
			Vector3 a3 = NavMeshSurface.Abs(mat.MultiplyVector(Vector3.forward));
			Vector3 center = mat.MultiplyPoint(bounds.center);
			Vector3 size = a * bounds.size.x + a2 * bounds.size.y + a3 * bounds.size.z;
			return new Bounds(center, size);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00039B5C File Offset: 0x00037F5C
		private Bounds CalculateWorldBounds(List<NavMeshBuildSource> sources)
		{
			Matrix4x4 lhs = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one);
			lhs = lhs.inverse;
			Bounds result = default(Bounds);
			foreach (NavMeshBuildSource navMeshBuildSource in sources)
			{
				switch (navMeshBuildSource.shape)
				{
				case NavMeshBuildSourceShape.Mesh:
				{
					Mesh mesh = navMeshBuildSource.sourceObject as Mesh;
					result.Encapsulate(NavMeshSurface.GetWorldBounds(lhs * navMeshBuildSource.transform, mesh.bounds));
					break;
				}
				case NavMeshBuildSourceShape.Terrain:
				{
					TerrainData terrainData = navMeshBuildSource.sourceObject as TerrainData;
					result.Encapsulate(NavMeshSurface.GetWorldBounds(lhs * navMeshBuildSource.transform, new Bounds(0.5f * terrainData.size, terrainData.size)));
					break;
				}
				case NavMeshBuildSourceShape.Box:
				case NavMeshBuildSourceShape.Sphere:
				case NavMeshBuildSourceShape.Capsule:
				case NavMeshBuildSourceShape.ModifierBox:
					result.Encapsulate(NavMeshSurface.GetWorldBounds(lhs * navMeshBuildSource.transform, new Bounds(Vector3.zero, navMeshBuildSource.size)));
					break;
				}
			}
			result.Expand(0.1f);
			return result;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00039CC4 File Offset: 0x000380C4
		private bool HasTransformChanged()
		{
			return this.m_LastPosition != base.transform.position || this.m_LastRotation != base.transform.rotation;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00039D01 File Offset: 0x00038101
		private void UpdateDataIfTransformChanged()
		{
			if (this.HasTransformChanged())
			{
				this.RemoveData();
				this.AddData();
			}
		}

		// Token: 0x040007BD RID: 1981
		[SerializeField]
		private int m_AgentTypeID;

		// Token: 0x040007BE RID: 1982
		[SerializeField]
		private CollectObjects m_CollectObjects;

		// Token: 0x040007BF RID: 1983
		[SerializeField]
		private Vector3 m_Size = new Vector3(10f, 10f, 10f);

		// Token: 0x040007C0 RID: 1984
		[SerializeField]
		private Vector3 m_Center = new Vector3(0f, 2f, 0f);

		// Token: 0x040007C1 RID: 1985
		[SerializeField]
		private LayerMask m_LayerMask = -1;

		// Token: 0x040007C2 RID: 1986
		[SerializeField]
		private NavMeshCollectGeometry m_UseGeometry;

		// Token: 0x040007C3 RID: 1987
		[SerializeField]
		private int m_DefaultArea;

		// Token: 0x040007C4 RID: 1988
		[SerializeField]
		private bool m_IgnoreNavMeshAgent = true;

		// Token: 0x040007C5 RID: 1989
		[SerializeField]
		private bool m_IgnoreNavMeshObstacle = true;

		// Token: 0x040007C6 RID: 1990
		[SerializeField]
		private bool m_OverrideTileSize;

		// Token: 0x040007C7 RID: 1991
		[SerializeField]
		private int m_TileSize = 256;

		// Token: 0x040007C8 RID: 1992
		[SerializeField]
		private bool m_OverrideVoxelSize;

		// Token: 0x040007C9 RID: 1993
		[SerializeField]
		private float m_VoxelSize;

		// Token: 0x040007CA RID: 1994
		[SerializeField]
		private bool m_BuildHeightMesh;

		// Token: 0x040007CB RID: 1995
		[SerializeField]
		private NavMeshData m_BakedNavMeshData;

		// Token: 0x040007CC RID: 1996
		private NavMeshDataInstance m_NavMeshDataInstance;

		// Token: 0x040007CD RID: 1997
		private Vector3 m_LastPosition = Vector3.zero;

		// Token: 0x040007CE RID: 1998
		private Quaternion m_LastRotation = Quaternion.identity;

		// Token: 0x040007CF RID: 1999
		private static readonly List<NavMeshSurface> s_NavMeshSurfaces = new List<NavMeshSurface>();

		// Token: 0x040007D0 RID: 2000
		[CompilerGenerated]
		private static NavMesh.OnNavMeshPreUpdate <>f__mg$cache0;

		// Token: 0x040007D1 RID: 2001
		[CompilerGenerated]
		private static NavMesh.OnNavMeshPreUpdate <>f__mg$cache1;
	}
}
