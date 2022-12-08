using System;
using UnityEngine;

// Token: 0x02000171 RID: 369
public class FindPlayers : MonoBehaviour
{
	// Token: 0x060008AD RID: 2221 RVA: 0x0005041E File Offset: 0x0004E81E
	private void Start()
	{
		base.InvokeRepeating("ScanForTarget", 0f, this.scanFrequency);
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x00050438 File Offset: 0x0004E838
	private void Update()
	{
		if (base.transform.Find("npc-pos/npc(Clone)") != null && this.npcmodel == null)
		{
			this.npcmodel = base.transform.Find("npc-pos/npc(Clone)").gameObject;
		}
		if (this.target == null)
		{
			this.ScanForTarget();
		}
		else
		{
			this.newdis = Vector3.Distance(this.target.transform.position, base.transform.position);
		}
		if (this.detectbydis && this.newdis <= this.curdis && !this.hasspotted)
		{
			base.gameObject.GetComponent<NpcSync>().Chase();
			this.hasspotted = true;
		}
		if (this.detectbyview && !this.hasspotted)
		{
			Vector3 direction = this.npcmodel.transform.TransformDirection(Vector3.forward);
			Vector3 position = base.transform.position;
			RaycastHit raycastHit;
			if (Physics.Raycast(new Vector3(position.x, position.y + 0.5f, position.z), direction, out raycastHit, (float)Mathf.FloorToInt(this.spotdis)) && raycastHit.transform.tag == "Player")
			{
				base.gameObject.GetComponent<NpcSync>().Chase();
				this.hasspotted = true;
			}
		}
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x000505AF File Offset: 0x0004E9AF
	private void ScanForTarget()
	{
		this.target = this.GetNearestTaggedObject();
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x000505C0 File Offset: 0x0004E9C0
	private GameObject GetNearestTaggedObject()
	{
		float num = float.PositiveInfinity;
		this.taggedGameObjects = GameObject.FindGameObjectsWithTag("Player");
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

	// Token: 0x04000AC2 RID: 2754
	public string searchTag = "Player";

	// Token: 0x04000AC3 RID: 2755
	public GameObject[] taggedGameObjects;

	// Token: 0x04000AC4 RID: 2756
	public bool detectbydis;

	// Token: 0x04000AC5 RID: 2757
	public bool detectbyview;

	// Token: 0x04000AC6 RID: 2758
	public bool following;

	// Token: 0x04000AC7 RID: 2759
	public float curdis;

	// Token: 0x04000AC8 RID: 2760
	public float newdis;

	// Token: 0x04000AC9 RID: 2761
	public float spotdis;

	// Token: 0x04000ACA RID: 2762
	public float attdis;

	// Token: 0x04000ACB RID: 2763
	public GameObject npcmodel;

	// Token: 0x04000ACC RID: 2764
	private bool hasspotted;

	// Token: 0x04000ACD RID: 2765
	public float scanFrequency = 1f;

	// Token: 0x04000ACE RID: 2766
	public GameObject target;
}
