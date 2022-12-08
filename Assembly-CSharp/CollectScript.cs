using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class CollectScript : MonoBehaviour
{
	// Token: 0x06000036 RID: 54 RVA: 0x00005A50 File Offset: 0x00003E50
	private void Start()
	{
		Vector3 size = base.gameObject.GetComponent<BoxCollider>().size;
		base.gameObject.GetComponent<BoxCollider>().size = new Vector3(size.x + size.y / 4f, size.x + size.y / 4f, size.z + size.z / 4f);
		base.transform.Translate(Vector3.up * 0.01f);
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00005ADC File Offset: 0x00003EDC
	private void Update()
	{
		if (this.begin)
		{
			this.mtg = (UnityEngine.Object.Instantiate(Resources.Load("MoreToGo"), new Vector3(0.5f, 0.5f, 0f), base.transform.rotation) as GameObject);
			if (this.mtg != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00005B49 File Offset: 0x00003F49
	private void OnTriggerStay(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			this.begin = true;
		}
	}

	// Token: 0x0400004C RID: 76
	public GameObject mtg;

	// Token: 0x0400004D RID: 77
	public bool begin;
}
