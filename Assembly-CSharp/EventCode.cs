using System;

// Token: 0x02000134 RID: 308
public class EventCode
{
	// Token: 0x04000969 RID: 2409
	public const byte GameList = 230;

	// Token: 0x0400096A RID: 2410
	public const byte GameListUpdate = 229;

	// Token: 0x0400096B RID: 2411
	public const byte QueueState = 228;

	// Token: 0x0400096C RID: 2412
	public const byte Match = 227;

	// Token: 0x0400096D RID: 2413
	public const byte AppStats = 226;

	// Token: 0x0400096E RID: 2414
	public const byte AzureNodeInfo = 210;

	// Token: 0x0400096F RID: 2415
	public const byte Join = 255;

	// Token: 0x04000970 RID: 2416
	public const byte Leave = 254;

	// Token: 0x04000971 RID: 2417
	public const byte PropertiesChanged = 253;

	// Token: 0x04000972 RID: 2418
	[Obsolete("Use PropertiesChanged now.")]
	public const byte SetProperties = 253;
}
