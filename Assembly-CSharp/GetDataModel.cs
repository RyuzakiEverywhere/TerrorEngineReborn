using System;
using Photon;
using UnityEngine;

// Token: 0x02000124 RID: 292
public class GetDataModel : Photon.MonoBehaviour
{
	// Token: 0x0600068B RID: 1675 RVA: 0x0004105C File Offset: 0x0003F45C
	private void Start()
	{
		if (base.photonView.isMine)
		{
			this.path = base.gameObject.name;
			base.photonView.RPC("GetInfo", PhotonTargets.AllBuffered, new object[]
			{
				this.path
			});
		}
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x000410AA File Offset: 0x0003F4AA
	private void Update()
	{
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x000410AC File Offset: 0x0003F4AC
	private void AddInfo()
	{
		base.gameObject.AddComponent<EditObjEnable>();
		base.gameObject.AddComponent<PositionAndScale>();
		base.gameObject.GetComponent<PositionAndScale>().model = true;
		base.gameObject.AddComponent<GridCreateObject>();
		base.gameObject.AddComponent<ModelProperties>();
		base.gameObject.AddComponent<State>();
		base.gameObject.GetComponent<State>().IsSpawnedAtRuntime = true;
		base.gameObject.GetComponent<LoadMeshFromWeb>().enabled = true;
		if (base.photonView.isMine)
		{
			base.gameObject.AddComponent<Rigidbody>();
			base.gameObject.GetComponent<Rigidbody>().useGravity = false;
			base.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		}
		if (!base.photonView.isMine)
		{
			base.GetComponent<Renderer>().material.color = Color.red;
		}
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x0004119E File Offset: 0x0003F59E
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

	// Token: 0x040008F1 RID: 2289
	public string path;
}
