using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B0 RID: 176
	[CallbackIdentity(506)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyChatUpdate_t
	{
		// Token: 0x04000308 RID: 776
		public const int k_iCallback = 506;

		// Token: 0x04000309 RID: 777
		public ulong m_ulSteamIDLobby;

		// Token: 0x0400030A RID: 778
		public ulong m_ulSteamIDUserChanged;

		// Token: 0x0400030B RID: 779
		public ulong m_ulSteamIDMakingChange;

		// Token: 0x0400030C RID: 780
		public uint m_rgfChatMemberStateChange;
	}
}
