using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000078 RID: 120
	[CallbackIdentity(340)]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GameConnectedChatLeave_t
	{
		// Token: 0x04000222 RID: 546
		public const int k_iCallback = 340;

		// Token: 0x04000223 RID: 547
		public CSteamID m_steamIDClanChat;

		// Token: 0x04000224 RID: 548
		public CSteamID m_steamIDUser;

		// Token: 0x04000225 RID: 549
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bKicked;

		// Token: 0x04000226 RID: 550
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bDropped;
	}
}
