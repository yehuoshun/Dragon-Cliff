using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000175 RID: 373
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardEntry_t
	{
		// Token: 0x0400094B RID: 2379
		public CSteamID m_steamIDUser;

		// Token: 0x0400094C RID: 2380
		public int m_nGlobalRank;

		// Token: 0x0400094D RID: 2381
		public int m_nScore;

		// Token: 0x0400094E RID: 2382
		public int m_cDetails;

		// Token: 0x0400094F RID: 2383
		public UGCHandle_t m_hUGC;
	}
}
