using System;
using System.Collections.Generic;
using Photon;
using UnityEngine;

// Token: 0x0200015C RID: 348
public class PlayerHandlerNPC : Photon.MonoBehaviour
{
	// Token: 0x0600085C RID: 2140 RVA: 0x0004BA94 File Offset: 0x00049E94
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

	// Token: 0x0600085D RID: 2141 RVA: 0x0004BBA8 File Offset: 0x00049FA8
	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(base.transform.position);
			stream.SendNext(base.transform.rotation);
			stream.SendNext(this.curanimation);
		}
		else
		{
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			this.correctAnimation = (int)stream.ReceiveNext();
		}
	}

	// Token: 0x0600085E RID: 2142 RVA: 0x0004BC38 File Offset: 0x0004A038
	private void Update()
	{
		if (!base.photonView.isMine)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, this.correctPlayerPos, Time.deltaTime * 8f);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.correctPlayerRot, Time.deltaTime * 8f);
			this.curanimation = this.correctAnimation;
		}
	}

	// Token: 0x04000A69 RID: 2665
	public List<GameObject> remoteObjectsToDeactivate;

	// Token: 0x04000A6A RID: 2666
	public List<UnityEngine.MonoBehaviour> remoteScriptsToDeactivate;

	// Token: 0x04000A6B RID: 2667
	public List<GameObject> localObjectsToDeactivate;

	// Token: 0x04000A6C RID: 2668
	public List<UnityEngine.MonoBehaviour> localScriptsToDeactivate;

	// Token: 0x04000A6D RID: 2669
	public int curanimation;

	// Token: 0x04000A6E RID: 2670
	private Vector3 correctPlayerPos = new Vector3(0f, -100f, 0f);

	// Token: 0x04000A6F RID: 2671
	private Quaternion correctPlayerRot = Quaternion.identity;

	// Token: 0x04000A70 RID: 2672
	public int correctAnimation;
}
