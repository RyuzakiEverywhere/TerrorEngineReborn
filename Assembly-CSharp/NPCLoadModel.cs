using System;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class NPCLoadModel : MonoBehaviour
{
	// Token: 0x060000CD RID: 205 RVA: 0x0000C8B4 File Offset: 0x0000ACB4
	private void Awake()
	{
		if (base.gameObject.name == "NPC1(Clone)")
		{
			this.npctype = "NPC_Type1";
		}
		if (base.gameObject.name == "NPC2(Clone)")
		{
			this.npctype = "NPC_Type2";
		}
		if (base.gameObject.name == "NPC3(Clone)")
		{
			this.npctype = "NPC_Type3";
		}
		if (base.gameObject.name == "NPC4(Clone)")
		{
			this.npctype = "NPC_Type4";
		}
		if (base.gameObject.name == "NPC5(Clone)")
		{
			this.npctype = "NPC_Type5";
		}
		if (base.gameObject.name == "NPC6(Clone)")
		{
			this.npctype = "NPC_Type6";
		}
		if (base.gameObject.name == "NPC7(Clone)")
		{
			this.npctype = "NPC_Type7";
		}
		if (base.gameObject.name == "NPC8(Clone)")
		{
			this.npctype = "NPC_Type8";
		}
		if (base.gameObject.name == "NPC9(Clone)")
		{
			this.npctype = "NPC_Type9";
		}
		if (base.gameObject.name == "NPC10(Clone)")
		{
			this.npctype = "NPC_Type10";
		}
		if (base.gameObject.name == "NPCPlayer(Clone)")
		{
			this.npctype = "NPC_Type1";
		}
		this.npctypeobj = GameObject.Find(this.npctype);
	}

	// Token: 0x060000CE RID: 206 RVA: 0x0000CA6C File Offset: 0x0000AE6C
	private void Update()
	{
		if (this.npctypeobj.GetComponent<LoadNPC>().hasloadedmodel)
		{
			this.npcmod = this.npctypeobj.GetComponent<LoadNPC>().NPC;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.npcmod, base.transform.position, base.transform.rotation);
			GameObject gameObject2 = base.transform.Find("npc-pos").gameObject;
			gameObject.transform.parent = gameObject2.transform;
			gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			MeshRenderer[] componentsInChildren = gameObject.gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				Material[] materials = meshRenderer.materials;
				foreach (Material material in materials)
				{
					material.shader = Shader.Find("Legacy Shaders/Transparent/Cutout/Diffuse");
				}
				meshRenderer.materials = materials;
			}
			SkinnedMeshRenderer[] componentsInChildren2 = gameObject.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
			{
				Material[] materials2 = skinnedMeshRenderer.materials;
				foreach (Material material2 in materials2)
				{
					material2.shader = Shader.Find("Legacy Shaders/Transparent/Cutout/Diffuse");
				}
				skinnedMeshRenderer.materials = materials2;
			}
			this.hasmod = true;
			if (base.gameObject.transform.tag == "PNPC")
			{
				base.gameObject.GetComponent<PNPCMechanics>().enabled = true;
			}
			base.enabled = false;
		}
	}

	// Token: 0x0400011F RID: 287
	public string npctype;

	// Token: 0x04000120 RID: 288
	public GameObject npctypeobj;

	// Token: 0x04000121 RID: 289
	public GameObject npcmod;

	// Token: 0x04000122 RID: 290
	public bool hasmod;
}
