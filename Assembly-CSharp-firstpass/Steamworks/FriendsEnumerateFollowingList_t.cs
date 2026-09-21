using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200007E RID: 126
	[CallbackIdentity(346)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FriendsEnumerateFollowingList_t
	{
		// Token: 0x04000237 RID: 567
		public const int k_iCallback = 346;

		// Token: 0x04000238 RID: 568
		public EResult m_eResult;

		// Token: 0x04000239 RID: 569
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public CSteamID[] m_rgSteamID;

		// Token: 0x0400023A RID: 570
		public int m_nResultsReturned;

		// Token: 0x0400023B RID: 571
		public int m_nTotalResultCount;
	}
}
