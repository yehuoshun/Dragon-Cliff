using System;

namespace Steamworks
{
	// Token: 0x02000136 RID: 310
	public enum ESNetSocketState
	{
		// Token: 0x040006AC RID: 1708
		k_ESNetSocketStateInvalid,
		// Token: 0x040006AD RID: 1709
		k_ESNetSocketStateConnected,
		// Token: 0x040006AE RID: 1710
		k_ESNetSocketStateInitiated = 10,
		// Token: 0x040006AF RID: 1711
		k_ESNetSocketStateLocalCandidatesFound,
		// Token: 0x040006B0 RID: 1712
		k_ESNetSocketStateReceivedRemoteCandidates,
		// Token: 0x040006B1 RID: 1713
		k_ESNetSocketStateChallengeHandshake = 15,
		// Token: 0x040006B2 RID: 1714
		k_ESNetSocketStateDisconnecting = 21,
		// Token: 0x040006B3 RID: 1715
		k_ESNetSocketStateLocalDisconnect,
		// Token: 0x040006B4 RID: 1716
		k_ESNetSocketStateTimeoutDuringConnect,
		// Token: 0x040006B5 RID: 1717
		k_ESNetSocketStateRemoteEndDisconnected,
		// Token: 0x040006B6 RID: 1718
		k_ESNetSocketStateConnectionBroken
	}
}
