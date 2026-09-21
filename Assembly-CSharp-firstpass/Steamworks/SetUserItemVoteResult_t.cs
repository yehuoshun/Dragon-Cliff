using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F0 RID: 240
	[CallbackIdentity(3408)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SetUserItemVoteResult_t
	{
		// Token: 0x040003EF RID: 1007
		public const int k_iCallback = 3408;

		// Token: 0x040003F0 RID: 1008
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003F1 RID: 1009
		public EResult m_eResult;

		// Token: 0x040003F2 RID: 1010
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bVoteUp;
	}
}
