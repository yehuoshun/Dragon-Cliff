using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000076 RID: 118
	[CallbackIdentity(338)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GameConnectedClanChatMsg_t
	{
		// Token: 0x0400021B RID: 539
		public const int k_iCallback = 338;

		// Token: 0x0400021C RID: 540
		public CSteamID m_steamIDClanChat;

		// Token: 0x0400021D RID: 541
		public CSteamID m_steamIDUser;

		// Token: 0x0400021E RID: 542
		public int m_iMessageID;
	}
}
