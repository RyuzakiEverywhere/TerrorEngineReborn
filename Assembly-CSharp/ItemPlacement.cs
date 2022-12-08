using System;
using System.Collections;
using Photon;
using UnityEngine;

// Token: 0x02000027 RID: 39
public class ItemPlacement : Photon.MonoBehaviour
{
	// Token: 0x060000A5 RID: 165 RVA: 0x0000AC90 File Offset: 0x00009090
	private IEnumerator Start()
	{
		this.player = base.gameObject.transform.parent.gameObject;
		if (base.gameObject.name == "ic1" || base.gameObject.name == "ic2" || base.gameObject.name == "ic3" || base.gameObject.name == "ic4" || base.gameObject.name == "ic5")
		{
			this.gii = base.gameObject.GetComponent<GetItemInfo>();
			yield return new WaitForEndOfFrame();
			string modelname = this.gii.infoobj.GetComponent<CustomItemsProperties>().modelname;
			WWW www = new WWW(string.Concat(new string[]
			{
				"file:///",
				Application.dataPath,
				"/Models/Items/",
				modelname,
				"_icon.png"
			}));
			yield return www;
			this.icontex = www.texture;
		}
		yield break;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x0000ACAC File Offset: 0x000090AC
	private void Update()
	{
		if (!this.check && base.transform.parent.Find("playermodel(Clone)") != null)
		{
			this.check = true;
		}
		if (this.check && !this.hasmodel)
		{
			this.Check();
		}
		if (this.sa.thirdperson != this.tpm)
		{
			this.Check();
		}
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0000AD24 File Offset: 0x00009124
	private void Check()
	{
		this.hasmodel = true;
		if (!base.photonView.isMine)
		{
			this.hand = base.transform.parent.Find("playermodel(Clone)/model/Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2/Bip01 Spine3/Bip01 Neck/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Wield Hand");
			base.gameObject.transform.position = this.hand.position;
			base.gameObject.transform.parent = this.hand;
			if (base.gameObject.name == "ilantern" || base.gameObject.name == "itorch" || base.gameObject.name == "icandle")
			{
				base.gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
				base.transform.Find("model").localPosition = new Vector3(0.04f, -0.004f, -0.15f);
				this.handmodel.gameObject.SetActive(false);
			}
			else
			{
				if (base.gameObject.name == "iflashlight")
				{
					base.gameObject.transform.localEulerAngles = new Vector3(0f, -90f, 90f);
					base.transform.Find("model").localPosition = new Vector3(0.04f, -0.004f, 0.1f);
					this.handmodel.gameObject.SetActive(false);
				}
				base.transform.Find("model").localPosition = new Vector3(-0.04f, -0.004f, 0.1f);
			}
			if (base.gameObject.name == "ic1" || base.gameObject.name == "ic2" || base.gameObject.name == "ic3" || base.gameObject.name == "ic4" || base.gameObject.name == "ic5")
			{
				base.gameObject.transform.localEulerAngles = new Vector3(350f, 276f, 264f);
				base.gameObject.transform.localPosition = new Vector3(-0.04f, -0.004f, 0.1f);
			}
		}
		else
		{
			if (!this.haspositions)
			{
				this.hand = base.transform.parent.Find("playermodel(Clone)/model/Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2/Bip01 Spine3/Bip01 Neck/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Wield Hand");
				if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) != "OVR")
				{
					this.fphand = base.transform.parent.Find("Head/MoveCam/PlayerCamera");
				}
				else
				{
					this.fphand = base.transform.parent.Find("Head/OVRCameraController/CameraLeft");
				}
				this.haspositions = true;
			}
			if (this.sa.thirdperson)
			{
				base.gameObject.GetComponent<Animation>().enabled = false;
				base.gameObject.transform.position = this.hand.position;
				base.gameObject.transform.parent = this.hand;
				if (base.gameObject.name == "ilantern" || base.gameObject.name == "itorch" || base.gameObject.name == "icandle")
				{
					base.gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
					this.temppos = base.transform.Find("model").localPosition;
					base.transform.Find("model").localPosition = new Vector3(0.04f, -0.004f, -0.15f);
					this.handmodel.gameObject.SetActive(false);
				}
				else if (base.gameObject.name == "iflashlight")
				{
					base.gameObject.transform.localEulerAngles = new Vector3(0f, -90f, 90f);
					this.temppos = base.transform.Find("model").localPosition;
					base.transform.Find("model").localPosition = new Vector3(0.04f, -0.004f, 0.1f);
					this.handmodel.gameObject.SetActive(false);
				}
				if (base.gameObject.name == "ic1" || base.gameObject.name == "ic2" || base.gameObject.name == "ic3" || base.gameObject.name == "ic4" || base.gameObject.name == "ic5")
				{
					base.gameObject.transform.localEulerAngles = new Vector3(0f, 276f, 264f);
				}
			}
			else
			{
				base.gameObject.GetComponent<Animation>().enabled = true;
				if (CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "Normal" || CryptoPlayerPrefs.GetString("CamMode", string.Empty) == "Analygraph")
				{
					base.gameObject.transform.parent = this.fphand;
				}
				else
				{
					base.gameObject.transform.parent = this.fphand;
				}
				base.gameObject.transform.localPosition = new Vector3(0.35f, -0.4f, 0.65f);
				base.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				if (base.gameObject.name == "ilantern" || base.gameObject.name == "itorch" || base.gameObject.name == "icandle" || base.gameObject.name == "iflashlight")
				{
					this.handmodel.gameObject.SetActive(true);
				}
				if (base.transform.Find("model") != null)
				{
					base.transform.Find("model").localPosition = this.temppos;
				}
			}
		}
		this.tpm = this.sa.thirdperson;
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x0000B420 File Offset: 0x00009820
	private void OnGUI()
	{
		if (base.photonView.isMine && this.icontex)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width - 110), (float)(Screen.height - 110), 100f, 100f), this.icontex);
		}
	}

	// Token: 0x040000E9 RID: 233
	public Transform hand;

	// Token: 0x040000EA RID: 234
	public GameObject player;

	// Token: 0x040000EB RID: 235
	public bool check;

	// Token: 0x040000EC RID: 236
	public bool hasmodel;

	// Token: 0x040000ED RID: 237
	public SyncAnimation sa;

	// Token: 0x040000EE RID: 238
	public bool tpm;

	// Token: 0x040000EF RID: 239
	public Transform fphand;

	// Token: 0x040000F0 RID: 240
	public Transform handmodel;

	// Token: 0x040000F1 RID: 241
	public bool haspositions;

	// Token: 0x040000F2 RID: 242
	public Texture2D icontex;

	// Token: 0x040000F3 RID: 243
	private GetItemInfo gii;

	// Token: 0x040000F4 RID: 244
	private Vector3 temppos;
}
