using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000071 RID: 113
	[CallbackIdentity(333)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameLobbyJoinRequested_t
	{
		// Token: 0x04000209 RID: 521
		public const int k_iCallback = 333;

		// Token: 0x0400020A RID: 522
		public CSteamID m_steamIDLobby;

		// Token: 0x0400020B RID: 523
		public CSteamID m_steamIDFriend;
	}
}
