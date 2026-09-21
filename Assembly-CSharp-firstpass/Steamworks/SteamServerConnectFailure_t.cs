using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000FC RID: 252
	[CallbackIdentity(102)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamServerConnectFailure_t
	{
		// Token: 0x0400041C RID: 1052
		public const int k_iCallback = 102;

		// Token: 0x0400041D RID: 1053
		public EResult m_eResult;

		// Token: 0x0400041E RID: 1054
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bStillRetrying;
	}
}
