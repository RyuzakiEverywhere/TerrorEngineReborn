using System;
using UnityEngine;

// Token: 0x020000E5 RID: 229
public class LightProperties : MonoBehaviour
{
	// Token: 0x0600044A RID: 1098 RVA: 0x0002F5A0 File Offset: 0x0002D9A0
	private void Start()
	{
		this.skin = (Resources.Load("Amiga500GUISkin") as GUISkin);
		this.mmf = (Resources.Load("Flares/Mmzoom") as Flare);
		this.sl = (Resources.Load("Flares/StreetLights") as Flare);
		this.sf = (Resources.Load("Flares/SmallFlare") as Flare);
		this.s = (Resources.Load("Flares/Sun") as Flare);
		if (this.noflare)
		{
			base.GetComponent<Light>().flare = null;
		}
		if (this.mmflare)
		{
			base.GetComponent<Light>().flare = this.mmf;
		}
		if (this.streetlight)
		{
			base.GetComponent<Light>().flare = this.sl;
		}
		if (this.smallflare)
		{
			base.GetComponent<Light>().flare = this.sf;
		}
		if (this.sun)
		{
			base.GetComponent<Light>().flare = this.s;
		}
		this.range = base.gameObject.GetComponent<Light>().range.ToString();
		this.strength = base.gameObject.GetComponent<Light>().intensity.ToString();
		base.gameObject.GetComponent<MeshRenderer>().castShadows = false;
		base.gameObject.GetComponent<MeshRenderer>().receiveShadows = false;
		if (!this.toggleshadow)
		{
			base.gameObject.GetComponent<Light>().shadows = LightShadows.Hard;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.blue)
		{
			this.blue = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.cyan)
		{
			this.cyan = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.green)
		{
			this.green = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.grey)
		{
			this.grey = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.magenta)
		{
			this.magenta = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.red)
		{
			this.red = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.white)
		{
			this.white = true;
		}
		if (base.gameObject.GetComponent<Light>().color == Color.yellow)
		{
			this.yellow = true;
		}
		if (base.gameObject.GetComponent<Light>().color == new Color(1f, 0.76f, 0.16f))
		{
			this.orange = true;
		}
		base.gameObject.GetComponent<LightProperties>().enabled = false;
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0002F89C File Offset: 0x0002DC9C
	private void Update()
	{
		if (this.toggleshadow)
		{
			base.gameObject.GetComponent<Light>().shadows = LightShadows.Hard;
		}
		else
		{
			base.gameObject.GetComponent<Light>().shadows = LightShadows.None;
		}
		base.gameObject.GetComponent<Light>().range = float.Parse(this.range);
		base.gameObject.GetComponent<Light>().intensity = float.Parse(this.strength);
		if (this.blue)
		{
			base.gameObject.GetComponent<Light>().color = Color.blue;
		}
		if (this.cyan)
		{
			base.gameObject.GetComponent<Light>().color = Color.cyan;
		}
		if (this.green)
		{
			base.gameObject.GetComponent<Light>().color = Color.green;
		}
		if (this.grey)
		{
			base.gameObject.GetComponent<Light>().color = Color.grey;
		}
		if (this.magenta)
		{
			base.gameObject.GetComponent<Light>().color = Color.magenta;
		}
		if (this.red)
		{
			base.gameObject.GetComponent<Light>().color = Color.red;
		}
		if (this.white)
		{
			base.gameObject.GetComponent<Light>().color = Color.white;
		}
		if (this.yellow)
		{
			base.gameObject.GetComponent<Light>().color = Color.yellow;
		}
		if (this.orange)
		{
			base.gameObject.GetComponent<Light>().color = new Color(1f, 0.76f, 0.16f);
		}
		if (GameObject.Find("Play"))
		{
			UnityEngine.Object.Destroy(this);
		}
		if (!base.gameObject.GetComponent<PositionAndScale>().enabled)
		{
			base.gameObject.GetComponent<LightProperties>().enabled = false;
		}
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0002FA80 File Offset: 0x0002DE80
	private void WallWindow(int windowID)
	{
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 37f, 234f, (float)(Screen.height - 338)), this.scrollPosition, new Rect(0f, 0f, 220f, 350f));
		GUI.Box(new Rect(30f, 100f, 180f, 200f), "Settings");
		this.togglevisible = GUI.Toggle(new Rect(40f, 20f, 100f, 20f), this.togglevisible, "Enabled At Start");
		this.toggleshadow = GUI.Toggle(new Rect(40f, 40f, 100f, 20f), this.toggleshadow, "Cast Shadows");
		this.toggleflicker = GUI.Toggle(new Rect(40f, 60f, 100f, 20f), this.toggleflicker, "Flicker");
		GUI.Label(new Rect(30f, 130f, 180f, 200f), "Range");
		this.range = GUI.TextField(new Rect(30f, 150f, 50f, 20f), this.range);
		GUI.Label(new Rect(30f, 180f, 180f, 200f), "Strength");
		this.strength = GUI.TextField(new Rect(30f, 200f, 50f, 20f), this.strength);
		GUI.Label(new Rect(30f, 220f, 180f, 280f), "Color & Flare");
		if (this.white && GUI.Button(new Rect(70f, 250f, 100f, 20f), "White"))
		{
			this.white = false;
			this.blue = true;
			this.cyan = false;
			this.green = false;
			this.grey = false;
			this.magenta = false;
			this.red = false;
			this.yellow = false;
			this.orange = false;
		}
		if (this.blue && GUI.Button(new Rect(70f, 250f, 100f, 20f), "Blue"))
		{
			this.white = false;
			this.blue = false;
			this.cyan = true;
			this.green = false;
			this.grey = false;
			this.magenta = false;
			this.red = false;
			this.yellow = false;
			this.orange = false;
		}
		if (this.cyan && GUI.Button(new Rect(70f, 250f, 100f, 20f), "Cyan"))
		{
			this.white = false;
			this.blue = false;
			this.cyan = false;
			this.green = true;
			this.grey = false;
			this.magenta = false;
			this.red = false;
			this.yellow = false;
			this.orange = false;
		}
		if (this.green && GUI.Button(new Rect(70f, 250f, 100f, 20f), "Green"))
		{
			this.white = false;
			this.blue = false;
			this.cyan = false;
			this.green = false;
			this.grey = true;
			this.magenta = false;
			this.red = false;
			this.yellow = false;
			this.orange = false;
		}
		if (this.grey && GUI.Button(new Rect(70f, 250f, 100f, 20f), "Grey"))
		{
			this.white = false;
			this.blue = false;
			this.cyan = false;
			this.green = false;
			this.grey = false;
			this.magenta = true;
			this.red = false;
			this.yellow = false;
			this.orange = false;
		}
		if (this.magenta && GUI.Button(new Rect(70f, 250f, 100f, 20f), "Magenta"))
		{
			this.white = false;
			this.blue = false;
			this.cyan = false;
			this.green = false;
			this.grey = false;
			this.magenta = false;
			this.red = true;
			this.yellow = false;
			this.orange = false;
		}
		if (this.red && GUI.Button(new Rect(70f, 250f, 100f, 20f), "Red"))
		{
			this.white = false;
			this.blue = false;
			this.cyan = false;
			this.green = false;
			this.grey = false;
			this.magenta = false;
			this.red = false;
			this.yellow = true;
			this.orange = false;
		}
		if (this.yellow && GUI.Button(new Rect(70f, 250f, 100f, 20f), "Yellow"))
		{
			this.white = false;
			this.blue = false;
			this.cyan = false;
			this.green = false;
			this.grey = false;
			this.magenta = false;
			this.red = false;
			this.yellow = false;
			this.orange = true;
		}
		if (this.orange && GUI.Button(new Rect(70f, 250f, 100f, 20f), "Orange"))
		{
			this.white = true;
			this.blue = false;
			this.cyan = false;
			this.green = false;
			this.grey = false;
			this.magenta = false;
			this.red = false;
			this.yellow = false;
			this.orange = false;
		}
		if (this.noflare && GUI.Button(new Rect(70f, 275f, 100f, 20f), "No Flare"))
		{
			base.GetComponent<Light>().flare = this.mmf;
			this.noflare = false;
			this.mmflare = true;
			this.streetlight = false;
			this.smallflare = false;
			this.sun = false;
		}
		if (this.mmflare && GUI.Button(new Rect(70f, 275f, 100f, 20f), "50mm Flare"))
		{
			base.GetComponent<Light>().flare = this.sl;
			this.noflare = false;
			this.mmflare = false;
			this.streetlight = true;
			this.smallflare = false;
			this.sun = false;
		}
		if (this.streetlight && GUI.Button(new Rect(70f, 275f, 100f, 20f), "Streetlight"))
		{
			base.GetComponent<Light>().flare = this.sf;
			this.noflare = false;
			this.mmflare = false;
			this.streetlight = false;
			this.smallflare = true;
			this.sun = false;
		}
		if (this.smallflare && GUI.Button(new Rect(70f, 275f, 100f, 20f), "Small Flare"))
		{
			base.GetComponent<Light>().flare = this.s;
			this.noflare = false;
			this.mmflare = false;
			this.streetlight = false;
			this.smallflare = false;
			this.sun = true;
		}
		if (this.sun && GUI.Button(new Rect(70f, 275f, 100f, 20f), "Sun"))
		{
			base.GetComponent<Light>().flare = null;
			this.noflare = true;
			this.mmflare = false;
			this.streetlight = false;
			this.smallflare = false;
			this.sun = false;
		}
		GUI.EndScrollView();
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x0003024C File Offset: 0x0002E64C
	private void OnGUI()
	{
		GUI.skin = this.skin;
		GUI.Window(0, new Rect((float)(Screen.width - 250), 291f, 245f, (float)(Screen.height - 285)), new GUI.WindowFunction(this.WallWindow), "Editor");
	}

	// Token: 0x04000673 RID: 1651
	public GUISkin skin;

	// Token: 0x04000674 RID: 1652
	public Vector2 scrollPosition;

	// Token: 0x04000675 RID: 1653
	public bool toggleshadow = true;

	// Token: 0x04000676 RID: 1654
	public bool toggleflicker;

	// Token: 0x04000677 RID: 1655
	public bool togglevisible = true;

	// Token: 0x04000678 RID: 1656
	public string strength;

	// Token: 0x04000679 RID: 1657
	public string range;

	// Token: 0x0400067A RID: 1658
	public bool blue;

	// Token: 0x0400067B RID: 1659
	public bool cyan;

	// Token: 0x0400067C RID: 1660
	public bool green;

	// Token: 0x0400067D RID: 1661
	public bool grey;

	// Token: 0x0400067E RID: 1662
	public bool magenta;

	// Token: 0x0400067F RID: 1663
	public bool red;

	// Token: 0x04000680 RID: 1664
	public bool white;

	// Token: 0x04000681 RID: 1665
	public bool yellow;

	// Token: 0x04000682 RID: 1666
	public bool orange;

	// Token: 0x04000683 RID: 1667
	public bool noflare = true;

	// Token: 0x04000684 RID: 1668
	public bool mmflare;

	// Token: 0x04000685 RID: 1669
	public bool streetlight;

	// Token: 0x04000686 RID: 1670
	public bool smallflare;

	// Token: 0x04000687 RID: 1671
	public bool sun;

	// Token: 0x04000688 RID: 1672
	public Flare mmf;

	// Token: 0x04000689 RID: 1673
	public Flare sl;

	// Token: 0x0400068A RID: 1674
	public Flare sf;

	// Token: 0x0400068B RID: 1675
	public Flare s;
}
