using System;

namespace Steamworks
{
	// Token: 0x02000127 RID: 295
	public enum EUserRestriction
	{
		// Token: 0x0400062A RID: 1578
		k_nUserRestrictionNone,
		// Token: 0x0400062B RID: 1579
		k_nUserRestrictionUnknown,
		// Token: 0x0400062C RID: 1580
		k_nUserRestrictionAnyChat,
		// Token: 0x0400062D RID: 1581
		k_nUserRestrictionVoiceChat = 4,
		// Token: 0x0400062E RID: 1582
		k_nUserRestrictionGroupChat = 8,
		// Token: 0x0400062F RID: 1583
		k_nUserRestrictionRating = 16,
		// Token: 0x04000630 RID: 1584
		k_nUserRestrictionGameInvites = 32,
		// Token: 0x04000631 RID: 1585
		k_nUserRestrictionTrading = 64
	}
}
