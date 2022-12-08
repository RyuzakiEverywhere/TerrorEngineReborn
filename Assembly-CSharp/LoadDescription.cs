using System;
using System.Collections;
using System.IO;
using UnityEngine;

// Token: 0x0200025B RID: 603
public class LoadDescription : MonoBehaviour
{
	// Token: 0x060010F1 RID: 4337 RVA: 0x0006B580 File Offset: 0x00069980
	private void LoadDes()
	{
		StreamReader streamReader = new StreamReader(this.fileName + this.newstory + ".txt");
		this.description = streamReader.ReadToEnd();
		base.gameObject.GetComponent<TestGUI>().description = this.description;
		streamReader.Close();
	}

	// Token: 0x060010F2 RID: 4338 RVA: 0x0006B5D4 File Offset: 0x000699D4
	private void Update()
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
		this.fileName = string.Concat(new object[]
		{
			directoryInfo.Parent.ToString(),
			Path.DirectorySeparatorChar,
			"Levels",
			Path.DirectorySeparatorChar
		});
		if (this.curstory != this.newstory)
		{
			if (File.Exists(this.fileName + this.newstory + ".txt"))
			{
				this.LoadDes();
			}
			else
			{
				this.description = "No Description Available";
				base.gameObject.GetComponent<TestGUI>().description = this.description;
			}
			if (File.Exists(this.fileName + this.newstory + ".png"))
			{
				base.StartCoroutine(this.LoadImage());
			}
			else
			{
				this.storyimage = this.NA;
				base.gameObject.GetComponent<TestGUI>().storyimage = this.storyimage;
			}
		}
		this.curstory = this.newstory;
	}

	// Token: 0x060010F3 RID: 4339 RVA: 0x0006B6F0 File Offset: 0x00069AF0
	private IEnumerator LoadImage()
	{
		Resources.UnloadUnusedAssets();
		WWW www = new WWW("file://" + this.fileName + this.newstory + ".png");
		yield return www;
		this.storyimage = www.texture;
		base.gameObject.GetComponent<TestGUI>().storyimage = this.storyimage;
		yield break;
	}

	// Token: 0x0400117F RID: 4479
	public string fileName;

	// Token: 0x04001180 RID: 4480
	public string description;

	// Token: 0x04001181 RID: 4481
	public string curstory;

	// Token: 0x04001182 RID: 4482
	public string newstory;

	// Token: 0x04001183 RID: 4483
	public Texture2D storyimage;

	// Token: 0x04001184 RID: 4484
	public Texture2D NA;
}
