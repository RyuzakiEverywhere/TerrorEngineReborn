using System;
using UnityEngine;

// Token: 0x020000EC RID: 236
public class WallProperties : MonoBehaviour
{
	// Token: 0x0600046B RID: 1131 RVA: 0x00033453 File Offset: 0x00031853
	private void Awake()
	{
		base.enabled = false;
		base.gameObject.layer = 18;
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x00033469 File Offset: 0x00031869
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x00033480 File Offset: 0x00031880
	private void Update()
	{
		if (this.hasct)
		{
			WWW www = new WWW(string.Concat(new string[]
			{
				"file://",
				Application.persistentDataPath,
				"/Stories/",
				PlayerPrefs.GetString("storyname"),
				"/Textures/",
				this.ctpath
			}));
			base.GetComponent<Renderer>().material.mainTexture = www.texture;
		}
		if (this.iswall)
		{
			this.curmesh = (Resources.Load("cube", typeof(Mesh)) as Mesh);
		}
		if (this.isdoor)
		{
			this.curmesh = (Resources.Load("doorframe", typeof(Mesh)) as Mesh);
		}
		if (this.iswindow)
		{
			this.curmesh = (Resources.Load("window", typeof(Mesh)) as Mesh);
		}
		base.gameObject.GetComponent<MeshFilter>().mesh = this.curmesh;
		if (GameObject.Find("Play"))
		{
			UnityEngine.Object.Destroy(this);
		}
		if (!base.gameObject.GetComponent<PositionAndScale>().enabled)
		{
			base.gameObject.GetComponent<WallProperties>().enabled = false;
		}
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x000335CC File Offset: 0x000319CC
	private void WallWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 350f));
		GUI.Box(new Rect(30f, 100f, 180f, 65f), "Type");
		if (!this.togglevisible)
		{
			GUI.Label(new Rect(40f, 40f, 160f, 20f), "Activate ID");
			this.triggerid = GUI.TextField(new Rect(40f, 60f, 50f, 20f), this.triggerid);
		}
		if (this.iswall && GUI.Button(new Rect(70f, 135f, 100f, 20f), "Wall"))
		{
			this.iswall = false;
			this.isdoor = true;
			this.iswindow = false;
		}
		if (this.isdoor && GUI.Button(new Rect(70f, 135f, 100f, 20f), "Door"))
		{
			this.iswall = false;
			this.isdoor = false;
			this.iswindow = true;
		}
		if (this.iswindow && GUI.Button(new Rect(70f, 135f, 100f, 20f), "Window"))
		{
			this.iswall = true;
			this.isdoor = false;
			this.iswindow = false;
		}
		this.hasct = GUI.Toggle(new Rect(40f, 245f, 100f, 20f), this.hasct, "Custom Texture");
		if (this.hasct)
		{
			GUI.Label(new Rect(40f, 265f, 130f, 20f), "Texture Name:");
			this.ctpath = GUI.TextField(new Rect(40f, 285f, 130f, 20f), this.ctpath);
			if (GUI.Button(new Rect(40f, 305f, 130f, 20f), "Change"))
			{
				ModelMesh component = base.gameObject.GetComponent<ModelMesh>();
				component.Start();
			}
		}
		if (this.togglevisible)
		{
			this.triggerdeactivate = GUI.Toggle(new Rect(40f, 180f, 100f, 20f), this.triggerdeactivate, "Use Trigger To Deactivate");
			if (this.triggerdeactivate)
			{
				GUI.Label(new Rect(40f, 205f, 160f, 20f), "Deactivate ID");
				this.triggerid = GUI.TextField(new Rect(40f, 225f, 50f, 22f), this.triggerid);
			}
		}
		GUI.EndScrollView();
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x000338D0 File Offset: 0x00031CD0
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.WallWindow), "Editor");
	}

	// Token: 0x040006B5 RID: 1717
	public GUISkin skin;

	// Token: 0x040006B6 RID: 1718
	public Vector2 scrollPosition;

	// Token: 0x040006B7 RID: 1719
	public bool iswall = true;

	// Token: 0x040006B8 RID: 1720
	public bool isdoor;

	// Token: 0x040006B9 RID: 1721
	public bool iswindow;

	// Token: 0x040006BA RID: 1722
	public Mesh curmesh;

	// Token: 0x040006BB RID: 1723
	public bool togglevisible = true;

	// Token: 0x040006BC RID: 1724
	public bool hasct;

	// Token: 0x040006BD RID: 1725
	public Texture customtexture;

	// Token: 0x040006BE RID: 1726
	public string ctpath;

	// Token: 0x040006BF RID: 1727
	public string triggerid;

	// Token: 0x040006C0 RID: 1728
	public bool triggerdeactivate;
}
