using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AE RID: 174
	[CallbackIdentity(504)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyEnter_t
	{
		// Token: 0x040002FF RID: 767
		public const int k_iCallback = 504;

		// Token: 0x04000300 RID: 768
		public ulong m_ulSteamIDLobby;

		// Token: 0x04000301 RID: 769
		public uint m_rgfChatPermissions;

		// Token: 0x04000302 RID: 770
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLocked;

		// Token: 0x04000303 RID: 771
		public uint m_EChatRoomEnterResponse;
	}
}
