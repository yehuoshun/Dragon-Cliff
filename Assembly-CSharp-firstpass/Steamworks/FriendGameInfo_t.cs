using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200016E RID: 366
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct FriendGameInfo_t
	{
		// Token: 0x04000918 RID: 2328
		public CGameID m_gameID;

		// Token: 0x04000919 RID: 2329
		public uint m_unGameIP;

		// Token: 0x0400091A RID: 2330
		public ushort m_usGamePort;

		// Token: 0x0400091B RID: 2331
		public ushort m_usQueryPort;

		// Token: 0x0400091C RID: 2332
		public CSteamID m_steamIDLobby;
	}
}
