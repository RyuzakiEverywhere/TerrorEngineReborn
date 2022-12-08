using System;
using Photon;

// Token: 0x02000161 RID: 353
public class storymakeronline : MonoBehaviour
{
	// Token: 0x0600086C RID: 2156 RVA: 0x0004E054 File Offset: 0x0004C454
	private void Awake()
	{
		if (base.photonView.isMine)
		{
			base.gameObject.tag = "editorobj";
		}
	}

	// Token: 0x0600086D RID: 2157 RVA: 0x0004E076 File Offset: 0x0004C476
	private void Start()
	{
	}

	// Token: 0x0600086E RID: 2158 RVA: 0x0004E078 File Offset: 0x0004C478
	private void Update()
	{
	}
}
