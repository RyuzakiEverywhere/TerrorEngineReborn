using System;
using System.IO;
using UnityEngine;

// Token: 0x020000D3 RID: 211
public class LoadOBJCS : MonoBehaviour
{
	// Token: 0x060003F6 RID: 1014 RVA: 0x000246C4 File Offset: 0x00022AC4
	private void Start()
	{
		this.Objpath = Application.dataPath + base.gameObject.name;
		ObjImporter objImporter = new ObjImporter();
		Mesh mesh = objImporter.ImportFile(this.Objpath);
		if (base.gameObject.GetComponent<MeshFilter>() != null)
		{
			base.gameObject.GetComponent<MeshFilter>().mesh = mesh;
		}
		else
		{
			base.gameObject.AddComponent<MeshFilter>();
			base.gameObject.GetComponent<MeshFilter>().mesh = mesh;
		}
		if (base.gameObject.GetComponent<MeshCollider>() != null)
		{
			base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
		}
		else
		{
			base.gameObject.AddComponent<MeshCollider>();
			base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
		}
		base.transform.localScale = new Vector3(0.035f, 0.035f, 0.35f);
		int num = this.Objpath.LastIndexOf(".");
		string text;
		if (num > -1)
		{
			text = this.Objpath.Remove(num);
		}
		else
		{
			text = Application.dataPath + this.Objpath;
		}
		if (File.Exists(text + ".png"))
		{
			this.isdds = false;
			text += ".png";
		}
		else if (File.Exists(text + ".jpg"))
		{
			this.isdds = false;
			text += ".jpg";
		}
		base.gameObject.AddComponent<LoadTexture>();
		base.gameObject.GetComponent<LoadTexture>().url = text;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x00024862 File Offset: 0x00022C62
	private void Update()
	{
	}

	// Token: 0x04000477 RID: 1143
	public string Objpath;

	// Token: 0x04000478 RID: 1144
	private string line;

	// Token: 0x04000479 RID: 1145
	private bool isdds;

	// Token: 0x0400047A RID: 1146
	public Texture tex;
}
