using System;
using UnityEngine;

// Token: 0x020001B2 RID: 434
public static class SunshineKeywords
{
	// Token: 0x06000A46 RID: 2630 RVA: 0x0005BBB8 File Offset: 0x00059FB8
	private static void SetKeyword(int index, string[] keywords)
	{
		for (int i = 0; i < keywords.Length; i++)
		{
			if (i == index)
			{
				Shader.EnableKeyword(keywords[i]);
			}
			else
			{
				Shader.DisableKeyword(keywords[i]);
			}
		}
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x0005BBF8 File Offset: 0x00059FF8
	private static void SetKeywordWithFallbacks(int index, string[] keywords, int minimumFallback)
	{
		for (int i = 0; i < keywords.Length; i++)
		{
			if (i == index || (i < index && i >= minimumFallback))
			{
				Shader.EnableKeyword(keywords[i]);
			}
			else
			{
				Shader.DisableKeyword(keywords[i]);
			}
		}
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x0005BC43 File Offset: 0x0005A043
	private static void ToggleKeyword(bool toggle, string keywordON, string keywordOFF)
	{
		Shader.DisableKeyword((!toggle) ? keywordON : keywordOFF);
		Shader.EnableKeyword((!toggle) ? keywordOFF : keywordON);
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x0005BC69 File Offset: 0x0005A069
	private static void ToggleKeyword(bool toggle, string keyword)
	{
		if (toggle)
		{
			Shader.EnableKeyword(keyword);
		}
		else
		{
			Shader.DisableKeyword(keyword);
		}
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x0005BC82 File Offset: 0x0005A082
	public static void SetCascadeCount(int i)
	{
		if (SunshineKeywords.cascadeCount.Change(Mathf.Clamp(i - 1, 0, 3)))
		{
			SunshineKeywords.SetKeyword(SunshineKeywords.cascadeCount.Value, SunshineKeywords.X_CASCADES);
		}
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x0005BCB1 File Offset: 0x0005A0B1
	public static void ToggleOvercast(bool enabled)
	{
		if (SunshineKeywords.overcast.Change(enabled))
		{
			SunshineKeywords.ToggleKeyword(enabled, "SUNSHINE_OVERCAST_ON", "SUNSHINE_OVERCAST_OFF");
		}
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x0005BCD3 File Offset: 0x0005A0D3
	public static void SetFilterStyle(int style)
	{
		SunshineKeywords.SetKeywordWithFallbacks(style, SunshineKeywords.FILTER_STYLES, 1);
	}

	// Token: 0x06000A4D RID: 2637 RVA: 0x0005BCE1 File Offset: 0x0005A0E1
	public static void SetFilterStyle(SunshineShadowFilters style)
	{
		SunshineKeywords.SetFilterStyle((int)(style + 1));
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x0005BCEB File Offset: 0x0005A0EB
	public static void DisableShadows()
	{
		SunshineKeywords.SetFilterStyle(0);
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x0005BCF3 File Offset: 0x0005A0F3
	public static void SetScatterQuality(SunshineScatterSamplingQualities quality)
	{
		SunshineKeywords.SetKeyword((int)quality, SunshineKeywords.SCATTER_QUALITIES);
	}

	// Token: 0x04000C52 RID: 3154
	private const string ONE_CASCADE = "SUNSHINE_ONE_CASCADE";

	// Token: 0x04000C53 RID: 3155
	private const string TWO_CASCADES = "SUNSHINE_TWO_CASCADES";

	// Token: 0x04000C54 RID: 3156
	private const string THREE_CASCADES = "SUNSHINE_THREE_CASCADES";

	// Token: 0x04000C55 RID: 3157
	private const string FOUR_CASCADES = "SUNSHINE_FOUR_CASCADES";

	// Token: 0x04000C56 RID: 3158
	private static readonly string[] X_CASCADES = new string[]
	{
		"SUNSHINE_ONE_CASCADE",
		"SUNSHINE_TWO_CASCADES",
		"SUNSHINE_THREE_CASCADES",
		"SUNSHINE_FOUR_CASCADES"
	};

	// Token: 0x04000C57 RID: 3159
	private static SunshineKeywords.ChangeTracker cascadeCount = new SunshineKeywords.ChangeTracker();

	// Token: 0x04000C58 RID: 3160
	private const string OVERCAST_ON = "SUNSHINE_OVERCAST_ON";

	// Token: 0x04000C59 RID: 3161
	private const string OVERCAST_OFF = "SUNSHINE_OVERCAST_OFF";

	// Token: 0x04000C5A RID: 3162
	private static SunshineKeywords.ChangeTracker overcast = new SunshineKeywords.ChangeTracker();

	// Token: 0x04000C5B RID: 3163
	private const string FILTER_DISABLED = "SUNSHINE_DISABLED";

	// Token: 0x04000C5C RID: 3164
	private const string FILTER_HARD = "SUNSHINE_FILTER_HARD";

	// Token: 0x04000C5D RID: 3165
	private const string FILTER_PCF_2x2 = "SUNSHINE_FILTER_PCF_2x2";

	// Token: 0x04000C5E RID: 3166
	private const string FILTER_PCF_3x3 = "SUNSHINE_FILTER_PCF_3x3";

	// Token: 0x04000C5F RID: 3167
	private const string FILTER_PCF_4x4 = "SUNSHINE_FILTER_PCF_4x4";

	// Token: 0x04000C60 RID: 3168
	private static readonly string[] FILTER_STYLES = new string[]
	{
		"SUNSHINE_DISABLED",
		"SUNSHINE_FILTER_HARD",
		"SUNSHINE_FILTER_PCF_2x2",
		"SUNSHINE_FILTER_PCF_3x3",
		"SUNSHINE_FILTER_PCF_4x4"
	};

	// Token: 0x04000C61 RID: 3169
	private const string SCATTER_QUALITY_LOW = "SUNSHINE_FILTER_HARD";

	// Token: 0x04000C62 RID: 3170
	private const string SCATTER_QUALITY_MEDIUM = "SUNSHINE_FILTER_PCF_2x2";

	// Token: 0x04000C63 RID: 3171
	private const string SCATTER_QUALITY_HIGH = "SUNSHINE_FILTER_PCF_3x3";

	// Token: 0x04000C64 RID: 3172
	private const string SCATTER_QUALITY_VERYHIGH = "SUNSHINE_FILTER_PCF_4x4";

	// Token: 0x04000C65 RID: 3173
	private static readonly string[] SCATTER_QUALITIES = new string[]
	{
		"SUNSHINE_FILTER_HARD",
		"SUNSHINE_FILTER_PCF_2x2",
		"SUNSHINE_FILTER_PCF_3x3",
		"SUNSHINE_FILTER_PCF_4x4"
	};

	// Token: 0x020001B3 RID: 435
	private class ChangeTracker
	{
		// Token: 0x06000A52 RID: 2642 RVA: 0x0005BDB9 File Offset: 0x0005A1B9
		public bool Change(int newValue)
		{
			if (newValue != this.lastValue)
			{
				this.lastValue = newValue;
				return true;
			}
			return false;
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0005BDD1 File Offset: 0x0005A1D1
		public bool Change(bool newValue)
		{
			return this.Change((!newValue) ? 0 : 1);
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0005BDE6 File Offset: 0x0005A1E6
		public int Value
		{
			get
			{
				return this.lastValue;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x0005BDEE File Offset: 0x0005A1EE
		public bool ValueBool
		{
			get
			{
				return this.lastValue > 0;
			}
		}

		// Token: 0x04000C66 RID: 3174
		private int lastValue = -1;
	}
}
