using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000EA RID: 234
public class ModelMesh : MonoBehaviour
{
	// Token: 0x06000462 RID: 1122 RVA: 0x000329F8 File Offset: 0x00030DF8
	public void Start()
	{
		if (base.name.Contains("idwall") || base.name.Contains("odwall"))
		{
			base.StartCoroutine(this.WallScale());
		}
		if (base.name.Contains("idfloor") || base.name.Contains("odfloor"))
		{
			base.StartCoroutine(this.FloorScale());
		}
		if (base.GetComponent<MeshFilter>() == null)
		{
			this.obj = (Resources.Load(base.gameObject.name.ToString()) as GameObject);
			base.gameObject.AddComponent<MeshFilter>();
			base.GetComponent<MeshFilter>().sharedMesh = this.obj.GetComponent<MeshFilter>().sharedMesh;
			base.gameObject.GetComponent<Renderer>().sharedMaterials = this.obj.GetComponent<Renderer>().sharedMaterials;
			if (base.gameObject.GetComponent<ModelProperties>() != null)
			{
				this.hasmesh = true;
			}
			if (this.hasmesh && base.gameObject.GetComponent<MeshCollider>() == null)
			{
				base.gameObject.AddComponent<MeshCollider>();
			}
			if (base.gameObject.GetComponent<MeshCollider>() != null && base.GetComponent<WallProperties>() == null)
			{
				base.gameObject.GetComponent<MeshCollider>().sharedMesh = this.obj.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			if (base.GetComponent<WallProperties>() != null)
			{
				if (base.GetComponent<WallProperties>().iswall)
				{
					this.hasmesh = true;
					base.GetComponent<MeshFilter>().mesh = (Resources.Load("cube", typeof(Mesh)) as Mesh);
				}
				if (base.GetComponent<WallProperties>().isdoor)
				{
					this.hasmesh = true;
					base.GetComponent<MeshFilter>().mesh = (Resources.Load("doorframe", typeof(Mesh)) as Mesh);
					UnityEngine.Object.Destroy(base.GetComponent<BoxCollider>());
					base.gameObject.AddComponent<MeshCollider>();
					base.GetComponent<MeshCollider>().sharedMesh = base.GetComponent<MeshFilter>().mesh;
				}
				if (base.GetComponent<WallProperties>().iswindow)
				{
					this.hasmesh = true;
					base.GetComponent<MeshFilter>().mesh = (Resources.Load("window", typeof(Mesh)) as Mesh);
					base.GetComponent<MeshCollider>().sharedMesh = base.GetComponent<MeshFilter>().mesh;
				}
				if (base.GetComponent<WallProperties>().hasct)
				{
					string ctpath = base.GetComponent<WallProperties>().ctpath;
					WWW www = new WWW(string.Concat(new string[]
					{
						"file://",
						Application.persistentDataPath,
						"/Stories/",
						PlayerPrefs.GetString("storyname"),
						"/Textures/",
						ctpath
					}));
					base.GetComponent<Renderer>().material.mainTexture = www.texture;
				}
			}
		}
		if (GameObject.Find("Play(Clone)"))
		{
			UnityEngine.Object.Destroy(this, 2f);
		}
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x00032D1C File Offset: 0x0003111C
	private IEnumerator FloorScale()
	{
		yield return new WaitForSeconds(1f);
		Vector3 thescale = base.transform.localScale;
		float correctx = thescale.x / 2f;
		float correcty = thescale.z / 2f;
		base.GetComponent<Renderer>().material.mainTextureScale = new Vector2(correctx, correcty);
		yield break;
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x00032D38 File Offset: 0x00031138
	private IEnumerator WallScale()
	{
		yield return new WaitForSeconds(1f);
		Vector3 thescale = base.transform.localScale;
		float correctx = thescale.x / 4f;
		float correcty = thescale.y / 4f;
		base.GetComponent<Renderer>().material.mainTextureScale = new Vector2(correctx, correcty);
		yield break;
	}

	// Token: 0x040006A4 RID: 1700
	public bool hasmesh;

	// Token: 0x040006A5 RID: 1701
	private GameObject obj;

	// Token: 0x040006A6 RID: 1702
	private Material[] myMaterials;

	// Token: 0x040006A7 RID: 1703
	public Material[] myMaterialsres;

	// Token: 0x040006A8 RID: 1704
	public bool isScenery;
}
