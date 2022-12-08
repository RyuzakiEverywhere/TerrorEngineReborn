using System;
using System.Collections;
using CompilerGenerated;
using UnityEngine;

// Token: 0x020001C1 RID: 449
public class CharacterSelectionMenu : MonoBehaviour
{
	// Token: 0x06000AA1 RID: 2721 RVA: 0x0005CF40 File Offset: 0x0005B340
	private void OnEnable()
	{
		UniFileBrowser component = base.gameObject.GetComponent<UniFileBrowser>();
		base.gameObject.GetComponent<UniFileBrowser>().filePath = Application.dataPath + "/Characters/Players/";
		base.gameObject.GetComponent<UniFileBrowser>().defaultFileWindowRect = new Rect(10f, 50f, 200f, (float)(Screen.height - 150));
		if (PlayerPrefs.GetString("Character") == null || PlayerPrefs.GetString("Character") == string.Empty)
		{
			PlayerPrefs.SetString("Character", "Default_Male.player");
		}
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x0005CFDF File Offset: 0x0005B3DF
	private void Start()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
		{
			this.pathChar = '\\';
		}
	}

	// Token: 0x06000AA3 RID: 2723 RVA: 0x0005D000 File Offset: 0x0005B400
	private void Update()
	{
		base.gameObject.GetComponent<UniFileBrowser>().filePath = Application.dataPath + "/Characters/Players/";
		base.gameObject.GetComponent<UniFileBrowser>().enabled = true;
		if (GameObject.Find("Bip01 Head"))
		{
			Vector3 position = GameObject.Find("Bip01 Head").transform.position;
			this.csCam.position = new Vector3(position.x, position.y + 0.1f, position.z - 0.8f);
		}
		if (!this.showOnce)
		{
			UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.OpenFile));
			this.showOnce = true;
		}
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x0005D0C0 File Offset: 0x0005B4C0
	private void OnGUI()
	{
		GUI.skin = this.titleskin;
		if (GUI.Button(new Rect((float)(Screen.width - 170), (float)(Screen.height - 25), 170f, 25f), "Back To Main Menu"))
		{
			this.maincam.active = true;
			this.menu.active = true;
			this.menu.GetComponent<TestGUI>().enabled = true;
			base.gameObject.active = false;
		}
	}

	// Token: 0x06000AA5 RID: 2725 RVA: 0x0005D140 File Offset: 0x0005B540
	private void OpenFile(string pathToFile)
	{
		int num = pathToFile.LastIndexOf(this.pathChar);
		PlayerPrefs.SetString("Character", base.gameObject.GetComponent<UniFileBrowser>().fileName);
		this.spawnpoint.playermodname = base.gameObject.GetComponent<UniFileBrowser>().fileName;
		this.spawnpoint.LoadModel();
		this.Fade();
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x0005D1A0 File Offset: 0x0005B5A0
	private void OpenFiles(string[] pathsToFiles)
	{
		this.message = "You selected these files:\n";
		for (int i = 0; i < pathsToFiles.Length; i++)
		{
			int num = pathsToFiles[i].LastIndexOf(this.pathChar);
			this.message = this.message + pathsToFiles[i].Substring(num + 1, pathsToFiles[i].Length - num - 1) + "\n";
		}
		this.Fade();
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x0005D210 File Offset: 0x0005B610
	private void SaveFile(string pathToFile)
	{
		int num = pathToFile.LastIndexOf(this.pathChar);
		this.message = "You're saving file: " + pathToFile.Substring(num + 1, pathToFile.Length - num - 1);
		this.Fade();
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x0005D253 File Offset: 0x0005B653
	private void OpenFolder(string pathToFolder)
	{
		this.message = "You selected folder: " + pathToFolder;
		this.Fade();
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x0005D26C File Offset: 0x0005B66C
	private void Fade()
	{
		base.StopCoroutine("FadeAlpha");
		base.StartCoroutine("FadeAlpha");
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x0005D288 File Offset: 0x0005B688
	private IEnumerator FadeAlpha()
	{
		this.alpha = 1f;
		yield return new WaitForSeconds(5f);
		this.alpha = 1f;
		while (this.alpha > 0f)
		{
			yield return null;
			this.alpha -= Time.deltaTime / 4f;
		}
		this.message = string.Empty;
		yield break;
	}

	// Token: 0x04000C86 RID: 3206
	private string message = string.Empty;

	// Token: 0x04000C87 RID: 3207
	private float alpha = 1f;

	// Token: 0x04000C88 RID: 3208
	private char pathChar = '/';

	// Token: 0x04000C89 RID: 3209
	public GUISkin titleskin;

	// Token: 0x04000C8A RID: 3210
	public GameObject maincam;

	// Token: 0x04000C8B RID: 3211
	public GameObject menu;

	// Token: 0x04000C8C RID: 3212
	public CharacterSelectionLoad spawnpoint;

	// Token: 0x04000C8D RID: 3213
	public Transform csCam;

	// Token: 0x04000C8E RID: 3214
	public bool showOnce;
}
