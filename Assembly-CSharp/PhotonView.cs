using System;
using Photon;
using UnityEngine;

// Token: 0x02000148 RID: 328
[AddComponentMenu("Miscellaneous/Photon View &v")]
public class PhotonView : Photon.MonoBehaviour
{
	// Token: 0x17000068 RID: 104
	// (get) Token: 0x060007EB RID: 2027 RVA: 0x0004A5A1 File Offset: 0x000489A1
	// (set) Token: 0x060007EC RID: 2028 RVA: 0x0004A5CF File Offset: 0x000489CF
	public int prefix
	{
		get
		{
			if (this.prefixBackup == -1 && PhotonNetwork.networkingPeer != null)
			{
				this.prefixBackup = (int)PhotonNetwork.networkingPeer.currentLevelPrefix;
			}
			return this.prefixBackup;
		}
		set
		{
			this.prefixBackup = value;
		}
	}

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x060007ED RID: 2029 RVA: 0x0004A5D8 File Offset: 0x000489D8
	// (set) Token: 0x060007EE RID: 2030 RVA: 0x0004A601 File Offset: 0x00048A01
	public object[] instantiationData
	{
		get
		{
			if (!this.didAwake)
			{
				this.instantiationDataField = PhotonNetwork.networkingPeer.FetchInstantiationData(this.instantiationId);
			}
			return this.instantiationDataField;
		}
		set
		{
			this.instantiationDataField = value;
		}
	}

	// Token: 0x1700006A RID: 106
	// (get) Token: 0x060007EF RID: 2031 RVA: 0x0004A60A File Offset: 0x00048A0A
	// (set) Token: 0x060007F0 RID: 2032 RVA: 0x0004A620 File Offset: 0x00048A20
	public int viewID
	{
		get
		{
			return this.ownerId * PhotonNetwork.MAX_VIEW_IDS + this.subId;
		}
		set
		{
			bool flag = this.didAwake && this.subId == 0;
			this.ownerId = value / PhotonNetwork.MAX_VIEW_IDS;
			this.subId = value % PhotonNetwork.MAX_VIEW_IDS;
			if (flag)
			{
				PhotonNetwork.networkingPeer.RegisterPhotonView(this);
			}
		}
	}

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x060007F1 RID: 2033 RVA: 0x0004A670 File Offset: 0x00048A70
	public bool isSceneView
	{
		get
		{
			return this.ownerId == 0;
		}
	}

