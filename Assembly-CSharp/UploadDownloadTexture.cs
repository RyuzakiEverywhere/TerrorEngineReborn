using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class UploadDownloadTexture : MonoBehaviour
{
	// Token: 0x060002C3 RID: 707 RVA: 0x0001BCF8 File Offset: 0x0001A0F8
	private void Start()
	{
		if (this.mode == UploadDownloadTexture.Mode.Upload)
		{
			Texture2D texture = this.GetTexture();
			if (texture == null)
			{
				Debug.LogError("There is no texture attached to this object.");
			}
			else
			{
				base.StartCoroutine(this.Upload(texture));
			}
		}
		else
		{
			base.StartCoroutine(this.Download());
		}
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x0001BD54 File Offset: 0x0001A154
	private IEnumerator Upload(Texture2D texture)
	{
		ES2Web web = new ES2Web(this.url, this.CreateSettings());
		yield return base.StartCoroutine(web.Upload<Texture2D>(texture));
		if (web.isError)
		{
			Debug.LogError(web.errorCode + ":" + web.error);
		}
		else
		{
			Debug.Log("Uploaded Successfully. Reload scene to load texture into blank object.");
		}
		yield break;
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0001BD78 File Offset: 0x0001A178
	private IEnumerator Download()
	{
		ES2Web web = new ES2Web(this.url, this.CreateSettings());
		yield return base.StartCoroutine(web.Download());
		if (!web.isError)
		{
			this.SetTexture(web.Load<Texture2D>(this.textureTag));
			yield return base.StartCoroutine(this.Delete());
			Debug.Log("Texture successfully downloaded and applied to blank object.");
			yield break;
		}
		if (web.errorCode == "05")
		{
			yield break;
		}
		Debug.LogError(web.errorCode + ":" + web.error);
		yield break;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x0001BD94 File Offset: 0x0001A194
	private IEnumerator Delete()
	{
		ES2Web web = new ES2Web(this.url, this.CreateSettings());
		yield return base.StartCoroutine(web.Delete());
		if (web.isError)
		{
			Debug.LogError(web.errorCode + ":" + web.error);
		}
		yield break;
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x0001BDB0 File Offset: 0x0001A1B0
	private ES2Settings CreateSettings()
	{
		return new ES2Settings
		{
			webFilename = this.filename,
			tag = this.textureTag,
			webUsername = this.webUsername,
			webPassword = this.webPassword
		};
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0001BDF4 File Offset: 0x0001A1F4
	private Texture2D GetTexture()
	{
		Renderer component = base.GetComponent<Renderer>();
		if (component.material != null && component.material.mainTexture != null)
		{
			return component.material.mainTexture as Texture2D;
		}
		return null;
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x0001BE44 File Offset: 0x0001A244
	private void SetTexture(Texture2D texture)
	{
		Renderer component = base.GetComponent<Renderer>();
		if (component.material != null)
		{
			component.material.mainTexture = texture;
		}
		else
		{
			Debug.LogError("There is no material attached to this object.");
		}
	}

	// Token: 0x04000337 RID: 823
	public UploadDownloadTexture.Mode mode;

	// Token: 0x04000338 RID: 824
	public string url = "http://www.server.com/ES2.php";

	// Token: 0x04000339 RID: 825
	public string filename = "textureFile.txt";

	// Token: 0x0400033A RID: 826
	public string textureTag = "textureTag";

	// Token: 0x0400033B RID: 827
	public string webUsername = "ES2";

	// Token: 0x0400033C RID: 828
	public string webPassword = "65w84e4p994z3Oq";

	// Token: 0x0200009D RID: 157
	public enum Mode
	{
		// Token: 0x0400033E RID: 830
		Upload,
		// Token: 0x0400033F RID: 831
		Download
	}
}
