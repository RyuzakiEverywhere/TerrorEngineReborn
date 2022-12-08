using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000284 RID: 644
public class database : MonoBehaviour
{
	// Token: 0x1700034A RID: 842
	// (get) Token: 0x0600127E RID: 4734 RVA: 0x00076D71 File Offset: 0x00075171
	// (set) Token: 0x0600127F RID: 4735 RVA: 0x00076D7E File Offset: 0x0007517E
	public string STRING
	{
		get
		{
			return SC.ToString(this._STRING);
		}
		set
		{
			this._STRING = SC.FromString(value);
		}
	}

	// Token: 0x06001280 RID: 4736 RVA: 0x00076D8C File Offset: 0x0007518C
	public IEnumerator Start()
	{
		this.versionText.text = "Version: " + this.version;
		if (GameObject.Find("isMenu") == null)
		{
			base.enabled = false;
		}
		database.user = CryptoPlayerPrefs.GetString("E602397", string.Empty);
		this.password = CryptoPlayerPrefs.GetString("E203051", string.Empty);
		CryptoPlayerPrefs.SetString("E410675", "000");
		WWW www = new WWW(this.url);
		yield return www;
		if (www.error == null)
		{
			this.result = www.text;
			if (this.result == this.version)
			{
				this.cfu = false;
				this.showlogin = true;
			}
			else
			{
				this.cfu = false;
				this.nua = true;
			}
		}
		else
		{
			this.cfu = false;
			this.error1 = true;
		}
		Resources.UnloadUnusedAssets();
		Cursor.visible = true;
		Screen.lockCursor = false;
		yield break;
	}

	// Token: 0x06001281 RID: 4737 RVA: 0x00076DA8 File Offset: 0x000751A8
	private void Loginwindow(int windowID)
	{
		GUI.skin = this.loginskin;
		GUILayout.Label("User:", new GUILayoutOption[0]);
		database.user = GUILayout.TextField(database.user, new GUILayoutOption[0]);
		GUILayout.Label("Password:", new GUILayoutOption[0]);
		this.password = GUILayout.PasswordField(this.password, "*"[0], new GUILayoutOption[0]);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		if (GUI.Button(this.playbutton, "Login"))
		{
			this.message = string.Empty;
			if (database.user == string.Empty || this.password == string.Empty)
			{
				this.message += "Please enter all the fields \n";
			}
			else
			{
				WWWForm wwwform = new WWWForm();
				wwwform.AddField("user", database.user);
				wwwform.AddField("password", this.password);
				WWW w = new WWW("http://zeoworks.com/home/telogin.php", wwwform);
				base.StartCoroutine(this.login(w));
			}
		}
		Rect position = this.freebutton;
		position.y += 21f;
		if (GUI.Button(position, "Create an account"))
		{
			Application.OpenURL("http://zeoworks.com/home/member.php?action=register");
		}
		if (GUI.Button(this.freebutton, "Sign in as guest"))
		{
			CryptoPlayerPrefs.SetString("E410675", "000");
			base.gameObject.GetComponent<TestGUI>().multiplayer = "Multiplayer";
			base.gameObject.GetComponent<TestGUI>().storycreator = "Story/Game Creator";
			if (CryptoPlayerPrefs.GetInt("E410670", 0) == 2)
			{
				base.gameObject.GetComponent<TestGUI>().enabled = true;
				base.enabled = false;
			}
			else
			{
				base.gameObject.GetComponent<IntroPicture>().enabled = true;
				CryptoPlayerPrefs.SetInt("E410670", 2);
				base.enabled = false;
			}
		}
		GUILayout.EndHorizontal();
		if (Input.GetKey(KeyCode.Q))
		{
			GUI.Label(new Rect(0f, (float)(Screen.height - 20), 600f, 20f), Application.persistentDataPath + "/Stories");
		}
	}

