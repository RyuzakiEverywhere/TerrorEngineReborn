using System;
using Photon;
using UnityEngine;

// Token: 0x02000123 RID: 291
public class GetData : Photon.MonoBehaviour
{
	// Token: 0x06000686 RID: 1670 RVA: 0x00040B80 File Offset: 0x0003EF80
	private void Start()
	{
		if (base.photonView.isMine)
		{
			this.path = base.gameObject.name;
		}
		base.photonView.RPC("GetInfo", PhotonTargets.AllBuffered, new object[]
		{
			this.path
		});
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x00040BCE File Offset: 0x0003EFCE
	private void Update()
	{
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x00040BD0 File Offset: 0x0003EFD0
	private void AddInfo()
	{
		this.obj = (Resources.Load(base.gameObject.name.ToString()) as GameObject);
		base.transform.localScale = new Vector3(this.obj.transform.localScale.x, this.obj.transform.localScale.y, this.obj.transform.localScale.z);
		if (this.obj.gameObject.GetComponent<MeshRenderer>() != null)
		{
			base.gameObject.AddComponent<MeshRenderer>();
			base.gameObject.AddComponent<ModelMesh>();
			base.gameObject.GetComponent<ModelMesh>().hasmesh = this.obj.gameObject.GetComponent<ModelMesh>().hasmesh;
		}
		if (this.obj.gameObject.GetComponent<EditObjEnable>() != null)
		{
			base.gameObject.AddComponent<EditObjEnable>();
		}
		if (this.obj.gameObject.GetComponent<BoxCollider>() != null)
		{
			base.gameObject.AddComponent<BoxCollider>();
			base.gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 1f, 1f);
		}
		if (this.obj.gameObject.GetComponent<PositionAndScale>() != null)
		{
			base.gameObject.AddComponent<PositionAndScale>();
			base.gameObject.GetComponent<PositionAndScale>().flip = this.obj.gameObject.GetComponent<PositionAndScale>().flip;
			base.gameObject.GetComponent<PositionAndScale>().wall = this.obj.gameObject.GetComponent<PositionAndScale>().wall;
			base.gameObject.GetComponent<PositionAndScale>().model = this.obj.gameObject.GetComponent<PositionAndScale>().model;
			base.gameObject.GetComponent<PositionAndScale>().light = this.obj.gameObject.GetComponent<PositionAndScale>().light;
			base.gameObject.GetComponent<PositionAndScale>().npc = this.obj.gameObject.GetComponent<PositionAndScale>().npc;
		}
		if (this.obj.gameObject.GetComponent<GridCreateObject>() != null)
		{
			base.gameObject.AddComponent<GridCreateObject>();
		}
		if (this.obj.gameObject.GetComponent<ModelProperties>() != null)
		{
			base.gameObject.AddComponent<ModelProperties>();
		}
		if (this.obj.gameObject.GetComponent<LightProperties>() != null)
		{
			base.gameObject.AddComponent<LightProperties>();
		}
		if (this.obj.gameObject.GetComponent<WallProperties>() != null)
		{
			base.gameObject.AddComponent<WallProperties>();
		}
		if (this.obj.gameObject.GetComponent<moveup>() != null)
		{
			base.gameObject.AddComponent<moveup>();
			base.gameObject.GetComponent<moveup>().move = this.obj.gameObject.GetComponent<moveup>().move;
		}
		if (this.obj.gameObject.GetComponent<State>() != null)
		{
			base.gameObject.AddComponent<State>();
			base.gameObject.GetComponent<State>().IsSpawnedAtRuntime = this.obj.gameObject.GetComponent<State>().IsSpawnedAtRuntime;
		}
		if (this.obj.gameObject.GetComponent<Rigidbody>() != null)
		{
			base.gameObject.AddComponent<Rigidbody>();
			base.gameObject.GetComponent<Rigidbody>().useGravity = false;
			base.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		}
		if (this.obj.gameObject.GetComponent<Light>() != null)
		{
			base.gameObject.AddComponent<Light>();
			base.gameObject.GetComponent<Light>().type = this.obj.gameObject.GetComponent<Light>().type;
			base.gameObject.GetComponent<Light>().intensity = this.obj.gameObject.GetComponent<Light>().intensity;
		}
		if (!base.photonView.isMine)
		{
			base.GetComponent<Renderer>().material.color = Color.red;
		}
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x00041025 File Offset: 0x0003F425
	[RPC]
	private void GetInfo(string p)
	{
		if (base.photonView.isMine)
		{
			p = this.path;
		}
		base.gameObject.name = p;
		this.AddInfo();
	}

	// Token: 0x040008EF RID: 2287
	public string path;

	// Token: 0x040008F0 RID: 2288
	private GameObject obj;
}
