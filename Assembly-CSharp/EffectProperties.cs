using System;
using UnityEngine;

// Token: 0x020000CD RID: 205
public class EffectProperties : MonoBehaviour
{
	// Token: 0x060003D8 RID: 984 RVA: 0x000233A0 File Offset: 0x000217A0
	private void Awake()
	{
		this.effectobj = base.gameObject.name;
		this.effectobj = this.effectobj.Replace("(Clone)", string.Empty);
		if (!base.gameObject.name.Contains("Effects/"))
		{
			base.gameObject.name = "Effects/" + this.effectobj;
		}
		if (base.gameObject.name.Contains("Effects/Effects/"))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (base.gameObject.transform.parent != null)
		{
			base.gameObject.transform.parent = null;
		}
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0002345F File Offset: 0x0002185F
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
		if (base.gameObject.GetComponent<ModelProperties>() != null)
		{
			base.gameObject.GetComponent<ModelProperties>().enabled = false;
		}
	}

	// Token: 0x060003DA RID: 986 RVA: 0x000234A0 File Offset: 0x000218A0
	private void Update()
	{
		if (this.togglepreview && this.effect == null)
		{
			this.effect = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Effects/_Prefabs/" + this.effectobj), base.transform.position, base.transform.rotation);
		}
		if (!this.togglepreview && this.effect != null)
		{
			UnityEngine.Object.Destroy(this.effect);
		}
		if (this.effect != null)
		{
			this.effect.transform.parent = base.transform;
		}
	}

	// Token: 0x060003DB RID: 987 RVA: 0x00023554 File Offset: 0x00021954
	private void ModelWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 370f));
		this.togglevisible = GUI.Toggle(new Rect(40f, 20f, 100f, 20f), this.togglevisible, "Enabled At Start");
		if (!this.togglevisible)
		{
			GUI.Label(new Rect(40f, 40f, 160f, 20f), "Activate ID");
			this.triggerid = GUI.TextField(new Rect(40f, 60f, 50f, 20f), this.triggerid);
		}
		this.togglepreview = GUI.Toggle(new Rect(40f, 80f, 100f, 20f), this.togglepreview, "Preview");
		if (this.togglevisible)
		{
			this.triggerdeactivate = GUI.Toggle(new Rect(40f, 100f, 100f, 20f), this.triggerdeactivate, "Use Trigger To Deactivate");
			if (this.triggerdeactivate)
			{
				GUI.Label(new Rect(40f, 120f, 160f, 20f), "Deactivate ID");
				this.triggerid = GUI.TextField(new Rect(40f, 150f, 50f, 22f), this.triggerid);
			}
		}
		GUI.EndScrollView();
	}

	// Token: 0x060003DC RID: 988 RVA: 0x000236F8 File Offset: 0x00021AF8
	private void OnGUI()
	{
		GUI.skin = this.skin;
		if (this.showgui)
		{
			GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.ModelWindow), "Editor");
		}
	}

	// Token: 0x04000459 RID: 1113
	public string effectobj;

	// Token: 0x0400045A RID: 1114
	public GameObject effect;

	// Token: 0x0400045B RID: 1115
	public bool showgui;

	// Token: 0x0400045C RID: 1116
	public Vector2 scrollPosition;

	// Token: 0x0400045D RID: 1117
	public GUISkin skin;

	// Token: 0x0400045E RID: 1118
	public bool togglevisible;

	// Token: 0x0400045F RID: 1119
	public bool togglepreview;

	// Token: 0x04000460 RID: 1120
	public bool triggerdeactivate;

	// Token: 0x04000461 RID: 1121
	public string triggerid;
}
