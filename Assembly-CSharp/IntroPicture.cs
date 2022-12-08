using System;
using UnityEngine;

// Token: 0x020000BD RID: 189
public class IntroPicture : MonoBehaviour
{
	// Token: 0x06000386 RID: 902 RVA: 0x00020AB0 File Offset: 0x0001EEB0
	private void Start()
	{
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00020AB2 File Offset: 0x0001EEB2
	private void Update()
	{
	}

	// Token: 0x06000388 RID: 904 RVA: 0x00020AB4 File Offset: 0x0001EEB4
	private void OnGUI()
	{
		GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.image);
		GUI.skin = this.skin1;
		if (GUI.Button(new Rect((float)(Screen.width - 210), (float)(Screen.height - 30), 205f, 25f), "Continue"))
		{
			base.GetComponent<TestGUI>().enabled = true;
			base.enabled = false;
		}
	}

	// Token: 0x040003DF RID: 991
	public Texture2D image;

	// Token: 0x040003E0 RID: 992
	public GUISkin skin1;

	// Token: 0x040003E1 RID: 993
	public GameObject characterselection;
}
