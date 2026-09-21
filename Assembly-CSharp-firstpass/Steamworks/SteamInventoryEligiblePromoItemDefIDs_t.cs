using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AB RID: 171
	[CallbackIdentity(4703)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamInventoryEligiblePromoItemDefIDs_t
	{
		// Token: 0x040002EE RID: 750
		public const int k_iCallback = 4703;

		// Token: 0x040002EF RID: 751
		public EResult m_result;

		// Token: 0x040002F0 RID: 752
		public CSteamID m_steamID;

		// Token: 0x040002F1 RID: 753
		public int m_numEligiblePromoItemDefs;

		// Token: 0x040002F2 RID: 754
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;
	}
}
