using System;
using UnityEngine;

// Token: 0x020000F0 RID: 240
public class TimerProperties : MonoBehaviour
{
	// Token: 0x06000481 RID: 1153 RVA: 0x00036B28 File Offset: 0x00034F28
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x00036B31 File Offset: 0x00034F31
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x00036B48 File Offset: 0x00034F48
	private void Update()
	{
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x00036B4C File Offset: 0x00034F4C
	private void TriggerWindow(int windowID)
	{
		GUI.Label(new Rect(395f, 45f, 70f, 22f), "Object ID");
		this.triggerid = GUI.TextField(new Rect(395f, 65f, 70f, 22f), this.triggerid);
		GUI.Box(new Rect(20f, 45f, 180f, 90f), "Type");
		if (this.oneshot && GUI.Button(new Rect(62f, 80f, 100f, 20f), "One-Shot"))
		{
			this.oneshot = false;
			this.repeat = true;
		}
		if (this.repeat && GUI.Button(new Rect(62f, 80f, 100f, 20f), "Repeat"))
		{
			this.oneshot = true;
			this.repeat = false;
		}
		GUI.Label(new Rect(25f, 110f, 90f, 22f), "Delay-Time");
		this.duration = GUI.TextField(new Rect(113f, 110f, 50f, 22f), this.duration);
		if (GUI.Button(new Rect(380f, 410f, 100f, 20f), "Save Settings"))
		{
			base.enabled = false;
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

	// Token: 0x06000485 RID: 1157 RVA: 0x0003727E File Offset: 0x0003567E
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect(5f, 30f, 500f, 450f), new GUI.WindowFunction(this.TriggerWindow), "Timer Editor");
	}

	// Token: 0x04000742 RID: 1858
	public GUISkin skin;

	// Token: 0x04000743 RID: 1859
	public bool togglevisible = true;

	// Token: 0x04000744 RID: 1860
	public string triggerid;

	// Token: 0x04000745 RID: 1861
	public bool oneshot = true;

	// Token: 0x04000746 RID: 1862
	public bool repeat;

	// Token: 0x04000747 RID: 1863
	public string duration = "5";

	// Token: 0x04000748 RID: 1864
	public string imessage = "To Activate";

	// Token: 0x04000749 RID: 1865
	public bool toggleobj;

	// Token: 0x0400074A RID: 1866
	public string toggleid = "1";

	// Token: 0x0400074B RID: 1867
	public bool playsound;

	// Token: 0x0400074C RID: 1868
	public string soundpath = "sample.wav";

	// Token: 0x0400074D RID: 1869
	public bool soundloop;

	// Token: 0x0400074E RID: 1870
	public bool playvideo;

	// Token: 0x0400074F RID: 1871
	public string videopath = "sample.ogg";

	// Token: 0x04000750 RID: 1872
	public bool displayimg;

	// Token: 0x04000751 RID: 1873
	public string imgpath = "sample.png";

	// Token: 0x04000752 RID: 1874
	public bool imgmanually;

	// Token: 0x04000753 RID: 1875
	public string imgduration = "1";

	// Token: 0x04000754 RID: 1876
	public bool teleport;

	// Token: 0x04000755 RID: 1877
	public string nodename = "NodeName";

	// Token: 0x04000756 RID: 1878
	public bool door;

	// Token: 0x04000757 RID: 1879
	public string doorname = "Door";

	// Token: 0x04000758 RID: 1880
	public bool enablecam;

	// Token: 0x04000759 RID: 1881
	public string camname = "Camera1";

	// Token: 0x0400075A RID: 1882
	public string camduration = "3";

	// Token: 0x0400075B RID: 1883
	public bool displaytext;

	// Token: 0x0400075C RID: 1884
	public string text = "This text will appear on screen for a duration of time when the timer reaches the duration time, click on the box to edit.";

	// Token: 0x0400075D RID: 1885
	public string textduration = "5";
}
