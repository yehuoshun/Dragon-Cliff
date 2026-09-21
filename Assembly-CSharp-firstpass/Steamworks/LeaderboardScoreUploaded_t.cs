using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010C RID: 268
	[CallbackIdentity(1106)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardScoreUploaded_t
	{
		// Token: 0x0400044F RID: 1103
		public const int k_iCallback = 1106;

		// Token: 0x04000450 RID: 1104
		public byte m_bSuccess;

		// Token: 0x04000451 RID: 1105
		public SteamLeaderboard_t m_hSteamLeaderboard;

		// Token: 0x04000452 RID: 1106
		public int m_nScore;

		// Token: 0x04000453 RID: 1107
		public byte m_bScoreChanged;

		// Token: 0x04000454 RID: 1108
		public int m_nGlobalRankNew;

		// Token: 0x04000455 RID: 1109
		public int m_nGlobalRankPrevious;
	}
}
