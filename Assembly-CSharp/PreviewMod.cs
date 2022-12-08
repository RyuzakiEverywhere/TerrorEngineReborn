using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200003E RID: 62
public class PreviewMod : MonoBehaviour
{
	// Token: 0x06000112 RID: 274 RVA: 0x0000F8E4 File Offset: 0x0000DCE4
	private void Update()
	{
		this.modname = base.gameObject.GetComponent<ModProperties>().modname;
		if (this.modname != null && !this.hasname && !this.hasmod)
		{
			base.StartCoroutine(this.Loltart());
		}
		if (this.des)
		{
			Resources.UnloadUnusedAssets();
			UnityEngine.Object.Destroy(this.modingame.gameObject);
			UnityEngine.Object.Destroy(this);
		}
		if (this.modingame != null)
		{
			this.modingame.transform.position = base.gameObject.transform.position;
			this.modingame.transform.localScale = base.gameObject.transform.localScale;
			this.modingame.transform.localEulerAngles = base.gameObject.transform.localEulerAngles;
		}
	}

	// Token: 0x06000113 RID: 275 RVA: 0x0000F9D0 File Offset: 0x0000DDD0
	private IEnumerator Loltart()
	{
		this.hasname = true;
		this.url = Application.dataPath + "/Mods/" + this.modname + ".mod";
		Time.timeScale = 0f;
		this.www = WWW.LoadFromCacheOrDownload("file://" + this.url, 1);
		yield return this.www;
		Time.timeScale = 1f;
		AssetBundle bundle = this.www.assetBundle;
		this.modobject = bundle.LoadAsset("mod", typeof(GameObject));
		this.modingame = (UnityEngine.Object.Instantiate(this.modobject, base.transform.position, base.transform.rotation) as GameObject);
		this.hasmod = true;
		this.modingame.transform.localScale = base.gameObject.transform.localScale;
		this.modingame.transform.parent = base.transform;
		MeshRenderer[] mr = this.modingame.gameObject.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in mr)
		{
			Material[] materials = meshRenderer.materials;
			foreach (Material material in materials)
			{
				material.shader = Shader.Find("Legacy Shaders/Transparent/Cutout/Diffuse");
			}
			meshRenderer.materials = materials;
			meshRenderer.gameObject.layer = 18;
		}
		SkinnedMeshRenderer[] smr = this.modingame.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in smr)
		{
			Material[] materials2 = skinnedMeshRenderer.materials;
			foreach (Material material2 in materials2)
			{
				material2.shader = Shader.Find("Legacy Shaders/Transparent/Cutout/Diffuse");
			}
			skinnedMeshRenderer.materials = materials2;
			skinnedMeshRenderer.gameObject.layer = 18;
		}
		ParticleRenderer[] pr = this.modingame.gameObject.GetComponentsInChildren<ParticleRenderer>();
		foreach (ParticleRenderer particleRenderer in pr)
		{
			Material[] materials3 = particleRenderer.materials;
			foreach (Material material3 in materials3)
			{
				material3.shader = Shader.Find("Particles/Additive");
			}
			particleRenderer.materials = materials3;
		}
		Terrain[] hinges = UnityEngine.Object.FindObjectsOfType(typeof(Terrain)) as Terrain[];
		foreach (Terrain terrain in hinges)
		{
			terrain.materialTemplate = (Resources.Load("TerrainMat") as Material);
		}
		bundle.Unload(false);
		MeshCollider[] hinges2 = UnityEngine.Object.FindObjectsOfType(typeof(MeshCollider)) as MeshCollider[];
		foreach (MeshCollider meshCollider in hinges2)
		{
			meshCollider.sharedMesh = null;
			meshCollider.sharedMesh = meshCollider.gameObject.GetComponent<MeshFilter>().sharedMesh;
		}
		yield break;
	}

	// Token: 0x040001A0 RID: 416
	public string url;

	// Token: 0x040001A1 RID: 417
	public string modname;

	// Token: 0x040001A2 RID: 418
	public UnityEngine.Object modobject;

	// Token: 0x040001A3 RID: 419
	public bool hasmod;

	// Token: 0x040001A4 RID: 420
	public GameObject modingame;

	// Token: 0x040001A5 RID: 421
	public bool hasname;

	// Token: 0x040001A6 RID: 422
	public bool des;

	// Token: 0x040001A7 RID: 423
	public WWW www;
}
