using System;
using UnityEngine;

// Token: 0x020000C6 RID: 198
public class AudioProperties : MonoBehaviour
{
	// Token: 0x060003B3 RID: 947 RVA: 0x0002230E File Offset: 0x0002070E
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x00022317 File Offset: 0x00020717
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0002232E File Offset: 0x0002072E
	private void Update()
	{
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x00022330 File Offset: 0x00020730
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect(5f, 30f, 260f, 200f), new GUI.WindowFunction(this.AudioWindow), "Audio Zone Editor");
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x00022370 File Offset: 0x00020770
	private void AudioWindow(int windowID)
	{
		GUI.skin = null;
		GUI.Label(new Rect(25f, 45f, 100f, 22f), "Volume:");
		this.volume = GUI.HorizontalSlider(new Rect(25f, 65f, 100f, 30f), this.volume, 0f, 1f);
		GUI.Label(new Rect(25f, 75f, 100f, 22f), "Pitch:");
		this.pitch = GUI.HorizontalSlider(new Rect(25f, 95f, 100f, 30f), this.pitch, 0f, 3f);
		GUI.skin = this.skin;
		if (GUI.Button(new Rect(145f, 160f, 100f, 20f), "Save Settings"))
		{
			base.enabled = false;
		}
		this.is3d = GUI.Toggle(new Rect(145f, 95f, 100f, 20f), this.is3d, "3D Sound");
		this.loop = GUI.Toggle(new Rect(145f, 115f, 100f, 20f), this.loop, "Loop");
		this.togglevisible = GUI.Toggle(new Rect(25f, 165f, 100f, 20f), this.togglevisible, "Enabled At Start");
		GUI.Label(new Rect(170f, 45f, 70f, 22f), "Object ID");
		this.triggerid = GUI.TextField(new Rect(170f, 65f, 70f, 22f), this.triggerid);
		GUI.Label(new Rect(25f, 115f, 100f, 22f), "Audio Name:");
		this.audioname = GUI.TextField(new Rect(25f, 135f, 100f, 22f), this.audioname);
	}

	// Token: 0x04000431 RID: 1073
	public GUISkin skin;

	// Token: 0x04000432 RID: 1074
	public bool togglevisible = true;

	// Token: 0x04000433 RID: 1075
	public float volume = 1f;

	// Token: 0x04000434 RID: 1076
	public float pitch = 1f;

	// Token: 0x04000435 RID: 1077
	public bool is3d = true;

	// Token: 0x04000436 RID: 1078
	public bool loop;

	// Token: 0x04000437 RID: 1079
	public string triggerid;

	// Token: 0x04000438 RID: 1080
	public string audioname = "Sample.wav";
}
