using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000074 RID: 116
	[CallbackIdentity(336)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FriendRichPresenceUpdate_t
	{
		// Token: 0x04000215 RID: 533
		public const int k_iCallback = 336;

		// Token: 0x04000216 RID: 534
		public CSteamID m_steamIDFriend;

		// Token: 0x04000217 RID: 535
		public AppId_t m_nAppID;
	}
}
