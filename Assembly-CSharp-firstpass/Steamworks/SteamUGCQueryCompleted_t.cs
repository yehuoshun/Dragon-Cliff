using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E9 RID: 233
	[CallbackIdentity(3401)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamUGCQueryCompleted_t
	{
		// Token: 0x040003D3 RID: 979
		public const int k_iCallback = 3401;

		// Token: 0x040003D4 RID: 980
		public UGCQueryHandle_t m_handle;

		// Token: 0x040003D5 RID: 981
		public EResult m_eResult;

		// Token: 0x040003D6 RID: 982
		public uint m_unNumResultsReturned;

		// Token: 0x040003D7 RID: 983
		public uint m_unTotalMatchingResults;

		// Token: 0x040003D8 RID: 984
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;
	}
}
