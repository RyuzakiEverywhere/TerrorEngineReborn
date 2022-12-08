using System;
using UnityEngine;

// Token: 0x020000CC RID: 204
public class DoorProperties : MonoBehaviour
{
	// Token: 0x060003D2 RID: 978 RVA: 0x00023181 File Offset: 0x00021581
	private void Awake()
	{
		base.enabled = false;
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0002318A File Offset: 0x0002158A
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
		base.gameObject.GetComponent<DoorProperties>().enabled = false;
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x000231B2 File Offset: 0x000215B2
	private void Update()
	{
		if (this.keyid > 9)
		{
			this.keyid = 1;
		}
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x000231C8 File Offset: 0x000215C8
	private void ModelWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 370f));
		GUI.Label(new Rect(40f, 20f, 60f, 20f), "ID");
		this.triggerid = GUI.TextField(new Rect(40f, 40f, 60f, 20f), this.triggerid);
		this.togglevisible = GUI.Toggle(new Rect(40f, 70f, 100f, 20f), this.togglevisible, "Enabled At Start");
		this.islocked = GUI.Toggle(new Rect(40f, 90f, 100f, 20f), this.islocked, "Is Locked");
		GUI.Label(new Rect(40f, 120f, 70f, 20f), "Key ID: " + this.keyid.ToString());
		if (GUI.Button(new Rect(40f, 140f, 70f, 20f), "Change ID"))
		{
			this.keyid++;
		}
		GUI.EndScrollView();
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x00023340 File Offset: 0x00021740
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.ModelWindow), "Editor");
	}

	// Token: 0x04000453 RID: 1107
	public GUISkin skin;

	// Token: 0x04000454 RID: 1108
	public Vector2 scrollPosition;

	// Token: 0x04000455 RID: 1109
	public bool togglevisible = true;

	// Token: 0x04000456 RID: 1110
	public string triggerid = "door1";

	// Token: 0x04000457 RID: 1111
	public bool islocked;

	// Token: 0x04000458 RID: 1112
	public int keyid = 1;
}
