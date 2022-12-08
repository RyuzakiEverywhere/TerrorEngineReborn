using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class AdvTeleportZone : MonoBehaviour
{
	// Token: 0x06000005 RID: 5 RVA: 0x00002C86 File Offset: 0x00001086
	private void Awake()
	{
		this.atp = base.gameObject.GetComponent<AdvTeleportProperties>();
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002C99 File Offset: 0x00001099
	private void Start()
	{
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002C9B File Offset: 0x0000109B
	private void Update()
	{
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002CA0 File Offset: 0x000010A0
	private void OnTriggerEnter(Collider other)
	{
		if (this.atp.player && other.transform.tag == "Player" && other.gameObject.GetComponent<PhotonView>().isMine)
		{
			Vector3 position = other.transform.position;
			if (this.atp.x && this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), float.Parse(this.atp.ypos), float.Parse(this.atp.zpos));
			}
			if (this.atp.x && this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), float.Parse(this.atp.ypos), position.z);
			}
			if (this.atp.x && !this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), position.y, position.z);
			}
			if (!this.atp.x && !this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(position.x, position.y, float.Parse(this.atp.zpos));
			}
			if (!this.atp.x && this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(position.x, float.Parse(this.atp.ypos), float.Parse(this.atp.zpos));
			}
			if (!this.atp.x && this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(position.x, float.Parse(this.atp.ypos), position.z);
			}
			if (this.atp.x && !this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), position.y, float.Parse(this.atp.zpos));
			}
		}
		if (this.atp.allplayers && other.transform.tag == "Player")
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject gameObject in array)
			{
				Vector3 position2 = gameObject.transform.position;
				if (this.atp.x && this.atp.y && this.atp.z)
				{
					gameObject.transform.position = new Vector3(float.Parse(this.atp.xpos), float.Parse(this.atp.ypos), float.Parse(this.atp.zpos));
				}
				if (this.atp.x && this.atp.y && !this.atp.z)
				{
					gameObject.transform.position = new Vector3(float.Parse(this.atp.xpos), float.Parse(this.atp.ypos), position2.z);
				}
				if (this.atp.x && !this.atp.y && !this.atp.z)
				{
					gameObject.transform.position = new Vector3(float.Parse(this.atp.xpos), position2.y, position2.z);
				}
				if (!this.atp.x && !this.atp.y && this.atp.z)
				{
					gameObject.transform.position = new Vector3(position2.x, position2.y, float.Parse(this.atp.zpos));
				}
				if (!this.atp.x && this.atp.y && this.atp.z)
				{
					gameObject.transform.position = new Vector3(position2.x, float.Parse(this.atp.ypos), float.Parse(this.atp.zpos));
				}
				if (!this.atp.x && this.atp.y && !this.atp.z)
				{
					gameObject.transform.position = new Vector3(position2.x, float.Parse(this.atp.ypos), position2.z);
				}
				if (this.atp.x && !this.atp.y && this.atp.z)
				{
					gameObject.transform.position = new Vector3(float.Parse(this.atp.xpos), position2.y, float.Parse(this.atp.zpos));
				}
			}
		}
		if ((this.atp.npc && other.transform.tag == "PNPC" && other.gameObject.GetComponent<PhotonView>().isMine) || (this.atp.npc && other.transform.tag == "NPC"))
		{
			Vector3 position3 = other.transform.position;
			if (this.atp.x && this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), float.Parse(this.atp.ypos), float.Parse(this.atp.zpos));
			}
			if (this.atp.x && this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), float.Parse(this.atp.ypos), position3.z);
			}
			if (this.atp.x && !this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), position3.y, position3.z);
			}
			if (!this.atp.x && !this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(position3.x, position3.y, float.Parse(this.atp.zpos));
			}
			if (!this.atp.x && this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(position3.x, float.Parse(this.atp.ypos), float.Parse(this.atp.zpos));
			}
			if (!this.atp.x && this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(position3.x, float.Parse(this.atp.ypos), position3.z);
			}
			if (this.atp.x && !this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), position3.y, float.Parse(this.atp.zpos));
			}
		}
		if (this.atp.objects && other.transform.tag != "PNPC" && other.transform.tag != "NPC" && other.transform.tag != "Player")
		{
			Vector3 position4 = other.transform.position;
			if (this.atp.x && this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), float.Parse(this.atp.ypos), float.Parse(this.atp.zpos));
			}
			if (this.atp.x && this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), float.Parse(this.atp.ypos), position4.z);
			}
			if (this.atp.x && !this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), position4.y, position4.z);
			}
			if (!this.atp.x && !this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(position4.x, position4.y, float.Parse(this.atp.zpos));
			}
			if (!this.atp.x && this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(position4.x, float.Parse(this.atp.ypos), float.Parse(this.atp.zpos));
			}
			if (!this.atp.x && this.atp.y && !this.atp.z)
			{
				other.transform.position = new Vector3(position4.x, float.Parse(this.atp.ypos), position4.z);
			}
			if (this.atp.x && !this.atp.y && this.atp.z)
			{
				other.transform.position = new Vector3(float.Parse(this.atp.xpos), position4.y, float.Parse(this.atp.zpos));
			}
		}
	}

	// Token: 0x0400000A RID: 10
	public AdvTeleportProperties atp;
}