	// Token: 0x06001282 RID: 4738 RVA: 0x00076FDC File Offset: 0x000753DC
	private IEnumerator login(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			if (w.text == "2")
			{
				MonoBehaviour.print("WOOOOOOOOOOOOOOO!");
				this._STRING = "E2193590";
				CryptoPlayerPrefs.SetString("E410675", this._STRING);
				CryptoPlayerPrefs.SetString("E602397", database.user);
				CryptoPlayerPrefs.SetString("E203051", this.password);
				if (CryptoPlayerPrefs.GetInt("E410670", 0) == 2)
				{
					base.gameObject.GetComponent<TestGUI>().enabled = true;
					base.enabled = false;
				}
				else
				{
					base.gameObject.GetComponent<IntroPicture>().enabled = true;
					CryptoPlayerPrefs.SetInt("E410670", 2);
					base.enabled = false;
				}
			}
			else
			{
				this.message += w.text;
			}
		}
		else
		{
			this.message = this.message + "ERROR: " + w.error + "\n";
		}
		yield break;
	}

	// Token: 0x06001283 RID: 4739 RVA: 0x00077000 File Offset: 0x00075400
	private void OnGUI()
	{
		if (GameObject.Find("isMenu"))
		{
			if (this.message != string.Empty)
			{
				GUILayout.Box(this.message, new GUILayoutOption[0]);
			}
			GUI.skin = this.loginskin;
			if (this.showlogin)
			{
				GUI.Window(6, new Rect((float)(Screen.width / 2 - 185), (float)(Screen.height / 2 - 90), 370f, 231f), new GUI.WindowFunction(this.Loginwindow), "Login To ZeoWorks");
			}
			if (this.cfu)
			{
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.cfu1);
			}
			if (this.error1)
			{
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.error2);
				if (Input.GetKey(KeyCode.Space))
				{
					this.error1 = false;
					this.showlogin = true;
				}
			}
			if (this.nua)
			{
				GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.nua1);
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 220), (float)(Screen.height - 120), 120f, 30f), "Remind Me Later"))
				{
					this.nua = false;
					this.showlogin = true;
				}
				if (GUI.Button(new Rect((float)(Screen.width / 2 + 120), (float)(Screen.height - 120), 120f, 30f), "Update Now!"))
				{
					Application.OpenURL("http://zeoworks.com/home/mydownloads.php?action=view_down&did=22");
					Application.Quit();
				}
			}
		}
	}

	// Token: 0x06001284 RID: 4740 RVA: 0x000771D0 File Offset: 0x000755D0
	private IEnumerator registerFunc(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			this.message += w.text;
			CryptoPlayerPrefs.SetString("E410675", "000");
		}
		else
		{
			this.message = this.message + "ERROR: " + w.error + "\n";
			CryptoPlayerPrefs.SetString("E410675", "000");
		}
		yield break;
	}

	// Token: 0x040012C4 RID: 4804
	public GUISkin loginskin;

	// Token: 0x040012C5 RID: 4805
	public static string user = string.Empty;

	// Token: 0x040012C6 RID: 4806
	public new static string name = string.Empty;

	// Token: 0x040012C7 RID: 4807
	private string password = string.Empty;

	// Token: 0x040012C8 RID: 4808
	private string rePass = string.Empty;

	// Token: 0x040012C9 RID: 4809
	private string message = string.Empty;

	// Token: 0x040012CA RID: 4810
	private bool register;

	// Token: 0x040012CB RID: 4811
	protected string _STRING;

	// Token: 0x040012CC RID: 4812
	public Rect playbutton;

	// Token: 0x040012CD RID: 4813
	public Rect freebutton;

	// Token: 0x040012CE RID: 4814
	public bool showlogin;

	// Token: 0x040012CF RID: 4815
	public bool cfu = true;

	// Token: 0x040012D0 RID: 4816
	public bool nua;

	// Token: 0x040012D1 RID: 4817
	public bool error1;

	// Token: 0x040012D2 RID: 4818
	public Texture2D cfu1;

	// Token: 0x040012D3 RID: 4819
	public Texture2D nua1;

	// Token: 0x040012D4 RID: 4820
	public Texture2D error2;

	// Token: 0x040012D5 RID: 4821
	public string url = "http://zeoworks.com/home/E100240";

	// Token: 0x040012D6 RID: 4822
	public string result;

	// Token: 0x040012D7 RID: 4823
	public string version = "2.5a";

	// Token: 0x040012D8 RID: 4824
	public GUIText versionText;
}
