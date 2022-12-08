using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
public class GUIEmail : MonoBehaviour
{
	// Token: 0x0600027D RID: 637 RVA: 0x00017F2E File Offset: 0x0001632E
	private void Start()
	{
		this.Send = base.GetComponent<SendEmail>();
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00017F3C File Offset: 0x0001633C
	private void Update()
	{
		this.Length = this.Body.Length;
	}

	// Token: 0x0600027F RID: 639 RVA: 0x00017F50 File Offset: 0x00016350
	private void OnGUI()
	{
		if (this.ShowGUI)
		{
			Time.timeScale = 0f;
			this.windowRect = GUI.Window(0, this.windowRect, new GUI.WindowFunction(this.DoMyWindow), "Report");
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	// Token: 0x06000280 RID: 640 RVA: 0x00017FA4 File Offset: 0x000163A4
	private void DoMyWindow(int windowID)
	{
		GUI.skin = this.ski;
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
		this.address = GUI.TextField(new Rect(this.windowRect.width / 3f, this.windowRect.height / 2f - 40f, this.windowRect.width / 3f, 20f), this.address, 30);
		GUI.Label(new Rect(this.windowRect.width / 4f - 60f, this.windowRect.height / 2f - 40f, 100f, 20f), "Your Email:");
		this.Subject = GUI.TextField(new Rect(this.windowRect.width / 3f, this.windowRect.height / 2f - 20f, this.windowRect.width / 3f, 20f), this.Subject, 20);
		GUI.Label(new Rect(this.windowRect.width / 4f - 60f, this.windowRect.height / 2f - 20f, 100f, 20f), "Subject:");
		this.Body = GUI.TextField(new Rect(this.windowRect.width / 4f, this.windowRect.height / 2f, this.windowRect.width / 2f, 20f), this.Body, 200);
		GUI.Label(new Rect(this.windowRect.width - this.windowRect.width / 4f + 10f, this.windowRect.height / 2f, 100f, 20f), string.Empty + this.Length + "/200");
		GUI.Label(new Rect(this.windowRect.width / 4f - 60f, this.windowRect.height / 2f, 100f, 22f), "Message:");
		if (GUI.Button(new Rect(this.windowRect.width / 2f - 60f, this.windowRect.height - 60f, 120f, 30f), "Send Report"))
		{
			this.Send.Ready = true;
			this.ShowGUI = false;
		}
		if (GUI.Button(new Rect(this.windowRect.width / 2f - 35f, this.windowRect.height - 25f, 70f, 20f), "Cancel"))
		{
			this.ShowGUI = false;
		}
	}

	// Token: 0x04000305 RID: 773
	public bool ShowGUI;

	// Token: 0x04000306 RID: 774
	private Rect windowRect = new Rect((float)(Screen.width / 3), (float)(Screen.height / 3), (float)(Screen.width / 2), (float)(Screen.height / 3 + 10));

	// Token: 0x04000307 RID: 775
	public string Body = string.Empty;

	// Token: 0x04000308 RID: 776
	public string Subject = string.Empty;

	// Token: 0x04000309 RID: 777
	public string address = string.Empty;

	// Token: 0x0400030A RID: 778
	private SendEmail Send;

	// Token: 0x0400030B RID: 779
	private int Length;

	// Token: 0x0400030C RID: 780
	public GUISkin ski;
}
