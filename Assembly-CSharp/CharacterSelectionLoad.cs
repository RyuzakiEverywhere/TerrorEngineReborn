using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class CharacterSelectionLoad : MonoBehaviour
{
	// Token: 0x06000020 RID: 32 RVA: 0x00004223 File Offset: 0x00002623
	private void Start()
	{
		this.playermodname = PlayerPrefs.GetString("Character");
		base.StartCoroutine(this.Loltart());
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00004242 File Offset: 0x00002642
	private void Update()
	{
		if (this.rotate)
		{
			base.transform.Rotate(Vector3.down * 20f * Time.deltaTime);
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00004274 File Offset: 0x00002674
	public void LoadModel()
	{
		if (this.playermodobject != null)
		{
			UnityEngine.Object.Destroy(this.curplayer.gameObject);
			UnityEngine.Object.Destroy(this.playermodobject);
		}
		Resources.UnloadUnusedAssets();
		base.StartCoroutine(this.Loltart());
	}

	// Token: 0x06000023 RID: 35 RVA: 0x000042C0 File Offset: 0x000026C0
	private IEnumerator Loltart()
	{
		this.url = Application.dataPath + "/Characters/Players/" + this.playermodname;
		WWW www = WWW.LoadFromCacheOrDownload("file://" + this.url, 1);
		yield return www;
		AssetBundle bundle = www.assetBundle;
		AssetBundleRequest request = bundle.LoadAssetAsync("playermodel", typeof(GameObject));
		yield return request;
		this.playermodobject = (request.asset as GameObject);
		this.curplayer = UnityEngine.Object.Instantiate<GameObject>(this.playermodobject, base.transform.position, base.transform.rotation);
		this.animationobj = GameObject.Find("Animations");
		GameObject.Find("model").GetComponent<Animation>().AddClip(this.animationobj.GetComponent<PlayerAnimations>().idle, "player-idle");
		GameObject.Find("model").GetComponent<Animation>().Play("player-idle");
		this.curplayer.transform.parent = base.gameObject.transform;
		if (this.curplayer.transform.Find("model/mesh"))
		{
			Material[] materials = this.curplayer.transform.Find("model/mesh").GetComponent<SkinnedMeshRenderer>().materials;
			foreach (Material material in materials)
			{
				if (!material.shader.name.Contains("Transparent"))
				{
					material.shader = Shader.Find("Legacy Shaders/Diffuse");
				}
				else
				{
					material.shader = Shader.Find("Legacy Shaders/Transparent/Cutout/Diffuse");
				}
			}
			this.curplayer.transform.Find("model/mesh").GetComponent<SkinnedMeshRenderer>().materials = materials;
		}
		bundle.Unload(false);
		yield break;
	}

	// Token: 0x04000028 RID: 40
	public string url;

	// Token: 0x04000029 RID: 41
	public string playermodname;

	// Token: 0x0400002A RID: 42
	public GameObject playermodobject;

	// Token: 0x0400002B RID: 43
	public GameObject curplayer;

	// Token: 0x0400002C RID: 44
	public GameObject animationobj;

	// Token: 0x0400002D RID: 45
	public bool rotate;
}
