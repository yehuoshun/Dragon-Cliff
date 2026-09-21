using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F1 RID: 241
	[CallbackIdentity(3409)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GetUserItemVoteResult_t
	{
		// Token: 0x040003F3 RID: 1011
		public const int k_iCallback = 3409;

		// Token: 0x040003F4 RID: 1012
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003F5 RID: 1013
		public EResult m_eResult;

		// Token: 0x040003F6 RID: 1014
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bVotedUp;

		// Token: 0x040003F7 RID: 1015
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bVotedDown;

		// Token: 0x040003F8 RID: 1016
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bVoteSkipped;
	}
}