	// Token: 0x1700006C RID: 108
	// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0004A67B File Offset: 0x00048A7B
	public PhotonPlayer owner
	{
		get
		{
			return PhotonPlayer.Find(this.ownerId);
		}
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x060007F3 RID: 2035 RVA: 0x0004A688 File Offset: 0x00048A88
	public int OwnerActorNr
	{
		get
		{
			return this.ownerId;
		}
	}

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x060007F4 RID: 2036 RVA: 0x0004A690 File Offset: 0x00048A90
	public bool isMine
	{
		get
		{
			return this.ownerId == PhotonNetwork.player.ID || (this.isSceneView && PhotonNetwork.isMasterClient);
		}
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x0004A6BD File Offset: 0x00048ABD
	public void Awake()
	{
		PhotonNetwork.networkingPeer.RegisterPhotonView(this);
		this.instantiationDataField = PhotonNetwork.networkingPeer.FetchInstantiationData(this.instantiationId);
		this.didAwake = true;
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x0004A6E7 File Offset: 0x00048AE7
	public void OnApplicationQuit()
	{
		this.destroyedByPhotonNetworkOrQuit = true;
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x0004A6F0 File Offset: 0x00048AF0
	public void OnDestroy()
	{
		PhotonNetwork.networkingPeer.RemovePhotonView(this);
		if (!this.destroyedByPhotonNetworkOrQuit && !Application.isLoadingLevel)
		{
			if (this.instantiationId > 0)
			{
				Debug.LogError(string.Concat(new object[]
				{
					"OnDestroy() seems to be called without PhotonNetwork.Destroy()?! GameObject: ",
					base.gameObject,
					" Application.isLoadingLevel: ",
					Application.isLoadingLevel
				}));
			}
			else if (this.viewID <= 0)
			{
				Debug.LogWarning(string.Format("OnDestroy manually allocated PhotonView {0}. The viewID is 0. Was it ever (manually) set?", this));
			}
			else if (this.isMine && !PhotonNetwork.manuallyAllocatedViewIds.Contains(this.viewID))
			{
				Debug.LogWarning(string.Format("OnDestroy manually allocated PhotonView {0}. The viewID is local (isMine) but not in manuallyAllocatedViewIds list. Use UnAllocateViewID() after you destroyed the PV.", this));
			}
		}
		if (PhotonNetwork.networkingPeer.instantiatedObjects.ContainsKey(this.instantiationId))
		{
			Debug.LogWarning(string.Format("OnDestroy for PhotonView {0} but GO is still in instantiatedObjects. instantiationId: {1}. Use PhotonNetwork.Destroy(). {2}", this, this.instantiationId, (!Application.isLoadingLevel) ? string.Empty : "Loading new scene caused this."));
		}
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x0004A803 File Offset: 0x00048C03
	public void RPC(string methodName, PhotonTargets target, params object[] parameters)
	{
		PhotonNetwork.RPC(this, methodName, target, parameters);
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x0004A80E File Offset: 0x00048C0E
	public void RPC(string methodName, PhotonPlayer targetPlayer, params object[] parameters)
	{
		PhotonNetwork.RPC(this, methodName, targetPlayer, parameters);
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x0004A819 File Offset: 0x00048C19
	public static PhotonView Get(Component component)
	{
		return component.GetComponent<PhotonView>();
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x0004A821 File Offset: 0x00048C21
	public static PhotonView Get(GameObject gameObj)
	{
		return gameObj.GetComponent<PhotonView>();
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x0004A829 File Offset: 0x00048C29
	public static PhotonView Find(int viewID)
	{
		return PhotonNetwork.networkingPeer.GetPhotonView(viewID);
	}

	// Token: 0x060007FD RID: 2045 RVA: 0x0004A838 File Offset: 0x00048C38
	public override string ToString()
	{
		return string.Format("View ({3}){0} on {1} {2}", new object[]
		{
			this.viewID,
			base.gameObject.name,
			(!this.isSceneView) ? string.Empty : "(scene)",
			this.prefix
		});
	}

	// Token: 0x04000A1A RID: 2586
	public int subId;

	// Token: 0x04000A1B RID: 2587
	public int ownerId;

	// Token: 0x04000A1C RID: 2588
	public int group;

	// Token: 0x04000A1D RID: 2589
	public int prefixBackup = -1;

	// Token: 0x04000A1E RID: 2590
	private object[] instantiationDataField;

	// Token: 0x04000A1F RID: 2591
	protected internal object[] lastOnSerializeDataSent;

	// Token: 0x04000A20 RID: 2592
	protected internal object[] lastOnSerializeDataReceived;

	// Token: 0x04000A21 RID: 2593
	public Component observed;

	// Token: 0x04000A22 RID: 2594
	public ViewSynchronization synchronization;

	// Token: 0x04000A23 RID: 2595
	public OnSerializeTransform onSerializeTransformOption = OnSerializeTransform.PositionAndRotation;

	// Token: 0x04000A24 RID: 2596
	public OnSerializeRigidBody onSerializeRigidBodyOption = OnSerializeRigidBody.All;

	// Token: 0x04000A25 RID: 2597
	public int instantiationId;

	// Token: 0x04000A26 RID: 2598
	private bool didAwake;

	// Token: 0x04000A27 RID: 2599
	protected internal bool destroyedByPhotonNetworkOrQuit;
}
