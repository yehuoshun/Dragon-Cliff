using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000088 RID: 136
	[CallbackIdentity(208)]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GSClientGroupStatus_t
	{
		// Token: 0x04000258 RID: 600
		public const int k_iCallback = 208;

		// Token: 0x04000259 RID: 601
		public CSteamID m_SteamIDUser;

		// Token: 0x0400025A RID: 602
		public CSteamID m_SteamIDGroup;

		// Token: 0x0400025B RID: 603
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bMember;

		// Token: 0x0400025C RID: 604
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bOfficer;
	}
}
