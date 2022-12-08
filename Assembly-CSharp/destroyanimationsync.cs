using System;
using Photon;

// Token: 0x0200015E RID: 350
public class destroyanimationsync : MonoBehaviour
{
	// Token: 0x06000862 RID: 2146 RVA: 0x0004DDB0 File Offset: 0x0004C1B0
	private void Start()
	{
		if (!base.photonView.isMine)
		{
			UpdateMyAnimation component = base.GetComponent<UpdateMyAnimation>();
			component.check = false;
		}
	}
}
