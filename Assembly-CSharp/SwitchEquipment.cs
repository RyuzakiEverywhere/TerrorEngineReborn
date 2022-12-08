using System;
using Photon;
using UnityEngine;

// Token: 0x02000042 RID: 66
public class SwitchEquipment : Photon.MonoBehaviour
{
	// Token: 0x06000126 RID: 294 RVA: 0x000108CD File Offset: 0x0000ECCD
	private void Start()
	{
		this.correctobj = this.curobj;
		this.pastobj = this.curobj;
		this.canshowinv = GameObject.Find("Settings").GetComponent<SettingsProperties>().useinv;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x00010904 File Offset: 0x0000ED04
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Debug.Log("switch!");
			this.curobj++;
		}
		if (base.photonView.isMine)
		{
			if (this.curobj > 11)
			{
				this.curobj = 0;
			}
			if (this.curobj == 1 && !this.flashlightbool)
			{
				this.curobj++;
			}
			if (this.curobj == 2 && !this.lanternbool)
			{
				this.curobj++;
			}
			if (this.curobj == 3 && !this.candlebool)
			{
				this.curobj++;
			}
			if (this.curobj == 4 && !this.torchbool)
			{
				this.curobj++;
			}
			if (this.curobj == 5 && !this.nvcamerabool)
			{
				this.curobj++;
			}
			if (this.curobj == 6 && !this.nvgogglesbool)
			{
				this.curobj++;
			}
			if (this.curobj == 7 && !this.ci1bool)
			{
				this.curobj++;
			}
			if (this.curobj == 8 && !this.ci2bool)
			{
				this.curobj++;
			}
			if (this.curobj == 9 && !this.ci3bool)
			{
				this.curobj++;
			}
			if (this.curobj == 10 && !this.ci4bool)
			{
				this.curobj++;
			}
			if (this.curobj == 11 && !this.ci5bool)
			{
				this.curobj++;
			}
			if (this.pastobj != this.correctobj)
			{
				base.gameObject.GetComponent<PlayerHandler>().curitem = this.correctobj;
				this.pastobj = this.correctobj;
			}
			if (Input.GetKeyDown(KeyCode.I) && this.canshowinv)
			{
				this.showinv = !this.showinv;
				if (this.showinv)
				{
					Screen.lockCursor = false;
					Cursor.visible = true;
				}
				else
				{
					Screen.lockCursor = true;
					Cursor.visible = false;
				}
			}
		}
		this.Check();
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00010B7A File Offset: 0x0000EF7A
	private void LateUpdate()
	{
		if (base.photonView.isMine)
		{
			this.correctobj = this.curobj;
		}
		else
		{
			this.correctobj = base.gameObject.GetComponent<PlayerHandler>().curitem;
		}
	}

