using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000162 RID: 354
public class PlayerHUD : MonoBehaviour
{
	// Token: 0x06000870 RID: 2160 RVA: 0x0004E082 File Offset: 0x0004C482
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("hud", 0) == 2)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x0004E09C File Offset: 0x0004C49C
	private IEnumerator Start()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) != 4 && CryptoPlayerPrefs.GetInt("Mode", 0) != 5)
		{
			yield return new WaitForSeconds(1f);
			if (!this.ispnpc)
			{
				this.url = GameObject.Find("Events/Player Start Point").GetComponent<PlayerProperties>().hud;
			}
			else if (GameObject.Find("Events/Monster Start Point") != null)
			{
				this.url = GameObject.Find("Events/Monster Start Point").GetComponent<MonsterProperties>().hud;
			}
			WWW www = new WWW("file:///" + Application.dataPath + "/Images/HUD/" + this.url);
			yield return www;
			this.tex = www.texture;
			base.GetComponent<GUITexture>().texture = this.tex;
		}
		yield break;
	}

	// Token: 0x06000872 RID: 2162 RVA: 0x0004E0B7 File Offset: 0x0004C4B7
	private void Update()
	{
	}

	// Token: 0x04000A80 RID: 2688
	public string url;

	// Token: 0x04000A81 RID: 2689
	public bool ispnpc;

	// Token: 0x04000A82 RID: 2690
	public Texture2D tex;
}
