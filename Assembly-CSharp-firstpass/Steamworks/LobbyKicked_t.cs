using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B4 RID: 180
	[CallbackIdentity(512)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyKicked_t
	{
		// Token: 0x04000319 RID: 793
		public const int k_iCallback = 512;

		// Token: 0x0400031A RID: 794
		public ulong m_ulSteamIDLobby;

		// Token: 0x0400031B RID: 795
		public ulong m_ulSteamIDAdmin;

		// Token: 0x0400031C RID: 796
		public byte m_bKickedDueToDisconnect;
	}
}
