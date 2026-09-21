using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000077 RID: 119
	[CallbackIdentity(339)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameConnectedChatJoin_t
	{
		// Token: 0x0400021F RID: 543
		public const int k_iCallback = 339;

		// Token: 0x04000220 RID: 544
		public CSteamID m_steamIDClanChat;

		// Token: 0x04000221 RID: 545
		public CSteamID m_steamIDUser;
	}
}
