using System;
using UnityEngine;

// Token: 0x020000F5 RID: 245
public class NPCCamera : MonoBehaviour
{
	// Token: 0x0600049C RID: 1180 RVA: 0x00038AF7 File Offset: 0x00036EF7
	private void Awake()
	{
		this.firstpos = new Vector3(0f, 0f, -1f);
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x00038B13 File Offset: 0x00036F13
	private void Start()
	{
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x00038B18 File Offset: 0x00036F18
	private void Update()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, Vector3.back, out raycastHit, 1f))
		{
			this.cam.position = raycastHit.point;
		}
		else
		{
			this.cam.localPosition = this.firstpos;
		}
	}

	// Token: 0x0400079C RID: 1948
	public Vector3 firstpos;

	// Token: 0x0400079D RID: 1949
	public Transform cam;
}
