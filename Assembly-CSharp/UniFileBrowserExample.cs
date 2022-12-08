using System;
using System.Collections;
using CompilerGenerated;
using UnityEngine;

// Token: 0x020001C2 RID: 450
public class UniFileBrowserExample : MonoBehaviour
{
	// Token: 0x06000AAC RID: 2732 RVA: 0x0005D3DB File Offset: 0x0005B7DB
	private void Start()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
		{
			this.pathChar = '\\';
		}
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x0005D3FC File Offset: 0x0005B7FC
	private void OnGUI()
	{
		if (GUI.Button(new Rect(100f, 50f, 95f, 35f), "Open"))
		{
			if (UniFileBrowser.use.allowMultiSelect)
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_multiDelegate$callable1$104_29__(this.OpenFiles));
			}
			else
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.OpenFile));
			}
		}
		if (GUI.Button(new Rect(100f, 125f, 95f, 35f), "Save"))
		{
			UniFileBrowser.use.SaveFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.SaveFile));
		}
		if (GUI.Button(new Rect(100f, 200f, 95f, 35f), "Open Folder"))
		{
			UniFileBrowser.use.OpenFolderWindow(true, new __UniFileBrowser_delegate$callable0$103_24__(this.OpenFolder));
		}
		Color color = GUI.color;
		color.a = this.alpha;
		GUI.color = color;
		GUI.Label(new Rect(100f, 275f, 500f, 1000f), this.message);
		color.a = 1f;
		GUI.color = color;
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x0005D540 File Offset: 0x0005B940
	private void OpenFile(string pathToFile)
	{
		int num = pathToFile.LastIndexOf(this.pathChar);
		this.message = "You selected file: " + pathToFile.Substring(num + 1, pathToFile.Length - num - 1);
		this.Fade();
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x0005D584 File Offset: 0x0005B984
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

	// Token: 0x06000AB0 RID: 2736 RVA: 0x0005D5F4 File Offset: 0x0005B9F4
	private void SaveFile(string pathToFile)
	{
		int num = pathToFile.LastIndexOf(this.pathChar);
		this.message = "You're saving file: " + pathToFile.Substring(num + 1, pathToFile.Length - num - 1);
		this.Fade();
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x0005D637 File Offset: 0x0005BA37
	private void OpenFolder(string pathToFolder)
	{
		this.message = "You selected folder: " + pathToFolder;
		this.Fade();
	}

	// Token: 0x06000AB2 RID: 2738 RVA: 0x0005D650 File Offset: 0x0005BA50
	private void Fade()
	{
		base.StopCoroutine("FadeAlpha");
		base.StartCoroutine("FadeAlpha");
	}

	// Token: 0x06000AB3 RID: 2739 RVA: 0x0005D66C File Offset: 0x0005BA6C
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

	// Token: 0x04000C8F RID: 3215
	private string message = string.Empty;

	// Token: 0x04000C90 RID: 3216
	private float alpha = 1f;

	// Token: 0x04000C91 RID: 3217
	private char pathChar = '/';
}
