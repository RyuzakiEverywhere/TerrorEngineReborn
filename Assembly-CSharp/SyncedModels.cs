using System;
using Photon;
using UnityEngine;

// Token: 0x020000EE RID: 238
public class SyncedModels : Photon.MonoBehaviour
{
	// Token: 0x0600047A RID: 1146 RVA: 0x000364D2 File Offset: 0x000348D2
	private void Awake()
	{
		base.gameObject.GetComponent<PhotonView>().observed = base.gameObject.transform;
		base.gameObject.GetComponent<PhotonView>().synchronization = ViewSynchronization.Unreliable;
	}

	// Token: 0x0600047B RID: 1147 RVA: 0x00036500 File Offset: 0x00034900
	private void Start()
	{
		base.photonView.RPC("Sendmodelinfo", PhotonTargets.All, new object[0]);
		if (base.gameObject.GetComponent<WallProperties>() != null)
		{
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<WallProperties>());
		}
		if (base.gameObject.GetComponent<LightProperties>() != null)
		{
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<LightProperties>());
		}
		if (base.gameObject.GetComponent<State>() != null)
		{
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<State>());
		}
		if (base.gameObject.GetComponent<GridCreateObject>() != null)
		{
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<GridCreateObject>());
		}
		if (base.gameObject.GetComponent<CreateSceneObj>() != null)
		{
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<CreateSceneObj>());
		}
		if (base.gameObject.GetComponent<ModelProperties>() != null)
		{
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<ModelProperties>());
		}
		if (base.gameObject.GetComponent<MeshCollider>() != null)
		{
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<MeshCollider>());
			base.gameObject.AddComponent<BoxCollider>();
		}
		if (this.canpickup)
		{
			base.gameObject.tag = "CanPickup";
		}
		if (this.collect)
		{
			base.gameObject.transform.tag = "collect";
		}
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x0003667C File Offset: 0x00034A7C
	[RPC]
	private void Sendmodelinfo()
	{
		this.collect = this.infoobj.GetComponent<ModelProperties>().collect;
		this.canpickup = this.infoobj.GetComponent<ModelProperties>().canpickup;
		this.triggerdeactivate = this.infoobj.GetComponent<ModelProperties>().triggerdeactivate;
		this.triggerid = this.infoobj.GetComponent<ModelProperties>().triggerid;
		base.transform.localScale = new Vector3(this.infoobj.transform.localScale.x, this.infoobj.transform.localScale.y, this.infoobj.transform.localScale.z);
		UnityEngine.Object.Destroy(this.infoobj);
	}

	// Token: 0x04000729 RID: 1833
	public GameObject infoobj;

	// Token: 0x0400072A RID: 1834
	public bool collect;

	// Token: 0x0400072B RID: 1835
	public bool canpickup;

	// Token: 0x0400072C RID: 1836
	public bool triggerdeactivate;

	// Token: 0x0400072D RID: 1837
	public string triggerid;
}
