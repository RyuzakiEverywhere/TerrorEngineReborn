using System;
using UnityEngine;

// Token: 0x02000094 RID: 148
public class GUISkinTest : MonoBehaviour
{
	// Token: 0x06000294 RID: 660 RVA: 0x0001A7A0 File Offset: 0x00018BA0
	private void Awake()
	{
		if (this.thisGUISkins.Length <= 0)
		{
			Debug.LogError("Missing GUI Skin, assign a GUI Skins in the inspector");
			this.error_GUISkins = true;
		}
		else
		{
			for (int i = 0; i < this.thisGUISkins.Length; i++)
			{
				if (!this.thisGUISkins[i])
				{
					Debug.LogError("Missing GUI Skin #" + i + ", assign a GUI Skin in the inspector");
					this.error_GUISkins = true;
				}
			}
		}
		this.rctWindow1 = new Rect(20f, 20f, 200f, 100f);
		this.rctWindow2 = new Rect(240f, 20f, 200f, 380f);
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0001A85C File Offset: 0x00018C5C
	private void OnGUI()
	{
		if (!this.error_GUISkins)
		{
			GUI.skin = this.thisGUISkins[this.selectedGUISkin];
			this.rctWindow1 = GUILayout.Window(0, this.rctWindow1, new GUI.WindowFunction(this.DoConfigWindow), "GUI Skin Config Window", GUI.skin.GetStyle("window"), new GUILayoutOption[0]);
			this.rctWindow2 = GUILayout.Window(1, this.rctWindow2, new GUI.WindowFunction(this.DoMyWindow), this.thisGUISkins[this.selectedGUISkin].name, GUI.skin.GetStyle("window"), new GUILayoutOption[0]);
		}
	}

	// Token: 0x06000296 RID: 662 RVA: 0x0001A904 File Offset: 0x00018D04
	private void DoConfigWindow(int windowID)
	{
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.Label("Select GUI Skin:", new GUILayoutOption[0]);
		GUILayout.Space(2f);
		for (int i = 0; i < this.thisGUISkins.Length; i++)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			string text;
			if (i == this.selectedGUISkin)
			{
				text = "--- " + this.thisGUISkins[i].name + " ---";
			}
			else
			{
				text = this.thisGUISkins[i].name;
			}
			if (GUILayout.Button(text, new GUILayoutOption[0]))
			{
				this.selectedGUISkin = i;
				this.rctWindow1 = new Rect(this.rctWindow1.x, this.rctWindow1.y, 200f, 100f);
				this.rctWindow2 = new Rect(this.rctWindow2.x, this.rctWindow2.y, 200f, 380f);
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndVertical();
		GUI.DragWindow();
	}

	// Token: 0x06000297 RID: 663 RVA: 0x0001AA14 File Offset: 0x00018E14
	private void DoMyWindow(int windowID)
	{
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.Label("Im a Label", new GUILayoutOption[0]);
		GUILayout.Box("Im a Box\nIm the second line", new GUILayoutOption[0]);
		GUILayout.Space(4f);
		GUILayout.Button("Im a Button", new GUILayoutOption[0]);
		GUILayout.Button("Im a ButtonIcon", "ButtonIcon", new GUILayoutOption[0]);
		GUILayout.TextField("Im a Text Field", new GUILayoutOption[0]);
		GUILayout.TextArea("Im a Text Area\nIm the second line\nIm the third line", new GUILayoutOption[0]);
		this.blnToggleState = GUILayout.Toggle(this.blnToggleState, "Im a Toggle", new GUILayoutOption[0]);
		GUILayout.EndVertical();
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.Space(8f);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.fltSliderValue = GUILayout.HorizontalSlider(this.fltSliderValue, 0f, 1.1f, new GUILayoutOption[0]);
		this.fltSliderValue = GUILayout.VerticalSlider(this.fltSliderValue, 0f, 1.1f, new GUILayoutOption[]
		{
			GUILayout.Height(50f)
		});
		GUILayout.EndHorizontal();
		GUILayout.Space(20f);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Space(8f);
		this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, true, true, new GUILayoutOption[]
		{
			GUILayout.Height(80f),
			GUILayout.Width(156f)
		});
		for (int i = 0; i < 8; i++)
		{
			GUILayout.Label("Im the #" + (i + 1) + " very long line of text", new GUILayoutOption[]
			{
				GUILayout.Width(205f)
			});
		}
		GUILayout.EndScrollView();
		GUILayout.EndHorizontal();
		GUILayout.Space(8f);
		GUILayout.EndVertical();
		GUI.DragWindow();
	}

	// Token: 0x04000320 RID: 800
	public GUISkin[] thisGUISkins;

	// Token: 0x04000321 RID: 801
	private bool error_GUISkins;

	// Token: 0x04000322 RID: 802
	private int selectedGUISkin;

	// Token: 0x04000323 RID: 803
	private Rect rctWindow1;

	// Token: 0x04000324 RID: 804
	private Rect rctWindow2;

	// Token: 0x04000325 RID: 805
	private bool blnToggleState = true;

	// Token: 0x04000326 RID: 806
	private float fltSliderValue = 0.5f;

	// Token: 0x04000327 RID: 807
	private Vector2 scrollPosition = Vector2.zero;
}
