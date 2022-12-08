using System;
using System.Collections.Generic;
using Photon;
using UnityEngine;

// Token: 0x0200015B RID: 347
public class PlayerHandler : Photon.MonoBehaviour
{
	// Token: 0x06000858 RID: 2136 RVA: 0x0004B7E4 File Offset: 0x00049BE4
	private void Start()
	{
		if (!base.photonView.isMine)
		{
			for (int i = 0; i < this.remoteObjectsToDeactivate.Count; i++)
			{
				UnityEngine.Object.Destroy(this.remoteObjectsToDeactivate[i]);
			}
			for (int j = 0; j < this.remoteScriptsToDeactivate.Count; j++)
			{
				UnityEngine.Object.Destroy(this.remoteScriptsToDeactivate[j]);
			}
		}
		else
		{
			for (int k = 0; k < this.localObjectsToDeactivate.Count; k++)
			{
				UnityEngine.Object.Destroy(this.localObjectsToDeactivate[k]);
			}
			for (int l = 0; l < this.localScriptsToDeactivate.Count; l++)
			{
				UnityEngine.Object.Destroy(this.localScriptsToDeactivate[l]);
			}
		}
		CryptoPlayerPrefs.SetString("gameover", GameObject.Find("Settings").GetComponent<SettingsProperties>().gameovername);
		CryptoPlayerPrefs.SetString("win", GameObject.Find("Settings").GetComponent<SettingsProperties>().winname);
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x0004B8F8 File Offset: 0x00049CF8
	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(base.transform.position);
			stream.SendNext(base.transform.rotation);
			stream.SendNext(this.curanimation);
			stream.SendNext(this.curitem);
			stream.SendNext(this.fireormelee);
		}
		else
		{
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			this.correctAnimation = (int)stream.ReceiveNext();
			this.correctItem = (int)stream.ReceiveNext();
			this.correctAction = (int)stream.ReceiveNext();
		}
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x0004B9CC File Offset: 0x00049DCC
	private void Update()
	{
		if (!base.photonView.isMine)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, this.correctPlayerPos, Time.deltaTime * 8f);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.correctPlayerRot, Time.deltaTime * 8f);
			this.curanimation = this.correctAnimation;
			this.curitem = this.correctItem;
			this.fireormelee = this.correctAction;
		}
	}

	// Token: 0x04000A5D RID: 2653
	public List<GameObject> remoteObjectsToDeactivate;

	// Token: 0x04000A5E RID: 2654
	public List<UnityEngine.MonoBehaviour> remoteScriptsToDeactivate;

	// Token: 0x04000A5F RID: 2655
	public List<GameObject> localObjectsToDeactivate;

	// Token: 0x04000A60 RID: 2656
	public List<UnityEngine.MonoBehaviour> localScriptsToDeactivate;

	// Token: 0x04000A61 RID: 2657
	public int curanimation;

	// Token: 0x04000A62 RID: 2658
	public int curitem;

	// Token: 0x04000A63 RID: 2659
	public int fireormelee;

	// Token: 0x04000A64 RID: 2660
	private Vector3 correctPlayerPos = new Vector3(0f, -100f, 0f);

	// Token: 0x04000A65 RID: 2661
	private Quaternion correctPlayerRot = Quaternion.identity;

	// Token: 0x04000A66 RID: 2662
	public int correctAnimation;

	// Token: 0x04000A67 RID: 2663
	public int correctItem;

	// Token: 0x04000A68 RID: 2664
	public int correctAction;
}
