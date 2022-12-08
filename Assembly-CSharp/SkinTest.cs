using System;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class SkinTest : MonoBehaviour
{
	// Token: 0x0600032C RID: 812 RVA: 0x0001EBAC File Offset: 0x0001CFAC
	private void Awake()
	{
		this.rctWindow1 = new Rect(20f, 20f, 320f, 400f);
		this.rctWindow2 = new Rect(260f, 30f, 320f, 420f);
		this.rctWindow3 = new Rect(260f, 30f, 320f, 200f);
		this.rctWindow4 = new Rect(360f, 20f, 320f, 400f);
		for (int i = 0; i < 19; i++)
		{
			this.testArray[i].itemType = "node";
			this.testArray[i].itemName = "Hello" + i;
		}
	}

	// Token: 0x0600032D RID: 813 RVA: 0x0001EC80 File Offset: 0x0001D080
	private void OnGUI()
	{
		GUI.skin = this.thisOrangeGUISkin;
		this.rctWindow1 = GUI.Window(0, this.rctWindow1, new GUI.WindowFunction(this.DoMyWindow), "Orange Unity", GUI.skin.GetStyle("window"));
		GUI.skin = this.thisMetalGUISkin;
		this.rctWindow2 = GUI.Window(1, this.rctWindow2, new GUI.WindowFunction(this.DoMyWindow2), "Metal Vista", GUI.skin.GetStyle("window"));
		this.rctWindow3 = GUI.Window(2, this.rctWindow3, new GUI.WindowFunction(this.DoMyWindow4), "Compound Control - Toggle Listbox", GUI.skin.GetStyle("window"));
		GUI.skin = this.thisAmigaGUISkin;
		this.rctWindow4 = GUI.Window(3, this.rctWindow4, new GUI.WindowFunction(this.DoMyWindow), "Amiga500", GUI.skin.GetStyle("window"));
	}

	// Token: 0x0600032E RID: 814 RVA: 0x0001ED76 File Offset: 0x0001D176
	private void gcListItem(string strItemName)
	{
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label(strItemName, new GUILayoutOption[0]);
		this.blnToggleState = GUILayout.Toggle(this.blnToggleState, string.Empty, new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
	}

	// Token: 0x0600032F RID: 815 RVA: 0x0001EDB0 File Offset: 0x0001D1B0
	private void gcListBox()
	{
		GUILayout.BeginVertical(GUI.skin.GetStyle("box"), new GUILayoutOption[0]);
		this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, new GUILayoutOption[]
		{
			GUILayout.Width(160f),
			GUILayout.Height(130f)
		});
		for (int i = 0; i < 20; i++)
		{
			this.gcListItem("I'm listItem number " + i);
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
	}

	// Token: 0x06000330 RID: 816 RVA: 0x0001EE3B File Offset: 0x0001D23B
	private void DoMyWindow4(int windowID)
	{
		this.gcListBox();
		GUI.DragWindow();
	}

	// Token: 0x06000331 RID: 817 RVA: 0x0001EE48 File Offset: 0x0001D248
	private void DoMyWindow3(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(10f, 100f, 200f, 200f), this.scrollPosition, new Rect(0f, 0f, 220f, 200f));
		GUI.Button(new Rect(0f, 0f, 100f, 20f), "Top-left");
		GUI.Button(new Rect(120f, 0f, 100f, 20f), "Top-right");
		GUI.Button(new Rect(0f, 180f, 100f, 20f), "Bottom-left");
		GUI.Button(new Rect(120f, 180f, 100f, 20f), "Bottom-right");
		GUI.EndScrollView();
		GUI.DragWindow();
	}

	// Token: 0x06000332 RID: 818 RVA: 0x0001EF34 File Offset: 0x0001D334
	private void DoMyWindow(int windowID)
	{
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.Label("Im a Label", new GUILayoutOption[0]);
		GUILayout.Space(8f);
		GUILayout.Button("Im a Button", new GUILayoutOption[0]);
		GUILayout.TextField("Im a textfield", new GUILayoutOption[0]);
		GUILayout.TextArea("Im a textfield\nIm the second line\nIm the third line\nIm the fourth line", new GUILayoutOption[0]);
		this.blnToggleState = GUILayout.Toggle(this.blnToggleState, "Im a Toggle button", new GUILayoutOption[0]);
		GUILayout.EndVertical();
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.fltSliderValue = GUILayout.HorizontalSlider(this.fltSliderValue, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Width(128f)
		});
		this.fltSliderValue = GUILayout.VerticalSlider(this.fltSliderValue, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Height(50f)
		});
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.fltScrollerValue = GUILayout.HorizontalScrollbar(this.fltScrollerValue, 0.1f, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Width(128f)
		});
		this.fltScrollerValue = GUILayout.VerticalScrollbar(this.fltScrollerValue, 0.1f, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Height(90f)
		});
		GUILayout.Box("Im\na\ntest\nBox", new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		GUI.DragWindow();
	}

	// Token: 0x06000333 RID: 819 RVA: 0x0001F0C4 File Offset: 0x0001D4C4
	private void DoMyWindow2(int windowID)
	{
		GUILayout.Label("3D Graphics Settings", new GUILayoutOption[0]);
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.blnToggleState = GUILayout.Toggle(this.blnToggleState, "Soft Shadows", new GUILayoutOption[0]);
		this.blnToggleState = GUILayout.Toggle(this.blnToggleState, "Particle Effects", new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.blnToggleState = GUILayout.Toggle(this.blnToggleState, "Enemy Shadows", new GUILayoutOption[0]);
		this.blnToggleState = GUILayout.Toggle(this.blnToggleState, "Object Glow", new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.Button("Im a Button", new GUILayoutOption[0]);
		GUILayout.TextField("Im a textfield", new GUILayoutOption[0]);
		GUILayout.TextArea("Im a textfield\nIm the second line\nIm the third line\nIm the fourth line", new GUILayoutOption[0]);
		this.blnToggleState = GUILayout.Toggle(this.blnToggleState, "Im a Toggle button", new GUILayoutOption[0]);
		GUILayout.EndVertical();
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.fltSliderValue = GUILayout.HorizontalSlider(this.fltSliderValue, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Width(128f)
		});
		this.fltSliderValue = GUILayout.VerticalSlider(this.fltSliderValue, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Height(50f)
		});
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.fltScrollerValue = GUILayout.HorizontalScrollbar(this.fltScrollerValue, 0.1f, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Width(128f)
		});
		this.fltScrollerValue = GUILayout.VerticalScrollbar(this.fltScrollerValue, 0.1f, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Height(90f)
		});
		GUILayout.Box("Im\na\ntest\nBox", new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		GUI.DragWindow();
	}

	// Token: 0x04000391 RID: 913
	public GUISkin thisMetalGUISkin;

	// Token: 0x04000392 RID: 914
	public GUISkin thisOrangeGUISkin;

	// Token: 0x04000393 RID: 915
	public GUISkin thisAmigaGUISkin;

	// Token: 0x04000394 RID: 916
	private Rect rctWindow1;

	// Token: 0x04000395 RID: 917
	private Rect rctWindow2;

	// Token: 0x04000396 RID: 918
	private Rect rctWindow3;

	// Token: 0x04000397 RID: 919
	private Rect rctWindow4;

	// Token: 0x04000398 RID: 920
	private bool blnToggleState;

	// Token: 0x04000399 RID: 921
	private float fltSliderValue = 0.5f;

	// Token: 0x0400039A RID: 922
	private float fltScrollerValue = 0.5f;

	// Token: 0x0400039B RID: 923
	private Vector2 scrollPosition = Vector2.zero;

	// Token: 0x0400039C RID: 924
	private SkinTest.snNodeArray[] testArray = new SkinTest.snNodeArray[20];

	// Token: 0x020000AC RID: 172
	public struct snNodeArray
	{
		// Token: 0x06000334 RID: 820 RVA: 0x0001F2E7 File Offset: 0x0001D6E7
		public snNodeArray(string itemType, string itemName)
		{
			this.itemType = itemType;
			this.itemName = itemName;
		}

		// Token: 0x0400039D RID: 925
		public string itemType;

		// Token: 0x0400039E RID: 926
		public string itemName;
	}
}
