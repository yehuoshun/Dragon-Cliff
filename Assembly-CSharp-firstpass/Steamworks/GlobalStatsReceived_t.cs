using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000112 RID: 274
	[CallbackIdentity(1112)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GlobalStatsReceived_t
	{
		// Token: 0x04000466 RID: 1126
		public const int k_iCallback = 1112;

		// Token: 0x04000467 RID: 1127
		public ulong m_nGameID;

		// Token: 0x04000468 RID: 1128
		public EResult m_eResult;
	}
}
