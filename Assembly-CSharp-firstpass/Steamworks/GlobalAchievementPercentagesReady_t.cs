using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000110 RID: 272
	[CallbackIdentity(1110)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GlobalAchievementPercentagesReady_t
	{
		// Token: 0x04000460 RID: 1120
		public const int k_iCallback = 1110;

		// Token: 0x04000461 RID: 1121
		public ulong m_nGameID;

		// Token: 0x04000462 RID: 1122
		public EResult m_eResult;
	}
}
