using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EA RID: 234
	[CallbackIdentity(3402)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamUGCRequestUGCDetailsResult_t
	{
		// Token: 0x040003D9 RID: 985
		public const int k_iCallback = 3402;

		// Token: 0x040003DA RID: 986
		public SteamUGCDetails_t m_details;

		// Token: 0x040003DB RID: 987
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;
	}
}
