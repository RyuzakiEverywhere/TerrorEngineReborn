using System;
using UnityEngine;

// Token: 0x0200016A RID: 362
public class ShowDead : MonoBehaviour
{
	// Token: 0x06000895 RID: 2197 RVA: 0x0004FD61 File Offset: 0x0004E161
	private void Start()
	{
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x0004FD63 File Offset: 0x0004E163
	private void Update()
	{
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x0004FD65 File Offset: 0x0004E165
	private void OnGUI()
	{
		GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.guitex);
	}

	// Token: 0x04000AA6 RID: 2726
	public Texture2D guitex;
}
