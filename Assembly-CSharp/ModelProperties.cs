using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class ModelProperties : MonoBehaviour
{
	// Token: 0x0600044F RID: 1103 RVA: 0x000302E1 File Offset: 0x0002E6E1
	private void Awake()
	{
		base.gameObject.layer = 18;
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x000302F0 File Offset: 0x0002E6F0
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
		base.gameObject.GetComponent<ModelProperties>().enabled = false;
		base.StartCoroutine(this.LateStart());
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x00030328 File Offset: 0x0002E728
	private IEnumerator LateStart()
	{
		yield return new WaitForEndOfFrame();
		base.gameObject.transform.localScale = new Vector3(float.Parse(base.gameObject.GetComponent<PositionAndScale>().scalex), float.Parse(base.gameObject.GetComponent<PositionAndScale>().scaley), float.Parse(base.gameObject.GetComponent<PositionAndScale>().scalez));
		yield break;
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x00030344 File Offset: 0x0002E744
	private void Update()
	{
		if (this.canpickup)
		{
			this.rigidbody = true;
		}
		if (!this.togglevisible)
		{
			this.triggerdeactivate = false;
		}
		if (this.rigidbody)
		{
			this.deathoncollide = false;
			this.examine = false;
		}
		if (this.collect)
		{
			this.examine = false;
		}
		if (!base.gameObject.GetComponent<PositionAndScale>().enabled)
		{
			base.gameObject.GetComponent<ModelProperties>().enabled = false;
		}
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x000303C8 File Offset: 0x0002E7C8
	private void ModelWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 370f));
		this.togglevisible = GUI.Toggle(new Rect(40f, 20f, 100f, 20f), this.togglevisible, "Enabled At Start");
		if (this.togglevisible)
		{
			this.rigidbody = GUI.Toggle(new Rect(40f, 40f, 100f, 20f), this.rigidbody, "Gravity");
			this.canpickup = GUI.Toggle(new Rect(40f, 60f, 120f, 20f), this.canpickup, "Host Can Pickup");
			this.collect = GUI.Toggle(new Rect(40f, 80f, 100f, 20f), this.collect, "Collect");
		}
		else
		{
			this.rigidbody = false;
			this.canpickup = false;
			this.collect = false;
			GUI.Label(new Rect(40f, 40f, 160f, 20f), "Activate ID");
			this.triggerid = GUI.TextField(new Rect(40f, 60f, 50f, 20f), this.triggerid);
		}
		GUI.Box(new Rect(30f, 100f, 180f, 120f), "Movement");
		if (!this.rigidbody)
		{
			if (this.none && GUI.Button(new Rect(70f, 135f, 100f, 20f), "None"))
			{
				this.none = false;
				this.moveforward = true;
				this.movebackward = false;
				this.moveup = false;
				this.movedown = false;
			}
			if (this.moveforward && GUI.Button(new Rect(70f, 135f, 100f, 20f), "Forward"))
			{
				this.none = false;
				this.moveforward = false;
				this.movebackward = true;
				this.moveup = false;
				this.movedown = false;
			}
			if (this.movebackward && GUI.Button(new Rect(70f, 135f, 100f, 20f), "Backward"))
			{
				this.none = false;
				this.moveforward = false;
				this.movebackward = false;
				this.moveup = true;
				this.movedown = false;
			}
			if (this.moveup && GUI.Button(new Rect(70f, 135f, 100f, 20f), "Up"))
			{
				this.none = false;
				this.moveforward = false;
				this.movebackward = false;
				this.moveup = false;
				this.movedown = true;
			}
			if (this.movedown && GUI.Button(new Rect(70f, 135f, 100f, 20f), "Down"))
			{
				this.none = true;
				this.moveforward = false;
				this.movebackward = false;
				this.moveup = false;
				this.movedown = false;
				this.backandforth = false;
			}
		}
		else
		{
			GUI.TextArea(new Rect(40f, 135f, 160f, 55f), "This option is not \n available with the \n current settings.");
			this.none = true;
			this.moveforward = false;
			this.movebackward = false;
			this.moveup = false;
			this.movedown = false;
		}
		if (!this.none)
		{
			GUI.Label(new Rect(40f, 160f, 160f, 20f), "Movement Speed");
			this.movementspeed = GUI.TextField(new Rect(40f, 180f, 30f, 20f), this.movementspeed);
			this.backandforth = GUI.Toggle(new Rect(40f, 200f, 100f, 20f), this.backandforth, "Back And Forth");
		}
		if (!this.rigidbody)
		{
			this.deathoncollide = GUI.Toggle(new Rect(40f, 230f, 100f, 20f), this.deathoncollide, "Death On Collision");
		}
		if (this.togglevisible)
		{
			this.triggerdeactivate = GUI.Toggle(new Rect(40f, 295f, 100f, 20f), this.triggerdeactivate, "Use Trigger To Deactivate");
			if (this.triggerdeactivate)
			{
				GUI.Label(new Rect(40f, 315f, 160f, 20f), "Deactivate ID");
				this.triggerid = GUI.TextField(new Rect(40f, 335f, 50f, 22f), this.triggerid);
			}
		}
		GUI.EndScrollView();
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x000308D4 File Offset: 0x0002ECD4
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.ModelWindow), "Editor");
	}

	// Token: 0x0400068C RID: 1676
	public GUISkin skin;

	// Token: 0x0400068D RID: 1677
	public Vector2 scrollPosition;

	// Token: 0x0400068E RID: 1678
	public bool togglevisible = true;

	// Token: 0x0400068F RID: 1679
	public bool rigidbody;

	// Token: 0x04000690 RID: 1680
	public bool canpickup;

	// Token: 0x04000691 RID: 1681
	public bool collect;

	// Token: 0x04000692 RID: 1682
	public bool none = true;

	// Token: 0x04000693 RID: 1683
	public bool moveforward;

	// Token: 0x04000694 RID: 1684
	public bool movebackward;

	// Token: 0x04000695 RID: 1685
	public bool moveup;

	// Token: 0x04000696 RID: 1686
	public bool movedown;

	// Token: 0x04000697 RID: 1687
	public bool backandforth;

	// Token: 0x04000698 RID: 1688
	public string movementspeed = "1";

	// Token: 0x04000699 RID: 1689
	public bool deathoncollide;

	// Token: 0x0400069A RID: 1690
	public bool triggerdeactivate;

	// Token: 0x0400069B RID: 1691
	public string triggerid = "1";

	// Token: 0x0400069C RID: 1692
	public bool examine;

	// Token: 0x0400069D RID: 1693
	public string examinetext = "Examine Text";

	// Token: 0x0400069E RID: 1694
	public bool notmodel = true;

	// Token: 0x0400069F RID: 1695
	private bool iscollect;
}
