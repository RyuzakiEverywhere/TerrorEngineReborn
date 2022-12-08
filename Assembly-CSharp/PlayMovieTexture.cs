using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x020000B9 RID: 185
[AddComponentMenu("Infinity Code/Play MovieTexture")]
public class PlayMovieTexture : MonoBehaviour
{
	// Token: 0x06000360 RID: 864 RVA: 0x00020014 File Offset: 0x0001E414
	public void PauseMovies()
	{
		PlayMovieTexture.PauseMovies(this.movieTextures);
	}

	// Token: 0x06000361 RID: 865 RVA: 0x00020024 File Offset: 0x0001E424
	public MovieTexture[] StartMovies()
	{
		List<MovieTexture> list = new List<MovieTexture>();
		foreach (MovieTexture movieTexture in this.movieTextures)
		{
			if (movieTexture != null)
			{
				list.Add(movieTexture);
				movieTexture.loop = this.loop;
				movieTexture.Play();
				if (!this.loop && this.afterStop != PlayMovieTextureStopEnum.none)
				{
					base.StartCoroutine(this.WaitStopMovie(movieTexture));
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06000362 RID: 866 RVA: 0x000200A5 File Offset: 0x0001E4A5
	public void StopMovies()
	{
		PlayMovieTexture.StopMovies(this.movieTextures);
	}

	// Token: 0x06000363 RID: 867 RVA: 0x000200B4 File Offset: 0x0001E4B4
	public static MovieTexture[] GetMovieTextures()
	{
		List<MovieTexture> list = new List<MovieTexture>();
		GUITexture[] source = (GUITexture[])UnityEngine.Object.FindSceneObjectsOfType(typeof(GUITexture));
		Renderer[] array = (Renderer[])UnityEngine.Object.FindSceneObjectsOfType(typeof(Renderer));
		list.AddRange(from t in source
		where t.texture is MovieTexture
		select (MovieTexture)t.texture);
		foreach (Renderer renderer in array)
		{
			for (int j = 0; j < renderer.sharedMaterials.Length; j++)
			{
				Material material = renderer.sharedMaterials[j];
				if (material != null)
				{
					for (int k = 0; k < PlayMovieTexture.aviableTextureNames.Length; k++)
					{
						if (material.HasProperty(PlayMovieTexture.aviableTextureNames[k]))
						{
							Texture texture = material.GetTexture(PlayMovieTexture.aviableTextureNames[k]);
							if (texture && texture is MovieTexture)
							{
								list.Add((MovieTexture)texture);
							}
						}
					}
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06000364 RID: 868 RVA: 0x00020200 File Offset: 0x0001E600
	public static MovieTexture[] GetMovieTextures(GameObject target)
	{
		List<MovieTexture> list = new List<MovieTexture>();
		if (target.GetComponent<Renderer>() != null)
		{
			for (int i = 0; i < target.GetComponent<Renderer>().sharedMaterials.Length; i++)
			{
				Material material = target.GetComponent<Renderer>().sharedMaterials[i];
				if (material != null)
				{
					for (int j = 0; j < PlayMovieTexture.aviableTextureNames.Length; j++)
					{
						if (material.HasProperty(PlayMovieTexture.aviableTextureNames[j]))
						{
							Texture texture = material.GetTexture(PlayMovieTexture.aviableTextureNames[j]);
							if (texture && texture is MovieTexture)
							{
								list.Add((MovieTexture)texture);
							}
						}
					}
				}
			}
		}
		if (target.GetComponent<GUITexture>() != null && target.GetComponent<GUITexture>().texture is MovieTexture)
		{
			list.Add((MovieTexture)target.GetComponent<GUITexture>().texture);
		}
		return list.ToArray();
	}

	// Token: 0x06000365 RID: 869 RVA: 0x000202FC File Offset: 0x0001E6FC
	public static void PauseAllMovies()
	{
		PlayMovieTexture.PauseMovies(PlayMovieTexture.GetMovieTextures());
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00020308 File Offset: 0x0001E708
	public static void PauseMovie(MovieTexture mt)
	{
		mt.Pause();
	}

	// Token: 0x06000367 RID: 871 RVA: 0x00020310 File Offset: 0x0001E710
	public static void PauseMovies(MovieTexture[] mts)
	{
		foreach (MovieTexture movieTexture in mts)
		{
			movieTexture.Pause();
		}
	}

	// Token: 0x06000368 RID: 872 RVA: 0x0002033D File Offset: 0x0001E73D
	public static void PauseMovies(GameObject target)
	{
		PlayMovieTexture.PauseMovies(PlayMovieTexture.GetMovieTextures(target));
	}

	// Token: 0x06000369 RID: 873 RVA: 0x0002034A File Offset: 0x0001E74A
	public static MovieTexture[] StartAllMovies()
	{
		return PlayMovieTexture.StartMovies(PlayMovieTexture.GetMovieTextures());
	}

	// Token: 0x0600036A RID: 874 RVA: 0x00020356 File Offset: 0x0001E756
	public static MovieTexture[] StartAllMovies(bool loop)
	{
		return PlayMovieTexture.StartMovies(PlayMovieTexture.GetMovieTextures(), loop);
	}

	// Token: 0x0600036B RID: 875 RVA: 0x00020363 File Offset: 0x0001E763
	public static MovieTexture[] StartAllMovies(float delay)
	{
		return PlayMovieTexture.StartMovies(PlayMovieTexture.GetMovieTextures(), delay);
	}

	// Token: 0x0600036C RID: 876 RVA: 0x00020370 File Offset: 0x0001E770
	public static MovieTexture[] StartAllMovies(float delay, bool loop)
	{
		return PlayMovieTexture.StartMovies(PlayMovieTexture.GetMovieTextures(), delay, loop);
	}

	// Token: 0x0600036D RID: 877 RVA: 0x0002037E File Offset: 0x0001E77E
	public static MovieTexture StartMovie(MovieTexture mt)
	{
		mt.Play();
		return mt;
	}

	// Token: 0x0600036E RID: 878 RVA: 0x00020387 File Offset: 0x0001E787
	public static MovieTexture StartMovie(MovieTexture mt, bool loop)
	{
		mt.loop = loop;
		return PlayMovieTexture.StartMovie(mt);
	}

	// Token: 0x0600036F RID: 879 RVA: 0x00020398 File Offset: 0x0001E798
	public static MovieTexture StartMovie(MovieTexture mt, float delay)
	{
		GameObject gameObject = new GameObject("_PlayMovieTextureIEnumenator");
		PlayMovieTexture playMovieTexture = gameObject.AddComponent<PlayMovieTexture>();
		playMovieTexture.StartCoroutine(playMovieTexture._StartMovie(mt, delay));
		return mt;
	}

	// Token: 0x06000370 RID: 880 RVA: 0x000203C7 File Offset: 0x0001E7C7
	public static MovieTexture StartMovie(MovieTexture mt, float delay, bool loop)
	{
		mt.loop = loop;
		return PlayMovieTexture.StartMovie(mt, delay);
	}

	// Token: 0x06000371 RID: 881 RVA: 0x000203D8 File Offset: 0x0001E7D8
	public static MovieTexture[] StartMovies(MovieTexture[] mts)
	{
		foreach (MovieTexture mt in mts)
		{
			PlayMovieTexture.StartMovie(mt);
		}
		return mts;
	}

	// Token: 0x06000372 RID: 882 RVA: 0x00020408 File Offset: 0x0001E808
	public static MovieTexture[] StartMovies(MovieTexture[] mts, bool loop)
	{
		foreach (MovieTexture movieTexture in mts)
		{
			movieTexture.loop = loop;
		}
		return PlayMovieTexture.StartMovies(mts);
	}

	// Token: 0x06000373 RID: 883 RVA: 0x0002043C File Offset: 0x0001E83C
	public static MovieTexture[] StartMovies(MovieTexture[] mts, float delay)
	{
		GameObject gameObject = new GameObject("_PlayMovieTextureIEnumenator");
		PlayMovieTexture playMovieTexture = gameObject.AddComponent<PlayMovieTexture>();
		playMovieTexture.StartCoroutine(playMovieTexture._StartMovies(mts, delay));
		return mts;
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0002046C File Offset: 0x0001E86C
	public static MovieTexture[] StartMovies(MovieTexture[] mts, float delay, bool loop)
	{
		foreach (MovieTexture movieTexture in mts)
		{
			movieTexture.loop = loop;
		}
		return PlayMovieTexture.StartMovies(mts, delay);
	}

	// Token: 0x06000375 RID: 885 RVA: 0x000204A4 File Offset: 0x0001E8A4
	public static MovieTexture[] StartMovies(GameObject target)
	{
		MovieTexture[] mts = PlayMovieTexture.GetMovieTextures(target);
		return PlayMovieTexture.StartMovies(mts);
	}

	// Token: 0x06000376 RID: 886 RVA: 0x000204C0 File Offset: 0x0001E8C0
	public static MovieTexture[] StartMovies(GameObject target, bool loop)
	{
		MovieTexture[] array = PlayMovieTexture.GetMovieTextures(target);
		foreach (MovieTexture movieTexture in array)
		{
			movieTexture.loop = loop;
		}
		return PlayMovieTexture.StartMovies(array);
	}

	// Token: 0x06000377 RID: 887 RVA: 0x000204FC File Offset: 0x0001E8FC
	public static MovieTexture[] StartMovies(GameObject target, float delay)
	{
		MovieTexture[] mts = PlayMovieTexture.GetMovieTextures(target);
		return PlayMovieTexture.StartMovies(mts, delay);
	}

	// Token: 0x06000378 RID: 888 RVA: 0x00020518 File Offset: 0x0001E918
	public static MovieTexture[] StartMovies(GameObject target, float delay, bool loop)
	{
		MovieTexture[] array = PlayMovieTexture.GetMovieTextures(target);
		foreach (MovieTexture movieTexture in array)
		{
			movieTexture.loop = loop;
		}
		return PlayMovieTexture.StartMovies(array, delay);
	}

	// Token: 0x06000379 RID: 889 RVA: 0x00020554 File Offset: 0x0001E954
	public static void StopAllMovies()
	{
		PlayMovieTexture.StopMovies(PlayMovieTexture.GetMovieTextures());
	}

	// Token: 0x0600037A RID: 890 RVA: 0x00020560 File Offset: 0x0001E960
	public static void StopMovie(MovieTexture mt)
	{
		if (mt != null)
		{
			mt.Stop();
		}
	}

	// Token: 0x0600037B RID: 891 RVA: 0x00020574 File Offset: 0x0001E974
	public static void StopMovies(MovieTexture[] mts)
	{
		foreach (MovieTexture mt in mts)
		{
			PlayMovieTexture.StopMovie(mt);
		}
	}

	// Token: 0x0600037C RID: 892 RVA: 0x000205A4 File Offset: 0x0001E9A4
	public static void StopMovies(GameObject target)
	{
		foreach (MovieTexture mt in PlayMovieTexture.GetMovieTextures(target))
		{
			PlayMovieTexture.StopMovie(mt);
		}
	}

	// Token: 0x0600037D RID: 893 RVA: 0x000205D6 File Offset: 0x0001E9D6
	private void Start()
	{
		if (this.movieTextures == null)
		{
			return;
		}
		if (this.autostart == PlayMovieTextureAutostartEnum.atStart)
		{
			this.StartMovies();
		}
		else if (this.autostart == PlayMovieTextureAutostartEnum.delayed)
		{
			base.StartCoroutine(this.WaitStartMovies());
		}
	}

	// Token: 0x0600037E RID: 894 RVA: 0x00020614 File Offset: 0x0001EA14
	private IEnumerator WaitStartMovies()
	{
		yield return new WaitForSeconds(this.delay);
		this.StartMovies();
		yield break;
	}

	// Token: 0x0600037F RID: 895 RVA: 0x00020630 File Offset: 0x0001EA30
	private IEnumerator WaitStopMovie(MovieTexture mt)
	{
		do
		{
			yield return new WaitForSeconds(0.1f);
		}
		while (mt.isPlaying);
		if (this.afterStop == PlayMovieTextureStopEnum.disableGameobject)
		{
			base.gameObject.GetComponent<GUITexture>().enabled = false;
		}
		else if (this.afterStop == PlayMovieTextureStopEnum.destroyGameobject)
		{
			UnityEngine.Object.Destroy(this);
		}
		else if (this.afterStop == PlayMovieTextureStopEnum.customAction)
		{
			if (this.customActionTarget == null)
			{
				this.customActionTarget = base.gameObject;
			}
			if (this.customActionMethod != string.Empty)
			{
				this.customActionTarget.SendMessage(this.customActionMethod);
			}
		}
		yield break;
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00020654 File Offset: 0x0001EA54
	private IEnumerator _StartMovie(MovieTexture mt, float delay)
	{
		yield return new WaitForSeconds(delay);
		PlayMovieTexture.StartMovie(mt);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00020680 File Offset: 0x0001EA80
	private IEnumerator _StartMovies(MovieTexture[] mts, float delay)
	{
		yield return new WaitForSeconds(delay);
		PlayMovieTexture.StartMovies(mts);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x040003C5 RID: 965
	public PlayMovieTextureStopEnum afterStop = PlayMovieTextureStopEnum.disableGameobject;

	// Token: 0x040003C6 RID: 966
	public PlayMovieTextureAutostartEnum autostart;

	// Token: 0x040003C7 RID: 967
	public string customActionMethod;

	// Token: 0x040003C8 RID: 968
	public GameObject customActionTarget;

	// Token: 0x040003C9 RID: 969
	public float delay;

	// Token: 0x040003CA RID: 970
	public int flag = -1;

	// Token: 0x040003CB RID: 971
	public bool loop;

	// Token: 0x040003CC RID: 972
	public MovieTexture[] movieTextures;

	// Token: 0x040003CD RID: 973
	public PlayMovieTextureTarget target = PlayMovieTextureTarget.scene;

	// Token: 0x040003CE RID: 974
	public GameObject targetObject;

	// Token: 0x040003CF RID: 975
	public static readonly string[] aviableTextureNames = new string[]
	{
		"_MainTex",
		"_BumpMap",
		"_ParallaxMap",
		"_DecalTex",
		"_Illum",
		"_LightMap",
		"_Mask"
	};

	// Token: 0x040003D0 RID: 976
	public static readonly string[] aviableTextureTitles = new string[]
	{
		"Base Texture",
		"Normal Map",
		"Parallax Map",
		"Decal Texture",
		"Illumin",
		"Light Map",
		"Culling Mask"
	};
}
