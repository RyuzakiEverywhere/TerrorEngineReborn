using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
[RequireComponent(typeof(InputToEvent))]
public class PointedAtGameObjectInfo : MonoBehaviour
{
	// Token: 0x06000847 RID: 2119 RVA: 0x0004B568 File Offset: 0x00049968
	private void OnGUI()
	{
		if (InputToEvent.goPointedAt != null)
		{
			PhotonView photonView = InputToEvent.goPointedAt.GetPhotonView();
			if (photonView != null)
			{
				GUI.Label(new Rect(Input.mousePosition.x + 5f, (float)Screen.height - Input.mousePosition.y - 15f, 300f, 30f), string.Format("ViewID {0} InstID {1} Lvl {2} {3}", new object[]
				{
					photonView.viewID,
					photonView.instantiationId,
					photonView.prefix,
					(!photonView.isSceneView) ? ((!photonView.isMine) ? "remote" : "mine") : "scene"
				}));
			}
		}
	}
}
