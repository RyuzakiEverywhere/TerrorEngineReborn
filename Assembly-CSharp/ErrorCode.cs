using System;

// Token: 0x02000131 RID: 305
public class ErrorCode
{
	// Token: 0x04000952 RID: 2386
	public const int Ok = 0;

	// Token: 0x04000953 RID: 2387
	public const int OperationNotAllowedInCurrentState = -3;

	// Token: 0x04000954 RID: 2388
	public const int InvalidOperationCode = -2;

	// Token: 0x04000955 RID: 2389
	public const int InternalServerError = -1;

	// Token: 0x04000956 RID: 2390
	public const int InvalidAuthentication = 32767;

	// Token: 0x04000957 RID: 2391
	public const int GameIdAlreadyExists = 32766;

	// Token: 0x04000958 RID: 2392
	public const int GameFull = 32765;

	// Token: 0x04000959 RID: 2393
	public const int GameClosed = 32764;

	// Token: 0x0400095A RID: 2394
	[Obsolete("No longer used, cause random matchmaking is no longer a process.")]
	public const int AlreadyMatched = 32763;

	// Token: 0x0400095B RID: 2395
	public const int ServerFull = 32762;

	// Token: 0x0400095C RID: 2396
	public const int UserBlocked = 32761;

	// Token: 0x0400095D RID: 2397
	public const int NoRandomMatchFound = 32760;

	// Token: 0x0400095E RID: 2398
	public const int GameDoesNotExist = 32758;

	// Token: 0x0400095F RID: 2399
	public const int MaxCcuReached = 32757;

	// Token: 0x04000960 RID: 2400
	public const int InvalidRegion = 32756;
}
