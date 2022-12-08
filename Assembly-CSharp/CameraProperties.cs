using System;
using UnityEngine;

// Token: 0x020000C7 RID: 199
public class CameraProperties : MonoBehaviour
{
	// Token: 0x060003B9 RID: 953 RVA: 0x0002259A File Offset: 0x0002099A
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x060003BA RID: 954 RVA: 0x000225A3 File Offset: 0x000209A3
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
	}

	// Token: 0x060003BB RID: 955 RVA: 0x000225BA File Offset: 0x000209BA
	private void Update()
	{
		if (!base.gameObject.GetComponent<PositionAndScale>().enabled)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060003BC RID: 956 RVA: 0x000225D8 File Offset: 0x000209D8
	private void WallWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 350f));
		GUI.Label(new Rect(40f, 40f, 100f, 20f), "Camera Name");
		this.camname = GUI.TextField(new Rect(40f, 60f, 100f, 22f), this.camname);
		GUI.EndScrollView();
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00022684 File Offset: 0x00020A84
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.WallWindow), "Editor");
	}

	// Token: 0x04000439 RID: 1081
	public GUISkin skin;

	// Token: 0x0400043A RID: 1082
	public Vector2 scrollPosition;

	// Token: 0x0400043B RID: 1083
	public string camname;
}
