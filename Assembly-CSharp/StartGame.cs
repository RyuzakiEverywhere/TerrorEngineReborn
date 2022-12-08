using System;
using Photon;

// Token: 0x020001A1 RID: 417
public class StartGame : MonoBehaviour
{
	// Token: 0x060009EE RID: 2542 RVA: 0x00058F81 File Offset: 0x00057381
	private void Start()
	{
		if (PhotonNetwork.isMasterClient)
		{
			PhotonNetwork.room.visible = false;
		}
		base.gameObject.name = "StartGame";
	}

	// Token: 0x060009EF RID: 2543 RVA: 0x00058FA8 File Offset: 0x000573A8
	private void Update()
	{
	}
}
