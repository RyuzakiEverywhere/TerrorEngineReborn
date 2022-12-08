using System;

// Token: 0x0200012E RID: 302
public enum DisconnectCause
{
	// Token: 0x04000948 RID: 2376
	ExceptionOnConnect = 1023,
	// Token: 0x04000949 RID: 2377
	SecurityExceptionOnConnect = 1022,
	// Token: 0x0400094A RID: 2378
	TimeoutDisconnect = 1040,
	// Token: 0x0400094B RID: 2379
	InternalReceiveException = 1039,
	// Token: 0x0400094C RID: 2380
	DisconnectByServer = 1041,
	// Token: 0x0400094D RID: 2381
	DisconnectByServerLogic = 1043,
	// Token: 0x0400094E RID: 2382
	DisconnectByServerUserLimit = 1042,
	// Token: 0x0400094F RID: 2383
	Exception = 1026,
	// Token: 0x04000950 RID: 2384
	InvalidRegion = 32756,
	// Token: 0x04000951 RID: 2385
	MaxCcuReached
}
