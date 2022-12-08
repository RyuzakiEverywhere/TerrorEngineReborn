using System;
using UnityEngine;

// Token: 0x020000F1 RID: 241
public class TriggerProperties : MonoBehaviour
{
	// Token: 0x06000487 RID: 1159 RVA: 0x00037361 File Offset: 0x00035761
	private void Awake()
	{
		if (base.gameObject.GetComponent<PositionAndScale>().events)
		{
			base.gameObject.tag = "Event";
		}
		base.enabled = false;
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0003738F File Offset: 0x0003578F
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x000373A6 File Offset: 0x000357A6
	private void Update()
	{
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x000373A8 File Offset: 0x000357A8
	private void TriggerWindow(int windowID)
	{
		GUI.Label(new Rect(395f, 45f, 70f, 22f), "Object ID");
		this.triggerid = GUI.TextField(new Rect(395f, 65f, 70f, 22f), this.triggerid);
		GUI.Box(new Rect(20f, 45f, 180f, 90f), "Type");
		if (this.onenter && GUI.Button(new Rect(62f, 80f, 100f, 20f), "On Enter"))
		{
			this.onenter = false;
			this.interactive = true;
		}
		if (this.interactive && GUI.Button(new Rect(62f, 80f, 100f, 20f), "Manual"))
		{
			this.onenter = true;
			this.interactive = false;
		}
		if (GUI.Button(new Rect(380f, 410f, 100f, 20f), "Save Settings"))
		{
			base.enabled = false;
		}
		this.destroyonexit = GUI.Toggle(new Rect(20f, 150f, 100f, 20f), this.destroyonexit, "Destroy On Exit");
		if (this.interactive)
		{
			GUI.Label(new Rect(25f, 110f, 60f, 22f), "Press E");
			this.imessage = GUI.TextField(new Rect(83f, 110f, 95f, 22f), this.imessage);
		}
		this.toggleobj = GUI.Toggle(new Rect(20f, 170f, 120f, 20f), this.toggleobj, "Activate/Deactivate Objects");
		if (this.toggleobj)
		{
			GUI.Label(new Rect(20f, 190f, 30f, 22f), "ID:");
			this.toggleid = GUI.TextField(new Rect(50f, 190f, 50f, 22f), this.toggleid);
		}
		this.playsound = GUI.Toggle(new Rect(20f, 220f, 100f, 20f), this.playsound, "Play Audio");
		if (this.playsound)
		{
			GUI.Label(new Rect(20f, 240f, 40f, 22f), "Path");
			this.soundpath = GUI.TextField(new Rect(60f, 240f, 110f, 22f), this.soundpath);
			this.soundloop = GUI.Toggle(new Rect(120f, 220f, 100f, 20f), this.soundloop, "Loop");
		}
		this.displayimg = GUI.Toggle(new Rect(20f, 270f, 100f, 20f), this.displayimg, "Display Image");
		if (this.displayimg)
		{
			GUI.Label(new Rect(20f, 290f, 40f, 22f), "Path");
			this.imgpath = GUI.TextField(new Rect(60f, 290f, 110f, 22f), this.imgpath);
			this.imgmanually = GUI.Toggle(new Rect(120f, 270f, 100f, 20f), this.imgmanually, "Manual Disable");
			if (!this.imgmanually)
			{
				GUI.Label(new Rect(20f, 312f, 80f, 22f), "Duration:");
				this.imgduration = GUI.TextField(new Rect(100f, 312f, 50f, 22f), this.imgduration);
			}
		}
		this.door = GUI.Toggle(new Rect(20f, 337f, 100f, 20f), this.door, "Lock/Unlock Door");
		if (this.door)
		{
			GUI.Label(new Rect(20f, 357f, 40f, 22f), "Name:");
			this.doorname = GUI.TextField(new Rect(60f, 357f, 110f, 22f), this.doorname);
		}
		this.teleport = GUI.Toggle(new Rect(20f, 382f, 100f, 20f), this.teleport, "Teleport");
		if (this.teleport)
		{
			GUI.Label(new Rect(20f, 402f, 40f, 22f), "To:");
			this.nodename = GUI.TextField(new Rect(60f, 402f, 110f, 22f), this.nodename);
		}
		this.playvideo = GUI.Toggle(new Rect(220f, 50f, 100f, 20f), this.playvideo, "Play Video");
		if (this.playvideo)
		{
			GUI.Label(new Rect(220f, 70f, 40f, 22f), "Path");
			this.videopath = GUI.TextField(new Rect(260f, 70f, 110f, 22f), this.videopath);
		}
		this.enablecam = GUI.Toggle(new Rect(220f, 100f, 100f, 20f), this.enablecam, "Enable Camera");
		if (this.enablecam)
		{
			GUI.Label(new Rect(220f, 120f, 45f, 22f), "Name:");
			this.camname = GUI.TextField(new Rect(265f, 120f, 80f, 22f), this.camname);
			GUI.Label(new Rect(220f, 142f, 80f, 22f), "Duration:");
			this.camduration = GUI.TextField(new Rect(300f, 142f, 50f, 22f), this.camduration);
		}
		GUI.Box(new Rect(230f, 180f, 230f, 170f), "Display Text");
		this.displaytext = GUI.Toggle(new Rect(240f, 220f, 100f, 20f), this.displaytext, "Enable");
		if (this.displaytext)
		{
			GUI.Label(new Rect(300f, 220f, 80f, 22f), "Duration:");
			this.textduration = GUI.TextField(new Rect(380f, 220f, 50f, 22f), this.textduration);
			this.text = GUI.TextArea(new Rect(240f, 240f, 210f, 100f), this.text);
		}
		this.togglevisible = GUI.Toggle(new Rect(255f, 412f, 130f, 20f), this.togglevisible, "Enabled At Start");
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x00037B14 File Offset: 0x00035F14
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect(5f, 30f, 500f, 450f), new GUI.WindowFunction(this.TriggerWindow), "Trigger Editor");
	}

	// Token: 0x0400075E RID: 1886
	public GUISkin skin;

	// Token: 0x0400075F RID: 1887
	public bool togglevisible = true;

	// Token: 0x04000760 RID: 1888
	public string triggerid;

	// Token: 0x04000761 RID: 1889
	public bool onenter = true;

	// Token: 0x04000762 RID: 1890
	public bool interactive;

	// Token: 0x04000763 RID: 1891
	public bool destroyonexit;

	// Token: 0x04000764 RID: 1892
	public string imessage = "To Activate";

	// Token: 0x04000765 RID: 1893
	public bool toggleobj;

	// Token: 0x04000766 RID: 1894
	public string toggleid = "1";

	// Token: 0x04000767 RID: 1895
	public bool playsound;

	// Token: 0x04000768 RID: 1896
	public string soundpath = "sample.wav";

	// Token: 0x04000769 RID: 1897
	public bool soundloop;

	// Token: 0x0400076A RID: 1898
	public bool playvideo;

	// Token: 0x0400076B RID: 1899
	public string videopath = "sample.ogg";

	// Token: 0x0400076C RID: 1900
	public bool displayimg;

	// Token: 0x0400076D RID: 1901
	public string imgpath = "sample.png";

	// Token: 0x0400076E RID: 1902
	public bool imgmanually;

	// Token: 0x0400076F RID: 1903
	public string imgduration = "1";

	// Token: 0x04000770 RID: 1904
	public bool teleport;

	// Token: 0x04000771 RID: 1905
	public string nodename = "NodeName";

	// Token: 0x04000772 RID: 1906
	public bool door;

	// Token: 0x04000773 RID: 1907
	public string doorname = "Door";

	// Token: 0x04000774 RID: 1908
	public bool enablecam;

	// Token: 0x04000775 RID: 1909
	public string camname = "Camera1";

	// Token: 0x04000776 RID: 1910
	public string camduration = "3";

	// Token: 0x04000777 RID: 1911
	public bool displaytext;

	// Token: 0x04000778 RID: 1912
	public string text = "This text will appear on screen for a duration of time when the player enters the trigger or manually presses F depending on the settings, click on the box to edit.";

	// Token: 0x04000779 RID: 1913
	public string textduration = "5";
}
