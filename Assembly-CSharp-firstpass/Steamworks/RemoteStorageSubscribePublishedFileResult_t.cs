using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D3 RID: 211
	[CallbackIdentity(1313)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageSubscribePublishedFileResult_t
	{
		// Token: 0x04000365 RID: 869
		public const int k_iCallback = 1313;

		// Token: 0x04000366 RID: 870
		public EResult m_eResult;

		// Token: 0x04000367 RID: 871
		public PublishedFileId_t m_nPublishedFileId;
	}
}
