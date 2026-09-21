using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B2 RID: 178
	[CallbackIdentity(509)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyGameCreated_t
	{
		// Token: 0x04000312 RID: 786
		public const int k_iCallback = 509;

		// Token: 0x04000313 RID: 787
		public ulong m_ulSteamIDLobby;

		// Token: 0x04000314 RID: 788
		public ulong m_ulSteamIDGameServer;

		// Token: 0x04000315 RID: 789
		public uint m_unIP;

		// Token: 0x04000316 RID: 790
		public ushort m_usPort;
	}
}
