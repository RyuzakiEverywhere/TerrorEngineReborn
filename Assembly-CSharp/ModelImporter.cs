using System;
using System.Collections;
using CompilerGenerated;
using UnityEngine;

// Token: 0x020000F3 RID: 243
public class ModelImporter : MonoBehaviour
{
	// Token: 0x06000492 RID: 1170 RVA: 0x0003864F File Offset: 0x00036A4F
	private void Awake()
	{
		UnityEngine.Object.Destroy(GameObject.Find("Menu"));
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x00038660 File Offset: 0x00036A60
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x00038678 File Offset: 0x00036A78
	private void OpenFile(string pathToFile)
	{
		this.showname = true;
		this.modelpath = pathToFile;
		ObjImporter objImporter = new ObjImporter();
		base.gameObject.GetComponent<MeshFilter>().sharedMesh = objImporter.ImportFile(this.modelpath);
		base.StartCoroutine(this.newsize());
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x000386C4 File Offset: 0x00036AC4
	private IEnumerator newsize()
	{
		yield return new WaitForSeconds(0.1f);
		base.gameObject.transform.localScale = new Vector3(0.035f, 0.035f, 0.035f);
		yield break;
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x000386E0 File Offset: 0x00036AE0
	private void OnGUI()
	{
		GUI.skin = this.theskin;
		if (!this.showname)
		{
			this.thetext = "Select a .obj model from your computer to convert!";
			if (!this.hideopen && GUI.Button(new Rect(10f, (float)(Screen.height - 35), 95f, 35f), "Open"))
			{
				UniFileBrowser.use.OpenFileWindow(new __UniFileBrowser_delegate$callable0$103_24__(this.OpenFile));
				this.hideopen = true;
			}
		}
		else
		{
			this.thetext = "Enter a name for your .model, the model will be saved into the Models folder.";
			GUI.Label(new Rect(10f, (float)(Screen.height - 75), 150f, 20f), "Model Name:");
			this.thename = GUI.TextField(new Rect(10f, (float)(Screen.height - 55), 150f, 20f), this.thename);
			if (GUI.Button(new Rect(10f, (float)(Screen.height - 35), 95f, 35f), "Export"))
			{
				base.gameObject.name = this.thename;
				this.showname = false;
				GameObject gameObject = new GameObject("ExportNow");
				base.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				this.hideopen = false;
			}
		}
		GUI.Label(new Rect(10f, 10f, 500f, 30f), this.thetext);
		if (GUI.Button(new Rect((float)(Screen.width - 210), 0f, 200f, 35f), "Return To Main Menu"))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	// Token: 0x04000793 RID: 1939
	public string thename;

	// Token: 0x04000794 RID: 1940
	public bool showname;

	// Token: 0x04000795 RID: 1941
	public string modelpath;

	// Token: 0x04000796 RID: 1942
	public string pathChar;

	// Token: 0x04000797 RID: 1943
	public GUISkin theskin;

	// Token: 0x04000798 RID: 1944
	public bool hideopen;

	// Token: 0x04000799 RID: 1945
	private string thetext = "Select a .obj model from your computer to convert!";
}
