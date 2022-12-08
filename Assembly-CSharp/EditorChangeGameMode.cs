using System;
using UnityEngine;

// Token: 0x020000AA RID: 170
public class EditorChangeGameMode : MonoBehaviour
{
	// Token: 0x06000328 RID: 808 RVA: 0x0001EAD4 File Offset: 0x0001CED4
	private void Awake()
	{
		PlayerPrefs.SetInt("Mode", this.gamemode);
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0001EAE6 File Offset: 0x0001CEE6
	private void Start()
	{
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0001EAE8 File Offset: 0x0001CEE8
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			this.gamemode = 1;
		}
		if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			this.gamemode = 2;
		}
		if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			this.gamemode = 3;
		}
		if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			this.gamemode = 4;
		}
		if (Input.GetKeyDown(KeyCode.Keypad5))
		{
			this.gamemode = 5;
		}
		PlayerPrefs.SetInt("Mode", this.gamemode);
	}

	// Token: 0x04000390 RID: 912
	public int gamemode = 4;
}
