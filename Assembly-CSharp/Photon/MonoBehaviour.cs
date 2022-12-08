using System;
using UnityEngine;

namespace Photon
{
	// Token: 0x0200013C RID: 316
	public class MonoBehaviour : MonoBehaviour
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x00002B1B File Offset: 0x00000F1B
		public PhotonView photonView
		{
			get
			{
				return PhotonView.Get(this);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x00002B23 File Offset: 0x00000F23
		public PhotonView networkView
		{
			get
			{
				Debug.LogWarning("Why are you still using networkView? should be PhotonView?");
				return PhotonView.Get(this);
			}
		}
	}
}
