using System;
using UnityEngine;

// Token: 0x02000121 RID: 289
public class EnableScript : MonoBehaviour
{
	// Token: 0x06000676 RID: 1654 RVA: 0x000407A4 File Offset: 0x0003EBA4
	public void Awake()
	{
		if (PhotonNetwork.room != null)
		{
			UnityEngine.Object.Destroy(this.mainMenu);
			this.game.active = true;
		}
		else
		{
			UnityEngine.Object.Destroy(this.game);
			this.mainMenu.active = true;
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x040008EA RID: 2282
	public GameObject game;

	// Token: 0x040008EB RID: 2283
	public GameObject mainMenu;
}
