using System;
using UnityEngine;

// Token: 0x02000150 RID: 336
public class InputToEvent : MonoBehaviour
{
	// Token: 0x1700007E RID: 126
	// (get) Token: 0x06000830 RID: 2096 RVA: 0x0004B08C File Offset: 0x0004948C
	// (set) Token: 0x06000831 RID: 2097 RVA: 0x0004B093 File Offset: 0x00049493
	public static GameObject goPointedAt { get; private set; }

	// Token: 0x06000832 RID: 2098 RVA: 0x0004B09C File Offset: 0x0004949C
	private void Update()
	{
		if (this.DetectPointedAtGameObject)
		{
			InputToEvent.goPointedAt = this.RaycastObject(Input.mousePosition);
		}
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				this.Press(touch.position);
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				this.Release(touch.position);
			}
			return;
		}
		if (Input.GetMouseButtonDown(0))
		{
			this.Press(Input.mousePosition);
		}
		if (Input.GetMouseButtonUp(0))
		{
			this.Release(Input.mousePosition);
		}
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x0004B14A File Offset: 0x0004954A
	private void Press(Vector2 screenPos)
	{
		this.lastGo = this.RaycastObject(screenPos);
		if (this.lastGo != null)
		{
			this.lastGo.SendMessage("OnPress", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x0004B17C File Offset: 0x0004957C
	private void Release(Vector2 screenPos)
	{
		if (this.lastGo != null)
		{
			GameObject x = this.RaycastObject(screenPos);
			if (x == this.lastGo)
			{
				this.lastGo.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
			}
			this.lastGo.SendMessage("OnRelease", SendMessageOptions.DontRequireReceiver);
			this.lastGo = null;
		}
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0004B1DC File Offset: 0x000495DC
	private GameObject RaycastObject(Vector2 screenPos)
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(base.GetComponent<Camera>().ScreenPointToRay(screenPos), out raycastHit, 200f))
		{
			InputToEvent.inputHitPos = raycastHit.point;
			return raycastHit.collider.gameObject;
		}
		return null;
	}

	// Token: 0x04000A47 RID: 2631
	private GameObject lastGo;

	// Token: 0x04000A48 RID: 2632
	public static Vector3 inputHitPos;

	// Token: 0x04000A49 RID: 2633
	public bool DetectPointedAtGameObject;
}
