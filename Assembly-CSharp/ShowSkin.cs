using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200016B RID: 363
public class ShowSkin : MonoBehaviour
{
	// Token: 0x06000899 RID: 2201 RVA: 0x0004FDAC File Offset: 0x0004E1AC
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUISkin guiskin = GUI.skin;
		GUI.BeginGroup(new Rect(30f, 20f, (float)(Screen.width - 60), (float)(Screen.height - 40)), guiskin.name, "window");
		GUIStyle style = GUI.skin.GetStyle("window");
		int num = 0;
		int num2 = 0;
		IEnumerator enumerator = guiskin.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				GUIStyle guistyle = (GUIStyle)obj;
				this.testBool = GUI.Toggle(new Rect((float)num * (this.elemWidth + 20f) + (float)style.padding.left, (float)num2 * (this.elemHeight + 15f) + (float)style.padding.top, this.elemWidth, this.elemHeight), this.testBool, new GUIContent(guistyle.name.ToUpper(), this.testIcon), guistyle);
				num++;
				if ((float)num * (this.elemWidth + 20f) > (float)Screen.width - this.elemWidth - 40f - (float)style.padding.right)
				{
					num = 0;
					num2++;
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		GUI.EndGroup();
	}

	// Token: 0x04000AA7 RID: 2727
	public GUISkin skin;

	// Token: 0x04000AA8 RID: 2728
	public float elemWidth = 100f;

	// Token: 0x04000AA9 RID: 2729
	public float elemHeight = 30f;

	// Token: 0x04000AAA RID: 2730
	public Texture2D testIcon;

	// Token: 0x04000AAB RID: 2731
	private bool testBool;

	// Token: 0x04000AAC RID: 2732
	private int selection;
}
