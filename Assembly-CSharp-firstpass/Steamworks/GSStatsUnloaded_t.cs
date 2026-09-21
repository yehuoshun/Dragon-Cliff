using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200008E RID: 142
	[CallbackIdentity(1108)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSStatsUnloaded_t
	{
		// Token: 0x04000273 RID: 627
		public const int k_iCallback = 1108;

		// Token: 0x04000274 RID: 628
		public CSteamID m_steamIDUser;
	}
}
