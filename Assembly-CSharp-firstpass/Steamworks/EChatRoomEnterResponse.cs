using System;

namespace Steamworks
{
	// Token: 0x02000161 RID: 353
	public enum EChatRoomEnterResponse
	{
		// Token: 0x04000882 RID: 2178
		k_EChatRoomEnterResponseSuccess = 1,
		// Token: 0x04000883 RID: 2179
		k_EChatRoomEnterResponseDoesntExist,
		// Token: 0x04000884 RID: 2180
		k_EChatRoomEnterResponseNotAllowed,
		// Token: 0x04000885 RID: 2181
		k_EChatRoomEnterResponseFull,
		// Token: 0x04000886 RID: 2182
		k_EChatRoomEnterResponseError,
		// Token: 0x04000887 RID: 2183
		k_EChatRoomEnterResponseBanned,
		// Token: 0x04000888 RID: 2184
		k_EChatRoomEnterResponseLimited,
		// Token: 0x04000889 RID: 2185
		k_EChatRoomEnterResponseClanDisabled,
		// Token: 0x0400088A RID: 2186
		k_EChatRoomEnterResponseCommunityBan,
		// Token: 0x0400088B RID: 2187
		k_EChatRoomEnterResponseMemberBlockedYou,
		// Token: 0x0400088C RID: 2188
		k_EChatRoomEnterResponseYouBlockedMember,
		// Token: 0x0400088D RID: 2189
		k_EChatRoomEnterResponseRatelimitExceeded = 15
	}
}
