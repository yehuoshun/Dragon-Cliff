using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000109 RID: 265
	[CallbackIdentity(1103)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserAchievementStored_t
	{
		// Token: 0x04000442 RID: 1090
		public const int k_iCallback = 1103;

		// Token: 0x04000443 RID: 1091
		public ulong m_nGameID;

		// Token: 0x04000444 RID: 1092
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bGroupAchievement;

		// Token: 0x04000445 RID: 1093
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_rgchAchievementName;

		// Token: 0x04000446 RID: 1094
		public uint m_nCurProgress;

		// Token: 0x04000447 RID: 1095
		public uint m_nMaxProgress;
	}
}
