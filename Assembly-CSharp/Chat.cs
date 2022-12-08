using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Photon;
using UnityEngine;

// Token: 0x0200011E RID: 286
public class Chat : Photon.MonoBehaviour
{
	// Token: 0x0600065F RID: 1631 RVA: 0x00040200 File Offset: 0x0003E600
	private void Awake()
	{
		Chat.SP = this;
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x00040208 File Offset: 0x0003E608
	private void OnPhotonSerializeView()
	{
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x0004020C File Offset: 0x0003E60C
	private void Update()
	{
		if (Input.GetKey(KeyCode.T) && !this.isChatting)
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this.ereaseChat());
		}
		if (this.messages.Count > 3)
		{
			this.messages.RemoveAt(0);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			Cursor.visible = !Cursor.visible;
			Screen.lockCursor = !Screen.lockCursor;
		}
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x00040286 File Offset: 0x0003E686
	private void Start()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x000402A0 File Offset: 0x0003E6A0
	private IEnumerator ereaseChat()
	{
		yield return new WaitForSeconds(0.07f);
		this.isChatting = true;
		yield break;
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x000402BC File Offset: 0x0003E6BC
	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect(255f, 5f, (float)(Screen.width - 260), 130f));
		GUI.color = Color.white;
		GUILayout.FlexibleSpace();
		for (int i = 0; i < this.messages.Count; i++)
		{
			GUI.color = Color.green;
			GUILayout.Label(this.messages[i].name, this.chatStyle, new GUILayoutOption[0]);
			GUILayout.Space(5f);
			GUI.color = Color.white;
			GUILayout.Label(this.messages[i].text, this.chatStyle1, new GUILayoutOption[0]);
		}
		GUILayout.EndArea();
		GUILayout.BeginArea(new Rect(90f, (float)(Screen.height - 35), (float)(Screen.width - 100), 30f));
		if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
		{
			this.isChatting = false;
			this.SendChat(PhotonTargets.All);
		}
		if (this.isChatting)
		{
			GUI.FocusControl("ChatField");
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUI.SetNextControlName("ChatField");
			GUI.color = Color.red;
			GUILayout.Label("Say: ", this.chatStyle, new GUILayoutOption[0]);
			GUILayout.Space(5f);
			GUI.color = Color.white;
			this.chatInput = GUILayout.TextField(this.chatInput, 50, this.chatStyle1, new GUILayoutOption[]
			{
				GUILayout.MinWidth(200f)
			});
			GUILayout.EndHorizontal();
		}
		else
		{
			GUI.FocusControl(string.Empty);
		}
		GUILayout.EndArea();
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x0004047E File Offset: 0x0003E87E
	public static void AddMessage(string name, string text)
	{
		Chat.SP.messages.Add(new Chat.ChatData(name, text));
		if (Chat.SP.messages.Count > 13)
		{
			Chat.SP.messages.RemoveAt(0);
		}
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x000404BC File Offset: 0x0003E8BC
	[RPC]
	private void SendChatMessage(string text, PhotonMessageInfo info)
	{
		Chat.AddMessage("  " + info.sender + ": ", text);
	}

	// Token: 0x06000667 RID: 1639 RVA: 0x000404DC File Offset: 0x0003E8DC
	private void SendChat(PhotonTargets target)
	{
		if (this.chatInput != string.Empty)
		{
			string text = " " + this.chatInput;
			base.photonView.RPC("SendChatMessage", target, new object[]
			{
				text
			});
			this.chatInput = string.Empty;
		}
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x00040538 File Offset: 0x0003E938
	private void SendChat(PhotonPlayer target)
	{
		if (this.chatInput != string.Empty)
		{
			this.chatInput = "[PM] " + this.chatInput;
			base.photonView.RPC("SendChatMessage", target, new object[]
			{
				this.chatInput
			});
			this.chatInput = string.Empty;
		}
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x0004059B File Offset: 0x0003E99B
	private void OnLeftRoom()
	{
		this.messages.Clear();
		base.enabled = false;
	}

	// Token: 0x0600066A RID: 1642 RVA: 0x000405AF File Offset: 0x0003E9AF
	private void OnJoinedRoom()
	{
		base.enabled = true;
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x000405B8 File Offset: 0x0003E9B8
	private void OnCreatedRoom()
	{
		base.enabled = true;
	}

	// Token: 0x040008DD RID: 2269
	public static Chat SP;

	// Token: 0x040008DE RID: 2270
	public List<Chat.ChatData> messages = new List<Chat.ChatData>();

	// Token: 0x040008DF RID: 2271
	private int chatHeight = 75;

	// Token: 0x040008E0 RID: 2272
	private Vector2 scrollPos = Vector2.zero;

	// Token: 0x040008E1 RID: 2273
	[HideInInspector]
	public string chatInput = string.Empty;

	// Token: 0x040008E2 RID: 2274
	[HideInInspector]
	public bool isChatting;

	// Token: 0x040008E3 RID: 2275
	public GUIStyle chatStyle;

	// Token: 0x040008E4 RID: 2276
	public GUIStyle chatStyle1;

	// Token: 0x0200011F RID: 287
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ChatData
	{
		// Token: 0x0600066C RID: 1644 RVA: 0x000405C1 File Offset: 0x0003E9C1
		public ChatData(string string1, string string2)
		{
			this.name = string1;
			this.text = string2;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x000405D1 File Offset: 0x0003E9D1
		// (set) Token: 0x0600066E RID: 1646 RVA: 0x000405D9 File Offset: 0x0003E9D9
		public string name { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x000405E2 File Offset: 0x0003E9E2
		// (set) Token: 0x06000670 RID: 1648 RVA: 0x000405EA File Offset: 0x0003E9EA
		public string text { get; set; }
	}
}
