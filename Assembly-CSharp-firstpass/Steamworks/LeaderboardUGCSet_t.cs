using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000111 RID: 273
	[CallbackIdentity(1111)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardUGCSet_t
	{
		// Token: 0x04000463 RID: 1123
		public const int k_iCallback = 1111;

		// Token: 0x04000464 RID: 1124
		public EResult m_eResult;

		// Token: 0x04000465 RID: 1125
		public SteamLeaderboard_t m_hSteamLeaderboard;
	}
}
