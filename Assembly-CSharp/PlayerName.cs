using System;
using Photon;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class PlayerName : Photon.MonoBehaviour
{
	// Token: 0x06000108 RID: 264 RVA: 0x0000F53C File Offset: 0x0000D93C
	private void Awake()
	{
		if (!this.positionDisplay)
		{
			if (!base.photonView.isMine)
			{
				this.positionDisplay = base.transform.Find("namepos");
			}
			else
			{
				this.positionDisplay = base.transform;
			}
		}
		if (base.photonView.isMine)
		{
			this.tempname = PhotonNetwork.playerName;
			base.photonView.RPC("SetName", PhotonTargets.AllBuffered, new object[]
			{
				this.tempname
			});
			this.hidename = true;
		}
		if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "OVR")
		{
			this.hidename = true;
		}
	}

	// Token: 0x06000109 RID: 265 RVA: 0x0000F5F8 File Offset: 0x0000D9F8
	private void Start()
	{
		if (base.gameObject.name == "player(Clone)" || base.gameObject.name == "Player(Clone)")
		{
			base.gameObject.name = "Player";
		}
	}

	// Token: 0x0600010A RID: 266 RVA: 0x0000F649 File Offset: 0x0000DA49
	private void Update()
	{
		this.playerName = base.gameObject.name;
		if (this.playerName.Contains("Guest"))
		{
			this.isadmin = false;
		}
	}

	// Token: 0x0600010B RID: 267 RVA: 0x0000F678 File Offset: 0x0000DA78
	private void OnGUI()
	{
		GUI.depth = 2;
		if (this.showname && !this.hidename)
		{
			if (this.isadmin)
			{
				GUI.color = Color.red;
			}
			else
			{
				GUI.color = Color.white;
			}
			if (Camera.main)
			{
				Vector3 vector = Camera.main.WorldToScreenPoint(this.positionDisplay.position);
				if (vector.z * 3f < 50f)
				{
					float num = vector.z * 3f;
				}
				if (vector.z > 0f)
				{
					GUI.Label(new Rect(vector.x - 30f, (float)Screen.height - vector.y - 1f - 21f, 200f, 30f), this.playerName);
				}
			}
		}
	}

	// Token: 0x0600010C RID: 268 RVA: 0x0000F773 File Offset: 0x0000DB73
	[RPC]
	private void SetName(string newname)
	{
		if (base.photonView.isMine)
		{
			newname = this.tempname;
		}
		base.gameObject.name = newname;
	}

	// Token: 0x0400019A RID: 410
	public string playerName;

	// Token: 0x0400019B RID: 411
	public Transform positionDisplay;

	// Token: 0x0400019C RID: 412
	public bool showname = true;

	// Token: 0x0400019D RID: 413
	private string tempname;

	// Token: 0x0400019E RID: 414
	private bool hidename;

	// Token: 0x0400019F RID: 415
	public bool isadmin = true;
}
