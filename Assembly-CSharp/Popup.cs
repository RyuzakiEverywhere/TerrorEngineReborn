using System;
using UnityEngine;

// Token: 0x020000E8 RID: 232
public class Popup
{
	// Token: 0x0600045A RID: 1114 RVA: 0x000328B0 File Offset: 0x00030CB0
	public static bool List(Rect position, ref bool showList, ref int listEntry, GUIContent buttonContent, object[] list, GUIStyle listStyle, Popup.ListCallBack callBack)
	{
		return Popup.List(position, ref showList, ref listEntry, buttonContent, list, "button", "box", listStyle, callBack);
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x000328E0 File Offset: 0x00030CE0
	public static bool List(Rect position, ref bool showList, ref int listEntry, GUIContent buttonContent, object[] list, GUIStyle buttonStyle, GUIStyle boxStyle, GUIStyle listStyle, Popup.ListCallBack callBack)
	{
		int controlID = GUIUtility.GetControlID(Popup.popupListHash, FocusType.Passive);
		bool flag = false;
		EventType typeForControl = Event.current.GetTypeForControl(controlID);
		if (typeForControl != EventType.MouseDown)
		{
			if (typeForControl == EventType.MouseUp)
			{
				if (showList)
				{
					flag = true;
					callBack();
				}
			}
		}
		else if (position.Contains(Event.current.mousePosition))
		{
			GUIUtility.hotControl = controlID;
			showList = true;
		}
		GUI.Label(position, buttonContent, buttonStyle);
		if (showList)
		{
			string[] array = new string[list.Length];
			for (int i = 0; i < list.Length; i++)
			{
				array[i] = list[i].ToString();
			}
			Rect position2 = new Rect(position.x, position.y, position.width, (float)(list.Length * 20));
			GUI.Box(position2, string.Empty, boxStyle);
			listEntry = GUI.SelectionGrid(position2, listEntry, array, 1, listStyle);
		}
		if (flag)
		{
			showList = false;
		}
		return flag;
	}

	// Token: 0x040006A3 RID: 1699
	private static int popupListHash = "PopupList".GetHashCode();

	// Token: 0x020000E9 RID: 233
	// (Invoke) Token: 0x0600045E RID: 1118
	public delegate void ListCallBack();
}
