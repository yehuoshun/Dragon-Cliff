using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200008C RID: 140
	[CallbackIdentity(1800)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GSStatsReceived_t
	{
		// Token: 0x0400026D RID: 621
		public const int k_iCallback = 1800;

		// Token: 0x0400026E RID: 622
		public EResult m_eResult;

		// Token: 0x0400026F RID: 623
		public CSteamID m_steamIDUser;
	}
}
