using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000085 RID: 133
	[CallbackIdentity(206)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSClientAchievementStatus_t
	{
		// Token: 0x0400024D RID: 589
		public const int k_iCallback = 206;

		// Token: 0x0400024E RID: 590
		public ulong m_SteamID;

		// Token: 0x0400024F RID: 591
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_pchAchievement;

		// Token: 0x04000250 RID: 592
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUnlocked;
	}
}
