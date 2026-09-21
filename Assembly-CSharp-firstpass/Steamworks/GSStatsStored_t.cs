using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200008D RID: 141
	[CallbackIdentity(1801)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GSStatsStored_t
	{
		// Token: 0x04000270 RID: 624
		public const int k_iCallback = 1801;

		// Token: 0x04000271 RID: 625
		public EResult m_eResult;

		// Token: 0x04000272 RID: 626
		public CSteamID m_steamIDUser;
	}
}
