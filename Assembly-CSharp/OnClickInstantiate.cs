using System;
using UnityEngine;

// Token: 0x02000154 RID: 340
public class OnClickInstantiate : MonoBehaviour
{
	// Token: 0x06000842 RID: 2114 RVA: 0x0004B408 File Offset: 0x00049808
	private void OnClick()
	{
		if (PhotonNetwork.connectionStateDetailed != PeerState.Joined)
		{
			return;
		}
		int instantiateType = this.InstantiateType;
		if (instantiateType != 0)
		{
			if (instantiateType == 1)
			{
				PhotonNetwork.InstantiateSceneObject(this.Prefab.name, InputToEvent.inputHitPos + new Vector3(0f, 5f, 0f), Quaternion.identity, 0, null);
			}
		}
		else
		{
			PhotonNetwork.Instantiate(this.Prefab.name, InputToEvent.inputHitPos + new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
		}
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x0004B4B0 File Offset: 0x000498B0
	private void OnGUI()
	{
		if (this.showGui)
		{
			GUILayout.BeginArea(new Rect((float)(Screen.width - 180), 0f, 180f, 50f));
			this.InstantiateType = GUILayout.Toolbar(this.InstantiateType, this.InstantiateTypeNames, new GUILayoutOption[0]);
			GUILayout.EndArea();
		}
	}

	// Token: 0x04000A4D RID: 2637
	public GameObject Prefab;

	// Token: 0x04000A4E RID: 2638
	public int InstantiateType;

	// Token: 0x04000A4F RID: 2639
	private string[] InstantiateTypeNames = new string[]
	{
		"Mine",
		"Scene"
	};

	// Token: 0x04000A50 RID: 2640
	public bool showGui;
}
