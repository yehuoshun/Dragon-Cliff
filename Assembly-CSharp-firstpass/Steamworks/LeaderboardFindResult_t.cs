using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010A RID: 266
	[CallbackIdentity(1104)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardFindResult_t
	{
		// Token: 0x04000448 RID: 1096
		public const int k_iCallback = 1104;

		// Token: 0x04000449 RID: 1097
		public SteamLeaderboard_t m_hSteamLeaderboard;

		// Token: 0x0400044A RID: 1098
		public byte m_bLeaderboardFound;
	}
}
