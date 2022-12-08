using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
public class NearestCinematicCam : MonoBehaviour
{
	// Token: 0x060000D0 RID: 208 RVA: 0x0000CC53 File Offset: 0x0000B053
	private void Start()
	{
		base.InvokeRepeating("ScanForTarget", 0f, this.scanFrequency);
		if (GameObject.Find("Settings").GetComponent<SettingsProperties>().camtype < 3)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x0000CC8C File Offset: 0x0000B08C
	private void Update()
	{
		if (this.target == null)
		{
			this.ScanForTarget();
		}
		else
		{
			this.newdis = Vector3.Distance(this.target.transform.position, base.transform.position);
			base.enabled = false;
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x0000CCE2 File Offset: 0x0000B0E2
	private void ScanForTarget()
	{
		this.target = this.GetNearestTaggedObject();
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x0000CCF0 File Offset: 0x0000B0F0
	private GameObject GetNearestTaggedObject()
	{
		float num = float.PositiveInfinity;
		this.taggedGameObjects = GameObject.FindGameObjectsWithTag(this.searchTag);
		GameObject result = null;
		if (this.taggedGameObjects != null)
		{
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
		}
		return result;
	}

	// Token: 0x04000123 RID: 291
	public string searchTag = "CinematicTrigger";

	// Token: 0x04000124 RID: 292
	public GameObject[] taggedGameObjects;

	// Token: 0x04000125 RID: 293
	public float curdis;

	// Token: 0x04000126 RID: 294
	public float newdis;

	// Token: 0x04000127 RID: 295
	private bool hasspotted;

	// Token: 0x04000128 RID: 296
	public float scanFrequency = 1f;

	// Token: 0x04000129 RID: 297
	public GameObject target;
}
