using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000108 RID: 264
	[CallbackIdentity(1102)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserStatsStored_t
	{
		// Token: 0x0400043F RID: 1087
		public const int k_iCallback = 1102;

		// Token: 0x04000440 RID: 1088
		public ulong m_nGameID;

		// Token: 0x04000441 RID: 1089
		public EResult m_eResult;
	}
}
