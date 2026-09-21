using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AD RID: 173
	[CallbackIdentity(503)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyInvite_t
	{
		// Token: 0x040002FB RID: 763
		public const int k_iCallback = 503;

		// Token: 0x040002FC RID: 764
		public ulong m_ulSteamIDUser;

		// Token: 0x040002FD RID: 765
		public ulong m_ulSteamIDLobby;

		// Token: 0x040002FE RID: 766
		public ulong m_ulGameID;
	}
}
