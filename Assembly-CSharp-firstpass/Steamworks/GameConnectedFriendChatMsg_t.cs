using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200007B RID: 123
	[CallbackIdentity(343)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GameConnectedFriendChatMsg_t
	{
		// Token: 0x0400022C RID: 556
		public const int k_iCallback = 343;

		// Token: 0x0400022D RID: 557
		public CSteamID m_steamIDUser;

		// Token: 0x0400022E RID: 558
		public int m_iMessageID;
	}
}
