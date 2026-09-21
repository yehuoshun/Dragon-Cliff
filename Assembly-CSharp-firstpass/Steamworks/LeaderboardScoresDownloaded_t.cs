using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010B RID: 267
	[CallbackIdentity(1105)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardScoresDownloaded_t
	{
		// Token: 0x0400044B RID: 1099
		public const int k_iCallback = 1105;

		// Token: 0x0400044C RID: 1100
		public SteamLeaderboard_t m_hSteamLeaderboard;

		// Token: 0x0400044D RID: 1101
		public SteamLeaderboardEntries_t m_hSteamLeaderboardEntries;

		// Token: 0x0400044E RID: 1102
		public int m_cEntryCount;
	}
}
