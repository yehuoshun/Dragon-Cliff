using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B5 RID: 181
	[CallbackIdentity(513)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyCreated_t
	{
		// Token: 0x0400031D RID: 797
		public const int k_iCallback = 513;

		// Token: 0x0400031E RID: 798
		public EResult m_eResult;

		// Token: 0x0400031F RID: 799
		public ulong m_ulSteamIDLobby;
	}
}
