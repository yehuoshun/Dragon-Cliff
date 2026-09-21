using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DE RID: 222
	[CallbackIdentity(1324)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageUpdateUserPublishedItemVoteResult_t
	{
		// Token: 0x040003AA RID: 938
		public const int k_iCallback = 1324;

		// Token: 0x040003AB RID: 939
		public EResult m_eResult;

		// Token: 0x040003AC RID: 940
		public PublishedFileId_t m_nPublishedFileId;
	}
}
