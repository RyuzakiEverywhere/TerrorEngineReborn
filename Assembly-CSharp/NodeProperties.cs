using System;
using UnityEngine;

// Token: 0x020000DB RID: 219
public class NodeProperties : MonoBehaviour
{
	// Token: 0x0600041E RID: 1054 RVA: 0x0002630E File Offset: 0x0002470E
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x00026317 File Offset: 0x00024717
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0002632E File Offset: 0x0002472E
	private void Update()
	{
		if (!base.gameObject.GetComponent<PositionAndScale>().enabled)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x0002634C File Offset: 0x0002474C
	private void WallWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 350f));
		this.togglevisible = GUI.Toggle(new Rect(40f, 20f, 100f, 20f), this.togglevisible, "Enabled At Start");
		GUI.Label(new Rect(40f, 40f, 100f, 20f), "Node Name");
		this.nodename = GUI.TextField(new Rect(40f, 60f, 100f, 22f), this.nodename);
		this.showwaypoint = GUI.Toggle(new Rect(40f, 80f, 100f, 20f), this.showwaypoint, "Display Waypoint");
		if (this.showwaypoint)
		{
			GUI.Label(new Rect(40f, 100f, 100f, 20f), "Waypoint Text");
			this.waypointname = GUI.TextField(new Rect(40f, 120f, 100f, 22f), this.waypointname);
		}
		GUI.EndScrollView();
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x000264AC File Offset: 0x000248AC
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.WallWindow), "Editor");
	}

	// Token: 0x040004C0 RID: 1216
	public GUISkin skin;

	// Token: 0x040004C1 RID: 1217
	public Vector2 scrollPosition;

	// Token: 0x040004C2 RID: 1218
	public bool togglevisible = true;

	// Token: 0x040004C3 RID: 1219
	public string nodename;

	// Token: 0x040004C4 RID: 1220
	public bool showwaypoint;

	// Token: 0x040004C5 RID: 1221
	public string waypointname;
}
