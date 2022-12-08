using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000F4 RID: 244
public class MoreToGoScript : MonoBehaviour
{
	// Token: 0x06000498 RID: 1176 RVA: 0x0003895C File Offset: 0x00036D5C
	private void Awake()
	{
		base.gameObject.GetComponent<GUIText>().enabled = false;
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x00038970 File Offset: 0x00036D70
	private IEnumerator Start()
	{
		if (GameObject.Find(base.gameObject.name) != null)
		{
			UnityEngine.Object.Destroy(GameObject.Find("Remaining"));
			base.gameObject.name = "Remaining";
		}
		yield return new WaitForSeconds(0.3f);
		this.objs = GameObject.FindGameObjectsWithTag("collect");
		base.gameObject.GetComponent<GUIText>().text = this.objs.Length.ToString() + " Remaining";
		base.gameObject.GetComponent<GUIText>().enabled = true;
		this.curname = base.gameObject.name;
		yield break;
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x0003898B File Offset: 0x00036D8B
	private void Update()
	{
		UnityEngine.Object.Destroy(base.gameObject, 3f);
	}

	// Token: 0x0400079A RID: 1946
	public GameObject[] objs;

	// Token: 0x0400079B RID: 1947
	public string curname;
}
