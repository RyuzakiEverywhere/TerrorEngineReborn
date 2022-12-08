using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class CinematicTrigger : MonoBehaviour
{
	// Token: 0x06000033 RID: 51 RVA: 0x00005844 File Offset: 0x00003C44
	private void Awake()
	{
		this.cp = base.gameObject.GetComponent<CinematicProperties>();
		if (this.cp.type == 1)
		{
			this.lookattrigger = true;
		}
		this.thecam = new GameObject("CinematicCAMERA");
		this.thecam.transform.tag = "CinematicCam";
		this.thecam.transform.localPosition = new Vector3(float.Parse(this.cp.xpos), float.Parse(this.cp.ypos), float.Parse(this.cp.zpos));
		this.thecam.transform.parent = base.gameObject.transform;
		this.thecam.AddComponent<CinematicCam>().enabled = false;
		if (this.lookattrigger)
		{
			this.thecam.GetComponent<CinematicCam>().target = base.gameObject.transform;
		}
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00005938 File Offset: 0x00003D38
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player" && other.GetComponent<PhotonView>() != null && other.GetComponent<PhotonView>().isMine)
		{
			GameObject gameObject = GameObject.Find("PlayerCamera");
			if (gameObject.transform.parent != null && gameObject.transform.parent.name == "CinematicCAMERA")
			{
				gameObject.transform.parent.GetComponent<CinematicCam>().enabled = false;
			}
			gameObject.transform.parent = null;
			gameObject.transform.parent = this.thecam.transform;
			gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.thecam.GetComponent<CinematicCam>().enabled = true;
		}
	}

	// Token: 0x04000049 RID: 73
	public bool lookattrigger;

	// Token: 0x0400004A RID: 74
	public GameObject thecam;

	// Token: 0x0400004B RID: 75
	public CinematicProperties cp;
}
