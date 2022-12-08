using System;
using UnityEngine;

// Token: 0x02000151 RID: 337
[RequireComponent(typeof(PhotonView))]
public class ManualPhotonViewAllocator : MonoBehaviour
{
	// Token: 0x06000837 RID: 2103 RVA: 0x0004B230 File Offset: 0x00049630
	public void AllocateManualPhotonView()
	{
		PhotonView photonView = base.gameObject.GetPhotonView();
		if (photonView == null)
		{
			Debug.LogError("Can't do manual instantiation without PhotonView component.");
			return;
		}
		int num = PhotonNetwork.AllocateViewID();
		photonView.RPC("InstantiateRpc", PhotonTargets.AllBuffered, new object[]
		{
			num
		});
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x0004B284 File Offset: 0x00049684
	[RPC]
	public void InstantiateRpc(int viewID)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Prefab, InputToEvent.inputHitPos + new Vector3(0f, 5f, 0f), Quaternion.identity);
		gameObject.GetPhotonView().viewID = viewID;
		OnClickDestroy component = gameObject.GetComponent<OnClickDestroy>();
		component.DestroyByRpc = true;
	}

	// Token: 0x04000A4B RID: 2635
	public GameObject Prefab;
}
