using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200024C RID: 588
public class Loading : MonoBehaviour
{
	// Token: 0x06001072 RID: 4210 RVA: 0x00068100 File Offset: 0x00066500
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) != 21)
		{
			if (GameObject.Find("Menu") != null)
			{
				GameObject.Find("Menu").GetComponent<AudioSource>().enabled = false;
			}
			if (CryptoPlayerPrefs.GetInt("Standalone", 0) == 1)
			{
				this.hidetext = true;
			}
			else if (!this.hidescreen)
			{
				this.randomnum = UnityEngine.Random.Range(1, 7);
				if (this.randomnum == 1)
				{
					this.loadingtex = this.loading1;
				}
				if (this.randomnum == 2)
				{
					this.loadingtex = this.loading2;
				}
				if (this.randomnum == 3)
				{
					this.loadingtex = this.loading3;
				}
				if (this.randomnum == 4)
				{
					this.loadingtex = this.loading4;
				}
				if (this.randomnum == 5)
				{
					this.loadingtex = this.loading5;
				}
				if (this.randomnum == 6)
				{
					this.loadingtex = this.loading6;
				}
				if (this.randomnum == 7)
				{
					this.loadingtex = this.loading7;
				}
			}
			if (!this.hidetext)
			{
				this.textelement = UnityEngine.Random.Range(1, this.texts.Length);
			}
		}
		else
		{
			this.hidescreen = true;
			this.hidetext = true;
			this.levelname = CryptoPlayerPrefs.GetString("level" + CryptoPlayerPrefs.GetInt("CurLevel", 0).ToString(), string.Empty);
			this.thepath = CryptoPlayerPrefs.GetString("path", string.Empty);
		}
		Loading.Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	// Token: 0x06001073 RID: 4211 RVA: 0x000682AC File Offset: 0x000666AC
	private IEnumerator Start()
	{
		if (CryptoPlayerPrefs.GetInt("Standalone", 0) == 1)
		{
			WWW www11 = new WWW("file:///" + Application.dataPath + "/Menu/loading_screen.png");
			yield return www11;
			this.loadingtex = www11.texture;
		}
		yield return new WaitForSeconds(0.1f);
		base.StartCoroutine(UniSave.LoadAfterLoadingScreen());
		yield break;
	}

	// Token: 0x06001074 RID: 4212 RVA: 0x000682C8 File Offset: 0x000666C8
	private void OnGUI()
	{
		if (!this.hidescreen)
		{
			GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.loadingtex);
			if (!this.hidetext)
			{
				GUI.Label(new Rect(40f, 40f, (float)(Screen.width / 2), (float)(Screen.height / 2)), this.texts[this.textelement]);
			}
		}
		else
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 100), (float)(Screen.height / 2 - 11), 200f, 22f), "Compiling Level '" + this.levelname + "'...");
		}
	}

	// Token: 0x0400110E RID: 4366
	public static Loading Instance;

	// Token: 0x0400110F RID: 4367
	public Texture2D loadingtex;

	// Token: 0x04001110 RID: 4368
	public Texture2D loading1;

	// Token: 0x04001111 RID: 4369
	public Texture2D loading2;

	// Token: 0x04001112 RID: 4370
	public Texture2D loading3;

	// Token: 0x04001113 RID: 4371
	public Texture2D loading4;

	// Token: 0x04001114 RID: 4372
	public Texture2D loading5;

	// Token: 0x04001115 RID: 4373
	public Texture2D loading6;

	// Token: 0x04001116 RID: 4374
	public Texture2D loading7;

	// Token: 0x04001117 RID: 4375
	public string[] texts;

	// Token: 0x04001118 RID: 4376
	public int textelement;

	// Token: 0x04001119 RID: 4377
	public int randomnum;

	// Token: 0x0400111A RID: 4378
	public bool hidescreen;

	// Token: 0x0400111B RID: 4379
	private bool hidetext;

	// Token: 0x0400111C RID: 4380
	private string levelname;

	// Token: 0x0400111D RID: 4381
	private string thepath;
}
