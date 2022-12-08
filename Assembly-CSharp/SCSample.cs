using System;
using UnityEngine;

// Token: 0x02000282 RID: 642
public class SCSample : MonoBehaviour
{
	// Token: 0x17000344 RID: 836
	// (get) Token: 0x0600126C RID: 4716 RVA: 0x0007666A File Offset: 0x00074A6A
	// (set) Token: 0x0600126D RID: 4717 RVA: 0x00076677 File Offset: 0x00074A77
	public bool BOOL
	{
		get
		{
			return SC.ToBool(this._BOOL);
		}
		set
		{
			this._BOOL = SC.FromBool(value);
		}
	}

	// Token: 0x17000345 RID: 837
	// (get) Token: 0x0600126E RID: 4718 RVA: 0x00076685 File Offset: 0x00074A85
	// (set) Token: 0x0600126F RID: 4719 RVA: 0x00076692 File Offset: 0x00074A92
	public byte BYTE
	{
		get
		{
			return SC.ToByte(this._BYTE);
		}
		set
		{
			this._BYTE = SC.FromByte(value);
		}
	}

	// Token: 0x17000346 RID: 838
	// (get) Token: 0x06001270 RID: 4720 RVA: 0x000766A0 File Offset: 0x00074AA0
	// (set) Token: 0x06001271 RID: 4721 RVA: 0x000766AD File Offset: 0x00074AAD
	public double DOUBLE
	{
		get
		{
			return SC.ToDouble(this._DOUBLE);
		}
		set
		{
			this._DOUBLE = SC.FromDouble(value);
		}
	}

	// Token: 0x17000347 RID: 839
	// (get) Token: 0x06001272 RID: 4722 RVA: 0x000766BB File Offset: 0x00074ABB
	// (set) Token: 0x06001273 RID: 4723 RVA: 0x000766C8 File Offset: 0x00074AC8
	public int INT
	{
		get
		{
			return SC.ToInt(this._INT);
		}
		set
		{
			this._INT = SC.FromInt(value);
		}
	}

	// Token: 0x17000348 RID: 840
	// (get) Token: 0x06001274 RID: 4724 RVA: 0x000766D6 File Offset: 0x00074AD6
	// (set) Token: 0x06001275 RID: 4725 RVA: 0x000766E3 File Offset: 0x00074AE3
	public float FLOAT
	{
		get
		{
			return SC.ToFloat(this._FLOAT);
		}
		set
		{
			this._FLOAT = SC.FromFloat(value);
		}
	}

	// Token: 0x17000349 RID: 841
	// (get) Token: 0x06001276 RID: 4726 RVA: 0x000766F1 File Offset: 0x00074AF1
	// (set) Token: 0x06001277 RID: 4727 RVA: 0x000766FE File Offset: 0x00074AFE
	public string STRING
	{
		get
		{
			return SC.ToString(this._STRING);
		}
		set
		{
			this._STRING = SC.FromString(value);
		}
	}

	// Token: 0x06001278 RID: 4728 RVA: 0x0007670C File Offset: 0x00074B0C
	private void Start()
	{
		this.INT = this.Unprotected;
		base.StartCoroutine(SC.GameGuard(Application.dataPath));
	}

	// Token: 0x06001279 RID: 4729 RVA: 0x0007672B File Offset: 0x00074B2B
	private void OnApplicationQuit()
	{
		if (SC.HasGameGuard())
		{
			SC.StopGameGuard();
		}
	}

	// Token: 0x0600127A RID: 4730 RVA: 0x0007673C File Offset: 0x00074B3C
	private void OnGUI()
	{
		if (GUI.Button(new Rect(5f, 5f, 300f, 30f), "Click Me!"))
		{
			this.INT -= UnityEngine.Random.Range(1, 5);
			this.Unprotected = this.INT;
		}
		GUI.Box(new Rect(5f, (float)(Screen.height - 45), 300f, 40f), ":: Hack Me If You Can! ::\n" + this.INT);
		GUI.Box(new Rect((float)(Screen.width - 305), (float)(Screen.height - 45), 300f, 40f), ":: Very Easy To Hack ::\n" + this.Unprotected);
		GUI.Box(new Rect(5f, (float)(Screen.height - 105), (float)(Screen.width - 10), 50f), "Is this player maybe using custom cheating programs? ::  " + SC.ToBool(SC.ExtravagantCheat));
		GUI.Box(new Rect(5f, (float)(Screen.height - 165), (float)(Screen.width - 10), 50f), "Is this player hooking system APIs? ::  " + SC.ToBool(SC.SystemHooked));
	}

	// Token: 0x040012B5 RID: 4789
	public int Unprotected = 5000;

	// Token: 0x040012B6 RID: 4790
	protected string _BOOL;

	// Token: 0x040012B7 RID: 4791
	protected string _BYTE;

	// Token: 0x040012B8 RID: 4792
	protected string _DOUBLE;

	// Token: 0x040012B9 RID: 4793
	protected string _INT;

	// Token: 0x040012BA RID: 4794
	protected string _FLOAT;

	// Token: 0x040012BB RID: 4795
	protected string _STRING;
}
