using System;

namespace Steamworks
{
	// Token: 0x02000159 RID: 345
	public enum EAuthSessionResponse
	{
		// Token: 0x04000822 RID: 2082
		k_EAuthSessionResponseOK,
		// Token: 0x04000823 RID: 2083
		k_EAuthSessionResponseUserNotConnectedToSteam,
		// Token: 0x04000824 RID: 2084
		k_EAuthSessionResponseNoLicenseOrExpired,
		// Token: 0x04000825 RID: 2085
		k_EAuthSessionResponseVACBanned,
		// Token: 0x04000826 RID: 2086
		k_EAuthSessionResponseLoggedInElseWhere,
		// Token: 0x04000827 RID: 2087
		k_EAuthSessionResponseVACCheckTimedOut,
		// Token: 0x04000828 RID: 2088
		k_EAuthSessionResponseAuthTicketCanceled,
		// Token: 0x04000829 RID: 2089
		k_EAuthSessionResponseAuthTicketInvalidAlreadyUsed,
		// Token: 0x0400082A RID: 2090
		k_EAuthSessionResponseAuthTicketInvalid,
		// Token: 0x0400082B RID: 2091
		k_EAuthSessionResponsePublisherIssuedBan
	}
}
