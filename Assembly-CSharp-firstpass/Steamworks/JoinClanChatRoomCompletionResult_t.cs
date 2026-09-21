using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200007A RID: 122
	[CallbackIdentity(342)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct JoinClanChatRoomCompletionResult_t
	{
		// Token: 0x04000229 RID: 553
		public const int k_iCallback = 342;

		// Token: 0x0400022A RID: 554
		public CSteamID m_steamIDClanChat;

		// Token: 0x0400022B RID: 555
		public EChatRoomEnterResponse m_eChatRoomEnterResponse;
	}
}