	// Token: 0x06000129 RID: 297 RVA: 0x00010BB4 File Offset: 0x0000EFB4
	private void Check()
	{
		if (this.correctobj == 0)
		{
			base.gameObject.GetComponent<UpdateMyAnimation>().noitem = true;
			base.gameObject.GetComponent<UpdateMyAnimation>().onehand = false;
			base.gameObject.GetComponent<UpdateMyAnimation>().twohand = false;
			base.gameObject.GetComponent<UpdateMyAnimation>().twohandweapon = false;
		}
		if (this.correctobj == 1)
		{
			this.flashlight.gameObject.SetActive(true);
		}
		else
		{
			this.flashlight.gameObject.SetActive(false);
		}
		if (this.correctobj == 2)
		{
			this.lantern.gameObject.SetActive(true);
		}
		else
		{
			this.lantern.gameObject.SetActive(false);
		}
		if (this.correctobj == 3)
		{
			this.candle.gameObject.SetActive(true);
		}
		else
		{
			this.candle.gameObject.SetActive(false);
		}
		if (this.correctobj == 4)
		{
			this.torch.gameObject.SetActive(true);
		}
		else
		{
			this.torch.gameObject.SetActive(false);
		}
		if (this.correctobj == 5)
		{
			this.nvcamera.gameObject.SetActive(true);
		}
		else
		{
			this.nvcamera.gameObject.SetActive(false);
		}
		if (this.correctobj == 6)
		{
			this.nvgoggles.gameObject.SetActive(true);
		}
		else
		{
			this.nvgoggles.gameObject.SetActive(false);
		}
		if (this.correctobj == 7)
		{
			this.ci1.gameObject.SetActive(true);
		}
		else
		{
			this.ci1.gameObject.SetActive(false);
		}
		if (this.correctobj == 8)
		{
			this.ci2.gameObject.SetActive(true);
		}
		else
		{
			this.ci2.gameObject.SetActive(false);
		}
		if (this.correctobj == 9)
		{
			this.ci3.gameObject.SetActive(true);
		}
		else
		{
			this.ci3.gameObject.SetActive(false);
		}
		if (this.correctobj == 10)
		{
			this.ci4.gameObject.SetActive(true);
		}
		else
		{
			this.ci4.gameObject.SetActive(false);
		}
		if (this.correctobj == 11)
		{
			this.ci5.gameObject.SetActive(true);
		}
		else
		{
			this.ci5.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00010E44 File Offset: 0x0000F244
	private void OnGUI()
	{
		GUI.skin = this.menuskin;
		if (this.canshowinv && this.showinv)
		{
			this.windowRect = new Rect((float)(Screen.width / 2 - 185), (float)(Screen.height / 2 - 155), 370f, 310f);
			GUI.BringWindowToFront(11);
			GUI.FocusWindow(11);
			this.windowRect = GUI.Window(11, this.windowRect, new GUI.WindowFunction(this.DoMyWindow), "Inventory");
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x00010ED8 File Offset: 0x0000F2D8
	private void DoMyWindow(int windowID)
	{
		GUI.Box(new Rect(10f, 50f, 350f, 210f), string.Empty);
		if (this.flashlightbool)
		{
			Texture2D icontex = this.flashlight.GetComponent<ItemPlacement>().icontex;
			if (icontex != null && GUI.Button(new Rect(10f, 50f, 70f, 70f), icontex))
			{
				this.curobj = 1;
			}
		}
		if (this.lanternbool)
		{
			Texture2D icontex2 = this.lantern.GetComponent<ItemPlacement>().icontex;
			if (icontex2 != null && GUI.Button(new Rect(80f, 50f, 70f, 70f), icontex2))
			{
				this.curobj = 2;
			}
		}
		if (this.candlebool)
		{
			Texture2D icontex3 = this.candle.GetComponent<ItemPlacement>().icontex;
			if (icontex3 != null && GUI.Button(new Rect(150f, 50f, 70f, 70f), icontex3))
			{
				this.curobj = 3;
			}
		}
		if (this.torchbool)
		{
			Texture2D icontex4 = this.torch.GetComponent<ItemPlacement>().icontex;
			if (icontex4 != null && GUI.Button(new Rect(220f, 50f, 70f, 70f), icontex4))
			{
				this.curobj = 4;
			}
		}
		if (this.nvcamerabool)
		{
			Texture2D icontex5 = this.nvcamera.GetComponent<ItemPlacement>().icontex;
			if (icontex5 != null && GUI.Button(new Rect(290f, 50f, 70f, 70f), icontex5))
			{
				this.curobj = 5;
			}
		}
		if (this.nvgogglesbool)
		{
			Texture2D icontex6 = this.nvgoggles.GetComponent<ItemPlacement>().icontex;
			if (icontex6 != null && GUI.Button(new Rect(290f, 190f, 70f, 70f), icontex6))
			{
				this.curobj = 6;
			}
		}
		if (this.ci1bool)
		{
			Texture2D icontex7 = this.ci1.GetComponent<ItemPlacement>().icontex;
			if (icontex7 != null && GUI.Button(new Rect(10f, 120f, 70f, 70f), icontex7))
			{
				this.curobj = 7;
			}
		}
		if (this.ci2bool)
		{
			Texture2D icontex8 = this.ci2.GetComponent<ItemPlacement>().icontex;
			if (icontex8 != null && GUI.Button(new Rect(80f, 120f, 70f, 70f), icontex8))
			{
				this.curobj = 8;
			}
		}
		if (this.ci3bool)
		{
			Texture2D icontex9 = this.ci3.GetComponent<ItemPlacement>().icontex;
			if (icontex9 != null && GUI.Button(new Rect(150f, 120f, 70f, 70f), icontex9))
			{
				this.curobj = 9;
			}
		}
		if (this.ci4bool)
		{
			Texture2D icontex10 = this.ci4.GetComponent<ItemPlacement>().icontex;
			if (icontex10 != null && GUI.Button(new Rect(220f, 120f, 70f, 70f), icontex10))
			{
				this.curobj = 10;
			}
		}
		if (this.ci5bool)
		{
			Texture2D icontex11 = this.ci5.GetComponent<ItemPlacement>().icontex;
			if (icontex11 != null && GUI.Button(new Rect(290f, 120f, 70f, 70f), icontex11))
			{
				this.curobj = 11;
			}
		}
	}

	// Token: 0x040001B8 RID: 440
	public int curobj;

	// Token: 0x040001B9 RID: 441
	public int correctobj;

	// Token: 0x040001BA RID: 442
	public int pastobj;

	// Token: 0x040001BB RID: 443
	public Transform flashlight;

	// Token: 0x040001BC RID: 444
	public Transform lantern;

	// Token: 0x040001BD RID: 445
	public Transform candle;

	// Token: 0x040001BE RID: 446
	public Transform torch;

	// Token: 0x040001BF RID: 447
	public Transform nvcamera;

	// Token: 0x040001C0 RID: 448
	public Transform nvgoggles;

	// Token: 0x040001C1 RID: 449
	public Transform ci1;

	// Token: 0x040001C2 RID: 450
	public Transform ci2;

	// Token: 0x040001C3 RID: 451
	public Transform ci3;

	// Token: 0x040001C4 RID: 452
	public Transform ci4;

	// Token: 0x040001C5 RID: 453
	public Transform ci5;

	// Token: 0x040001C6 RID: 454
	public bool flashlightbool;

	// Token: 0x040001C7 RID: 455
	public bool lanternbool;

	// Token: 0x040001C8 RID: 456
	public bool candlebool;

	// Token: 0x040001C9 RID: 457
	public bool torchbool;

	// Token: 0x040001CA RID: 458
	public bool nvcamerabool;

	// Token: 0x040001CB RID: 459
	public bool nvgogglesbool;

	// Token: 0x040001CC RID: 460
	public bool ci1bool;

	// Token: 0x040001CD RID: 461
	public bool ci2bool;

	// Token: 0x040001CE RID: 462
	public bool ci3bool;

	// Token: 0x040001CF RID: 463
	public bool ci4bool;

	// Token: 0x040001D0 RID: 464
	public bool ci5bool;

	// Token: 0x040001D1 RID: 465
	public GUISkin menuskin;

	// Token: 0x040001D2 RID: 466
	public bool canshowinv;

	// Token: 0x040001D3 RID: 467
	private bool showinv;

	// Token: 0x040001D4 RID: 468
	private Rect windowRect = new Rect((float)(Screen.width - 540), (float)(Screen.height - 455), 370f, 310f);
}
