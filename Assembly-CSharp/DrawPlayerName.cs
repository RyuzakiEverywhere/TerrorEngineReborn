using System;
using Photon;
using UnityEngine;

// Token: 0x02000120 RID: 288
public class DrawPlayerName : Photon.MonoBehaviour
{
	// Token: 0x06000672 RID: 1650 RVA: 0x00040693 File Offset: 0x0003EA93
	private void Awake()
	{
		if (!this.positionDisplay)
		{
			this.positionDisplay = base.transform;
		}
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x000406B1 File Offset: 0x0003EAB1
	private void Update()
	{
		this.playerName = base.gameObject.name;
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x000406C4 File Offset: 0x0003EAC4
	private void OnGUI()
	{
		GUI.skin = this.guiSKin;
		GUI.depth = 2;
		GUI.color = Color.white;
		if (Camera.main)
		{
			Vector3 vector = Camera.main.WorldToScreenPoint(this.positionDisplay.position);
			float num;
			if (vector.z * 3f < 50f)
			{
				num = vector.z * 3f;
			}
			else
			{
				num = 50f;
			}
			if (vector.z > 0f)
			{
				GUI.Label(new Rect(vector.x - 30f, (float)Screen.height - vector.y - 1f - num / 2f, 200f, 30f), this.playerName);
			}
		}
	}

	// Token: 0x040008E7 RID: 2279
	public GUISkin guiSKin;

	// Token: 0x040008E8 RID: 2280
	public Transform positionDisplay;

	// Token: 0x040008E9 RID: 2281
	public string playerName;
}
