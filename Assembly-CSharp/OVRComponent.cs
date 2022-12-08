using System;
using UnityEngine;

// Token: 0x02000104 RID: 260
public class OVRComponent : MonoBehaviour
{
	// Token: 0x0600055E RID: 1374 RVA: 0x0003A824 File Offset: 0x00038C24
	public virtual void Awake()
	{
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x0003A826 File Offset: 0x00038C26
	public virtual void Start()
	{
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x0003A828 File Offset: 0x00038C28
	public virtual void Update()
	{
		this.DeltaTime = Time.deltaTime * 60f;
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0003A83B File Offset: 0x00038C3B
	public virtual void LateUpdate()
	{
	}

	// Token: 0x04000820 RID: 2080
	protected float DeltaTime = 1f;
}
