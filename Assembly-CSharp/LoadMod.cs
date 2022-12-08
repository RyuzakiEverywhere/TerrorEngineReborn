using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000029 RID: 41
public class LoadMod : MonoBehaviour
{
	// Token: 0x060000AD RID: 173 RVA: 0x0000B7F4 File Offset: 0x00009BF4
	private void Update()
	{
		this.modname = base.gameObject.GetComponent<ModProperties>().modname;
		if (this.modname != null && !this.hasname && !this.hasloadedmod)
		{
			base.StartCoroutine(this.Loltart());
		}
	}

	// Token: 0x060000AE RID: 174 RVA: 0x0000B848 File Offset: 0x00009C48
	private IEnumerator Loltart()
	{
		this.hasname = true;
		this.url = Application.dataPath + "/Mods/" + this.modname + ".mod";
		WWW www = WWW.LoadFromCacheOrDownload("file://" + this.url, 1);
		yield return www;
		AssetBundle bundle = www.assetBundle;
		this.modobject = (bundle.LoadAsset("mod", typeof(GameObject)) as GameObject);
		this.modingame = UnityEngine.Object.Instantiate<GameObject>(this.modobject, base.transform.position, base.transform.rotation);
		this.hasloadedmod = true;
		this.modingame.transform.localScale = base.gameObject.transform.localScale;
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

	// Token: 0x040000FB RID: 251
	public string url;

	// Token: 0x040000FC RID: 252
	public string modname;

	// Token: 0x040000FD RID: 253
	public GameObject modobject;

	// Token: 0x040000FE RID: 254
	public bool hasloadedmod;

	// Token: 0x040000FF RID: 255
	public GameObject modingame;

	// Token: 0x04000100 RID: 256
	public bool hasname;
}
