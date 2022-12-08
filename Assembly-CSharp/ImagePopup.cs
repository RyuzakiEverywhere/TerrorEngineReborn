using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class ImagePopup : MonoBehaviour
{
	// Token: 0x0600034F RID: 847 RVA: 0x0001F6A4 File Offset: 0x0001DAA4
	public void SendNow()
	{
		if (!this.haveimage)
		{
			base.StartCoroutine("LoadImage");
		}
	}

	// Token: 0x06000350 RID: 848 RVA: 0x0001F6BD File Offset: 0x0001DABD
	private void Start()
	{
	}

	// Token: 0x06000351 RID: 849 RVA: 0x0001F6BF File Offset: 0x0001DABF
	private void Update()
	{
		if (this.manual && Input.GetKeyDown(KeyCode.Mouse0))
		{
			base.gameObject.GetComponent<GUITexture>().enabled = false;
			this.haveimage = false;
			this.manual = false;
		}
	}

	// Token: 0x06000352 RID: 850 RVA: 0x0001F6FC File Offset: 0x0001DAFC
	private IEnumerator LoadImage()
	{
		this.haveimage = true;
		if (this.imagetex != null)
		{
			UnityEngine.Object.Destroy(this.imagetex);
		}
		WWW image = new WWW("file:///" + Application.dataPath + "/Images/" + this.imageurl);
		yield return image;
		this.imagetex = image.texture;
		base.gameObject.GetComponent<GUITexture>().texture = this.imagetex;
		base.gameObject.GetComponent<GUITexture>().enabled = true;
		if (!this.manual)
		{
			yield return new WaitForSeconds(this.imagetime);
			base.gameObject.GetComponent<GUITexture>().enabled = false;
			this.haveimage = false;
		}
		yield break;
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0001F717 File Offset: 0x0001DB17
	private void OnGUI()
	{
		if (this.manual)
		{
			GUI.Label(new Rect((float)(Screen.width - 150), (float)(Screen.height - 30), 150f, 30f), "Left Click To Continue");
		}
	}

	// Token: 0x040003A8 RID: 936
	public Texture imagetex;

	// Token: 0x040003A9 RID: 937
	public float imagetime;

	// Token: 0x040003AA RID: 938
	public string imageurl;

	// Token: 0x040003AB RID: 939
	public bool haveimage;

	// Token: 0x040003AC RID: 940
	public bool manual;
}
