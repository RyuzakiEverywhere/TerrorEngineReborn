using System;
using Photon;
using UnityEngine;

// Token: 0x020000E4 RID: 228
public class EditObjEnable : Photon.MonoBehaviour
{
	// Token: 0x06000446 RID: 1094 RVA: 0x0002F2E8 File Offset: 0x0002D6E8
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			base.gameObject.AddComponent<CheckVisible>();
			base.gameObject.AddComponent<ObjectPlayMode>();
		}
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x0002F340 File Offset: 0x0002D740
	private void Start()
	{
		this.obj = (Resources.Load(base.gameObject.name.ToString()) as GameObject);
		if (base.gameObject.GetComponent<MeshFilter>() != null && this.obj != null && base.GetComponent<MeshFilter>().mesh != null && this.obj.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
		{
			base.GetComponent<MeshFilter>().sharedMesh = this.obj.gameObject.GetComponent<MeshFilter>().sharedMesh;
		}
		base.GetComponent<Renderer>().material.color = Color.white;
		if (base.gameObject.GetComponent<PositionAndScale>() != null)
		{
			base.gameObject.AddComponent<Resize>();
		}
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x0002F424 File Offset: 0x0002D824
	public void OnMouseDown()
	{
		if (base.gameObject.GetComponent<PhotonView>() != null && !base.photonView.isMine)
		{
			base.GetComponent<Renderer>().material.color = Color.red;
			return;
		}
		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		{
			this.toggleon = !this.toggleon;
			if (this.toggleon)
			{
				base.gameObject.GetComponent<PositionAndScale>().enabled = true;
			}
		}
		if (!this.toggleon)
		{
			base.GetComponent<Renderer>().material.color = Color.white;
			base.gameObject.GetComponent<PositionAndScale>().enabled = false;
			if (base.gameObject.GetComponent<WallProperties>() != null)
			{
				base.gameObject.GetComponent<WallProperties>().enabled = false;
			}
			if (base.gameObject.GetComponent<NPCObjProperties>() != null)
			{
				base.gameObject.GetComponent<NPCObjProperties>().enabled = false;
			}
			if (base.gameObject.GetComponent<ModProperties>() != null)
			{
				base.gameObject.GetComponent<ModProperties>().enabled = false;
			}
			if (base.gameObject.GetComponent<LightProperties>() != null)
			{
				base.gameObject.GetComponent<LightProperties>().enabled = false;
			}
		}
	}

	// Token: 0x04000670 RID: 1648
	public bool toggleon;

	// Token: 0x04000671 RID: 1649
	public GameObject obj;

	// Token: 0x04000672 RID: 1650
	public Vector3 sc;
}
