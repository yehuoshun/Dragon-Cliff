using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010E RID: 270
	[CallbackIdentity(1108)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserStatsUnloaded_t
	{
		// Token: 0x04000459 RID: 1113
		public const int k_iCallback = 1108;

		// Token: 0x0400045A RID: 1114
		public CSteamID m_steamIDUser;
	}
}
