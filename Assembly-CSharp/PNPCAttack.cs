using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200011D RID: 285
public class PNPCAttack : MonoBehaviour
{
	// Token: 0x0600065A RID: 1626 RVA: 0x0003FFA4 File Offset: 0x0003E3A4
	private IEnumerator Start()
	{
		base.InvokeRepeating("ScanForTarget", 0f, this.scanFrequency);
		yield return new WaitForSeconds(1f);
		this.des = true;
		yield break;
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x0003FFC0 File Offset: 0x0003E3C0
	private void Update()
	{
		if (this.des)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (this.target == null)
		{
			this.ScanForTarget();
		}
		else
		{
			this.curdis = Vector3.Distance(this.target.transform.position, base.transform.position);
			if (this.curdis <= 3f && !this.hasattacked)
			{
				this.damage = float.Parse(GameObject.FindGameObjectWithTag("MonsterStartPoint").GetComponent<MonsterProperties>().damage);
				this.target.GetComponent<PlayerHealth>().health -= this.damage;
				this.hasattacked = true;
			}
		}
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x00040083 File Offset: 0x0003E483
	private void ScanForTarget()
	{
		this.target = this.GetNearestTaggedObject();
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x00040094 File Offset: 0x0003E494
	private GameObject GetNearestTaggedObject()
	{
		float num = float.PositiveInfinity;
		this.taggedGameObjects = GameObject.FindGameObjectsWithTag(this.searchTag);
		GameObject result = null;
		foreach (GameObject gameObject in this.taggedGameObjects)
		{
			Vector3 position = gameObject.transform.position;
			float sqrMagnitude = (position - base.transform.position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				result = gameObject;
				num = sqrMagnitude;
			}
		}
		return result;
	}

	// Token: 0x040008D5 RID: 2261
	public float damage;

	// Token: 0x040008D6 RID: 2262
	public bool des;

	// Token: 0x040008D7 RID: 2263
	public string searchTag = "Player";

	// Token: 0x040008D8 RID: 2264
	public GameObject[] taggedGameObjects;

	// Token: 0x040008D9 RID: 2265
	public float curdis;

	// Token: 0x040008DA RID: 2266
	public float scanFrequency = 1f;

	// Token: 0x040008DB RID: 2267
	public bool hasattacked;

	// Token: 0x040008DC RID: 2268
	public GameObject target;
}
