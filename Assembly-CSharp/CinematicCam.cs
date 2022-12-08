using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class CinematicCam : MonoBehaviour
{
	// Token: 0x06000030 RID: 48 RVA: 0x00005798 File Offset: 0x00003B98
	private void LateUpdate()
	{
		if (this.target)
		{
			if (this.smooth)
			{
				Quaternion b = Quaternion.LookRotation(this.target.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.damping);
			}
			else
			{
				base.transform.LookAt(this.target);
			}
		}
		else
		{
			this.target = GameObject.Find("CinematicPoint").transform;
		}
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00005839 File Offset: 0x00003C39
	private void Start()
	{
	}

	// Token: 0x04000046 RID: 70
	public Transform target;

	// Token: 0x04000047 RID: 71
	public float damping = 200f;

	// Token: 0x04000048 RID: 72
	public bool smooth;
}
