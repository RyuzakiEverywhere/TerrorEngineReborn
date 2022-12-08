using System;
using UnityEngine;

// Token: 0x020000D1 RID: 209
public class GridMovement : MonoBehaviour
{
	// Token: 0x060003EE RID: 1006 RVA: 0x00024314 File Offset: 0x00022714
	private void Start()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 1 || CryptoPlayerPrefs.GetInt("Mode", 0) == 2 || CryptoPlayerPrefs.GetInt("Mode", 0) == 3)
		{
			base.gameObject.active = false;
		}
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00024360 File Offset: 0x00022760
	private void Update()
	{
		if (Input.GetKey(KeyCode.Mouse1))
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(this.editorobj.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out raycastHit))
			{
				this.rayHitWorldPosition = raycastHit.point;
				this.mouseposX = raycastHit.point.x;
				this.mouseposZ = raycastHit.point.z;
			}
			Vector3 localEulerAngles = this.editorobj.localEulerAngles;
			Vector3 position = this.editorobj.position;
			Vector3 position2 = base.transform.position;
			if (!this.snapped)
			{
				position2.x = Mathf.Round(this.mouseposX);
				position2.z = Mathf.Round(this.mouseposZ);
			}
			else if ((localEulerAngles.y > 50f && localEulerAngles.y < 130f) || (localEulerAngles.y > 230f && localEulerAngles.y < 310f))
			{
				position2.z = Mathf.Round(this.mouseposZ);
			}
			else
			{
				position2.x = Mathf.Round(this.mouseposX);
			}
			base.transform.position = position2;
			if ((localEulerAngles.y > 50f && localEulerAngles.y < 130f) || (localEulerAngles.y > 230f && localEulerAngles.y < 310f))
			{
				base.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
			}
			else
			{
				base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			}
		}
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.PageUp))
		{
			Vector3 position3 = base.transform.position;
			position3.y += 2f;
			base.transform.position = position3;
		}
		if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.PageDown))
		{
			Vector3 position4 = base.transform.position;
			position4.y -= 2f;
			base.transform.position = position4;
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			this.snapped = !this.snapped;
		}
	}

	// Token: 0x04000470 RID: 1136
	private float mouseposX;

	// Token: 0x04000471 RID: 1137
	private float mouseposZ;

	// Token: 0x04000472 RID: 1138
	private Vector3 rayHitWorldPosition;

	// Token: 0x04000473 RID: 1139
	public Transform editorobj;

	// Token: 0x04000474 RID: 1140
	public bool snapped;
}
