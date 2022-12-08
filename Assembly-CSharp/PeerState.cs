using System;

// Token: 0x0200012B RID: 299
public enum PeerState
{
	// Token: 0x04000918 RID: 2328
	Uninitialized,
	// Token: 0x04000919 RID: 2329
	PeerCreated,
	// Token: 0x0400091A RID: 2330
	Connecting,
	// Token: 0x0400091B RID: 2331
	Connected,
	// Token: 0x0400091C RID: 2332
	Queued,
	// Token: 0x0400091D RID: 2333
	Authenticated,
	// Token: 0x0400091E RID: 2334
	JoinedLobby,
	// Token: 0x0400091F RID: 2335
	DisconnectingFromMasterserver,
	// Token: 0x04000920 RID: 2336
	ConnectingToGameserver,
	// Token: 0x04000921 RID: 2337
	ConnectedToGameserver,
	// Token: 0x04000922 RID: 2338
	Joining,
	// Token: 0x04000923 RID: 2339
	Joined,
	// Token: 0x04000924 RID: 2340
	Leaving,
	// Token: 0x04000925 RID: 2341
	DisconnectingFromGameserver,
	// Token: 0x04000926 RID: 2342
	ConnectingToMasterserver,
	// Token: 0x04000927 RID: 2343
	ConnectedComingFromGameserver,
	// Token: 0x04000928 RID: 2344
	QueuedComingFromGameserver,
	// Token: 0x04000929 RID: 2345
	Disconnecting,
	// Token: 0x0400092A RID: 2346
	Disconnected,
	// Token: 0x0400092B RID: 2347
	ConnectedToMaster
}
