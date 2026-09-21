using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010F RID: 271
	[CallbackIdentity(1109)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserAchievementIconFetched_t
	{
		// Token: 0x0400045B RID: 1115
		public const int k_iCallback = 1109;

		// Token: 0x0400045C RID: 1116
		public CGameID m_nGameID;

		// Token: 0x0400045D RID: 1117
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_rgchAchievementName;

		// Token: 0x0400045E RID: 1118
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAchieved;

		// Token: 0x0400045F RID: 1119
		public int m_nIconHandle;
	}
}
