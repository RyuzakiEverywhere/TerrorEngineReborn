using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class EndZoneSync : MonoBehaviour
{
	// Token: 0x06000072 RID: 114 RVA: 0x000087DB File Offset: 0x00006BDB
	private void Start()
	{
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000087E0 File Offset: 0x00006BE0
	private void Update()
	{
		if (this.collect || this.collectandenter)
		{
			this.collectitems = GameObject.FindGameObjectsWithTag("collect");
		}
		if (this.killnpc)
		{
			this.npc = GameObject.FindGameObjectsWithTag("NPC");
		}
		if (this.collect && this.collectitems.Length == 0)
		{
			EndGame component = GameObject.Find("EndGame").GetComponent<EndGame>();
			component.End();
		}
	}

	// Token: 0x06000074 RID: 116 RVA: 0x0000885C File Offset: 0x00006C5C
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player" && ((!this.collect && !this.collectandenter) || (this.collectandenter && this.collectitems.Length == 0) || (this.killnpc && this.npc.Length == 0)))
		{
			EndGame component = GameObject.Find("EndGame").GetComponent<EndGame>();
			component.End();
		}
	}

	// Token: 0x040000A6 RID: 166
	public bool collect;

	// Token: 0x040000A7 RID: 167
	public bool collectandenter;

	// Token: 0x040000A8 RID: 168
	public bool killnpc;

	// Token: 0x040000A9 RID: 169
	public GameObject[] collectitems;

	// Token: 0x040000AA RID: 170
	public GameObject[] npc;
}
