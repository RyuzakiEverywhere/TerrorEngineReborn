using System;
using UnityEngine;

// Token: 0x020001B9 RID: 441
public class SunshineProjectPreferences : ScriptableObject
{
	// Token: 0x170000CB RID: 203
	// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0005C918 File Offset: 0x0005AD18
	public static SunshineProjectPreferences Instance
	{
		get
		{
			if (SunshineProjectPreferences.instance == null)
			{
				SunshineProjectPreferences.instance = SunshineProjectPreferences.Load();
			}
			return SunshineProjectPreferences.instance;
		}
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x0005C93C File Offset: 0x0005AD3C
	private static SunshineProjectPreferences Load()
	{
		SunshineProjectPreferences sunshineProjectPreferences = null;
		try
		{
			sunshineProjectPreferences = (Resources.Load("SunshinePreferences", typeof(SunshineProjectPreferences)) as SunshineProjectPreferences);
		}
		catch
		{
		}
		if (sunshineProjectPreferences == null)
		{
			sunshineProjectPreferences = ScriptableObject.CreateInstance<SunshineProjectPreferences>();
			sunshineProjectPreferences.name = "Sunshine Project Configuration";
			sunshineProjectPreferences.hideFlags = HideFlags.NotEditable;
		}
		return sunshineProjectPreferences;
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x0005C9A8 File Offset: 0x0005ADA8
	public void SaveIfDirty()
	{
	}

	// Token: 0x170000CC RID: 204
	// (get) Token: 0x06000A85 RID: 2693 RVA: 0x0005C9AA File Offset: 0x0005ADAA
	// (set) Token: 0x06000A86 RID: 2694 RVA: 0x0005C9B2 File Offset: 0x0005ADB2
	public string Version
	{
		get
		{
			return this.version;
		}
		set
		{
			if (this.version == value)
			{
				return;
			}
			this.version = value;
		}
	}

	// Token: 0x170000CD RID: 205
	// (get) Token: 0x06000A87 RID: 2695 RVA: 0x0005C9CD File Offset: 0x0005ADCD
	// (set) Token: 0x06000A88 RID: 2696 RVA: 0x0005C9D5 File Offset: 0x0005ADD5
	public bool ForwardShadersInstalled
	{
		get
		{
			return this.forwardShadersInstalled;
		}
		set
		{
			if (this.forwardShadersInstalled == value)
			{
				return;
			}
			this.forwardShadersInstalled = value;
		}
	}

	// Token: 0x170000CE RID: 206
	// (get) Token: 0x06000A89 RID: 2697 RVA: 0x0005C9EB File Offset: 0x0005ADEB
	// (set) Token: 0x06000A8A RID: 2698 RVA: 0x0005C9F3 File Offset: 0x0005ADF3
	public bool UseCustomShadows
	{
		get
		{
			return this.useCustomShadows;
		}
		set
		{
			if (this.useCustomShadows == value)
			{
				return;
			}
			this.useCustomShadows = value;
		}
	}

	// Token: 0x170000CF RID: 207
	// (get) Token: 0x06000A8B RID: 2699 RVA: 0x0005CA09 File Offset: 0x0005AE09
	// (set) Token: 0x06000A8C RID: 2700 RVA: 0x0005CA11 File Offset: 0x0005AE11
	public bool ManualShaderInstallation
	{
		get
		{
			return this.manualShaderInstallation;
		}
		set
		{
			if (this.manualShaderInstallation == value)
			{
				return;
			}
			this.manualShaderInstallation = value;
		}
	}

	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x06000A8D RID: 2701 RVA: 0x0005CA27 File Offset: 0x0005AE27
	// (set) Token: 0x06000A8E RID: 2702 RVA: 0x0005CA2F File Offset: 0x0005AE2F
	public bool InstallerRunning
	{
		get
		{
			return this.installerRunning;
		}
		set
		{
			if (this.installerRunning == value)
			{
				return;
			}
			this.installerRunning = value;
		}
	}

	// Token: 0x04000C71 RID: 3185
	public const string AssetPath = "Assets/Sunshine/Resources/SunshinePreferences.asset";

	// Token: 0x04000C72 RID: 3186
	public const string ResourceName = "SunshinePreferences";

	// Token: 0x04000C73 RID: 3187
	private static SunshineProjectPreferences instance;

	// Token: 0x04000C74 RID: 3188
	[SerializeField]
	private string version = string.Empty;

	// Token: 0x04000C75 RID: 3189
	[SerializeField]
	private bool forwardShadersInstalled;

	// Token: 0x04000C76 RID: 3190
	[SerializeField]
	private bool useCustomShadows;

	// Token: 0x04000C77 RID: 3191
	[SerializeField]
	private bool manualShaderInstallation = true;

	// Token: 0x04000C78 RID: 3192
	[SerializeField]
	private bool installerRunning;
}
