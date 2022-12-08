using System;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class MapCreatorDecentralized : MonoBehaviour
{
	// Token: 0x06000357 RID: 855 RVA: 0x0001F9CC File Offset: 0x0001DDCC
	private void Awake()
	{
		this.mat = (Resources.Load("GridMat") as Material);
	}

	// Token: 0x06000358 RID: 856 RVA: 0x0001F9E4 File Offset: 0x0001DDE4
	private void Start()
	{
		this.Detector = GameObject.CreatePrimitive(PrimitiveType.Cube);
		this.Detector.name = "Detector";
		this.Detector.transform.localScale = new Vector3(InfiniteMapBuilderSpawn._SizeOfMap, 0.001f, InfiniteMapBuilderSpawn._SizeOfMap);
		this.Detector.transform.parent = base.transform;
		this.Detector.transform.position = base.transform.position;
		this.Detector.GetComponent<Renderer>().material = this.mat;
		this.Detector.GetComponent<Collider>().isTrigger = false;
		this.Detector.gameObject.AddComponent<GridCreateObject>();
		this.Detector.GetComponent<Renderer>().castShadows = false;
		this.Detector.GetComponent<Renderer>().receiveShadows = false;
		this.Detector.transform.Translate(0f, 0f, 0f);
		this.DetectorRay = new Ray(this.Detector.transform.position, this.Detector.transform.forward);
		this.MinRange = 0;
		this.MaxRange = 4;
		if (!InfiniteMapBuilderSpawn._TileX)
		{
			this.MinRange = 2;
		}
		if (!InfiniteMapBuilderSpawn._TileZ)
		{
			this.MaxRange = 2;
		}
	}

	// Token: 0x06000359 RID: 857 RVA: 0x0001FB38 File Offset: 0x0001DF38
	private void Update()
	{
		if (Time.time - this.TimeSinceLastCreation < 0.2f)
		{
			return;
		}
		this.TimeSinceLastCreation = Time.time;
		int num = UnityEngine.Random.Range(this.MinRange, this.MaxRange);
		Vector3 position = base.transform.position;
		this.DetectorRay.origin = this.Detector.transform.position;
		if (num == 0)
		{
			this.NewMapPos = new Vector3(position.x - InfiniteMapBuilderSpawn._SizeOfMap, position.y, position.z);
			this.DetectorRay.direction = -this.Detector.transform.right;
		}
		else if (num == 1)
		{
			this.NewMapPos = new Vector3(position.x + InfiniteMapBuilderSpawn._SizeOfMap, position.y, position.z);
			this.DetectorRay.direction = this.Detector.transform.right;
		}
		else if (num == 2)
		{
			this.NewMapPos = new Vector3(position.x, position.y, position.z + InfiniteMapBuilderSpawn._SizeOfMap);
			this.DetectorRay.direction = this.Detector.transform.forward;
		}
		else if (num == 3)
		{
			this.NewMapPos = new Vector3(position.x, position.y, position.z - InfiniteMapBuilderSpawn._SizeOfMap);
			this.DetectorRay.direction = -this.Detector.transform.forward;
		}
		if (Vector3.Distance(this.NewMapPos, InfiniteMapBuilderSpawn._PlayerCamera.transform.position) < 2f * InfiniteMapBuilderSpawn.FarDistance && !Physics.Raycast(this.DetectorRay, InfiniteMapBuilderSpawn._SizeOfMap))
		{
			GameObject objectFromPool = InfiniteMapBuilderSpawn.MapPool.GetObjectFromPool();
			objectFromPool.transform.position = this.NewMapPos;
		}
		if (Vector3.Distance(base.transform.position, InfiniteMapBuilderSpawn._PlayerCamera.transform.position) > 3f * InfiniteMapBuilderSpawn.FarDistance)
		{
			InfiniteMapBuilderSpawn.MapPool.PutObjectInPool(base.gameObject);
		}
	}

	// Token: 0x040003BA RID: 954
	public GameObject Detector;

	// Token: 0x040003BB RID: 955
	private Ray DetectorRay;

	// Token: 0x040003BC RID: 956
	public Material mat;

	// Token: 0x040003BD RID: 957
	private int MinRange;

	// Token: 0x040003BE RID: 958
	private int MaxRange = 4;

	// Token: 0x040003BF RID: 959
	private float TimeSinceLastCreation;

	// Token: 0x040003C0 RID: 960
	private Vector3 NewMapPos;
}
