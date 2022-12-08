using System;
using UnityEngine;

// Token: 0x02000269 RID: 617
public class HitManager : MonoBehaviour
{
	// Token: 0x060011B2 RID: 4530 RVA: 0x00072E88 File Offset: 0x00071288
	private void Start()
	{
		this.myTextMesh = base.GetComponentInChildren<TextMesh>();
		if (!CryptoPlayerPrefs.HasKey(this.getPrefKey()))
		{
			this.SetHits(0);
		}
		else
		{
			this.SetHits(CryptoPlayerPrefs.GetInt(this.getPrefKey(), 0));
		}
	}

	// Token: 0x060011B3 RID: 4531 RVA: 0x00072EC4 File Offset: 0x000712C4
	private void OnCollisionEnter(Collision collision)
	{
		this.SetHits(this.hits + 1);
	}

	// Token: 0x060011B4 RID: 4532 RVA: 0x00072ED4 File Offset: 0x000712D4
	private void SetHits(int hits)
	{
		this.hits = hits;
		this.Save();
		this.myTextMesh.text = hits.ToString();
	}

	// Token: 0x060011B5 RID: 4533 RVA: 0x00072EFB File Offset: 0x000712FB
	private void Save()
	{
		CryptoPlayerPrefs.SetInt(this.getPrefKey(), this.hits);
		PlayerPrefs.SetInt(this.getPrefKey(), this.hits);
		CryptoPlayerPrefs.Save();
	}

	// Token: 0x060011B6 RID: 4534 RVA: 0x00072F24 File Offset: 0x00071324
	private string getPrefKey()
	{
		return "cpp_test_hits_" + this.id;
	}

	// Token: 0x0400124C RID: 4684
	public string id = "cube1";

	// Token: 0x0400124D RID: 4685
	public int hits;

	// Token: 0x0400124E RID: 4686
	private TextMesh myTextMesh;
}
