using System;
using Photon;
using UnityEngine;

// Token: 0x0200015F RID: 351
public class SyncedModel : Photon.MonoBehaviour
{
	// Token: 0x06000864 RID: 2148 RVA: 0x0004DDE4 File Offset: 0x0004C1E4
	private void Start()
	{
		if (base.photonView.isMine)
		{
			this.name = base.gameObject.name;
			base.gameObject.GetComponent<Rigidbody>().useGravity = true;
		}
		base.photonView.RPC("GetInfo2", PhotonTargets.AllBuffered, new object[]
		{
			this.name
		});
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x0004DE44 File Offset: 0x0004C244
	private void Update()
	{
		base.gameObject.GetComponent<MeshFilter>().mesh = this.original.GetComponent<MeshFilter>().mesh;
		if (base.gameObject.GetComponent<MeshFilter>().mesh != null)
		{
			if (base.gameObject.GetComponent<BoxCollider>() == null)
			{
				base.gameObject.AddComponent<BoxCollider>();
			}
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x0004DEB4 File Offset: 0x0004C2B4
	private void AddInfo2()
	{
		this.original = GameObject.Find(this.name);
		if ((this.original != null && this.original.GetComponent<Renderer>().material != null) || (this.original != null && this.original.GetComponent<Renderer>().sharedMaterial != null))
		{
			base.GetComponent<Renderer>().sharedMaterial = this.original.GetComponent<Renderer>().material;
			if (this.original.GetComponent<ModelProperties>().collect)
			{
				this.cancollect = true;
			}
			if (this.original.GetComponent<ModelProperties>().canpickup)
			{
				this.canpickup = true;
			}
			if (this.cancollect)
			{
				base.gameObject.name = "collect";
			}
			if (this.canpickup)
			{
				base.gameObject.tag = "CanPickup";
			}
			base.gameObject.transform.localScale = this.original.transform.localScale;
			return;
		}
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x0004DFD9 File Offset: 0x0004C3D9
	[RPC]
	private void GetInfo2(string p)
	{
		if (base.photonView.isMine)
		{
			p = this.name;
		}
		this.name = p;
		this.AddInfo2();
	}

	// Token: 0x04000A7A RID: 2682
	public new string name;

	// Token: 0x04000A7B RID: 2683
	public GameObject original;

	// Token: 0x04000A7C RID: 2684
	public bool cancollect;

	// Token: 0x04000A7D RID: 2685
	public bool canpickup;

	// Token: 0x04000A7E RID: 2686
	public bool getinfonow;

	// Token: 0x04000A7F RID: 2687
	public Mesh objmesh;
}
