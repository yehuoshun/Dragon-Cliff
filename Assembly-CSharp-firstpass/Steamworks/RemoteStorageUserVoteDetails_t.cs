using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DF RID: 223
	[CallbackIdentity(1325)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageUserVoteDetails_t
	{
		// Token: 0x040003AD RID: 941
		public const int k_iCallback = 1325;

		// Token: 0x040003AE RID: 942
		public EResult m_eResult;

		// Token: 0x040003AF RID: 943
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003B0 RID: 944
		public EWorkshopVote m_eVote;
	}
}
