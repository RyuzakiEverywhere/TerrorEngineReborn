using System;
using UnityEngine;

// Token: 0x020000C8 RID: 200
public class CinematicProperties : MonoBehaviour
{
	// Token: 0x060003BF RID: 959 RVA: 0x00022704 File Offset: 0x00020B04
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00022710 File Offset: 0x00020B10
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
		if (this.xpos == "null")
		{
			Vector3 position = base.transform.position;
			this.xpos = position.x.ToString();
			this.ypos = position.y.ToString();
			this.zpos = position.z.ToString();
		}
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x0002279C File Offset: 0x00020B9C
	private void Update()
	{
		if (!this.haslinerenderer)
		{
			base.gameObject.AddComponent<LineRenderer>();
			this.lr = base.gameObject.GetComponent<LineRenderer>();
			this.lr.SetWidth(0.1f, 0.1f);
			this.lr.SetColors(Color.green, Color.green);
			this.lr.material = new Material(Shader.Find("Transparent/Cutout/Soft Edge Unlit"));
			this.haslinerenderer = true;
		}
		else
		{
			this.lr.enabled = true;
			this.lr.SetPosition(0, base.transform.position);
			this.lr.SetPosition(1, new Vector3(float.Parse(this.xpos), float.Parse(this.ypos), float.Parse(this.zpos)));
		}
		if (!base.gameObject.GetComponent<PositionAndScale>().enabled)
		{
			UnityEngine.Object.Destroy(this.lr);
			this.haslinerenderer = false;
			base.enabled = false;
		}
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x000228A4 File Offset: 0x00020CA4
	private void WallWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 350f));
		GUI.Label(new Rect(40f, 20f, 110f, 20f), "Camera Position");
		GUI.Label(new Rect(40f, 40f, 30f, 20f), "X");
		this.xpos = GUI.TextField(new Rect(70f, 40f, 50f, 22f), this.xpos);
		GUI.Label(new Rect(40f, 65f, 30f, 20f), "Y");
		this.ypos = GUI.TextField(new Rect(70f, 65f, 50f, 22f), this.ypos);
		GUI.Label(new Rect(40f, 90f, 30f, 20f), "Z");
		this.zpos = GUI.TextField(new Rect(70f, 90f, 50f, 22f), this.zpos);
		if (this.type == 0 && GUI.Button(new Rect(40f, 120f, 110f, 20f), "Look At Player"))
		{
			this.type = 1;
		}
		if (this.type == 1 && GUI.Button(new Rect(40f, 120f, 110f, 20f), "Look At Trigger"))
		{
			this.type = 0;
		}
		GUI.EndScrollView();
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x00022A80 File Offset: 0x00020E80
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.WallWindow), "Editor");
	}

	// Token: 0x0400043C RID: 1084
	public GUISkin skin;

	// Token: 0x0400043D RID: 1085
	public Vector2 scrollPosition;

	// Token: 0x0400043E RID: 1086
	public string xpos = "null";

	// Token: 0x0400043F RID: 1087
	public string ypos = "0";

	// Token: 0x04000440 RID: 1088
	public string zpos = "0";

	// Token: 0x04000441 RID: 1089
	public bool haslinerenderer;

	// Token: 0x04000442 RID: 1090
	public LineRenderer lr;

	// Token: 0x04000443 RID: 1091
	public int type;
}
